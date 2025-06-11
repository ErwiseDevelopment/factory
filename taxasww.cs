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
   public class taxasww : GXDataArea
   {
      public taxasww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public taxasww( IGxContext context )
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
         nRC_GXsfl_105 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_105"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_105_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_105_idx = GetPar( "sGXsfl_105_idx");
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
         AV18TaxasPercentual1 = NumberUtil.Val( GetPar( "TaxasPercentual1"), ".");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22TaxasPercentual2 = NumberUtil.Val( GetPar( "TaxasPercentual2"), ".");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26TaxasPercentual3 = NumberUtil.Val( GetPar( "TaxasPercentual3"), ".");
         AV32ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV61Pgmname = GetPar( "Pgmname");
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV33TFTaxasPercentual = NumberUtil.Val( GetPar( "TFTaxasPercentual"), ".");
         AV34TFTaxasPercentual_To = NumberUtil.Val( GetPar( "TFTaxasPercentual_To"), ".");
         AV59TFTaxasPercentualAnual = NumberUtil.Val( GetPar( "TFTaxasPercentualAnual"), ".");
         AV60TFTaxasPercentualAnual_To = NumberUtil.Val( GetPar( "TFTaxasPercentualAnual_To"), ".");
         AV35TFTaxasValorMinimo = NumberUtil.Val( GetPar( "TFTaxasValorMinimo"), ".");
         AV36TFTaxasValorMinimo_To = NumberUtil.Val( GetPar( "TFTaxasValorMinimo_To"), ".");
         AV37TFTaxasCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFTaxasCreatedAt"));
         AV38TFTaxasCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFTaxasCreatedAt_To"));
         AV42TFTaxasUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFTaxasUpdatedAt"));
         AV43TFTaxasUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFTaxasUpdatedAt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PA8T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START8T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("taxasww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vTAXASPERCENTUAL1", StringUtil.LTrim( StringUtil.NToC( AV18TaxasPercentual1, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTAXASPERCENTUAL2", StringUtil.LTrim( StringUtil.NToC( AV22TaxasPercentual2, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTAXASPERCENTUAL3", StringUtil.LTrim( StringUtil.NToC( AV26TaxasPercentual3, 16, 4, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_105", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_105), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV55GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV51DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TAXASCREATEDATAUXDATE", context.localUtil.DToC( AV39DDO_TaxasCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TAXASCREATEDATAUXDATETO", context.localUtil.DToC( AV40DDO_TaxasCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TAXASUPDATEDATAUXDATE", context.localUtil.DToC( AV44DDO_TaxasUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TAXASUPDATEDATAUXDATETO", context.localUtil.DToC( AV45DDO_TaxasUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFTAXASPERCENTUAL", StringUtil.LTrim( StringUtil.NToC( AV33TFTaxasPercentual, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASPERCENTUAL_TO", StringUtil.LTrim( StringUtil.NToC( AV34TFTaxasPercentual_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASPERCENTUALANUAL", StringUtil.LTrim( StringUtil.NToC( AV59TFTaxasPercentualAnual, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASPERCENTUALANUAL_TO", StringUtil.LTrim( StringUtil.NToC( AV60TFTaxasPercentualAnual_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASVALORMINIMO", StringUtil.LTrim( StringUtil.NToC( AV35TFTaxasValorMinimo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASVALORMINIMO_TO", StringUtil.LTrim( StringUtil.NToC( AV36TFTaxasValorMinimo_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTAXASCREATEDAT", context.localUtil.TToC( AV37TFTaxasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFTAXASCREATEDAT_TO", context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFTAXASUPDATEDAT", context.localUtil.TToC( AV42TFTaxasUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFTAXASUPDATEDAT_TO", context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
            WE8T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT8T2( ) ;
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
         return formatLink("taxasww")  ;
      }

      public override string GetPgmname( )
      {
         return "TaxasWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Taxas" ;
      }

      protected void WB8T0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(105), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TaxasWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV30ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_TaxasWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_8T2( true) ;
         }
         else
         {
            wb_table1_43_8T2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_8T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_65_8T2( true) ;
         }
         else
         {
            wb_table2_65_8T2( false) ;
         }
         return  ;
      }

      protected void wb_table2_65_8T2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_87_8T2( true) ;
         }
         else
         {
            wb_table3_87_8T2( false) ;
         }
         return  ;
      }

      protected void wb_table3_87_8T2e( bool wbgen )
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
            StartGridControl105( ) ;
         }
         if ( wbEnd == 105 )
         {
            wbEnd = 0;
            nRC_GXsfl_105 = (int)(nGXsfl_105_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV53GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV54GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV55GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_TaxasWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_taxascreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_taxascreatedatauxdatetext_Internalname, AV41DDO_TaxasCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV41DDO_TaxasCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_taxascreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TaxasWW.htm");
            /* User Defined Control */
            ucTftaxascreatedat_rangepicker.SetProperty("Start Date", AV39DDO_TaxasCreatedAtAuxDate);
            ucTftaxascreatedat_rangepicker.SetProperty("End Date", AV40DDO_TaxasCreatedAtAuxDateTo);
            ucTftaxascreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tftaxascreatedat_rangepicker_Internalname, "TFTAXASCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_taxasupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_taxasupdatedatauxdatetext_Internalname, AV46DDO_TaxasUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV46DDO_TaxasUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_taxasupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TaxasWW.htm");
            /* User Defined Control */
            ucTftaxasupdatedat_rangepicker.SetProperty("Start Date", AV44DDO_TaxasUpdatedAtAuxDate);
            ucTftaxasupdatedat_rangepicker.SetProperty("End Date", AV45DDO_TaxasUpdatedAtAuxDateTo);
            ucTftaxasupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tftaxasupdatedat_rangepicker_Internalname, "TFTAXASUPDATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 105 )
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

      protected void START8T2( )
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
         Form.Meta.addItem("description", " Taxas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP8T0( ) ;
      }

      protected void WS8T2( )
      {
         START8T2( ) ;
         EVT8T2( ) ;
      }

      protected void EVT8T2( )
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
                              E118T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E128T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E138T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E148T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E158T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E168T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E178T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E188T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E198T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E208T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E218T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E228T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E238T2 ();
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
                              nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
                              SubsflControlProps_1052( ) ;
                              AV56Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV56Display);
                              AV57Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
                              AV58Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV58Delete);
                              A863TaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A864TaxasPercentual = context.localUtil.CToN( cgiGet( edtTaxasPercentual_Internalname), ",", ".");
                              n864TaxasPercentual = false;
                              A894TaxasPercentualAnual = context.localUtil.CToN( cgiGet( edtTaxasPercentualAnual_Internalname), ",", ".");
                              n894TaxasPercentualAnual = false;
                              A865TaxasValorMinimo = context.localUtil.CToN( cgiGet( edtTaxasValorMinimo_Internalname), ",", ".");
                              n865TaxasValorMinimo = false;
                              A866TaxasCreatedAt = context.localUtil.CToT( cgiGet( edtTaxasCreatedAt_Internalname), 0);
                              n866TaxasCreatedAt = false;
                              A867TaxasUpdatedAt = context.localUtil.CToT( cgiGet( edtTaxasUpdatedAt_Internalname), 0);
                              n867TaxasUpdatedAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E248T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E258T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E268T2 ();
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
                                       /* Set Refresh If Taxaspercentual1 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL1"), ",", ".") != AV18TaxasPercentual1 )
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
                                       /* Set Refresh If Taxaspercentual2 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL2"), ",", ".") != AV22TaxasPercentual2 )
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
                                       /* Set Refresh If Taxaspercentual3 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL3"), ",", ".") != AV26TaxasPercentual3 )
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

      protected void WE8T2( )
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

      protected void PA8T2( )
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
         SubsflControlProps_1052( ) ;
         while ( nGXsfl_105_idx <= nRC_GXsfl_105 )
         {
            sendrow_1052( ) ;
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
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
                                       decimal AV18TaxasPercentual1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       decimal AV22TaxasPercentual2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       decimal AV26TaxasPercentual3 ,
                                       short AV32ManageFiltersExecutionStep ,
                                       string AV61Pgmname ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       decimal AV33TFTaxasPercentual ,
                                       decimal AV34TFTaxasPercentual_To ,
                                       decimal AV59TFTaxasPercentualAnual ,
                                       decimal AV60TFTaxasPercentualAnual_To ,
                                       decimal AV35TFTaxasValorMinimo ,
                                       decimal AV36TFTaxasValorMinimo_To ,
                                       DateTime AV37TFTaxasCreatedAt ,
                                       DateTime AV38TFTaxasCreatedAt_To ,
                                       DateTime AV42TFTaxasUpdatedAt ,
                                       DateTime AV43TFTaxasUpdatedAt_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF8T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TAXASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A863TaxasId), 9, 0, ".", "")));
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
         RF8T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV61Pgmname = "TaxasWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF8T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 105;
         /* Execute user event: Refresh */
         E258T2 ();
         nGXsfl_105_idx = 1;
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         bGXsfl_105_Refreshing = true;
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
            SubsflControlProps_1052( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV62Taxaswwds_1_filterfulltext ,
                                                 AV63Taxaswwds_2_dynamicfiltersselector1 ,
                                                 AV64Taxaswwds_3_dynamicfiltersoperator1 ,
                                                 AV65Taxaswwds_4_taxaspercentual1 ,
                                                 AV66Taxaswwds_5_dynamicfiltersenabled2 ,
                                                 AV67Taxaswwds_6_dynamicfiltersselector2 ,
                                                 AV68Taxaswwds_7_dynamicfiltersoperator2 ,
                                                 AV69Taxaswwds_8_taxaspercentual2 ,
                                                 AV70Taxaswwds_9_dynamicfiltersenabled3 ,
                                                 AV71Taxaswwds_10_dynamicfiltersselector3 ,
                                                 AV72Taxaswwds_11_dynamicfiltersoperator3 ,
                                                 AV73Taxaswwds_12_taxaspercentual3 ,
                                                 AV74Taxaswwds_13_tftaxaspercentual ,
                                                 AV75Taxaswwds_14_tftaxaspercentual_to ,
                                                 AV76Taxaswwds_15_tftaxaspercentualanual ,
                                                 AV77Taxaswwds_16_tftaxaspercentualanual_to ,
                                                 AV78Taxaswwds_17_tftaxasvalorminimo ,
                                                 AV79Taxaswwds_18_tftaxasvalorminimo_to ,
                                                 AV80Taxaswwds_19_tftaxascreatedat ,
                                                 AV81Taxaswwds_20_tftaxascreatedat_to ,
                                                 AV82Taxaswwds_21_tftaxasupdatedat ,
                                                 AV83Taxaswwds_22_tftaxasupdatedat_to ,
                                                 A864TaxasPercentual ,
                                                 A894TaxasPercentualAnual ,
                                                 A865TaxasValorMinimo ,
                                                 A866TaxasCreatedAt ,
                                                 A867TaxasUpdatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
            lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
            lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
            /* Using cursor H008T2 */
            pr_default.execute(0, new Object[] {lV62Taxaswwds_1_filterfulltext, lV62Taxaswwds_1_filterfulltext, lV62Taxaswwds_1_filterfulltext, AV65Taxaswwds_4_taxaspercentual1, AV65Taxaswwds_4_taxaspercentual1, AV65Taxaswwds_4_taxaspercentual1, AV69Taxaswwds_8_taxaspercentual2, AV69Taxaswwds_8_taxaspercentual2, AV69Taxaswwds_8_taxaspercentual2, AV73Taxaswwds_12_taxaspercentual3, AV73Taxaswwds_12_taxaspercentual3, AV73Taxaswwds_12_taxaspercentual3, AV74Taxaswwds_13_tftaxaspercentual, AV75Taxaswwds_14_tftaxaspercentual_to, AV76Taxaswwds_15_tftaxaspercentualanual, AV77Taxaswwds_16_tftaxaspercentualanual_to, AV78Taxaswwds_17_tftaxasvalorminimo, AV79Taxaswwds_18_tftaxasvalorminimo_to, AV80Taxaswwds_19_tftaxascreatedat, AV81Taxaswwds_20_tftaxascreatedat_to, AV82Taxaswwds_21_tftaxasupdatedat, AV83Taxaswwds_22_tftaxasupdatedat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_105_idx = 1;
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A867TaxasUpdatedAt = H008T2_A867TaxasUpdatedAt[0];
               n867TaxasUpdatedAt = H008T2_n867TaxasUpdatedAt[0];
               A866TaxasCreatedAt = H008T2_A866TaxasCreatedAt[0];
               n866TaxasCreatedAt = H008T2_n866TaxasCreatedAt[0];
               A865TaxasValorMinimo = H008T2_A865TaxasValorMinimo[0];
               n865TaxasValorMinimo = H008T2_n865TaxasValorMinimo[0];
               A894TaxasPercentualAnual = H008T2_A894TaxasPercentualAnual[0];
               n894TaxasPercentualAnual = H008T2_n894TaxasPercentualAnual[0];
               A864TaxasPercentual = H008T2_A864TaxasPercentual[0];
               n864TaxasPercentual = H008T2_n864TaxasPercentual[0];
               A863TaxasId = H008T2_A863TaxasId[0];
               /* Execute user event: Grid.Load */
               E268T2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 105;
            WB8T0( ) ;
         }
         bGXsfl_105_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes8T2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TAXASID"+"_"+sGXsfl_105_idx, GetSecureSignedToken( sGXsfl_105_idx, context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9"), context));
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
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV62Taxaswwds_1_filterfulltext ,
                                              AV63Taxaswwds_2_dynamicfiltersselector1 ,
                                              AV64Taxaswwds_3_dynamicfiltersoperator1 ,
                                              AV65Taxaswwds_4_taxaspercentual1 ,
                                              AV66Taxaswwds_5_dynamicfiltersenabled2 ,
                                              AV67Taxaswwds_6_dynamicfiltersselector2 ,
                                              AV68Taxaswwds_7_dynamicfiltersoperator2 ,
                                              AV69Taxaswwds_8_taxaspercentual2 ,
                                              AV70Taxaswwds_9_dynamicfiltersenabled3 ,
                                              AV71Taxaswwds_10_dynamicfiltersselector3 ,
                                              AV72Taxaswwds_11_dynamicfiltersoperator3 ,
                                              AV73Taxaswwds_12_taxaspercentual3 ,
                                              AV74Taxaswwds_13_tftaxaspercentual ,
                                              AV75Taxaswwds_14_tftaxaspercentual_to ,
                                              AV76Taxaswwds_15_tftaxaspercentualanual ,
                                              AV77Taxaswwds_16_tftaxaspercentualanual_to ,
                                              AV78Taxaswwds_17_tftaxasvalorminimo ,
                                              AV79Taxaswwds_18_tftaxasvalorminimo_to ,
                                              AV80Taxaswwds_19_tftaxascreatedat ,
                                              AV81Taxaswwds_20_tftaxascreatedat_to ,
                                              AV82Taxaswwds_21_tftaxasupdatedat ,
                                              AV83Taxaswwds_22_tftaxasupdatedat_to ,
                                              A864TaxasPercentual ,
                                              A894TaxasPercentualAnual ,
                                              A865TaxasValorMinimo ,
                                              A866TaxasCreatedAt ,
                                              A867TaxasUpdatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
         lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
         lV62Taxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext), "%", "");
         /* Using cursor H008T3 */
         pr_default.execute(1, new Object[] {lV62Taxaswwds_1_filterfulltext, lV62Taxaswwds_1_filterfulltext, lV62Taxaswwds_1_filterfulltext, AV65Taxaswwds_4_taxaspercentual1, AV65Taxaswwds_4_taxaspercentual1, AV65Taxaswwds_4_taxaspercentual1, AV69Taxaswwds_8_taxaspercentual2, AV69Taxaswwds_8_taxaspercentual2, AV69Taxaswwds_8_taxaspercentual2, AV73Taxaswwds_12_taxaspercentual3, AV73Taxaswwds_12_taxaspercentual3, AV73Taxaswwds_12_taxaspercentual3, AV74Taxaswwds_13_tftaxaspercentual, AV75Taxaswwds_14_tftaxaspercentual_to, AV76Taxaswwds_15_tftaxaspercentualanual, AV77Taxaswwds_16_tftaxaspercentualanual_to, AV78Taxaswwds_17_tftaxasvalorminimo, AV79Taxaswwds_18_tftaxasvalorminimo_to, AV80Taxaswwds_19_tftaxascreatedat, AV81Taxaswwds_20_tftaxascreatedat_to, AV82Taxaswwds_21_tftaxasupdatedat, AV83Taxaswwds_22_tftaxasupdatedat_to});
         GRID_nRecordCount = H008T3_AGRID_nRecordCount[0];
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
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV61Pgmname = "TaxasWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtTaxasId_Enabled = 0;
         edtTaxasPercentual_Enabled = 0;
         edtTaxasPercentualAnual_Enabled = 0;
         edtTaxasValorMinimo_Enabled = 0;
         edtTaxasCreatedAt_Enabled = 0;
         edtTaxasUpdatedAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP8T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E248T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV30ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_105 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_105"), ",", "."), 18, MidpointRounding.ToEven));
            AV53GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV39DDO_TaxasCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TAXASCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV39DDO_TaxasCreatedAtAuxDate", context.localUtil.Format(AV39DDO_TaxasCreatedAtAuxDate, "99/99/9999"));
            AV40DDO_TaxasCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TAXASCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV40DDO_TaxasCreatedAtAuxDateTo", context.localUtil.Format(AV40DDO_TaxasCreatedAtAuxDateTo, "99/99/9999"));
            AV44DDO_TaxasUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TAXASUPDATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV44DDO_TaxasUpdatedAtAuxDate", context.localUtil.Format(AV44DDO_TaxasUpdatedAtAuxDate, "99/99/9999"));
            AV45DDO_TaxasUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TAXASUPDATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV45DDO_TaxasUpdatedAtAuxDateTo", context.localUtil.Format(AV45DDO_TaxasUpdatedAtAuxDateTo, "99/99/9999"));
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
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual1_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTAXASPERCENTUAL1");
               GX_FocusControl = edtavTaxaspercentual1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18TaxasPercentual1 = 0;
               AssignAttri("", false, "AV18TaxasPercentual1", StringUtil.LTrimStr( AV18TaxasPercentual1, 16, 4));
            }
            else
            {
               AV18TaxasPercentual1 = context.localUtil.CToN( cgiGet( edtavTaxaspercentual1_Internalname), ",", ".");
               AssignAttri("", false, "AV18TaxasPercentual1", StringUtil.LTrimStr( AV18TaxasPercentual1, 16, 4));
            }
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual2_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTAXASPERCENTUAL2");
               GX_FocusControl = edtavTaxaspercentual2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22TaxasPercentual2 = 0;
               AssignAttri("", false, "AV22TaxasPercentual2", StringUtil.LTrimStr( AV22TaxasPercentual2, 16, 4));
            }
            else
            {
               AV22TaxasPercentual2 = context.localUtil.CToN( cgiGet( edtavTaxaspercentual2_Internalname), ",", ".");
               AssignAttri("", false, "AV22TaxasPercentual2", StringUtil.LTrimStr( AV22TaxasPercentual2, 16, 4));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTaxaspercentual3_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTAXASPERCENTUAL3");
               GX_FocusControl = edtavTaxaspercentual3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26TaxasPercentual3 = 0;
               AssignAttri("", false, "AV26TaxasPercentual3", StringUtil.LTrimStr( AV26TaxasPercentual3, 16, 4));
            }
            else
            {
               AV26TaxasPercentual3 = context.localUtil.CToN( cgiGet( edtavTaxaspercentual3_Internalname), ",", ".");
               AssignAttri("", false, "AV26TaxasPercentual3", StringUtil.LTrimStr( AV26TaxasPercentual3, 16, 4));
            }
            AV41DDO_TaxasCreatedAtAuxDateText = cgiGet( edtavDdo_taxascreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV41DDO_TaxasCreatedAtAuxDateText", AV41DDO_TaxasCreatedAtAuxDateText);
            AV46DDO_TaxasUpdatedAtAuxDateText = cgiGet( edtavDdo_taxasupdatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV46DDO_TaxasUpdatedAtAuxDateText", AV46DDO_TaxasUpdatedAtAuxDateText);
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL1"), ",", ".") != AV18TaxasPercentual1 )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL2"), ",", ".") != AV22TaxasPercentual2 )
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vTAXASPERCENTUAL3"), ",", ".") != AV26TaxasPercentual3 )
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
         E248T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E248T2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFTAXASUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_taxasupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFTAXASCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_taxascreatedatauxdatetext_Internalname});
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
         AV16DynamicFiltersSelector1 = "TAXASPERCENTUAL";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "TAXASPERCENTUAL";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "TAXASPERCENTUAL";
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
         Form.Caption = " Taxas";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV51DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV51DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E258T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV32ManageFiltersExecutionStep == 1 )
         {
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV32ManageFiltersExecutionStep == 2 )
         {
            AV32ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
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
         AV53GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV53GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV53GridCurrentPage), 10, 0));
         AV54GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV54GridPageCount", StringUtil.LTrimStr( (decimal)(AV54GridPageCount), 10, 0));
         GXt_char2 = AV55GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV61Pgmname, out  GXt_char2) ;
         AV55GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV55GridAppliedFilters", AV55GridAppliedFilters);
         AV62Taxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Taxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Taxaswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Taxaswwds_4_taxaspercentual1 = AV18TaxasPercentual1;
         AV66Taxaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Taxaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Taxaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Taxaswwds_8_taxaspercentual2 = AV22TaxasPercentual2;
         AV70Taxaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Taxaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Taxaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Taxaswwds_12_taxaspercentual3 = AV26TaxasPercentual3;
         AV74Taxaswwds_13_tftaxaspercentual = AV33TFTaxasPercentual;
         AV75Taxaswwds_14_tftaxaspercentual_to = AV34TFTaxasPercentual_To;
         AV76Taxaswwds_15_tftaxaspercentualanual = AV59TFTaxasPercentualAnual;
         AV77Taxaswwds_16_tftaxaspercentualanual_to = AV60TFTaxasPercentualAnual_To;
         AV78Taxaswwds_17_tftaxasvalorminimo = AV35TFTaxasValorMinimo;
         AV79Taxaswwds_18_tftaxasvalorminimo_to = AV36TFTaxasValorMinimo_To;
         AV80Taxaswwds_19_tftaxascreatedat = AV37TFTaxasCreatedAt;
         AV81Taxaswwds_20_tftaxascreatedat_to = AV38TFTaxasCreatedAt_To;
         AV82Taxaswwds_21_tftaxasupdatedat = AV42TFTaxasUpdatedAt;
         AV83Taxaswwds_22_tftaxasupdatedat_to = AV43TFTaxasUpdatedAt_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E128T2( )
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
            AV52PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV52PageToGo) ;
         }
      }

      protected void E138T2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E148T2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TaxasPercentual") == 0 )
            {
               AV33TFTaxasPercentual = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV33TFTaxasPercentual", StringUtil.LTrimStr( AV33TFTaxasPercentual, 16, 4));
               AV34TFTaxasPercentual_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV34TFTaxasPercentual_To", StringUtil.LTrimStr( AV34TFTaxasPercentual_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TaxasPercentualAnual") == 0 )
            {
               AV59TFTaxasPercentualAnual = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV59TFTaxasPercentualAnual", StringUtil.LTrimStr( AV59TFTaxasPercentualAnual, 16, 4));
               AV60TFTaxasPercentualAnual_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV60TFTaxasPercentualAnual_To", StringUtil.LTrimStr( AV60TFTaxasPercentualAnual_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TaxasValorMinimo") == 0 )
            {
               AV35TFTaxasValorMinimo = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV35TFTaxasValorMinimo", StringUtil.LTrimStr( AV35TFTaxasValorMinimo, 18, 2));
               AV36TFTaxasValorMinimo_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV36TFTaxasValorMinimo_To", StringUtil.LTrimStr( AV36TFTaxasValorMinimo_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TaxasCreatedAt") == 0 )
            {
               AV37TFTaxasCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV37TFTaxasCreatedAt", context.localUtil.TToC( AV37TFTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV38TFTaxasCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV38TFTaxasCreatedAt_To", context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV38TFTaxasCreatedAt_To) )
               {
                  AV38TFTaxasCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV38TFTaxasCreatedAt_To)), (short)(DateTimeUtil.Month( AV38TFTaxasCreatedAt_To)), (short)(DateTimeUtil.Day( AV38TFTaxasCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV38TFTaxasCreatedAt_To", context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TaxasUpdatedAt") == 0 )
            {
               AV42TFTaxasUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV42TFTaxasUpdatedAt", context.localUtil.TToC( AV42TFTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV43TFTaxasUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV43TFTaxasUpdatedAt_To", context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV43TFTaxasUpdatedAt_To) )
               {
                  AV43TFTaxasUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV43TFTaxasUpdatedAt_To)), (short)(DateTimeUtil.Month( AV43TFTaxasUpdatedAt_To)), (short)(DateTimeUtil.Day( AV43TFTaxasUpdatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV43TFTaxasUpdatedAt_To", context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E268T2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV56Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV56Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A863TaxasId,9,0));
         edtavDisplay_Link = formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV57Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A863TaxasId,9,0));
         edtavUpdate_Link = formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV58Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV58Delete);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A863TaxasId,9,0));
         edtavDelete_Link = formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A863TaxasId,9,0));
         edtTaxasPercentual_Link = formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 105;
         }
         sendrow_1052( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_105_Refreshing )
         {
            DoAjaxLoad(105, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E198T2( )
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

      protected void E158T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E208T2( )
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

      protected void E218T2( )
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

      protected void E168T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E228T2( )
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

      protected void E178T2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18TaxasPercentual1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22TaxasPercentual2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26TaxasPercentual3, AV32ManageFiltersExecutionStep, AV61Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFTaxasPercentual, AV34TFTaxasPercentual_To, AV59TFTaxasPercentualAnual, AV60TFTaxasPercentualAnual_To, AV35TFTaxasValorMinimo, AV36TFTaxasValorMinimo_To, AV37TFTaxasCreatedAt, AV38TFTaxasCreatedAt_To, AV42TFTaxasUpdatedAt, AV43TFTaxasUpdatedAt_To, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E238T2( )
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

      protected void E118T2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("TaxasWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV61Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("TaxasWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV31ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "TaxasWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV31ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV31ManageFiltersXml) ;
               AV10GridState.FromXml(AV31ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E188T2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "taxas"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("taxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
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
         edtavTaxaspercentual1_Visible = 0;
         AssignProp("", false, edtavTaxaspercentual1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TAXASPERCENTUAL") == 0 )
         {
            edtavTaxaspercentual1_Visible = 1;
            AssignProp("", false, edtavTaxaspercentual1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTaxaspercentual2_Visible = 0;
         AssignProp("", false, edtavTaxaspercentual2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TAXASPERCENTUAL") == 0 )
         {
            edtavTaxaspercentual2_Visible = 1;
            AssignProp("", false, edtavTaxaspercentual2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTaxaspercentual3_Visible = 0;
         AssignProp("", false, edtavTaxaspercentual3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TAXASPERCENTUAL") == 0 )
         {
            edtavTaxaspercentual3_Visible = 1;
            AssignProp("", false, edtavTaxaspercentual3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTaxaspercentual3_Visible), 5, 0), true);
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
         AV20DynamicFiltersSelector2 = "TAXASPERCENTUAL";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22TaxasPercentual2 = 0;
         AssignAttri("", false, "AV22TaxasPercentual2", StringUtil.LTrimStr( AV22TaxasPercentual2, 16, 4));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "TAXASPERCENTUAL";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26TaxasPercentual3 = 0;
         AssignAttri("", false, "AV26TaxasPercentual3", StringUtil.LTrimStr( AV26TaxasPercentual3, 16, 4));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV30ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "TaxasWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV30ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV33TFTaxasPercentual = 0;
         AssignAttri("", false, "AV33TFTaxasPercentual", StringUtil.LTrimStr( AV33TFTaxasPercentual, 16, 4));
         AV34TFTaxasPercentual_To = 0;
         AssignAttri("", false, "AV34TFTaxasPercentual_To", StringUtil.LTrimStr( AV34TFTaxasPercentual_To, 16, 4));
         AV59TFTaxasPercentualAnual = 0;
         AssignAttri("", false, "AV59TFTaxasPercentualAnual", StringUtil.LTrimStr( AV59TFTaxasPercentualAnual, 16, 4));
         AV60TFTaxasPercentualAnual_To = 0;
         AssignAttri("", false, "AV60TFTaxasPercentualAnual_To", StringUtil.LTrimStr( AV60TFTaxasPercentualAnual_To, 16, 4));
         AV35TFTaxasValorMinimo = 0;
         AssignAttri("", false, "AV35TFTaxasValorMinimo", StringUtil.LTrimStr( AV35TFTaxasValorMinimo, 18, 2));
         AV36TFTaxasValorMinimo_To = 0;
         AssignAttri("", false, "AV36TFTaxasValorMinimo_To", StringUtil.LTrimStr( AV36TFTaxasValorMinimo_To, 18, 2));
         AV37TFTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV37TFTaxasCreatedAt", context.localUtil.TToC( AV37TFTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AV38TFTaxasCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV38TFTaxasCreatedAt_To", context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
         AV42TFTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV42TFTaxasUpdatedAt", context.localUtil.TToC( AV42TFTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
         AV43TFTaxasUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV43TFTaxasUpdatedAt_To", context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 3, "/", ":", " "));
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "TAXASPERCENTUAL";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18TaxasPercentual1 = 0;
         AssignAttri("", false, "AV18TaxasPercentual1", StringUtil.LTrimStr( AV18TaxasPercentual1, 16, 4));
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
         if ( StringUtil.StrCmp(AV29Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV29Session.Get(AV61Pgmname+"GridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTAXASPERCENTUAL") == 0 )
            {
               AV33TFTaxasPercentual = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV33TFTaxasPercentual", StringUtil.LTrimStr( AV33TFTaxasPercentual, 16, 4));
               AV34TFTaxasPercentual_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV34TFTaxasPercentual_To", StringUtil.LTrimStr( AV34TFTaxasPercentual_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTAXASPERCENTUALANUAL") == 0 )
            {
               AV59TFTaxasPercentualAnual = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV59TFTaxasPercentualAnual", StringUtil.LTrimStr( AV59TFTaxasPercentualAnual, 16, 4));
               AV60TFTaxasPercentualAnual_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV60TFTaxasPercentualAnual_To", StringUtil.LTrimStr( AV60TFTaxasPercentualAnual_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTAXASVALORMINIMO") == 0 )
            {
               AV35TFTaxasValorMinimo = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV35TFTaxasValorMinimo", StringUtil.LTrimStr( AV35TFTaxasValorMinimo, 18, 2));
               AV36TFTaxasValorMinimo_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV36TFTaxasValorMinimo_To", StringUtil.LTrimStr( AV36TFTaxasValorMinimo_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTAXASCREATEDAT") == 0 )
            {
               AV37TFTaxasCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV37TFTaxasCreatedAt", context.localUtil.TToC( AV37TFTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV38TFTaxasCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV38TFTaxasCreatedAt_To", context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               AV39DDO_TaxasCreatedAtAuxDate = DateTimeUtil.ResetTime(AV37TFTaxasCreatedAt);
               AssignAttri("", false, "AV39DDO_TaxasCreatedAtAuxDate", context.localUtil.Format(AV39DDO_TaxasCreatedAtAuxDate, "99/99/9999"));
               AV40DDO_TaxasCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV38TFTaxasCreatedAt_To);
               AssignAttri("", false, "AV40DDO_TaxasCreatedAtAuxDateTo", context.localUtil.Format(AV40DDO_TaxasCreatedAtAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFTAXASUPDATEDAT") == 0 )
            {
               AV42TFTaxasUpdatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV42TFTaxasUpdatedAt", context.localUtil.TToC( AV42TFTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "));
               AV43TFTaxasUpdatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV43TFTaxasUpdatedAt_To", context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 3, "/", ":", " "));
               AV44DDO_TaxasUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV42TFTaxasUpdatedAt);
               AssignAttri("", false, "AV44DDO_TaxasUpdatedAtAuxDate", context.localUtil.Format(AV44DDO_TaxasUpdatedAtAuxDate, "99/99/9999"));
               AV45DDO_TaxasUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV43TFTaxasUpdatedAt_To);
               AssignAttri("", false, "AV45DDO_TaxasUpdatedAtAuxDateTo", context.localUtil.Format(AV45DDO_TaxasUpdatedAtAuxDateTo, "99/99/9999"));
            }
            AV84GXV1 = (int)(AV84GXV1+1);
         }
         Ddo_grid_Filteredtext_set = ((Convert.ToDecimal(0)==AV33TFTaxasPercentual) ? "" : StringUtil.Str( AV33TFTaxasPercentual, 16, 4))+"|"+((Convert.ToDecimal(0)==AV59TFTaxasPercentualAnual) ? "" : StringUtil.Str( AV59TFTaxasPercentualAnual, 16, 4))+"|"+((Convert.ToDecimal(0)==AV35TFTaxasValorMinimo) ? "" : StringUtil.Str( AV35TFTaxasValorMinimo, 18, 2))+"|"+((DateTime.MinValue==AV37TFTaxasCreatedAt) ? "" : context.localUtil.DToC( AV39DDO_TaxasCreatedAtAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV42TFTaxasUpdatedAt) ? "" : context.localUtil.DToC( AV44DDO_TaxasUpdatedAtAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((Convert.ToDecimal(0)==AV34TFTaxasPercentual_To) ? "" : StringUtil.Str( AV34TFTaxasPercentual_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV60TFTaxasPercentualAnual_To) ? "" : StringUtil.Str( AV60TFTaxasPercentualAnual_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV36TFTaxasValorMinimo_To) ? "" : StringUtil.Str( AV36TFTaxasValorMinimo_To, 18, 2))+"|"+((DateTime.MinValue==AV38TFTaxasCreatedAt_To) ? "" : context.localUtil.DToC( AV40DDO_TaxasCreatedAtAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV43TFTaxasUpdatedAt_To) ? "" : context.localUtil.DToC( AV45DDO_TaxasUpdatedAtAuxDateTo, 4, "/"));
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TAXASPERCENTUAL") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18TaxasPercentual1 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri("", false, "AV18TaxasPercentual1", StringUtil.LTrimStr( AV18TaxasPercentual1, 16, 4));
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
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TAXASPERCENTUAL") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22TaxasPercentual2 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri("", false, "AV22TaxasPercentual2", StringUtil.LTrimStr( AV22TaxasPercentual2, 16, 4));
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
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TAXASPERCENTUAL") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26TaxasPercentual3 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri("", false, "AV26TaxasPercentual3", StringUtil.LTrimStr( AV26TaxasPercentual3, 16, 4));
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
         AV10GridState.FromXml(AV29Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTAXASPERCENTUAL",  "Taxa de Administração",  !((Convert.ToDecimal(0)==AV33TFTaxasPercentual)&&(Convert.ToDecimal(0)==AV34TFTaxasPercentual_To)),  0,  StringUtil.Trim( StringUtil.Str( AV33TFTaxasPercentual, 16, 4)),  ((Convert.ToDecimal(0)==AV33TFTaxasPercentual) ? "" : StringUtil.Trim( context.localUtil.Format( AV33TFTaxasPercentual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV34TFTaxasPercentual_To, 16, 4)),  ((Convert.ToDecimal(0)==AV34TFTaxasPercentual_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFTaxasPercentual_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTAXASPERCENTUALANUAL",  "Taxa Anual",  !((Convert.ToDecimal(0)==AV59TFTaxasPercentualAnual)&&(Convert.ToDecimal(0)==AV60TFTaxasPercentualAnual_To)),  0,  StringUtil.Trim( StringUtil.Str( AV59TFTaxasPercentualAnual, 16, 4)),  ((Convert.ToDecimal(0)==AV59TFTaxasPercentualAnual) ? "" : StringUtil.Trim( context.localUtil.Format( AV59TFTaxasPercentualAnual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV60TFTaxasPercentualAnual_To, 16, 4)),  ((Convert.ToDecimal(0)==AV60TFTaxasPercentualAnual_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV60TFTaxasPercentualAnual_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTAXASVALORMINIMO",  "Valor Mínimo",  !((Convert.ToDecimal(0)==AV35TFTaxasValorMinimo)&&(Convert.ToDecimal(0)==AV36TFTaxasValorMinimo_To)),  0,  StringUtil.Trim( StringUtil.Str( AV35TFTaxasValorMinimo, 18, 2)),  ((Convert.ToDecimal(0)==AV35TFTaxasValorMinimo) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFTaxasValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV36TFTaxasValorMinimo_To, 18, 2)),  ((Convert.ToDecimal(0)==AV36TFTaxasValorMinimo_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFTaxasValorMinimo_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTAXASCREATEDAT",  "Criado em",  !((DateTime.MinValue==AV37TFTaxasCreatedAt)&&(DateTime.MinValue==AV38TFTaxasCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV37TFTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV37TFTaxasCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFTaxasCreatedAt, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV38TFTaxasCreatedAt_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV38TFTaxasCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFTaxasCreatedAt_To, "99/99/9999 99:99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFTAXASUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV42TFTaxasUpdatedAt)&&(DateTime.MinValue==AV43TFTaxasUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV42TFTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV42TFTaxasUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFTaxasUpdatedAt, "99/99/9999 99:99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV43TFTaxasUpdatedAt_To, 10, 8, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV43TFTaxasUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFTaxasUpdatedAt_To, "99/99/9999 99:99:99")))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "TAXASPERCENTUAL") == 0 ) && ! (Convert.ToDecimal(0)==AV18TaxasPercentual1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Percentual",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV18TaxasPercentual1, 16, 4)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV18TaxasPercentual1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV18TaxasPercentual1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV18TaxasPercentual1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TAXASPERCENTUAL") == 0 ) && ! (Convert.ToDecimal(0)==AV22TaxasPercentual2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Percentual",  AV21DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV22TaxasPercentual2, 16, 4)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV22TaxasPercentual2, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV22TaxasPercentual2, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV22TaxasPercentual2, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TAXASPERCENTUAL") == 0 ) && ! (Convert.ToDecimal(0)==AV26TaxasPercentual3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Percentual",  AV25DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV26TaxasPercentual3, 16, 4)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV26TaxasPercentual3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV26TaxasPercentual3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV26TaxasPercentual3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")), "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV61Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Taxas";
         AV29Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_87_8T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_taxaspercentual3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTaxaspercentual3_Internalname, "Taxas Percentual3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTaxaspercentual3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV26TaxasPercentual3, 21, 4, ",", "")), StringUtil.LTrim( ((edtavTaxaspercentual3_Enabled!=0) ? context.localUtil.Format( AV26TaxasPercentual3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV26TaxasPercentual3, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTaxaspercentual3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTaxaspercentual3_Visible, edtavTaxaspercentual3_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_87_8T2e( true) ;
         }
         else
         {
            wb_table3_87_8T2e( false) ;
         }
      }

      protected void wb_table2_65_8T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_taxaspercentual2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTaxaspercentual2_Internalname, "Taxas Percentual2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTaxaspercentual2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV22TaxasPercentual2, 21, 4, ",", "")), StringUtil.LTrim( ((edtavTaxaspercentual2_Enabled!=0) ? context.localUtil.Format( AV22TaxasPercentual2, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV22TaxasPercentual2, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTaxaspercentual2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTaxaspercentual2_Visible, edtavTaxaspercentual2_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_65_8T2e( true) ;
         }
         else
         {
            wb_table2_65_8T2e( false) ;
         }
      }

      protected void wb_table1_43_8T2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_TaxasWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_taxaspercentual1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTaxaspercentual1_Internalname, "Taxas Percentual1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTaxaspercentual1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18TaxasPercentual1, 21, 4, ",", "")), StringUtil.LTrim( ((edtavTaxaspercentual1_Enabled!=0) ? context.localUtil.Format( AV18TaxasPercentual1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( AV18TaxasPercentual1, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTaxaspercentual1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTaxaspercentual1_Visible, edtavTaxaspercentual1_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_8T2e( true) ;
         }
         else
         {
            wb_table1_43_8T2e( false) ;
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
         PA8T2( ) ;
         WS8T2( ) ;
         WE8T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019274616", true, true);
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
         context.AddJavascriptSource("taxasww.js", "?202561019274617", false, true);
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

      protected void SubsflControlProps_1052( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_105_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_105_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_105_idx;
         edtTaxasId_Internalname = "TAXASID_"+sGXsfl_105_idx;
         edtTaxasPercentual_Internalname = "TAXASPERCENTUAL_"+sGXsfl_105_idx;
         edtTaxasPercentualAnual_Internalname = "TAXASPERCENTUALANUAL_"+sGXsfl_105_idx;
         edtTaxasValorMinimo_Internalname = "TAXASVALORMINIMO_"+sGXsfl_105_idx;
         edtTaxasCreatedAt_Internalname = "TAXASCREATEDAT_"+sGXsfl_105_idx;
         edtTaxasUpdatedAt_Internalname = "TAXASUPDATEDAT_"+sGXsfl_105_idx;
      }

      protected void SubsflControlProps_fel_1052( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_105_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_105_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_105_fel_idx;
         edtTaxasId_Internalname = "TAXASID_"+sGXsfl_105_fel_idx;
         edtTaxasPercentual_Internalname = "TAXASPERCENTUAL_"+sGXsfl_105_fel_idx;
         edtTaxasPercentualAnual_Internalname = "TAXASPERCENTUALANUAL_"+sGXsfl_105_fel_idx;
         edtTaxasValorMinimo_Internalname = "TAXASVALORMINIMO_"+sGXsfl_105_fel_idx;
         edtTaxasCreatedAt_Internalname = "TAXASCREATEDAT_"+sGXsfl_105_fel_idx;
         edtTaxasUpdatedAt_Internalname = "TAXASUPDATEDAT_"+sGXsfl_105_fel_idx;
      }

      protected void sendrow_1052( )
      {
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         WB8T0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_105_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_105_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_105_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_105_idx + "',105)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV56Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_105_idx + "',105)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV57Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_105_idx + "',105)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV58Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A863TaxasId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A863TaxasId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTaxasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasPercentual_Internalname,StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A864TaxasPercentual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTaxasPercentual_Link,(string)"",(string)"",(string)"",(string)edtTaxasPercentual_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasPercentualAnual_Internalname,StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A894TaxasPercentualAnual, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTaxasPercentualAnual_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasValorMinimo_Internalname,StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A865TaxasValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTaxasValorMinimo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasCreatedAt_Internalname,context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A866TaxasCreatedAt, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTaxasCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTaxasUpdatedAt_Internalname,context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A867TaxasUpdatedAt, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTaxasUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes8T2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
         }
         /* End function sendrow_1052 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TAXASPERCENTUAL", "Percentual", 0);
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
         cmbavDynamicfiltersselector2.addItem("TAXASPERCENTUAL", "Percentual", 0);
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
         cmbavDynamicfiltersselector3.addItem("TAXASPERCENTUAL", "Percentual", 0);
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
         /* End function init_web_controls */
      }

      protected void StartGridControl105( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"105\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa de Administração") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa Anual") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor Mínimo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado em") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV56Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV57Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A863TaxasId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A864TaxasPercentual, 21, 4, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTaxasPercentual_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A894TaxasPercentualAnual, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A865TaxasValorMinimo, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A866TaxasCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A867TaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
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
         edtavTaxaspercentual1_Internalname = "vTAXASPERCENTUAL1";
         cellFilter_taxaspercentual1_cell_Internalname = "FILTER_TAXASPERCENTUAL1_CELL";
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
         edtavTaxaspercentual2_Internalname = "vTAXASPERCENTUAL2";
         cellFilter_taxaspercentual2_cell_Internalname = "FILTER_TAXASPERCENTUAL2_CELL";
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
         edtavTaxaspercentual3_Internalname = "vTAXASPERCENTUAL3";
         cellFilter_taxaspercentual3_cell_Internalname = "FILTER_TAXASPERCENTUAL3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtTaxasId_Internalname = "TAXASID";
         edtTaxasPercentual_Internalname = "TAXASPERCENTUAL";
         edtTaxasPercentualAnual_Internalname = "TAXASPERCENTUALANUAL";
         edtTaxasValorMinimo_Internalname = "TAXASVALORMINIMO";
         edtTaxasCreatedAt_Internalname = "TAXASCREATEDAT";
         edtTaxasUpdatedAt_Internalname = "TAXASUPDATEDAT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_taxascreatedatauxdatetext_Internalname = "vDDO_TAXASCREATEDATAUXDATETEXT";
         Tftaxascreatedat_rangepicker_Internalname = "TFTAXASCREATEDAT_RANGEPICKER";
         divDdo_taxascreatedatauxdates_Internalname = "DDO_TAXASCREATEDATAUXDATES";
         edtavDdo_taxasupdatedatauxdatetext_Internalname = "vDDO_TAXASUPDATEDATAUXDATETEXT";
         Tftaxasupdatedat_rangepicker_Internalname = "TFTAXASUPDATEDAT_RANGEPICKER";
         divDdo_taxasupdatedatauxdates_Internalname = "DDO_TAXASUPDATEDATAUXDATES";
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
         edtTaxasUpdatedAt_Jsonclick = "";
         edtTaxasCreatedAt_Jsonclick = "";
         edtTaxasValorMinimo_Jsonclick = "";
         edtTaxasPercentualAnual_Jsonclick = "";
         edtTaxasPercentual_Jsonclick = "";
         edtTaxasPercentual_Link = "";
         edtTaxasId_Jsonclick = "";
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
         edtavTaxaspercentual1_Jsonclick = "";
         edtavTaxaspercentual1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTaxaspercentual2_Jsonclick = "";
         edtavTaxaspercentual2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTaxaspercentual3_Jsonclick = "";
         edtavTaxaspercentual3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTaxaspercentual3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTaxaspercentual2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTaxaspercentual1_Visible = 1;
         edtTaxasUpdatedAt_Enabled = 0;
         edtTaxasCreatedAt_Enabled = 0;
         edtTaxasValorMinimo_Enabled = 0;
         edtTaxasPercentualAnual_Enabled = 0;
         edtTaxasPercentual_Enabled = 0;
         edtTaxasId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_taxasupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_taxascreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "16.2|16.2|18.2||";
         Ddo_grid_Filterisrange = "T|T|T|P|P";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric|Date|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "4:TaxasPercentual|5:TaxasPercentualAnual|6:TaxasValorMinimo|7:TaxasCreatedAt|8:TaxasUpdatedAt";
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
         Form.Caption = " Taxas";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E128T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E138T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E148T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E268T2","iparms":[{"av":"A863TaxasId","fld":"TAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV56Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV57Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV58Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtTaxasPercentual_Link","ctrl":"TAXASPERCENTUAL","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E198T2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E158T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTaxaspercentual2_Visible","ctrl":"vTAXASPERCENTUAL2","prop":"Visible"},{"av":"edtavTaxaspercentual3_Visible","ctrl":"vTAXASPERCENTUAL3","prop":"Visible"},{"av":"edtavTaxaspercentual1_Visible","ctrl":"vTAXASPERCENTUAL1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E208T2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavTaxaspercentual1_Visible","ctrl":"vTAXASPERCENTUAL1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E218T2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E168T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTaxaspercentual2_Visible","ctrl":"vTAXASPERCENTUAL2","prop":"Visible"},{"av":"edtavTaxaspercentual3_Visible","ctrl":"vTAXASPERCENTUAL3","prop":"Visible"},{"av":"edtavTaxaspercentual1_Visible","ctrl":"vTAXASPERCENTUAL1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E228T2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavTaxaspercentual2_Visible","ctrl":"vTAXASPERCENTUAL2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E178T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTaxaspercentual2_Visible","ctrl":"vTAXASPERCENTUAL2","prop":"Visible"},{"av":"edtavTaxaspercentual3_Visible","ctrl":"vTAXASPERCENTUAL3","prop":"Visible"},{"av":"edtavTaxaspercentual1_Visible","ctrl":"vTAXASPERCENTUAL1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E238T2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavTaxaspercentual3_Visible","ctrl":"vTAXASPERCENTUAL3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E118T2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV39DDO_TaxasCreatedAtAuxDate","fld":"vDDO_TAXASCREATEDATAUXDATE","type":"date"},{"av":"AV44DDO_TaxasUpdatedAtAuxDate","fld":"vDDO_TAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV40DDO_TaxasCreatedAtAuxDateTo","fld":"vDDO_TAXASCREATEDATAUXDATETO","type":"date"},{"av":"AV45DDO_TaxasUpdatedAtAuxDateTo","fld":"vDDO_TAXASUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV33TFTaxasPercentual","fld":"vTFTAXASPERCENTUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFTaxasPercentual_To","fld":"vTFTAXASPERCENTUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV59TFTaxasPercentualAnual","fld":"vTFTAXASPERCENTUALANUAL","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV60TFTaxasPercentualAnual_To","fld":"vTFTAXASPERCENTUALANUAL_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFTaxasValorMinimo","fld":"vTFTAXASVALORMINIMO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV36TFTaxasValorMinimo_To","fld":"vTFTAXASVALORMINIMO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV37TFTaxasCreatedAt","fld":"vTFTAXASCREATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV38TFTaxasCreatedAt_To","fld":"vTFTAXASCREATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV42TFTaxasUpdatedAt","fld":"vTFTAXASUPDATEDAT","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"AV43TFTaxasUpdatedAt_To","fld":"vTFTAXASUPDATEDAT_TO","pic":"99/99/9999 99:99:99","type":"dtime"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18TaxasPercentual1","fld":"vTAXASPERCENTUAL1","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV44DDO_TaxasUpdatedAtAuxDate","fld":"vDDO_TAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV45DDO_TaxasUpdatedAtAuxDateTo","fld":"vDDO_TAXASUPDATEDATAUXDATETO","type":"date"},{"av":"AV39DDO_TaxasCreatedAtAuxDate","fld":"vDDO_TAXASCREATEDATAUXDATE","type":"date"},{"av":"AV40DDO_TaxasCreatedAtAuxDateTo","fld":"vDDO_TAXASCREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22TaxasPercentual2","fld":"vTAXASPERCENTUAL2","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26TaxasPercentual3","fld":"vTAXASPERCENTUAL3","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"edtavTaxaspercentual1_Visible","ctrl":"vTAXASPERCENTUAL1","prop":"Visible"},{"av":"edtavTaxaspercentual2_Visible","ctrl":"vTAXASPERCENTUAL2","prop":"Visible"},{"av":"edtavTaxaspercentual3_Visible","ctrl":"vTAXASPERCENTUAL3","prop":"Visible"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E188T2","iparms":[{"av":"A863TaxasId","fld":"TAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Taxasupdatedat","iparms":[]}""");
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
         AV20DynamicFiltersSelector2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV61Pgmname = "";
         AV37TFTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         AV38TFTaxasCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV42TFTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AV43TFTaxasUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV30ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55GridAppliedFilters = "";
         AV51DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV39DDO_TaxasCreatedAtAuxDate = DateTime.MinValue;
         AV40DDO_TaxasCreatedAtAuxDateTo = DateTime.MinValue;
         AV44DDO_TaxasUpdatedAtAuxDate = DateTime.MinValue;
         AV45DDO_TaxasUpdatedAtAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         AV41DDO_TaxasCreatedAtAuxDateText = "";
         ucTftaxascreatedat_rangepicker = new GXUserControl();
         AV46DDO_TaxasUpdatedAtAuxDateText = "";
         ucTftaxasupdatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV56Display = "";
         AV57Update = "";
         AV58Delete = "";
         A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         lV62Taxaswwds_1_filterfulltext = "";
         AV62Taxaswwds_1_filterfulltext = "";
         AV63Taxaswwds_2_dynamicfiltersselector1 = "";
         AV67Taxaswwds_6_dynamicfiltersselector2 = "";
         AV71Taxaswwds_10_dynamicfiltersselector3 = "";
         AV80Taxaswwds_19_tftaxascreatedat = (DateTime)(DateTime.MinValue);
         AV81Taxaswwds_20_tftaxascreatedat_to = (DateTime)(DateTime.MinValue);
         AV82Taxaswwds_21_tftaxasupdatedat = (DateTime)(DateTime.MinValue);
         AV83Taxaswwds_22_tftaxasupdatedat_to = (DateTime)(DateTime.MinValue);
         H008T2_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H008T2_n867TaxasUpdatedAt = new bool[] {false} ;
         H008T2_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H008T2_n866TaxasCreatedAt = new bool[] {false} ;
         H008T2_A865TaxasValorMinimo = new decimal[1] ;
         H008T2_n865TaxasValorMinimo = new bool[] {false} ;
         H008T2_A894TaxasPercentualAnual = new decimal[1] ;
         H008T2_n894TaxasPercentualAnual = new bool[] {false} ;
         H008T2_A864TaxasPercentual = new decimal[1] ;
         H008T2_n864TaxasPercentual = new bool[] {false} ;
         H008T2_A863TaxasId = new int[1] ;
         H008T3_AGRID_nRecordCount = new long[1] ;
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
         AV31ManageFiltersXml = "";
         GXt_char2 = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV29Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.taxasww__default(),
            new Object[][] {
                new Object[] {
               H008T2_A867TaxasUpdatedAt, H008T2_n867TaxasUpdatedAt, H008T2_A866TaxasCreatedAt, H008T2_n866TaxasCreatedAt, H008T2_A865TaxasValorMinimo, H008T2_n865TaxasValorMinimo, H008T2_A894TaxasPercentualAnual, H008T2_n894TaxasPercentualAnual, H008T2_A864TaxasPercentual, H008T2_n864TaxasPercentual,
               H008T2_A863TaxasId
               }
               , new Object[] {
               H008T3_AGRID_nRecordCount
               }
            }
         );
         AV61Pgmname = "TaxasWW";
         /* GeneXus formulas. */
         AV61Pgmname = "TaxasWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV32ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV64Taxaswwds_3_dynamicfiltersoperator1 ;
      private short AV68Taxaswwds_7_dynamicfiltersoperator2 ;
      private short AV72Taxaswwds_11_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_105 ;
      private int nGXsfl_105_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A863TaxasId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtTaxasId_Enabled ;
      private int edtTaxasPercentual_Enabled ;
      private int edtTaxasPercentualAnual_Enabled ;
      private int edtTaxasValorMinimo_Enabled ;
      private int edtTaxasCreatedAt_Enabled ;
      private int edtTaxasUpdatedAt_Enabled ;
      private int AV52PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTaxaspercentual1_Visible ;
      private int edtavTaxaspercentual2_Visible ;
      private int edtavTaxaspercentual3_Visible ;
      private int AV84GXV1 ;
      private int edtavTaxaspercentual3_Enabled ;
      private int edtavTaxaspercentual2_Enabled ;
      private int edtavTaxaspercentual1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV53GridCurrentPage ;
      private long AV54GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV18TaxasPercentual1 ;
      private decimal AV22TaxasPercentual2 ;
      private decimal AV26TaxasPercentual3 ;
      private decimal AV33TFTaxasPercentual ;
      private decimal AV34TFTaxasPercentual_To ;
      private decimal AV59TFTaxasPercentualAnual ;
      private decimal AV60TFTaxasPercentualAnual_To ;
      private decimal AV35TFTaxasValorMinimo ;
      private decimal AV36TFTaxasValorMinimo_To ;
      private decimal A864TaxasPercentual ;
      private decimal A894TaxasPercentualAnual ;
      private decimal A865TaxasValorMinimo ;
      private decimal AV65Taxaswwds_4_taxaspercentual1 ;
      private decimal AV69Taxaswwds_8_taxaspercentual2 ;
      private decimal AV73Taxaswwds_12_taxaspercentual3 ;
      private decimal AV74Taxaswwds_13_tftaxaspercentual ;
      private decimal AV75Taxaswwds_14_tftaxaspercentual_to ;
      private decimal AV76Taxaswwds_15_tftaxaspercentualanual ;
      private decimal AV77Taxaswwds_16_tftaxaspercentualanual_to ;
      private decimal AV78Taxaswwds_17_tftaxasvalorminimo ;
      private decimal AV79Taxaswwds_18_tftaxasvalorminimo_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_105_idx="0001" ;
      private string AV61Pgmname ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Format ;
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
      private string divDdo_taxascreatedatauxdates_Internalname ;
      private string edtavDdo_taxascreatedatauxdatetext_Internalname ;
      private string edtavDdo_taxascreatedatauxdatetext_Jsonclick ;
      private string Tftaxascreatedat_rangepicker_Internalname ;
      private string divDdo_taxasupdatedatauxdates_Internalname ;
      private string edtavDdo_taxasupdatedatauxdatetext_Internalname ;
      private string edtavDdo_taxasupdatedatauxdatetext_Jsonclick ;
      private string Tftaxasupdatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV56Display ;
      private string edtavDisplay_Internalname ;
      private string AV57Update ;
      private string edtavUpdate_Internalname ;
      private string AV58Delete ;
      private string edtavDelete_Internalname ;
      private string edtTaxasId_Internalname ;
      private string edtTaxasPercentual_Internalname ;
      private string edtTaxasPercentualAnual_Internalname ;
      private string edtTaxasValorMinimo_Internalname ;
      private string edtTaxasCreatedAt_Internalname ;
      private string edtTaxasUpdatedAt_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTaxaspercentual1_Internalname ;
      private string edtavTaxaspercentual2_Internalname ;
      private string edtavTaxaspercentual3_Internalname ;
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
      private string edtTaxasPercentual_Link ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_taxaspercentual3_cell_Internalname ;
      private string edtavTaxaspercentual3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_taxaspercentual2_cell_Internalname ;
      private string edtavTaxaspercentual2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_taxaspercentual1_cell_Internalname ;
      private string edtavTaxaspercentual1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_105_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtTaxasId_Jsonclick ;
      private string edtTaxasPercentual_Jsonclick ;
      private string edtTaxasPercentualAnual_Jsonclick ;
      private string edtTaxasValorMinimo_Jsonclick ;
      private string edtTaxasCreatedAt_Jsonclick ;
      private string edtTaxasUpdatedAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV37TFTaxasCreatedAt ;
      private DateTime AV38TFTaxasCreatedAt_To ;
      private DateTime AV42TFTaxasUpdatedAt ;
      private DateTime AV43TFTaxasUpdatedAt_To ;
      private DateTime A866TaxasCreatedAt ;
      private DateTime A867TaxasUpdatedAt ;
      private DateTime AV80Taxaswwds_19_tftaxascreatedat ;
      private DateTime AV81Taxaswwds_20_tftaxascreatedat_to ;
      private DateTime AV82Taxaswwds_21_tftaxasupdatedat ;
      private DateTime AV83Taxaswwds_22_tftaxasupdatedat_to ;
      private DateTime AV39DDO_TaxasCreatedAtAuxDate ;
      private DateTime AV40DDO_TaxasCreatedAtAuxDateTo ;
      private DateTime AV44DDO_TaxasUpdatedAtAuxDate ;
      private DateTime AV45DDO_TaxasUpdatedAtAuxDateTo ;
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
      private bool n864TaxasPercentual ;
      private bool n894TaxasPercentualAnual ;
      private bool n865TaxasValorMinimo ;
      private bool n866TaxasCreatedAt ;
      private bool n867TaxasUpdatedAt ;
      private bool bGXsfl_105_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV66Taxaswwds_5_dynamicfiltersenabled2 ;
      private bool AV70Taxaswwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV31ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV55GridAppliedFilters ;
      private string AV41DDO_TaxasCreatedAtAuxDateText ;
      private string AV46DDO_TaxasUpdatedAtAuxDateText ;
      private string lV62Taxaswwds_1_filterfulltext ;
      private string AV62Taxaswwds_1_filterfulltext ;
      private string AV63Taxaswwds_2_dynamicfiltersselector1 ;
      private string AV67Taxaswwds_6_dynamicfiltersselector2 ;
      private string AV71Taxaswwds_10_dynamicfiltersselector3 ;
      private IGxSession AV29Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftaxascreatedat_rangepicker ;
      private GXUserControl ucTftaxasupdatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV30ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H008T2_A867TaxasUpdatedAt ;
      private bool[] H008T2_n867TaxasUpdatedAt ;
      private DateTime[] H008T2_A866TaxasCreatedAt ;
      private bool[] H008T2_n866TaxasCreatedAt ;
      private decimal[] H008T2_A865TaxasValorMinimo ;
      private bool[] H008T2_n865TaxasValorMinimo ;
      private decimal[] H008T2_A894TaxasPercentualAnual ;
      private bool[] H008T2_n894TaxasPercentualAnual ;
      private decimal[] H008T2_A864TaxasPercentual ;
      private bool[] H008T2_n864TaxasPercentual ;
      private int[] H008T2_A863TaxasId ;
      private long[] H008T3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class taxasww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H008T2( IGxContext context ,
                                             string AV62Taxaswwds_1_filterfulltext ,
                                             string AV63Taxaswwds_2_dynamicfiltersselector1 ,
                                             short AV64Taxaswwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Taxaswwds_4_taxaspercentual1 ,
                                             bool AV66Taxaswwds_5_dynamicfiltersenabled2 ,
                                             string AV67Taxaswwds_6_dynamicfiltersselector2 ,
                                             short AV68Taxaswwds_7_dynamicfiltersoperator2 ,
                                             decimal AV69Taxaswwds_8_taxaspercentual2 ,
                                             bool AV70Taxaswwds_9_dynamicfiltersenabled3 ,
                                             string AV71Taxaswwds_10_dynamicfiltersselector3 ,
                                             short AV72Taxaswwds_11_dynamicfiltersoperator3 ,
                                             decimal AV73Taxaswwds_12_taxaspercentual3 ,
                                             decimal AV74Taxaswwds_13_tftaxaspercentual ,
                                             decimal AV75Taxaswwds_14_tftaxaspercentual_to ,
                                             decimal AV76Taxaswwds_15_tftaxaspercentualanual ,
                                             decimal AV77Taxaswwds_16_tftaxaspercentualanual_to ,
                                             decimal AV78Taxaswwds_17_tftaxasvalorminimo ,
                                             decimal AV79Taxaswwds_18_tftaxasvalorminimo_to ,
                                             DateTime AV80Taxaswwds_19_tftaxascreatedat ,
                                             DateTime AV81Taxaswwds_20_tftaxascreatedat_to ,
                                             DateTime AV82Taxaswwds_21_tftaxasupdatedat ,
                                             DateTime AV83Taxaswwds_22_tftaxasupdatedat_to ,
                                             decimal A864TaxasPercentual ,
                                             decimal A894TaxasPercentualAnual ,
                                             decimal A865TaxasValorMinimo ,
                                             DateTime A866TaxasCreatedAt ,
                                             DateTime A867TaxasUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[25];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " TaxasUpdatedAt, TaxasCreatedAt, TaxasValorMinimo, TaxasPercentualAnual, TaxasPercentual, TaxasId";
         sFromString = " FROM Taxas";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TaxasPercentual,'99999999990.9999'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(TaxasPercentualAnual,'99999999990.9999'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(TaxasValorMinimo,'999999999999990.99'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Taxaswwds_13_tftaxaspercentual) )
         {
            AddWhere(sWhereString, "(TaxasPercentual >= :AV74Taxaswwds_13_tftaxaspercentual)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Taxaswwds_14_tftaxaspercentual_to) )
         {
            AddWhere(sWhereString, "(TaxasPercentual <= :AV75Taxaswwds_14_tftaxaspercentual_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Taxaswwds_15_tftaxaspercentualanual) )
         {
            AddWhere(sWhereString, "(TaxasPercentualAnual >= :AV76Taxaswwds_15_tftaxaspercentualanual)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Taxaswwds_16_tftaxaspercentualanual_to) )
         {
            AddWhere(sWhereString, "(TaxasPercentualAnual <= :AV77Taxaswwds_16_tftaxaspercentualanual_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Taxaswwds_17_tftaxasvalorminimo) )
         {
            AddWhere(sWhereString, "(TaxasValorMinimo >= :AV78Taxaswwds_17_tftaxasvalorminimo)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Taxaswwds_18_tftaxasvalorminimo_to) )
         {
            AddWhere(sWhereString, "(TaxasValorMinimo <= :AV79Taxaswwds_18_tftaxasvalorminimo_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Taxaswwds_19_tftaxascreatedat) )
         {
            AddWhere(sWhereString, "(TaxasCreatedAt >= :AV80Taxaswwds_19_tftaxascreatedat)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Taxaswwds_20_tftaxascreatedat_to) )
         {
            AddWhere(sWhereString, "(TaxasCreatedAt <= :AV81Taxaswwds_20_tftaxascreatedat_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Taxaswwds_21_tftaxasupdatedat) )
         {
            AddWhere(sWhereString, "(TaxasUpdatedAt >= :AV82Taxaswwds_21_tftaxasupdatedat)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Taxaswwds_22_tftaxasupdatedat_to) )
         {
            AddWhere(sWhereString, "(TaxasUpdatedAt <= :AV83Taxaswwds_22_tftaxasupdatedat_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY TaxasPercentual, TaxasId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY TaxasPercentual DESC, TaxasId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY TaxasPercentualAnual, TaxasId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY TaxasPercentualAnual DESC, TaxasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY TaxasValorMinimo, TaxasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY TaxasValorMinimo DESC, TaxasId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY TaxasCreatedAt, TaxasId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY TaxasCreatedAt DESC, TaxasId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY TaxasUpdatedAt, TaxasId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY TaxasUpdatedAt DESC, TaxasId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY TaxasId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H008T3( IGxContext context ,
                                             string AV62Taxaswwds_1_filterfulltext ,
                                             string AV63Taxaswwds_2_dynamicfiltersselector1 ,
                                             short AV64Taxaswwds_3_dynamicfiltersoperator1 ,
                                             decimal AV65Taxaswwds_4_taxaspercentual1 ,
                                             bool AV66Taxaswwds_5_dynamicfiltersenabled2 ,
                                             string AV67Taxaswwds_6_dynamicfiltersselector2 ,
                                             short AV68Taxaswwds_7_dynamicfiltersoperator2 ,
                                             decimal AV69Taxaswwds_8_taxaspercentual2 ,
                                             bool AV70Taxaswwds_9_dynamicfiltersenabled3 ,
                                             string AV71Taxaswwds_10_dynamicfiltersselector3 ,
                                             short AV72Taxaswwds_11_dynamicfiltersoperator3 ,
                                             decimal AV73Taxaswwds_12_taxaspercentual3 ,
                                             decimal AV74Taxaswwds_13_tftaxaspercentual ,
                                             decimal AV75Taxaswwds_14_tftaxaspercentual_to ,
                                             decimal AV76Taxaswwds_15_tftaxaspercentualanual ,
                                             decimal AV77Taxaswwds_16_tftaxaspercentualanual_to ,
                                             decimal AV78Taxaswwds_17_tftaxasvalorminimo ,
                                             decimal AV79Taxaswwds_18_tftaxasvalorminimo_to ,
                                             DateTime AV80Taxaswwds_19_tftaxascreatedat ,
                                             DateTime AV81Taxaswwds_20_tftaxascreatedat_to ,
                                             DateTime AV82Taxaswwds_21_tftaxasupdatedat ,
                                             DateTime AV83Taxaswwds_22_tftaxasupdatedat_to ,
                                             decimal A864TaxasPercentual ,
                                             decimal A894TaxasPercentualAnual ,
                                             decimal A865TaxasValorMinimo ,
                                             DateTime A866TaxasCreatedAt ,
                                             DateTime A867TaxasUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[22];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM Taxas";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Taxaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(TaxasPercentual,'99999999990.9999'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(TaxasPercentualAnual,'99999999990.9999'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(TaxasValorMinimo,'999999999999990.99'), 2) like '%' || :lV62Taxaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Taxaswwds_2_dynamicfiltersselector1, "TAXASPERCENTUAL") == 0 ) && ( AV64Taxaswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV65Taxaswwds_4_taxaspercentual1) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV65Taxaswwds_4_taxaspercentual1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV66Taxaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Taxaswwds_6_dynamicfiltersselector2, "TAXASPERCENTUAL") == 0 ) && ( AV68Taxaswwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV69Taxaswwds_8_taxaspercentual2) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV69Taxaswwds_8_taxaspercentual2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual < :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual = :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV70Taxaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Taxaswwds_10_dynamicfiltersselector3, "TAXASPERCENTUAL") == 0 ) && ( AV72Taxaswwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV73Taxaswwds_12_taxaspercentual3) ) )
         {
            AddWhere(sWhereString, "(TaxasPercentual > :AV73Taxaswwds_12_taxaspercentual3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Taxaswwds_13_tftaxaspercentual) )
         {
            AddWhere(sWhereString, "(TaxasPercentual >= :AV74Taxaswwds_13_tftaxaspercentual)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Taxaswwds_14_tftaxaspercentual_to) )
         {
            AddWhere(sWhereString, "(TaxasPercentual <= :AV75Taxaswwds_14_tftaxaspercentual_to)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Taxaswwds_15_tftaxaspercentualanual) )
         {
            AddWhere(sWhereString, "(TaxasPercentualAnual >= :AV76Taxaswwds_15_tftaxaspercentualanual)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Taxaswwds_16_tftaxaspercentualanual_to) )
         {
            AddWhere(sWhereString, "(TaxasPercentualAnual <= :AV77Taxaswwds_16_tftaxaspercentualanual_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Taxaswwds_17_tftaxasvalorminimo) )
         {
            AddWhere(sWhereString, "(TaxasValorMinimo >= :AV78Taxaswwds_17_tftaxasvalorminimo)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Taxaswwds_18_tftaxasvalorminimo_to) )
         {
            AddWhere(sWhereString, "(TaxasValorMinimo <= :AV79Taxaswwds_18_tftaxasvalorminimo_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Taxaswwds_19_tftaxascreatedat) )
         {
            AddWhere(sWhereString, "(TaxasCreatedAt >= :AV80Taxaswwds_19_tftaxascreatedat)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Taxaswwds_20_tftaxascreatedat_to) )
         {
            AddWhere(sWhereString, "(TaxasCreatedAt <= :AV81Taxaswwds_20_tftaxascreatedat_to)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Taxaswwds_21_tftaxasupdatedat) )
         {
            AddWhere(sWhereString, "(TaxasUpdatedAt >= :AV82Taxaswwds_21_tftaxasupdatedat)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Taxaswwds_22_tftaxasupdatedat_to) )
         {
            AddWhere(sWhereString, "(TaxasUpdatedAt <= :AV83Taxaswwds_22_tftaxasupdatedat_to)");
         }
         else
         {
            GXv_int6[21] = 1;
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
                     return conditional_H008T2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
               case 1 :
                     return conditional_H008T3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmH008T2;
          prmH008T2 = new Object[] {
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV74Taxaswwds_13_tftaxaspercentual",GXType.Number,16,4) ,
          new ParDef("AV75Taxaswwds_14_tftaxaspercentual_to",GXType.Number,16,4) ,
          new ParDef("AV76Taxaswwds_15_tftaxaspercentualanual",GXType.Number,16,4) ,
          new ParDef("AV77Taxaswwds_16_tftaxaspercentualanual_to",GXType.Number,16,4) ,
          new ParDef("AV78Taxaswwds_17_tftaxasvalorminimo",GXType.Number,18,2) ,
          new ParDef("AV79Taxaswwds_18_tftaxasvalorminimo_to",GXType.Number,18,2) ,
          new ParDef("AV80Taxaswwds_19_tftaxascreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV81Taxaswwds_20_tftaxascreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV82Taxaswwds_21_tftaxasupdatedat",GXType.DateTime,10,8) ,
          new ParDef("AV83Taxaswwds_22_tftaxasupdatedat_to",GXType.DateTime,10,8) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH008T3;
          prmH008T3 = new Object[] {
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Taxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV65Taxaswwds_4_taxaspercentual1",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV69Taxaswwds_8_taxaspercentual2",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV73Taxaswwds_12_taxaspercentual3",GXType.Number,16,4) ,
          new ParDef("AV74Taxaswwds_13_tftaxaspercentual",GXType.Number,16,4) ,
          new ParDef("AV75Taxaswwds_14_tftaxaspercentual_to",GXType.Number,16,4) ,
          new ParDef("AV76Taxaswwds_15_tftaxaspercentualanual",GXType.Number,16,4) ,
          new ParDef("AV77Taxaswwds_16_tftaxaspercentualanual_to",GXType.Number,16,4) ,
          new ParDef("AV78Taxaswwds_17_tftaxasvalorminimo",GXType.Number,18,2) ,
          new ParDef("AV79Taxaswwds_18_tftaxasvalorminimo_to",GXType.Number,18,2) ,
          new ParDef("AV80Taxaswwds_19_tftaxascreatedat",GXType.DateTime,10,8) ,
          new ParDef("AV81Taxaswwds_20_tftaxascreatedat_to",GXType.DateTime,10,8) ,
          new ParDef("AV82Taxaswwds_21_tftaxasupdatedat",GXType.DateTime,10,8) ,
          new ParDef("AV83Taxaswwds_22_tftaxasupdatedat_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("H008T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008T2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H008T3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH008T3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
