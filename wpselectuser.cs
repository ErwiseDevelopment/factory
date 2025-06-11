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
   public class wpselectuser : GXDataArea
   {
      public wpselectuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpselectuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV51SecRoleId = aP0_SecRoleId;
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
            gxfirstwebparm = GetFirstPar( "SecRoleId");
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
               gxfirstwebparm = GetFirstPar( "SecRoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV17OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV18FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV21SecUserName1 = GetPar( "SecUserName1");
         AV22SecUserManName1 = GetPar( "SecUserManName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV26SecUserName2 = GetPar( "SecUserName2");
         AV27SecUserManName2 = GetPar( "SecUserManName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV31SecUserName3 = GetPar( "SecUserName3");
         AV32SecUserManName3 = GetPar( "SecUserManName3");
         AV38ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV23DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV28DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV52Pgmname = GetPar( "Pgmname");
         AV39TFSecUserName = GetPar( "TFSecUserName");
         AV40TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV41TFSecUserFullName = GetPar( "TFSecUserFullName");
         AV42TFSecUserFullName_Sel = GetPar( "TFSecUserFullName_Sel");
         AV43TFSecUserEmail = GetPar( "TFSecUserEmail");
         AV44TFSecUserEmail_Sel = GetPar( "TFSecUserEmail_Sel");
         AV45TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV51SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV13GridState);
         AV34DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV33DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
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
         PA7S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7S2( ) ;
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
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpselectuser"+UrlEncode(StringUtil.LTrimStr(AV51SecRoleId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpselectuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51SecRoleId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV17OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV18FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV19DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME1", AV21SecUserName1);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME1", AV22SecUserManName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV24DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME2", AV26SecUserName2);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME2", AV27SecUserManName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV29DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME3", AV31SecUserName3);
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERMANNAME3", AV32SecUserManName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV36ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV50GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV23DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV28DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME", AV39TFSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME_SEL", AV40TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME", AV41TFSecUserFullName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME_SEL", AV42TFSecUserFullName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSEREMAIL", AV43TFSecUserEmail);
         GxWebStd.gx_hidden_field( context, "vTFSECUSEREMAIL_SEL", AV44TFSecUserEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFSecUserStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV17OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51SecRoleId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV13GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV13GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV34DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV33DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Width", StringUtil.RTrim( Ucmessage_Width));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Minheight", StringUtil.RTrim( Ucmessage_Minheight));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stylingtype", StringUtil.RTrim( Ucmessage_Stylingtype));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectin", StringUtil.RTrim( Ucmessage_Effectin));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Effectout", StringUtil.RTrim( Ucmessage_Effectout));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Animationspeed", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ucmessage_Animationspeed), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Startposition", StringUtil.RTrim( Ucmessage_Startposition));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_Nextmessageposition", StringUtil.RTrim( Ucmessage_Nextmessageposition));
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
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
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
            WE7S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7S2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpselectuser"+UrlEncode(StringUtil.LTrimStr(AV51SecRoleId,4,0));
         return formatLink("wpselectuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpSelectuser" ;
      }

      public override string GetPgmdesc( )
      {
         return " Usuário" ;
      }

      protected void WB7S0( )
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
            ClassString = "BtnCancelar";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtncancelar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Fechar", bttBtnbtncancelar_Jsonclick, 5, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNCANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpSelectuser.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV36ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV18FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV18FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpSelectuser.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_7S2( true) ;
         }
         else
         {
            wb_table1_43_7S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_7S2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_7S2( true) ;
         }
         else
         {
            wb_table2_68_7S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_7S2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_7S2( true) ;
         }
         else
         {
            wb_table3_93_7S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_7S2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV48GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV49GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV50GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("Width", Ucmessage_Width);
            ucUcmessage.SetProperty("MinHeight", Ucmessage_Minheight);
            ucUcmessage.SetProperty("StylingType", Ucmessage_Stylingtype);
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.SetProperty("EffectIn", Ucmessage_Effectin);
            ucUcmessage.SetProperty("EffectOut", Ucmessage_Effectout);
            ucUcmessage.SetProperty("AnimationSpeed", Ucmessage_Animationspeed);
            ucUcmessage.SetProperty("StartPosition", Ucmessage_Startposition);
            ucUcmessage.SetProperty("NextMessagePosition", Ucmessage_Nextmessageposition);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGEContainer");
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpSelectuser.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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

      protected void START7S2( )
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
         STRUP7S0( ) ;
      }

      protected void WS7S2( )
      {
         START7S2( ) ;
         EVT7S2( ) ;
      }

      protected void EVT7S2( )
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
                              E117S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNCANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnCancelar' */
                              E187S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237S2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECIONAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VSELECIONAR.CLICK") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV5Selecionar = cgiGet( edtavSelecionar_Internalname);
                              AssignAttri("", false, edtavSelecionar_Internalname, AV5Selecionar);
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
                              A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E247S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E267S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECIONAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E277S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV16OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV19DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV21SecUserName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME1"), AV22SecUserManName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV26SecUserName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME2"), AV27SecUserManName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV31SecUserName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusermanname3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME3"), AV32SecUserManName3) != 0 )
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

      protected void WE7S2( )
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

      protected void PA7S2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpselectuser")), "wpselectuser") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpselectuser")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV51SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV51SecRoleId", StringUtil.LTrimStr( (decimal)(AV51SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51SecRoleId), "ZZZ9"), context));
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
                                       short AV16OrderedBy ,
                                       bool AV17OrderedDsc ,
                                       string AV18FilterFullText ,
                                       string AV19DynamicFiltersSelector1 ,
                                       short AV20DynamicFiltersOperator1 ,
                                       string AV21SecUserName1 ,
                                       string AV22SecUserManName1 ,
                                       string AV24DynamicFiltersSelector2 ,
                                       short AV25DynamicFiltersOperator2 ,
                                       string AV26SecUserName2 ,
                                       string AV27SecUserManName2 ,
                                       string AV29DynamicFiltersSelector3 ,
                                       short AV30DynamicFiltersOperator3 ,
                                       string AV31SecUserName3 ,
                                       string AV32SecUserManName3 ,
                                       short AV38ManageFiltersExecutionStep ,
                                       bool AV23DynamicFiltersEnabled2 ,
                                       bool AV28DynamicFiltersEnabled3 ,
                                       string AV52Pgmname ,
                                       string AV39TFSecUserName ,
                                       string AV40TFSecUserName_Sel ,
                                       string AV41TFSecUserFullName ,
                                       string AV42TFSecUserFullName_Sel ,
                                       string AV43TFSecUserEmail ,
                                       string AV44TFSecUserEmail_Sel ,
                                       short AV45TFSecUserStatus_Sel ,
                                       short AV51SecRoleId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV13GridState ,
                                       bool AV34DynamicFiltersIgnoreFirst ,
                                       bool AV33DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7S2( ) ;
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
            AV19DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV19DynamicFiltersSelector1);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV52Pgmname = "WpSelectuser";
         edtavSelecionar_Enabled = 0;
      }

      protected void RF7S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E257S2 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV53Wpselectuserds_1_filterfulltext ,
                                                 AV54Wpselectuserds_2_dynamicfiltersselector1 ,
                                                 AV55Wpselectuserds_3_dynamicfiltersoperator1 ,
                                                 AV56Wpselectuserds_4_secusername1 ,
                                                 AV57Wpselectuserds_5_secusermanname1 ,
                                                 AV58Wpselectuserds_6_dynamicfiltersenabled2 ,
                                                 AV59Wpselectuserds_7_dynamicfiltersselector2 ,
                                                 AV60Wpselectuserds_8_dynamicfiltersoperator2 ,
                                                 AV61Wpselectuserds_9_secusername2 ,
                                                 AV62Wpselectuserds_10_secusermanname2 ,
                                                 AV63Wpselectuserds_11_dynamicfiltersenabled3 ,
                                                 AV64Wpselectuserds_12_dynamicfiltersselector3 ,
                                                 AV65Wpselectuserds_13_dynamicfiltersoperator3 ,
                                                 AV66Wpselectuserds_14_secusername3 ,
                                                 AV67Wpselectuserds_15_secusermanname3 ,
                                                 AV69Wpselectuserds_17_tfsecusername_sel ,
                                                 AV68Wpselectuserds_16_tfsecusername ,
                                                 AV71Wpselectuserds_19_tfsecuserfullname_sel ,
                                                 AV70Wpselectuserds_18_tfsecuserfullname ,
                                                 AV73Wpselectuserds_21_tfsecuseremail_sel ,
                                                 AV72Wpselectuserds_20_tfsecuseremail ,
                                                 AV74Wpselectuserds_22_tfsecuserstatus_sel ,
                                                 A141SecUserName ,
                                                 A143SecUserFullName ,
                                                 A144SecUserEmail ,
                                                 A150SecUserStatus ,
                                                 A148SecUserManName ,
                                                 AV16OrderedBy ,
                                                 AV17OrderedDsc ,
                                                 A40000SecUserRoleActive } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
            lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
            lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
            lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
            lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
            lV56Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Wpselectuserds_4_secusername1), "%", "");
            lV56Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Wpselectuserds_4_secusername1), "%", "");
            lV57Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1), "%", "");
            lV57Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1), "%", "");
            lV61Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_9_secusername2), "%", "");
            lV61Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_9_secusername2), "%", "");
            lV62Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2), "%", "");
            lV62Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2), "%", "");
            lV66Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_14_secusername3), "%", "");
            lV66Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_14_secusername3), "%", "");
            lV67Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3), "%", "");
            lV67Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3), "%", "");
            lV68Wpselectuserds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV68Wpselectuserds_16_tfsecusername), "%", "");
            lV70Wpselectuserds_18_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_18_tfsecuserfullname), "%", "");
            lV72Wpselectuserds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV72Wpselectuserds_20_tfsecuseremail), "%", "");
            /* Using cursor H007S3 */
            pr_default.execute(0, new Object[] {AV51SecRoleId, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV56Wpselectuserds_4_secusername1, lV56Wpselectuserds_4_secusername1, lV57Wpselectuserds_5_secusermanname1, lV57Wpselectuserds_5_secusermanname1, lV61Wpselectuserds_9_secusername2, lV61Wpselectuserds_9_secusername2, lV62Wpselectuserds_10_secusermanname2, lV62Wpselectuserds_10_secusermanname2, lV66Wpselectuserds_14_secusername3, lV66Wpselectuserds_14_secusername3, lV67Wpselectuserds_15_secusermanname3, lV67Wpselectuserds_15_secusermanname3, lV68Wpselectuserds_16_tfsecusername, AV69Wpselectuserds_17_tfsecusername_sel, lV70Wpselectuserds_18_tfsecuserfullname, AV71Wpselectuserds_19_tfsecuserfullname_sel, lV72Wpselectuserds_20_tfsecuseremail, AV73Wpselectuserds_21_tfsecuseremail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A147SecUserUserMan = H007S3_A147SecUserUserMan[0];
               n147SecUserUserMan = H007S3_n147SecUserUserMan[0];
               A148SecUserManName = H007S3_A148SecUserManName[0];
               n148SecUserManName = H007S3_n148SecUserManName[0];
               A133SecUserId = H007S3_A133SecUserId[0];
               A150SecUserStatus = H007S3_A150SecUserStatus[0];
               n150SecUserStatus = H007S3_n150SecUserStatus[0];
               A144SecUserEmail = H007S3_A144SecUserEmail[0];
               n144SecUserEmail = H007S3_n144SecUserEmail[0];
               A143SecUserFullName = H007S3_A143SecUserFullName[0];
               n143SecUserFullName = H007S3_n143SecUserFullName[0];
               A141SecUserName = H007S3_A141SecUserName[0];
               n141SecUserName = H007S3_n141SecUserName[0];
               A40000SecUserRoleActive = H007S3_A40000SecUserRoleActive[0];
               n40000SecUserRoleActive = H007S3_n40000SecUserRoleActive[0];
               A148SecUserManName = H007S3_A148SecUserManName[0];
               n148SecUserManName = H007S3_n148SecUserManName[0];
               A40000SecUserRoleActive = H007S3_A40000SecUserRoleActive[0];
               n40000SecUserRoleActive = H007S3_n40000SecUserRoleActive[0];
               /* Execute user event: Grid.Load */
               E267S2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 114;
            WB7S0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV52Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV52Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
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
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Wpselectuserds_1_filterfulltext ,
                                              AV54Wpselectuserds_2_dynamicfiltersselector1 ,
                                              AV55Wpselectuserds_3_dynamicfiltersoperator1 ,
                                              AV56Wpselectuserds_4_secusername1 ,
                                              AV57Wpselectuserds_5_secusermanname1 ,
                                              AV58Wpselectuserds_6_dynamicfiltersenabled2 ,
                                              AV59Wpselectuserds_7_dynamicfiltersselector2 ,
                                              AV60Wpselectuserds_8_dynamicfiltersoperator2 ,
                                              AV61Wpselectuserds_9_secusername2 ,
                                              AV62Wpselectuserds_10_secusermanname2 ,
                                              AV63Wpselectuserds_11_dynamicfiltersenabled3 ,
                                              AV64Wpselectuserds_12_dynamicfiltersselector3 ,
                                              AV65Wpselectuserds_13_dynamicfiltersoperator3 ,
                                              AV66Wpselectuserds_14_secusername3 ,
                                              AV67Wpselectuserds_15_secusermanname3 ,
                                              AV69Wpselectuserds_17_tfsecusername_sel ,
                                              AV68Wpselectuserds_16_tfsecusername ,
                                              AV71Wpselectuserds_19_tfsecuserfullname_sel ,
                                              AV70Wpselectuserds_18_tfsecuserfullname ,
                                              AV73Wpselectuserds_21_tfsecuseremail_sel ,
                                              AV72Wpselectuserds_20_tfsecuseremail ,
                                              AV74Wpselectuserds_22_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              A40000SecUserRoleActive } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
         lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
         lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
         lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
         lV53Wpselectuserds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext), "%", "");
         lV56Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Wpselectuserds_4_secusername1), "%", "");
         lV56Wpselectuserds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV56Wpselectuserds_4_secusername1), "%", "");
         lV57Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1), "%", "");
         lV57Wpselectuserds_5_secusermanname1 = StringUtil.Concat( StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1), "%", "");
         lV61Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_9_secusername2), "%", "");
         lV61Wpselectuserds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV61Wpselectuserds_9_secusername2), "%", "");
         lV62Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2), "%", "");
         lV62Wpselectuserds_10_secusermanname2 = StringUtil.Concat( StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2), "%", "");
         lV66Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_14_secusername3), "%", "");
         lV66Wpselectuserds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV66Wpselectuserds_14_secusername3), "%", "");
         lV67Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3), "%", "");
         lV67Wpselectuserds_15_secusermanname3 = StringUtil.Concat( StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3), "%", "");
         lV68Wpselectuserds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV68Wpselectuserds_16_tfsecusername), "%", "");
         lV70Wpselectuserds_18_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV70Wpselectuserds_18_tfsecuserfullname), "%", "");
         lV72Wpselectuserds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV72Wpselectuserds_20_tfsecuseremail), "%", "");
         /* Using cursor H007S5 */
         pr_default.execute(1, new Object[] {AV51SecRoleId, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV53Wpselectuserds_1_filterfulltext, lV56Wpselectuserds_4_secusername1, lV56Wpselectuserds_4_secusername1, lV57Wpselectuserds_5_secusermanname1, lV57Wpselectuserds_5_secusermanname1, lV61Wpselectuserds_9_secusername2, lV61Wpselectuserds_9_secusername2, lV62Wpselectuserds_10_secusermanname2, lV62Wpselectuserds_10_secusermanname2, lV66Wpselectuserds_14_secusername3, lV66Wpselectuserds_14_secusername3, lV67Wpselectuserds_15_secusermanname3, lV67Wpselectuserds_15_secusermanname3, lV68Wpselectuserds_16_tfsecusername, AV69Wpselectuserds_17_tfsecusername_sel, lV70Wpselectuserds_18_tfsecuserfullname, AV71Wpselectuserds_19_tfsecuserfullname_sel, lV72Wpselectuserds_20_tfsecuseremail, AV73Wpselectuserds_21_tfsecuseremail_sel});
         GRID_nRecordCount = H007S5_AGRID_nRecordCount[0];
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
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV52Pgmname = "WpSelectuser";
         edtavSelecionar_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         cmbSecUserStatus.Enabled = 0;
         edtSecUserId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV36ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV49GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV50GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ucmessage_Width = cgiGet( "UCMESSAGE_Width");
            Ucmessage_Minheight = cgiGet( "UCMESSAGE_Minheight");
            Ucmessage_Stylingtype = cgiGet( "UCMESSAGE_Stylingtype");
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_Stoponerror"));
            Ucmessage_Effectin = cgiGet( "UCMESSAGE_Effectin");
            Ucmessage_Effectout = cgiGet( "UCMESSAGE_Effectout");
            Ucmessage_Animationspeed = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCMESSAGE_Animationspeed"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmessage_Startposition = cgiGet( "UCMESSAGE_Startposition");
            Ucmessage_Nextmessageposition = cgiGet( "UCMESSAGE_Nextmessageposition");
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
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
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
            AV18FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV19DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AV21SecUserName1 = StringUtil.Upper( cgiGet( edtavSecusername1_Internalname));
            AssignAttri("", false, "AV21SecUserName1", AV21SecUserName1);
            AV22SecUserManName1 = StringUtil.Upper( cgiGet( edtavSecusermanname1_Internalname));
            AssignAttri("", false, "AV22SecUserManName1", AV22SecUserManName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV24DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AV26SecUserName2 = StringUtil.Upper( cgiGet( edtavSecusername2_Internalname));
            AssignAttri("", false, "AV26SecUserName2", AV26SecUserName2);
            AV27SecUserManName2 = StringUtil.Upper( cgiGet( edtavSecusermanname2_Internalname));
            AssignAttri("", false, "AV27SecUserManName2", AV27SecUserManName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV29DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AV31SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri("", false, "AV31SecUserName3", AV31SecUserName3);
            AV32SecUserManName3 = StringUtil.Upper( cgiGet( edtavSecusermanname3_Internalname));
            AssignAttri("", false, "AV32SecUserManName3", AV32SecUserManName3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV16OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV19DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV21SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME1"), AV22SecUserManName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV24DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV26SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME2"), AV27SecUserManName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV31SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERMANNAME3"), AV32SecUserManName3) != 0 )
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
         E247S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247S2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV10HTTPRequest.Method, "GET") == 0 )
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
         AV19DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
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
         if ( AV16OrderedBy < 1 )
         {
            AV16OrderedBy = 1;
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E257S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( AV38ManageFiltersExecutionStep == 1 )
         {
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV38ManageFiltersExecutionStep == 2 )
         {
            AV38ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV28DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
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
         AV48GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV48GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV48GridCurrentPage), 10, 0));
         AV49GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV49GridPageCount", StringUtil.LTrimStr( (decimal)(AV49GridPageCount), 10, 0));
         GXt_char2 = AV50GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV52Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         AV53Wpselectuserds_1_filterfulltext = AV18FilterFullText;
         AV54Wpselectuserds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV55Wpselectuserds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV56Wpselectuserds_4_secusername1 = AV21SecUserName1;
         AV57Wpselectuserds_5_secusermanname1 = AV22SecUserManName1;
         AV58Wpselectuserds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Wpselectuserds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Wpselectuserds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Wpselectuserds_9_secusername2 = AV26SecUserName2;
         AV62Wpselectuserds_10_secusermanname2 = AV27SecUserManName2;
         AV63Wpselectuserds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV64Wpselectuserds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV65Wpselectuserds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV66Wpselectuserds_14_secusername3 = AV31SecUserName3;
         AV67Wpselectuserds_15_secusermanname3 = AV32SecUserManName3;
         AV68Wpselectuserds_16_tfsecusername = AV39TFSecUserName;
         AV69Wpselectuserds_17_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV70Wpselectuserds_18_tfsecuserfullname = AV41TFSecUserFullName;
         AV71Wpselectuserds_19_tfsecuserfullname_sel = AV42TFSecUserFullName_Sel;
         AV72Wpselectuserds_20_tfsecuseremail = AV43TFSecUserEmail;
         AV73Wpselectuserds_21_tfsecuseremail_sel = AV44TFSecUserEmail_Sel;
         AV74Wpselectuserds_22_tfsecuserstatus_sel = AV45TFSecUserStatus_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E127S2( )
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
            AV47PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV47PageToGo) ;
         }
      }

      protected void E137S2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147S2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            AV17OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
               AV39TFSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFSecUserName", AV39TFSecUserName);
               AV40TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFSecUserName_Sel", AV40TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserFullName") == 0 )
            {
               AV41TFSecUserFullName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFSecUserFullName", AV41TFSecUserFullName);
               AV42TFSecUserFullName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFSecUserFullName_Sel", AV42TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserEmail") == 0 )
            {
               AV43TFSecUserEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFSecUserEmail", AV43TFSecUserEmail);
               AV44TFSecUserEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFSecUserEmail_Sel", AV44TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserStatus") == 0 )
            {
               AV45TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV45TFSecUserStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E267S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV5Selecionar = "<i class=\"fas fa-check\"></i>";
         AssignAttri("", false, edtavSelecionar_Internalname, AV5Selecionar);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secusercliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserFullName_Link = formatLink("secusercliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 114;
         }
         sendrow_1142( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_114_Refreshing )
         {
            DoAjaxLoad(114, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E197S2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E157S2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV34DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV34DynamicFiltersIgnoreFirst", AV34DynamicFiltersIgnoreFirst);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV34DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV34DynamicFiltersIgnoreFirst", AV34DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E207S2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV20DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E217S2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void E167S2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E227S2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E177S2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
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
         AV33DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E237S2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV30DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E117S2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpSelectuserFilters")) + "," + UrlEncode(StringUtil.RTrim(AV52Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpSelectuserFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV38ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV38ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV38ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV37ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpSelectuserFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV37ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV37ManageFiltersXml) ;
               AV13GridState.FromXml(AV37ManageFiltersXml, null, "", "");
               AV16OrderedBy = AV13GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
               AV17OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
      }

      protected void E187S2( )
      {
         /* 'DoBtnCancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))+":"+(AV17OrderedDsc ? "DSC" : "ASC");
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
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
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
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
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
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
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
         AV23DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
         AV24DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         AV25DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AV26SecUserName2 = "";
         AssignAttri("", false, "AV26SecUserName2", AV26SecUserName2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         AV29DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         AV30DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AV31SecUserName3 = "";
         AssignAttri("", false, "AV31SecUserName3", AV31SecUserName3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV36ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpSelectuserFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV36ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV18FilterFullText = "";
         AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
         AV39TFSecUserName = "";
         AssignAttri("", false, "AV39TFSecUserName", AV39TFSecUserName);
         AV40TFSecUserName_Sel = "";
         AssignAttri("", false, "AV40TFSecUserName_Sel", AV40TFSecUserName_Sel);
         AV41TFSecUserFullName = "";
         AssignAttri("", false, "AV41TFSecUserFullName", AV41TFSecUserFullName);
         AV42TFSecUserFullName_Sel = "";
         AssignAttri("", false, "AV42TFSecUserFullName_Sel", AV42TFSecUserFullName_Sel);
         AV43TFSecUserEmail = "";
         AssignAttri("", false, "AV43TFSecUserEmail", AV43TFSecUserEmail);
         AV44TFSecUserEmail_Sel = "";
         AssignAttri("", false, "AV44TFSecUserEmail_Sel", AV44TFSecUserEmail_Sel);
         AV45TFSecUserStatus_Sel = 0;
         AssignAttri("", false, "AV45TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV45TFSecUserStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV19DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         AV20DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AV21SecUserName1 = "";
         AssignAttri("", false, "AV21SecUserName1", AV21SecUserName1);
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
         AV13GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV35Session.Get(AV52Pgmname+"GridState"), "") == 0 )
         {
            AV13GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV52Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV13GridState.FromXml(AV35Session.Get(AV52Pgmname+"GridState"), null, "", "");
         }
         AV16OrderedBy = AV13GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         AV17OrderedDsc = AV13GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV13GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV13GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV13GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV13GridState.gxTpr_Filtervalues.Count )
         {
            AV14GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV13GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV39TFSecUserName = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFSecUserName", AV39TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV40TFSecUserName_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFSecUserName_Sel", AV40TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV41TFSecUserFullName = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFSecUserFullName", AV41TFSecUserFullName);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV42TFSecUserFullName_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSecUserFullName_Sel", AV42TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV43TFSecUserEmail = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFSecUserEmail", AV43TFSecUserEmail);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV44TFSecUserEmail_Sel = AV14GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFSecUserEmail_Sel", AV44TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV14GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV45TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV14GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFSecUserStatus_Sel", StringUtil.Str( (decimal)(AV45TFSecUserStatus_Sel), 1, 0));
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserName_Sel)),  AV40TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserFullName_Sel)),  AV42TFSecUserFullName_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSecUserEmail_Sel)),  AV44TFSecUserEmail_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+((0==AV45TFSecUserStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV45TFSecUserStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName)),  AV39TFSecUserName, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName)),  AV41TFSecUserFullName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecUserEmail)),  AV43TFSecUserEmail, out  GXt_char2) ;
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
         if ( AV13GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV15GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV13GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV15GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV15GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
               AV21SecUserName1 = AV15GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21SecUserName1", AV21SecUserName1);
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV15GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
               AV22SecUserManName1 = AV15GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV22SecUserManName1", AV22SecUserManName1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV13GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV23DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV23DynamicFiltersEnabled2", AV23DynamicFiltersEnabled2);
               AV15GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV13GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV15GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV15GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV26SecUserName2 = AV15GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26SecUserName2", AV26SecUserName2);
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV15GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
                  AV27SecUserManName2 = AV15GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27SecUserManName2", AV27SecUserManName2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV13GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV28DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
                  AV15GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV13GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV15GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV15GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV31SecUserName3 = AV15GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31SecUserName3", AV31SecUserName3);
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV15GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV32SecUserManName3 = AV15GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32SecUserManName3", AV32SecUserManName3);
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
         if ( AV33DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV13GridState.FromXml(AV35Session.Get(AV52Pgmname+"GridState"), null, "", "");
         AV13GridState.gxTpr_Orderedby = AV16OrderedBy;
         AV13GridState.gxTpr_Ordereddsc = AV17OrderedDsc;
         AV13GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)),  0,  AV18FilterFullText,  AV18FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFSECUSERNAME",  "Usuário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName)),  0,  AV39TFSecUserName,  AV39TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserName_Sel)),  AV40TFSecUserName_Sel,  AV40TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFSECUSERFULLNAME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName)),  0,  AV41TFSecUserFullName,  AV41TFSecUserFullName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserFullName_Sel)),  AV42TFSecUserFullName_Sel,  AV42TFSecUserFullName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV13GridState,  "TFSECUSEREMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecUserEmail)),  0,  AV43TFSecUserEmail,  AV43TFSecUserEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSecUserEmail_Sel)),  AV44TFSecUserEmail_Sel,  AV44TFSecUserEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV13GridState,  "TFSECUSERSTATUS_SEL",  "Status",  !(0==AV45TFSecUserStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFSecUserStatus_Sel), 1, 0)),  ((AV45TFSecUserStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         if ( ! (0==AV51SecRoleId) )
         {
            AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV14GridStateFilterValue.gxTpr_Name = "PARM_&SECROLEID";
            AV14GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV51SecRoleId), 4, 0);
            AV13GridState.gxTpr_Filtervalues.Add(AV14GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV13GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV52Pgmname+"GridState",  AV13GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV13GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV34DynamicFiltersIgnoreFirst )
         {
            AV15GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV15GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário",  AV20DynamicFiltersOperator1,  AV21SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21SecUserName1, "Contém"+" "+AV21SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserManName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário manutenção",  AV20DynamicFiltersOperator1,  AV22SecUserManName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV22SecUserManName1, "Contém"+" "+AV22SecUserManName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV15GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV13GridState.gxTpr_Dynamicfilters.Add(AV15GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled2 )
         {
            AV15GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV15GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário",  AV25DynamicFiltersOperator2,  AV26SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV26SecUserName2, "Contém"+" "+AV26SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserManName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário manutenção",  AV25DynamicFiltersOperator2,  AV27SecUserManName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV27SecUserManName2, "Contém"+" "+AV27SecUserManName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV15GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV13GridState.gxTpr_Dynamicfilters.Add(AV15GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled3 )
         {
            AV15GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV15GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário",  AV30DynamicFiltersOperator3,  AV31SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV31SecUserName3, "Contém"+" "+AV31SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32SecUserManName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV15GridStateDynamicFilter,  "Usuário manutenção",  AV30DynamicFiltersOperator3,  AV32SecUserManName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV32SecUserManName3, "Contém"+" "+AV32SecUserManName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV15GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV13GridState.gxTpr_Dynamicfilters.Add(AV15GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV52Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "SecUser";
         AV35Session.Set("TrnContext", AV11TrnContext.ToXml(false, true, "", ""));
      }

      protected void E277S2( )
      {
         /* Selecionar_Click Routine */
         returnInSub = false;
         AV6SecUserRole.Load(A133SecUserId, AV51SecRoleId);
         AV6SecUserRole.gxTpr_Secuserroleactive = true;
         AV6SecUserRole.Save();
         if ( AV6SecUserRole.Success() )
         {
            context.CommitDataStores("wpselectuser",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Sucesso!",  "Usuário inserido com sucesso!",  "success",  "",  "true",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21SecUserName1, AV22SecUserManName1, AV24DynamicFiltersSelector2, AV25DynamicFiltersOperator2, AV26SecUserName2, AV27SecUserManName2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31SecUserName3, AV32SecUserManName3, AV38ManageFiltersExecutionStep, AV23DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV52Pgmname, AV39TFSecUserName, AV40TFSecUserName_Sel, AV41TFSecUserFullName, AV42TFSecUserFullName_Sel, AV43TFSecUserEmail, AV44TFSecUserEmail_Sel, AV45TFSecUserStatus_Sel, AV51SecRoleId, AV13GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atenção!",  StringUtil.Trim( ((GeneXus.Utils.SdtMessages_Message)AV6SecUserRole.GetMessages().Item(1)).gxTpr_Description),  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36ManageFiltersData", AV36ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13GridState", AV13GridState);
      }

      protected void wb_table3_93_7S2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV31SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV31SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname3_Internalname, "Sec User Man Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname3_Internalname, AV32SecUserManName3, StringUtil.RTrim( context.localUtil.Format( AV32SecUserManName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname3_Visible, edtavSecusermanname3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpSelectuser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_7S2e( true) ;
         }
         else
         {
            wb_table3_93_7S2e( false) ;
         }
      }

      protected void wb_table2_68_7S2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV26SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV26SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname2_Internalname, "Sec User Man Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname2_Internalname, AV27SecUserManName2, StringUtil.RTrim( context.localUtil.Format( AV27SecUserManName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname2_Visible, edtavSecusermanname2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpSelectuser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpSelectuser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_7S2e( true) ;
         }
         else
         {
            wb_table2_68_7S2e( false) ;
         }
      }

      protected void wb_table1_43_7S2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpSelectuser.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV21SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV21SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusermanname1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusermanname1_Internalname, "Sec User Man Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusermanname1_Internalname, AV22SecUserManName1, StringUtil.RTrim( context.localUtil.Format( AV22SecUserManName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusermanname1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusermanname1_Visible, edtavSecusermanname1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpSelectuser.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpSelectuser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpSelectuser.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_7S2e( true) ;
         }
         else
         {
            wb_table1_43_7S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV51SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV51SecRoleId", StringUtil.LTrimStr( (decimal)(AV51SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV51SecRoleId), "ZZZ9"), context));
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
         PA7S2( ) ;
         WS7S2( ) ;
         WE7S2( ) ;
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
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019271116", true, true);
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
         context.AddJavascriptSource("wpselectuser.js", "?202561019271117", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1142( )
      {
         edtavSelecionar_Internalname = "vSELECIONAR_"+sGXsfl_114_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_114_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_114_idx;
         edtSecUserEmail_Internalname = "SECUSEREMAIL_"+sGXsfl_114_idx;
         cmbSecUserStatus_Internalname = "SECUSERSTATUS_"+sGXsfl_114_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         edtavSelecionar_Internalname = "vSELECIONAR_"+sGXsfl_114_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_114_fel_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_114_fel_idx;
         edtSecUserEmail_Internalname = "SECUSEREMAIL_"+sGXsfl_114_fel_idx;
         cmbSecUserStatus_Internalname = "SECUSERSTATUS_"+sGXsfl_114_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB7S0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelecionar_Internalname,StringUtil.RTrim( AV5Selecionar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"","'"+""+"'"+",false,"+"'"+"EVSELECIONAR.CLICK."+sGXsfl_114_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelecionar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavSelecionar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserFullName_Internalname,(string)A143SecUserFullName,StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserFullName_Link,(string)"",(string)"",(string)"",(string)edtSecUserFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserEmail_Internalname,(string)A144SecUserEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A144SecUserEmail,(string)"",(string)"",(string)"",(string)edtSecUserEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecUserStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECUSERSTATUS_" + sGXsfl_114_idx;
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
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecUserStatus,(string)cmbSecUserStatus_Internalname,StringUtil.BoolToStr( A150SecUserStatus),(short)1,(string)cmbSecUserStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecUserStatus.CurrentValue = StringUtil.BoolToStr( A150SecUserStatus);
            AssignProp("", false, cmbSecUserStatus_Internalname, "Values", (string)(cmbSecUserStatus.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes7S2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector1.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV19DynamicFiltersSelector1);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector2.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV24DynamicFiltersSelector2);
            AssignAttri("", false, "AV24DynamicFiltersSelector2", AV24DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERMANNAME", "Usuário manutenção", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "SECUSERSTATUS_" + sGXsfl_114_idx;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV5Selecionar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelecionar_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A141SecUserName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
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
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
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
         bttBtnbtncancelar_Internalname = "BTNBTNCANCELAR";
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
         edtavSelecionar_Internalname = "vSELECIONAR";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtSecUserEmail_Internalname = "SECUSEREMAIL";
         cmbSecUserStatus_Internalname = "SECUSERSTATUS";
         edtSecUserId_Internalname = "SECUSERID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Ucmessage_Internalname = "UCMESSAGE";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
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
         edtSecUserId_Jsonclick = "";
         cmbSecUserStatus_Jsonclick = "";
         edtSecUserEmail_Jsonclick = "";
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Link = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtavSelecionar_Jsonclick = "";
         edtavSelecionar_Enabled = 1;
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
         edtSecUserId_Enabled = 0;
         cmbSecUserStatus.Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserName_Enabled = 0;
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
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WpSelectuserGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|";
         Ddo_grid_Includefilter = "T|T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "1:SecUserName|2:SecUserFullName|3:SecUserEmail|4:SecUserStatus";
         Ddo_grid_Gridinternalname = "";
         Ucmessage_Nextmessageposition = "down";
         Ucmessage_Startposition = "TopRight";
         Ucmessage_Animationspeed = 300;
         Ucmessage_Effectout = "slide";
         Ucmessage_Effectin = "slide";
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ucmessage_Stylingtype = "fontawesome";
         Ucmessage_Minheight = "16";
         Ucmessage_Width = "500";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E267S2","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV5Selecionar","fld":"vSELECIONAR","type":"char"},{"av":"edtSecUserName_Link","ctrl":"SECUSERNAME","prop":"Link"},{"av":"edtSecUserFullName_Link","ctrl":"SECUSERFULLNAME","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E197S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E207S2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E217S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E227S2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E237S2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusermanname1_Visible","ctrl":"vSECUSERMANNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusermanname2_Visible","ctrl":"vSECUSERMANNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusermanname3_Visible","ctrl":"vSECUSERMANNAME3","prop":"Visible"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOBTNCANCELAR'","""{"handler":"E187S2","iparms":[]}""");
         setEventMetadata("VSELECIONAR.CLICK","""{"handler":"E277S2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV22SecUserManName1","fld":"vSECUSERMANNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV24DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV26SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27SecUserManName2","fld":"vSECUSERMANNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV32SecUserManName3","fld":"vSECUSERMANNAME3","pic":"@!","type":"svchar"},{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV23DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV52Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV39TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV42TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV44TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV45TFSecUserStatus_Sel","fld":"vTFSECUSERSTATUS_SEL","pic":"9","type":"int"},{"av":"AV51SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VSELECIONAR.CLICK",""","oparms":[{"av":"AV38ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV25DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV36ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV13GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[]}""");
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
         AV18FilterFullText = "";
         AV19DynamicFiltersSelector1 = "";
         AV21SecUserName1 = "";
         AV22SecUserManName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26SecUserName2 = "";
         AV27SecUserManName2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31SecUserName3 = "";
         AV32SecUserManName3 = "";
         AV52Pgmname = "";
         AV39TFSecUserName = "";
         AV40TFSecUserName_Sel = "";
         AV41TFSecUserFullName = "";
         AV42TFSecUserFullName_Sel = "";
         AV43TFSecUserEmail = "";
         AV44TFSecUserEmail_Sel = "";
         AV13GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV36ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50GridAppliedFilters = "";
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         bttBtnbtncancelar_Jsonclick = "";
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
         ucUcmessage = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5Selecionar = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         GXDecQS = "";
         lV53Wpselectuserds_1_filterfulltext = "";
         lV56Wpselectuserds_4_secusername1 = "";
         lV57Wpselectuserds_5_secusermanname1 = "";
         lV61Wpselectuserds_9_secusername2 = "";
         lV62Wpselectuserds_10_secusermanname2 = "";
         lV66Wpselectuserds_14_secusername3 = "";
         lV67Wpselectuserds_15_secusermanname3 = "";
         lV68Wpselectuserds_16_tfsecusername = "";
         lV70Wpselectuserds_18_tfsecuserfullname = "";
         lV72Wpselectuserds_20_tfsecuseremail = "";
         AV53Wpselectuserds_1_filterfulltext = "";
         AV54Wpselectuserds_2_dynamicfiltersselector1 = "";
         AV56Wpselectuserds_4_secusername1 = "";
         AV57Wpselectuserds_5_secusermanname1 = "";
         AV59Wpselectuserds_7_dynamicfiltersselector2 = "";
         AV61Wpselectuserds_9_secusername2 = "";
         AV62Wpselectuserds_10_secusermanname2 = "";
         AV64Wpselectuserds_12_dynamicfiltersselector3 = "";
         AV66Wpselectuserds_14_secusername3 = "";
         AV67Wpselectuserds_15_secusermanname3 = "";
         AV69Wpselectuserds_17_tfsecusername_sel = "";
         AV68Wpselectuserds_16_tfsecusername = "";
         AV71Wpselectuserds_19_tfsecuserfullname_sel = "";
         AV70Wpselectuserds_18_tfsecuserfullname = "";
         AV73Wpselectuserds_21_tfsecuseremail_sel = "";
         AV72Wpselectuserds_20_tfsecuseremail = "";
         A148SecUserManName = "";
         H007S3_A147SecUserUserMan = new short[1] ;
         H007S3_n147SecUserUserMan = new bool[] {false} ;
         H007S3_A148SecUserManName = new string[] {""} ;
         H007S3_n148SecUserManName = new bool[] {false} ;
         H007S3_A133SecUserId = new short[1] ;
         H007S3_A150SecUserStatus = new bool[] {false} ;
         H007S3_n150SecUserStatus = new bool[] {false} ;
         H007S3_A144SecUserEmail = new string[] {""} ;
         H007S3_n144SecUserEmail = new bool[] {false} ;
         H007S3_A143SecUserFullName = new string[] {""} ;
         H007S3_n143SecUserFullName = new bool[] {false} ;
         H007S3_A141SecUserName = new string[] {""} ;
         H007S3_n141SecUserName = new bool[] {false} ;
         H007S3_A40000SecUserRoleActive = new bool[] {false} ;
         H007S3_n40000SecUserRoleActive = new bool[] {false} ;
         H007S5_AGRID_nRecordCount = new long[1] ;
         AV10HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV37ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV35Session = context.GetSession();
         AV14GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV15GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV6SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpselectuser__default(),
            new Object[][] {
                new Object[] {
               H007S3_A147SecUserUserMan, H007S3_n147SecUserUserMan, H007S3_A148SecUserManName, H007S3_n148SecUserManName, H007S3_A133SecUserId, H007S3_A150SecUserStatus, H007S3_n150SecUserStatus, H007S3_A144SecUserEmail, H007S3_n144SecUserEmail, H007S3_A143SecUserFullName,
               H007S3_n143SecUserFullName, H007S3_A141SecUserName, H007S3_n141SecUserName, H007S3_A40000SecUserRoleActive, H007S3_n40000SecUserRoleActive
               }
               , new Object[] {
               H007S5_AGRID_nRecordCount
               }
            }
         );
         AV52Pgmname = "WpSelectuser";
         /* GeneXus formulas. */
         AV52Pgmname = "WpSelectuser";
         edtavSelecionar_Enabled = 0;
      }

      private short AV51SecRoleId ;
      private short wcpOAV51SecRoleId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16OrderedBy ;
      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV38ManageFiltersExecutionStep ;
      private short AV45TFSecUserStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A133SecUserId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV55Wpselectuserds_3_dynamicfiltersoperator1 ;
      private short AV60Wpselectuserds_8_dynamicfiltersoperator2 ;
      private short AV65Wpselectuserds_13_dynamicfiltersoperator3 ;
      private short AV74Wpselectuserds_22_tfsecuserstatus_sel ;
      private short A147SecUserUserMan ;
      private short gxcookieaux ;
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
      private int Gridpaginationbar_Pagestoshow ;
      private int Ucmessage_Animationspeed ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavSelecionar_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtSecUserEmail_Enabled ;
      private int edtSecUserId_Enabled ;
      private int AV47PageToGo ;
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
      private int AV75GXV1 ;
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
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
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
      private string sGXsfl_114_idx="0001" ;
      private string AV52Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ucmessage_Width ;
      private string Ucmessage_Minheight ;
      private string Ucmessage_Stylingtype ;
      private string Ucmessage_Effectin ;
      private string Ucmessage_Effectout ;
      private string Ucmessage_Startposition ;
      private string Ucmessage_Nextmessageposition ;
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
      private string bttBtnbtncancelar_Internalname ;
      private string bttBtnbtncancelar_Jsonclick ;
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
      private string Ucmessage_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV5Selecionar ;
      private string edtavSelecionar_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserEmail_Internalname ;
      private string cmbSecUserStatus_Internalname ;
      private string edtSecUserId_Internalname ;
      private string GXDecQS ;
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
      private string edtSecUserName_Link ;
      private string edtSecUserFullName_Link ;
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
      private string sGXsfl_114_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavSelecionar_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtSecUserEmail_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecUserStatus_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17OrderedDsc ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV34DynamicFiltersIgnoreFirst ;
      private bool AV33DynamicFiltersRemoving ;
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
      private bool Ucmessage_Stoponerror ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool A150SecUserStatus ;
      private bool n150SecUserStatus ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV58Wpselectuserds_6_dynamicfiltersenabled2 ;
      private bool AV63Wpselectuserds_11_dynamicfiltersenabled3 ;
      private bool A40000SecUserRoleActive ;
      private bool n147SecUserUserMan ;
      private bool n148SecUserManName ;
      private bool n40000SecUserRoleActive ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV37ManageFiltersXml ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21SecUserName1 ;
      private string AV22SecUserManName1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26SecUserName2 ;
      private string AV27SecUserManName2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31SecUserName3 ;
      private string AV32SecUserManName3 ;
      private string AV39TFSecUserName ;
      private string AV40TFSecUserName_Sel ;
      private string AV41TFSecUserFullName ;
      private string AV42TFSecUserFullName_Sel ;
      private string AV43TFSecUserEmail ;
      private string AV44TFSecUserEmail_Sel ;
      private string AV50GridAppliedFilters ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string lV53Wpselectuserds_1_filterfulltext ;
      private string lV56Wpselectuserds_4_secusername1 ;
      private string lV57Wpselectuserds_5_secusermanname1 ;
      private string lV61Wpselectuserds_9_secusername2 ;
      private string lV62Wpselectuserds_10_secusermanname2 ;
      private string lV66Wpselectuserds_14_secusername3 ;
      private string lV67Wpselectuserds_15_secusermanname3 ;
      private string lV68Wpselectuserds_16_tfsecusername ;
      private string lV70Wpselectuserds_18_tfsecuserfullname ;
      private string lV72Wpselectuserds_20_tfsecuseremail ;
      private string AV53Wpselectuserds_1_filterfulltext ;
      private string AV54Wpselectuserds_2_dynamicfiltersselector1 ;
      private string AV56Wpselectuserds_4_secusername1 ;
      private string AV57Wpselectuserds_5_secusermanname1 ;
      private string AV59Wpselectuserds_7_dynamicfiltersselector2 ;
      private string AV61Wpselectuserds_9_secusername2 ;
      private string AV62Wpselectuserds_10_secusermanname2 ;
      private string AV64Wpselectuserds_12_dynamicfiltersselector3 ;
      private string AV66Wpselectuserds_14_secusername3 ;
      private string AV67Wpselectuserds_15_secusermanname3 ;
      private string AV69Wpselectuserds_17_tfsecusername_sel ;
      private string AV68Wpselectuserds_16_tfsecusername ;
      private string AV71Wpselectuserds_19_tfsecuserfullname_sel ;
      private string AV70Wpselectuserds_18_tfsecuserfullname ;
      private string AV73Wpselectuserds_21_tfsecuseremail_sel ;
      private string AV72Wpselectuserds_20_tfsecuseremail ;
      private string A148SecUserManName ;
      private IGxSession AV35Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV10HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbSecUserStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV13GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV36ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H007S3_A147SecUserUserMan ;
      private bool[] H007S3_n147SecUserUserMan ;
      private string[] H007S3_A148SecUserManName ;
      private bool[] H007S3_n148SecUserManName ;
      private short[] H007S3_A133SecUserId ;
      private bool[] H007S3_A150SecUserStatus ;
      private bool[] H007S3_n150SecUserStatus ;
      private string[] H007S3_A144SecUserEmail ;
      private bool[] H007S3_n144SecUserEmail ;
      private string[] H007S3_A143SecUserFullName ;
      private bool[] H007S3_n143SecUserFullName ;
      private string[] H007S3_A141SecUserName ;
      private bool[] H007S3_n141SecUserName ;
      private bool[] H007S3_A40000SecUserRoleActive ;
      private bool[] H007S3_n40000SecUserRoleActive ;
      private long[] H007S5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV14GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV15GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole AV6SecUserRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpselectuser__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007S3( IGxContext context ,
                                             string AV53Wpselectuserds_1_filterfulltext ,
                                             string AV54Wpselectuserds_2_dynamicfiltersselector1 ,
                                             short AV55Wpselectuserds_3_dynamicfiltersoperator1 ,
                                             string AV56Wpselectuserds_4_secusername1 ,
                                             string AV57Wpselectuserds_5_secusermanname1 ,
                                             bool AV58Wpselectuserds_6_dynamicfiltersenabled2 ,
                                             string AV59Wpselectuserds_7_dynamicfiltersselector2 ,
                                             short AV60Wpselectuserds_8_dynamicfiltersoperator2 ,
                                             string AV61Wpselectuserds_9_secusername2 ,
                                             string AV62Wpselectuserds_10_secusermanname2 ,
                                             bool AV63Wpselectuserds_11_dynamicfiltersenabled3 ,
                                             string AV64Wpselectuserds_12_dynamicfiltersselector3 ,
                                             short AV65Wpselectuserds_13_dynamicfiltersoperator3 ,
                                             string AV66Wpselectuserds_14_secusername3 ,
                                             string AV67Wpselectuserds_15_secusermanname3 ,
                                             string AV69Wpselectuserds_17_tfsecusername_sel ,
                                             string AV68Wpselectuserds_16_tfsecusername ,
                                             string AV71Wpselectuserds_19_tfsecuserfullname_sel ,
                                             string AV70Wpselectuserds_18_tfsecuserfullname ,
                                             string AV73Wpselectuserds_21_tfsecuseremail_sel ,
                                             string AV72Wpselectuserds_20_tfsecuseremail ,
                                             short AV74Wpselectuserds_22_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             bool A40000SecUserRoleActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[27];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecUserUserMan AS SecUserUserMan, T2.SecUserName AS SecUserManName, T1.SecUserId, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, T1.SecUserName, COALESCE( T3.SecUserRoleActive, FALSE) AS SecUserRoleActive";
         sFromString = " FROM ((SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan) LEFT JOIN (SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :AV51SecRoleId ) T3 ON T3.SecUserId = T1.SecUserId)";
         sOrderString = "";
         AddWhere(sWhereString, "(COALESCE( T3.SecUserRoleActive, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecUserName like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( T1.SecUserFullName like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( T1.SecUserEmail like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV56Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV56Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV57Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV57Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV61Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV61Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV62Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV62Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV66Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV66Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpselectuserds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpselectuserds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV68Wpselectuserds_16_tfsecusername)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpselectuserds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV69Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV69Wpselectuserds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_19_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_18_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV70Wpselectuserds_18_tfsecuserfullname)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_19_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV71Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV71Wpselectuserds_19_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpselectuserds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV72Wpselectuserds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV73Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV73Wpselectuserds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV74Wpselectuserds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV74Wpselectuserds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserName, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserName DESC, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserFullName, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserFullName DESC, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserEmail, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserEmail DESC, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserStatus, T1.SecUserId";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
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

      protected Object[] conditional_H007S5( IGxContext context ,
                                             string AV53Wpselectuserds_1_filterfulltext ,
                                             string AV54Wpselectuserds_2_dynamicfiltersselector1 ,
                                             short AV55Wpselectuserds_3_dynamicfiltersoperator1 ,
                                             string AV56Wpselectuserds_4_secusername1 ,
                                             string AV57Wpselectuserds_5_secusermanname1 ,
                                             bool AV58Wpselectuserds_6_dynamicfiltersenabled2 ,
                                             string AV59Wpselectuserds_7_dynamicfiltersselector2 ,
                                             short AV60Wpselectuserds_8_dynamicfiltersoperator2 ,
                                             string AV61Wpselectuserds_9_secusername2 ,
                                             string AV62Wpselectuserds_10_secusermanname2 ,
                                             bool AV63Wpselectuserds_11_dynamicfiltersenabled3 ,
                                             string AV64Wpselectuserds_12_dynamicfiltersselector3 ,
                                             short AV65Wpselectuserds_13_dynamicfiltersoperator3 ,
                                             string AV66Wpselectuserds_14_secusername3 ,
                                             string AV67Wpselectuserds_15_secusermanname3 ,
                                             string AV69Wpselectuserds_17_tfsecusername_sel ,
                                             string AV68Wpselectuserds_16_tfsecusername ,
                                             string AV71Wpselectuserds_19_tfsecuserfullname_sel ,
                                             string AV70Wpselectuserds_18_tfsecuserfullname ,
                                             string AV73Wpselectuserds_21_tfsecuseremail_sel ,
                                             string AV72Wpselectuserds_20_tfsecuseremail ,
                                             short AV74Wpselectuserds_22_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             bool A40000SecUserRoleActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[24];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan) LEFT JOIN (SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecRoleId = :AV51SecRoleId ) T3 ON T3.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecUserRoleActive, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Wpselectuserds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecUserName like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( T1.SecUserFullName like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( T1.SecUserEmail like '%' || :lV53Wpselectuserds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV53Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV53Wpselectuserds_1_filterfulltext) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV56Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wpselectuserds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV56Wpselectuserds_4_secusername1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV57Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Wpselectuserds_2_dynamicfiltersselector1, "SECUSERMANNAME") == 0 ) && ( AV55Wpselectuserds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wpselectuserds_5_secusermanname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV57Wpselectuserds_5_secusermanname1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV61Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wpselectuserds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV61Wpselectuserds_9_secusername2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV62Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV58Wpselectuserds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wpselectuserds_7_dynamicfiltersselector2, "SECUSERMANNAME") == 0 ) && ( AV60Wpselectuserds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wpselectuserds_10_secusermanname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV62Wpselectuserds_10_secusermanname2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV66Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wpselectuserds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV66Wpselectuserds_14_secusername3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV63Wpselectuserds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Wpselectuserds_12_dynamicfiltersselector3, "SECUSERMANNAME") == 0 ) && ( AV65Wpselectuserds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wpselectuserds_15_secusermanname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67Wpselectuserds_15_secusermanname3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpselectuserds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wpselectuserds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV68Wpselectuserds_16_tfsecusername)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpselectuserds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV69Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV69Wpselectuserds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wpselectuserds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_19_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpselectuserds_18_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV70Wpselectuserds_18_tfsecuserfullname)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wpselectuserds_19_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV71Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV71Wpselectuserds_19_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wpselectuserds_19_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpselectuserds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV72Wpselectuserds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpselectuserds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV73Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV73Wpselectuserds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV73Wpselectuserds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV74Wpselectuserds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV74Wpselectuserds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
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
                     return conditional_H007S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] );
               case 1 :
                     return conditional_H007S5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (bool)dynConstraints[29] );
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
          Object[] prmH007S3;
          prmH007S3 = new Object[] {
          new ParDef("AV51SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV56Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV62Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV62Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV67Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV67Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV68Wpselectuserds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV69Wpselectuserds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_18_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV71Wpselectuserds_19_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV72Wpselectuserds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV73Wpselectuserds_21_tfsecuseremail_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007S5;
          prmH007S5 = new Object[] {
          new ParDef("AV51SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV53Wpselectuserds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV56Wpselectuserds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV57Wpselectuserds_5_secusermanname1",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV61Wpselectuserds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV62Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV62Wpselectuserds_10_secusermanname2",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV66Wpselectuserds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV67Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV67Wpselectuserds_15_secusermanname3",GXType.VarChar,100,0) ,
          new ParDef("lV68Wpselectuserds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV69Wpselectuserds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpselectuserds_18_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV71Wpselectuserds_19_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV72Wpselectuserds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV73Wpselectuserds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007S3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007S5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007S5,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
