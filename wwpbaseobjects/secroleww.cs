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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secroleww : GXDataArea
   {
      public secroleww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secroleww( IGxContext context )
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
         AV44OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV45OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV93FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV46DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV47DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV48SecRoleName1 = GetPar( "SecRoleName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV51DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV52DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV53SecRoleName2 = GetPar( "SecRoleName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV56DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV57DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV58SecRoleName3 = GetPar( "SecRoleName3");
         AV64ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV99Pgmname = GetPar( "Pgmname");
         AV50DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV55DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV71TFSecRoleName = GetPar( "TFSecRoleName");
         AV72TFSecRoleName_Sel = GetPar( "TFSecRoleName_Sel");
         AV75TFSecRoleDescription = GetPar( "TFSecRoleDescription");
         AV76TFSecRoleDescription_Sel = GetPar( "TFSecRoleDescription_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41GridState);
         AV61DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV60DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
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
         PA2E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2E2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secroleww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV45OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV93FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV46DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME1", AV48SecRoleName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV51DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME2", AV53SecRoleName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV56DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME3", AV58SecRoleName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_109", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_109), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV68ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV68ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV90GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV91GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV78DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV78DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV64ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV50DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV55DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFSECROLENAME", AV71TFSecRoleName);
         GxWebStd.gx_hidden_field( context, "vTFSECROLENAME_SEL", AV72TFSecRoleName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECROLEDESCRIPTION", AV75TFSecRoleDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECROLEDESCRIPTION_SEL", AV76TFSecRoleDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV45OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV41GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV41GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV61DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV60DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
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
            WE2E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2E2( ) ;
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
         return formatLink("wwpbaseobjects.secroleww")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecRoleWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Role" ;
      }

      protected void WB2E0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV68ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV93FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV93FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecRoleWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV46DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_2E2( true) ;
         }
         else
         {
            wb_table1_47_2E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_2E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV51DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_69_2E2( true) ;
         }
         else
         {
            wb_table2_69_2E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_2E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV56DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_91_2E2( true) ;
         }
         else
         {
            wb_table3_91_2E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_91_2E2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV89GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV90GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV91GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SecRoleWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV78DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void START2E2( )
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
         Form.Meta.addItem("description", " Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2E0( ) ;
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                              E112E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E142E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E152E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E162E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E172E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E182E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E202E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E212E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E222E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E232E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E242E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E252E2 ();
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
                              AV94Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV94Display);
                              AV13Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
                              AV97usuarioxperfil = cgiGet( edtavUsuarioxperfil_Internalname);
                              AssignAttri("", false, edtavUsuarioxperfil_Internalname, AV97usuarioxperfil);
                              AV98AddFunc = cgiGet( edtavAddfunc_Internalname);
                              AssignAttri("", false, edtavAddfunc_Internalname, AV98AddFunc);
                              A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A140SecRoleName = cgiGet( edtSecRoleName_Internalname);
                              A139SecRoleDescription = cgiGet( edtSecRoleDescription_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E262E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E272E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E282E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV44OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV45OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV93FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV46DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV47DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME1"), AV48SecRoleName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV51DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV52DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME2"), AV53SecRoleName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV56DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV57DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME3"), AV58SecRoleName3) != 0 )
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

      protected void WE2E2( )
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

      protected void PA2E2( )
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
                                       short AV44OrderedBy ,
                                       bool AV45OrderedDsc ,
                                       string AV93FilterFullText ,
                                       string AV46DynamicFiltersSelector1 ,
                                       short AV47DynamicFiltersOperator1 ,
                                       string AV48SecRoleName1 ,
                                       string AV51DynamicFiltersSelector2 ,
                                       short AV52DynamicFiltersOperator2 ,
                                       string AV53SecRoleName2 ,
                                       string AV56DynamicFiltersSelector3 ,
                                       short AV57DynamicFiltersOperator3 ,
                                       string AV58SecRoleName3 ,
                                       short AV64ManageFiltersExecutionStep ,
                                       string AV99Pgmname ,
                                       bool AV50DynamicFiltersEnabled2 ,
                                       bool AV55DynamicFiltersEnabled3 ,
                                       string AV71TFSecRoleName ,
                                       string AV72TFSecRoleName_Sel ,
                                       string AV75TFSecRoleDescription ,
                                       string AV76TFSecRoleDescription_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ,
                                       bool AV61DynamicFiltersIgnoreFirst ,
                                       bool AV60DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ".", "")));
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
            AV46DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV46DynamicFiltersSelector1);
            AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV47DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV47DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV51DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV51DynamicFiltersSelector2);
            AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV52DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV56DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV56DynamicFiltersSelector3);
            AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV57DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV57DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV99Pgmname = "WWPBaseObjects.SecRoleWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUsuarioxperfil_Enabled = 0;
         edtavAddfunc_Enabled = 0;
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E272E2 ();
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
                                                 AV100Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                                 AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                                 AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                                 AV103Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                                 AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                                 AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                                 AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                                 AV107Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                                 AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                                 AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                                 AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                                 AV111Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                                 AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                                 AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                                 AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                                 AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                                 A140SecRoleName ,
                                                 A139SecRoleDescription ,
                                                 AV44OrderedBy ,
                                                 AV45OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV100Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
            lV100Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
            lV103Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
            lV103Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
            lV107Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
            lV107Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
            lV111Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
            lV111Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
            lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
            lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
            /* Using cursor H002E2 */
            pr_default.execute(0, new Object[] {lV100Wwpbaseobjects_secrolewwds_1_filterfulltext, lV100Wwpbaseobjects_secrolewwds_1_filterfulltext, lV103Wwpbaseobjects_secrolewwds_4_secrolename1, lV103Wwpbaseobjects_secrolewwds_4_secrolename1, lV107Wwpbaseobjects_secrolewwds_8_secrolename2, lV107Wwpbaseobjects_secrolewwds_8_secrolename2, lV111Wwpbaseobjects_secrolewwds_12_secrolename3, lV111Wwpbaseobjects_secrolewwds_12_secrolename3, lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_109_idx = 1;
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A139SecRoleDescription = H002E2_A139SecRoleDescription[0];
               A140SecRoleName = H002E2_A140SecRoleName[0];
               A131SecRoleId = H002E2_A131SecRoleId[0];
               /* Execute user event: Grid.Load */
               E282E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 109;
            WB2E0( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECROLEID"+"_"+sGXsfl_109_idx, GetSecureSignedToken( sGXsfl_109_idx, context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"), context));
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
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV100Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                              AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                              AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                              AV103Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                              AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                              AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                              AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                              AV107Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                              AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                              AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                              AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                              AV111Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                              AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                              AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                              AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                              AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                              A140SecRoleName ,
                                              A139SecRoleDescription ,
                                              AV44OrderedBy ,
                                              AV45OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV100Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV100Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV103Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV103Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV107Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV107Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV111Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV111Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
         lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
         /* Using cursor H002E3 */
         pr_default.execute(1, new Object[] {lV100Wwpbaseobjects_secrolewwds_1_filterfulltext, lV100Wwpbaseobjects_secrolewwds_1_filterfulltext, lV103Wwpbaseobjects_secrolewwds_4_secrolename1, lV103Wwpbaseobjects_secrolewwds_4_secrolename1, lV107Wwpbaseobjects_secrolewwds_8_secrolename2, lV107Wwpbaseobjects_secrolewwds_8_secrolename2, lV111Wwpbaseobjects_secrolewwds_12_secrolename3, lV111Wwpbaseobjects_secrolewwds_12_secrolename3, lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel});
         GRID_nRecordCount = H002E3_AGRID_nRecordCount[0];
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
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV99Pgmname = "WWPBaseObjects.SecRoleWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUsuarioxperfil_Enabled = 0;
         edtavAddfunc_Enabled = 0;
         edtSecRoleId_Enabled = 0;
         edtSecRoleName_Enabled = 0;
         edtSecRoleDescription_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E262E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV68ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV78DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_109"), ",", "."), 18, MidpointRounding.ToEven));
            AV89GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV90GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV91GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
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
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV93FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV93FilterFullText", AV93FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV46DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV47DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV47DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
            AV48SecRoleName1 = cgiGet( edtavSecrolename1_Internalname);
            AssignAttri("", false, "AV48SecRoleName1", AV48SecRoleName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV51DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV52DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
            AV53SecRoleName2 = cgiGet( edtavSecrolename2_Internalname);
            AssignAttri("", false, "AV53SecRoleName2", AV53SecRoleName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV56DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV57DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV57DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
            AV58SecRoleName3 = cgiGet( edtavSecrolename3_Internalname);
            AssignAttri("", false, "AV58SecRoleName3", AV58SecRoleName3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV44OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV45OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV93FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV46DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV47DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME1"), AV48SecRoleName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV51DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV52DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME2"), AV53SecRoleName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV56DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV57DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME3"), AV58SecRoleName3) != 0 )
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
         E262E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E262E2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
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
         AV46DynamicFiltersSelector1 = "SECROLENAME";
         AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV51DynamicFiltersSelector2 = "SECROLENAME";
         AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV56DynamicFiltersSelector3 = "SECROLENAME";
         AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
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
         Form.Caption = " Role";
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
         if ( AV44OrderedBy < 1 )
         {
            AV44OrderedBy = 1;
            AssignAttri("", false, "AV44OrderedBy", StringUtil.LTrimStr( (decimal)(AV44OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV78DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV78DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E272E2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV87WWPContext) ;
         if ( AV64ManageFiltersExecutionStep == 1 )
         {
            AV64ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV64ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV64ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV64ManageFiltersExecutionStep == 2 )
         {
            AV64ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV64ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV64ManageFiltersExecutionStep), 1, 0));
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
         AV89GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV89GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV89GridCurrentPage), 10, 0));
         AV90GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV90GridPageCount", StringUtil.LTrimStr( (decimal)(AV90GridPageCount), 10, 0));
         GXt_char2 = AV91GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV99Pgmname, out  GXt_char2) ;
         AV91GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV91GridAppliedFilters", AV91GridAppliedFilters);
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = AV93FilterFullText;
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = AV48SecRoleName1;
         AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = AV53SecRoleName2;
         AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = AV58SecRoleName3;
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV71TFSecRoleName;
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV72TFSecRoleName_Sel;
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV75TFSecRoleDescription;
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV76TFSecRoleDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ManageFiltersData", AV68ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
      }

      protected void E122E2( )
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
            AV88PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV88PageToGo) ;
         }
      }

      protected void E132E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142E2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV44OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV44OrderedBy", StringUtil.LTrimStr( (decimal)(AV44OrderedBy), 4, 0));
            AV45OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV45OrderedDsc", AV45OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecRoleName") == 0 )
            {
               AV71TFSecRoleName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV71TFSecRoleName", AV71TFSecRoleName);
               AV72TFSecRoleName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV72TFSecRoleName_Sel", AV72TFSecRoleName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecRoleDescription") == 0 )
            {
               AV75TFSecRoleDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV75TFSecRoleDescription", AV75TFSecRoleDescription);
               AV76TFSecRoleDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV76TFSecRoleDescription_Sel", AV76TFSecRoleDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E282E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV94Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV94Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrole"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavDisplay_Link = formatLink("wwpbaseobjects.secrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV13Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrole"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavUpdate_Link = formatLink("wwpbaseobjects.secrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV97usuarioxperfil = "<i class=\"fas fa-user-tag\"></i>";
         AssignAttri("", false, edtavUsuarioxperfil_Internalname, AV97usuarioxperfil);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpperfilusuario"+UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0)) + "," + UrlEncode(StringUtil.RTrim(A140SecRoleName));
         edtavUsuarioxperfil_Link = formatLink("wpperfilusuario") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV98AddFunc = "<i class=\"fa fa-lock\"></i>";
         AssignAttri("", false, edtavAddfunc_Internalname, AV98AddFunc);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpfuncionalidades"+UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtavAddfunc_Link = formatLink("wpfuncionalidades") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrole"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A131SecRoleId,4,0));
         edtSecRoleName_Link = formatLink("wwpbaseobjects.secrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E212E2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV50DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV50DynamicFiltersEnabled2", AV50DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E152E2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV60DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         AV61DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV61DynamicFiltersIgnoreFirst", AV61DynamicFiltersIgnoreFirst);
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
         AV60DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         AV61DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV61DynamicFiltersIgnoreFirst", AV61DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ManageFiltersData", AV68ManageFiltersData);
      }

      protected void E222E2( )
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

      protected void E232E2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV55DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV55DynamicFiltersEnabled3", AV55DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E162E2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV60DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         AV50DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV50DynamicFiltersEnabled2", AV50DynamicFiltersEnabled2);
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
         AV60DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ManageFiltersData", AV68ManageFiltersData);
      }

      protected void E242E2( )
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

      protected void E172E2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV60DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         AV55DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV55DynamicFiltersEnabled3", AV55DynamicFiltersEnabled3);
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
         AV60DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV60DynamicFiltersRemoving", AV60DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV44OrderedBy, AV45OrderedDsc, AV93FilterFullText, AV46DynamicFiltersSelector1, AV47DynamicFiltersOperator1, AV48SecRoleName1, AV51DynamicFiltersSelector2, AV52DynamicFiltersOperator2, AV53SecRoleName2, AV56DynamicFiltersSelector3, AV57DynamicFiltersOperator3, AV58SecRoleName3, AV64ManageFiltersExecutionStep, AV99Pgmname, AV50DynamicFiltersEnabled2, AV55DynamicFiltersEnabled3, AV71TFSecRoleName, AV72TFSecRoleName_Sel, AV75TFSecRoleDescription, AV76TFSecRoleDescription_Sel, AV41GridState, AV61DynamicFiltersIgnoreFirst, AV60DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ManageFiltersData", AV68ManageFiltersData);
      }

      protected void E252E2( )
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

      protected void E112E2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV99Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV64ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV64ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV64ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecRoleWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV64ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV64ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV64ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV65ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecRoleWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV65ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV65ManageFiltersXml) ;
               AV41GridState.FromXml(AV65ManageFiltersXml, null, "", "");
               AV44OrderedBy = AV41GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV44OrderedBy", StringUtil.LTrimStr( (decimal)(AV44OrderedBy), 4, 0));
               AV45OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV45OrderedDsc", AV45OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68ManageFiltersData", AV68ManageFiltersData);
      }

      protected void E182E2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrole"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wwpbaseobjects.secrole") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E192E2( )
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
         new GeneXus.Programs.wwpbaseobjects.secrolewwexport(context ).execute( out  AV62ExcelFilename, out  AV63ErrorMessage) ;
         if ( StringUtil.StrCmp(AV62ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV62ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV63ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E202E2( )
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
         Innewwindow1_Target = formatLink("wwpbaseobjects.asecrolewwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41GridState", AV41GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV46DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV51DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV56DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV44OrderedBy), 4, 0))+":"+(AV45OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavSecrolename1_Visible = 0;
         AssignProp("", false, edtavSecrolename1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECROLENAME") == 0 )
         {
            edtavSecrolename1_Visible = 1;
            AssignProp("", false, edtavSecrolename1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSecrolename2_Visible = 0;
         AssignProp("", false, edtavSecrolename2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECROLENAME") == 0 )
         {
            edtavSecrolename2_Visible = 1;
            AssignProp("", false, edtavSecrolename2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSecrolename3_Visible = 0;
         AssignProp("", false, edtavSecrolename3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECROLENAME") == 0 )
         {
            edtavSecrolename3_Visible = 1;
            AssignProp("", false, edtavSecrolename3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV50DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV50DynamicFiltersEnabled2", AV50DynamicFiltersEnabled2);
         AV51DynamicFiltersSelector2 = "SECROLENAME";
         AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
         AV52DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV52DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         AV53SecRoleName2 = "";
         AssignAttri("", false, "AV53SecRoleName2", AV53SecRoleName2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV55DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV55DynamicFiltersEnabled3", AV55DynamicFiltersEnabled3);
         AV56DynamicFiltersSelector3 = "SECROLENAME";
         AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
         AV57DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV57DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
         AV58SecRoleName3 = "";
         AssignAttri("", false, "AV58SecRoleName3", AV58SecRoleName3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV68ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecRoleWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV68ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV93FilterFullText = "";
         AssignAttri("", false, "AV93FilterFullText", AV93FilterFullText);
         AV71TFSecRoleName = "";
         AssignAttri("", false, "AV71TFSecRoleName", AV71TFSecRoleName);
         AV72TFSecRoleName_Sel = "";
         AssignAttri("", false, "AV72TFSecRoleName_Sel", AV72TFSecRoleName_Sel);
         AV75TFSecRoleDescription = "";
         AssignAttri("", false, "AV75TFSecRoleDescription", AV75TFSecRoleDescription);
         AV76TFSecRoleDescription_Sel = "";
         AssignAttri("", false, "AV76TFSecRoleDescription_Sel", AV76TFSecRoleDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV46DynamicFiltersSelector1 = "SECROLENAME";
         AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
         AV47DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV47DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         AV48SecRoleName1 = "";
         AssignAttri("", false, "AV48SecRoleName1", AV48SecRoleName1);
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
         AV41GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV15Session.Get(AV99Pgmname+"GridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV99Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV15Session.Get(AV99Pgmname+"GridState"), null, "", "");
         }
         AV44OrderedBy = AV41GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV44OrderedBy", StringUtil.LTrimStr( (decimal)(AV44OrderedBy), 4, 0));
         AV45OrderedDsc = AV41GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV45OrderedDsc", AV45OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV41GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV41GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV41GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV116GXV1 = 1;
         while ( AV116GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV116GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV93FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV93FilterFullText", AV93FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV71TFSecRoleName = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFSecRoleName", AV71TFSecRoleName);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV72TFSecRoleName_Sel = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFSecRoleName_Sel", AV72TFSecRoleName_Sel);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV75TFSecRoleDescription = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFSecRoleDescription", AV75TFSecRoleDescription);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV76TFSecRoleDescription_Sel = AV42GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFSecRoleDescription_Sel", AV76TFSecRoleDescription_Sel);
            }
            AV116GXV1 = (int)(AV116GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFSecRoleName_Sel)),  AV72TFSecRoleName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFSecRoleDescription_Sel)),  AV76TFSecRoleDescription_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFSecRoleName)),  AV71TFSecRoleName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFSecRoleDescription)),  AV75TFSecRoleDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
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
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV43GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV47DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
               AV48SecRoleName1 = AV43GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV48SecRoleName1", AV48SecRoleName1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV50DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV50DynamicFiltersEnabled2", AV50DynamicFiltersEnabled2);
               AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV43GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV52DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
                  AV53SecRoleName2 = AV43GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV53SecRoleName2", AV53SecRoleName2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV55DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV55DynamicFiltersEnabled3", AV55DynamicFiltersEnabled3);
                  AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV43GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV57DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
                     AV58SecRoleName3 = AV43GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV58SecRoleName3", AV58SecRoleName3);
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
         if ( AV60DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV41GridState.FromXml(AV15Session.Get(AV99Pgmname+"GridState"), null, "", "");
         AV41GridState.gxTpr_Orderedby = AV44OrderedBy;
         AV41GridState.gxTpr_Ordereddsc = AV45OrderedDsc;
         AV41GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV41GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV93FilterFullText)),  0,  AV93FilterFullText,  AV93FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV41GridState,  "TFSECROLENAME",  "Perfil",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFSecRoleName)),  0,  AV71TFSecRoleName,  AV71TFSecRoleName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFSecRoleName_Sel)),  AV72TFSecRoleName_Sel,  AV72TFSecRoleName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV41GridState,  "TFSECROLEDESCRIPTION",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFSecRoleDescription)),  0,  AV75TFSecRoleDescription,  AV75TFSecRoleDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFSecRoleDescription_Sel)),  AV76TFSecRoleDescription_Sel,  AV76TFSecRoleDescription_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV41GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV41GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV41GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV41GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV61DynamicFiltersIgnoreFirst )
         {
            AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV43GridStateDynamicFilter.gxTpr_Selected = AV46DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV48SecRoleName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV43GridStateDynamicFilter,  "Perfil",  AV47DynamicFiltersOperator1,  AV48SecRoleName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV48SecRoleName1, "Contém"+" "+AV48SecRoleName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV60DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV43GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV41GridState.gxTpr_Dynamicfilters.Add(AV43GridStateDynamicFilter, 0);
            }
         }
         if ( AV50DynamicFiltersEnabled2 )
         {
            AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV43GridStateDynamicFilter.gxTpr_Selected = AV51DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV53SecRoleName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV43GridStateDynamicFilter,  "Perfil",  AV52DynamicFiltersOperator2,  AV53SecRoleName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV53SecRoleName2, "Contém"+" "+AV53SecRoleName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV60DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV43GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV41GridState.gxTpr_Dynamicfilters.Add(AV43GridStateDynamicFilter, 0);
            }
         }
         if ( AV55DynamicFiltersEnabled3 )
         {
            AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV43GridStateDynamicFilter.gxTpr_Selected = AV56DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV58SecRoleName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV43GridStateDynamicFilter,  "Perfil",  AV57DynamicFiltersOperator3,  AV58SecRoleName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV58SecRoleName3, "Contém"+" "+AV58SecRoleName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV60DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV43GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV41GridState.gxTpr_Dynamicfilters.Add(AV43GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV99Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecRole";
         AV15Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
      }

      protected void S252( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
      }

      protected void wb_table3_91_2E2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename3_Internalname, "Sec Role Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename3_Internalname, AV58SecRoleName3, StringUtil.RTrim( context.localUtil.Format( AV58SecRoleName3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename3_Visible, edtavSecrolename3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/SecRoleWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_91_2E2e( true) ;
         }
         else
         {
            wb_table3_91_2E2e( false) ;
         }
      }

      protected void wb_table2_69_2E2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename2_Internalname, "Sec Role Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename2_Internalname, AV53SecRoleName2, StringUtil.RTrim( context.localUtil.Format( AV53SecRoleName2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename2_Visible, edtavSecrolename2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/SecRoleWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/SecRoleWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_2E2e( true) ;
         }
         else
         {
            wb_table2_69_2E2e( false) ;
         }
      }

      protected void wb_table1_47_2E2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_WWPBaseObjects/SecRoleWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename1_Internalname, "Sec Role Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename1_Internalname, AV48SecRoleName1, StringUtil.RTrim( context.localUtil.Format( AV48SecRoleName1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename1_Visible, edtavSecrolename1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecRoleWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/SecRoleWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects/SecRoleWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_2E2e( true) ;
         }
         else
         {
            wb_table1_47_2E2e( false) ;
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019232493", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secroleww.js", "?202561019232494", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1092( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_109_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_idx;
         edtavUsuarioxperfil_Internalname = "vUSUARIOXPERFIL_"+sGXsfl_109_idx;
         edtavAddfunc_Internalname = "vADDFUNC_"+sGXsfl_109_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_109_idx;
         edtSecRoleName_Internalname = "SECROLENAME_"+sGXsfl_109_idx;
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_109_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_fel_idx;
         edtavUsuarioxperfil_Internalname = "vUSUARIOXPERFIL_"+sGXsfl_109_fel_idx;
         edtavAddfunc_Internalname = "vADDFUNC_"+sGXsfl_109_fel_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_109_fel_idx;
         edtSecRoleName_Internalname = "SECROLENAME_"+sGXsfl_109_fel_idx;
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         WB2E0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV94Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV13Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUsuarioxperfil_Internalname,StringUtil.RTrim( AV97usuarioxperfil),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUsuarioxperfil_Link,(string)"",(string)"",(string)"",(string)edtavUsuarioxperfil_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUsuarioxperfil_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAddfunc_Internalname,StringUtil.RTrim( AV98AddFunc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavAddfunc_Link,(string)"",(string)"",(string)"",(string)edtavAddfunc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavAddfunc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecRoleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleName_Internalname,(string)A140SecRoleName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecRoleName_Link,(string)"",(string)"",(string)"",(string)edtSecRoleName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleDescription_Internalname,(string)A139SecRoleDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecRoleDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes2E2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("SECROLENAME", "Perfil", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV46DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV46DynamicFiltersSelector1);
            AssignAttri("", false, "AV46DynamicFiltersSelector1", AV46DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV47DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV47DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV47DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECROLENAME", "Perfil", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV51DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV51DynamicFiltersSelector2);
            AssignAttri("", false, "AV51DynamicFiltersSelector2", AV51DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV52DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV52DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV52DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECROLENAME", "Perfil", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV56DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV56DynamicFiltersSelector3);
            AssignAttri("", false, "AV56DynamicFiltersSelector3", AV56DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV57DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV57DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV57DynamicFiltersOperator3), 4, 0));
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Perfil") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV94Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV97usuarioxperfil)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUsuarioxperfil_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUsuarioxperfil_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV98AddFunc)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAddfunc_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavAddfunc_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A140SecRoleName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecRoleName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A139SecRoleDescription));
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
         edtavSecrolename1_Internalname = "vSECROLENAME1";
         cellFilter_secrolename1_cell_Internalname = "FILTER_SECROLENAME1_CELL";
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
         edtavSecrolename2_Internalname = "vSECROLENAME2";
         cellFilter_secrolename2_cell_Internalname = "FILTER_SECROLENAME2_CELL";
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
         edtavSecrolename3_Internalname = "vSECROLENAME3";
         cellFilter_secrolename3_cell_Internalname = "FILTER_SECROLENAME3_CELL";
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
         edtavUsuarioxperfil_Internalname = "vUSUARIOXPERFIL";
         edtavAddfunc_Internalname = "vADDFUNC";
         edtSecRoleId_Internalname = "SECROLEID";
         edtSecRoleName_Internalname = "SECROLENAME";
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtSecRoleDescription_Jsonclick = "";
         edtSecRoleName_Jsonclick = "";
         edtSecRoleName_Link = "";
         edtSecRoleId_Jsonclick = "";
         edtavAddfunc_Jsonclick = "";
         edtavAddfunc_Link = "";
         edtavAddfunc_Enabled = 0;
         edtavUsuarioxperfil_Jsonclick = "";
         edtavUsuarioxperfil_Link = "";
         edtavUsuarioxperfil_Enabled = 0;
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
         edtavSecrolename1_Jsonclick = "";
         edtavSecrolename1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecrolename2_Jsonclick = "";
         edtavSecrolename2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecrolename3_Jsonclick = "";
         edtavSecrolename3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecrolename3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecrolename2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecrolename1_Visible = 1;
         edtSecRoleDescription_Enabled = 0;
         edtSecRoleName_Enabled = 0;
         edtSecRoleId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecRoleWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2";
         Ddo_grid_Columnids = "5:SecRoleName|6:SecRoleDescription";
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
         Form.Caption = " Role";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV89GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV90GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV91GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV68ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E122E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E132E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E142E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E282E2","iparms":[{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A140SecRoleName","fld":"SECROLENAME","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV94Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV13Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV97usuarioxperfil","fld":"vUSUARIOXPERFIL","type":"char"},{"av":"edtavUsuarioxperfil_Link","ctrl":"vUSUARIOXPERFIL","prop":"Link"},{"av":"AV98AddFunc","fld":"vADDFUNC","type":"char"},{"av":"edtavAddfunc_Link","ctrl":"vADDFUNC","prop":"Link"},{"av":"edtSecRoleName_Link","ctrl":"SECROLENAME","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E212E2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E152E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV89GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV90GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV91GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV68ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E222E2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E232E2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E162E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV89GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV90GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV91GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV68ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E242E2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E172E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV89GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV90GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV91GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV68ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E252E2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"AV89GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV90GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV91GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV68ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E182E2","iparms":[{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E192E2","iparms":[{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E202E2","iparms":[{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV41GridState","fld":"vGRIDSTATE","type":""},{"av":"AV44OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV45OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV93FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV46DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV47DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV48SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV51DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV52DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV53SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV56DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV57DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV58SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV64ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV99Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV55DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFSecRoleName","fld":"vTFSECROLENAME","type":"svchar"},{"av":"AV72TFSecRoleName_Sel","fld":"vTFSECROLENAME_SEL","type":"svchar"},{"av":"AV75TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV76TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV61DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV60DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secroledescription","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV93FilterFullText = "";
         AV46DynamicFiltersSelector1 = "";
         AV48SecRoleName1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV53SecRoleName2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58SecRoleName3 = "";
         AV99Pgmname = "";
         AV71TFSecRoleName = "";
         AV72TFSecRoleName_Sel = "";
         AV75TFSecRoleDescription = "";
         AV76TFSecRoleDescription_Sel = "";
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV68ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV91GridAppliedFilters = "";
         AV78DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV94Display = "";
         AV13Update = "";
         AV97usuarioxperfil = "";
         AV98AddFunc = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         lV100Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         lV103Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         lV107Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         lV111Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         AV100Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = "";
         AV103Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = "";
         AV107Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = "";
         AV111Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = "";
         AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = "";
         AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         H002E2_A139SecRoleDescription = new string[] {""} ;
         H002E2_A140SecRoleName = new string[] {""} ;
         H002E2_A131SecRoleId = new short[1] ;
         H002E3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV87WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV65ManageFiltersXml = "";
         AV62ExcelFilename = "";
         AV63ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15Session = context.GetSession();
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char2 = "";
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secroleww__default(),
            new Object[][] {
                new Object[] {
               H002E2_A139SecRoleDescription, H002E2_A140SecRoleName, H002E2_A131SecRoleId
               }
               , new Object[] {
               H002E3_AGRID_nRecordCount
               }
            }
         );
         AV99Pgmname = "WWPBaseObjects.SecRoleWW";
         /* GeneXus formulas. */
         AV99Pgmname = "WWPBaseObjects.SecRoleWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUsuarioxperfil_Enabled = 0;
         edtavAddfunc_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV44OrderedBy ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV64ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A131SecRoleId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ;
      private short AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ;
      private short AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ;
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
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavUsuarioxperfil_Enabled ;
      private int edtavAddfunc_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecRoleId_Enabled ;
      private int edtSecRoleName_Enabled ;
      private int edtSecRoleDescription_Enabled ;
      private int AV88PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSecrolename1_Visible ;
      private int edtavSecrolename2_Visible ;
      private int edtavSecrolename3_Visible ;
      private int AV116GXV1 ;
      private int edtavSecrolename3_Enabled ;
      private int edtavSecrolename2_Enabled ;
      private int edtavSecrolename1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV89GridCurrentPage ;
      private long AV90GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_109_idx="0001" ;
      private string AV99Pgmname ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV94Display ;
      private string edtavDisplay_Internalname ;
      private string AV13Update ;
      private string edtavUpdate_Internalname ;
      private string AV97usuarioxperfil ;
      private string edtavUsuarioxperfil_Internalname ;
      private string AV98AddFunc ;
      private string edtavAddfunc_Internalname ;
      private string edtSecRoleId_Internalname ;
      private string edtSecRoleName_Internalname ;
      private string edtSecRoleDescription_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavSecrolename1_Internalname ;
      private string edtavSecrolename2_Internalname ;
      private string edtavSecrolename3_Internalname ;
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
      private string edtavUsuarioxperfil_Link ;
      private string edtavAddfunc_Link ;
      private string edtSecRoleName_Link ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secrolename3_cell_Internalname ;
      private string edtavSecrolename3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secrolename2_cell_Internalname ;
      private string edtavSecrolename2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secrolename1_cell_Internalname ;
      private string edtavSecrolename1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavUsuarioxperfil_Jsonclick ;
      private string edtavAddfunc_Jsonclick ;
      private string edtSecRoleId_Jsonclick ;
      private string edtSecRoleName_Jsonclick ;
      private string edtSecRoleDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV45OrderedDsc ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV61DynamicFiltersIgnoreFirst ;
      private bool AV60DynamicFiltersRemoving ;
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
      private bool bGXsfl_109_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ;
      private bool AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV65ManageFiltersXml ;
      private string AV93FilterFullText ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV48SecRoleName1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV53SecRoleName2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV58SecRoleName3 ;
      private string AV71TFSecRoleName ;
      private string AV72TFSecRoleName_Sel ;
      private string AV75TFSecRoleDescription ;
      private string AV76TFSecRoleDescription_Sel ;
      private string AV91GridAppliedFilters ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string lV100Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string lV103Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string lV107Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string lV111Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string AV100Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ;
      private string AV103Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ;
      private string AV107Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ;
      private string AV111Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ;
      private string AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ;
      private string AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string AV62ExcelFilename ;
      private string AV63ErrorMessage ;
      private IGxSession AV15Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV68ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV78DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H002E2_A139SecRoleDescription ;
      private string[] H002E2_A140SecRoleName ;
      private short[] H002E2_A131SecRoleId ;
      private long[] H002E3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV87WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secroleww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002E2( IGxContext context ,
                                             string AV100Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV103Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV107Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV111Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV44OrderedBy ,
                                             bool AV45OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[15];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SecRoleDescription, SecRoleName, SecRoleId";
         sFromString = " FROM SecRole";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV100Wwpbaseobjects_secrolewwds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV100Wwpbaseobjects_secrolewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV103Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV103Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV107Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV107Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV111Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV111Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( StringUtil.StrCmp(AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         if ( ( AV44OrderedBy == 1 ) && ! AV45OrderedDsc )
         {
            sOrderString += " ORDER BY SecRoleName, SecRoleId";
         }
         else if ( ( AV44OrderedBy == 1 ) && ( AV45OrderedDsc ) )
         {
            sOrderString += " ORDER BY SecRoleName DESC, SecRoleId";
         }
         else if ( ( AV44OrderedBy == 2 ) && ! AV45OrderedDsc )
         {
            sOrderString += " ORDER BY SecRoleDescription, SecRoleId";
         }
         else if ( ( AV44OrderedBy == 2 ) && ( AV45OrderedDsc ) )
         {
            sOrderString += " ORDER BY SecRoleDescription DESC, SecRoleId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY SecRoleId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H002E3( IGxContext context ,
                                             string AV100Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV103Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV107Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV111Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A140SecRoleName ,
                                             string A139SecRoleDescription ,
                                             short AV44OrderedBy ,
                                             bool AV45OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM SecRole";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecRoleName like '%' || :lV100Wwpbaseobjects_secrolewwds_1_filterfulltext) or ( SecRoleDescription like '%' || :lV100Wwpbaseobjects_secrolewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV103Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV101Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV102Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV103Wwpbaseobjects_secrolewwds_4_secrolename1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV107Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV104Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV105Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV106Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV107Wwpbaseobjects_secrolewwds_8_secrolename2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV111Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV108Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV109Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV110Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like '%' || :lV111Wwpbaseobjects_secrolewwds_12_secrolename3)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(SecRoleName like :lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleName = ( :AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription like :lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecRoleDescription = ( :AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from SecRoleDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV44OrderedBy == 1 ) && ! AV45OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV44OrderedBy == 1 ) && ( AV45OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV44OrderedBy == 2 ) && ! AV45OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV44OrderedBy == 2 ) && ( AV45OrderedDsc ) )
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
                     return conditional_H002E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
               case 1 :
                     return conditional_H002E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmH002E2;
          prmH002E2 = new Object[] {
          new ParDef("lV100Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV100Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV103Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV103Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV107Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV107Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV111Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV111Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.VarChar,120,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002E3;
          prmH002E3 = new Object[] {
          new ParDef("lV100Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV100Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV103Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV103Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV107Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV107Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV111Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV111Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV112Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("AV113Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.VarChar,40,0) ,
          new ParDef("lV114Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV115Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
