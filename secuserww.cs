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
   public class secuserww : GXDataArea
   {
      public secuserww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserww( IGxContext context )
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
         cmbSecUserStatus = new GXCombobox();
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
         nRC_GXsfl_118 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_118"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_118_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_118_idx = GetPar( "sGXsfl_118_idx");
         edtavUaassociateroles_Title = GetNextPar( );
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
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
         AV23OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV24OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV88FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV27SecUserName1 = GetPar( "SecUserName1");
         AV111SecUserManName1 = GetPar( "SecUserManName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV31SecUserName2 = GetPar( "SecUserName2");
         AV112SecUserManName2 = GetPar( "SecUserManName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV33DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV35SecUserName3 = GetPar( "SecUserName3");
         AV113SecUserManName3 = GetPar( "SecUserManName3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV28DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV32DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV114Pgmname = GetPar( "Pgmname");
         AV51TFSecUserName = GetPar( "TFSecUserName");
         AV52TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV84TFSecUserFullName = GetPar( "TFSecUserFullName");
         AV85TFSecUserFullName_Sel = GetPar( "TFSecUserFullName_Sel");
         AV86TFSecUserEmail = GetPar( "TFSecUserEmail");
         AV87TFSecUserEmail_Sel = GetPar( "TFSecUserEmail_Sel");
         AV89TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV20GridState);
         AV37DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV36DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         edtavUaassociateroles_Title = GetNextPar( );
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
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
         PA2G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2G2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("secuserww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV114Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV114Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV24OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV88FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV25DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME1", AV27SecUserName1);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME1", AV111SecUserManName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV29DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME2", AV31SecUserName2);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME2", AV112SecUserManName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV33DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME3", AV35SecUserName3);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME3", AV113SecUserManName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_118", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_118), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV82GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV28DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV32DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV114Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV114Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV24OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME", AV51TFSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME_SEL", AV52TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME", AV84TFSecUserFullName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME_SEL", AV85TFSecUserFullName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSEREMAIL", AV86TFSecUserEmail);
         GxWebStd.gx_hidden_field( context, "vTFSECUSEREMAIL_SEL", AV87TFSecUserEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89TFSecUserStatus_Sel), 1, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV20GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV20GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV37DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV36DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
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
         GxWebStd.gx_hidden_field( context, "vUAASSOCIATEROLES_Title", StringUtil.RTrim( edtavUaassociateroles_Title));
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
            WE2G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2G2( ) ;
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
         return formatLink("secuserww")  ;
      }

      public override string GetPgmname( )
      {
         return "SecUserWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Usuário" ;
      }

      protected void WB2G0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV44ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV88FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV88FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_SecUserWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_2G2( true) ;
         }
         else
         {
            wb_table1_47_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_2G2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_72_2G2( true) ;
         }
         else
         {
            wb_table2_72_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_2G2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV33DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_97_2G2( true) ;
         }
         else
         {
            wb_table3_97_2G2( false) ;
         }
         return  ;
      }

      protected void wb_table3_97_2G2e( bool wbgen )
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
            StartGridControl118( ) ;
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            nRC_GXsfl_118 = (int)(nGXsfl_118_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV79GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV80GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV82GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_SecUserWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
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
         if ( wbEnd == 118 )
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

      protected void START2G2( )
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
         Form.Meta.addItem("description", " Usuário", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2G0( ) ;
      }

      protected void WS2G2( )
      {
         START2G2( ) ;
         EVT2G2( ) ;
      }

      protected void EVT2G2( )
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
                              E112G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E142G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E152G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E162G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E172G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E182G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E192G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E202G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E212G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E222G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E232G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E242G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E252G2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) )
                           {
                              nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
                              SubsflControlProps_1182( ) ;
                              AV110Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV110Display);
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV15UAAssociateRoles = cgiGet( edtavUaassociateroles_Internalname);
                              AssignAttri("", false, edtavUaassociateroles_Internalname, AV15UAAssociateRoles);
                              A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
                              n141SecUserName = false;
                              A143SecUserFullName = StringUtil.Upper( cgiGet( edtSecUserFullName_Internalname));
                              n143SecUserFullName = false;
                              A144SecUserEmail = cgiGet( edtSecUserEmail_Internalname);
                              n144SecUserEmail = false;
                              cmbSecUserStatus.Name = cmbSecUserStatus_Internalname;
                              cmbSecUserStatus.CurrentValue = cgiGet( cmbSecUserStatus_Internalname);
                              A150SecUserStatus = StringUtil.StrToBool( cgiGet( cmbSecUserStatus_Internalname));
                              n150SecUserStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E262G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E272G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E282G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E292G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV23OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV24OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV88FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV25DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV27SecUserName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME1"), AV111SecUserManName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV31SecUserName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME2"), AV112SecUserManName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV33DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV34DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV35SecUserName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME3"), AV113SecUserManName3) != 0 )
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

      protected void WE2G2( )
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

      protected void PA2G2( )
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
         SubsflControlProps_1182( ) ;
         while ( nGXsfl_118_idx <= nRC_GXsfl_118 )
         {
            sendrow_1182( ) ;
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV23OrderedBy ,
                                       bool AV24OrderedDsc ,
                                       string AV88FilterFullText ,
                                       string AV25DynamicFiltersSelector1 ,
                                       short AV26DynamicFiltersOperator1 ,
                                       string AV27SecUserName1 ,
                                       string AV111SecUserManName1 ,
                                       string AV29DynamicFiltersSelector2 ,
                                       short AV30DynamicFiltersOperator2 ,
                                       string AV31SecUserName2 ,
                                       string AV112SecUserManName2 ,
                                       string AV33DynamicFiltersSelector3 ,
                                       short AV34DynamicFiltersOperator3 ,
                                       string AV35SecUserName3 ,
                                       string AV113SecUserManName3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       bool AV28DynamicFiltersEnabled2 ,
                                       bool AV32DynamicFiltersEnabled3 ,
                                       string AV114Pgmname ,
                                       string AV51TFSecUserName ,
                                       string AV52TFSecUserName_Sel ,
                                       string AV84TFSecUserFullName ,
                                       string AV85TFSecUserFullName_Sel ,
                                       string AV86TFSecUserEmail ,
                                       string AV87TFSecUserEmail_Sel ,
                                       short AV89TFSecUserStatus_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ,
                                       bool AV37DynamicFiltersIgnoreFirst ,
                                       bool AV36DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", "")));
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
            AV25DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV25DynamicFiltersSelector1);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV33DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV33DynamicFiltersSelector3);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV114Pgmname = "SecUserWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUaassociateroles_Enabled = 0;
      }

      protected void RF2G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 118;
         /* Execute user event: Refresh */
         E272G2 ();
         nGXsfl_118_idx = 1;
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         bGXsfl_118_Refreshing = true;
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
            SubsflControlProps_1182( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV88FilterFullText ,
                                                 AV25DynamicFiltersSelector1 ,
                                                 AV26DynamicFiltersOperator1 ,
                                                 AV27SecUserName1 ,
                                                 AV111SecUserManName1 ,
                                                 AV28DynamicFiltersEnabled2 ,
                                                 AV29DynamicFiltersSelector2 ,
                                                 AV30DynamicFiltersOperator2 ,
                                                 AV31SecUserName2 ,
                                                 AV112SecUserManName2 ,
                                                 AV32DynamicFiltersEnabled3 ,
                                                 AV33DynamicFiltersSelector3 ,
                                                 AV34DynamicFiltersOperator3 ,
                                                 AV35SecUserName3 ,
                                                 AV113SecUserManName3 ,
                                                 AV52TFSecUserName_Sel ,
                                                 AV51TFSecUserName ,
                                                 AV85TFSecUserFullName_Sel ,
                                                 AV84TFSecUserFullName ,
                                                 AV87TFSecUserEmail_Sel ,
                                                 AV86TFSecUserEmail ,
                                                 AV89TFSecUserStatus_Sel ,
                                                 A141SecUserName ,
                                                 A143SecUserFullName ,
                                                 A144SecUserEmail ,
                                                 A150SecUserStatus ,
                                                 A148SecUserManName ,
                                                 AV23OrderedBy ,
                                                 AV24OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
            lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
            lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
            lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
            lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
            lV27SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV27SecUserName1), "%", "");
            lV27SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV27SecUserName1), "%", "");
            lV111SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV111SecUserManName1), "%", "");
            lV111SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV111SecUserManName1), "%", "");
            lV31SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV31SecUserName2), "%", "");
            lV31SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV31SecUserName2), "%", "");
            lV112SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV112SecUserManName2), "%", "");
            lV112SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV112SecUserManName2), "%", "");
            lV35SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV35SecUserName3), "%", "");
            lV35SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV35SecUserName3), "%", "");
            lV113SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV113SecUserManName3), "%", "");
            lV113SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV113SecUserManName3), "%", "");
            lV51TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV51TFSecUserName), "%", "");
            lV84TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV84TFSecUserFullName), "%", "");
            lV86TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV86TFSecUserEmail), "%", "");
            /* Using cursor H002G2 */
            pr_default.execute(0, new Object[] {lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV27SecUserName1, lV27SecUserName1, lV111SecUserManName1, lV111SecUserManName1, lV31SecUserName2, lV31SecUserName2, lV112SecUserManName2, lV112SecUserManName2, lV35SecUserName3, lV35SecUserName3, lV113SecUserManName3, lV113SecUserManName3, lV51TFSecUserName, AV52TFSecUserName_Sel, lV84TFSecUserFullName, AV85TFSecUserFullName_Sel, lV86TFSecUserEmail, AV87TFSecUserEmail_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_118_idx = 1;
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A147SecUserUserMan = H002G2_A147SecUserUserMan[0];
               n147SecUserUserMan = H002G2_n147SecUserUserMan[0];
               A148SecUserManName = H002G2_A148SecUserManName[0];
               n148SecUserManName = H002G2_n148SecUserManName[0];
               A150SecUserStatus = H002G2_A150SecUserStatus[0];
               n150SecUserStatus = H002G2_n150SecUserStatus[0];
               A144SecUserEmail = H002G2_A144SecUserEmail[0];
               n144SecUserEmail = H002G2_n144SecUserEmail[0];
               A143SecUserFullName = H002G2_A143SecUserFullName[0];
               n143SecUserFullName = H002G2_n143SecUserFullName[0];
               A141SecUserName = H002G2_A141SecUserName[0];
               n141SecUserName = H002G2_n141SecUserName[0];
               A133SecUserId = H002G2_A133SecUserId[0];
               A148SecUserManName = H002G2_A148SecUserManName[0];
               n148SecUserManName = H002G2_n148SecUserManName[0];
               /* Execute user event: Grid.Load */
               E282G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 118;
            WB2G0( ) ;
         }
         bGXsfl_118_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2G2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV114Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV114Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV88FilterFullText ,
                                              AV25DynamicFiltersSelector1 ,
                                              AV26DynamicFiltersOperator1 ,
                                              AV27SecUserName1 ,
                                              AV111SecUserManName1 ,
                                              AV28DynamicFiltersEnabled2 ,
                                              AV29DynamicFiltersSelector2 ,
                                              AV30DynamicFiltersOperator2 ,
                                              AV31SecUserName2 ,
                                              AV112SecUserManName2 ,
                                              AV32DynamicFiltersEnabled3 ,
                                              AV33DynamicFiltersSelector3 ,
                                              AV34DynamicFiltersOperator3 ,
                                              AV35SecUserName3 ,
                                              AV113SecUserManName3 ,
                                              AV52TFSecUserName_Sel ,
                                              AV51TFSecUserName ,
                                              AV85TFSecUserFullName_Sel ,
                                              AV84TFSecUserFullName ,
                                              AV87TFSecUserEmail_Sel ,
                                              AV86TFSecUserEmail ,
                                              AV89TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              AV23OrderedBy ,
                                              AV24OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
         lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
         lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
         lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
         lV88FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV88FilterFullText), "%", "");
         lV27SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV27SecUserName1), "%", "");
         lV27SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV27SecUserName1), "%", "");
         lV111SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV111SecUserManName1), "%", "");
         lV111SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV111SecUserManName1), "%", "");
         lV31SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV31SecUserName2), "%", "");
         lV31SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV31SecUserName2), "%", "");
         lV112SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV112SecUserManName2), "%", "");
         lV112SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV112SecUserManName2), "%", "");
         lV35SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV35SecUserName3), "%", "");
         lV35SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV35SecUserName3), "%", "");
         lV113SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV113SecUserManName3), "%", "");
         lV113SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV113SecUserManName3), "%", "");
         lV51TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV51TFSecUserName), "%", "");
         lV84TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV84TFSecUserFullName), "%", "");
         lV86TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV86TFSecUserEmail), "%", "");
         /* Using cursor H002G3 */
         pr_default.execute(1, new Object[] {lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV88FilterFullText, lV27SecUserName1, lV27SecUserName1, lV111SecUserManName1, lV111SecUserManName1, lV31SecUserName2, lV31SecUserName2, lV112SecUserManName2, lV112SecUserManName2, lV35SecUserName3, lV35SecUserName3, lV113SecUserManName3, lV113SecUserManName3, lV51TFSecUserName, AV52TFSecUserName_Sel, lV84TFSecUserFullName, AV85TFSecUserFullName_Sel, lV86TFSecUserEmail, AV87TFSecUserEmail_Sel});
         GRID_nRecordCount = H002G3_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV114Pgmname = "SecUserWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUaassociateroles_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         cmbSecUserStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E262G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV44ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV54DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_118 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_118"), ",", "."), 18, MidpointRounding.ToEven));
            AV79GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV80GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV82GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
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
            AV88FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV88FilterFullText", AV88FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV25DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AV27SecUserName1 = StringUtil.Upper( cgiGet( edtavSecusername1_Internalname));
            AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
            AV111SecUserManName1 = StringUtil.Upper( cgiGet( edtavSecusermanname1_Internalname));
            AssignAttri("", false, "AV111SecUserManName1", AV111SecUserManName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV29DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AV31SecUserName2 = StringUtil.Upper( cgiGet( edtavSecusername2_Internalname));
            AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
            AV112SecUserManName2 = StringUtil.Upper( cgiGet( edtavSecusermanname2_Internalname));
            AssignAttri("", false, "AV112SecUserManName2", AV112SecUserManName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV33DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AV35SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
            AV113SecUserManName3 = StringUtil.Upper( cgiGet( edtavSecusermanname3_Internalname));
            AssignAttri("", false, "AV113SecUserManName3", AV113SecUserManName3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV23OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV24OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV88FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV25DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV27SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME1"), AV111SecUserManName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV31SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME2"), AV112SecUserManName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV33DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV34DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV35SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME3"), AV113SecUserManName3) != 0 )
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
         E262G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E262G2( )
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
         AV25DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV33DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
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
         Form.Caption = " Usuário";
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
         if ( AV23OrderedBy < 1 )
         {
            AV23OrderedBy = 1;
            AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
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
         edtavUaassociateroles_Title = "Roles";
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
      }

      protected void E272G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV77WWPContext) ;
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV32DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
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
         AV79GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV79GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV79GridCurrentPage), 10, 0));
         AV80GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV80GridPageCount", StringUtil.LTrimStr( (decimal)(AV80GridPageCount), 10, 0));
         GXt_char2 = AV82GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV114Pgmname, out  GXt_char2) ;
         AV82GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV82GridAppliedFilters", AV82GridAppliedFilters);
         cmbSecUserStatus_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbSecUserStatus_Internalname, "Columnheaderclass", cmbSecUserStatus_Columnheaderclass, !bGXsfl_118_Refreshing);
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E122G2( )
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
            AV78PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV78PageToGo) ;
         }
      }

      protected void E132G2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142G2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV23OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
            AV24OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserName") == 0 )
            {
               AV51TFSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
               AV52TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserFullName") == 0 )
            {
               AV84TFSecUserFullName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV84TFSecUserFullName", AV84TFSecUserFullName);
               AV85TFSecUserFullName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV85TFSecUserFullName_Sel", AV85TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserEmail") == 0 )
            {
               AV86TFSecUserEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV86TFSecUserEmail", AV86TFSecUserEmail);
               AV87TFSecUserEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV87TFSecUserEmail_Sel", AV87TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserStatus") == 0 )
            {
               AV89TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV89TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV89TFSecUserStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E282G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV110Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV110Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtavDisplay_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV12Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         AV15UAAssociateRoles = "<i class=\"fas fa-user-gear\"></i>";
         AssignAttri("", false, edtavUaassociateroles_Internalname, AV15UAAssociateRoles);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secusersecuserroleassociation"+UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtavUaassociateroles_Link = formatLink("secusersecuserroleassociation") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secusercliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserFullName_Link = formatLink("secusercliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
         {
            cmbSecUserStatus_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
         {
            cmbSecUserStatus_Columnclass = "WWColumn hidden-xs WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbSecUserStatus_Columnclass = "WWColumn hidden-xs";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 118;
         }
         sendrow_1182( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_118_Refreshing )
         {
            DoAjaxLoad(118, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E212G2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E152G2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E222G2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV26DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E232G2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E162G2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E242G2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E172G2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV32DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
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
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV88FilterFullText, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV111SecUserManName1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV112SecUserManName2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV113SecUserManName3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV114Pgmname, AV51TFSecUserName, AV52TFSecUserName_Sel, AV84TFSecUserFullName, AV85TFSecUserFullName_Sel, AV86TFSecUserEmail, AV87TFSecUserEmail_Sel, AV89TFSecUserStatus_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E252G2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV34DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E112G2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("SecUserWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV114Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("SecUserWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV41ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "SecUserWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV41ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV114Pgmname+"GridState",  AV41ManageFiltersXml) ;
               AV20GridState.FromXml(AV41ManageFiltersXml, null, "", "");
               AV23OrderedBy = AV20GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
               AV24OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E292G2( )
      {
         /* Update_Click Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         context.PopUp(formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E182G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E192G2( )
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
         new secuserwwexport(context ).execute( out  AV38ExcelFilename, out  AV39ErrorMessage) ;
         if ( StringUtil.StrCmp(AV38ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV38ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV39ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E202G2( )
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
         Innewwindow1_Target = formatLink("secuserwwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderedBy), 4, 0))+":"+(AV24OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavSecusername1_Visible = 0;
         AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
         edtavSecusermanname1_Visible = 0;
         AssignProp("", false, edtavSecusermanname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
         {
            edtavSecusermanname1_Visible = 1;
            AssignProp("", false, edtavSecusermanname1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSecusername2_Visible = 0;
         AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
         edtavSecusermanname2_Visible = 0;
         AssignProp("", false, edtavSecusermanname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
         {
            edtavSecusermanname2_Visible = 1;
            AssignProp("", false, edtavSecusermanname2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSecusername3_Visible = 0;
         AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
         edtavSecusermanname3_Visible = 0;
         AssignProp("", false, edtavSecusermanname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
         {
            edtavSecusermanname3_Visible = 1;
            AssignProp("", false, edtavSecusermanname3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusermanname3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         AV29DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AV31SecUserName2 = "";
         AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
         AV33DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         AV34DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AV35SecUserName3 = "";
         AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV44ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "SecUserWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV44ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV88FilterFullText = "";
         AssignAttri("", false, "AV88FilterFullText", AV88FilterFullText);
         AV51TFSecUserName = "";
         AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
         AV52TFSecUserName_Sel = "";
         AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
         AV84TFSecUserFullName = "";
         AssignAttri("", false, "AV84TFSecUserFullName", AV84TFSecUserFullName);
         AV85TFSecUserFullName_Sel = "";
         AssignAttri("", false, "AV85TFSecUserFullName_Sel", AV85TFSecUserFullName_Sel);
         AV86TFSecUserEmail = "";
         AssignAttri("", false, "AV86TFSecUserEmail", AV86TFSecUserEmail);
         AV87TFSecUserEmail_Sel = "";
         AssignAttri("", false, "AV87TFSecUserEmail_Sel", AV87TFSecUserEmail_Sel);
         AV89TFSecUserStatus_Sel = 0;
         AssignAttri("", false, "AV89TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV89TFSecUserStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV25DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         AV26DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AV27SecUserName1 = "";
         AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
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
         AV20GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV14Session.Get(AV114Pgmname+"GridState"), "") == 0 )
         {
            AV20GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV114Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV20GridState.FromXml(AV14Session.Get(AV114Pgmname+"GridState"), null, "", "");
         }
         AV23OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
         AV24OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV20GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV20GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV20GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV115GXV1 = 1;
         while ( AV115GXV1 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV115GXV1));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV88FilterFullText = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV88FilterFullText", AV88FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV51TFSecUserName = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV52TFSecUserName_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV84TFSecUserFullName = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV84TFSecUserFullName", AV84TFSecUserFullName);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV85TFSecUserFullName_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV85TFSecUserFullName_Sel", AV85TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV86TFSecUserEmail = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV86TFSecUserEmail", AV86TFSecUserEmail);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV87TFSecUserEmail_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV87TFSecUserEmail_Sel", AV87TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV89TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV89TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV89TFSecUserStatus_Sel), 1, 0));
            }
            AV115GXV1 = (int)(AV115GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)),  AV52TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)),  AV85TFSecUserFullName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)),  AV87TFSecUserEmail_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+((0==AV89TFSecUserStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV89TFSecUserStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)),  AV51TFSecUserName, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV84TFSecUserFullName)),  AV84TFSecUserFullName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV86TFSecUserEmail)),  AV86TFSecUserEmail, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+GXt_char2+"|";
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
         if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(1));
            AV25DynamicFiltersSelector1 = AV22GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV26DynamicFiltersOperator1 = AV22GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
               AV27SecUserName1 = AV22GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV26DynamicFiltersOperator1 = AV22GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
               AV111SecUserManName1 = AV22GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV111SecUserManName1", AV111SecUserManName1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV28DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
               AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(2));
               AV29DynamicFiltersSelector2 = AV22GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV22GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV31SecUserName2 = AV22GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV22GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV112SecUserManName2 = AV22GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV112SecUserManName2", AV112SecUserManName2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV32DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
                  AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(3));
                  AV33DynamicFiltersSelector3 = AV22GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV22GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
                     AV35SecUserName3 = AV22GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV22GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
                     AV113SecUserManName3 = AV22GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV113SecUserManName3", AV113SecUserManName3);
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
         if ( AV36DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV20GridState.FromXml(AV14Session.Get(AV114Pgmname+"GridState"), null, "", "");
         AV20GridState.gxTpr_Orderedby = AV23OrderedBy;
         AV20GridState.gxTpr_Ordereddsc = AV24OrderedDsc;
         AV20GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV88FilterFullText)),  0,  AV88FilterFullText,  AV88FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSERNAME",  "Usuário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)),  0,  AV51TFSecUserName,  AV51TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)),  AV52TFSecUserName_Sel,  AV52TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSERFULLNAME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV84TFSecUserFullName)),  0,  AV84TFSecUserFullName,  AV84TFSecUserFullName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)),  AV85TFSecUserFullName_Sel,  AV85TFSecUserFullName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSEREMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV86TFSecUserEmail)),  0,  AV86TFSecUserEmail,  AV86TFSecUserEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)),  AV87TFSecUserEmail_Sel,  AV87TFSecUserEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFSECUSERSTATUS_SEL",  "Status",  !(0==AV89TFSecUserStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV89TFSecUserStatus_Sel), 1, 0)),  ((AV89TFSecUserStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV20GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV114Pgmname+"GridState",  AV20GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV20GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV37DynamicFiltersIgnoreFirst )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário",  AV26DynamicFiltersOperator1,  AV27SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV27SecUserName1, "Contém"+" "+AV27SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV111SecUserManName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário manutenção",  AV26DynamicFiltersOperator1,  AV111SecUserManName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV111SecUserManName1, "Contém"+" "+AV111SecUserManName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário",  AV30DynamicFiltersOperator2,  AV31SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV31SecUserName2, "Contém"+" "+AV31SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV112SecUserManName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário manutenção",  AV30DynamicFiltersOperator2,  AV112SecUserManName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV112SecUserManName2, "Contém"+" "+AV112SecUserManName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
         if ( AV32DynamicFiltersEnabled3 )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV33DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário",  AV34DynamicFiltersOperator3,  AV35SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV35SecUserName3, "Contém"+" "+AV35SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV113SecUserManName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV22GridStateDynamicFilter,  "Usuário manutenção",  AV34DynamicFiltersOperator3,  AV113SecUserManName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV113SecUserManName3, "Contém"+" "+AV113SecUserManName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV114Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "SecUser";
         AV14Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_97_2G2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV35SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV35SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname3_Internalname, "Sec User Man Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname3_Internalname, AV113SecUserManName3, StringUtil.RTrim( context.localUtil.Format( AV113SecUserManName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname3_Visible, edtavSecusermanname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_97_2G2e( true) ;
         }
         else
         {
            wb_table3_97_2G2e( false) ;
         }
      }

      protected void wb_table2_72_2G2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV31SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV31SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname2_Internalname, "Sec User Man Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname2_Internalname, AV112SecUserManName2, StringUtil.RTrim( context.localUtil.Format( AV112SecUserManName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname2_Visible, edtavSecusermanname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_2G2e( true) ;
         }
         else
         {
            wb_table2_72_2G2e( false) ;
         }
      }

      protected void wb_table1_47_2G2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_SecUserWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV27SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV27SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname1_Internalname, "Sec User Man Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname1_Internalname, AV111SecUserManName1, StringUtil.RTrim( context.localUtil.Format( AV111SecUserManName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname1_Visible, edtavSecusermanname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_2G2e( true) ;
         }
         else
         {
            wb_table1_47_2G2e( false) ;
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
         PA2G2( ) ;
         WS2G2( ) ;
         WE2G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019233779", true, true);
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
         context.AddJavascriptSource("secuserww.js", "?202561019233780", false, true);
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

      protected void SubsflControlProps_1182( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_118_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_118_idx;
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES_"+sGXsfl_118_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_118_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_118_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_118_idx;
         edtSecUserEmail_Internalname = "SECUSEREMAIL_"+sGXsfl_118_idx;
         cmbSecUserStatus_Internalname = "SECUSERSTATUS_"+sGXsfl_118_idx;
      }

      protected void SubsflControlProps_fel_1182( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_118_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_118_fel_idx;
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES_"+sGXsfl_118_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_118_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_118_fel_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_118_fel_idx;
         edtSecUserEmail_Internalname = "SECUSEREMAIL_"+sGXsfl_118_fel_idx;
         cmbSecUserStatus_Internalname = "SECUSERSTATUS_"+sGXsfl_118_fel_idx;
      }

      protected void sendrow_1182( )
      {
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         WB2G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_118_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_118_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_118_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_118_idx + "',118)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV110Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_118_idx + "',118)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"","'"+""+"'"+",false,"+"'"+"EVUPDATE.CLICK."+sGXsfl_118_idx+"'",(string)"",(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_118_idx + "',118)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaassociateroles_Internalname,StringUtil.RTrim( AV15UAAssociateRoles),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUaassociateroles_Link,(string)"",(string)"",(string)"",(string)edtavUaassociateroles_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUaassociateroles_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserFullName_Internalname,(string)A143SecUserFullName,StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserFullName_Link,(string)"",(string)"",(string)"",(string)edtSecUserFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserEmail_Internalname,(string)A144SecUserEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A144SecUserEmail,(string)"",(string)"",(string)"",(string)edtSecUserEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecUserStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECUSERSTATUS_" + sGXsfl_118_idx;
               cmbSecUserStatus.Name = GXCCtl;
               cmbSecUserStatus.WebTags = "";
               cmbSecUserStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
               cmbSecUserStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
               if ( cmbSecUserStatus.ItemCount > 0 )
               {
                  A150SecUserStatus = StringUtil.StrToBool( cmbSecUserStatus.getValidValue(StringUtil.BoolToStr( A150SecUserStatus)));
                  n150SecUserStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecUserStatus,(string)cmbSecUserStatus_Internalname,StringUtil.BoolToStr( A150SecUserStatus),(short)1,(string)cmbSecUserStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbSecUserStatus_Columnclass,(string)cmbSecUserStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbSecUserStatus.CurrentValue = StringUtil.BoolToStr( A150SecUserStatus);
            AssignProp("", false, cmbSecUserStatus_Internalname, "Values", (string)(cmbSecUserStatus.ToJavascriptSource()), !bGXsfl_118_Refreshing);
            send_integrity_lvl_hashes2G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         /* End function sendrow_1182 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector1.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV25DynamicFiltersSelector1);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector2.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV33DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV33DynamicFiltersSelector3);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "SECUSERSTATUS_" + sGXsfl_118_idx;
         cmbSecUserStatus.Name = GXCCtl;
         cmbSecUserStatus.WebTags = "";
         cmbSecUserStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbSecUserStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbSecUserStatus.ItemCount > 0 )
         {
            A150SecUserStatus = StringUtil.StrToBool( cmbSecUserStatus.getValidValue(StringUtil.BoolToStr( A150SecUserStatus)));
            n150SecUserStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl118( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"118\">") ;
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
            context.SendWebValue( edtavUaassociateroles_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Usuário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV110Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV15UAAssociateRoles)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavUaassociateroles_Title));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUaassociateroles_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUaassociateroles_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A141SecUserName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A143SecUserFullName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserFullName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A144SecUserEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A150SecUserStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbSecUserStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbSecUserStatus_Columnheaderclass));
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
         edtavSecusername1_Internalname = "vSECUSERNAME1";
         cellFilter_secusername1_cell_Internalname = "FILTER_SECUSERNAME1_CELL";
         edtavSecusermanname1_Internalname = "vSECUSERMANNAME1";
         cellFilter_secusermanname1_cell_Internalname = "FILTER_SECUSERMANNAME1_CELL";
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
         edtavSecusername2_Internalname = "vSECUSERNAME2";
         cellFilter_secusername2_cell_Internalname = "FILTER_SECUSERNAME2_CELL";
         edtavSecusermanname2_Internalname = "vSECUSERMANNAME2";
         cellFilter_secusermanname2_cell_Internalname = "FILTER_SECUSERMANNAME2_CELL";
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
         edtavSecusername3_Internalname = "vSECUSERNAME3";
         cellFilter_secusername3_cell_Internalname = "FILTER_SECUSERNAME3_CELL";
         edtavSecusermanname3_Internalname = "vSECUSERMANNAME3";
         cellFilter_secusermanname3_cell_Internalname = "FILTER_SECUSERMANNAME3_CELL";
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
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtSecUserEmail_Internalname = "SECUSEREMAIL";
         cmbSecUserStatus_Internalname = "SECUSERSTATUS";
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
         cmbSecUserStatus_Jsonclick = "";
         cmbSecUserStatus_Columnclass = "WWColumn hidden-xs";
         edtSecUserEmail_Jsonclick = "";
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Link = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserId_Jsonclick = "";
         edtavUaassociateroles_Jsonclick = "";
         edtavUaassociateroles_Link = "";
         edtavUaassociateroles_Enabled = 1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Enabled = 1;
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecusermanname1_Jsonclick = "";
         edtavSecusermanname1_Enabled = 1;
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecusermanname2_Jsonclick = "";
         edtavSecusermanname2_Enabled = 1;
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecusermanname3_Jsonclick = "";
         edtavSecusermanname3_Enabled = 1;
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecusermanname3_Visible = 1;
         edtavSecusername3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecusermanname2_Visible = 1;
         edtavSecusername2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecusermanname1_Visible = 1;
         edtavSecusername1_Visible = 1;
         cmbSecUserStatus_Columnheaderclass = "";
         cmbSecUserStatus.Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "SecUserWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "4:SecUserName|5:SecUserFullName|6:SecUserEmail|7:SecUserStatus";
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
         Form.Caption = " Usuário";
         edtavUaassociateroles_Title = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E122G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E132G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E142G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E282G2","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"cmbSecUserStatus"},{"av":"A150SecUserStatus","fld":"SECUSERSTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV110Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV12Update","fld":"vUPDATE","type":"char"},{"av":"AV15UAAssociateRoles","fld":"vUAASSOCIATEROLES","type":"char"},{"av":"edtavUaassociateroles_Link","ctrl":"vUAASSOCIATEROLES","prop":"Link"},{"av":"edtSecUserFullName_Link","ctrl":"SECUSERFULLNAME","prop":"Link"},{"av":"cmbSecUserStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E212G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E152G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E222G2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E232G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E162G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E242G2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E172G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E252G2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E292G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E182G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV79GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV80GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV82GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbSecUserStatus"},{"av":"AV44ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E192G2","iparms":[{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E202G2","iparms":[{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV20GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV24OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV88FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV25DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV26DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV27SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV111SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV29DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV30DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV112SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV33DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV34DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV35SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV113SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV28DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV32DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV114Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV51TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV52TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV84TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV85TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV86TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV87TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV89TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV37DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV36DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"edtavUaassociateroles_Title","ctrl":"vUAASSOCIATEROLES","prop":"Title"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secuserstatus","iparms":[]}""");
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
         AV88FilterFullText = "";
         AV25DynamicFiltersSelector1 = "";
         AV27SecUserName1 = "";
         AV111SecUserManName1 = "";
         AV29DynamicFiltersSelector2 = "";
         AV31SecUserName2 = "";
         AV112SecUserManName2 = "";
         AV33DynamicFiltersSelector3 = "";
         AV35SecUserName3 = "";
         AV113SecUserManName3 = "";
         AV114Pgmname = "";
         AV51TFSecUserName = "";
         AV52TFSecUserName_Sel = "";
         AV84TFSecUserFullName = "";
         AV85TFSecUserFullName_Sel = "";
         AV86TFSecUserEmail = "";
         AV87TFSecUserEmail_Sel = "";
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV82GridAppliedFilters = "";
         AV54DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         AV110Display = "";
         AV12Update = "";
         AV15UAAssociateRoles = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         lV88FilterFullText = "";
         lV27SecUserName1 = "";
         lV111SecUserManName1 = "";
         lV31SecUserName2 = "";
         lV112SecUserManName2 = "";
         lV35SecUserName3 = "";
         lV113SecUserManName3 = "";
         lV51TFSecUserName = "";
         lV84TFSecUserFullName = "";
         lV86TFSecUserEmail = "";
         A148SecUserManName = "";
         H002G2_A147SecUserUserMan = new short[1] ;
         H002G2_n147SecUserUserMan = new bool[] {false} ;
         H002G2_A148SecUserManName = new string[] {""} ;
         H002G2_n148SecUserManName = new bool[] {false} ;
         H002G2_A150SecUserStatus = new bool[] {false} ;
         H002G2_n150SecUserStatus = new bool[] {false} ;
         H002G2_A144SecUserEmail = new string[] {""} ;
         H002G2_n144SecUserEmail = new bool[] {false} ;
         H002G2_A143SecUserFullName = new string[] {""} ;
         H002G2_n143SecUserFullName = new bool[] {false} ;
         H002G2_A141SecUserName = new string[] {""} ;
         H002G2_n141SecUserName = new bool[] {false} ;
         H002G2_A133SecUserId = new short[1] ;
         H002G3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV77WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV41ManageFiltersXml = "";
         AV38ExcelFilename = "";
         AV39ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV14Session = context.GetSession();
         AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserww__default(),
            new Object[][] {
                new Object[] {
               H002G2_A147SecUserUserMan, H002G2_n147SecUserUserMan, H002G2_A148SecUserManName, H002G2_n148SecUserManName, H002G2_A150SecUserStatus, H002G2_n150SecUserStatus, H002G2_A144SecUserEmail, H002G2_n144SecUserEmail, H002G2_A143SecUserFullName, H002G2_n143SecUserFullName,
               H002G2_A141SecUserName, H002G2_n141SecUserName, H002G2_A133SecUserId
               }
               , new Object[] {
               H002G3_AGRID_nRecordCount
               }
            }
         );
         AV114Pgmname = "SecUserWW";
         /* GeneXus formulas. */
         AV114Pgmname = "SecUserWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavUaassociateroles_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV23OrderedBy ;
      private short AV26DynamicFiltersOperator1 ;
      private short AV30DynamicFiltersOperator2 ;
      private short AV34DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV89TFSecUserStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A133SecUserId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short A147SecUserUserMan ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_118 ;
      private int nGXsfl_118_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavUaassociateroles_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtSecUserEmail_Enabled ;
      private int AV78PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSecusername1_Visible ;
      private int edtavSecusermanname1_Visible ;
      private int edtavSecusername2_Visible ;
      private int edtavSecusermanname2_Visible ;
      private int edtavSecusername3_Visible ;
      private int edtavSecusermanname3_Visible ;
      private int AV115GXV1 ;
      private int edtavSecusername3_Enabled ;
      private int edtavSecusermanname3_Enabled ;
      private int edtavSecusername2_Enabled ;
      private int edtavSecusermanname2_Enabled ;
      private int edtavSecusername1_Enabled ;
      private int edtavSecusermanname1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV79GridCurrentPage ;
      private long AV80GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string edtavUaassociateroles_Title ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_118_idx="0001" ;
      private string edtavUaassociateroles_Internalname ;
      private string AV114Pgmname ;
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
      private string Ddo_grid_Datalistfixedvalues ;
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
      private string AV110Display ;
      private string edtavDisplay_Internalname ;
      private string AV12Update ;
      private string edtavUpdate_Internalname ;
      private string AV15UAAssociateRoles ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserEmail_Internalname ;
      private string cmbSecUserStatus_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavSecusername1_Internalname ;
      private string edtavSecusermanname1_Internalname ;
      private string edtavSecusername2_Internalname ;
      private string edtavSecusermanname2_Internalname ;
      private string edtavSecusername3_Internalname ;
      private string edtavSecusermanname3_Internalname ;
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
      private string cmbSecUserStatus_Columnheaderclass ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUaassociateroles_Link ;
      private string edtSecUserFullName_Link ;
      private string cmbSecUserStatus_Columnclass ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
      private string cellFilter_secusermanname3_cell_Internalname ;
      private string edtavSecusermanname3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
      private string cellFilter_secusermanname2_cell_Internalname ;
      private string edtavSecusermanname2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
      private string cellFilter_secusermanname1_cell_Internalname ;
      private string edtavSecusermanname1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_118_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavUaassociateroles_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtSecUserEmail_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecUserStatus_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_118_Refreshing=false ;
      private bool AV24OrderedDsc ;
      private bool AV28DynamicFiltersEnabled2 ;
      private bool AV32DynamicFiltersEnabled3 ;
      private bool AV37DynamicFiltersIgnoreFirst ;
      private bool AV36DynamicFiltersRemoving ;
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
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private bool gxdyncontrolsrefreshing ;
      private bool n147SecUserUserMan ;
      private bool n148SecUserManName ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV41ManageFiltersXml ;
      private string AV88FilterFullText ;
      private string AV25DynamicFiltersSelector1 ;
      private string AV27SecUserName1 ;
      private string AV111SecUserManName1 ;
      private string AV29DynamicFiltersSelector2 ;
      private string AV31SecUserName2 ;
      private string AV112SecUserManName2 ;
      private string AV33DynamicFiltersSelector3 ;
      private string AV35SecUserName3 ;
      private string AV113SecUserManName3 ;
      private string AV51TFSecUserName ;
      private string AV52TFSecUserName_Sel ;
      private string AV84TFSecUserFullName ;
      private string AV85TFSecUserFullName_Sel ;
      private string AV86TFSecUserEmail ;
      private string AV87TFSecUserEmail_Sel ;
      private string AV82GridAppliedFilters ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string lV88FilterFullText ;
      private string lV27SecUserName1 ;
      private string lV111SecUserManName1 ;
      private string lV31SecUserName2 ;
      private string lV112SecUserManName2 ;
      private string lV35SecUserName3 ;
      private string lV113SecUserManName3 ;
      private string lV51TFSecUserName ;
      private string lV84TFSecUserFullName ;
      private string lV86TFSecUserEmail ;
      private string A148SecUserManName ;
      private string AV38ExcelFilename ;
      private string AV39ErrorMessage ;
      private IGxSession AV14Session ;
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
      private GXCombobox cmbSecUserStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV44ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV54DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H002G2_A147SecUserUserMan ;
      private bool[] H002G2_n147SecUserUserMan ;
      private string[] H002G2_A148SecUserManName ;
      private bool[] H002G2_n148SecUserManName ;
      private bool[] H002G2_A150SecUserStatus ;
      private bool[] H002G2_n150SecUserStatus ;
      private string[] H002G2_A144SecUserEmail ;
      private bool[] H002G2_n144SecUserEmail ;
      private string[] H002G2_A143SecUserFullName ;
      private bool[] H002G2_n143SecUserFullName ;
      private string[] H002G2_A141SecUserName ;
      private bool[] H002G2_n141SecUserName ;
      private short[] H002G2_A133SecUserId ;
      private long[] H002G3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV77WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV21GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV22GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuserww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002G2( IGxContext context ,
                                             string AV88FilterFullText ,
                                             string AV25DynamicFiltersSelector1 ,
                                             short AV26DynamicFiltersOperator1 ,
                                             string AV27SecUserName1 ,
                                             string AV111SecUserManName1 ,
                                             bool AV28DynamicFiltersEnabled2 ,
                                             string AV29DynamicFiltersSelector2 ,
                                             short AV30DynamicFiltersOperator2 ,
                                             string AV31SecUserName2 ,
                                             string AV112SecUserManName2 ,
                                             bool AV32DynamicFiltersEnabled3 ,
                                             string AV33DynamicFiltersSelector3 ,
                                             short AV34DynamicFiltersOperator3 ,
                                             string AV35SecUserName3 ,
                                             string AV113SecUserManName3 ,
                                             string AV52TFSecUserName_Sel ,
                                             string AV51TFSecUserName ,
                                             string AV85TFSecUserFullName_Sel ,
                                             string AV84TFSecUserFullName ,
                                             string AV87TFSecUserEmail_Sel ,
                                             string AV86TFSecUserEmail ,
                                             short AV89TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV23OrderedBy ,
                                             bool AV24OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[26];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecUserUserMan AS SecUserUserMan, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, T1.SecUserName, T1.SecUserId";
         sFromString = " FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV88FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV88FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV88FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV88FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV88FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV27SecUserName1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV27SecUserName1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV111SecUserManName1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV111SecUserManName1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV31SecUserName2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV31SecUserName2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV112SecUserManName2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV112SecUserManName2)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV35SecUserName3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV35SecUserName3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV113SecUserManName3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV113SecUserManName3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV51TFSecUserName)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV52TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV52TFSecUserName_Sel))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( StringUtil.StrCmp(AV52TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV84TFSecUserFullName)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV85TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV85TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV86TFSecUserEmail)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV87TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV87TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV89TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV89TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         if ( ( AV23OrderedBy == 1 ) && ! AV24OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserName, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 1 ) && ( AV24OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserName DESC, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 2 ) && ! AV24OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserFullName, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 2 ) && ( AV24OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserFullName DESC, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 3 ) && ! AV24OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserEmail, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 3 ) && ( AV24OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserEmail DESC, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 4 ) && ! AV24OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserStatus, T1.SecUserId";
         }
         else if ( ( AV23OrderedBy == 4 ) && ( AV24OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserStatus DESC, T1.SecUserId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecUserId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H002G3( IGxContext context ,
                                             string AV88FilterFullText ,
                                             string AV25DynamicFiltersSelector1 ,
                                             short AV26DynamicFiltersOperator1 ,
                                             string AV27SecUserName1 ,
                                             string AV111SecUserManName1 ,
                                             bool AV28DynamicFiltersEnabled2 ,
                                             string AV29DynamicFiltersSelector2 ,
                                             short AV30DynamicFiltersOperator2 ,
                                             string AV31SecUserName2 ,
                                             string AV112SecUserManName2 ,
                                             bool AV32DynamicFiltersEnabled3 ,
                                             string AV33DynamicFiltersSelector3 ,
                                             short AV34DynamicFiltersOperator3 ,
                                             string AV35SecUserName3 ,
                                             string AV113SecUserManName3 ,
                                             string AV52TFSecUserName_Sel ,
                                             string AV51TFSecUserName ,
                                             string AV85TFSecUserFullName_Sel ,
                                             string AV84TFSecUserFullName ,
                                             string AV87TFSecUserEmail_Sel ,
                                             string AV86TFSecUserEmail ,
                                             short AV89TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV23OrderedBy ,
                                             bool AV24OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[23];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV88FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV88FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV88FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV88FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV88FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV27SecUserName1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV27SecUserName1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV111SecUserManName1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV26DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV111SecUserManName1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV31SecUserName2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV31SecUserName2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV112SecUserManName2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV28DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV30DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV112SecUserManName2)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV35SecUserName3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV35SecUserName3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV113SecUserManName3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV32DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV34DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV113SecUserManName3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV51TFSecUserName)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV52TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV52TFSecUserName_Sel))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( StringUtil.StrCmp(AV52TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV84TFSecUserFullName)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV85TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV85TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV85TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV86TFSecUserEmail)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV87TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV87TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV87TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV89TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV89TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV23OrderedBy == 1 ) && ! AV24OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 1 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 2 ) && ! AV24OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 2 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 3 ) && ! AV24OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 3 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 4 ) && ! AV24OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderedBy == 4 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H002G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
               case 1 :
                     return conditional_H002G3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmH002G2;
          prmH002G2 = new Object[] {
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV27SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV27SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV111SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV111SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV31SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV31SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV112SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV112SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV35SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV35SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV113SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV113SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV51TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV52TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV84TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV85TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV86TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV87TFSecUserEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002G3;
          prmH002G3 = new Object[] {
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV88FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV27SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV27SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV111SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV111SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV31SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV31SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV112SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV112SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV35SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV35SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV113SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV113SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV51TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV52TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV84TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV85TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV86TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV87TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002G2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002G3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
