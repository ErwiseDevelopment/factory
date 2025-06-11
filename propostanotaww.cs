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
   public class propostanotaww : GXDataArea
   {
      public propostanotaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanotaww( IGxContext context )
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
         cmbPropostaTipoProposta = new GXCombobox();
         cmbPropostaStatus = new GXCombobox();
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
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV59Pgmname = GetPar( "Pgmname");
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV18PropostaQtdItensNota_F1 = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaQtdItensNota_F1"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22PropostaQtdItensNota_F2 = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaQtdItensNota_F2"), "."), 18, MidpointRounding.ToEven));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26PropostaQtdItensNota_F3 = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaQtdItensNota_F3"), "."), 18, MidpointRounding.ToEven));
         AV35TFPropostaProtocolo = GetPar( "TFPropostaProtocolo");
         AV36TFPropostaProtocolo_Sel = GetPar( "TFPropostaProtocolo_Sel");
         AV37TFPropostaEmpresaRazao = GetPar( "TFPropostaEmpresaRazao");
         AV38TFPropostaEmpresaRazao_Sel = GetPar( "TFPropostaEmpresaRazao_Sel");
         AV39TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPropostaQtdItensNota_F"), "."), 18, MidpointRounding.ToEven));
         AV40TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPropostaQtdItensNota_F_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV42TFPropostaTipoProposta_Sels);
         AV43TFPropostaSumItensnota_F = NumberUtil.Val( GetPar( "TFPropostaSumItensnota_F"), ".");
         AV44TFPropostaSumItensnota_F_To = NumberUtil.Val( GetPar( "TFPropostaSumItensnota_F_To"), ".");
         AV45TFPropostaCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFPropostaCreatedAt"));
         AV46TFPropostaCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFPropostaCreatedAt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV51TFPropostaStatus_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PA9B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9B2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostanotaww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
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
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_PROPOSTACREATEDATAUXDATE", context.localUtil.DToC( AV47DDO_PropostaCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_PROPOSTACREATEDATAUXDATETO", context.localUtil.DToC( AV48DDO_PropostaCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPROTOCOLO", AV35TFPropostaProtocolo);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAPROTOCOLO_SEL", AV36TFPropostaProtocolo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAEMPRESARAZAO", AV37TFPropostaEmpresaRazao);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAEMPRESARAZAO_SEL", AV38TFPropostaEmpresaRazao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAQTDITENSNOTA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTAQTDITENSNOTA_F_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROPOSTATIPOPROPOSTA_SELS", AV42TFPropostaTipoProposta_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROPOSTATIPOPROPOSTA_SELS", AV42TFPropostaTipoProposta_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASUMITENSNOTA_F", StringUtil.LTrim( StringUtil.NToC( AV43TFPropostaSumItensnota_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASUMITENSNOTA_F_TO", StringUtil.LTrim( StringUtil.NToC( AV44TFPropostaSumItensnota_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTACREATEDAT", context.localUtil.TToC( AV45TFPropostaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTACREATEDAT_TO", context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFPROPOSTASTATUS_SELS", AV51TFPropostaStatus_Sels);
         }
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
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTATIPOPROPOSTA_SELSJSON", AV41TFPropostaTipoProposta_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFPROPOSTASTATUS_SELSJSON", AV50TFPropostaStatus_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
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
            WE9B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9B2( ) ;
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
         return formatLink("propostanotaww")  ;
      }

      public override string GetPgmname( )
      {
         return "PropostaNotaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Proposta Nota" ;
      }

      protected void WB9B0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaNotaWW.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_PropostaNotaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_9B2( true) ;
         }
         else
         {
            wb_table1_47_9B2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_9B2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_69_9B2( true) ;
         }
         else
         {
            wb_table2_69_9B2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_9B2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_91_9B2( true) ;
         }
         else
         {
            wb_table3_91_9B2( false) ;
         }
         return  ;
      }

      protected void wb_table3_91_9B2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_PropostaNotaWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_propostacreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_propostacreatedatauxdatetext_Internalname, AV49DDO_PropostaCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV49DDO_PropostaCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_propostacreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaNotaWW.htm");
            /* User Defined Control */
            ucTfpropostacreatedat_rangepicker.SetProperty("Start Date", AV47DDO_PropostaCreatedAtAuxDate);
            ucTfpropostacreatedat_rangepicker.SetProperty("End Date", AV48DDO_PropostaCreatedAtAuxDateTo);
            ucTfpropostacreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfpropostacreatedat_rangepicker_Internalname, "TFPROPOSTACREATEDAT_RANGEPICKERContainer");
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

      protected void START9B2( )
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
         Form.Meta.addItem("description", " Proposta Nota", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9B0( ) ;
      }

      protected void WS9B2( )
      {
         START9B2( ) ;
         EVT9B2( ) ;
      }

      protected void EVT9B2( )
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
                              E119B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E209B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E229B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239B2 ();
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
                              AV58PropostaCons = cgiGet( edtavPropostacons_Internalname);
                              AssignAttri("", false, edtavPropostacons_Internalname, AV58PropostaCons);
                              A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n323PropostaId = false;
                              A853PropostaProtocolo = cgiGet( edtPropostaProtocolo_Internalname);
                              n853PropostaProtocolo = false;
                              A888PropostaEmpresaRazao = StringUtil.Upper( cgiGet( edtPropostaEmpresaRazao_Internalname));
                              n888PropostaEmpresaRazao = false;
                              A854PropostaQtdItensNota_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQtdItensNota_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              cmbPropostaTipoProposta.Name = cmbPropostaTipoProposta_Internalname;
                              cmbPropostaTipoProposta.CurrentValue = cgiGet( cmbPropostaTipoProposta_Internalname);
                              A849PropostaTipoProposta = cgiGet( cmbPropostaTipoProposta_Internalname);
                              n849PropostaTipoProposta = false;
                              A887PropostaSumItensnota_F = context.localUtil.CToN( cgiGet( edtPropostaSumItensnota_F_Internalname), ",", ".");
                              A850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaEmpresaClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n850PropostaEmpresaClienteId = false;
                              A327PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtPropostaCreatedAt_Internalname), 0);
                              n327PropostaCreatedAt = false;
                              cmbPropostaStatus.Name = cmbPropostaStatus_Internalname;
                              cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
                              A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
                              n329PropostaStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E249B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E259B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E269B2 ();
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

      protected void WE9B2( )
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

      protected void PA9B2( )
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
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV59Pgmname ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       short AV18PropostaQtdItensNota_F1 ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       short AV22PropostaQtdItensNota_F2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       short AV26PropostaQtdItensNota_F3 ,
                                       string AV35TFPropostaProtocolo ,
                                       string AV36TFPropostaProtocolo_Sel ,
                                       string AV37TFPropostaEmpresaRazao ,
                                       string AV38TFPropostaEmpresaRazao_Sel ,
                                       short AV39TFPropostaQtdItensNota_F ,
                                       short AV40TFPropostaQtdItensNota_F_To ,
                                       GxSimpleCollection<string> AV42TFPropostaTipoProposta_Sels ,
                                       decimal AV43TFPropostaSumItensnota_F ,
                                       decimal AV44TFPropostaSumItensnota_F_To ,
                                       DateTime AV45TFPropostaCreatedAt ,
                                       DateTime AV46TFPropostaCreatedAt_To ,
                                       GxSimpleCollection<string> AV51TFPropostaStatus_Sels ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", "")));
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
         RF9B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV59Pgmname = "PropostaNotaWW";
         edtavPropostacons_Enabled = 0;
      }

      protected void RF9B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E259B2 ();
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
                                                 A849PropostaTipoProposta ,
                                                 AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                                 A329PropostaStatus ,
                                                 AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                                 AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                                 AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                                 AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                                 AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                                 AV78Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                                 AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                                 AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                                 AV81Propostanotawwds_22_tfpropostacreatedat ,
                                                 AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                                 AV83Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                                 A853PropostaProtocolo ,
                                                 A888PropostaEmpresaRazao ,
                                                 A887PropostaSumItensnota_F ,
                                                 A327PropostaCreatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 AV60Propostanotawwds_1_filterfulltext ,
                                                 A854PropostaQtdItensNota_F ,
                                                 AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                                 AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                                 AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                                 AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                                 AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                                 AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                                 AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                                 AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                                 AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                                 AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                                 AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                                 AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                                 AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
            lV72Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo), "%", "");
            lV74Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao), "%", "");
            /* Using cursor H009B3 */
            pr_default.execute(0, new Object[] {AV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV72Propostanotawwds_13_tfpropostaprotocolo, AV73Propostanotawwds_14_tfpropostaprotocolo_sel, lV74Propostanotawwds_15_tfpropostaempresarazao, AV75Propostanotawwds_16_tfpropostaempresarazao_sel, AV79Propostanotawwds_20_tfpropostasumitensnota_f, AV80Propostanotawwds_21_tfpropostasumitensnota_f_to, AV81Propostanotawwds_22_tfpropostacreatedat, AV82Propostanotawwds_23_tfpropostacreatedat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_109_idx = 1;
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A329PropostaStatus = H009B3_A329PropostaStatus[0];
               n329PropostaStatus = H009B3_n329PropostaStatus[0];
               A327PropostaCreatedAt = H009B3_A327PropostaCreatedAt[0];
               n327PropostaCreatedAt = H009B3_n327PropostaCreatedAt[0];
               A850PropostaEmpresaClienteId = H009B3_A850PropostaEmpresaClienteId[0];
               n850PropostaEmpresaClienteId = H009B3_n850PropostaEmpresaClienteId[0];
               A849PropostaTipoProposta = H009B3_A849PropostaTipoProposta[0];
               n849PropostaTipoProposta = H009B3_n849PropostaTipoProposta[0];
               A888PropostaEmpresaRazao = H009B3_A888PropostaEmpresaRazao[0];
               n888PropostaEmpresaRazao = H009B3_n888PropostaEmpresaRazao[0];
               A853PropostaProtocolo = H009B3_A853PropostaProtocolo[0];
               n853PropostaProtocolo = H009B3_n853PropostaProtocolo[0];
               A323PropostaId = H009B3_A323PropostaId[0];
               n323PropostaId = H009B3_n323PropostaId[0];
               A887PropostaSumItensnota_F = H009B3_A887PropostaSumItensnota_F[0];
               A854PropostaQtdItensNota_F = H009B3_A854PropostaQtdItensNota_F[0];
               A888PropostaEmpresaRazao = H009B3_A888PropostaEmpresaRazao[0];
               n888PropostaEmpresaRazao = H009B3_n888PropostaEmpresaRazao[0];
               A887PropostaSumItensnota_F = H009B3_A887PropostaSumItensnota_F[0];
               A854PropostaQtdItensNota_F = H009B3_A854PropostaQtdItensNota_F[0];
               /* Execute user event: Grid.Load */
               E269B2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 109;
            WB9B0( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9B2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV59Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV59Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PROPOSTAID"+"_"+sGXsfl_109_idx, GetSecureSignedToken( sGXsfl_109_idx, context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"), context));
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
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A849PropostaTipoProposta ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                              A329PropostaStatus ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                              AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                              AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                              AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                              AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                              AV78Propostanotawwds_19_tfpropostatipoproposta_sels.Count ,
                                              AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                              AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                              AV81Propostanotawwds_22_tfpropostacreatedat ,
                                              AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                              AV83Propostanotawwds_24_tfpropostastatus_sels.Count ,
                                              A853PropostaProtocolo ,
                                              A888PropostaEmpresaRazao ,
                                              A887PropostaSumItensnota_F ,
                                              A327PropostaCreatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              AV60Propostanotawwds_1_filterfulltext ,
                                              A854PropostaQtdItensNota_F ,
                                              AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                              AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                              AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                              AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                              AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                              AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                              AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                              AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                              AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                              AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                              AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                              AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                              AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV60Propostanotawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Propostanotawwds_1_filterfulltext), "%", "");
         lV72Propostanotawwds_13_tfpropostaprotocolo = StringUtil.Concat( StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo), "%", "");
         lV74Propostanotawwds_15_tfpropostaempresarazao = StringUtil.Concat( StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao), "%", "");
         /* Using cursor H009B5 */
         pr_default.execute(1, new Object[] {AV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, lV60Propostanotawwds_1_filterfulltext, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV61Propostanotawwds_2_dynamicfiltersselector1, AV62Propostanotawwds_3_dynamicfiltersoperator1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV63Propostanotawwds_4_propostaqtditensnota_f1, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV64Propostanotawwds_5_dynamicfiltersenabled2, AV65Propostanotawwds_6_dynamicfiltersselector2, AV66Propostanotawwds_7_dynamicfiltersoperator2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV67Propostanotawwds_8_propostaqtditensnota_f2, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV68Propostanotawwds_9_dynamicfiltersenabled3, AV69Propostanotawwds_10_dynamicfiltersselector3, AV70Propostanotawwds_11_dynamicfiltersoperator3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV71Propostanotawwds_12_propostaqtditensnota_f3, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV76Propostanotawwds_17_tfpropostaqtditensnota_f, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to, lV72Propostanotawwds_13_tfpropostaprotocolo, AV73Propostanotawwds_14_tfpropostaprotocolo_sel, lV74Propostanotawwds_15_tfpropostaempresarazao, AV75Propostanotawwds_16_tfpropostaempresarazao_sel, AV79Propostanotawwds_20_tfpropostasumitensnota_f, AV80Propostanotawwds_21_tfpropostasumitensnota_f_to, AV81Propostanotawwds_22_tfpropostacreatedat, AV82Propostanotawwds_23_tfpropostacreatedat_to});
         GRID_nRecordCount = H009B5_AGRID_nRecordCount[0];
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
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV59Pgmname = "PropostaNotaWW";
         edtavPropostacons_Enabled = 0;
         edtPropostaId_Enabled = 0;
         edtPropostaProtocolo_Enabled = 0;
         edtPropostaEmpresaRazao_Enabled = 0;
         edtPropostaQtdItensNota_F_Enabled = 0;
         cmbPropostaTipoProposta.Enabled = 0;
         edtPropostaSumItensnota_F_Enabled = 0;
         edtPropostaEmpresaClienteId_Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         cmbPropostaStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E249B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_109"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV47DDO_PropostaCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_PROPOSTACREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV47DDO_PropostaCreatedAtAuxDate", context.localUtil.Format(AV47DDO_PropostaCreatedAtAuxDate, "99/99/99"));
            AV48DDO_PropostaCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_PROPOSTACREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV48DDO_PropostaCreatedAtAuxDateTo", context.localUtil.Format(AV48DDO_PropostaCreatedAtAuxDateTo, "99/99/99"));
            AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( cgiGet( "vDYNAMICFILTERSENABLED3"));
            AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
            AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( cgiGet( "vDYNAMICFILTERSENABLED2"));
            AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f1_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAQTDITENSNOTA_F1");
               GX_FocusControl = edtavPropostaqtditensnota_f1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18PropostaQtdItensNota_F1 = 0;
               AssignAttri("", false, "AV18PropostaQtdItensNota_F1", StringUtil.LTrimStr( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0));
            }
            else
            {
               AV18PropostaQtdItensNota_F1 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18PropostaQtdItensNota_F1", StringUtil.LTrimStr( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0));
            }
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f2_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAQTDITENSNOTA_F2");
               GX_FocusControl = edtavPropostaqtditensnota_f2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22PropostaQtdItensNota_F2 = 0;
               AssignAttri("", false, "AV22PropostaQtdItensNota_F2", StringUtil.LTrimStr( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0));
            }
            else
            {
               AV22PropostaQtdItensNota_F2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22PropostaQtdItensNota_F2", StringUtil.LTrimStr( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f3_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPROPOSTAQTDITENSNOTA_F3");
               GX_FocusControl = edtavPropostaqtditensnota_f3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26PropostaQtdItensNota_F3 = 0;
               AssignAttri("", false, "AV26PropostaQtdItensNota_F3", StringUtil.LTrimStr( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0));
            }
            else
            {
               AV26PropostaQtdItensNota_F3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavPropostaqtditensnota_f3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26PropostaQtdItensNota_F3", StringUtil.LTrimStr( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0));
            }
            AV49DDO_PropostaCreatedAtAuxDateText = cgiGet( edtavDdo_propostacreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV49DDO_PropostaCreatedAtAuxDateText", AV49DDO_PropostaCreatedAtAuxDateText);
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
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E249B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E249B2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFPROPOSTACREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_propostacreatedatauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "PROPOSTAQTDITENSNOTA_F";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "PROPOSTAQTDITENSNOTA_F";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "PROPOSTAQTDITENSNOTA_F";
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
         Form.Caption = " Proposta Nota";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E259B2( )
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
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV59Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         cmbPropostaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbPropostaStatus_Internalname, "Columnheaderclass", cmbPropostaStatus_Columnheaderclass, !bGXsfl_109_Refreshing);
         AV60Propostanotawwds_1_filterfulltext = AV15FilterFullText;
         AV61Propostanotawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV62Propostanotawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV63Propostanotawwds_4_propostaqtditensnota_f1 = AV18PropostaQtdItensNota_F1;
         AV64Propostanotawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV65Propostanotawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV66Propostanotawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV67Propostanotawwds_8_propostaqtditensnota_f2 = AV22PropostaQtdItensNota_F2;
         AV68Propostanotawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV69Propostanotawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV70Propostanotawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV71Propostanotawwds_12_propostaqtditensnota_f3 = AV26PropostaQtdItensNota_F3;
         AV72Propostanotawwds_13_tfpropostaprotocolo = AV35TFPropostaProtocolo;
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = AV36TFPropostaProtocolo_Sel;
         AV74Propostanotawwds_15_tfpropostaempresarazao = AV37TFPropostaEmpresaRazao;
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = AV38TFPropostaEmpresaRazao_Sel;
         AV76Propostanotawwds_17_tfpropostaqtditensnota_f = AV39TFPropostaQtdItensNota_F;
         AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = AV40TFPropostaQtdItensNota_F_To;
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = AV42TFPropostaTipoProposta_Sels;
         AV79Propostanotawwds_20_tfpropostasumitensnota_f = AV43TFPropostaSumItensnota_F;
         AV80Propostanotawwds_21_tfpropostasumitensnota_f_to = AV44TFPropostaSumItensnota_F_To;
         AV81Propostanotawwds_22_tfpropostacreatedat = AV45TFPropostaCreatedAt;
         AV82Propostanotawwds_23_tfpropostacreatedat_to = AV46TFPropostaCreatedAt_To;
         AV83Propostanotawwds_24_tfpropostastatus_sels = AV51TFPropostaStatus_Sels;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129B2( )
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
            AV53PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E139B2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149B2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaProtocolo") == 0 )
            {
               AV35TFPropostaProtocolo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFPropostaProtocolo", AV35TFPropostaProtocolo);
               AV36TFPropostaProtocolo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFPropostaProtocolo_Sel", AV36TFPropostaProtocolo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaEmpresaRazao") == 0 )
            {
               AV37TFPropostaEmpresaRazao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFPropostaEmpresaRazao", AV37TFPropostaEmpresaRazao);
               AV38TFPropostaEmpresaRazao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFPropostaEmpresaRazao_Sel", AV38TFPropostaEmpresaRazao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaQtdItensNota_F") == 0 )
            {
               AV39TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFPropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0));
               AV40TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40TFPropostaQtdItensNota_F_To", StringUtil.LTrimStr( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaTipoProposta") == 0 )
            {
               AV41TFPropostaTipoProposta_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFPropostaTipoProposta_SelsJson", AV41TFPropostaTipoProposta_SelsJson);
               AV42TFPropostaTipoProposta_Sels.FromJSonString(AV41TFPropostaTipoProposta_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaSumItensnota_F") == 0 )
            {
               AV43TFPropostaSumItensnota_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV43TFPropostaSumItensnota_F", StringUtil.LTrimStr( AV43TFPropostaSumItensnota_F, 18, 2));
               AV44TFPropostaSumItensnota_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV44TFPropostaSumItensnota_F_To", StringUtil.LTrimStr( AV44TFPropostaSumItensnota_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaCreatedAt") == 0 )
            {
               AV45TFPropostaCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV45TFPropostaCreatedAt", context.localUtil.TToC( AV45TFPropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV46TFPropostaCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV46TFPropostaCreatedAt_To", context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV46TFPropostaCreatedAt_To) )
               {
                  AV46TFPropostaCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV46TFPropostaCreatedAt_To)), (short)(DateTimeUtil.Month( AV46TFPropostaCreatedAt_To)), (short)(DateTimeUtil.Day( AV46TFPropostaCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV46TFPropostaCreatedAt_To", context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PropostaStatus") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFPropostaTipoProposta_Sels", AV42TFPropostaTipoProposta_Sels);
      }

      private void E269B2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV58PropostaCons = "<i class=\"fas fa-eye\"></i>";
         AssignAttri("", false, edtavPropostacons_Internalname, AV58PropostaCons);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpconsultapropostanota"+UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtavPropostacons_Link = formatLink("wpconsultapropostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "propostanota"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A323PropostaId,9,0));
         edtPropostaQtdItensNota_F_Link = formatLink("propostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnWarning WWColumnWarningSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnInfo WWColumnInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnGray WWColumnGraySingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnInfo WWColumnInfoSingleCell";
         }
         else if ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 )
         {
            cmbPropostaStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else
         {
            cmbPropostaStatus_Columnclass = "WWColumn";
         }
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

      protected void E159B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E219B2( )
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

      protected void E169B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E229B2( )
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

      protected void E179B2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV34ManageFiltersExecutionStep, AV59Pgmname, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18PropostaQtdItensNota_F1, AV19DynamicFiltersEnabled2, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22PropostaQtdItensNota_F2, AV23DynamicFiltersEnabled3, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26PropostaQtdItensNota_F3, AV35TFPropostaProtocolo, AV36TFPropostaProtocolo_Sel, AV37TFPropostaEmpresaRazao, AV38TFPropostaEmpresaRazao_Sel, AV39TFPropostaQtdItensNota_F, AV40TFPropostaQtdItensNota_F_To, AV42TFPropostaTipoProposta_Sels, AV43TFPropostaSumItensnota_F, AV44TFPropostaSumItensnota_F_To, AV45TFPropostaCreatedAt, AV46TFPropostaCreatedAt_To, AV51TFPropostaStatus_Sels, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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

      protected void E239B2( )
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

      protected void E119B2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("PropostaNotaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV59Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("PropostaNotaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "PropostaNotaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV59Pgmname+"GridState",  AV33ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFPropostaTipoProposta_Sels", AV42TFPropostaTipoProposta_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
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

      protected void E189B2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "propostanota"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("propostanota") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E199B2( )
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
         new propostanotawwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFPropostaTipoProposta_Sels", AV42TFPropostaTipoProposta_Sels);
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

      protected void E209B2( )
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
         Innewwindow1_Target = formatLink("propostanotawwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51TFPropostaStatus_Sels", AV51TFPropostaStatus_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42TFPropostaTipoProposta_Sels", AV42TFPropostaTipoProposta_Sels);
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
         edtavPropostaqtditensnota_f1_Visible = 0;
         AssignProp("", false, edtavPropostaqtditensnota_f1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 )
         {
            edtavPropostaqtditensnota_f1_Visible = 1;
            AssignProp("", false, edtavPropostaqtditensnota_f1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavPropostaqtditensnota_f2_Visible = 0;
         AssignProp("", false, edtavPropostaqtditensnota_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 )
         {
            edtavPropostaqtditensnota_f2_Visible = 1;
            AssignProp("", false, edtavPropostaqtditensnota_f2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavPropostaqtditensnota_f3_Visible = 0;
         AssignProp("", false, edtavPropostaqtditensnota_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 )
         {
            edtavPropostaqtditensnota_f3_Visible = 1;
            AssignProp("", false, edtavPropostaqtditensnota_f3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPropostaqtditensnota_f3_Visible), 5, 0), true);
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
         AV20DynamicFiltersSelector2 = "PROPOSTAQTDITENSNOTA_F";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22PropostaQtdItensNota_F2 = 0;
         AssignAttri("", false, "AV22PropostaQtdItensNota_F2", StringUtil.LTrimStr( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "PROPOSTAQTDITENSNOTA_F";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26PropostaQtdItensNota_F3 = 0;
         AssignAttri("", false, "AV26PropostaQtdItensNota_F3", StringUtil.LTrimStr( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "PropostaNotaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV35TFPropostaProtocolo = "";
         AssignAttri("", false, "AV35TFPropostaProtocolo", AV35TFPropostaProtocolo);
         AV36TFPropostaProtocolo_Sel = "";
         AssignAttri("", false, "AV36TFPropostaProtocolo_Sel", AV36TFPropostaProtocolo_Sel);
         AV37TFPropostaEmpresaRazao = "";
         AssignAttri("", false, "AV37TFPropostaEmpresaRazao", AV37TFPropostaEmpresaRazao);
         AV38TFPropostaEmpresaRazao_Sel = "";
         AssignAttri("", false, "AV38TFPropostaEmpresaRazao_Sel", AV38TFPropostaEmpresaRazao_Sel);
         AV39TFPropostaQtdItensNota_F = 0;
         AssignAttri("", false, "AV39TFPropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0));
         AV40TFPropostaQtdItensNota_F_To = 0;
         AssignAttri("", false, "AV40TFPropostaQtdItensNota_F_To", StringUtil.LTrimStr( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0));
         AV42TFPropostaTipoProposta_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV43TFPropostaSumItensnota_F = 0;
         AssignAttri("", false, "AV43TFPropostaSumItensnota_F", StringUtil.LTrimStr( AV43TFPropostaSumItensnota_F, 18, 2));
         AV44TFPropostaSumItensnota_F_To = 0;
         AssignAttri("", false, "AV44TFPropostaSumItensnota_F_To", StringUtil.LTrimStr( AV44TFPropostaSumItensnota_F_To, 18, 2));
         AV45TFPropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV45TFPropostaCreatedAt", context.localUtil.TToC( AV45TFPropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV46TFPropostaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV46TFPropostaCreatedAt_To", context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV51TFPropostaStatus_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "PROPOSTAQTDITENSNOTA_F";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18PropostaQtdItensNota_F1 = 0;
         AssignAttri("", false, "AV18PropostaQtdItensNota_F1", StringUtil.LTrimStr( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0));
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
         if ( StringUtil.StrCmp(AV31Session.Get(AV59Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV59Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV59Pgmname+"GridState"), null, "", "");
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
         AV84GXV1 = 1;
         while ( AV84GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV84GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO") == 0 )
            {
               AV35TFPropostaProtocolo = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFPropostaProtocolo", AV35TFPropostaProtocolo);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPROTOCOLO_SEL") == 0 )
            {
               AV36TFPropostaProtocolo_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFPropostaProtocolo_Sel", AV36TFPropostaProtocolo_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO") == 0 )
            {
               AV37TFPropostaEmpresaRazao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFPropostaEmpresaRazao", AV37TFPropostaEmpresaRazao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAEMPRESARAZAO_SEL") == 0 )
            {
               AV38TFPropostaEmpresaRazao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFPropostaEmpresaRazao_Sel", AV38TFPropostaEmpresaRazao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV39TFPropostaQtdItensNota_F = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39TFPropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0));
               AV40TFPropostaQtdItensNota_F_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40TFPropostaQtdItensNota_F_To", StringUtil.LTrimStr( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTATIPOPROPOSTA_SEL") == 0 )
            {
               AV41TFPropostaTipoProposta_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFPropostaTipoProposta_SelsJson", AV41TFPropostaTipoProposta_SelsJson);
               AV42TFPropostaTipoProposta_Sels.FromJSonString(AV41TFPropostaTipoProposta_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASUMITENSNOTA_F") == 0 )
            {
               AV43TFPropostaSumItensnota_F = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV43TFPropostaSumItensnota_F", StringUtil.LTrimStr( AV43TFPropostaSumItensnota_F, 18, 2));
               AV44TFPropostaSumItensnota_F_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV44TFPropostaSumItensnota_F_To", StringUtil.LTrimStr( AV44TFPropostaSumItensnota_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTACREATEDAT") == 0 )
            {
               AV45TFPropostaCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV45TFPropostaCreatedAt", context.localUtil.TToC( AV45TFPropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV46TFPropostaCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV46TFPropostaCreatedAt_To", context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV47DDO_PropostaCreatedAtAuxDate = DateTimeUtil.ResetTime(AV45TFPropostaCreatedAt);
               AssignAttri("", false, "AV47DDO_PropostaCreatedAtAuxDate", context.localUtil.Format(AV47DDO_PropostaCreatedAtAuxDate, "99/99/99"));
               AV48DDO_PropostaCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV46TFPropostaCreatedAt_To);
               AssignAttri("", false, "AV48DDO_PropostaCreatedAtAuxDateTo", context.localUtil.Format(AV48DDO_PropostaCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV50TFPropostaStatus_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFPropostaStatus_SelsJson", AV50TFPropostaStatus_SelsJson);
               AV51TFPropostaStatus_Sels.FromJSonString(AV50TFPropostaStatus_SelsJson, null);
            }
            AV84GXV1 = (int)(AV84GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaProtocolo_Sel)),  AV36TFPropostaProtocolo_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPropostaEmpresaRazao_Sel)),  AV38TFPropostaEmpresaRazao_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV42TFPropostaTipoProposta_Sels.Count==0),  AV41TFPropostaTipoProposta_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV51TFPropostaStatus_Sels.Count==0),  AV50TFPropostaStatus_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||"+GXt_char5+"|||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaProtocolo)),  AV35TFPropostaProtocolo, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPropostaEmpresaRazao)),  AV37TFPropostaEmpresaRazao, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((0==AV39TFPropostaQtdItensNota_F) ? "" : StringUtil.Str( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0))+"||"+((Convert.ToDecimal(0)==AV43TFPropostaSumItensnota_F) ? "" : StringUtil.Str( AV43TFPropostaSumItensnota_F, 18, 2))+"|"+((DateTime.MinValue==AV45TFPropostaCreatedAt) ? "" : context.localUtil.DToC( AV47DDO_PropostaCreatedAtAuxDate, 4, "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV40TFPropostaQtdItensNota_F_To) ? "" : StringUtil.Str( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0))+"||"+((Convert.ToDecimal(0)==AV44TFPropostaSumItensnota_F_To) ? "" : StringUtil.Str( AV44TFPropostaSumItensnota_F_To, 18, 2))+"|"+((DateTime.MinValue==AV46TFPropostaCreatedAt_To) ? "" : context.localUtil.DToC( AV48DDO_PropostaCreatedAtAuxDateTo, 4, "/"))+"|";
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18PropostaQtdItensNota_F1 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18PropostaQtdItensNota_F1", StringUtil.LTrimStr( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0));
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22PropostaQtdItensNota_F2 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22PropostaQtdItensNota_F2", StringUtil.LTrimStr( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0));
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26PropostaQtdItensNota_F3 = (short)(Math.Round(NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV26PropostaQtdItensNota_F3", StringUtil.LTrimStr( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0));
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
         AV10GridState.FromXml(AV31Session.Get(AV59Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAPROTOCOLO",  "Protocolo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPropostaProtocolo)),  0,  AV35TFPropostaProtocolo,  AV35TFPropostaProtocolo,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPropostaProtocolo_Sel)),  AV36TFPropostaProtocolo_Sel,  AV36TFPropostaProtocolo_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFPROPOSTAEMPRESARAZAO",  "Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPropostaEmpresaRazao)),  0,  AV37TFPropostaEmpresaRazao,  AV37TFPropostaEmpresaRazao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPropostaEmpresaRazao_Sel)),  AV38TFPropostaEmpresaRazao_Sel,  AV38TFPropostaEmpresaRazao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTAQTDITENSNOTA_F",  "Quantidade",  !((0==AV39TFPropostaQtdItensNota_F)&&(0==AV40TFPropostaQtdItensNota_F_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV39TFPropostaQtdItensNota_F), 4, 0)),  ((0==AV39TFPropostaQtdItensNota_F) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV39TFPropostaQtdItensNota_F), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV40TFPropostaQtdItensNota_F_To), 4, 0)),  ((0==AV40TFPropostaQtdItensNota_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV40TFPropostaQtdItensNota_F_To), "ZZZ9")))) ;
         AV57AuxText = ((AV42TFPropostaTipoProposta_Sels.Count==1) ? "["+((string)AV42TFPropostaTipoProposta_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTATIPOPROPOSTA_SEL",  "Tipo Proposta",  !(AV42TFPropostaTipoProposta_Sels.Count==0),  0,  AV42TFPropostaTipoProposta_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV57AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV57AuxText, "[CLINICA]", "Clinica"), "[COMPRA_TITULO]", "Compra de título")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTASUMITENSNOTA_F",  "Total",  !((Convert.ToDecimal(0)==AV43TFPropostaSumItensnota_F)&&(Convert.ToDecimal(0)==AV44TFPropostaSumItensnota_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV43TFPropostaSumItensnota_F, 18, 2)),  ((Convert.ToDecimal(0)==AV43TFPropostaSumItensnota_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFPropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV44TFPropostaSumItensnota_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV44TFPropostaSumItensnota_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFPropostaSumItensnota_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTACREATEDAT",  "Data Criação",  !((DateTime.MinValue==AV45TFPropostaCreatedAt)&&(DateTime.MinValue==AV46TFPropostaCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV45TFPropostaCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV45TFPropostaCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFPropostaCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV46TFPropostaCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV46TFPropostaCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFPropostaCreatedAt_To, "99/99/99 99:99")))) ;
         AV57AuxText = ((AV51TFPropostaStatus_Sels.Count==1) ? "["+((string)AV51TFPropostaStatus_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFPROPOSTASTATUS_SEL",  "Status",  !(AV51TFPropostaStatus_Sels.Count==0),  0,  AV51TFPropostaStatus_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV57AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV57AuxText, "[PENDENTE]", "Pendente aprovação"), "[EM_ANALISE]", "Em análise"), "[APROVADO]", "Aprovado"), "[REJEITADO]", "Rejeitado"), "[REVISAO]", "Revisão"), "[CANCELADO]", "Cancelado"), "[AGUARDANDO_ASSINATURA]", "Aguardando assinatura"), "[AnaliseReprovada]", "Análise reprovada")),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV59Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "PROPOSTAQTDITENSNOTA_F") == 0 ) && ! (0==AV18PropostaQtdItensNota_F1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Itens Nota_F",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV18PropostaQtdItensNota_F1), "ZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV18PropostaQtdItensNota_F1), "ZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV18PropostaQtdItensNota_F1), "ZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PROPOSTAQTDITENSNOTA_F") == 0 ) && ! (0==AV22PropostaQtdItensNota_F2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Itens Nota_F",  AV21DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV22PropostaQtdItensNota_F2), "ZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV22PropostaQtdItensNota_F2), "ZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV22PropostaQtdItensNota_F2), "ZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PROPOSTAQTDITENSNOTA_F") == 0 ) && ! (0==AV26PropostaQtdItensNota_F3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Itens Nota_F",  AV25DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26PropostaQtdItensNota_F3), "ZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26PropostaQtdItensNota_F3), "ZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV26PropostaQtdItensNota_F3), "ZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV59Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "PropostaNota";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_91_9B2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaqtditensnota_f3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaqtditensnota_f3_Internalname, "Proposta Qtd Itens Nota_F3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaqtditensnota_f3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26PropostaQtdItensNota_F3), 4, 0, ",", "")), StringUtil.LTrim( ((edtavPropostaqtditensnota_f3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV26PropostaQtdItensNota_F3), "ZZZ9") : context.localUtil.Format( (decimal)(AV26PropostaQtdItensNota_F3), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaqtditensnota_f3_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaqtditensnota_f3_Visible, edtavPropostaqtditensnota_f3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaNotaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_91_9B2e( true) ;
         }
         else
         {
            wb_table3_91_9B2e( false) ;
         }
      }

      protected void wb_table2_69_9B2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaqtditensnota_f2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaqtditensnota_f2_Internalname, "Proposta Qtd Itens Nota_F2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaqtditensnota_f2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22PropostaQtdItensNota_F2), 4, 0, ",", "")), StringUtil.LTrim( ((edtavPropostaqtditensnota_f2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22PropostaQtdItensNota_F2), "ZZZ9") : context.localUtil.Format( (decimal)(AV22PropostaQtdItensNota_F2), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaqtditensnota_f2_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaqtditensnota_f2_Visible, edtavPropostaqtditensnota_f2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e279b1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaNotaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaNotaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_9B2e( true) ;
         }
         else
         {
            wb_table2_69_9B2e( false) ;
         }
      }

      protected void wb_table1_47_9B2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_PropostaNotaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_propostaqtditensnota_f1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPropostaqtditensnota_f1_Internalname, "Proposta Qtd Itens Nota_F1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPropostaqtditensnota_f1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18PropostaQtdItensNota_F1), 4, 0, ",", "")), StringUtil.LTrim( ((edtavPropostaqtditensnota_f1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18PropostaQtdItensNota_F1), "ZZZ9") : context.localUtil.Format( (decimal)(AV18PropostaQtdItensNota_F1), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPropostaqtditensnota_f1_Jsonclick, 0, "Attribute", "", "", "", "", edtavPropostaqtditensnota_f1_Visible, edtavPropostaqtditensnota_f1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaNotaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e289b1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaNotaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PropostaNotaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_9B2e( true) ;
         }
         else
         {
            wb_table1_47_9B2e( false) ;
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
         PA9B2( ) ;
         WS9B2( ) ;
         WE9B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019281732", true, true);
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
         context.AddJavascriptSource("propostanotaww.js", "?202561019281733", false, true);
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
         edtavPropostacons_Internalname = "vPROPOSTACONS_"+sGXsfl_109_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_109_idx;
         edtPropostaProtocolo_Internalname = "PROPOSTAPROTOCOLO_"+sGXsfl_109_idx;
         edtPropostaEmpresaRazao_Internalname = "PROPOSTAEMPRESARAZAO_"+sGXsfl_109_idx;
         edtPropostaQtdItensNota_F_Internalname = "PROPOSTAQTDITENSNOTA_F_"+sGXsfl_109_idx;
         cmbPropostaTipoProposta_Internalname = "PROPOSTATIPOPROPOSTA_"+sGXsfl_109_idx;
         edtPropostaSumItensnota_F_Internalname = "PROPOSTASUMITENSNOTA_F_"+sGXsfl_109_idx;
         edtPropostaEmpresaClienteId_Internalname = "PROPOSTAEMPRESACLIENTEID_"+sGXsfl_109_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_109_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         edtavPropostacons_Internalname = "vPROPOSTACONS_"+sGXsfl_109_fel_idx;
         edtPropostaId_Internalname = "PROPOSTAID_"+sGXsfl_109_fel_idx;
         edtPropostaProtocolo_Internalname = "PROPOSTAPROTOCOLO_"+sGXsfl_109_fel_idx;
         edtPropostaEmpresaRazao_Internalname = "PROPOSTAEMPRESARAZAO_"+sGXsfl_109_fel_idx;
         edtPropostaQtdItensNota_F_Internalname = "PROPOSTAQTDITENSNOTA_F_"+sGXsfl_109_fel_idx;
         cmbPropostaTipoProposta_Internalname = "PROPOSTATIPOPROPOSTA_"+sGXsfl_109_fel_idx;
         edtPropostaSumItensnota_F_Internalname = "PROPOSTASUMITENSNOTA_F_"+sGXsfl_109_fel_idx;
         edtPropostaEmpresaClienteId_Internalname = "PROPOSTAEMPRESACLIENTEID_"+sGXsfl_109_fel_idx;
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT_"+sGXsfl_109_fel_idx;
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         WB9B0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPropostacons_Internalname,StringUtil.RTrim( AV58PropostaCons),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavPropostacons_Link,(string)"",(string)"Verificar proposta",(string)"",(string)edtavPropostacons_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavPropostacons_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaProtocolo_Internalname,(string)A853PropostaProtocolo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaProtocolo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaEmpresaRazao_Internalname,(string)A888PropostaEmpresaRazao,StringUtil.RTrim( context.localUtil.Format( A888PropostaEmpresaRazao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaEmpresaRazao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaQtdItensNota_F_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A854PropostaQtdItensNota_F), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPropostaQtdItensNota_F_Link,(string)"",(string)"",(string)"",(string)edtPropostaQtdItensNota_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPropostaTipoProposta.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROPOSTATIPOPROPOSTA_" + sGXsfl_109_idx;
               cmbPropostaTipoProposta.Name = GXCCtl;
               cmbPropostaTipoProposta.WebTags = "";
               cmbPropostaTipoProposta.addItem("CLINICA", "Clinica", 0);
               cmbPropostaTipoProposta.addItem("COMPRA_TITULO", "Compra de título", 0);
               if ( cmbPropostaTipoProposta.ItemCount > 0 )
               {
                  A849PropostaTipoProposta = cmbPropostaTipoProposta.getValidValue(A849PropostaTipoProposta);
                  n849PropostaTipoProposta = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaTipoProposta,(string)cmbPropostaTipoProposta_Internalname,StringUtil.RTrim( A849PropostaTipoProposta),(short)1,(string)cmbPropostaTipoProposta_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaTipoProposta.CurrentValue = StringUtil.RTrim( A849PropostaTipoProposta);
            AssignProp("", false, cmbPropostaTipoProposta_Internalname, "Values", (string)(cmbPropostaTipoProposta.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaSumItensnota_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A887PropostaSumItensnota_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A887PropostaSumItensnota_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaSumItensnota_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaEmpresaClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A850PropostaEmpresaClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaEmpresaClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPropostaCreatedAt_Internalname,context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPropostaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPropostaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "PROPOSTASTATUS_" + sGXsfl_109_idx;
               cmbPropostaStatus.Name = GXCCtl;
               cmbPropostaStatus.WebTags = "";
               cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
               cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
               cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
               cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
               cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
               cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
               cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
               cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
               if ( cmbPropostaStatus.ItemCount > 0 )
               {
                  A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
                  n329PropostaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPropostaStatus,(string)cmbPropostaStatus_Internalname,StringUtil.RTrim( A329PropostaStatus),(short)1,(string)cmbPropostaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbPropostaStatus_Columnclass,(string)cmbPropostaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            send_integrity_lvl_hashes9B2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("PROPOSTAQTDITENSNOTA_F", "Itens Nota_F", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("PROPOSTAQTDITENSNOTA_F", "Itens Nota_F", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("PROPOSTAQTDITENSNOTA_F", "Itens Nota_F", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "PROPOSTATIPOPROPOSTA_" + sGXsfl_109_idx;
         cmbPropostaTipoProposta.Name = GXCCtl;
         cmbPropostaTipoProposta.WebTags = "";
         cmbPropostaTipoProposta.addItem("CLINICA", "Clinica", 0);
         cmbPropostaTipoProposta.addItem("COMPRA_TITULO", "Compra de título", 0);
         if ( cmbPropostaTipoProposta.ItemCount > 0 )
         {
            A849PropostaTipoProposta = cmbPropostaTipoProposta.getValidValue(A849PropostaTipoProposta);
            n849PropostaTipoProposta = false;
         }
         GXCCtl = "PROPOSTASTATUS_" + sGXsfl_109_idx;
         cmbPropostaStatus.Name = GXCCtl;
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Protocolo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Proposta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data Criação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58PropostaCons)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPropostacons_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavPropostacons_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A853PropostaProtocolo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A888PropostaEmpresaRazao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtPropostaQtdItensNota_F_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A849PropostaTipoProposta));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A887PropostaSumItensnota_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A329PropostaStatus));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbPropostaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbPropostaStatus_Columnheaderclass));
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
         edtavPropostaqtditensnota_f1_Internalname = "vPROPOSTAQTDITENSNOTA_F1";
         cellFilter_propostaqtditensnota_f1_cell_Internalname = "FILTER_PROPOSTAQTDITENSNOTA_F1_CELL";
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
         edtavPropostaqtditensnota_f2_Internalname = "vPROPOSTAQTDITENSNOTA_F2";
         cellFilter_propostaqtditensnota_f2_cell_Internalname = "FILTER_PROPOSTAQTDITENSNOTA_F2_CELL";
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
         edtavPropostaqtditensnota_f3_Internalname = "vPROPOSTAQTDITENSNOTA_F3";
         cellFilter_propostaqtditensnota_f3_cell_Internalname = "FILTER_PROPOSTAQTDITENSNOTA_F3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavPropostacons_Internalname = "vPROPOSTACONS";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtPropostaProtocolo_Internalname = "PROPOSTAPROTOCOLO";
         edtPropostaEmpresaRazao_Internalname = "PROPOSTAEMPRESARAZAO";
         edtPropostaQtdItensNota_F_Internalname = "PROPOSTAQTDITENSNOTA_F";
         cmbPropostaTipoProposta_Internalname = "PROPOSTATIPOPROPOSTA";
         edtPropostaSumItensnota_F_Internalname = "PROPOSTASUMITENSNOTA_F";
         edtPropostaEmpresaClienteId_Internalname = "PROPOSTAEMPRESACLIENTEID";
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_propostacreatedatauxdatetext_Internalname = "vDDO_PROPOSTACREATEDATAUXDATETEXT";
         Tfpropostacreatedat_rangepicker_Internalname = "TFPROPOSTACREATEDAT_RANGEPICKER";
         divDdo_propostacreatedatauxdates_Internalname = "DDO_PROPOSTACREATEDATAUXDATES";
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
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus_Columnclass = "WWColumn";
         edtPropostaCreatedAt_Jsonclick = "";
         edtPropostaEmpresaClienteId_Jsonclick = "";
         edtPropostaSumItensnota_F_Jsonclick = "";
         cmbPropostaTipoProposta_Jsonclick = "";
         edtPropostaQtdItensNota_F_Jsonclick = "";
         edtPropostaQtdItensNota_F_Link = "";
         edtPropostaEmpresaRazao_Jsonclick = "";
         edtPropostaProtocolo_Jsonclick = "";
         edtPropostaId_Jsonclick = "";
         edtavPropostacons_Jsonclick = "";
         edtavPropostacons_Link = "";
         edtavPropostacons_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavPropostaqtditensnota_f1_Jsonclick = "";
         edtavPropostaqtditensnota_f1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavPropostaqtditensnota_f2_Jsonclick = "";
         edtavPropostaqtditensnota_f2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavPropostaqtditensnota_f3_Jsonclick = "";
         edtavPropostaqtditensnota_f3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavPropostaqtditensnota_f3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavPropostaqtditensnota_f2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavPropostaqtditensnota_f1_Visible = 1;
         cmbPropostaStatus_Columnheaderclass = "";
         cmbPropostaStatus.Enabled = 0;
         edtPropostaCreatedAt_Enabled = 0;
         edtPropostaEmpresaClienteId_Enabled = 0;
         edtPropostaSumItensnota_F_Enabled = 0;
         cmbPropostaTipoProposta.Enabled = 0;
         edtPropostaQtdItensNota_F_Enabled = 0;
         edtPropostaEmpresaRazao_Enabled = 0;
         edtPropostaProtocolo_Enabled = 0;
         edtPropostaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_propostacreatedatauxdatetext_Jsonclick = "";
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
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "||4.0||18.2||";
         Ddo_grid_Datalistproc = "PropostaNotaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||CLINICA:Clinica,COMPRA_TITULO:Compra de título|||PENDENTE:Pendente aprovação,EM_ANALISE:Em análise,APROVADO:Aprovado,REJEITADO:Rejeitado,REVISAO:Revisão,CANCELADO:Cancelado,AGUARDANDO_ASSINATURA:Aguardando assinatura,AnaliseReprovada:Análise reprovada";
         Ddo_grid_Allowmultipleselection = "|||T|||T";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||FixedValues|||FixedValues";
         Ddo_grid_Includedatalist = "T|T||T|||T";
         Ddo_grid_Filterisrange = "||T||T|P|";
         Ddo_grid_Filtertype = "Character|Character|Numeric||Numeric|Date|";
         Ddo_grid_Includefilter = "T|T|T||T|T|";
         Ddo_grid_Includesortasc = "T|T||T||T|T";
         Ddo_grid_Columnssortvalues = "1|2||3||4|5";
         Ddo_grid_Columnids = "2:PropostaProtocolo|3:PropostaEmpresaRazao|4:PropostaQtdItensNota_F|5:PropostaTipoProposta|6:PropostaSumItensnota_F|8:PropostaCreatedAt|9:PropostaStatus";
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
         Form.Caption = " Proposta Nota";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E269B2","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbPropostaStatus"},{"av":"A329PropostaStatus","fld":"PROPOSTASTATUS","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV58PropostaCons","fld":"vPROPOSTACONS","type":"char"},{"av":"edtavPropostacons_Link","ctrl":"vPROPOSTACONS","prop":"Link"},{"av":"edtPropostaQtdItensNota_F_Link","ctrl":"PROPOSTAQTDITENSNOTA_F","prop":"Link"},{"av":"cmbPropostaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E289B1","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219B2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E279B1","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E229B2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E239B2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119B2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbPropostaStatus"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189B2","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199B2","iparms":[{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E209B2","iparms":[{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV59Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18PropostaQtdItensNota_F1","fld":"vPROPOSTAQTDITENSNOTA_F1","pic":"ZZZ9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22PropostaQtdItensNota_F2","fld":"vPROPOSTAQTDITENSNOTA_F2","pic":"ZZZ9","type":"int"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26PropostaQtdItensNota_F3","fld":"vPROPOSTAQTDITENSNOTA_F3","pic":"ZZZ9","type":"int"},{"av":"AV35TFPropostaProtocolo","fld":"vTFPROPOSTAPROTOCOLO","type":"svchar"},{"av":"AV36TFPropostaProtocolo_Sel","fld":"vTFPROPOSTAPROTOCOLO_SEL","type":"svchar"},{"av":"AV37TFPropostaEmpresaRazao","fld":"vTFPROPOSTAEMPRESARAZAO","pic":"@!","type":"svchar"},{"av":"AV38TFPropostaEmpresaRazao_Sel","fld":"vTFPROPOSTAEMPRESARAZAO_SEL","pic":"@!","type":"svchar"},{"av":"AV39TFPropostaQtdItensNota_F","fld":"vTFPROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"AV40TFPropostaQtdItensNota_F_To","fld":"vTFPROPOSTAQTDITENSNOTA_F_TO","pic":"ZZZ9","type":"int"},{"av":"AV42TFPropostaTipoProposta_Sels","fld":"vTFPROPOSTATIPOPROPOSTA_SELS","type":""},{"av":"AV43TFPropostaSumItensnota_F","fld":"vTFPROPOSTASUMITENSNOTA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV44TFPropostaSumItensnota_F_To","fld":"vTFPROPOSTASUMITENSNOTA_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV45TFPropostaCreatedAt","fld":"vTFPROPOSTACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46TFPropostaCreatedAt_To","fld":"vTFPROPOSTACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFPropostaStatus_Sels","fld":"vTFPROPOSTASTATUS_SELS","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV50TFPropostaStatus_SelsJson","fld":"vTFPROPOSTASTATUS_SELSJSON","type":"vchar"},{"av":"AV47DDO_PropostaCreatedAtAuxDate","fld":"vDDO_PROPOSTACREATEDATAUXDATE","type":"date"},{"av":"AV48DDO_PropostaCreatedAtAuxDateTo","fld":"vDDO_PROPOSTACREATEDATAUXDATETO","type":"date"},{"av":"AV41TFPropostaTipoProposta_SelsJson","fld":"vTFPROPOSTATIPOPROPOSTA_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavPropostaqtditensnota_f1_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F1","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f2_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F2","prop":"Visible"},{"av":"edtavPropostaqtditensnota_f3_Visible","ctrl":"vPROPOSTAQTDITENSNOTA_F3","prop":"Visible"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAEMPRESACLIENTEID","""{"handler":"Valid_Propostaempresaclienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Propostastatus","iparms":[]}""");
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
         AV59Pgmname = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV35TFPropostaProtocolo = "";
         AV36TFPropostaProtocolo_Sel = "";
         AV37TFPropostaEmpresaRazao = "";
         AV38TFPropostaEmpresaRazao_Sel = "";
         AV42TFPropostaTipoProposta_Sels = new GxSimpleCollection<string>();
         AV45TFPropostaCreatedAt = (DateTime)(DateTime.MinValue);
         AV46TFPropostaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV51TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47DDO_PropostaCreatedAtAuxDate = DateTime.MinValue;
         AV48DDO_PropostaCreatedAtAuxDateTo = DateTime.MinValue;
         AV41TFPropostaTipoProposta_SelsJson = "";
         AV50TFPropostaStatus_SelsJson = "";
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
         AV49DDO_PropostaCreatedAtAuxDateText = "";
         ucTfpropostacreatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV58PropostaCons = "";
         A853PropostaProtocolo = "";
         A888PropostaEmpresaRazao = "";
         A849PropostaTipoProposta = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A329PropostaStatus = "";
         AV78Propostanotawwds_19_tfpropostatipoproposta_sels = new GxSimpleCollection<string>();
         AV83Propostanotawwds_24_tfpropostastatus_sels = new GxSimpleCollection<string>();
         lV60Propostanotawwds_1_filterfulltext = "";
         lV72Propostanotawwds_13_tfpropostaprotocolo = "";
         lV74Propostanotawwds_15_tfpropostaempresarazao = "";
         AV73Propostanotawwds_14_tfpropostaprotocolo_sel = "";
         AV72Propostanotawwds_13_tfpropostaprotocolo = "";
         AV75Propostanotawwds_16_tfpropostaempresarazao_sel = "";
         AV74Propostanotawwds_15_tfpropostaempresarazao = "";
         AV81Propostanotawwds_22_tfpropostacreatedat = (DateTime)(DateTime.MinValue);
         AV82Propostanotawwds_23_tfpropostacreatedat_to = (DateTime)(DateTime.MinValue);
         AV60Propostanotawwds_1_filterfulltext = "";
         AV61Propostanotawwds_2_dynamicfiltersselector1 = "";
         AV65Propostanotawwds_6_dynamicfiltersselector2 = "";
         AV69Propostanotawwds_10_dynamicfiltersselector3 = "";
         H009B3_A329PropostaStatus = new string[] {""} ;
         H009B3_n329PropostaStatus = new bool[] {false} ;
         H009B3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009B3_n327PropostaCreatedAt = new bool[] {false} ;
         H009B3_A850PropostaEmpresaClienteId = new int[1] ;
         H009B3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         H009B3_A849PropostaTipoProposta = new string[] {""} ;
         H009B3_n849PropostaTipoProposta = new bool[] {false} ;
         H009B3_A888PropostaEmpresaRazao = new string[] {""} ;
         H009B3_n888PropostaEmpresaRazao = new bool[] {false} ;
         H009B3_A853PropostaProtocolo = new string[] {""} ;
         H009B3_n853PropostaProtocolo = new bool[] {false} ;
         H009B3_A323PropostaId = new int[1] ;
         H009B3_n323PropostaId = new bool[] {false} ;
         H009B3_A887PropostaSumItensnota_F = new decimal[1] ;
         H009B3_A854PropostaQtdItensNota_F = new short[1] ;
         H009B5_AGRID_nRecordCount = new long[1] ;
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
         GXt_char4 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV57AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanotaww__default(),
            new Object[][] {
                new Object[] {
               H009B3_A329PropostaStatus, H009B3_n329PropostaStatus, H009B3_A327PropostaCreatedAt, H009B3_n327PropostaCreatedAt, H009B3_A850PropostaEmpresaClienteId, H009B3_n850PropostaEmpresaClienteId, H009B3_A849PropostaTipoProposta, H009B3_n849PropostaTipoProposta, H009B3_A888PropostaEmpresaRazao, H009B3_n888PropostaEmpresaRazao,
               H009B3_A853PropostaProtocolo, H009B3_n853PropostaProtocolo, H009B3_A323PropostaId, H009B3_A887PropostaSumItensnota_F, H009B3_A854PropostaQtdItensNota_F
               }
               , new Object[] {
               H009B5_AGRID_nRecordCount
               }
            }
         );
         AV59Pgmname = "PropostaNotaWW";
         /* GeneXus formulas. */
         AV59Pgmname = "PropostaNotaWW";
         edtavPropostacons_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV34ManageFiltersExecutionStep ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV18PropostaQtdItensNota_F1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV22PropostaQtdItensNota_F2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV26PropostaQtdItensNota_F3 ;
      private short AV39TFPropostaQtdItensNota_F ;
      private short AV40TFPropostaQtdItensNota_F_To ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A854PropostaQtdItensNota_F ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV62Propostanotawwds_3_dynamicfiltersoperator1 ;
      private short AV63Propostanotawwds_4_propostaqtditensnota_f1 ;
      private short AV66Propostanotawwds_7_dynamicfiltersoperator2 ;
      private short AV67Propostanotawwds_8_propostaqtditensnota_f2 ;
      private short AV70Propostanotawwds_11_dynamicfiltersoperator3 ;
      private short AV71Propostanotawwds_12_propostaqtditensnota_f3 ;
      private short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ;
      private short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to ;
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
      private int A323PropostaId ;
      private int A850PropostaEmpresaClienteId ;
      private int subGrid_Islastpage ;
      private int edtavPropostacons_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ;
      private int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaProtocolo_Enabled ;
      private int edtPropostaEmpresaRazao_Enabled ;
      private int edtPropostaQtdItensNota_F_Enabled ;
      private int edtPropostaSumItensnota_F_Enabled ;
      private int edtPropostaEmpresaClienteId_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int AV53PageToGo ;
      private int edtavPropostaqtditensnota_f1_Visible ;
      private int edtavPropostaqtditensnota_f2_Visible ;
      private int edtavPropostaqtditensnota_f3_Visible ;
      private int AV84GXV1 ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavPropostaqtditensnota_f3_Enabled ;
      private int edtavPropostaqtditensnota_f2_Enabled ;
      private int edtavPropostaqtditensnota_f1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV43TFPropostaSumItensnota_F ;
      private decimal AV44TFPropostaSumItensnota_F_To ;
      private decimal A887PropostaSumItensnota_F ;
      private decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ;
      private decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_109_idx="0001" ;
      private string AV59Pgmname ;
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
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
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
      private string divDdo_propostacreatedatauxdates_Internalname ;
      private string edtavDdo_propostacreatedatauxdatetext_Internalname ;
      private string edtavDdo_propostacreatedatauxdatetext_Jsonclick ;
      private string Tfpropostacreatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV58PropostaCons ;
      private string edtavPropostacons_Internalname ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaProtocolo_Internalname ;
      private string edtPropostaEmpresaRazao_Internalname ;
      private string edtPropostaQtdItensNota_F_Internalname ;
      private string cmbPropostaTipoProposta_Internalname ;
      private string edtPropostaSumItensnota_F_Internalname ;
      private string edtPropostaEmpresaClienteId_Internalname ;
      private string edtPropostaCreatedAt_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavPropostaqtditensnota_f1_Internalname ;
      private string edtavPropostaqtditensnota_f2_Internalname ;
      private string edtavPropostaqtditensnota_f3_Internalname ;
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
      private string cmbPropostaStatus_Columnheaderclass ;
      private string edtavPropostacons_Link ;
      private string GXEncryptionTmp ;
      private string edtPropostaQtdItensNota_F_Link ;
      private string cmbPropostaStatus_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_propostaqtditensnota_f3_cell_Internalname ;
      private string edtavPropostaqtditensnota_f3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_propostaqtditensnota_f2_cell_Internalname ;
      private string edtavPropostaqtditensnota_f2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_propostaqtditensnota_f1_cell_Internalname ;
      private string edtavPropostaqtditensnota_f1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavPropostacons_Jsonclick ;
      private string edtPropostaId_Jsonclick ;
      private string edtPropostaProtocolo_Jsonclick ;
      private string edtPropostaEmpresaRazao_Jsonclick ;
      private string edtPropostaQtdItensNota_F_Jsonclick ;
      private string GXCCtl ;
      private string cmbPropostaTipoProposta_Jsonclick ;
      private string edtPropostaSumItensnota_F_Jsonclick ;
      private string edtPropostaEmpresaClienteId_Jsonclick ;
      private string edtPropostaCreatedAt_Jsonclick ;
      private string cmbPropostaStatus_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV45TFPropostaCreatedAt ;
      private DateTime AV46TFPropostaCreatedAt_To ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime AV81Propostanotawwds_22_tfpropostacreatedat ;
      private DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ;
      private DateTime AV47DDO_PropostaCreatedAtAuxDate ;
      private DateTime AV48DDO_PropostaCreatedAtAuxDateTo ;
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
      private bool n323PropostaId ;
      private bool n853PropostaProtocolo ;
      private bool n888PropostaEmpresaRazao ;
      private bool n849PropostaTipoProposta ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n327PropostaCreatedAt ;
      private bool n329PropostaStatus ;
      private bool bGXsfl_109_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ;
      private bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV41TFPropostaTipoProposta_SelsJson ;
      private string AV50TFPropostaStatus_SelsJson ;
      private string AV33ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV35TFPropostaProtocolo ;
      private string AV36TFPropostaProtocolo_Sel ;
      private string AV37TFPropostaEmpresaRazao ;
      private string AV38TFPropostaEmpresaRazao_Sel ;
      private string AV56GridAppliedFilters ;
      private string AV49DDO_PropostaCreatedAtAuxDateText ;
      private string A853PropostaProtocolo ;
      private string A888PropostaEmpresaRazao ;
      private string A849PropostaTipoProposta ;
      private string A329PropostaStatus ;
      private string lV60Propostanotawwds_1_filterfulltext ;
      private string lV72Propostanotawwds_13_tfpropostaprotocolo ;
      private string lV74Propostanotawwds_15_tfpropostaempresarazao ;
      private string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ;
      private string AV72Propostanotawwds_13_tfpropostaprotocolo ;
      private string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ;
      private string AV74Propostanotawwds_15_tfpropostaempresarazao ;
      private string AV60Propostanotawwds_1_filterfulltext ;
      private string AV61Propostanotawwds_2_dynamicfiltersselector1 ;
      private string AV65Propostanotawwds_6_dynamicfiltersselector2 ;
      private string AV69Propostanotawwds_10_dynamicfiltersselector3 ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private string AV57AuxText ;
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
      private GXUserControl ucTfpropostacreatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbPropostaTipoProposta ;
      private GXCombobox cmbPropostaStatus ;
      private GxSimpleCollection<string> AV42TFPropostaTipoProposta_Sels ;
      private GxSimpleCollection<string> AV51TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ;
      private GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H009B3_A329PropostaStatus ;
      private bool[] H009B3_n329PropostaStatus ;
      private DateTime[] H009B3_A327PropostaCreatedAt ;
      private bool[] H009B3_n327PropostaCreatedAt ;
      private int[] H009B3_A850PropostaEmpresaClienteId ;
      private bool[] H009B3_n850PropostaEmpresaClienteId ;
      private string[] H009B3_A849PropostaTipoProposta ;
      private bool[] H009B3_n849PropostaTipoProposta ;
      private string[] H009B3_A888PropostaEmpresaRazao ;
      private bool[] H009B3_n888PropostaEmpresaRazao ;
      private string[] H009B3_A853PropostaProtocolo ;
      private bool[] H009B3_n853PropostaProtocolo ;
      private int[] H009B3_A323PropostaId ;
      private bool[] H009B3_n323PropostaId ;
      private decimal[] H009B3_A887PropostaSumItensnota_F ;
      private short[] H009B3_A854PropostaQtdItensNota_F ;
      private long[] H009B5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostanotaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009B3( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV81Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV60Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[72];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.PropostaStatus, T1.PropostaCreatedAt, T1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T1.PropostaTipoProposta, T2.ClienteRazaoSocial AS PropostaEmpresaRazao, T1.PropostaProtocolo, T1.PropostaId, COALESCE( T3.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F";
         sFromString = " FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         sOrderString = "";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV60Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV76Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV76Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV72Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int7[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV73Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int7[62] = 1;
         }
         if ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV74Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int7[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV75Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV79Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV80Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV81Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV82Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( AV83Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaProtocolo, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaProtocolo DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaTipoProposta, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaTipoProposta DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaCreatedAt, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaCreatedAt DESC, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.PropostaStatus, T1.PropostaId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.PropostaStatus DESC, T1.PropostaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.PropostaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H009B5( IGxContext context ,
                                             string A849PropostaTipoProposta ,
                                             GxSimpleCollection<string> AV78Propostanotawwds_19_tfpropostatipoproposta_sels ,
                                             string A329PropostaStatus ,
                                             GxSimpleCollection<string> AV83Propostanotawwds_24_tfpropostastatus_sels ,
                                             string AV73Propostanotawwds_14_tfpropostaprotocolo_sel ,
                                             string AV72Propostanotawwds_13_tfpropostaprotocolo ,
                                             string AV75Propostanotawwds_16_tfpropostaempresarazao_sel ,
                                             string AV74Propostanotawwds_15_tfpropostaempresarazao ,
                                             int AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count ,
                                             decimal AV79Propostanotawwds_20_tfpropostasumitensnota_f ,
                                             decimal AV80Propostanotawwds_21_tfpropostasumitensnota_f_to ,
                                             DateTime AV81Propostanotawwds_22_tfpropostacreatedat ,
                                             DateTime AV82Propostanotawwds_23_tfpropostacreatedat_to ,
                                             int AV83Propostanotawwds_24_tfpropostastatus_sels_Count ,
                                             string A853PropostaProtocolo ,
                                             string A888PropostaEmpresaRazao ,
                                             decimal A887PropostaSumItensnota_F ,
                                             DateTime A327PropostaCreatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             string AV60Propostanotawwds_1_filterfulltext ,
                                             short A854PropostaQtdItensNota_F ,
                                             string AV61Propostanotawwds_2_dynamicfiltersselector1 ,
                                             short AV62Propostanotawwds_3_dynamicfiltersoperator1 ,
                                             short AV63Propostanotawwds_4_propostaqtditensnota_f1 ,
                                             bool AV64Propostanotawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Propostanotawwds_6_dynamicfiltersselector2 ,
                                             short AV66Propostanotawwds_7_dynamicfiltersoperator2 ,
                                             short AV67Propostanotawwds_8_propostaqtditensnota_f2 ,
                                             bool AV68Propostanotawwds_9_dynamicfiltersenabled3 ,
                                             string AV69Propostanotawwds_10_dynamicfiltersselector3 ,
                                             short AV70Propostanotawwds_11_dynamicfiltersoperator3 ,
                                             short AV71Propostanotawwds_12_propostaqtditensnota_f3 ,
                                             short AV76Propostanotawwds_17_tfpropostaqtditensnota_f ,
                                             short AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[69];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaEmpresaClienteId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F, PropostaId, COUNT(*) AS PropostaQtdItensNota_F FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV60Propostanotawwds_1_filterfulltext))=0) or ( ( T1.PropostaProtocolo like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaQtdItensNota_F, 0),'9999'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'clinica' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'CLINICA')) or ( 'compra de título' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaTipoProposta = ( 'COMPRA_TITULO')) or ( SUBSTR(TO_CHAR(COALESCE( T3.PropostaSumItensnota_F, 0),'999999999999990.99'), 2) like '%' || :lV60Propostanotawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV60Propostanotawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada'))))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV61Propostanotawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV62Propostanotawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV63Propostanotawwds_4_propostaqtditensnota_f1 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV63Propostanotawwds_4_propostaqtditensnota_f1))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 0 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 1 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV64Propostanotawwds_5_dynamicfiltersenabled2 and :AV65Propostanotawwds_6_dynamicfiltersselector2 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV66Propostanotawwds_7_dynamicfiltersoperator2 = 2 and ( Not (:AV67Propostanotawwds_8_propostaqtditensnota_f2 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV67Propostanotawwds_8_propostaqtditensnota_f2))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 0 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) < :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 1 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) = :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "(Not ( :AV68Propostanotawwds_9_dynamicfiltersenabled3 and :AV69Propostanotawwds_10_dynamicfiltersselector3 = ( 'PROPOSTAQTDITENSNOTA_F') and :AV70Propostanotawwds_11_dynamicfiltersoperator3 = 2 and ( Not (:AV71Propostanotawwds_12_propostaqtditensnota_f3 = 0))) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) > :AV71Propostanotawwds_12_propostaqtditensnota_f3))");
         AddWhere(sWhereString, "((:AV76Propostanotawwds_17_tfpropostaqtditensnota_f = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) >= :AV76Propostanotawwds_17_tfpropostaqtditensnota_f))");
         AddWhere(sWhereString, "((:AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to = 0) or ( COALESCE( T3.PropostaQtdItensNota_F, 0) <= :AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to))");
         AddWhere(sWhereString, "(COALESCE( T3.PropostaQtdItensNota_F, 0) > 0)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Propostanotawwds_13_tfpropostaprotocolo)) ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo like :lV72Propostanotawwds_13_tfpropostaprotocolo)");
         }
         else
         {
            GXv_int9[61] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Propostanotawwds_14_tfpropostaprotocolo_sel)) && ! ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo = ( :AV73Propostanotawwds_14_tfpropostaprotocolo_sel))");
         }
         else
         {
            GXv_int9[62] = 1;
         }
         if ( StringUtil.StrCmp(AV73Propostanotawwds_14_tfpropostaprotocolo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.PropostaProtocolo IS NULL or (char_length(trim(trailing ' ' from T1.PropostaProtocolo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Propostanotawwds_15_tfpropostaempresarazao)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV74Propostanotawwds_15_tfpropostaempresarazao)");
         }
         else
         {
            GXv_int9[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Propostanotawwds_16_tfpropostaempresarazao_sel)) && ! ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV75Propostanotawwds_16_tfpropostaempresarazao_sel))");
         }
         else
         {
            GXv_int9[64] = 1;
         }
         if ( StringUtil.StrCmp(AV75Propostanotawwds_16_tfpropostaempresarazao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( AV78Propostanotawwds_19_tfpropostatipoproposta_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Propostanotawwds_19_tfpropostatipoproposta_sels, "T1.PropostaTipoProposta IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Propostanotawwds_20_tfpropostasumitensnota_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) >= :AV79Propostanotawwds_20_tfpropostasumitensnota_f)");
         }
         else
         {
            GXv_int9[65] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Propostanotawwds_21_tfpropostasumitensnota_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T3.PropostaSumItensnota_F, 0) <= :AV80Propostanotawwds_21_tfpropostasumitensnota_f_to)");
         }
         else
         {
            GXv_int9[66] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Propostanotawwds_22_tfpropostacreatedat) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt >= :AV81Propostanotawwds_22_tfpropostacreatedat)");
         }
         else
         {
            GXv_int9[67] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Propostanotawwds_23_tfpropostacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.PropostaCreatedAt <= :AV82Propostanotawwds_23_tfpropostacreatedat_to)");
         }
         else
         {
            GXv_int9[68] = 1;
         }
         if ( AV83Propostanotawwds_24_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV83Propostanotawwds_24_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H009B3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] );
               case 1 :
                     return conditional_H009B5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (DateTime)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (short)dynConstraints[34] );
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
          Object[] prmH009B3;
          prmH009B3 = new Object[] {
          new ParDef("AV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV72Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV73Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV74Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV75Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV79Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV80Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV81Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009B5;
          prmH009B5 = new Object[] {
          new ParDef("AV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Propostanotawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV61Propostanotawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV62Propostanotawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV63Propostanotawwds_4_propostaqtditensnota_f1",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV64Propostanotawwds_5_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV65Propostanotawwds_6_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV66Propostanotawwds_7_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV67Propostanotawwds_8_propostaqtditensnota_f2",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV68Propostanotawwds_9_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV69Propostanotawwds_10_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV70Propostanotawwds_11_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV71Propostanotawwds_12_propostaqtditensnota_f3",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV76Propostanotawwds_17_tfpropostaqtditensnota_f",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("AV77Propostanotawwds_18_tfpropostaqtditensnota_f_to",GXType.Int16,4,0) ,
          new ParDef("lV72Propostanotawwds_13_tfpropostaprotocolo",GXType.VarChar,40,0) ,
          new ParDef("AV73Propostanotawwds_14_tfpropostaprotocolo_sel",GXType.VarChar,40,0) ,
          new ParDef("lV74Propostanotawwds_15_tfpropostaempresarazao",GXType.VarChar,150,0) ,
          new ParDef("AV75Propostanotawwds_16_tfpropostaempresarazao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV79Propostanotawwds_20_tfpropostasumitensnota_f",GXType.Number,18,2) ,
          new ParDef("AV80Propostanotawwds_21_tfpropostasumitensnota_f_to",GXType.Number,18,2) ,
          new ParDef("AV81Propostanotawwds_22_tfpropostacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Propostanotawwds_23_tfpropostacreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H009B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009B3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009B5,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((short[]) buf[14])[0] = rslt.getShort(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
