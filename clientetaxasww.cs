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
   public class clientetaxasww : GXDataArea
   {
      public clientetaxasww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientetaxasww( IGxContext context )
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
         cmbavClientetaxastipo1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavClientetaxastipo2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavClientetaxastipo3 = new GXCombobox();
         cmbClienteTaxasTipo = new GXCombobox();
         cmbClienteTaxasTipoTarifa = new GXCombobox();
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
         nRC_GXsfl_98 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_98"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_98_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_98_idx = GetPar( "sGXsfl_98_idx");
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
         cmbavClientetaxastipo1.FromJSonString( GetNextPar( ));
         AV17ClienteTaxasTipo1 = GetPar( "ClienteTaxasTipo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavClientetaxastipo2.FromJSonString( GetNextPar( ));
         AV20ClienteTaxasTipo2 = GetPar( "ClienteTaxasTipo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavClientetaxastipo3.FromJSonString( GetNextPar( ));
         AV23ClienteTaxasTipo3 = GetPar( "ClienteTaxasTipo3");
         AV31ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV61Pgmname = GetPar( "Pgmname");
         AV18DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV21DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV33TFClienteTaxasTipo_Sels);
         AV34TFClienteTaxasEfetiva = NumberUtil.Val( GetPar( "TFClienteTaxasEfetiva"), ".");
         AV35TFClienteTaxasEfetiva_To = NumberUtil.Val( GetPar( "TFClienteTaxasEfetiva_To"), ".");
         AV36TFClienteTaxasMora = NumberUtil.Val( GetPar( "TFClienteTaxasMora"), ".");
         AV37TFClienteTaxasMora_To = NumberUtil.Val( GetPar( "TFClienteTaxasMora_To"), ".");
         AV38TFClienteTaxasFator = NumberUtil.Val( GetPar( "TFClienteTaxasFator"), ".");
         AV39TFClienteTaxasFator_To = NumberUtil.Val( GetPar( "TFClienteTaxasFator_To"), ".");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41TFClienteTaxasTipoTarifa_Sels);
         AV42TFClienteTaxasTarifa = NumberUtil.Val( GetPar( "TFClienteTaxasTarifa"), ".");
         AV43TFClienteTaxasTarifa_To = NumberUtil.Val( GetPar( "TFClienteTaxasTarifa_To"), ".");
         AV44TFClienteTaxasCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFClienteTaxasCreatedAt"));
         AV45TFClienteTaxasCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFClienteTaxasCreatedAt_To"));
         AV49TFClienteTaxasUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFClienteTaxasUpdatedAt"));
         AV50TFClienteTaxasUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFClienteTaxasUpdatedAt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV25DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV24DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
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
         PAA02( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA02( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientetaxasww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTETAXASTIPO1", AV17ClienteTaxasTipo1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV19DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTETAXASTIPO2", AV20ClienteTaxasTipo2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV22DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTETAXASTIPO3", AV23ClienteTaxasTipo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_98), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV29ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV58GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTETAXASCREATEDATAUXDATE", context.localUtil.DToC( AV46DDO_ClienteTaxasCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTETAXASCREATEDATAUXDATETO", context.localUtil.DToC( AV47DDO_ClienteTaxasCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTETAXASUPDATEDATAUXDATE", context.localUtil.DToC( AV51DDO_ClienteTaxasUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CLIENTETAXASUPDATEDATAUXDATETO", context.localUtil.DToC( AV52DDO_ClienteTaxasUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV18DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV21DynamicFiltersEnabled3);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTETAXASTIPO_SELS", AV33TFClienteTaxasTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTETAXASTIPO_SELS", AV33TFClienteTaxasTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASEFETIVA", StringUtil.LTrim( StringUtil.NToC( AV34TFClienteTaxasEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASEFETIVA_TO", StringUtil.LTrim( StringUtil.NToC( AV35TFClienteTaxasEfetiva_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASMORA", StringUtil.LTrim( StringUtil.NToC( AV36TFClienteTaxasMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASMORA_TO", StringUtil.LTrim( StringUtil.NToC( AV37TFClienteTaxasMora_To, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASFATOR", StringUtil.LTrim( StringUtil.NToC( AV38TFClienteTaxasFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASFATOR_TO", StringUtil.LTrim( StringUtil.NToC( AV39TFClienteTaxasFator_To, 16, 4, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFCLIENTETAXASTIPOTARIFA_SELS", AV41TFClienteTaxasTipoTarifa_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFCLIENTETAXASTIPOTARIFA_SELS", AV41TFClienteTaxasTipoTarifa_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASTARIFA", StringUtil.LTrim( StringUtil.NToC( AV42TFClienteTaxasTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASTARIFA_TO", StringUtil.LTrim( StringUtil.NToC( AV43TFClienteTaxasTarifa_To, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASCREATEDAT", context.localUtil.TToC( AV44TFClienteTaxasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASCREATEDAT_TO", context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASUPDATEDAT", context.localUtil.TToC( AV49TFClienteTaxasUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASUPDATEDAT_TO", context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV25DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV24DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASTIPO_SELSJSON", AV32TFClienteTaxasTipo_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTETAXASTIPOTARIFA_SELSJSON", AV40TFClienteTaxasTipoTarifa_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
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
            WEA02( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA02( ) ;
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
         return formatLink("clientetaxasww")  ;
      }

      public override string GetPgmname( )
      {
         return "ClienteTaxasWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Taxas" ;
      }

      protected void WBA00( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(98), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteTaxasWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV29ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ClienteTaxasWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_A02( true) ;
         }
         else
         {
            wb_table1_45_A02( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_A02e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_64_A02( true) ;
         }
         else
         {
            wb_table2_64_A02( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_A02e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ClienteTaxasWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_83_A02( true) ;
         }
         else
         {
            wb_table3_83_A02( false) ;
         }
         return  ;
      }

      protected void wb_table3_83_A02e( bool wbgen )
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
            StartGridControl98( ) ;
         }
         if ( wbEnd == 98 )
         {
            wbEnd = 0;
            nRC_GXsfl_98 = (int)(nGXsfl_98_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV56GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV57GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV58GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ClienteTaxasWW.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_clientetaxascreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_clientetaxascreatedatauxdatetext_Internalname, AV48DDO_ClienteTaxasCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV48DDO_ClienteTaxasCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_clientetaxascreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteTaxasWW.htm");
            /* User Defined Control */
            ucTfclientetaxascreatedat_rangepicker.SetProperty("Start Date", AV46DDO_ClienteTaxasCreatedAtAuxDate);
            ucTfclientetaxascreatedat_rangepicker.SetProperty("End Date", AV47DDO_ClienteTaxasCreatedAtAuxDateTo);
            ucTfclientetaxascreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfclientetaxascreatedat_rangepicker_Internalname, "TFCLIENTETAXASCREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_clientetaxasupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'" + sGXsfl_98_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_clientetaxasupdatedatauxdatetext_Internalname, AV53DDO_ClienteTaxasUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV53DDO_ClienteTaxasUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_clientetaxasupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ClienteTaxasWW.htm");
            /* User Defined Control */
            ucTfclientetaxasupdatedat_rangepicker.SetProperty("Start Date", AV51DDO_ClienteTaxasUpdatedAtAuxDate);
            ucTfclientetaxasupdatedat_rangepicker.SetProperty("End Date", AV52DDO_ClienteTaxasUpdatedAtAuxDateTo);
            ucTfclientetaxasupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfclientetaxasupdatedat_rangepicker_Internalname, "TFCLIENTETAXASUPDATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 98 )
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

      protected void STARTA02( )
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
         Form.Meta.addItem("description", "Taxas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA00( ) ;
      }

      protected void WSA02( )
      {
         STARTA02( ) ;
         EVTA02( ) ;
      }

      protected void EVTA02( )
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
                              E11A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E19A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E20A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E22A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23A02 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24A02 ();
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
                              nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
                              SubsflControlProps_982( ) ;
                              AV59Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
                              A1008ClienteTaxasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteTaxasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              cmbClienteTaxasTipo.Name = cmbClienteTaxasTipo_Internalname;
                              cmbClienteTaxasTipo.CurrentValue = cgiGet( cmbClienteTaxasTipo_Internalname);
                              A1009ClienteTaxasTipo = cgiGet( cmbClienteTaxasTipo_Internalname);
                              n1009ClienteTaxasTipo = false;
                              A1040ClienteTaxasEfetiva = context.localUtil.CToN( cgiGet( edtClienteTaxasEfetiva_Internalname), ",", ".");
                              n1040ClienteTaxasEfetiva = false;
                              A1041ClienteTaxasMora = context.localUtil.CToN( cgiGet( edtClienteTaxasMora_Internalname), ",", ".");
                              n1041ClienteTaxasMora = false;
                              A1042ClienteTaxasFator = context.localUtil.CToN( cgiGet( edtClienteTaxasFator_Internalname), ",", ".");
                              n1042ClienteTaxasFator = false;
                              cmbClienteTaxasTipoTarifa.Name = cmbClienteTaxasTipoTarifa_Internalname;
                              cmbClienteTaxasTipoTarifa.CurrentValue = cgiGet( cmbClienteTaxasTipoTarifa_Internalname);
                              A1043ClienteTaxasTipoTarifa = cgiGet( cmbClienteTaxasTipoTarifa_Internalname);
                              n1043ClienteTaxasTipoTarifa = false;
                              A1044ClienteTaxasTarifa = context.localUtil.CToN( cgiGet( edtClienteTaxasTarifa_Internalname), ",", ".");
                              n1044ClienteTaxasTarifa = false;
                              A1045ClienteTaxasCreatedAt = context.localUtil.CToT( cgiGet( edtClienteTaxasCreatedAt_Internalname), 0);
                              n1045ClienteTaxasCreatedAt = false;
                              A1046ClienteTaxasUpdatedAt = context.localUtil.CToT( cgiGet( edtClienteTaxasUpdatedAt_Internalname), 0);
                              n1046ClienteTaxasUpdatedAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E25A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E26A02 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E27A02 ();
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
                                       /* Set Refresh If Clientetaxastipo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO1"), AV17ClienteTaxasTipo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientetaxastipo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO2"), AV20ClienteTaxasTipo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientetaxastipo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO3"), AV23ClienteTaxasTipo3) != 0 )
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

      protected void WEA02( )
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

      protected void PAA02( )
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
         SubsflControlProps_982( ) ;
         while ( nGXsfl_98_idx <= nRC_GXsfl_98 )
         {
            sendrow_982( ) ;
            nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       string AV17ClienteTaxasTipo1 ,
                                       string AV19DynamicFiltersSelector2 ,
                                       string AV20ClienteTaxasTipo2 ,
                                       string AV22DynamicFiltersSelector3 ,
                                       string AV23ClienteTaxasTipo3 ,
                                       short AV31ManageFiltersExecutionStep ,
                                       string AV61Pgmname ,
                                       bool AV18DynamicFiltersEnabled2 ,
                                       bool AV21DynamicFiltersEnabled3 ,
                                       GxSimpleCollection<string> AV33TFClienteTaxasTipo_Sels ,
                                       decimal AV34TFClienteTaxasEfetiva ,
                                       decimal AV35TFClienteTaxasEfetiva_To ,
                                       decimal AV36TFClienteTaxasMora ,
                                       decimal AV37TFClienteTaxasMora_To ,
                                       decimal AV38TFClienteTaxasFator ,
                                       decimal AV39TFClienteTaxasFator_To ,
                                       GxSimpleCollection<string> AV41TFClienteTaxasTipoTarifa_Sels ,
                                       decimal AV42TFClienteTaxasTarifa ,
                                       decimal AV43TFClienteTaxasTarifa_To ,
                                       DateTime AV44TFClienteTaxasCreatedAt ,
                                       DateTime AV45TFClienteTaxasCreatedAt_To ,
                                       DateTime AV49TFClienteTaxasUpdatedAt ,
                                       DateTime AV50TFClienteTaxasUpdatedAt_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV25DynamicFiltersIgnoreFirst ,
                                       bool AV24DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA02( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTETAXASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTETAXASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1008ClienteTaxasId), 9, 0, ".", "")));
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
         if ( cmbavClientetaxastipo1.ItemCount > 0 )
         {
            AV17ClienteTaxasTipo1 = cmbavClientetaxastipo1.getValidValue(AV17ClienteTaxasTipo1);
            AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
            AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavClientetaxastipo2.ItemCount > 0 )
         {
            AV20ClienteTaxasTipo2 = cmbavClientetaxastipo2.getValidValue(AV20ClienteTaxasTipo2);
            AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
            AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV22DynamicFiltersSelector3);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavClientetaxastipo3.ItemCount > 0 )
         {
            AV23ClienteTaxasTipo3 = cmbavClientetaxastipo3.getValidValue(AV23ClienteTaxasTipo3);
            AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
            AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA02( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV61Pgmname = "ClienteTaxasWW";
         edtavUpdate_Enabled = 0;
      }

      protected void RFA02( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 98;
         /* Execute user event: Refresh */
         E26A02 ();
         nGXsfl_98_idx = 1;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         bGXsfl_98_Refreshing = true;
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
            SubsflControlProps_982( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A1009ClienteTaxasTipo ,
                                                 AV71Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                                 A1043ClienteTaxasTipoTarifa ,
                                                 AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                                 AV62Clientetaxaswwds_1_filterfulltext ,
                                                 AV63Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                                 AV64Clientetaxaswwds_3_clientetaxastipo1 ,
                                                 AV65Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                                 AV66Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                                 AV67Clientetaxaswwds_6_clientetaxastipo2 ,
                                                 AV68Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                                 AV69Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                                 AV70Clientetaxaswwds_9_clientetaxastipo3 ,
                                                 AV71Clientetaxaswwds_10_tfclientetaxastipo_sels.Count ,
                                                 AV72Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                                 AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                                 AV74Clientetaxaswwds_13_tfclientetaxasmora ,
                                                 AV75Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                                 AV76Clientetaxaswwds_15_tfclientetaxasfator ,
                                                 AV77Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                                 AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels.Count ,
                                                 AV79Clientetaxaswwds_18_tfclientetaxastarifa ,
                                                 AV80Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                                 AV81Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                                 AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                                 AV83Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                                 AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                                 A1040ClienteTaxasEfetiva ,
                                                 A1041ClienteTaxasMora ,
                                                 A1042ClienteTaxasFator ,
                                                 A1044ClienteTaxasTarifa ,
                                                 A1045ClienteTaxasCreatedAt ,
                                                 A1046ClienteTaxasUpdatedAt ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
            /* Using cursor H00A02 */
            pr_default.execute(0, new Object[] {lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, AV64Clientetaxaswwds_3_clientetaxastipo1, AV67Clientetaxaswwds_6_clientetaxastipo2, AV70Clientetaxaswwds_9_clientetaxastipo3, AV72Clientetaxaswwds_11_tfclientetaxasefetiva, AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to, AV74Clientetaxaswwds_13_tfclientetaxasmora, AV75Clientetaxaswwds_14_tfclientetaxasmora_to, AV76Clientetaxaswwds_15_tfclientetaxasfator, AV77Clientetaxaswwds_16_tfclientetaxasfator_to, AV79Clientetaxaswwds_18_tfclientetaxastarifa, AV80Clientetaxaswwds_19_tfclientetaxastarifa_to, AV81Clientetaxaswwds_20_tfclientetaxascreatedat, AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to, AV83Clientetaxaswwds_22_tfclientetaxasupdatedat, AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_98_idx = 1;
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1046ClienteTaxasUpdatedAt = H00A02_A1046ClienteTaxasUpdatedAt[0];
               n1046ClienteTaxasUpdatedAt = H00A02_n1046ClienteTaxasUpdatedAt[0];
               A1045ClienteTaxasCreatedAt = H00A02_A1045ClienteTaxasCreatedAt[0];
               n1045ClienteTaxasCreatedAt = H00A02_n1045ClienteTaxasCreatedAt[0];
               A1044ClienteTaxasTarifa = H00A02_A1044ClienteTaxasTarifa[0];
               n1044ClienteTaxasTarifa = H00A02_n1044ClienteTaxasTarifa[0];
               A1043ClienteTaxasTipoTarifa = H00A02_A1043ClienteTaxasTipoTarifa[0];
               n1043ClienteTaxasTipoTarifa = H00A02_n1043ClienteTaxasTipoTarifa[0];
               A1042ClienteTaxasFator = H00A02_A1042ClienteTaxasFator[0];
               n1042ClienteTaxasFator = H00A02_n1042ClienteTaxasFator[0];
               A1041ClienteTaxasMora = H00A02_A1041ClienteTaxasMora[0];
               n1041ClienteTaxasMora = H00A02_n1041ClienteTaxasMora[0];
               A1040ClienteTaxasEfetiva = H00A02_A1040ClienteTaxasEfetiva[0];
               n1040ClienteTaxasEfetiva = H00A02_n1040ClienteTaxasEfetiva[0];
               A1009ClienteTaxasTipo = H00A02_A1009ClienteTaxasTipo[0];
               n1009ClienteTaxasTipo = H00A02_n1009ClienteTaxasTipo[0];
               A1008ClienteTaxasId = H00A02_A1008ClienteTaxasId[0];
               /* Execute user event: Grid.Load */
               E27A02 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 98;
            WBA00( ) ;
         }
         bGXsfl_98_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA02( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTETAXASID"+"_"+sGXsfl_98_idx, GetSecureSignedToken( sGXsfl_98_idx, context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9"), context));
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
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1009ClienteTaxasTipo ,
                                              AV71Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                              A1043ClienteTaxasTipoTarifa ,
                                              AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                              AV62Clientetaxaswwds_1_filterfulltext ,
                                              AV63Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                              AV64Clientetaxaswwds_3_clientetaxastipo1 ,
                                              AV65Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                              AV66Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                              AV67Clientetaxaswwds_6_clientetaxastipo2 ,
                                              AV68Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                              AV69Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                              AV70Clientetaxaswwds_9_clientetaxastipo3 ,
                                              AV71Clientetaxaswwds_10_tfclientetaxastipo_sels.Count ,
                                              AV72Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                              AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                              AV74Clientetaxaswwds_13_tfclientetaxasmora ,
                                              AV75Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                              AV76Clientetaxaswwds_15_tfclientetaxasfator ,
                                              AV77Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                              AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels.Count ,
                                              AV79Clientetaxaswwds_18_tfclientetaxastarifa ,
                                              AV80Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                              AV81Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                              AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                              AV83Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                              AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                              A1040ClienteTaxasEfetiva ,
                                              A1041ClienteTaxasMora ,
                                              A1042ClienteTaxasFator ,
                                              A1044ClienteTaxasTarifa ,
                                              A1045ClienteTaxasCreatedAt ,
                                              A1046ClienteTaxasUpdatedAt ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         lV62Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext), "%", "");
         /* Using cursor H00A03 */
         pr_default.execute(1, new Object[] {lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, lV62Clientetaxaswwds_1_filterfulltext, AV64Clientetaxaswwds_3_clientetaxastipo1, AV67Clientetaxaswwds_6_clientetaxastipo2, AV70Clientetaxaswwds_9_clientetaxastipo3, AV72Clientetaxaswwds_11_tfclientetaxasefetiva, AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to, AV74Clientetaxaswwds_13_tfclientetaxasmora, AV75Clientetaxaswwds_14_tfclientetaxasmora_to, AV76Clientetaxaswwds_15_tfclientetaxasfator, AV77Clientetaxaswwds_16_tfclientetaxasfator_to, AV79Clientetaxaswwds_18_tfclientetaxastarifa, AV80Clientetaxaswwds_19_tfclientetaxastarifa_to, AV81Clientetaxaswwds_20_tfclientetaxascreatedat, AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to, AV83Clientetaxaswwds_22_tfclientetaxasupdatedat, AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to});
         GRID_nRecordCount = H00A03_AGRID_nRecordCount[0];
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
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV61Pgmname = "ClienteTaxasWW";
         edtavUpdate_Enabled = 0;
         edtClienteTaxasId_Enabled = 0;
         cmbClienteTaxasTipo.Enabled = 0;
         edtClienteTaxasEfetiva_Enabled = 0;
         edtClienteTaxasMora_Enabled = 0;
         edtClienteTaxasFator_Enabled = 0;
         cmbClienteTaxasTipoTarifa.Enabled = 0;
         edtClienteTaxasTarifa_Enabled = 0;
         edtClienteTaxasCreatedAt_Enabled = 0;
         edtClienteTaxasUpdatedAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA00( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E25A02 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV29ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV54DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_98"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV57GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV46DDO_ClienteTaxasCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CLIENTETAXASCREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV46DDO_ClienteTaxasCreatedAtAuxDate", context.localUtil.Format(AV46DDO_ClienteTaxasCreatedAtAuxDate, "99/99/99"));
            AV47DDO_ClienteTaxasCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CLIENTETAXASCREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV47DDO_ClienteTaxasCreatedAtAuxDateTo", context.localUtil.Format(AV47DDO_ClienteTaxasCreatedAtAuxDateTo, "99/99/99"));
            AV51DDO_ClienteTaxasUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CLIENTETAXASUPDATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV51DDO_ClienteTaxasUpdatedAtAuxDate", context.localUtil.Format(AV51DDO_ClienteTaxasUpdatedAtAuxDate, "99/99/99"));
            AV52DDO_ClienteTaxasUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CLIENTETAXASUPDATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV52DDO_ClienteTaxasUpdatedAtAuxDateTo", context.localUtil.Format(AV52DDO_ClienteTaxasUpdatedAtAuxDateTo, "99/99/99"));
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
            cmbavClientetaxastipo1.Name = cmbavClientetaxastipo1_Internalname;
            cmbavClientetaxastipo1.CurrentValue = cgiGet( cmbavClientetaxastipo1_Internalname);
            AV17ClienteTaxasTipo1 = cgiGet( cmbavClientetaxastipo1_Internalname);
            AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV19DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
            cmbavClientetaxastipo2.Name = cmbavClientetaxastipo2_Internalname;
            cmbavClientetaxastipo2.CurrentValue = cgiGet( cmbavClientetaxastipo2_Internalname);
            AV20ClienteTaxasTipo2 = cgiGet( cmbavClientetaxastipo2_Internalname);
            AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV22DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
            cmbavClientetaxastipo3.Name = cmbavClientetaxastipo3_Internalname;
            cmbavClientetaxastipo3.CurrentValue = cgiGet( cmbavClientetaxastipo3_Internalname);
            AV23ClienteTaxasTipo3 = cgiGet( cmbavClientetaxastipo3_Internalname);
            AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
            AV48DDO_ClienteTaxasCreatedAtAuxDateText = cgiGet( edtavDdo_clientetaxascreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV48DDO_ClienteTaxasCreatedAtAuxDateText", AV48DDO_ClienteTaxasCreatedAtAuxDateText);
            AV53DDO_ClienteTaxasUpdatedAtAuxDateText = cgiGet( edtavDdo_clientetaxasupdatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV53DDO_ClienteTaxasUpdatedAtAuxDateText", AV53DDO_ClienteTaxasUpdatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO1"), AV17ClienteTaxasTipo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV19DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO2"), AV20ClienteTaxasTipo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV22DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTETAXASTIPO3"), AV23ClienteTaxasTipo3) != 0 )
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
         E25A02 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E25A02( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCLIENTETAXASUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_clientetaxasupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFCLIENTETAXASCREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_clientetaxascreatedatauxdatetext_Internalname});
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
         AV17ClienteTaxasTipo1 = "";
         AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
         AV16DynamicFiltersSelector1 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20ClienteTaxasTipo2 = "";
         AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
         AV19DynamicFiltersSelector2 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23ClienteTaxasTipo3 = "";
         AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
         AV22DynamicFiltersSelector3 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
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
         Form.Caption = "Taxas";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV54DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV54DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E26A02( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV31ManageFiltersExecutionStep == 1 )
         {
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV31ManageFiltersExecutionStep == 2 )
         {
            AV31ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
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
         AV56GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV56GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV56GridCurrentPage), 10, 0));
         AV57GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV57GridPageCount", StringUtil.LTrimStr( (decimal)(AV57GridPageCount), 10, 0));
         GXt_char2 = AV58GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV61Pgmname, out  GXt_char2) ;
         AV58GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV58GridAppliedFilters", AV58GridAppliedFilters);
         AV62Clientetaxaswwds_1_filterfulltext = AV15FilterFullText;
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Clientetaxaswwds_3_clientetaxastipo1 = AV17ClienteTaxasTipo1;
         AV65Clientetaxaswwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Clientetaxaswwds_6_clientetaxastipo2 = AV20ClienteTaxasTipo2;
         AV68Clientetaxaswwds_7_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV70Clientetaxaswwds_9_clientetaxastipo3 = AV23ClienteTaxasTipo3;
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = AV33TFClienteTaxasTipo_Sels;
         AV72Clientetaxaswwds_11_tfclientetaxasefetiva = AV34TFClienteTaxasEfetiva;
         AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV35TFClienteTaxasEfetiva_To;
         AV74Clientetaxaswwds_13_tfclientetaxasmora = AV36TFClienteTaxasMora;
         AV75Clientetaxaswwds_14_tfclientetaxasmora_to = AV37TFClienteTaxasMora_To;
         AV76Clientetaxaswwds_15_tfclientetaxasfator = AV38TFClienteTaxasFator;
         AV77Clientetaxaswwds_16_tfclientetaxasfator_to = AV39TFClienteTaxasFator_To;
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV41TFClienteTaxasTipoTarifa_Sels;
         AV79Clientetaxaswwds_18_tfclientetaxastarifa = AV42TFClienteTaxasTarifa;
         AV80Clientetaxaswwds_19_tfclientetaxastarifa_to = AV43TFClienteTaxasTarifa_To;
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = AV44TFClienteTaxasCreatedAt;
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV45TFClienteTaxasCreatedAt_To;
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = AV49TFClienteTaxasUpdatedAt;
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV50TFClienteTaxasUpdatedAt_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A02( )
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
            AV55PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV55PageToGo) ;
         }
      }

      protected void E13A02( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A02( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasTipo") == 0 )
            {
               AV32TFClienteTaxasTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFClienteTaxasTipo_SelsJson", AV32TFClienteTaxasTipo_SelsJson);
               AV33TFClienteTaxasTipo_Sels.FromJSonString(AV32TFClienteTaxasTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasEfetiva") == 0 )
            {
               AV34TFClienteTaxasEfetiva = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV34TFClienteTaxasEfetiva", StringUtil.LTrimStr( AV34TFClienteTaxasEfetiva, 16, 4));
               AV35TFClienteTaxasEfetiva_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV35TFClienteTaxasEfetiva_To", StringUtil.LTrimStr( AV35TFClienteTaxasEfetiva_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasMora") == 0 )
            {
               AV36TFClienteTaxasMora = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV36TFClienteTaxasMora", StringUtil.LTrimStr( AV36TFClienteTaxasMora, 16, 4));
               AV37TFClienteTaxasMora_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV37TFClienteTaxasMora_To", StringUtil.LTrimStr( AV37TFClienteTaxasMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasFator") == 0 )
            {
               AV38TFClienteTaxasFator = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV38TFClienteTaxasFator", StringUtil.LTrimStr( AV38TFClienteTaxasFator, 16, 4));
               AV39TFClienteTaxasFator_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV39TFClienteTaxasFator_To", StringUtil.LTrimStr( AV39TFClienteTaxasFator_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasTipoTarifa") == 0 )
            {
               AV40TFClienteTaxasTipoTarifa_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFClienteTaxasTipoTarifa_SelsJson", AV40TFClienteTaxasTipoTarifa_SelsJson);
               AV41TFClienteTaxasTipoTarifa_Sels.FromJSonString(AV40TFClienteTaxasTipoTarifa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasTarifa") == 0 )
            {
               AV42TFClienteTaxasTarifa = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV42TFClienteTaxasTarifa", StringUtil.LTrimStr( AV42TFClienteTaxasTarifa, 15, 2));
               AV43TFClienteTaxasTarifa_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV43TFClienteTaxasTarifa_To", StringUtil.LTrimStr( AV43TFClienteTaxasTarifa_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasCreatedAt") == 0 )
            {
               AV44TFClienteTaxasCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV44TFClienteTaxasCreatedAt", context.localUtil.TToC( AV44TFClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV45TFClienteTaxasCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV45TFClienteTaxasCreatedAt_To", context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV45TFClienteTaxasCreatedAt_To) )
               {
                  AV45TFClienteTaxasCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV45TFClienteTaxasCreatedAt_To)), (short)(DateTimeUtil.Month( AV45TFClienteTaxasCreatedAt_To)), (short)(DateTimeUtil.Day( AV45TFClienteTaxasCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV45TFClienteTaxasCreatedAt_To", context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteTaxasUpdatedAt") == 0 )
            {
               AV49TFClienteTaxasUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV49TFClienteTaxasUpdatedAt", context.localUtil.TToC( AV49TFClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV50TFClienteTaxasUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV50TFClienteTaxasUpdatedAt_To", context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV50TFClienteTaxasUpdatedAt_To) )
               {
                  AV50TFClienteTaxasUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV50TFClienteTaxasUpdatedAt_To)), (short)(DateTimeUtil.Month( AV50TFClienteTaxasUpdatedAt_To)), (short)(DateTimeUtil.Day( AV50TFClienteTaxasUpdatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV50TFClienteTaxasUpdatedAt_To", context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFClienteTaxasTipoTarifa_Sels", AV41TFClienteTaxasTipoTarifa_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33TFClienteTaxasTipo_Sels", AV33TFClienteTaxasTipo_Sels);
      }

      private void E27A02( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV59Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "clientetaxas"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A1008ClienteTaxasId,9,0));
         edtavUpdate_Link = formatLink("clientetaxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 98;
         }
         sendrow_982( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_98_Refreshing )
         {
            DoAjaxLoad(98, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E20A02( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15A02( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV25DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV25DynamicFiltersIgnoreFirst", AV25DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E21A02( )
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

      protected void E22A02( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16A02( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E23A02( )
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

      protected void E17A02( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV24DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
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
         AV24DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV24DynamicFiltersRemoving", AV24DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17ClienteTaxasTipo1, AV19DynamicFiltersSelector2, AV20ClienteTaxasTipo2, AV22DynamicFiltersSelector3, AV23ClienteTaxasTipo3, AV31ManageFiltersExecutionStep, AV61Pgmname, AV18DynamicFiltersEnabled2, AV21DynamicFiltersEnabled3, AV33TFClienteTaxasTipo_Sels, AV34TFClienteTaxasEfetiva, AV35TFClienteTaxasEfetiva_To, AV36TFClienteTaxasMora, AV37TFClienteTaxasMora_To, AV38TFClienteTaxasFator, AV39TFClienteTaxasFator_To, AV41TFClienteTaxasTipoTarifa_Sels, AV42TFClienteTaxasTarifa, AV43TFClienteTaxasTarifa_To, AV44TFClienteTaxasCreatedAt, AV45TFClienteTaxasCreatedAt_To, AV49TFClienteTaxasUpdatedAt, AV50TFClienteTaxasUpdatedAt_To, AV10GridState, AV25DynamicFiltersIgnoreFirst, AV24DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E24A02( )
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

      protected void E11A02( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ClienteTaxasWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV61Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ClienteTaxasWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV31ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV31ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV31ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV30ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ClienteTaxasWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV30ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV30ManageFiltersXml) ;
               AV10GridState.FromXml(AV30ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33TFClienteTaxasTipo_Sels", AV33TFClienteTaxasTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFClienteTaxasTipoTarifa_Sels", AV41TFClienteTaxasTipoTarifa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29ManageFiltersData", AV29ManageFiltersData);
      }

      protected void E18A02( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "clientetaxas"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("clientetaxas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E19A02( )
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
         new clientetaxaswwexport(context ).execute( out  AV26ExcelFilename, out  AV27ErrorMessage) ;
         if ( StringUtil.StrCmp(AV26ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV26ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV27ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41TFClienteTaxasTipoTarifa_Sels", AV41TFClienteTaxasTipoTarifa_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33TFClienteTaxasTipo_Sels", AV33TFClienteTaxasTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", cmbavClientetaxastipo1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", cmbavClientetaxastipo2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", cmbavClientetaxastipo3.ToJavascriptSource(), true);
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
         cmbavClientetaxastipo1.Visible = 0;
         AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTETAXASTIPO") == 0 )
         {
            cmbavClientetaxastipo1.Visible = 1;
            AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavClientetaxastipo2.Visible = 0;
         AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CLIENTETAXASTIPO") == 0 )
         {
            cmbavClientetaxastipo2.Visible = 1;
            AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavClientetaxastipo3.Visible = 0;
         AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CLIENTETAXASTIPO") == 0 )
         {
            cmbavClientetaxastipo3.Visible = 1;
            AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClientetaxastipo3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV18DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
         AV19DynamicFiltersSelector2 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         AV20ClienteTaxasTipo2 = "";
         AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
         AV22DynamicFiltersSelector3 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         AV23ClienteTaxasTipo3 = "";
         AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV29ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ClienteTaxasWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV29ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV33TFClienteTaxasTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34TFClienteTaxasEfetiva = 0;
         AssignAttri("", false, "AV34TFClienteTaxasEfetiva", StringUtil.LTrimStr( AV34TFClienteTaxasEfetiva, 16, 4));
         AV35TFClienteTaxasEfetiva_To = 0;
         AssignAttri("", false, "AV35TFClienteTaxasEfetiva_To", StringUtil.LTrimStr( AV35TFClienteTaxasEfetiva_To, 16, 4));
         AV36TFClienteTaxasMora = 0;
         AssignAttri("", false, "AV36TFClienteTaxasMora", StringUtil.LTrimStr( AV36TFClienteTaxasMora, 16, 4));
         AV37TFClienteTaxasMora_To = 0;
         AssignAttri("", false, "AV37TFClienteTaxasMora_To", StringUtil.LTrimStr( AV37TFClienteTaxasMora_To, 16, 4));
         AV38TFClienteTaxasFator = 0;
         AssignAttri("", false, "AV38TFClienteTaxasFator", StringUtil.LTrimStr( AV38TFClienteTaxasFator, 16, 4));
         AV39TFClienteTaxasFator_To = 0;
         AssignAttri("", false, "AV39TFClienteTaxasFator_To", StringUtil.LTrimStr( AV39TFClienteTaxasFator_To, 16, 4));
         AV41TFClienteTaxasTipoTarifa_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42TFClienteTaxasTarifa = 0;
         AssignAttri("", false, "AV42TFClienteTaxasTarifa", StringUtil.LTrimStr( AV42TFClienteTaxasTarifa, 15, 2));
         AV43TFClienteTaxasTarifa_To = 0;
         AssignAttri("", false, "AV43TFClienteTaxasTarifa_To", StringUtil.LTrimStr( AV43TFClienteTaxasTarifa_To, 15, 2));
         AV44TFClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV44TFClienteTaxasCreatedAt", context.localUtil.TToC( AV44TFClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV45TFClienteTaxasCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV45TFClienteTaxasCreatedAt_To", context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV49TFClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV49TFClienteTaxasUpdatedAt", context.localUtil.TToC( AV49TFClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV50TFClienteTaxasUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV50TFClienteTaxasUpdatedAt_To", context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "CLIENTETAXASTIPO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17ClienteTaxasTipo1 = "";
         AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
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
         if ( StringUtil.StrCmp(AV28Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV28Session.Get(AV61Pgmname+"GridState"), null, "", "");
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
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV85GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTIPO_SEL") == 0 )
            {
               AV32TFClienteTaxasTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFClienteTaxasTipo_SelsJson", AV32TFClienteTaxasTipo_SelsJson);
               AV33TFClienteTaxasTipo_Sels.FromJSonString(AV32TFClienteTaxasTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASEFETIVA") == 0 )
            {
               AV34TFClienteTaxasEfetiva = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV34TFClienteTaxasEfetiva", StringUtil.LTrimStr( AV34TFClienteTaxasEfetiva, 16, 4));
               AV35TFClienteTaxasEfetiva_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV35TFClienteTaxasEfetiva_To", StringUtil.LTrimStr( AV35TFClienteTaxasEfetiva_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASMORA") == 0 )
            {
               AV36TFClienteTaxasMora = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV36TFClienteTaxasMora", StringUtil.LTrimStr( AV36TFClienteTaxasMora, 16, 4));
               AV37TFClienteTaxasMora_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV37TFClienteTaxasMora_To", StringUtil.LTrimStr( AV37TFClienteTaxasMora_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASFATOR") == 0 )
            {
               AV38TFClienteTaxasFator = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV38TFClienteTaxasFator", StringUtil.LTrimStr( AV38TFClienteTaxasFator, 16, 4));
               AV39TFClienteTaxasFator_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV39TFClienteTaxasFator_To", StringUtil.LTrimStr( AV39TFClienteTaxasFator_To, 16, 4));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTIPOTARIFA_SEL") == 0 )
            {
               AV40TFClienteTaxasTipoTarifa_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFClienteTaxasTipoTarifa_SelsJson", AV40TFClienteTaxasTipoTarifa_SelsJson);
               AV41TFClienteTaxasTipoTarifa_Sels.FromJSonString(AV40TFClienteTaxasTipoTarifa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTARIFA") == 0 )
            {
               AV42TFClienteTaxasTarifa = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV42TFClienteTaxasTarifa", StringUtil.LTrimStr( AV42TFClienteTaxasTarifa, 15, 2));
               AV43TFClienteTaxasTarifa_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV43TFClienteTaxasTarifa_To", StringUtil.LTrimStr( AV43TFClienteTaxasTarifa_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASCREATEDAT") == 0 )
            {
               AV44TFClienteTaxasCreatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV44TFClienteTaxasCreatedAt", context.localUtil.TToC( AV44TFClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV45TFClienteTaxasCreatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV45TFClienteTaxasCreatedAt_To", context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV46DDO_ClienteTaxasCreatedAtAuxDate = DateTimeUtil.ResetTime(AV44TFClienteTaxasCreatedAt);
               AssignAttri("", false, "AV46DDO_ClienteTaxasCreatedAtAuxDate", context.localUtil.Format(AV46DDO_ClienteTaxasCreatedAtAuxDate, "99/99/99"));
               AV47DDO_ClienteTaxasCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV45TFClienteTaxasCreatedAt_To);
               AssignAttri("", false, "AV47DDO_ClienteTaxasCreatedAtAuxDateTo", context.localUtil.Format(AV47DDO_ClienteTaxasCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASUPDATEDAT") == 0 )
            {
               AV49TFClienteTaxasUpdatedAt = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV49TFClienteTaxasUpdatedAt", context.localUtil.TToC( AV49TFClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV50TFClienteTaxasUpdatedAt_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV50TFClienteTaxasUpdatedAt_To", context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV51DDO_ClienteTaxasUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV49TFClienteTaxasUpdatedAt);
               AssignAttri("", false, "AV51DDO_ClienteTaxasUpdatedAtAuxDate", context.localUtil.Format(AV51DDO_ClienteTaxasUpdatedAtAuxDate, "99/99/99"));
               AV52DDO_ClienteTaxasUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV50TFClienteTaxasUpdatedAt_To);
               AssignAttri("", false, "AV52DDO_ClienteTaxasUpdatedAtAuxDateTo", context.localUtil.Format(AV52DDO_ClienteTaxasUpdatedAtAuxDateTo, "99/99/99"));
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV33TFClienteTaxasTipo_Sels.Count==0),  AV32TFClienteTaxasTipo_SelsJson, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV41TFClienteTaxasTipoTarifa_Sels.Count==0),  AV40TFClienteTaxasTipoTarifa_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||||"+GXt_char4+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "|"+((Convert.ToDecimal(0)==AV34TFClienteTaxasEfetiva) ? "" : StringUtil.Str( AV34TFClienteTaxasEfetiva, 16, 4))+"|"+((Convert.ToDecimal(0)==AV36TFClienteTaxasMora) ? "" : StringUtil.Str( AV36TFClienteTaxasMora, 16, 4))+"|"+((Convert.ToDecimal(0)==AV38TFClienteTaxasFator) ? "" : StringUtil.Str( AV38TFClienteTaxasFator, 16, 4))+"||"+((Convert.ToDecimal(0)==AV42TFClienteTaxasTarifa) ? "" : StringUtil.Str( AV42TFClienteTaxasTarifa, 15, 2))+"|"+((DateTime.MinValue==AV44TFClienteTaxasCreatedAt) ? "" : context.localUtil.DToC( AV46DDO_ClienteTaxasCreatedAtAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV49TFClienteTaxasUpdatedAt) ? "" : context.localUtil.DToC( AV51DDO_ClienteTaxasUpdatedAtAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((Convert.ToDecimal(0)==AV35TFClienteTaxasEfetiva_To) ? "" : StringUtil.Str( AV35TFClienteTaxasEfetiva_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV37TFClienteTaxasMora_To) ? "" : StringUtil.Str( AV37TFClienteTaxasMora_To, 16, 4))+"|"+((Convert.ToDecimal(0)==AV39TFClienteTaxasFator_To) ? "" : StringUtil.Str( AV39TFClienteTaxasFator_To, 16, 4))+"||"+((Convert.ToDecimal(0)==AV43TFClienteTaxasTarifa_To) ? "" : StringUtil.Str( AV43TFClienteTaxasTarifa_To, 15, 2))+"|"+((DateTime.MinValue==AV45TFClienteTaxasCreatedAt_To) ? "" : context.localUtil.DToC( AV47DDO_ClienteTaxasCreatedAtAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV50TFClienteTaxasUpdatedAt_To) ? "" : context.localUtil.DToC( AV52DDO_ClienteTaxasUpdatedAtAuxDateTo, 4, "/"));
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTETAXASTIPO") == 0 )
            {
               AV17ClienteTaxasTipo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
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
               AV18DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV18DynamicFiltersEnabled2", AV18DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CLIENTETAXASTIPO") == 0 )
               {
                  AV20ClienteTaxasTipo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
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
                  AV21DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV21DynamicFiltersEnabled3", AV21DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CLIENTETAXASTIPO") == 0 )
                  {
                     AV23ClienteTaxasTipo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
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
         if ( AV24DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV28Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         AV60AuxText = ((AV33TFClienteTaxasTipo_Sels.Count==1) ? "["+((string)AV33TFClienteTaxasTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASTIPO_SEL",  "Tipo",  !(AV33TFClienteTaxasTipo_Sels.Count==0),  0,  AV33TFClienteTaxasTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV60AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV60AuxText, "[SEM_RISCO]", "Sem Risco"), "[BAIXO]", "Risco Baixo"), "[ALTO]", "Risco Alto"), "[PREMIUM]", "Cliente Premium")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASEFETIVA",  "Taxa Efetiva",  !((Convert.ToDecimal(0)==AV34TFClienteTaxasEfetiva)&&(Convert.ToDecimal(0)==AV35TFClienteTaxasEfetiva_To)),  0,  StringUtil.Trim( StringUtil.Str( AV34TFClienteTaxasEfetiva, 16, 4)),  ((Convert.ToDecimal(0)==AV34TFClienteTaxasEfetiva) ? "" : StringUtil.Trim( context.localUtil.Format( AV34TFClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV35TFClienteTaxasEfetiva_To, 16, 4)),  ((Convert.ToDecimal(0)==AV35TFClienteTaxasEfetiva_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV35TFClienteTaxasEfetiva_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASMORA",  "Juros Mora",  !((Convert.ToDecimal(0)==AV36TFClienteTaxasMora)&&(Convert.ToDecimal(0)==AV37TFClienteTaxasMora_To)),  0,  StringUtil.Trim( StringUtil.Str( AV36TFClienteTaxasMora, 16, 4)),  ((Convert.ToDecimal(0)==AV36TFClienteTaxasMora) ? "" : StringUtil.Trim( context.localUtil.Format( AV36TFClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV37TFClienteTaxasMora_To, 16, 4)),  ((Convert.ToDecimal(0)==AV37TFClienteTaxasMora_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV37TFClienteTaxasMora_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASFATOR",  "Fator",  !((Convert.ToDecimal(0)==AV38TFClienteTaxasFator)&&(Convert.ToDecimal(0)==AV39TFClienteTaxasFator_To)),  0,  StringUtil.Trim( StringUtil.Str( AV38TFClienteTaxasFator, 16, 4)),  ((Convert.ToDecimal(0)==AV38TFClienteTaxasFator) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"))),  true,  StringUtil.Trim( StringUtil.Str( AV39TFClienteTaxasFator_To, 16, 4)),  ((Convert.ToDecimal(0)==AV39TFClienteTaxasFator_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFClienteTaxasFator_To, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))) ;
         AV60AuxText = ((AV41TFClienteTaxasTipoTarifa_Sels.Count==1) ? "["+((string)AV41TFClienteTaxasTipoTarifa_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASTIPOTARIFA_SEL",  "Tipo da Tarifa",  !(AV41TFClienteTaxasTipoTarifa_Sels.Count==0),  0,  AV41TFClienteTaxasTipoTarifa_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV60AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV60AuxText, "[P]", "Percentual"), "[V]", "Valor")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASTARIFA",  "Tarifa",  !((Convert.ToDecimal(0)==AV42TFClienteTaxasTarifa)&&(Convert.ToDecimal(0)==AV43TFClienteTaxasTarifa_To)),  0,  StringUtil.Trim( StringUtil.Str( AV42TFClienteTaxasTarifa, 15, 2)),  ((Convert.ToDecimal(0)==AV42TFClienteTaxasTarifa) ? "" : StringUtil.Trim( context.localUtil.Format( AV42TFClienteTaxasTarifa, "ZZZZZZZZZZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV43TFClienteTaxasTarifa_To, 15, 2)),  ((Convert.ToDecimal(0)==AV43TFClienteTaxasTarifa_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV43TFClienteTaxasTarifa_To, "ZZZZZZZZZZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASCREATEDAT",  "Criado em",  !((DateTime.MinValue==AV44TFClienteTaxasCreatedAt)&&(DateTime.MinValue==AV45TFClienteTaxasCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV44TFClienteTaxasCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV44TFClienteTaxasCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV44TFClienteTaxasCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV45TFClienteTaxasCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV45TFClienteTaxasCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFClienteTaxasCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCLIENTETAXASUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV49TFClienteTaxasUpdatedAt)&&(DateTime.MinValue==AV50TFClienteTaxasUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV49TFClienteTaxasUpdatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV49TFClienteTaxasUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV49TFClienteTaxasUpdatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV50TFClienteTaxasUpdatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV50TFClienteTaxasUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV50TFClienteTaxasUpdatedAt_To, "99/99/99 99:99")))) ;
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
         if ( ! AV25DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTETAXASTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ClienteTaxasTipo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV17ClienteTaxasTipo1,  StringUtil.Trim( gxdomaindmclientetiporisco.getDescription(context,AV17ClienteTaxasTipo1)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV18DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CLIENTETAXASTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteTaxasTipo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV20ClienteTaxasTipo2,  StringUtil.Trim( gxdomaindmclientetiporisco.getDescription(context,AV20ClienteTaxasTipo2)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "CLIENTETAXASTIPO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteTaxasTipo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo",  0,  AV23ClienteTaxasTipo3,  StringUtil.Trim( gxdomaindmclientetiporisco.getDescription(context,AV23ClienteTaxasTipo3)),  false,  "",  "") ;
            }
            if ( AV24DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Transactionname = "ClienteTaxas";
         AV28Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_83_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientetaxastipo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientetaxastipo3_Internalname, "Cliente Taxas Tipo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientetaxastipo3, cmbavClientetaxastipo3_Internalname, StringUtil.RTrim( AV23ClienteTaxasTipo3), 1, cmbavClientetaxastipo3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavClientetaxastipo3.Visible, cmbavClientetaxastipo3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavClientetaxastipo3.CurrentValue = StringUtil.RTrim( AV23ClienteTaxasTipo3);
            AssignProp("", false, cmbavClientetaxastipo3_Internalname, "Values", (string)(cmbavClientetaxastipo3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteTaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_83_A02e( true) ;
         }
         else
         {
            wb_table3_83_A02e( false) ;
         }
      }

      protected void wb_table2_64_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientetaxastipo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientetaxastipo2_Internalname, "Cliente Taxas Tipo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientetaxastipo2, cmbavClientetaxastipo2_Internalname, StringUtil.RTrim( AV20ClienteTaxasTipo2), 1, cmbavClientetaxastipo2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavClientetaxastipo2.Visible, cmbavClientetaxastipo2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavClientetaxastipo2.CurrentValue = StringUtil.RTrim( AV20ClienteTaxasTipo2);
            AssignProp("", false, cmbavClientetaxastipo2_Internalname, "Values", (string)(cmbavClientetaxastipo2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteTaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteTaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_A02e( true) ;
         }
         else
         {
            wb_table2_64_A02e( false) ;
         }
      }

      protected void wb_table1_45_A02( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientetaxastipo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavClientetaxastipo1_Internalname, "Cliente Taxas Tipo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_98_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavClientetaxastipo1, cmbavClientetaxastipo1_Internalname, StringUtil.RTrim( AV17ClienteTaxasTipo1), 1, cmbavClientetaxastipo1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavClientetaxastipo1.Visible, cmbavClientetaxastipo1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_ClienteTaxasWW.htm");
            cmbavClientetaxastipo1.CurrentValue = StringUtil.RTrim( AV17ClienteTaxasTipo1);
            AssignProp("", false, cmbavClientetaxastipo1_Internalname, "Values", (string)(cmbavClientetaxastipo1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteTaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ClienteTaxasWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_A02e( true) ;
         }
         else
         {
            wb_table1_45_A02e( false) ;
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
         PAA02( ) ;
         WSA02( ) ;
         WEA02( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101929138", true, true);
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
         context.AddJavascriptSource("clientetaxasww.js", "?20256101929139", false, true);
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

      protected void SubsflControlProps_982( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_98_idx;
         edtClienteTaxasId_Internalname = "CLIENTETAXASID_"+sGXsfl_98_idx;
         cmbClienteTaxasTipo_Internalname = "CLIENTETAXASTIPO_"+sGXsfl_98_idx;
         edtClienteTaxasEfetiva_Internalname = "CLIENTETAXASEFETIVA_"+sGXsfl_98_idx;
         edtClienteTaxasMora_Internalname = "CLIENTETAXASMORA_"+sGXsfl_98_idx;
         edtClienteTaxasFator_Internalname = "CLIENTETAXASFATOR_"+sGXsfl_98_idx;
         cmbClienteTaxasTipoTarifa_Internalname = "CLIENTETAXASTIPOTARIFA_"+sGXsfl_98_idx;
         edtClienteTaxasTarifa_Internalname = "CLIENTETAXASTARIFA_"+sGXsfl_98_idx;
         edtClienteTaxasCreatedAt_Internalname = "CLIENTETAXASCREATEDAT_"+sGXsfl_98_idx;
         edtClienteTaxasUpdatedAt_Internalname = "CLIENTETAXASUPDATEDAT_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_982( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_98_fel_idx;
         edtClienteTaxasId_Internalname = "CLIENTETAXASID_"+sGXsfl_98_fel_idx;
         cmbClienteTaxasTipo_Internalname = "CLIENTETAXASTIPO_"+sGXsfl_98_fel_idx;
         edtClienteTaxasEfetiva_Internalname = "CLIENTETAXASEFETIVA_"+sGXsfl_98_fel_idx;
         edtClienteTaxasMora_Internalname = "CLIENTETAXASMORA_"+sGXsfl_98_fel_idx;
         edtClienteTaxasFator_Internalname = "CLIENTETAXASFATOR_"+sGXsfl_98_fel_idx;
         cmbClienteTaxasTipoTarifa_Internalname = "CLIENTETAXASTIPOTARIFA_"+sGXsfl_98_fel_idx;
         edtClienteTaxasTarifa_Internalname = "CLIENTETAXASTARIFA_"+sGXsfl_98_fel_idx;
         edtClienteTaxasCreatedAt_Internalname = "CLIENTETAXASCREATEDAT_"+sGXsfl_98_fel_idx;
         edtClienteTaxasUpdatedAt_Internalname = "CLIENTETAXASUPDATEDAT_"+sGXsfl_98_fel_idx;
      }

      protected void sendrow_982( )
      {
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_982( ) ;
         WBA00( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_98_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_98_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_98_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_98_idx + "',98)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV59Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)98,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1008ClienteTaxasId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1008ClienteTaxasId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteTaxasTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETAXASTIPO_" + sGXsfl_98_idx;
               cmbClienteTaxasTipo.Name = GXCCtl;
               cmbClienteTaxasTipo.WebTags = "";
               cmbClienteTaxasTipo.addItem("SEM_RISCO", "Normal", 0);
               cmbClienteTaxasTipo.addItem("BAIXO", "Risco Baixo", 0);
               cmbClienteTaxasTipo.addItem("ALTO", "Risco Alto", 0);
               cmbClienteTaxasTipo.addItem("PREMIUM", "Cliente Premium", 0);
               if ( cmbClienteTaxasTipo.ItemCount > 0 )
               {
                  A1009ClienteTaxasTipo = cmbClienteTaxasTipo.getValidValue(A1009ClienteTaxasTipo);
                  n1009ClienteTaxasTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteTaxasTipo,(string)cmbClienteTaxasTipo_Internalname,StringUtil.RTrim( A1009ClienteTaxasTipo),(short)1,(string)cmbClienteTaxasTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbClienteTaxasTipo.CurrentValue = StringUtil.RTrim( A1009ClienteTaxasTipo);
            AssignProp("", false, cmbClienteTaxasTipo_Internalname, "Values", (string)(cmbClienteTaxasTipo.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasEfetiva_Internalname,StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1040ClienteTaxasEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasEfetiva_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasMora_Internalname,StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1041ClienteTaxasMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasMora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasFator_Internalname,StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 21, 4, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1042ClienteTaxasFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasFator_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentual",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbClienteTaxasTipoTarifa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CLIENTETAXASTIPOTARIFA_" + sGXsfl_98_idx;
               cmbClienteTaxasTipoTarifa.Name = GXCCtl;
               cmbClienteTaxasTipoTarifa.WebTags = "";
               cmbClienteTaxasTipoTarifa.addItem("P", "Percentual", 0);
               cmbClienteTaxasTipoTarifa.addItem("V", "Valor", 0);
               if ( cmbClienteTaxasTipoTarifa.ItemCount > 0 )
               {
                  A1043ClienteTaxasTipoTarifa = cmbClienteTaxasTipoTarifa.getValidValue(A1043ClienteTaxasTipoTarifa);
                  n1043ClienteTaxasTipoTarifa = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbClienteTaxasTipoTarifa,(string)cmbClienteTaxasTipoTarifa_Internalname,StringUtil.RTrim( A1043ClienteTaxasTipoTarifa),(short)1,(string)cmbClienteTaxasTipoTarifa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbClienteTaxasTipoTarifa.CurrentValue = StringUtil.RTrim( A1043ClienteTaxasTipoTarifa);
            AssignProp("", false, cmbClienteTaxasTipoTarifa_Internalname, "Values", (string)(cmbClienteTaxasTipoTarifa.ToJavascriptSource()), !bGXsfl_98_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasTarifa_Internalname,StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A1044ClienteTaxasTarifa, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasTarifa_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasCreatedAt_Internalname,context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1045ClienteTaxasCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTaxasUpdatedAt_Internalname,context.localUtil.TToC( A1046ClienteTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1046ClienteTaxasUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteTaxasUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA02( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_98_idx = ((subGrid_Islastpage==1)&&(nGXsfl_98_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_982( ) ;
         }
         /* End function sendrow_982 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CLIENTETAXASTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavClientetaxastipo1.Name = "vCLIENTETAXASTIPO1";
         cmbavClientetaxastipo1.WebTags = "";
         cmbavClientetaxastipo1.addItem("", "Todos", 0);
         cmbavClientetaxastipo1.addItem("SEM_RISCO", "Normal", 0);
         cmbavClientetaxastipo1.addItem("BAIXO", "Risco Baixo", 0);
         cmbavClientetaxastipo1.addItem("ALTO", "Risco Alto", 0);
         cmbavClientetaxastipo1.addItem("PREMIUM", "Cliente Premium", 0);
         if ( cmbavClientetaxastipo1.ItemCount > 0 )
         {
            AV17ClienteTaxasTipo1 = cmbavClientetaxastipo1.getValidValue(AV17ClienteTaxasTipo1);
            AssignAttri("", false, "AV17ClienteTaxasTipo1", AV17ClienteTaxasTipo1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CLIENTETAXASTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV19DynamicFiltersSelector2);
            AssignAttri("", false, "AV19DynamicFiltersSelector2", AV19DynamicFiltersSelector2);
         }
         cmbavClientetaxastipo2.Name = "vCLIENTETAXASTIPO2";
         cmbavClientetaxastipo2.WebTags = "";
         cmbavClientetaxastipo2.addItem("", "Todos", 0);
         cmbavClientetaxastipo2.addItem("SEM_RISCO", "Normal", 0);
         cmbavClientetaxastipo2.addItem("BAIXO", "Risco Baixo", 0);
         cmbavClientetaxastipo2.addItem("ALTO", "Risco Alto", 0);
         cmbavClientetaxastipo2.addItem("PREMIUM", "Cliente Premium", 0);
         if ( cmbavClientetaxastipo2.ItemCount > 0 )
         {
            AV20ClienteTaxasTipo2 = cmbavClientetaxastipo2.getValidValue(AV20ClienteTaxasTipo2);
            AssignAttri("", false, "AV20ClienteTaxasTipo2", AV20ClienteTaxasTipo2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CLIENTETAXASTIPO", "Tipo", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV22DynamicFiltersSelector3);
            AssignAttri("", false, "AV22DynamicFiltersSelector3", AV22DynamicFiltersSelector3);
         }
         cmbavClientetaxastipo3.Name = "vCLIENTETAXASTIPO3";
         cmbavClientetaxastipo3.WebTags = "";
         cmbavClientetaxastipo3.addItem("", "Todos", 0);
         cmbavClientetaxastipo3.addItem("SEM_RISCO", "Normal", 0);
         cmbavClientetaxastipo3.addItem("BAIXO", "Risco Baixo", 0);
         cmbavClientetaxastipo3.addItem("ALTO", "Risco Alto", 0);
         cmbavClientetaxastipo3.addItem("PREMIUM", "Cliente Premium", 0);
         if ( cmbavClientetaxastipo3.ItemCount > 0 )
         {
            AV23ClienteTaxasTipo3 = cmbavClientetaxastipo3.getValidValue(AV23ClienteTaxasTipo3);
            AssignAttri("", false, "AV23ClienteTaxasTipo3", AV23ClienteTaxasTipo3);
         }
         GXCCtl = "CLIENTETAXASTIPO_" + sGXsfl_98_idx;
         cmbClienteTaxasTipo.Name = GXCCtl;
         cmbClienteTaxasTipo.WebTags = "";
         cmbClienteTaxasTipo.addItem("SEM_RISCO", "Normal", 0);
         cmbClienteTaxasTipo.addItem("BAIXO", "Risco Baixo", 0);
         cmbClienteTaxasTipo.addItem("ALTO", "Risco Alto", 0);
         cmbClienteTaxasTipo.addItem("PREMIUM", "Cliente Premium", 0);
         if ( cmbClienteTaxasTipo.ItemCount > 0 )
         {
            A1009ClienteTaxasTipo = cmbClienteTaxasTipo.getValidValue(A1009ClienteTaxasTipo);
            n1009ClienteTaxasTipo = false;
         }
         GXCCtl = "CLIENTETAXASTIPOTARIFA_" + sGXsfl_98_idx;
         cmbClienteTaxasTipoTarifa.Name = GXCCtl;
         cmbClienteTaxasTipoTarifa.WebTags = "";
         cmbClienteTaxasTipoTarifa.addItem("P", "Percentual", 0);
         cmbClienteTaxasTipoTarifa.addItem("V", "Valor", 0);
         if ( cmbClienteTaxasTipoTarifa.ItemCount > 0 )
         {
            A1043ClienteTaxasTipoTarifa = cmbClienteTaxasTipoTarifa.getValidValue(A1043ClienteTaxasTipoTarifa);
            n1043ClienteTaxasTipoTarifa = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl98( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"98\">") ;
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
            context.SendWebValue( "Taxas Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Taxa Efetiva") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Juros Mora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fator") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo da Tarifa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tarifa") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1008ClienteTaxasId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1009ClienteTaxasTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1040ClienteTaxasEfetiva, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1041ClienteTaxasMora, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1042ClienteTaxasFator, 21, 4, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1043ClienteTaxasTipoTarifa));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1044ClienteTaxasTarifa, 15, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1045ClienteTaxasCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1046ClienteTaxasUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavClientetaxastipo1_Internalname = "vCLIENTETAXASTIPO1";
         cellFilter_clientetaxastipo1_cell_Internalname = "FILTER_CLIENTETAXASTIPO1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavClientetaxastipo2_Internalname = "vCLIENTETAXASTIPO2";
         cellFilter_clientetaxastipo2_cell_Internalname = "FILTER_CLIENTETAXASTIPO2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavClientetaxastipo3_Internalname = "vCLIENTETAXASTIPO3";
         cellFilter_clientetaxastipo3_cell_Internalname = "FILTER_CLIENTETAXASTIPO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavUpdate_Internalname = "vUPDATE";
         edtClienteTaxasId_Internalname = "CLIENTETAXASID";
         cmbClienteTaxasTipo_Internalname = "CLIENTETAXASTIPO";
         edtClienteTaxasEfetiva_Internalname = "CLIENTETAXASEFETIVA";
         edtClienteTaxasMora_Internalname = "CLIENTETAXASMORA";
         edtClienteTaxasFator_Internalname = "CLIENTETAXASFATOR";
         cmbClienteTaxasTipoTarifa_Internalname = "CLIENTETAXASTIPOTARIFA";
         edtClienteTaxasTarifa_Internalname = "CLIENTETAXASTARIFA";
         edtClienteTaxasCreatedAt_Internalname = "CLIENTETAXASCREATEDAT";
         edtClienteTaxasUpdatedAt_Internalname = "CLIENTETAXASUPDATEDAT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_clientetaxascreatedatauxdatetext_Internalname = "vDDO_CLIENTETAXASCREATEDATAUXDATETEXT";
         Tfclientetaxascreatedat_rangepicker_Internalname = "TFCLIENTETAXASCREATEDAT_RANGEPICKER";
         divDdo_clientetaxascreatedatauxdates_Internalname = "DDO_CLIENTETAXASCREATEDATAUXDATES";
         edtavDdo_clientetaxasupdatedatauxdatetext_Internalname = "vDDO_CLIENTETAXASUPDATEDATAUXDATETEXT";
         Tfclientetaxasupdatedat_rangepicker_Internalname = "TFCLIENTETAXASUPDATEDAT_RANGEPICKER";
         divDdo_clientetaxasupdatedatauxdates_Internalname = "DDO_CLIENTETAXASUPDATEDATAUXDATES";
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
         edtClienteTaxasUpdatedAt_Jsonclick = "";
         edtClienteTaxasCreatedAt_Jsonclick = "";
         edtClienteTaxasTarifa_Jsonclick = "";
         cmbClienteTaxasTipoTarifa_Jsonclick = "";
         edtClienteTaxasFator_Jsonclick = "";
         edtClienteTaxasMora_Jsonclick = "";
         edtClienteTaxasEfetiva_Jsonclick = "";
         cmbClienteTaxasTipo_Jsonclick = "";
         edtClienteTaxasId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavClientetaxastipo1_Jsonclick = "";
         cmbavClientetaxastipo1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavClientetaxastipo2_Jsonclick = "";
         cmbavClientetaxastipo2.Enabled = 1;
         cmbavClientetaxastipo3_Jsonclick = "";
         cmbavClientetaxastipo3.Enabled = 1;
         cmbavClientetaxastipo3.Visible = 1;
         cmbavClientetaxastipo2.Visible = 1;
         cmbavClientetaxastipo1.Visible = 1;
         edtClienteTaxasUpdatedAt_Enabled = 0;
         edtClienteTaxasCreatedAt_Enabled = 0;
         edtClienteTaxasTarifa_Enabled = 0;
         cmbClienteTaxasTipoTarifa.Enabled = 0;
         edtClienteTaxasFator_Enabled = 0;
         edtClienteTaxasMora_Enabled = 0;
         edtClienteTaxasEfetiva_Enabled = 0;
         cmbClienteTaxasTipo.Enabled = 0;
         edtClienteTaxasId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_clientetaxasupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_clientetaxascreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|16.4|16.4|16.4||15.2||";
         Ddo_grid_Datalistfixedvalues = "SEM_RISCO:Sem Risco,BAIXO:Risco Baixo,ALTO:Risco Alto,PREMIUM:Cliente Premium||||P:Percentual,V:Valor|||";
         Ddo_grid_Allowmultipleselection = "T||||T|||";
         Ddo_grid_Datalisttype = "FixedValues||||FixedValues|||";
         Ddo_grid_Includedatalist = "T||||T|||";
         Ddo_grid_Filterisrange = "|T|T|T||T|P|P";
         Ddo_grid_Filtertype = "|Numeric|Numeric|Numeric||Numeric|Date|Date";
         Ddo_grid_Includefilter = "|T|T|T||T|T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "2:ClienteTaxasTipo|3:ClienteTaxasEfetiva|4:ClienteTaxasMora|5:ClienteTaxasFator|6:ClienteTaxasTipoTarifa|7:ClienteTaxasTarifa|8:ClienteTaxasCreatedAt|9:ClienteTaxasUpdatedAt";
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
         Form.Caption = "Taxas";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV40TFClienteTaxasTipoTarifa_SelsJson","fld":"vTFCLIENTETAXASTIPOTARIFA_SELSJSON","type":"vchar"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV32TFClienteTaxasTipo_SelsJson","fld":"vTFCLIENTETAXASTIPO_SELSJSON","type":"vchar"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E27A02","iparms":[{"av":"A1008ClienteTaxasId","fld":"CLIENTETAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV59Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E20A02","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E21A02","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavClientetaxastipo1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E22A02","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E23A02","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavClientetaxastipo2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV56GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E24A02","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavClientetaxastipo3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A02","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV32TFClienteTaxasTipo_SelsJson","fld":"vTFCLIENTETAXASTIPO_SELSJSON","type":"vchar"},{"av":"AV40TFClienteTaxasTipoTarifa_SelsJson","fld":"vTFCLIENTETAXASTIPOTARIFA_SELSJSON","type":"vchar"},{"av":"AV46DDO_ClienteTaxasCreatedAtAuxDate","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATE","type":"date"},{"av":"AV51DDO_ClienteTaxasUpdatedAtAuxDate","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV47DDO_ClienteTaxasCreatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATETO","type":"date"},{"av":"AV52DDO_ClienteTaxasUpdatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV51DDO_ClienteTaxasUpdatedAtAuxDate","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV52DDO_ClienteTaxasUpdatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATETO","type":"date"},{"av":"AV46DDO_ClienteTaxasCreatedAtAuxDate","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATE","type":"date"},{"av":"AV47DDO_ClienteTaxasCreatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATETO","type":"date"},{"av":"AV40TFClienteTaxasTipoTarifa_SelsJson","fld":"vTFCLIENTETAXASTIPOTARIFA_SELSJSON","type":"vchar"},{"av":"AV32TFClienteTaxasTipo_SelsJson","fld":"vTFCLIENTETAXASTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV56GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV29ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18A02","iparms":[{"av":"A1008ClienteTaxasId","fld":"CLIENTETAXASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19A02","iparms":[{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV32TFClienteTaxasTipo_SelsJson","fld":"vTFCLIENTETAXASTIPO_SELSJSON","type":"vchar"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV40TFClienteTaxasTipoTarifa_SelsJson","fld":"vTFCLIENTETAXASTIPOTARIFA_SELSJSON","type":"vchar"},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV46DDO_ClienteTaxasCreatedAtAuxDate","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATE","type":"date"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51DDO_ClienteTaxasUpdatedAtAuxDate","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV47DDO_ClienteTaxasCreatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATETO","type":"date"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52DDO_ClienteTaxasUpdatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATETO","type":"date"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavClientetaxastipo1"},{"av":"AV17ClienteTaxasTipo1","fld":"vCLIENTETAXASTIPO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV19DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavClientetaxastipo2"},{"av":"AV20ClienteTaxasTipo2","fld":"vCLIENTETAXASTIPO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV22DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavClientetaxastipo3"},{"av":"AV23ClienteTaxasTipo3","fld":"vCLIENTETAXASTIPO3","type":"svchar"},{"av":"AV31ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV18DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV21DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFClienteTaxasTipo_Sels","fld":"vTFCLIENTETAXASTIPO_SELS","type":""},{"av":"AV34TFClienteTaxasEfetiva","fld":"vTFCLIENTETAXASEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV35TFClienteTaxasEfetiva_To","fld":"vTFCLIENTETAXASEFETIVA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV36TFClienteTaxasMora","fld":"vTFCLIENTETAXASMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV37TFClienteTaxasMora_To","fld":"vTFCLIENTETAXASMORA_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV38TFClienteTaxasFator","fld":"vTFCLIENTETAXASFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV39TFClienteTaxasFator_To","fld":"vTFCLIENTETAXASFATOR_TO","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","type":"decimal"},{"av":"AV41TFClienteTaxasTipoTarifa_Sels","fld":"vTFCLIENTETAXASTIPOTARIFA_SELS","type":""},{"av":"AV42TFClienteTaxasTarifa","fld":"vTFCLIENTETAXASTARIFA","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV43TFClienteTaxasTarifa_To","fld":"vTFCLIENTETAXASTARIFA_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV44TFClienteTaxasCreatedAt","fld":"vTFCLIENTETAXASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV45TFClienteTaxasCreatedAt_To","fld":"vTFCLIENTETAXASCREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV49TFClienteTaxasUpdatedAt","fld":"vTFCLIENTETAXASUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV50TFClienteTaxasUpdatedAt_To","fld":"vTFCLIENTETAXASUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV25DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV24DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV51DDO_ClienteTaxasUpdatedAtAuxDate","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATE","type":"date"},{"av":"AV52DDO_ClienteTaxasUpdatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASUPDATEDATAUXDATETO","type":"date"},{"av":"AV46DDO_ClienteTaxasCreatedAtAuxDate","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATE","type":"date"},{"av":"AV47DDO_ClienteTaxasCreatedAtAuxDateTo","fld":"vDDO_CLIENTETAXASCREATEDATAUXDATETO","type":"date"},{"av":"AV40TFClienteTaxasTipoTarifa_SelsJson","fld":"vTFCLIENTETAXASTIPOTARIFA_SELSJSON","type":"vchar"},{"av":"AV32TFClienteTaxasTipo_SelsJson","fld":"vTFCLIENTETAXASTIPO_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"}]}""");
         setEventMetadata("VALIDV_CLIENTETAXASTIPO1","""{"handler":"Validv_Clientetaxastipo1","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTETAXASTIPO2","""{"handler":"Validv_Clientetaxastipo2","iparms":[]}""");
         setEventMetadata("VALIDV_CLIENTETAXASTIPO3","""{"handler":"Validv_Clientetaxastipo3","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Clientetaxasupdatedat","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV17ClienteTaxasTipo1 = "";
         AV19DynamicFiltersSelector2 = "";
         AV20ClienteTaxasTipo2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV23ClienteTaxasTipo3 = "";
         AV61Pgmname = "";
         AV33TFClienteTaxasTipo_Sels = new GxSimpleCollection<string>();
         AV41TFClienteTaxasTipoTarifa_Sels = new GxSimpleCollection<string>();
         AV44TFClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         AV45TFClienteTaxasCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV49TFClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AV50TFClienteTaxasUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV29ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58GridAppliedFilters = "";
         AV54DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV46DDO_ClienteTaxasCreatedAtAuxDate = DateTime.MinValue;
         AV47DDO_ClienteTaxasCreatedAtAuxDateTo = DateTime.MinValue;
         AV51DDO_ClienteTaxasUpdatedAtAuxDate = DateTime.MinValue;
         AV52DDO_ClienteTaxasUpdatedAtAuxDateTo = DateTime.MinValue;
         AV32TFClienteTaxasTipo_SelsJson = "";
         AV40TFClienteTaxasTipoTarifa_SelsJson = "";
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
         AV48DDO_ClienteTaxasCreatedAtAuxDateText = "";
         ucTfclientetaxascreatedat_rangepicker = new GXUserControl();
         AV53DDO_ClienteTaxasUpdatedAtAuxDateText = "";
         ucTfclientetaxasupdatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV59Update = "";
         A1009ClienteTaxasTipo = "";
         A1043ClienteTaxasTipoTarifa = "";
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AV71Clientetaxaswwds_10_tfclientetaxastipo_sels = new GxSimpleCollection<string>();
         AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = new GxSimpleCollection<string>();
         lV62Clientetaxaswwds_1_filterfulltext = "";
         AV62Clientetaxaswwds_1_filterfulltext = "";
         AV63Clientetaxaswwds_2_dynamicfiltersselector1 = "";
         AV64Clientetaxaswwds_3_clientetaxastipo1 = "";
         AV66Clientetaxaswwds_5_dynamicfiltersselector2 = "";
         AV67Clientetaxaswwds_6_clientetaxastipo2 = "";
         AV69Clientetaxaswwds_8_dynamicfiltersselector3 = "";
         AV70Clientetaxaswwds_9_clientetaxastipo3 = "";
         AV81Clientetaxaswwds_20_tfclientetaxascreatedat = (DateTime)(DateTime.MinValue);
         AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to = (DateTime)(DateTime.MinValue);
         AV83Clientetaxaswwds_22_tfclientetaxasupdatedat = (DateTime)(DateTime.MinValue);
         AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to = (DateTime)(DateTime.MinValue);
         H00A02_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A02_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         H00A02_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A02_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         H00A02_A1044ClienteTaxasTarifa = new decimal[1] ;
         H00A02_n1044ClienteTaxasTarifa = new bool[] {false} ;
         H00A02_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         H00A02_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         H00A02_A1042ClienteTaxasFator = new decimal[1] ;
         H00A02_n1042ClienteTaxasFator = new bool[] {false} ;
         H00A02_A1041ClienteTaxasMora = new decimal[1] ;
         H00A02_n1041ClienteTaxasMora = new bool[] {false} ;
         H00A02_A1040ClienteTaxasEfetiva = new decimal[1] ;
         H00A02_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         H00A02_A1009ClienteTaxasTipo = new string[] {""} ;
         H00A02_n1009ClienteTaxasTipo = new bool[] {false} ;
         H00A02_A1008ClienteTaxasId = new int[1] ;
         H00A03_AGRID_nRecordCount = new long[1] ;
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
         AV30ManageFiltersXml = "";
         AV26ExcelFilename = "";
         AV27ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV28Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV60AuxText = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientetaxasww__default(),
            new Object[][] {
                new Object[] {
               H00A02_A1046ClienteTaxasUpdatedAt, H00A02_n1046ClienteTaxasUpdatedAt, H00A02_A1045ClienteTaxasCreatedAt, H00A02_n1045ClienteTaxasCreatedAt, H00A02_A1044ClienteTaxasTarifa, H00A02_n1044ClienteTaxasTarifa, H00A02_A1043ClienteTaxasTipoTarifa, H00A02_n1043ClienteTaxasTipoTarifa, H00A02_A1042ClienteTaxasFator, H00A02_n1042ClienteTaxasFator,
               H00A02_A1041ClienteTaxasMora, H00A02_n1041ClienteTaxasMora, H00A02_A1040ClienteTaxasEfetiva, H00A02_n1040ClienteTaxasEfetiva, H00A02_A1009ClienteTaxasTipo, H00A02_n1009ClienteTaxasTipo, H00A02_A1008ClienteTaxasId
               }
               , new Object[] {
               H00A03_AGRID_nRecordCount
               }
            }
         );
         AV61Pgmname = "ClienteTaxasWW";
         /* GeneXus formulas. */
         AV61Pgmname = "ClienteTaxasWW";
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV31ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
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
      private int nRC_GXsfl_98 ;
      private int nGXsfl_98_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A1008ClienteTaxasId ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV71Clientetaxaswwds_10_tfclientetaxastipo_sels_Count ;
      private int AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count ;
      private int edtClienteTaxasId_Enabled ;
      private int edtClienteTaxasEfetiva_Enabled ;
      private int edtClienteTaxasMora_Enabled ;
      private int edtClienteTaxasFator_Enabled ;
      private int edtClienteTaxasTarifa_Enabled ;
      private int edtClienteTaxasCreatedAt_Enabled ;
      private int edtClienteTaxasUpdatedAt_Enabled ;
      private int AV55PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV85GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV56GridCurrentPage ;
      private long AV57GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV34TFClienteTaxasEfetiva ;
      private decimal AV35TFClienteTaxasEfetiva_To ;
      private decimal AV36TFClienteTaxasMora ;
      private decimal AV37TFClienteTaxasMora_To ;
      private decimal AV38TFClienteTaxasFator ;
      private decimal AV39TFClienteTaxasFator_To ;
      private decimal AV42TFClienteTaxasTarifa ;
      private decimal AV43TFClienteTaxasTarifa_To ;
      private decimal A1040ClienteTaxasEfetiva ;
      private decimal A1041ClienteTaxasMora ;
      private decimal A1042ClienteTaxasFator ;
      private decimal A1044ClienteTaxasTarifa ;
      private decimal AV72Clientetaxaswwds_11_tfclientetaxasefetiva ;
      private decimal AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to ;
      private decimal AV74Clientetaxaswwds_13_tfclientetaxasmora ;
      private decimal AV75Clientetaxaswwds_14_tfclientetaxasmora_to ;
      private decimal AV76Clientetaxaswwds_15_tfclientetaxasfator ;
      private decimal AV77Clientetaxaswwds_16_tfclientetaxasfator_to ;
      private decimal AV79Clientetaxaswwds_18_tfclientetaxastarifa ;
      private decimal AV80Clientetaxaswwds_19_tfclientetaxastarifa_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_98_idx="0001" ;
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
      private string divDdo_clientetaxascreatedatauxdates_Internalname ;
      private string edtavDdo_clientetaxascreatedatauxdatetext_Internalname ;
      private string edtavDdo_clientetaxascreatedatauxdatetext_Jsonclick ;
      private string Tfclientetaxascreatedat_rangepicker_Internalname ;
      private string divDdo_clientetaxasupdatedatauxdates_Internalname ;
      private string edtavDdo_clientetaxasupdatedatauxdatetext_Internalname ;
      private string edtavDdo_clientetaxasupdatedatauxdatetext_Jsonclick ;
      private string Tfclientetaxasupdatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV59Update ;
      private string edtavUpdate_Internalname ;
      private string edtClienteTaxasId_Internalname ;
      private string cmbClienteTaxasTipo_Internalname ;
      private string edtClienteTaxasEfetiva_Internalname ;
      private string edtClienteTaxasMora_Internalname ;
      private string edtClienteTaxasFator_Internalname ;
      private string cmbClienteTaxasTipoTarifa_Internalname ;
      private string edtClienteTaxasTarifa_Internalname ;
      private string edtClienteTaxasCreatedAt_Internalname ;
      private string edtClienteTaxasUpdatedAt_Internalname ;
      private string cmbavClientetaxastipo1_Internalname ;
      private string cmbavClientetaxastipo2_Internalname ;
      private string cmbavClientetaxastipo3_Internalname ;
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
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_clientetaxastipo3_cell_Internalname ;
      private string cmbavClientetaxastipo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_clientetaxastipo2_cell_Internalname ;
      private string cmbavClientetaxastipo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_clientetaxastipo1_cell_Internalname ;
      private string cmbavClientetaxastipo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_98_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtClienteTaxasId_Jsonclick ;
      private string GXCCtl ;
      private string cmbClienteTaxasTipo_Jsonclick ;
      private string edtClienteTaxasEfetiva_Jsonclick ;
      private string edtClienteTaxasMora_Jsonclick ;
      private string edtClienteTaxasFator_Jsonclick ;
      private string cmbClienteTaxasTipoTarifa_Jsonclick ;
      private string edtClienteTaxasTarifa_Jsonclick ;
      private string edtClienteTaxasCreatedAt_Jsonclick ;
      private string edtClienteTaxasUpdatedAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV44TFClienteTaxasCreatedAt ;
      private DateTime AV45TFClienteTaxasCreatedAt_To ;
      private DateTime AV49TFClienteTaxasUpdatedAt ;
      private DateTime AV50TFClienteTaxasUpdatedAt_To ;
      private DateTime A1045ClienteTaxasCreatedAt ;
      private DateTime A1046ClienteTaxasUpdatedAt ;
      private DateTime AV81Clientetaxaswwds_20_tfclientetaxascreatedat ;
      private DateTime AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to ;
      private DateTime AV83Clientetaxaswwds_22_tfclientetaxasupdatedat ;
      private DateTime AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to ;
      private DateTime AV46DDO_ClienteTaxasCreatedAtAuxDate ;
      private DateTime AV47DDO_ClienteTaxasCreatedAtAuxDateTo ;
      private DateTime AV51DDO_ClienteTaxasUpdatedAtAuxDate ;
      private DateTime AV52DDO_ClienteTaxasUpdatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV25DynamicFiltersIgnoreFirst ;
      private bool AV24DynamicFiltersRemoving ;
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
      private bool n1009ClienteTaxasTipo ;
      private bool n1040ClienteTaxasEfetiva ;
      private bool n1041ClienteTaxasMora ;
      private bool n1042ClienteTaxasFator ;
      private bool n1043ClienteTaxasTipoTarifa ;
      private bool n1044ClienteTaxasTarifa ;
      private bool n1045ClienteTaxasCreatedAt ;
      private bool n1046ClienteTaxasUpdatedAt ;
      private bool bGXsfl_98_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV65Clientetaxaswwds_4_dynamicfiltersenabled2 ;
      private bool AV68Clientetaxaswwds_7_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV32TFClienteTaxasTipo_SelsJson ;
      private string AV40TFClienteTaxasTipoTarifa_SelsJson ;
      private string AV30ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV17ClienteTaxasTipo1 ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV20ClienteTaxasTipo2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV23ClienteTaxasTipo3 ;
      private string AV58GridAppliedFilters ;
      private string AV48DDO_ClienteTaxasCreatedAtAuxDateText ;
      private string AV53DDO_ClienteTaxasUpdatedAtAuxDateText ;
      private string A1009ClienteTaxasTipo ;
      private string A1043ClienteTaxasTipoTarifa ;
      private string lV62Clientetaxaswwds_1_filterfulltext ;
      private string AV62Clientetaxaswwds_1_filterfulltext ;
      private string AV63Clientetaxaswwds_2_dynamicfiltersselector1 ;
      private string AV64Clientetaxaswwds_3_clientetaxastipo1 ;
      private string AV66Clientetaxaswwds_5_dynamicfiltersselector2 ;
      private string AV67Clientetaxaswwds_6_clientetaxastipo2 ;
      private string AV69Clientetaxaswwds_8_dynamicfiltersselector3 ;
      private string AV70Clientetaxaswwds_9_clientetaxastipo3 ;
      private string AV26ExcelFilename ;
      private string AV27ErrorMessage ;
      private string AV60AuxText ;
      private IGxSession AV28Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfclientetaxascreatedat_rangepicker ;
      private GXUserControl ucTfclientetaxasupdatedat_rangepicker ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavClientetaxastipo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavClientetaxastipo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavClientetaxastipo3 ;
      private GXCombobox cmbClienteTaxasTipo ;
      private GXCombobox cmbClienteTaxasTipoTarifa ;
      private GxSimpleCollection<string> AV33TFClienteTaxasTipo_Sels ;
      private GxSimpleCollection<string> AV41TFClienteTaxasTipoTarifa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV29ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV54DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV71Clientetaxaswwds_10_tfclientetaxastipo_sels ;
      private GxSimpleCollection<string> AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00A02_A1046ClienteTaxasUpdatedAt ;
      private bool[] H00A02_n1046ClienteTaxasUpdatedAt ;
      private DateTime[] H00A02_A1045ClienteTaxasCreatedAt ;
      private bool[] H00A02_n1045ClienteTaxasCreatedAt ;
      private decimal[] H00A02_A1044ClienteTaxasTarifa ;
      private bool[] H00A02_n1044ClienteTaxasTarifa ;
      private string[] H00A02_A1043ClienteTaxasTipoTarifa ;
      private bool[] H00A02_n1043ClienteTaxasTipoTarifa ;
      private decimal[] H00A02_A1042ClienteTaxasFator ;
      private bool[] H00A02_n1042ClienteTaxasFator ;
      private decimal[] H00A02_A1041ClienteTaxasMora ;
      private bool[] H00A02_n1041ClienteTaxasMora ;
      private decimal[] H00A02_A1040ClienteTaxasEfetiva ;
      private bool[] H00A02_n1040ClienteTaxasEfetiva ;
      private string[] H00A02_A1009ClienteTaxasTipo ;
      private bool[] H00A02_n1009ClienteTaxasTipo ;
      private int[] H00A02_A1008ClienteTaxasId ;
      private long[] H00A03_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clientetaxasww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A02( IGxContext context ,
                                             string A1009ClienteTaxasTipo ,
                                             GxSimpleCollection<string> AV71Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                             string A1043ClienteTaxasTipoTarifa ,
                                             GxSimpleCollection<string> AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                             string AV62Clientetaxaswwds_1_filterfulltext ,
                                             string AV63Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                             string AV64Clientetaxaswwds_3_clientetaxastipo1 ,
                                             bool AV65Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                             string AV66Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                             string AV67Clientetaxaswwds_6_clientetaxastipo2 ,
                                             bool AV68Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                             string AV69Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                             string AV70Clientetaxaswwds_9_clientetaxastipo3 ,
                                             int AV71Clientetaxaswwds_10_tfclientetaxastipo_sels_Count ,
                                             decimal AV72Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                             decimal AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                             decimal AV74Clientetaxaswwds_13_tfclientetaxasmora ,
                                             decimal AV75Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                             decimal AV76Clientetaxaswwds_15_tfclientetaxasfator ,
                                             decimal AV77Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                             int AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count ,
                                             decimal AV79Clientetaxaswwds_18_tfclientetaxastarifa ,
                                             decimal AV80Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                             DateTime AV81Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                             DateTime AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                             DateTime AV83Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                             DateTime AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                             decimal A1040ClienteTaxasEfetiva ,
                                             decimal A1041ClienteTaxasMora ,
                                             decimal A1042ClienteTaxasFator ,
                                             decimal A1044ClienteTaxasTarifa ,
                                             DateTime A1045ClienteTaxasCreatedAt ,
                                             DateTime A1046ClienteTaxasUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ClienteTaxasUpdatedAt, ClienteTaxasCreatedAt, ClienteTaxasTarifa, ClienteTaxasTipoTarifa, ClienteTaxasFator, ClienteTaxasMora, ClienteTaxasEfetiva, ClienteTaxasTipo, ClienteTaxasId";
         sFromString = " FROM ClienteTaxas";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'sem risco' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'SEM_RISCO')) or ( 'risco baixo' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'BAIXO')) or ( 'risco alto' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'ALTO')) or ( 'cliente premium' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'PREMIUM')) or ( SUBSTR(TO_CHAR(ClienteTaxasEfetiva,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasMora,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasFator,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( 'percentual' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'P')) or ( 'valor' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'V')) or ( SUBSTR(TO_CHAR(ClienteTaxasTarifa,'999999999990.99'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Clientetaxaswwds_2_dynamicfiltersselector1, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clientetaxaswwds_3_clientetaxastipo1)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV64Clientetaxaswwds_3_clientetaxastipo1))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV65Clientetaxaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Clientetaxaswwds_5_dynamicfiltersselector2, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Clientetaxaswwds_6_clientetaxastipo2)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV67Clientetaxaswwds_6_clientetaxastipo2))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV68Clientetaxaswwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Clientetaxaswwds_8_dynamicfiltersselector3, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Clientetaxaswwds_9_clientetaxastipo3)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV70Clientetaxaswwds_9_clientetaxastipo3))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV71Clientetaxaswwds_10_tfclientetaxastipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Clientetaxaswwds_10_tfclientetaxastipo_sels, "ClienteTaxasTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV72Clientetaxaswwds_11_tfclientetaxasefetiva) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva >= :AV72Clientetaxaswwds_11_tfclientetaxasefetiva)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva <= :AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Clientetaxaswwds_13_tfclientetaxasmora) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora >= :AV74Clientetaxaswwds_13_tfclientetaxasmora)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Clientetaxaswwds_14_tfclientetaxasmora_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora <= :AV75Clientetaxaswwds_14_tfclientetaxasmora_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Clientetaxaswwds_15_tfclientetaxasfator) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator >= :AV76Clientetaxaswwds_15_tfclientetaxasfator)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Clientetaxaswwds_16_tfclientetaxasfator_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator <= :AV77Clientetaxaswwds_16_tfclientetaxasfator_to)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels, "ClienteTaxasTipoTarifa IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Clientetaxaswwds_18_tfclientetaxastarifa) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa >= :AV79Clientetaxaswwds_18_tfclientetaxastarifa)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Clientetaxaswwds_19_tfclientetaxastarifa_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa <= :AV80Clientetaxaswwds_19_tfclientetaxastarifa_to)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Clientetaxaswwds_20_tfclientetaxascreatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt >= :AV81Clientetaxaswwds_20_tfclientetaxascreatedat)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt <= :AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Clientetaxaswwds_22_tfclientetaxasupdatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt >= :AV83Clientetaxaswwds_22_tfclientetaxasupdatedat)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt <= :AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasTipo";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasTipo DESC";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasEfetiva, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasEfetiva DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasMora, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasMora DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasFator, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasFator DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasTipoTarifa, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasTipoTarifa DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasTarifa, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasTarifa DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasCreatedAt, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasCreatedAt DESC, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ClienteTaxasUpdatedAt, ClienteTaxasId";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ClienteTaxasUpdatedAt DESC, ClienteTaxasId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY ClienteTaxasId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00A03( IGxContext context ,
                                             string A1009ClienteTaxasTipo ,
                                             GxSimpleCollection<string> AV71Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                             string A1043ClienteTaxasTipoTarifa ,
                                             GxSimpleCollection<string> AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                             string AV62Clientetaxaswwds_1_filterfulltext ,
                                             string AV63Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                             string AV64Clientetaxaswwds_3_clientetaxastipo1 ,
                                             bool AV65Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                             string AV66Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                             string AV67Clientetaxaswwds_6_clientetaxastipo2 ,
                                             bool AV68Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                             string AV69Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                             string AV70Clientetaxaswwds_9_clientetaxastipo3 ,
                                             int AV71Clientetaxaswwds_10_tfclientetaxastipo_sels_Count ,
                                             decimal AV72Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                             decimal AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                             decimal AV74Clientetaxaswwds_13_tfclientetaxasmora ,
                                             decimal AV75Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                             decimal AV76Clientetaxaswwds_15_tfclientetaxasfator ,
                                             decimal AV77Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                             int AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count ,
                                             decimal AV79Clientetaxaswwds_18_tfclientetaxastarifa ,
                                             decimal AV80Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                             DateTime AV81Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                             DateTime AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                             DateTime AV83Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                             DateTime AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                             decimal A1040ClienteTaxasEfetiva ,
                                             decimal A1041ClienteTaxasMora ,
                                             decimal A1042ClienteTaxasFator ,
                                             decimal A1044ClienteTaxasTarifa ,
                                             DateTime A1045ClienteTaxasCreatedAt ,
                                             DateTime A1046ClienteTaxasUpdatedAt ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[25];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ClienteTaxas";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Clientetaxaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'sem risco' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'SEM_RISCO')) or ( 'risco baixo' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'BAIXO')) or ( 'risco alto' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'ALTO')) or ( 'cliente premium' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'PREMIUM')) or ( SUBSTR(TO_CHAR(ClienteTaxasEfetiva,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasMora,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasFator,'99999999990.9999'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext) or ( 'percentual' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'P')) or ( 'valor' like '%' || LOWER(:lV62Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'V')) or ( SUBSTR(TO_CHAR(ClienteTaxasTarifa,'999999999990.99'), 2) like '%' || :lV62Clientetaxaswwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Clientetaxaswwds_2_dynamicfiltersselector1, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clientetaxaswwds_3_clientetaxastipo1)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV64Clientetaxaswwds_3_clientetaxastipo1))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV65Clientetaxaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Clientetaxaswwds_5_dynamicfiltersselector2, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Clientetaxaswwds_6_clientetaxastipo2)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV67Clientetaxaswwds_6_clientetaxastipo2))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV68Clientetaxaswwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Clientetaxaswwds_8_dynamicfiltersselector3, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Clientetaxaswwds_9_clientetaxastipo3)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV70Clientetaxaswwds_9_clientetaxastipo3))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV71Clientetaxaswwds_10_tfclientetaxastipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV71Clientetaxaswwds_10_tfclientetaxastipo_sels, "ClienteTaxasTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV72Clientetaxaswwds_11_tfclientetaxasefetiva) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva >= :AV72Clientetaxaswwds_11_tfclientetaxasefetiva)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva <= :AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV74Clientetaxaswwds_13_tfclientetaxasmora) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora >= :AV74Clientetaxaswwds_13_tfclientetaxasmora)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Clientetaxaswwds_14_tfclientetaxasmora_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora <= :AV75Clientetaxaswwds_14_tfclientetaxasmora_to)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Clientetaxaswwds_15_tfclientetaxasfator) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator >= :AV76Clientetaxaswwds_15_tfclientetaxasfator)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Clientetaxaswwds_16_tfclientetaxasfator_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator <= :AV77Clientetaxaswwds_16_tfclientetaxasfator_to)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Clientetaxaswwds_17_tfclientetaxastipotarifa_sels, "ClienteTaxasTipoTarifa IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Clientetaxaswwds_18_tfclientetaxastarifa) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa >= :AV79Clientetaxaswwds_18_tfclientetaxastarifa)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Clientetaxaswwds_19_tfclientetaxastarifa_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa <= :AV80Clientetaxaswwds_19_tfclientetaxastarifa_to)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Clientetaxaswwds_20_tfclientetaxascreatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt >= :AV81Clientetaxaswwds_20_tfclientetaxascreatedat)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt <= :AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Clientetaxaswwds_22_tfclientetaxasupdatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt >= :AV83Clientetaxaswwds_22_tfclientetaxasupdatedat)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt <= :AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to)");
         }
         else
         {
            GXv_int7[24] = 1;
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
         else if ( ( AV13OrderedBy == 6 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 6 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 7 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 8 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00A02(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
               case 1 :
                     return conditional_H00A03(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmH00A02;
          prmH00A02 = new Object[] {
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Clientetaxaswwds_3_clientetaxastipo1",GXType.VarChar,40,0) ,
          new ParDef("AV67Clientetaxaswwds_6_clientetaxastipo2",GXType.VarChar,40,0) ,
          new ParDef("AV70Clientetaxaswwds_9_clientetaxastipo3",GXType.VarChar,40,0) ,
          new ParDef("AV72Clientetaxaswwds_11_tfclientetaxasefetiva",GXType.Number,16,4) ,
          new ParDef("AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV74Clientetaxaswwds_13_tfclientetaxasmora",GXType.Number,16,4) ,
          new ParDef("AV75Clientetaxaswwds_14_tfclientetaxasmora_to",GXType.Number,16,4) ,
          new ParDef("AV76Clientetaxaswwds_15_tfclientetaxasfator",GXType.Number,16,4) ,
          new ParDef("AV77Clientetaxaswwds_16_tfclientetaxasfator_to",GXType.Number,16,4) ,
          new ParDef("AV79Clientetaxaswwds_18_tfclientetaxastarifa",GXType.Number,15,2) ,
          new ParDef("AV80Clientetaxaswwds_19_tfclientetaxastarifa_to",GXType.Number,15,2) ,
          new ParDef("AV81Clientetaxaswwds_20_tfclientetaxascreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV83Clientetaxaswwds_22_tfclientetaxasupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A03;
          prmH00A03 = new Object[] {
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Clientetaxaswwds_3_clientetaxastipo1",GXType.VarChar,40,0) ,
          new ParDef("AV67Clientetaxaswwds_6_clientetaxastipo2",GXType.VarChar,40,0) ,
          new ParDef("AV70Clientetaxaswwds_9_clientetaxastipo3",GXType.VarChar,40,0) ,
          new ParDef("AV72Clientetaxaswwds_11_tfclientetaxasefetiva",GXType.Number,16,4) ,
          new ParDef("AV73Clientetaxaswwds_12_tfclientetaxasefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV74Clientetaxaswwds_13_tfclientetaxasmora",GXType.Number,16,4) ,
          new ParDef("AV75Clientetaxaswwds_14_tfclientetaxasmora_to",GXType.Number,16,4) ,
          new ParDef("AV76Clientetaxaswwds_15_tfclientetaxasfator",GXType.Number,16,4) ,
          new ParDef("AV77Clientetaxaswwds_16_tfclientetaxasfator_to",GXType.Number,16,4) ,
          new ParDef("AV79Clientetaxaswwds_18_tfclientetaxastarifa",GXType.Number,15,2) ,
          new ParDef("AV80Clientetaxaswwds_19_tfclientetaxastarifa_to",GXType.Number,15,2) ,
          new ParDef("AV81Clientetaxaswwds_20_tfclientetaxascreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Clientetaxaswwds_21_tfclientetaxascreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV83Clientetaxaswwds_22_tfclientetaxasupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV84Clientetaxaswwds_23_tfclientetaxasupdatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00A02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A02,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A03,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
