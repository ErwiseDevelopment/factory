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
   public class wpaddfunc : GXDataArea
   {
      public wpaddfunc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpaddfunc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV65SecRoleId = aP0_SecRoleId;
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
         chkavSelected = new GXCheckbox();
         cmbSecFunctionalityType = new GXCombobox();
         chkSecFunctionalityActive = new GXCheckbox();
         chkavSelectall = new GXCheckbox();
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
         chkavSelected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
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
         AV18SecFunctionalityDescription1 = GetPar( "SecFunctionalityDescription1");
         AV19SecParentFunctionalityDescription1 = GetPar( "SecParentFunctionalityDescription1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23SecFunctionalityDescription2 = GetPar( "SecFunctionalityDescription2");
         AV24SecParentFunctionalityDescription2 = GetPar( "SecParentFunctionalityDescription2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28SecFunctionalityDescription3 = GetPar( "SecFunctionalityDescription3");
         AV29SecParentFunctionalityDescription3 = GetPar( "SecParentFunctionalityDescription3");
         AV35ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV69Pgmname = GetPar( "Pgmname");
         AV59SecFunctionalityIdJson = GetPar( "SecFunctionalityIdJson");
         AV40TFSecFunctionalityDescription = GetPar( "TFSecFunctionalityDescription");
         AV41TFSecFunctionalityDescription_Sel = GetPar( "TFSecFunctionalityDescription_Sel");
         AV67TFSecFunctionalityModule = GetPar( "TFSecFunctionalityModule");
         AV68TFSecFunctionalityModule_Sel = GetPar( "TFSecFunctionalityModule_Sel");
         AV48TFSecFunctionalityActive_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSecFunctionalityActive_Sel"), "."), 18, MidpointRounding.ToEven));
         AV65SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         chkavSelected_Titleformat = (short)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AV57i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV58SecFunctionalityIdCol);
         AV61SecFunctionalityIdToFind = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityIdToFind"), "."), 18, MidpointRounding.ToEven));
         AV62SelectAll = StringUtil.StrToBool( GetPar( "SelectAll"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
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
         PA7X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7X2( ) ;
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
         GXEncryptionTmp = "wpaddfunc"+UrlEncode(StringUtil.LTrimStr(AV65SecRoleId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpaddfunc") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65SecRoleId), "ZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION1", AV18SecFunctionalityDescription1);
         GxWebStd.gx_hidden_field( context, "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION1", AV19SecParentFunctionalityDescription1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION2", AV23SecFunctionalityDescription2);
         GxWebStd.gx_hidden_field( context, "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION2", AV24SecParentFunctionalityDescription2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION3", AV28SecFunctionalityDescription3);
         GxWebStd.gx_hidden_field( context, "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION3", AV29SecParentFunctionalityDescription3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV33ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV33ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV51GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV53GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV49DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDJSON", AV59SecFunctionalityIdJson);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION", AV40TFSecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION_SEL", AV41TFSecFunctionalityDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYMODULE", AV67TFSecFunctionalityModule);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYMODULE_SEL", AV68TFSecFunctionalityModule_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYACTIVE_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65SecRoleId), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57i), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYIDCOL", AV58SecFunctionalityIdCol);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYIDCOL", AV58SecFunctionalityIdCol);
         }
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDTOFIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61SecFunctionalityIdToFind), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDROWS", AV55SelectedRows);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDROWS", AV55SelectedRows);
         }
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
         GxWebStd.gx_hidden_field( context, "vSELECTED_Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSelected_Titleformat), 4, 0, ".", "")));
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
            WE7X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7X2( ) ;
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
         GXEncryptionTmp = "wpaddfunc"+UrlEncode(StringUtil.LTrimStr(AV65SecRoleId,4,0));
         return formatLink("wpaddfunc") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WPAddFunc" ;
      }

      public override string GetPgmdesc( )
      {
         return " Functionality" ;
      }

      protected void WB7X0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
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
            ClassString = "Button WWPBtnNeedMultiRowSelection";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtninserirpop_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Confirmar", bttBtnbtninserirpop_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNINSERIRPOP\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPAddFunc.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV33ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WPAddFunc.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_7X2( true) ;
         }
         else
         {
            wb_table1_43_7X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_7X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_7X2( true) ;
         }
         else
         {
            wb_table2_68_7X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_7X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_7X2( true) ;
         }
         else
         {
            wb_table3_93_7X2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_7X2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV51GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV52GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV53GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WPAddFunc.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV49DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_114_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectall_Internalname, StringUtil.BoolToStr( AV62SelectAll), "", "", chkavSelectall.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
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

      protected void START7X2( )
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
         Form.Meta.addItem("description", " Functionality", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7X0( ) ;
      }

      protected void WS7X2( )
      {
         START7X2( ) ;
         EVT7X2( ) ;
      }

      protected void EVT7X2( )
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
                              E117X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNINSERIRPOP'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnInserirPop' */
                              E187X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTALL.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E197X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E207X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E217X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E227X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E247X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV54Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
                              AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
                              A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
                              n130SecFunctionalityKey = false;
                              A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              n135SecFunctionalityDescription = false;
                              A789SecFunctionalityModule = cgiGet( edtSecFunctionalityModule_Internalname);
                              n789SecFunctionalityModule = false;
                              cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
                              cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
                              A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
                              n136SecFunctionalityType = false;
                              A129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n129SecParentFunctionalityId = false;
                              A138SecParentFunctionalityDescription = cgiGet( edtSecParentFunctionalityDescription_Internalname);
                              n138SecParentFunctionalityDescription = false;
                              A134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( chkSecFunctionalityActive_Internalname));
                              n134SecFunctionalityActive = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E257X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E267X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E277X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E287X2 ();
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
                                       /* Set Refresh If Secfunctionalitydescription1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION1"), AV18SecFunctionalityDescription1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secparentfunctionalitydescription1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION1"), AV19SecParentFunctionalityDescription1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION2"), AV23SecFunctionalityDescription2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secparentfunctionalitydescription2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION2"), AV24SecParentFunctionalityDescription2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION3"), AV28SecFunctionalityDescription3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secparentfunctionalitydescription3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION3"), AV29SecParentFunctionalityDescription3) != 0 )
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

      protected void WE7X2( )
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

      protected void PA7X2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpaddfunc")), "wpaddfunc") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpaddfunc")))) ;
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
                     AV65SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV65SecRoleId", StringUtil.LTrimStr( (decimal)(AV65SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65SecRoleId), "ZZZ9"), context));
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
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       string AV15FilterFullText ,
                                       string AV16DynamicFiltersSelector1 ,
                                       short AV17DynamicFiltersOperator1 ,
                                       string AV18SecFunctionalityDescription1 ,
                                       string AV19SecParentFunctionalityDescription1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23SecFunctionalityDescription2 ,
                                       string AV24SecParentFunctionalityDescription2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28SecFunctionalityDescription3 ,
                                       string AV29SecParentFunctionalityDescription3 ,
                                       short AV35ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV69Pgmname ,
                                       string AV59SecFunctionalityIdJson ,
                                       string AV40TFSecFunctionalityDescription ,
                                       string AV41TFSecFunctionalityDescription_Sel ,
                                       string AV67TFSecFunctionalityModule ,
                                       string AV68TFSecFunctionalityModule_Sel ,
                                       short AV48TFSecFunctionalityActive_Sel ,
                                       short AV65SecRoleId ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       long AV57i ,
                                       GxSimpleCollection<long> AV58SecFunctionalityIdCol ,
                                       long AV61SecFunctionalityIdToFind ,
                                       bool AV62SelectAll )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYKEY", A130SecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYDESCRIPTION", A135SecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYMODULE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A789SecFunctionalityModule, "")), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYMODULE", A789SecFunctionalityModule);
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYTYPE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A136SecFunctionalityType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SECPARENTFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECPARENTFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYACTIVE", GetSecureSignedToken( "", A134SecFunctionalityActive, context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYACTIVE", StringUtil.BoolToStr( A134SecFunctionalityActive));
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
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
         AV62SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV62SelectAll));
         AssignAttri("", false, "AV62SelectAll", AV62SelectAll);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "WPAddFunc";
      }

      protected void RF7X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E267X2 ();
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
                                                 AV70Wpaddfuncds_1_filterfulltext ,
                                                 AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                                 AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                                 AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                                 AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                                 AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                                 AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                                 AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                                 AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                                 AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                                 AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                                 AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                                 AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                                 AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                                 AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                                 AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                                 AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                                 AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                                 AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                                 AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                                 A135SecFunctionalityDescription ,
                                                 A789SecFunctionalityModule ,
                                                 A138SecParentFunctionalityDescription ,
                                                 A134SecFunctionalityActive ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A40000SecFunctionalityRoleAtivo } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
            lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
            lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
            lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
            lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
            lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
            lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
            lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
            lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
            lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
            lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
            lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
            lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
            lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
            lV85Wpaddfuncds_16_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription), "%", "");
            lV87Wpaddfuncds_18_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule), "%", "");
            /* Using cursor H007X3 */
            pr_default.execute(0, new Object[] {AV65SecRoleId, lV70Wpaddfuncds_1_filterfulltext, lV70Wpaddfuncds_1_filterfulltext, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV85Wpaddfuncds_16_tfsecfunctionalitydescription, AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, lV87Wpaddfuncds_18_tfsecfunctionalitymodule, AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A134SecFunctionalityActive = H007X3_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = H007X3_n134SecFunctionalityActive[0];
               A138SecParentFunctionalityDescription = H007X3_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H007X3_n138SecParentFunctionalityDescription[0];
               A129SecParentFunctionalityId = H007X3_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H007X3_n129SecParentFunctionalityId[0];
               A136SecFunctionalityType = H007X3_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H007X3_n136SecFunctionalityType[0];
               A789SecFunctionalityModule = H007X3_A789SecFunctionalityModule[0];
               n789SecFunctionalityModule = H007X3_n789SecFunctionalityModule[0];
               A135SecFunctionalityDescription = H007X3_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H007X3_n135SecFunctionalityDescription[0];
               A130SecFunctionalityKey = H007X3_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H007X3_n130SecFunctionalityKey[0];
               A128SecFunctionalityId = H007X3_A128SecFunctionalityId[0];
               A40000SecFunctionalityRoleAtivo = H007X3_A40000SecFunctionalityRoleAtivo[0];
               n40000SecFunctionalityRoleAtivo = H007X3_n40000SecFunctionalityRoleAtivo[0];
               A138SecParentFunctionalityDescription = H007X3_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H007X3_n138SecParentFunctionalityDescription[0];
               A40000SecFunctionalityRoleAtivo = H007X3_A40000SecFunctionalityRoleAtivo[0];
               n40000SecFunctionalityRoleAtivo = H007X3_n40000SecFunctionalityRoleAtivo[0];
               /* Execute user event: Grid.Load */
               E277X2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 114;
            WB7X0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYKEY"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYDESCRIPTION"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYMODULE"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, StringUtil.RTrim( context.localUtil.Format( A789SecFunctionalityModule, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYTYPE"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A136SecFunctionalityType), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECPARENTFUNCTIONALITYID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYACTIVE"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, A134SecFunctionalityActive, context));
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
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV70Wpaddfuncds_1_filterfulltext ,
                                              AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                              AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                              AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                              AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                              AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                              AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                              AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                              AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                              AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                              AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                              AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                              AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                              AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                              AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                              AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                              AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                              AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                              AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                              AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                              A135SecFunctionalityDescription ,
                                              A789SecFunctionalityModule ,
                                              A138SecParentFunctionalityDescription ,
                                              A134SecFunctionalityActive ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A40000SecFunctionalityRoleAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
         lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
         lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV85Wpaddfuncds_16_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription), "%", "");
         lV87Wpaddfuncds_18_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule), "%", "");
         /* Using cursor H007X5 */
         pr_default.execute(1, new Object[] {AV65SecRoleId, lV70Wpaddfuncds_1_filterfulltext, lV70Wpaddfuncds_1_filterfulltext, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV85Wpaddfuncds_16_tfsecfunctionalitydescription, AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, lV87Wpaddfuncds_18_tfsecfunctionalitymodule, AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel});
         GRID_nRecordCount = H007X5_AGRID_nRecordCount[0];
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
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "WPAddFunc";
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityModule_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         chkSecFunctionalityActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E257X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV33ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV49DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV51GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV52GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV53GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV18SecFunctionalityDescription1 = cgiGet( edtavSecfunctionalitydescription1_Internalname);
            AssignAttri("", false, "AV18SecFunctionalityDescription1", AV18SecFunctionalityDescription1);
            AV19SecParentFunctionalityDescription1 = cgiGet( edtavSecparentfunctionalitydescription1_Internalname);
            AssignAttri("", false, "AV19SecParentFunctionalityDescription1", AV19SecParentFunctionalityDescription1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV23SecFunctionalityDescription2 = cgiGet( edtavSecfunctionalitydescription2_Internalname);
            AssignAttri("", false, "AV23SecFunctionalityDescription2", AV23SecFunctionalityDescription2);
            AV24SecParentFunctionalityDescription2 = cgiGet( edtavSecparentfunctionalitydescription2_Internalname);
            AssignAttri("", false, "AV24SecParentFunctionalityDescription2", AV24SecParentFunctionalityDescription2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28SecFunctionalityDescription3 = cgiGet( edtavSecfunctionalitydescription3_Internalname);
            AssignAttri("", false, "AV28SecFunctionalityDescription3", AV28SecFunctionalityDescription3);
            AV29SecParentFunctionalityDescription3 = cgiGet( edtavSecparentfunctionalitydescription3_Internalname);
            AssignAttri("", false, "AV29SecParentFunctionalityDescription3", AV29SecParentFunctionalityDescription3);
            AV62SelectAll = StringUtil.StrToBool( cgiGet( chkavSelectall_Internalname));
            AssignAttri("", false, "AV62SelectAll", AV62SelectAll);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION1"), AV18SecFunctionalityDescription1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION1"), AV19SecParentFunctionalityDescription1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION2"), AV23SecFunctionalityDescription2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION2"), AV24SecParentFunctionalityDescription2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION3"), AV28SecFunctionalityDescription3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECPARENTFUNCTIONALITYDESCRIPTION3"), AV29SecParentFunctionalityDescription3) != 0 )
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
         E257X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E257X2( )
      {
         /* Start Routine */
         returnInSub = false;
         chkavSelectall.Visible = 0;
         AssignProp("", false, chkavSelectall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSelectall.Visible), 5, 0), true);
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
         AV16DynamicFiltersSelector1 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         Form.Caption = " Functionality";
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
         chkavSelected_Titleformat = 1;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV49DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV49DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E267X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV35ManageFiltersExecutionStep == 1 )
         {
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV35ManageFiltersExecutionStep == 2 )
         {
            AV35ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
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
         chkavSelected.Title.Text = StringUtil.Format( "<input name=\"selectAllCheckbox\" type=\"checkbox\" value=\"Select All\" onchange=\"$(%1).click();\" class=\"AttributeCheckBox\" >", "'#"+chkavSelectall_Internalname+"'", "", "", "", "", "", "", "", "");
         AssignProp("", false, chkavSelected_Internalname, "Title", chkavSelected.Title.Text, !bGXsfl_114_Refreshing);
         AV62SelectAll = false;
         AssignAttri("", false, "AV62SelectAll", AV62SelectAll);
         AV51GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV51GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV51GridCurrentPage), 10, 0));
         AV52GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV52GridPageCount", StringUtil.LTrimStr( (decimal)(AV52GridPageCount), 10, 0));
         GXt_char2 = AV53GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char2) ;
         AV53GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV53GridAppliedFilters", AV53GridAppliedFilters);
         AV58SecFunctionalityIdCol.FromJSonString(AV59SecFunctionalityIdJson, null);
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127X2( )
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
            AV50PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV50PageToGo) ;
         }
      }

      protected void E137X2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147X2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityDescription") == 0 )
            {
               AV40TFSecFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFSecFunctionalityDescription", AV40TFSecFunctionalityDescription);
               AV41TFSecFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFSecFunctionalityDescription_Sel", AV41TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityModule") == 0 )
            {
               AV67TFSecFunctionalityModule = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFSecFunctionalityModule", AV67TFSecFunctionalityModule);
               AV68TFSecFunctionalityModule_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFSecFunctionalityModule_Sel", AV68TFSecFunctionalityModule_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityActive") == 0 )
            {
               AV48TFSecFunctionalityActive_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFSecFunctionalityActive_Sel", StringUtil.Str( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E277X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV54Selected = false;
         AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
         AV61SecFunctionalityIdToFind = A128SecFunctionalityId;
         AssignAttri("", false, "AV61SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV61SecFunctionalityIdToFind), 10, 0));
         /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV57i > 0 )
         {
            AV54Selected = true;
            AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
         }
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

      protected void E287X2( )
      {
         /* Selected_Click Routine */
         returnInSub = false;
         if ( AV54Selected )
         {
            AV58SecFunctionalityIdCol.Add(A128SecFunctionalityId, 0);
         }
         else
         {
            AV61SecFunctionalityIdToFind = A128SecFunctionalityId;
            AssignAttri("", false, "AV61SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV61SecFunctionalityIdToFind), 10, 0));
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV58SecFunctionalityIdCol.RemoveItem((int)(AV57i));
         }
         AV59SecFunctionalityIdJson = AV58SecFunctionalityIdCol.ToJSonString(false);
         AssignAttri("", false, "AV59SecFunctionalityIdJson", AV59SecFunctionalityIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV58SecFunctionalityIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
      }

      protected void E207X2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E157X2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E217X2( )
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

      protected void E227X2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E167X2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E237X2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E177X2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18SecFunctionalityDescription1, AV19SecParentFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23SecFunctionalityDescription2, AV24SecParentFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28SecFunctionalityDescription3, AV29SecParentFunctionalityDescription3, AV35ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV69Pgmname, AV59SecFunctionalityIdJson, AV40TFSecFunctionalityDescription, AV41TFSecFunctionalityDescription_Sel, AV67TFSecFunctionalityModule, AV68TFSecFunctionalityModule_Sel, AV48TFSecFunctionalityActive_Sel, AV65SecRoleId, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, AV57i, AV58SecFunctionalityIdCol, AV61SecFunctionalityIdToFind, AV62SelectAll) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E247X2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E117X2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S232 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WPAddFuncFilters")) + "," + UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WPAddFuncFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV34ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WPAddFuncFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV34ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV34ManageFiltersXml) ;
               AV10GridState.FromXml(AV34ManageFiltersXml, null, "", "");
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
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S222 ();
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E187X2( )
      {
         /* 'DoBtnInserirPop' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADSELECTEDROWS' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV55SelectedRows.Count == 0 )
         {
            GX_msglist.addItem("Nenhum registro selecionado.");
         }
         if ( AV55SelectedRows.Count != 0 )
         {
            AV90GXV1 = 1;
            while ( AV90GXV1 <= AV55SelectedRows.Count )
            {
               AV56SelectedRow = ((SdtWPAddFuncSDT_WPAddFuncSDTItem)AV55SelectedRows.Item(AV90GXV1));
               AV64SecFunctionalityRole.Load(AV56SelectedRow.gxTpr_Secfunctionalityid, AV65SecRoleId);
               AV64SecFunctionalityRole.gxTpr_Secfunctionalityid = AV56SelectedRow.gxTpr_Secfunctionalityid;
               AV64SecFunctionalityRole.gxTpr_Secroleid = AV65SecRoleId;
               AV64SecFunctionalityRole.gxTpr_Secfunctionalityroleativo = true;
               AV64SecFunctionalityRole.Save();
               if ( AV64SecFunctionalityRole.Success() )
               {
                  context.CommitDataStores("wpaddfunc",pr_default);
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Sucesso!",  "Dados gravados com sucesso!",  "success",  "",  "true",  ""));
                  context.setWebReturnParms(new Object[] {});
                  context.setWebReturnParmsMetadata(new Object[] {});
                  context.wjLocDisableFrm = 1;
                  context.nUserReturn = 1;
                  returnInSub = true;
                  if (true) return;
               }
               else
               {
                  context.RollbackDataStores("wpaddfunc",pr_default);
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atenção!",  "",  "error",  "",  "true",  ""));
               }
               AV90GXV1 = (int)(AV90GXV1+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV55SelectedRows", AV55SelectedRows);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
      }

      protected void E197X2( )
      {
         /* Selectall_Click Routine */
         returnInSub = false;
         AV58SecFunctionalityIdCol = (GxSimpleCollection<long>)(new GxSimpleCollection<long>());
         if ( AV62SelectAll )
         {
            /* Execute user subroutine: 'ADD ALL RECORDS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Start For Each Line */
         nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_114_fel_idx = 0;
         while ( nGXsfl_114_fel_idx < nRC_GXsfl_114 )
         {
            nGXsfl_114_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_114_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_fel_idx+1);
            sGXsfl_114_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1142( ) ;
            AV54Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
            A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
            n130SecFunctionalityKey = false;
            A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
            n135SecFunctionalityDescription = false;
            A789SecFunctionalityModule = cgiGet( edtSecFunctionalityModule_Internalname);
            n789SecFunctionalityModule = false;
            cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
            cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
            A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
            n136SecFunctionalityType = false;
            A129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n129SecParentFunctionalityId = false;
            A138SecParentFunctionalityDescription = cgiGet( edtSecParentFunctionalityDescription_Internalname);
            n138SecParentFunctionalityDescription = false;
            A134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( chkSecFunctionalityActive_Internalname));
            n134SecFunctionalityActive = false;
            AV54Selected = AV62SelectAll;
            AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
            /* End For Each Line */
         }
         if ( nGXsfl_114_fel_idx == 0 )
         {
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         nGXsfl_114_fel_idx = 1;
         AV59SecFunctionalityIdJson = AV58SecFunctionalityIdCol.ToJSonString(false);
         AssignAttri("", false, "AV59SecFunctionalityIdJson", AV59SecFunctionalityIdJson);
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV58SecFunctionalityIdCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV58SecFunctionalityIdCol", AV58SecFunctionalityIdCol);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S192( )
      {
         /* 'GETINDEXOFSELECTEDROW' Routine */
         returnInSub = false;
         AV57i = 1;
         AssignAttri("", false, "AV57i", StringUtil.LTrimStr( (decimal)(AV57i), 10, 0));
         AV92GXV2 = 1;
         while ( AV92GXV2 <= AV58SecFunctionalityIdCol.Count )
         {
            AV60SecFunctionalityIdColItem = (long)(AV58SecFunctionalityIdCol.GetNumeric(AV92GXV2));
            AssignAttri("", false, "AV60SecFunctionalityIdColItem", StringUtil.LTrimStr( (decimal)(AV60SecFunctionalityIdColItem), 10, 0));
            if ( AV60SecFunctionalityIdColItem == AV61SecFunctionalityIdToFind )
            {
               if (true) break;
            }
            AV57i = (long)(AV57i+1);
            AssignAttri("", false, "AV57i", StringUtil.LTrimStr( (decimal)(AV57i), 10, 0));
            AV92GXV2 = (int)(AV92GXV2+1);
         }
         if ( AV57i > AV58SecFunctionalityIdCol.Count )
         {
            AV57i = 0;
            AssignAttri("", false, "AV57i", StringUtil.LTrimStr( (decimal)(AV57i), 10, 0));
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavSecfunctionalitydescription1_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription1_Visible), 5, 0), true);
         edtavSecparentfunctionalitydescription1_Visible = 0;
         AssignProp("", false, edtavSecparentfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription1_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecparentfunctionalitydescription1_Visible = 1;
            AssignProp("", false, edtavSecparentfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSecfunctionalitydescription2_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription2_Visible), 5, 0), true);
         edtavSecparentfunctionalitydescription2_Visible = 0;
         AssignProp("", false, edtavSecparentfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription2_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecparentfunctionalitydescription2_Visible = 1;
            AssignProp("", false, edtavSecparentfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSecfunctionalitydescription3_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription3_Visible), 5, 0), true);
         edtavSecparentfunctionalitydescription3_Visible = 0;
         AssignProp("", false, edtavSecparentfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription3_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecparentfunctionalitydescription3_Visible = 1;
            AssignProp("", false, edtavSecparentfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecparentfunctionalitydescription3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23SecFunctionalityDescription2 = "";
         AssignAttri("", false, "AV23SecFunctionalityDescription2", AV23SecFunctionalityDescription2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28SecFunctionalityDescription3 = "";
         AssignAttri("", false, "AV28SecFunctionalityDescription3", AV28SecFunctionalityDescription3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV33ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WPAddFuncFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV33ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV40TFSecFunctionalityDescription = "";
         AssignAttri("", false, "AV40TFSecFunctionalityDescription", AV40TFSecFunctionalityDescription);
         AV41TFSecFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV41TFSecFunctionalityDescription_Sel", AV41TFSecFunctionalityDescription_Sel);
         AV67TFSecFunctionalityModule = "";
         AssignAttri("", false, "AV67TFSecFunctionalityModule", AV67TFSecFunctionalityModule);
         AV68TFSecFunctionalityModule_Sel = "";
         AssignAttri("", false, "AV68TFSecFunctionalityModule_Sel", AV68TFSecFunctionalityModule_Sel);
         AV48TFSecFunctionalityActive_Sel = 0;
         AssignAttri("", false, "AV48TFSecFunctionalityActive_Sel", StringUtil.Str( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "SECFUNCTIONALITYDESCRIPTION";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18SecFunctionalityDescription1 = "";
         AssignAttri("", false, "AV18SecFunctionalityDescription1", AV18SecFunctionalityDescription1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S252( )
      {
         /* 'LOADSELECTEDROWS' Routine */
         returnInSub = false;
         AV55SelectedRows = new GXBaseCollection<SdtWPAddFuncSDT_WPAddFuncSDTItem>( context, "WPAddFuncSDTItem", "Factory21");
         AV58SecFunctionalityIdCol.FromJSonString(AV59SecFunctionalityIdJson, null);
         AV93GXV3 = 1;
         while ( AV93GXV3 <= AV58SecFunctionalityIdCol.Count )
         {
            AV60SecFunctionalityIdColItem = (long)(AV58SecFunctionalityIdCol.GetNumeric(AV93GXV3));
            AssignAttri("", false, "AV60SecFunctionalityIdColItem", StringUtil.LTrimStr( (decimal)(AV60SecFunctionalityIdColItem), 10, 0));
            AV56SelectedRow = new SdtWPAddFuncSDT_WPAddFuncSDTItem(context);
            /* Using cursor H007X7 */
            pr_default.execute(2, new Object[] {AV65SecRoleId, AV60SecFunctionalityIdColItem});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A128SecFunctionalityId = H007X7_A128SecFunctionalityId[0];
               A130SecFunctionalityKey = H007X7_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H007X7_n130SecFunctionalityKey[0];
               A135SecFunctionalityDescription = H007X7_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H007X7_n135SecFunctionalityDescription[0];
               A789SecFunctionalityModule = H007X7_A789SecFunctionalityModule[0];
               n789SecFunctionalityModule = H007X7_n789SecFunctionalityModule[0];
               A136SecFunctionalityType = H007X7_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H007X7_n136SecFunctionalityType[0];
               A129SecParentFunctionalityId = H007X7_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H007X7_n129SecParentFunctionalityId[0];
               A138SecParentFunctionalityDescription = H007X7_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H007X7_n138SecParentFunctionalityDescription[0];
               A134SecFunctionalityActive = H007X7_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = H007X7_n134SecFunctionalityActive[0];
               A40000SecFunctionalityRoleAtivo = H007X7_A40000SecFunctionalityRoleAtivo[0];
               n40000SecFunctionalityRoleAtivo = H007X7_n40000SecFunctionalityRoleAtivo[0];
               A40000SecFunctionalityRoleAtivo = H007X7_A40000SecFunctionalityRoleAtivo[0];
               n40000SecFunctionalityRoleAtivo = H007X7_n40000SecFunctionalityRoleAtivo[0];
               A138SecParentFunctionalityDescription = H007X7_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H007X7_n138SecParentFunctionalityDescription[0];
               AV56SelectedRow.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
               AV56SelectedRow.gxTpr_Secfunctionalitykey = A130SecFunctionalityKey;
               AV56SelectedRow.gxTpr_Secfunctionalitydescription = A135SecFunctionalityDescription;
               AV56SelectedRow.gxTpr_Secfunctionalitymodule = A789SecFunctionalityModule;
               AV56SelectedRow.gxTpr_Secfunctionalitytype = A136SecFunctionalityType;
               AV56SelectedRow.gxTpr_Secparentfunctionalityid = A129SecParentFunctionalityId;
               AV56SelectedRow.gxTpr_Secparentfunctionalitydescription = A138SecParentFunctionalityDescription;
               AV56SelectedRow.gxTpr_Secfunctionalityactive = A134SecFunctionalityActive;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV55SelectedRows.Add(AV56SelectedRow, 0);
            AV93GXV3 = (int)(AV93GXV3+1);
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV32Session.Get(AV69Pgmname+"GridState"), null, "", "");
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
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
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

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV95GXV4 = 1;
         while ( AV95GXV4 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV95GXV4));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV40TFSecFunctionalityDescription = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFSecFunctionalityDescription", AV40TFSecFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV41TFSecFunctionalityDescription_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFSecFunctionalityDescription_Sel", AV41TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE") == 0 )
            {
               AV67TFSecFunctionalityModule = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFSecFunctionalityModule", AV67TFSecFunctionalityModule);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE_SEL") == 0 )
            {
               AV68TFSecFunctionalityModule_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFSecFunctionalityModule_Sel", AV68TFSecFunctionalityModule_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYACTIVE_SEL") == 0 )
            {
               AV48TFSecFunctionalityActive_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFSecFunctionalityActive_Sel", StringUtil.Str( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0));
            }
            AV95GXV4 = (int)(AV95GXV4+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecFunctionalityDescription_Sel)),  AV41TFSecFunctionalityDescription_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFSecFunctionalityModule_Sel)),  AV68TFSecFunctionalityModule_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+((0==AV48TFSecFunctionalityActive_Sel) ? "" : StringUtil.Str( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecFunctionalityDescription)),  AV40TFSecFunctionalityDescription, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFSecFunctionalityModule)),  AV67TFSecFunctionalityModule, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S222( )
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18SecFunctionalityDescription1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18SecFunctionalityDescription1", AV18SecFunctionalityDescription1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19SecParentFunctionalityDescription1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19SecParentFunctionalityDescription1", AV19SecParentFunctionalityDescription1);
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23SecFunctionalityDescription2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23SecFunctionalityDescription2", AV23SecFunctionalityDescription2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24SecParentFunctionalityDescription2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24SecParentFunctionalityDescription2", AV24SecParentFunctionalityDescription2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28SecFunctionalityDescription3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28SecFunctionalityDescription3", AV28SecFunctionalityDescription3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29SecParentFunctionalityDescription3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29SecParentFunctionalityDescription3", AV29SecParentFunctionalityDescription3);
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
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV32Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECFUNCTIONALITYDESCRIPTION",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecFunctionalityDescription)),  0,  AV40TFSecFunctionalityDescription,  AV40TFSecFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecFunctionalityDescription_Sel)),  AV41TFSecFunctionalityDescription_Sel,  AV41TFSecFunctionalityDescription_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECFUNCTIONALITYMODULE",  "Módulo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFSecFunctionalityModule)),  0,  AV67TFSecFunctionalityModule,  AV67TFSecFunctionalityModule,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFSecFunctionalityModule_Sel)),  AV68TFSecFunctionalityModule_Sel,  AV68TFSecFunctionalityModule_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSECFUNCTIONALITYACTIVE_SEL",  "Ativo",  !(0==AV48TFSecFunctionalityActive_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFSecFunctionalityActive_Sel), 1, 0)),  ((AV48TFSecFunctionalityActive_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         if ( ! (0==AV65SecRoleId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SECROLEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV65SecRoleId), 4, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecFunctionalityDescription1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Description",  AV17DynamicFiltersOperator1,  AV18SecFunctionalityDescription1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18SecFunctionalityDescription1, "Contém"+" "+AV18SecFunctionalityDescription1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SecParentFunctionalityDescription1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Parent Functionality",  AV17DynamicFiltersOperator1,  AV19SecParentFunctionalityDescription1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19SecParentFunctionalityDescription1, "Contém"+" "+AV19SecParentFunctionalityDescription1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SecFunctionalityDescription2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Description",  AV22DynamicFiltersOperator2,  AV23SecFunctionalityDescription2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV23SecFunctionalityDescription2, "Contém"+" "+AV23SecFunctionalityDescription2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecParentFunctionalityDescription2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Parent Functionality",  AV22DynamicFiltersOperator2,  AV24SecParentFunctionalityDescription2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24SecParentFunctionalityDescription2, "Contém"+" "+AV24SecParentFunctionalityDescription2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SecFunctionalityDescription3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Description",  AV27DynamicFiltersOperator3,  AV28SecFunctionalityDescription3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28SecFunctionalityDescription3, "Contém"+" "+AV28SecFunctionalityDescription3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecParentFunctionalityDescription3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Parent Functionality",  AV27DynamicFiltersOperator3,  AV29SecParentFunctionalityDescription3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29SecParentFunctionalityDescription3, "Contém"+" "+AV29SecParentFunctionalityDescription3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecFunctionality";
         AV32Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S262( )
      {
         /* 'ADD ALL RECORDS' Routine */
         returnInSub = false;
         AV70Wpaddfuncds_1_filterfulltext = AV15FilterFullText;
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV72Wpaddfuncds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = AV19SecParentFunctionalityDescription1;
         AV75Wpaddfuncds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV77Wpaddfuncds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = AV24SecParentFunctionalityDescription2;
         AV80Wpaddfuncds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV82Wpaddfuncds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = AV29SecParentFunctionalityDescription3;
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = AV40TFSecFunctionalityDescription;
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = AV41TFSecFunctionalityDescription_Sel;
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = AV67TFSecFunctionalityModule;
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = AV68TFSecFunctionalityModule_Sel;
         AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel = AV48TFSecFunctionalityActive_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV70Wpaddfuncds_1_filterfulltext ,
                                              AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                              AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                              AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                              AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                              AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                              AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                              AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                              AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                              AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                              AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                              AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                              AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                              AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                              AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                              AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                              AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                              AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                              AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                              AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                              A135SecFunctionalityDescription ,
                                              A789SecFunctionalityModule ,
                                              A138SecParentFunctionalityDescription ,
                                              A134SecFunctionalityActive ,
                                              A40000SecFunctionalityRoleAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
         lV70Wpaddfuncds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext), "%", "");
         lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV73Wpaddfuncds_4_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1), "%", "");
         lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV78Wpaddfuncds_9_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2), "%", "");
         lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV83Wpaddfuncds_14_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3), "%", "");
         lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3), "%", "");
         lV85Wpaddfuncds_16_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription), "%", "");
         lV87Wpaddfuncds_18_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule), "%", "");
         /* Using cursor H007X9 */
         pr_default.execute(3, new Object[] {AV65SecRoleId, lV70Wpaddfuncds_1_filterfulltext, lV70Wpaddfuncds_1_filterfulltext, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV73Wpaddfuncds_4_secfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV74Wpaddfuncds_5_secparentfunctionalitydescription1, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV78Wpaddfuncds_9_secfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV79Wpaddfuncds_10_secparentfunctionalitydescription2, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV83Wpaddfuncds_14_secfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV84Wpaddfuncds_15_secparentfunctionalitydescription3, lV85Wpaddfuncds_16_tfsecfunctionalitydescription, AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, lV87Wpaddfuncds_18_tfsecfunctionalitymodule, AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A129SecParentFunctionalityId = H007X9_A129SecParentFunctionalityId[0];
            n129SecParentFunctionalityId = H007X9_n129SecParentFunctionalityId[0];
            A134SecFunctionalityActive = H007X9_A134SecFunctionalityActive[0];
            n134SecFunctionalityActive = H007X9_n134SecFunctionalityActive[0];
            A138SecParentFunctionalityDescription = H007X9_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = H007X9_n138SecParentFunctionalityDescription[0];
            A789SecFunctionalityModule = H007X9_A789SecFunctionalityModule[0];
            n789SecFunctionalityModule = H007X9_n789SecFunctionalityModule[0];
            A135SecFunctionalityDescription = H007X9_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = H007X9_n135SecFunctionalityDescription[0];
            A128SecFunctionalityId = H007X9_A128SecFunctionalityId[0];
            A40000SecFunctionalityRoleAtivo = H007X9_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = H007X9_n40000SecFunctionalityRoleAtivo[0];
            A138SecParentFunctionalityDescription = H007X9_A138SecParentFunctionalityDescription[0];
            n138SecParentFunctionalityDescription = H007X9_n138SecParentFunctionalityDescription[0];
            A40000SecFunctionalityRoleAtivo = H007X9_A40000SecFunctionalityRoleAtivo[0];
            n40000SecFunctionalityRoleAtivo = H007X9_n40000SecFunctionalityRoleAtivo[0];
            AV58SecFunctionalityIdCol.Add(A128SecFunctionalityId, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void wb_table3_93_7X2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription3_Internalname, "Sec Functionality Description3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription3_Internalname, AV28SecFunctionalityDescription3, StringUtil.RTrim( context.localUtil.Format( AV28SecFunctionalityDescription3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription3_Visible, edtavSecfunctionalitydescription3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secparentfunctionalitydescription3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecparentfunctionalitydescription3_Internalname, "Sec Parent Functionality Description3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecparentfunctionalitydescription3_Internalname, AV29SecParentFunctionalityDescription3, StringUtil.RTrim( context.localUtil.Format( AV29SecParentFunctionalityDescription3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecparentfunctionalitydescription3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecparentfunctionalitydescription3_Visible, edtavSecparentfunctionalitydescription3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAddFunc.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_7X2e( true) ;
         }
         else
         {
            wb_table3_93_7X2e( false) ;
         }
      }

      protected void wb_table2_68_7X2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription2_Internalname, "Sec Functionality Description2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription2_Internalname, AV23SecFunctionalityDescription2, StringUtil.RTrim( context.localUtil.Format( AV23SecFunctionalityDescription2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription2_Visible, edtavSecfunctionalitydescription2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secparentfunctionalitydescription2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecparentfunctionalitydescription2_Internalname, "Sec Parent Functionality Description2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecparentfunctionalitydescription2_Internalname, AV24SecParentFunctionalityDescription2, StringUtil.RTrim( context.localUtil.Format( AV24SecParentFunctionalityDescription2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecparentfunctionalitydescription2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecparentfunctionalitydescription2_Visible, edtavSecparentfunctionalitydescription2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAddFunc.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAddFunc.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_7X2e( true) ;
         }
         else
         {
            wb_table2_68_7X2e( false) ;
         }
      }

      protected void wb_table1_43_7X2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WPAddFunc.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription1_Internalname, "Sec Functionality Description1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription1_Internalname, AV18SecFunctionalityDescription1, StringUtil.RTrim( context.localUtil.Format( AV18SecFunctionalityDescription1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription1_Visible, edtavSecfunctionalitydescription1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secparentfunctionalitydescription1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecparentfunctionalitydescription1_Internalname, "Sec Parent Functionality Description1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecparentfunctionalitydescription1_Internalname, AV19SecParentFunctionalityDescription1, StringUtil.RTrim( context.localUtil.Format( AV19SecParentFunctionalityDescription1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecparentfunctionalitydescription1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecparentfunctionalitydescription1_Visible, edtavSecparentfunctionalitydescription1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WPAddFunc.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAddFunc.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WPAddFunc.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_7X2e( true) ;
         }
         else
         {
            wb_table1_43_7X2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV65SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV65SecRoleId", StringUtil.LTrimStr( (decimal)(AV65SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV65SecRoleId), "ZZZ9"), context));
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
         PA7X2( ) ;
         WS7X2( ) ;
         WE7X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019272859", true, true);
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
         context.AddJavascriptSource("wpaddfunc.js", "?202561019272860", false, true);
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
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_114_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_114_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_114_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_idx;
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE_"+sGXsfl_114_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_114_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_114_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE_"+sGXsfl_114_fel_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_114_fel_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_114_fel_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_fel_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB7X0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_114_idx + "',114)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vSELECTED_" + sGXsfl_114_idx;
            chkavSelected.Name = GXCCtl;
            chkavSelected.WebTags = "";
            chkavSelected.Caption = "";
            AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_114_Refreshing);
            chkavSelected.CheckedValue = "false";
            AV54Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV54Selected));
            AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelected_Internalname,StringUtil.BoolToStr( AV54Selected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,115);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A130SecFunctionalityKey,StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityModule_Internalname,(string)A789SecFunctionalityModule,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityModule_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( cmbSecFunctionalityType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_114_idx;
               cmbSecFunctionalityType.Name = GXCCtl;
               cmbSecFunctionalityType.WebTags = "";
               cmbSecFunctionalityType.addItem("1", "Mode", 0);
               cmbSecFunctionalityType.addItem("2", "Action", 0);
               cmbSecFunctionalityType.addItem("3", "Tab", 0);
               cmbSecFunctionalityType.addItem("4", "Object", 0);
               cmbSecFunctionalityType.addItem("5", "Attribute", 0);
               if ( cmbSecFunctionalityType.ItemCount > 0 )
               {
                  A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
                  n136SecFunctionalityType = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecFunctionalityType,(string)cmbSecFunctionalityType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0)),(short)1,(string)cmbSecFunctionalityType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_114_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescription_Internalname,(string)A138SecParentFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_114_idx;
            chkSecFunctionalityActive.Name = GXCCtl;
            chkSecFunctionalityActive.WebTags = "";
            chkSecFunctionalityActive.Caption = "";
            AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_114_Refreshing);
            chkSecFunctionalityActive.CheckedValue = "false";
            A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
            n134SecFunctionalityActive = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSecFunctionalityActive_Internalname,StringUtil.BoolToStr( A134SecFunctionalityActive),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            send_integrity_lvl_hashes7X2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("SECFUNCTIONALITYDESCRIPTION", "Description", 0);
         cmbavDynamicfiltersselector1.addItem("SECPARENTFUNCTIONALITYDESCRIPTION", "Parent Functionality", 0);
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
         cmbavDynamicfiltersselector2.addItem("SECFUNCTIONALITYDESCRIPTION", "Description", 0);
         cmbavDynamicfiltersselector2.addItem("SECPARENTFUNCTIONALITYDESCRIPTION", "Parent Functionality", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECFUNCTIONALITYDESCRIPTION", "Description", 0);
         cmbavDynamicfiltersselector3.addItem("SECPARENTFUNCTIONALITYDESCRIPTION", "Parent Functionality", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vSELECTED_" + sGXsfl_114_idx;
         chkavSelected.Name = GXCCtl;
         chkavSelected.WebTags = "";
         chkavSelected.Caption = "";
         AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_114_Refreshing);
         chkavSelected.CheckedValue = "false";
         AV54Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV54Selected));
         AssignAttri("", false, chkavSelected_Internalname, AV54Selected);
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_114_idx;
         cmbSecFunctionalityType.Name = GXCCtl;
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", "Mode", 0);
         cmbSecFunctionalityType.addItem("2", "Action", 0);
         cmbSecFunctionalityType.addItem("3", "Tab", 0);
         cmbSecFunctionalityType.addItem("4", "Object", 0);
         cmbSecFunctionalityType.addItem("5", "Attribute", 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            n136SecFunctionalityType = false;
         }
         GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_114_idx;
         chkSecFunctionalityActive.Name = GXCCtl;
         chkSecFunctionalityActive.WebTags = "";
         chkSecFunctionalityActive.Caption = "";
         AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_114_Refreshing);
         chkSecFunctionalityActive.CheckedValue = "false";
         A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
         n134SecFunctionalityActive = false;
         chkavSelectall.Name = "vSELECTALL";
         chkavSelectall.WebTags = "";
         chkavSelectall.Caption = "";
         AssignProp("", false, chkavSelectall_Internalname, "TitleCaption", chkavSelectall.Caption, true);
         chkavSelectall.CheckedValue = "false";
         AV62SelectAll = StringUtil.StrToBool( StringUtil.BoolToStr( AV62SelectAll));
         AssignAttri("", false, "AV62SelectAll", AV62SelectAll);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            if ( chkavSelected_Titleformat == 0 )
            {
               context.SendWebValue( chkavSelected.Title.Text) ;
            }
            else
            {
               context.WriteHtmlText( chkavSelected.Title.Text) ;
            }
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Módulo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality Id  ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ativo") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV54Selected)));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( chkavSelected.Title.Text));
            GridColumn.AddObjectProperty("Titleformat", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavSelected_Titleformat), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A130SecFunctionalityKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A789SecFunctionalityModule));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A138SecParentFunctionalityDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A134SecFunctionalityActive)));
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
         bttBtnbtninserirpop_Internalname = "BTNBTNINSERIRPOP";
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
         edtavSecfunctionalitydescription1_Internalname = "vSECFUNCTIONALITYDESCRIPTION1";
         cellFilter_secfunctionalitydescription1_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION1_CELL";
         edtavSecparentfunctionalitydescription1_Internalname = "vSECPARENTFUNCTIONALITYDESCRIPTION1";
         cellFilter_secparentfunctionalitydescription1_cell_Internalname = "FILTER_SECPARENTFUNCTIONALITYDESCRIPTION1_CELL";
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
         edtavSecfunctionalitydescription2_Internalname = "vSECFUNCTIONALITYDESCRIPTION2";
         cellFilter_secfunctionalitydescription2_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION2_CELL";
         edtavSecparentfunctionalitydescription2_Internalname = "vSECPARENTFUNCTIONALITYDESCRIPTION2";
         cellFilter_secparentfunctionalitydescription2_cell_Internalname = "FILTER_SECPARENTFUNCTIONALITYDESCRIPTION2_CELL";
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
         edtavSecfunctionalitydescription3_Internalname = "vSECFUNCTIONALITYDESCRIPTION3";
         cellFilter_secfunctionalitydescription3_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION3_CELL";
         edtavSecparentfunctionalitydescription3_Internalname = "vSECPARENTFUNCTIONALITYDESCRIPTION3";
         cellFilter_secparentfunctionalitydescription3_cell_Internalname = "FILTER_SECPARENTFUNCTIONALITYDESCRIPTION3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         chkavSelected_Internalname = "vSELECTED";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION";
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         Ucmessage_Internalname = "UCMESSAGE";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         chkavSelectall_Internalname = "vSELECTALL";
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
         chkavSelectall.Caption = "";
         chkSecFunctionalityActive.Caption = "";
         edtSecParentFunctionalityDescription_Jsonclick = "";
         edtSecParentFunctionalityId_Jsonclick = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityModule_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Link = "";
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         chkavSelected.Caption = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecparentfunctionalitydescription1_Jsonclick = "";
         edtavSecparentfunctionalitydescription1_Enabled = 1;
         edtavSecfunctionalitydescription1_Jsonclick = "";
         edtavSecfunctionalitydescription1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecparentfunctionalitydescription2_Jsonclick = "";
         edtavSecparentfunctionalitydescription2_Enabled = 1;
         edtavSecfunctionalitydescription2_Jsonclick = "";
         edtavSecfunctionalitydescription2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecparentfunctionalitydescription3_Jsonclick = "";
         edtavSecparentfunctionalitydescription3_Enabled = 1;
         edtavSecfunctionalitydescription3_Jsonclick = "";
         edtavSecfunctionalitydescription3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecparentfunctionalitydescription3_Visible = 1;
         edtavSecfunctionalitydescription3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecparentfunctionalitydescription2_Visible = 1;
         edtavSecfunctionalitydescription2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecparentfunctionalitydescription1_Visible = 1;
         edtavSecfunctionalitydescription1_Visible = 1;
         chkavSelected.Title.Text = "";
         chkSecFunctionalityActive.Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityModule_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         subGrid_Sortable = 0;
         chkavSelectall.Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         divLayoutmaintable_Class = "Table TableWithSelectableGrid";
         chkavSelected_Titleformat = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WPAddFuncGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|";
         Ddo_grid_Includefilter = "T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "3:SecFunctionalityDescription|4:SecFunctionalityModule|8:SecFunctionalityActive";
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
         Form.Caption = " Functionality";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E277X2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSecFunctionalityDescription_Link","ctrl":"SECFUNCTIONALITYDESCRIPTION","prop":"Link"},{"av":"AV54Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60SecFunctionalityIdColItem","fld":"vSECFUNCTIONALITYIDCOLITEM","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VSELECTED.CLICK","""{"handler":"E287X2","iparms":[{"av":"AV54Selected","fld":"vSELECTED","type":"boolean"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VSELECTED.CLICK",""","oparms":[{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV60SecFunctionalityIdColItem","fld":"vSECFUNCTIONALITYIDCOLITEM","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E207X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription2_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription3_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription1_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E217X2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription1_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E227X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription2_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription3_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription1_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E237X2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription2_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription2_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription3_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription1_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E247X2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription3_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117X2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"chkavSelected_Titleformat","ctrl":"vSELECTED","prop":"Titleformat"},{"av":"AV57i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV61SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription1_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription2_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"edtavSecparentfunctionalitydescription3_Visible","ctrl":"vSECPARENTFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"chkavSelected.Title.Text","ctrl":"vSELECTED","prop":"Title"},{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV51GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV52GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV53GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOBTNINSERIRPOP'","""{"handler":"E187X2","iparms":[{"av":"AV55SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A130SecFunctionalityKey","fld":"SECFUNCTIONALITYKEY","pic":"@!","hsh":true,"type":"svchar"},{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","hsh":true,"type":"svchar"},{"av":"A789SecFunctionalityModule","fld":"SECFUNCTIONALITYMODULE","hsh":true,"type":"svchar"},{"av":"cmbSecFunctionalityType"},{"av":"A136SecFunctionalityType","fld":"SECFUNCTIONALITYTYPE","pic":"Z9","hsh":true,"type":"int"},{"av":"A129SecParentFunctionalityId","fld":"SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A138SecParentFunctionalityDescription","fld":"SECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"A134SecFunctionalityActive","fld":"SECFUNCTIONALITYACTIVE","hsh":true,"type":"boolean"}]""");
         setEventMetadata("'DOBTNINSERIRPOP'",""","oparms":[{"av":"AV55SelectedRows","fld":"vSELECTEDROWS","type":""},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV60SecFunctionalityIdColItem","fld":"vSECFUNCTIONALITYIDCOLITEM","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VSELECTALL.CLICK","""{"handler":"E197X2","iparms":[{"av":"AV62SelectAll","fld":"vSELECTALL","type":"boolean"},{"av":"AV48TFSecFunctionalityActive_Sel","fld":"vTFSECFUNCTIONALITYACTIVE_SEL","pic":"9","type":"int"},{"av":"AV68TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV67TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV41TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV40TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV29SecParentFunctionalityDescription3","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV24SecParentFunctionalityDescription2","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV19SecParentFunctionalityDescription1","fld":"vSECPARENTFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV65SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","grid":114,"pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_114","ctrl":"GRID","prop":"GridRC","grid":114,"type":"int"},{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""}]""");
         setEventMetadata("VSELECTALL.CLICK",""","oparms":[{"av":"AV58SecFunctionalityIdCol","fld":"vSECFUNCTIONALITYIDCOL","type":""},{"av":"AV54Selected","fld":"vSELECTED","type":"boolean"},{"av":"AV59SecFunctionalityIdJson","fld":"vSECFUNCTIONALITYIDJSON","type":"vchar"},{"av":"divLayoutmaintable_Class","ctrl":"LAYOUTMAINTABLE","prop":"Class"}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[]}""");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","""{"handler":"Valid_Secparentfunctionalityid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secfunctionalityactive","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18SecFunctionalityDescription1 = "";
         AV19SecParentFunctionalityDescription1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23SecFunctionalityDescription2 = "";
         AV24SecParentFunctionalityDescription2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SecFunctionalityDescription3 = "";
         AV29SecParentFunctionalityDescription3 = "";
         AV69Pgmname = "";
         AV59SecFunctionalityIdJson = "";
         AV40TFSecFunctionalityDescription = "";
         AV41TFSecFunctionalityDescription_Sel = "";
         AV67TFSecFunctionalityModule = "";
         AV68TFSecFunctionalityModule_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV58SecFunctionalityIdCol = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV33ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53GridAppliedFilters = "";
         AV49DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV55SelectedRows = new GXBaseCollection<SdtWPAddFuncSDT_WPAddFuncSDTItem>( context, "WPAddFuncSDTItem", "Factory21");
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
         bttBtnbtninserirpop_Jsonclick = "";
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
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A789SecFunctionalityModule = "";
         A138SecParentFunctionalityDescription = "";
         GXDecQS = "";
         lV70Wpaddfuncds_1_filterfulltext = "";
         lV73Wpaddfuncds_4_secfunctionalitydescription1 = "";
         lV74Wpaddfuncds_5_secparentfunctionalitydescription1 = "";
         lV78Wpaddfuncds_9_secfunctionalitydescription2 = "";
         lV79Wpaddfuncds_10_secparentfunctionalitydescription2 = "";
         lV83Wpaddfuncds_14_secfunctionalitydescription3 = "";
         lV84Wpaddfuncds_15_secparentfunctionalitydescription3 = "";
         lV85Wpaddfuncds_16_tfsecfunctionalitydescription = "";
         lV87Wpaddfuncds_18_tfsecfunctionalitymodule = "";
         AV70Wpaddfuncds_1_filterfulltext = "";
         AV71Wpaddfuncds_2_dynamicfiltersselector1 = "";
         AV73Wpaddfuncds_4_secfunctionalitydescription1 = "";
         AV74Wpaddfuncds_5_secparentfunctionalitydescription1 = "";
         AV76Wpaddfuncds_7_dynamicfiltersselector2 = "";
         AV78Wpaddfuncds_9_secfunctionalitydescription2 = "";
         AV79Wpaddfuncds_10_secparentfunctionalitydescription2 = "";
         AV81Wpaddfuncds_12_dynamicfiltersselector3 = "";
         AV83Wpaddfuncds_14_secfunctionalitydescription3 = "";
         AV84Wpaddfuncds_15_secparentfunctionalitydescription3 = "";
         AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel = "";
         AV85Wpaddfuncds_16_tfsecfunctionalitydescription = "";
         AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel = "";
         AV87Wpaddfuncds_18_tfsecfunctionalitymodule = "";
         H007X3_A134SecFunctionalityActive = new bool[] {false} ;
         H007X3_n134SecFunctionalityActive = new bool[] {false} ;
         H007X3_A138SecParentFunctionalityDescription = new string[] {""} ;
         H007X3_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H007X3_A129SecParentFunctionalityId = new long[1] ;
         H007X3_n129SecParentFunctionalityId = new bool[] {false} ;
         H007X3_A136SecFunctionalityType = new short[1] ;
         H007X3_n136SecFunctionalityType = new bool[] {false} ;
         H007X3_A789SecFunctionalityModule = new string[] {""} ;
         H007X3_n789SecFunctionalityModule = new bool[] {false} ;
         H007X3_A135SecFunctionalityDescription = new string[] {""} ;
         H007X3_n135SecFunctionalityDescription = new bool[] {false} ;
         H007X3_A130SecFunctionalityKey = new string[] {""} ;
         H007X3_n130SecFunctionalityKey = new bool[] {false} ;
         H007X3_A128SecFunctionalityId = new long[1] ;
         H007X3_A40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         H007X3_n40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         H007X5_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV34ManageFiltersXml = "";
         AV56SelectedRow = new SdtWPAddFuncSDT_WPAddFuncSDTItem(context);
         AV64SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         H007X7_A128SecFunctionalityId = new long[1] ;
         H007X7_A130SecFunctionalityKey = new string[] {""} ;
         H007X7_n130SecFunctionalityKey = new bool[] {false} ;
         H007X7_A135SecFunctionalityDescription = new string[] {""} ;
         H007X7_n135SecFunctionalityDescription = new bool[] {false} ;
         H007X7_A789SecFunctionalityModule = new string[] {""} ;
         H007X7_n789SecFunctionalityModule = new bool[] {false} ;
         H007X7_A136SecFunctionalityType = new short[1] ;
         H007X7_n136SecFunctionalityType = new bool[] {false} ;
         H007X7_A129SecParentFunctionalityId = new long[1] ;
         H007X7_n129SecParentFunctionalityId = new bool[] {false} ;
         H007X7_A138SecParentFunctionalityDescription = new string[] {""} ;
         H007X7_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H007X7_A134SecFunctionalityActive = new bool[] {false} ;
         H007X7_n134SecFunctionalityActive = new bool[] {false} ;
         H007X7_A40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         H007X7_n40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         AV32Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         H007X9_A129SecParentFunctionalityId = new long[1] ;
         H007X9_n129SecParentFunctionalityId = new bool[] {false} ;
         H007X9_A134SecFunctionalityActive = new bool[] {false} ;
         H007X9_n134SecFunctionalityActive = new bool[] {false} ;
         H007X9_A138SecParentFunctionalityDescription = new string[] {""} ;
         H007X9_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H007X9_A789SecFunctionalityModule = new string[] {""} ;
         H007X9_n789SecFunctionalityModule = new bool[] {false} ;
         H007X9_A135SecFunctionalityDescription = new string[] {""} ;
         H007X9_n135SecFunctionalityDescription = new bool[] {false} ;
         H007X9_A128SecFunctionalityId = new long[1] ;
         H007X9_A40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         H007X9_n40000SecFunctionalityRoleAtivo = new bool[] {false} ;
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpaddfunc__default(),
            new Object[][] {
                new Object[] {
               H007X3_A134SecFunctionalityActive, H007X3_n134SecFunctionalityActive, H007X3_A138SecParentFunctionalityDescription, H007X3_n138SecParentFunctionalityDescription, H007X3_A129SecParentFunctionalityId, H007X3_n129SecParentFunctionalityId, H007X3_A136SecFunctionalityType, H007X3_n136SecFunctionalityType, H007X3_A789SecFunctionalityModule, H007X3_n789SecFunctionalityModule,
               H007X3_A135SecFunctionalityDescription, H007X3_n135SecFunctionalityDescription, H007X3_A130SecFunctionalityKey, H007X3_n130SecFunctionalityKey, H007X3_A128SecFunctionalityId, H007X3_A40000SecFunctionalityRoleAtivo, H007X3_n40000SecFunctionalityRoleAtivo
               }
               , new Object[] {
               H007X5_AGRID_nRecordCount
               }
               , new Object[] {
               H007X7_A128SecFunctionalityId, H007X7_A130SecFunctionalityKey, H007X7_n130SecFunctionalityKey, H007X7_A135SecFunctionalityDescription, H007X7_n135SecFunctionalityDescription, H007X7_A789SecFunctionalityModule, H007X7_n789SecFunctionalityModule, H007X7_A136SecFunctionalityType, H007X7_n136SecFunctionalityType, H007X7_A129SecParentFunctionalityId,
               H007X7_n129SecParentFunctionalityId, H007X7_A138SecParentFunctionalityDescription, H007X7_n138SecParentFunctionalityDescription, H007X7_A134SecFunctionalityActive, H007X7_n134SecFunctionalityActive, H007X7_A40000SecFunctionalityRoleAtivo, H007X7_n40000SecFunctionalityRoleAtivo
               }
               , new Object[] {
               H007X9_A129SecParentFunctionalityId, H007X9_n129SecParentFunctionalityId, H007X9_A134SecFunctionalityActive, H007X9_n134SecFunctionalityActive, H007X9_A138SecParentFunctionalityDescription, H007X9_n138SecParentFunctionalityDescription, H007X9_A789SecFunctionalityModule, H007X9_n789SecFunctionalityModule, H007X9_A135SecFunctionalityDescription, H007X9_n135SecFunctionalityDescription,
               H007X9_A128SecFunctionalityId, H007X9_A40000SecFunctionalityRoleAtivo, H007X9_n40000SecFunctionalityRoleAtivo
               }
            }
         );
         AV69Pgmname = "WPAddFunc";
         /* GeneXus formulas. */
         AV69Pgmname = "WPAddFunc";
      }

      private short AV65SecRoleId ;
      private short wcpOAV65SecRoleId ;
      private short chkavSelected_Titleformat ;
      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV35ManageFiltersExecutionStep ;
      private short AV48TFSecFunctionalityActive_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A136SecFunctionalityType ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV72Wpaddfuncds_3_dynamicfiltersoperator1 ;
      private short AV77Wpaddfuncds_8_dynamicfiltersoperator2 ;
      private short AV82Wpaddfuncds_13_dynamicfiltersoperator3 ;
      private short AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ;
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
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecFunctionalityModule_Enabled ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecParentFunctionalityDescription_Enabled ;
      private int AV50PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV90GXV1 ;
      private int nGXsfl_114_fel_idx=1 ;
      private int AV92GXV2 ;
      private int edtavSecfunctionalitydescription1_Visible ;
      private int edtavSecparentfunctionalitydescription1_Visible ;
      private int edtavSecfunctionalitydescription2_Visible ;
      private int edtavSecparentfunctionalitydescription2_Visible ;
      private int edtavSecfunctionalitydescription3_Visible ;
      private int edtavSecparentfunctionalitydescription3_Visible ;
      private int AV93GXV3 ;
      private int AV95GXV4 ;
      private int edtavSecfunctionalitydescription3_Enabled ;
      private int edtavSecparentfunctionalitydescription3_Enabled ;
      private int edtavSecfunctionalitydescription2_Enabled ;
      private int edtavSecparentfunctionalitydescription2_Enabled ;
      private int edtavSecfunctionalitydescription1_Enabled ;
      private int edtavSecparentfunctionalitydescription1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV57i ;
      private long AV61SecFunctionalityIdToFind ;
      private long AV51GridCurrentPage ;
      private long AV52GridPageCount ;
      private long A128SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV60SecFunctionalityIdColItem ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_114_idx="0001" ;
      private string AV69Pgmname ;
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
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnbtninserirpop_Internalname ;
      private string bttBtnbtninserirpop_Jsonclick ;
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
      private string chkavSelectall_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavSelected_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string edtSecFunctionalityModule_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityDescription_Internalname ;
      private string chkSecFunctionalityActive_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavSecfunctionalitydescription1_Internalname ;
      private string edtavSecparentfunctionalitydescription1_Internalname ;
      private string edtavSecfunctionalitydescription2_Internalname ;
      private string edtavSecparentfunctionalitydescription2_Internalname ;
      private string edtavSecfunctionalitydescription3_Internalname ;
      private string edtavSecparentfunctionalitydescription3_Internalname ;
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
      private string edtSecFunctionalityDescription_Link ;
      private string sGXsfl_114_fel_idx="0001" ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secfunctionalitydescription3_cell_Internalname ;
      private string edtavSecfunctionalitydescription3_Jsonclick ;
      private string cellFilter_secparentfunctionalitydescription3_cell_Internalname ;
      private string edtavSecparentfunctionalitydescription3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secfunctionalitydescription2_cell_Internalname ;
      private string edtavSecfunctionalitydescription2_Jsonclick ;
      private string cellFilter_secparentfunctionalitydescription2_cell_Internalname ;
      private string edtavSecparentfunctionalitydescription2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secfunctionalitydescription1_cell_Internalname ;
      private string edtavSecfunctionalitydescription1_Jsonclick ;
      private string cellFilter_secparentfunctionalitydescription1_cell_Internalname ;
      private string edtavSecparentfunctionalitydescription1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string edtSecFunctionalityModule_Jsonclick ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecParentFunctionalityDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
      private bool AV62SelectAll ;
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
      private bool AV54Selected ;
      private bool n130SecFunctionalityKey ;
      private bool n135SecFunctionalityDescription ;
      private bool n789SecFunctionalityModule ;
      private bool n136SecFunctionalityType ;
      private bool n129SecParentFunctionalityId ;
      private bool n138SecParentFunctionalityDescription ;
      private bool A134SecFunctionalityActive ;
      private bool n134SecFunctionalityActive ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV75Wpaddfuncds_6_dynamicfiltersenabled2 ;
      private bool AV80Wpaddfuncds_11_dynamicfiltersenabled3 ;
      private bool A40000SecFunctionalityRoleAtivo ;
      private bool n40000SecFunctionalityRoleAtivo ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV59SecFunctionalityIdJson ;
      private string AV34ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18SecFunctionalityDescription1 ;
      private string AV19SecParentFunctionalityDescription1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23SecFunctionalityDescription2 ;
      private string AV24SecParentFunctionalityDescription2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28SecFunctionalityDescription3 ;
      private string AV29SecParentFunctionalityDescription3 ;
      private string AV40TFSecFunctionalityDescription ;
      private string AV41TFSecFunctionalityDescription_Sel ;
      private string AV67TFSecFunctionalityModule ;
      private string AV68TFSecFunctionalityModule_Sel ;
      private string AV53GridAppliedFilters ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A789SecFunctionalityModule ;
      private string A138SecParentFunctionalityDescription ;
      private string lV70Wpaddfuncds_1_filterfulltext ;
      private string lV73Wpaddfuncds_4_secfunctionalitydescription1 ;
      private string lV74Wpaddfuncds_5_secparentfunctionalitydescription1 ;
      private string lV78Wpaddfuncds_9_secfunctionalitydescription2 ;
      private string lV79Wpaddfuncds_10_secparentfunctionalitydescription2 ;
      private string lV83Wpaddfuncds_14_secfunctionalitydescription3 ;
      private string lV84Wpaddfuncds_15_secparentfunctionalitydescription3 ;
      private string lV85Wpaddfuncds_16_tfsecfunctionalitydescription ;
      private string lV87Wpaddfuncds_18_tfsecfunctionalitymodule ;
      private string AV70Wpaddfuncds_1_filterfulltext ;
      private string AV71Wpaddfuncds_2_dynamicfiltersselector1 ;
      private string AV73Wpaddfuncds_4_secfunctionalitydescription1 ;
      private string AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ;
      private string AV76Wpaddfuncds_7_dynamicfiltersselector2 ;
      private string AV78Wpaddfuncds_9_secfunctionalitydescription2 ;
      private string AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ;
      private string AV81Wpaddfuncds_12_dynamicfiltersselector3 ;
      private string AV83Wpaddfuncds_14_secfunctionalitydescription3 ;
      private string AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ;
      private string AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ;
      private string AV85Wpaddfuncds_16_tfsecfunctionalitydescription ;
      private string AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ;
      private string AV87Wpaddfuncds_18_tfsecfunctionalitymodule ;
      private IGxSession AV32Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkavSelected ;
      private GXCombobox cmbSecFunctionalityType ;
      private GXCheckbox chkSecFunctionalityActive ;
      private GXCheckbox chkavSelectall ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GxSimpleCollection<long> AV58SecFunctionalityIdCol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV33ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV49DDO_TitleSettingsIcons ;
      private GXBaseCollection<SdtWPAddFuncSDT_WPAddFuncSDTItem> AV55SelectedRows ;
      private IDataStoreProvider pr_default ;
      private bool[] H007X3_A134SecFunctionalityActive ;
      private bool[] H007X3_n134SecFunctionalityActive ;
      private string[] H007X3_A138SecParentFunctionalityDescription ;
      private bool[] H007X3_n138SecParentFunctionalityDescription ;
      private long[] H007X3_A129SecParentFunctionalityId ;
      private bool[] H007X3_n129SecParentFunctionalityId ;
      private short[] H007X3_A136SecFunctionalityType ;
      private bool[] H007X3_n136SecFunctionalityType ;
      private string[] H007X3_A789SecFunctionalityModule ;
      private bool[] H007X3_n789SecFunctionalityModule ;
      private string[] H007X3_A135SecFunctionalityDescription ;
      private bool[] H007X3_n135SecFunctionalityDescription ;
      private string[] H007X3_A130SecFunctionalityKey ;
      private bool[] H007X3_n130SecFunctionalityKey ;
      private long[] H007X3_A128SecFunctionalityId ;
      private bool[] H007X3_A40000SecFunctionalityRoleAtivo ;
      private bool[] H007X3_n40000SecFunctionalityRoleAtivo ;
      private long[] H007X5_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtWPAddFuncSDT_WPAddFuncSDTItem AV56SelectedRow ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole AV64SecFunctionalityRole ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private long[] H007X7_A128SecFunctionalityId ;
      private string[] H007X7_A130SecFunctionalityKey ;
      private bool[] H007X7_n130SecFunctionalityKey ;
      private string[] H007X7_A135SecFunctionalityDescription ;
      private bool[] H007X7_n135SecFunctionalityDescription ;
      private string[] H007X7_A789SecFunctionalityModule ;
      private bool[] H007X7_n789SecFunctionalityModule ;
      private short[] H007X7_A136SecFunctionalityType ;
      private bool[] H007X7_n136SecFunctionalityType ;
      private long[] H007X7_A129SecParentFunctionalityId ;
      private bool[] H007X7_n129SecParentFunctionalityId ;
      private string[] H007X7_A138SecParentFunctionalityDescription ;
      private bool[] H007X7_n138SecParentFunctionalityDescription ;
      private bool[] H007X7_A134SecFunctionalityActive ;
      private bool[] H007X7_n134SecFunctionalityActive ;
      private bool[] H007X7_A40000SecFunctionalityRoleAtivo ;
      private bool[] H007X7_n40000SecFunctionalityRoleAtivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private long[] H007X9_A129SecParentFunctionalityId ;
      private bool[] H007X9_n129SecParentFunctionalityId ;
      private bool[] H007X9_A134SecFunctionalityActive ;
      private bool[] H007X9_n134SecFunctionalityActive ;
      private string[] H007X9_A138SecParentFunctionalityDescription ;
      private bool[] H007X9_n138SecParentFunctionalityDescription ;
      private string[] H007X9_A789SecFunctionalityModule ;
      private bool[] H007X9_n789SecFunctionalityModule ;
      private string[] H007X9_A135SecFunctionalityDescription ;
      private bool[] H007X9_n135SecFunctionalityDescription ;
      private long[] H007X9_A128SecFunctionalityId ;
      private bool[] H007X9_A40000SecFunctionalityRoleAtivo ;
      private bool[] H007X9_n40000SecFunctionalityRoleAtivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpaddfunc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007X3( IGxContext context ,
                                             string AV70Wpaddfuncds_1_filterfulltext ,
                                             string AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                             short AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                             string AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                             string AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                             bool AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                             string AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                             short AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                             string AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                             string AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                             bool AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                             string AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                             short AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                             string AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                             string AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                             string AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                             string AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                             string AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                             string AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                             short AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                             string A135SecFunctionalityDescription ,
                                             string A789SecFunctionalityModule ,
                                             string A138SecParentFunctionalityDescription ,
                                             bool A134SecFunctionalityActive ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             bool A40000SecFunctionalityRoleAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[22];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityType, T1.SecFunctionalityModule, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId, COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) AS SecFunctionalityRoleAtivo";
         sFromString = " FROM ((SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) LEFT JOIN (SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :AV65SecRoleId ) T3 ON T3.SecFunctionalityId = T1.SecFunctionalityId)";
         sOrderString = "";
         AddWhere(sWhereString, "(COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityDescription like '%' || :lV70Wpaddfuncds_1_filterfulltext) or ( T1.SecFunctionalityModule like '%' || :lV70Wpaddfuncds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV85Wpaddfuncds_16_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule like :lV87Wpaddfuncds_18_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule = ( :AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityModule))=0))");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = TRUE)");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = FALSE)");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityModule, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityModule DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityActive, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityActive DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H007X5( IGxContext context ,
                                             string AV70Wpaddfuncds_1_filterfulltext ,
                                             string AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                             short AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                             string AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                             string AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                             bool AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                             string AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                             short AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                             string AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                             string AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                             bool AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                             string AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                             short AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                             string AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                             string AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                             string AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                             string AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                             string AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                             string AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                             short AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                             string A135SecFunctionalityDescription ,
                                             string A789SecFunctionalityModule ,
                                             string A138SecParentFunctionalityDescription ,
                                             bool A134SecFunctionalityActive ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             bool A40000SecFunctionalityRoleAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[19];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) LEFT JOIN (SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :AV65SecRoleId ) T3 ON T3.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityDescription like '%' || :lV70Wpaddfuncds_1_filterfulltext) or ( T1.SecFunctionalityModule like '%' || :lV70Wpaddfuncds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV85Wpaddfuncds_16_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule like :lV87Wpaddfuncds_18_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule = ( :AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityModule))=0))");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = TRUE)");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = FALSE)");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H007X9( IGxContext context ,
                                             string AV70Wpaddfuncds_1_filterfulltext ,
                                             string AV71Wpaddfuncds_2_dynamicfiltersselector1 ,
                                             short AV72Wpaddfuncds_3_dynamicfiltersoperator1 ,
                                             string AV73Wpaddfuncds_4_secfunctionalitydescription1 ,
                                             string AV74Wpaddfuncds_5_secparentfunctionalitydescription1 ,
                                             bool AV75Wpaddfuncds_6_dynamicfiltersenabled2 ,
                                             string AV76Wpaddfuncds_7_dynamicfiltersselector2 ,
                                             short AV77Wpaddfuncds_8_dynamicfiltersoperator2 ,
                                             string AV78Wpaddfuncds_9_secfunctionalitydescription2 ,
                                             string AV79Wpaddfuncds_10_secparentfunctionalitydescription2 ,
                                             bool AV80Wpaddfuncds_11_dynamicfiltersenabled3 ,
                                             string AV81Wpaddfuncds_12_dynamicfiltersselector3 ,
                                             short AV82Wpaddfuncds_13_dynamicfiltersoperator3 ,
                                             string AV83Wpaddfuncds_14_secfunctionalitydescription3 ,
                                             string AV84Wpaddfuncds_15_secparentfunctionalitydescription3 ,
                                             string AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel ,
                                             string AV85Wpaddfuncds_16_tfsecfunctionalitydescription ,
                                             string AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel ,
                                             string AV87Wpaddfuncds_18_tfsecfunctionalitymodule ,
                                             short AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel ,
                                             string A135SecFunctionalityDescription ,
                                             string A789SecFunctionalityModule ,
                                             string A138SecParentFunctionalityDescription ,
                                             bool A134SecFunctionalityActive ,
                                             bool A40000SecFunctionalityRoleAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[19];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityModule, T1.SecFunctionalityDescription, T1.SecFunctionalityId, COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) AS SecFunctionalityRoleAtivo FROM ((SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId) LEFT JOIN (SELECT SecFunctionalityId, SecRoleId, SecFunctionalityRoleAtivo FROM SecFunctionalityRole WHERE SecRoleId = :AV65SecRoleId ) T3 ON T3.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(COALESCE( T3.SecFunctionalityRoleAtivo, FALSE) = FALSE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpaddfuncds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityDescription like '%' || :lV70Wpaddfuncds_1_filterfulltext) or ( T1.SecFunctionalityModule like '%' || :lV70Wpaddfuncds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wpaddfuncds_4_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV73Wpaddfuncds_4_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Wpaddfuncds_2_dynamicfiltersselector1, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV72Wpaddfuncds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wpaddfuncds_5_secparentfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV74Wpaddfuncds_5_secparentfunctionalitydescription1)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpaddfuncds_9_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV78Wpaddfuncds_9_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV75Wpaddfuncds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Wpaddfuncds_7_dynamicfiltersselector2, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV77Wpaddfuncds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpaddfuncds_10_secparentfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV79Wpaddfuncds_10_secparentfunctionalitydescription2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wpaddfuncds_14_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like '%' || :lV83Wpaddfuncds_14_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV80Wpaddfuncds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV81Wpaddfuncds_12_dynamicfiltersselector3, "SECPARENTFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV82Wpaddfuncds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wpaddfuncds_15_secparentfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV84Wpaddfuncds_15_secparentfunctionalitydescription3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wpaddfuncds_16_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV85Wpaddfuncds_16_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpaddfuncds_18_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule like :lV87Wpaddfuncds_18_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule = ( :AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityModule IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityModule))=0))");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = TRUE)");
         }
         if ( AV89Wpaddfuncds_20_tfsecfunctionalityactive_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityActive = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SecFunctionalityId";
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
                     return conditional_H007X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] );
               case 1 :
                     return conditional_H007X5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] , (bool)dynConstraints[26] );
               case 3 :
                     return conditional_H007X9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (bool)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007X7;
          prmH007X7 = new Object[] {
          new ParDef("AV65SecRoleId",GXType.Int16,4,0) ,
          new ParDef("AV60SecFunctionalityIdColItem",GXType.Int64,10,0)
          };
          Object[] prmH007X3;
          prmH007X3 = new Object[] {
          new ParDef("AV65SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV85Wpaddfuncds_16_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wpaddfuncds_18_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007X5;
          prmH007X5 = new Object[] {
          new ParDef("AV65SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV85Wpaddfuncds_16_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wpaddfuncds_18_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0)
          };
          Object[] prmH007X9;
          prmH007X9 = new Object[] {
          new ParDef("AV65SecRoleId",GXType.Int16,4,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpaddfuncds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV73Wpaddfuncds_4_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV74Wpaddfuncds_5_secparentfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV78Wpaddfuncds_9_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpaddfuncds_10_secparentfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV83Wpaddfuncds_14_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV84Wpaddfuncds_15_secparentfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV85Wpaddfuncds_16_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV86Wpaddfuncds_17_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("lV87Wpaddfuncds_18_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV88Wpaddfuncds_19_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007X3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007X5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007X7", "SELECT T1.SecFunctionalityId, T1.SecFunctionalityKey, T1.SecFunctionalityDescription, T1.SecFunctionalityModule, T1.SecFunctionalityType, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T3.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecFunctionalityActive, COALESCE( T2.SecFunctionalityRoleAtivo, FALSE) AS SecFunctionalityRoleAtivo FROM ((SecFunctionality T1 LEFT JOIN (SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecRoleId = :AV65SecRoleId ) T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId) LEFT JOIN SecFunctionality T3 ON T3.SecFunctionalityId = T1.SecParentFunctionalityId) WHERE T1.SecFunctionalityId = :AV60SecFunctionalityIdColItem ORDER BY T1.SecFunctionalityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007X7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H007X9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007X9,11, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((long[]) buf[14])[0] = rslt.getLong(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((long[]) buf[10])[0] = rslt.getLong(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
