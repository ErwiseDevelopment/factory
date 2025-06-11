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
   public class wpfuncionalidades : GXDataArea
   {
      public wpfuncionalidades( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpfuncionalidades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV59SecRoleId = aP0_SecRoleId;
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
         chkavSecfunctionalityroleativo1 = new GXCheckbox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         chkavSecfunctionalityroleativo2 = new GXCheckbox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         chkavSecfunctionalityroleativo3 = new GXCheckbox();
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV67SecFunctionalityRoleAtivo1 = StringUtil.StrToBool( GetPar( "SecFunctionalityRoleAtivo1"));
         AV18SecFunctionalityDescription1 = GetPar( "SecFunctionalityDescription1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV68SecFunctionalityRoleAtivo2 = StringUtil.StrToBool( GetPar( "SecFunctionalityRoleAtivo2"));
         AV23SecFunctionalityDescription2 = GetPar( "SecFunctionalityDescription2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV69SecFunctionalityRoleAtivo3 = StringUtil.StrToBool( GetPar( "SecFunctionalityRoleAtivo3"));
         AV28SecFunctionalityDescription3 = GetPar( "SecFunctionalityDescription3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV70Pgmname = GetPar( "Pgmname");
         AV59SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV65TFSecFunctionalityModule = GetPar( "TFSecFunctionalityModule");
         AV66TFSecFunctionalityModule_Sel = GetPar( "TFSecFunctionalityModule_Sel");
         AV42TFSecFunctionalityDescription = GetPar( "TFSecFunctionalityDescription");
         AV43TFSecFunctionalityDescription_Sel = GetPar( "TFSecFunctionalityDescription_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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
         PA7Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7Y2( ) ;
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
         GXEncryptionTmp = "wpfuncionalidades"+UrlEncode(StringUtil.LTrimStr(AV59SecRoleId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpfuncionalidades") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59SecRoleId), "ZZZ9"), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYROLEATIVO1", StringUtil.BoolToStr( AV67SecFunctionalityRoleAtivo1));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION1", AV18SecFunctionalityDescription1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYROLEATIVO2", StringUtil.BoolToStr( AV68SecFunctionalityRoleAtivo2));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION2", AV23SecFunctionalityDescription2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYROLEATIVO3", StringUtil.BoolToStr( AV69SecFunctionalityRoleAtivo3));
         GxWebStd.gx_hidden_field( context, "GXH_vSECFUNCTIONALITYDESCRIPTION3", AV28SecFunctionalityDescription3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
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
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYMODULE", AV65TFSecFunctionalityModule);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYMODULE_SEL", AV66TFSecFunctionalityModule_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION", AV42TFSecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION_SEL", AV43TFSecFunctionalityDescription_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
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
            WE7Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7Y2( ) ;
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
         GXEncryptionTmp = "wpfuncionalidades"+UrlEncode(StringUtil.LTrimStr(AV59SecRoleId,4,0));
         return formatLink("wpfuncionalidades") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpFuncionalidades" ;
      }

      public override string GetPgmdesc( )
      {
         return " Functionality - Role" ;
      }

      protected void WB7Y0( )
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnbtninserir_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Inserir", bttBtnbtninserir_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBTNINSERIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpFuncionalidades.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV35ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpFuncionalidades.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_7Y2( true) ;
         }
         else
         {
            wb_table1_43_7Y2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_7Y2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_68_7Y2( true) ;
         }
         else
         {
            wb_table2_68_7Y2( false) ;
         }
         return  ;
      }

      protected void wb_table2_68_7Y2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_93_7Y2( true) ;
         }
         else
         {
            wb_table3_93_7Y2( false) ;
         }
         return  ;
      }

      protected void wb_table3_93_7Y2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpFuncionalidades.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
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

      protected void START7Y2( )
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
         Form.Meta.addItem("description", " Functionality - Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7Y0( ) ;
      }

      protected void WS7Y2( )
      {
         START7Y2( ) ;
         EVT7Y2( ) ;
      }

      protected void EVT7Y2( )
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
                              E117Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBTNINSERIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBtnInserir' */
                              E187Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227Y2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237Y2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VBTNREMOVER.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "VBTNREMOVER.CLICK") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              AV62BtnRemover = cgiGet( edtavBtnremover_Internalname);
                              AssignAttri("", false, edtavBtnremover_Internalname, AV62BtnRemover);
                              A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A789SecFunctionalityModule = cgiGet( edtSecFunctionalityModule_Internalname);
                              n789SecFunctionalityModule = false;
                              A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              n135SecFunctionalityDescription = false;
                              A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E247Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E267Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VBTNREMOVER.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E277Y2 ();
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
                                       /* Set Refresh If Secfunctionalityroleativo1 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO1")) != AV67SecFunctionalityRoleAtivo1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION1"), AV18SecFunctionalityDescription1) != 0 )
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
                                       /* Set Refresh If Secfunctionalityroleativo2 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO2")) != AV68SecFunctionalityRoleAtivo2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION2"), AV23SecFunctionalityDescription2) != 0 )
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
                                       /* Set Refresh If Secfunctionalityroleativo3 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO3")) != AV69SecFunctionalityRoleAtivo3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secfunctionalitydescription3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION3"), AV28SecFunctionalityDescription3) != 0 )
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

      protected void WE7Y2( )
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

      protected void PA7Y2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpfuncionalidades")), "wpfuncionalidades") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpfuncionalidades")))) ;
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
                     AV59SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV59SecRoleId", StringUtil.LTrimStr( (decimal)(AV59SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59SecRoleId), "ZZZ9"), context));
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
                                       bool AV67SecFunctionalityRoleAtivo1 ,
                                       string AV18SecFunctionalityDescription1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       bool AV68SecFunctionalityRoleAtivo2 ,
                                       string AV23SecFunctionalityDescription2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       bool AV69SecFunctionalityRoleAtivo3 ,
                                       string AV28SecFunctionalityDescription3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       string AV70Pgmname ,
                                       short AV59SecRoleId ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV65TFSecFunctionalityModule ,
                                       string AV66TFSecFunctionalityModule_Sel ,
                                       string AV42TFSecFunctionalityDescription ,
                                       string AV43TFSecFunctionalityDescription_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", "")));
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
         AV67SecFunctionalityRoleAtivo1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV67SecFunctionalityRoleAtivo1));
         AssignAttri("", false, "AV67SecFunctionalityRoleAtivo1", AV67SecFunctionalityRoleAtivo1);
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
         AV68SecFunctionalityRoleAtivo2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV68SecFunctionalityRoleAtivo2));
         AssignAttri("", false, "AV68SecFunctionalityRoleAtivo2", AV68SecFunctionalityRoleAtivo2);
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
         AV69SecFunctionalityRoleAtivo3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV69SecFunctionalityRoleAtivo3));
         AssignAttri("", false, "AV69SecFunctionalityRoleAtivo3", AV69SecFunctionalityRoleAtivo3);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV70Pgmname = "WpFuncionalidades";
         edtavBtnremover_Enabled = 0;
      }

      protected void RF7Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E257Y2 ();
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
                                                 AV72Wpfuncionalidadesds_2_filterfulltext ,
                                                 AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                                 AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                                 AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                                 AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                                 AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                                 AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                                 AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                                 AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                                 AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                                 AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                                 AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                                 AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                                 AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                                 AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                                 AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                                 AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                                 AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                                 AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                                 A789SecFunctionalityModule ,
                                                 A135SecFunctionalityDescription ,
                                                 A735SecFunctionalityRoleAtivo ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A131SecRoleId ,
                                                 AV71Wpfuncionalidadesds_1_secroleid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV72Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext), "%", "");
            lV72Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext), "%", "");
            lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
            lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
            lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
            lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
            lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
            lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
            lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule), "%", "");
            lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription), "%", "");
            /* Using cursor H007Y2 */
            pr_default.execute(0, new Object[] {AV71Wpfuncionalidadesds_1_secroleid, lV72Wpfuncionalidadesds_2_filterfulltext, lV72Wpfuncionalidadesds_2_filterfulltext, AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1, lV76Wpfuncionalidadesds_6_secfunctionalitydescription1, lV76Wpfuncionalidadesds_6_secfunctionalitydescription1, AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2, lV81Wpfuncionalidadesds_11_secfunctionalitydescription2, lV81Wpfuncionalidadesds_11_secfunctionalitydescription2, AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3, lV86Wpfuncionalidadesds_16_secfunctionalitydescription3, lV86Wpfuncionalidadesds_16_secfunctionalitydescription3, lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule, AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription, AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_114_idx = 1;
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A735SecFunctionalityRoleAtivo = H007Y2_A735SecFunctionalityRoleAtivo[0];
               A131SecRoleId = H007Y2_A131SecRoleId[0];
               A135SecFunctionalityDescription = H007Y2_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H007Y2_n135SecFunctionalityDescription[0];
               A789SecFunctionalityModule = H007Y2_A789SecFunctionalityModule[0];
               n789SecFunctionalityModule = H007Y2_n789SecFunctionalityModule[0];
               A128SecFunctionalityId = H007Y2_A128SecFunctionalityId[0];
               A135SecFunctionalityDescription = H007Y2_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H007Y2_n135SecFunctionalityDescription[0];
               A789SecFunctionalityModule = H007Y2_A789SecFunctionalityModule[0];
               n789SecFunctionalityModule = H007Y2_n789SecFunctionalityModule[0];
               /* Execute user event: Grid.Load */
               E267Y2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 114;
            WB7Y0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7Y2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV70Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV70Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECROLEID"+"_"+sGXsfl_114_idx, GetSecureSignedToken( sGXsfl_114_idx, context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"), context));
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
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV72Wpfuncionalidadesds_2_filterfulltext ,
                                              AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                              AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                              AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                              AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                              AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                              AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                              AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                              AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                              AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                              AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                              AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                              AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                              AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                              AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                              AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                              AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                              AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                              AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                              A789SecFunctionalityModule ,
                                              A135SecFunctionalityDescription ,
                                              A735SecFunctionalityRoleAtivo ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A131SecRoleId ,
                                              AV71Wpfuncionalidadesds_1_secroleid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV72Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV72Wpfuncionalidadesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext), "%", "");
         lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = StringUtil.Concat( StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1), "%", "");
         lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = StringUtil.Concat( StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2), "%", "");
         lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = StringUtil.Concat( StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3), "%", "");
         lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = StringUtil.Concat( StringUtil.RTrim( AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule), "%", "");
         lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription), "%", "");
         /* Using cursor H007Y3 */
         pr_default.execute(1, new Object[] {AV71Wpfuncionalidadesds_1_secroleid, lV72Wpfuncionalidadesds_2_filterfulltext, lV72Wpfuncionalidadesds_2_filterfulltext, AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1, lV76Wpfuncionalidadesds_6_secfunctionalitydescription1, lV76Wpfuncionalidadesds_6_secfunctionalitydescription1, AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2, lV81Wpfuncionalidadesds_11_secfunctionalitydescription2, lV81Wpfuncionalidadesds_11_secfunctionalitydescription2, AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3, lV86Wpfuncionalidadesds_16_secfunctionalitydescription3, lV86Wpfuncionalidadesds_16_secfunctionalitydescription3, lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule, AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription, AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel});
         GRID_nRecordCount = H007Y3_AGRID_nRecordCount[0];
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
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV70Pgmname = "WpFuncionalidades";
         edtavBtnremover_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityModule_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecRoleId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV53GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV67SecFunctionalityRoleAtivo1 = StringUtil.StrToBool( cgiGet( chkavSecfunctionalityroleativo1_Internalname));
            AssignAttri("", false, "AV67SecFunctionalityRoleAtivo1", AV67SecFunctionalityRoleAtivo1);
            AV18SecFunctionalityDescription1 = cgiGet( edtavSecfunctionalitydescription1_Internalname);
            AssignAttri("", false, "AV18SecFunctionalityDescription1", AV18SecFunctionalityDescription1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV68SecFunctionalityRoleAtivo2 = StringUtil.StrToBool( cgiGet( chkavSecfunctionalityroleativo2_Internalname));
            AssignAttri("", false, "AV68SecFunctionalityRoleAtivo2", AV68SecFunctionalityRoleAtivo2);
            AV23SecFunctionalityDescription2 = cgiGet( edtavSecfunctionalitydescription2_Internalname);
            AssignAttri("", false, "AV23SecFunctionalityDescription2", AV23SecFunctionalityDescription2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV69SecFunctionalityRoleAtivo3 = StringUtil.StrToBool( cgiGet( chkavSecfunctionalityroleativo3_Internalname));
            AssignAttri("", false, "AV69SecFunctionalityRoleAtivo3", AV69SecFunctionalityRoleAtivo3);
            AV28SecFunctionalityDescription3 = cgiGet( edtavSecfunctionalitydescription3_Internalname);
            AssignAttri("", false, "AV28SecFunctionalityDescription3", AV28SecFunctionalityDescription3);
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO1")) != AV67SecFunctionalityRoleAtivo1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION1"), AV18SecFunctionalityDescription1) != 0 )
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO2")) != AV68SecFunctionalityRoleAtivo2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION2"), AV23SecFunctionalityDescription2) != 0 )
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECFUNCTIONALITYROLEATIVO3")) != AV69SecFunctionalityRoleAtivo3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECFUNCTIONALITYDESCRIPTION3"), AV28SecFunctionalityDescription3) != 0 )
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
         E247Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247Y2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV16DynamicFiltersSelector1 = "SECFUNCTIONALITYROLEATIVO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "SECFUNCTIONALITYROLEATIVO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "SECFUNCTIONALITYROLEATIVO";
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
         Form.Caption = " Functionality - Role";
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

      protected void E257Y2( )
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
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV70Pgmname, out  GXt_char2) ;
         AV55GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV55GridAppliedFilters", AV55GridAppliedFilters);
         AV71Wpfuncionalidadesds_1_secroleid = AV59SecRoleId;
         AV72Wpfuncionalidadesds_2_filterfulltext = AV15FilterFullText;
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 = AV67SecFunctionalityRoleAtivo1;
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = AV18SecFunctionalityDescription1;
         AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 = AV68SecFunctionalityRoleAtivo2;
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = AV23SecFunctionalityDescription2;
         AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 = AV69SecFunctionalityRoleAtivo3;
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = AV28SecFunctionalityDescription3;
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = AV65TFSecFunctionalityModule;
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = AV66TFSecFunctionalityModule_Sel;
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = AV42TFSecFunctionalityDescription;
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = AV43TFSecFunctionalityDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127Y2( )
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

      protected void E137Y2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147Y2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityModule") == 0 )
            {
               AV65TFSecFunctionalityModule = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV65TFSecFunctionalityModule", AV65TFSecFunctionalityModule);
               AV66TFSecFunctionalityModule_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFSecFunctionalityModule_Sel", AV66TFSecFunctionalityModule_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityDescription") == 0 )
            {
               AV42TFSecFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFSecFunctionalityDescription", AV42TFSecFunctionalityDescription);
               AV43TFSecFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFSecFunctionalityDescription_Sel", AV43TFSecFunctionalityDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E267Y2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV62BtnRemover = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavBtnremover_Internalname, AV62BtnRemover);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E197Y2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E157Y2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E207Y2( )
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

      protected void E217Y2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E167Y2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E227Y2( )
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

      protected void E177Y2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E237Y2( )
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

      protected void E117Y2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpFuncionalidadesFilters")) + "," + UrlEncode(StringUtil.RTrim(AV70Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpFuncionalidadesFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpFuncionalidadesFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV70Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E187Y2( )
      {
         /* 'DoBtnInserir' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpaddfunc"+UrlEncode(StringUtil.LTrimStr(AV59SecRoleId,4,0));
         context.PopUp(formatLink("wpaddfunc") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
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
         chkavSecfunctionalityroleativo1.Visible = 0;
         AssignProp("", false, chkavSecfunctionalityroleativo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo1.Visible), 5, 0), true);
         edtavSecfunctionalitydescription1_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYROLEATIVO") == 0 )
         {
            chkavSecfunctionalityroleativo1.Visible = 1;
            AssignProp("", false, chkavSecfunctionalityroleativo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription1_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         chkavSecfunctionalityroleativo2.Visible = 0;
         AssignProp("", false, chkavSecfunctionalityroleativo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo2.Visible), 5, 0), true);
         edtavSecfunctionalitydescription2_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYROLEATIVO") == 0 )
         {
            chkavSecfunctionalityroleativo2.Visible = 1;
            AssignProp("", false, chkavSecfunctionalityroleativo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription2_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         chkavSecfunctionalityroleativo3.Visible = 0;
         AssignProp("", false, chkavSecfunctionalityroleativo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo3.Visible), 5, 0), true);
         edtavSecfunctionalitydescription3_Visible = 0;
         AssignProp("", false, edtavSecfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYROLEATIVO") == 0 )
         {
            chkavSecfunctionalityroleativo3.Visible = 1;
            AssignProp("", false, chkavSecfunctionalityroleativo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecfunctionalityroleativo3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
         {
            edtavSecfunctionalitydescription3_Visible = 1;
            AssignProp("", false, edtavSecfunctionalitydescription3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecfunctionalitydescription3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "SECFUNCTIONALITYROLEATIVO";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV68SecFunctionalityRoleAtivo2 = false;
         AssignAttri("", false, "AV68SecFunctionalityRoleAtivo2", AV68SecFunctionalityRoleAtivo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "SECFUNCTIONALITYROLEATIVO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV69SecFunctionalityRoleAtivo3 = false;
         AssignAttri("", false, "AV69SecFunctionalityRoleAtivo3", AV69SecFunctionalityRoleAtivo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV35ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpFuncionalidadesFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV65TFSecFunctionalityModule = "";
         AssignAttri("", false, "AV65TFSecFunctionalityModule", AV65TFSecFunctionalityModule);
         AV66TFSecFunctionalityModule_Sel = "";
         AssignAttri("", false, "AV66TFSecFunctionalityModule_Sel", AV66TFSecFunctionalityModule_Sel);
         AV42TFSecFunctionalityDescription = "";
         AssignAttri("", false, "AV42TFSecFunctionalityDescription", AV42TFSecFunctionalityDescription);
         AV43TFSecFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV43TFSecFunctionalityDescription_Sel", AV43TFSecFunctionalityDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "SECFUNCTIONALITYROLEATIVO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV67SecFunctionalityRoleAtivo1 = false;
         AssignAttri("", false, "AV67SecFunctionalityRoleAtivo1", AV67SecFunctionalityRoleAtivo1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV70Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV70Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV70Pgmname+"GridState"), null, "", "");
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
         AV91GXV1 = 1;
         while ( AV91GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV91GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE") == 0 )
            {
               AV65TFSecFunctionalityModule = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFSecFunctionalityModule", AV65TFSecFunctionalityModule);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYMODULE_SEL") == 0 )
            {
               AV66TFSecFunctionalityModule_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFSecFunctionalityModule_Sel", AV66TFSecFunctionalityModule_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV42TFSecFunctionalityDescription = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSecFunctionalityDescription", AV42TFSecFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV43TFSecFunctionalityDescription_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFSecFunctionalityDescription_Sel", AV43TFSecFunctionalityDescription_Sel);
            }
            AV91GXV1 = (int)(AV91GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFSecFunctionalityModule_Sel)),  AV66TFSecFunctionalityModule_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecFunctionalityDescription_Sel)),  AV43TFSecFunctionalityDescription_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFSecFunctionalityModule)),  AV65TFSecFunctionalityModule, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecFunctionalityDescription)),  AV42TFSecFunctionalityDescription, out  GXt_char2) ;
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
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYROLEATIVO") == 0 )
            {
               AV67SecFunctionalityRoleAtivo1 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
               AssignAttri("", false, "AV67SecFunctionalityRoleAtivo1", AV67SecFunctionalityRoleAtivo1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18SecFunctionalityDescription1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18SecFunctionalityDescription1", AV18SecFunctionalityDescription1);
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
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYROLEATIVO") == 0 )
               {
                  AV68SecFunctionalityRoleAtivo2 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                  AssignAttri("", false, "AV68SecFunctionalityRoleAtivo2", AV68SecFunctionalityRoleAtivo2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23SecFunctionalityDescription2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23SecFunctionalityDescription2", AV23SecFunctionalityDescription2);
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
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYROLEATIVO") == 0 )
                  {
                     AV69SecFunctionalityRoleAtivo3 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                     AssignAttri("", false, "AV69SecFunctionalityRoleAtivo3", AV69SecFunctionalityRoleAtivo3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28SecFunctionalityDescription3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28SecFunctionalityDescription3", AV28SecFunctionalityDescription3);
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
         AV10GridState.FromXml(AV34Session.Get(AV70Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECFUNCTIONALITYMODULE",  "Modulo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFSecFunctionalityModule)),  0,  AV65TFSecFunctionalityModule,  AV65TFSecFunctionalityModule,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFSecFunctionalityModule_Sel)),  AV66TFSecFunctionalityModule_Sel,  AV66TFSecFunctionalityModule_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECFUNCTIONALITYDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecFunctionalityDescription)),  0,  AV42TFSecFunctionalityDescription,  AV42TFSecFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecFunctionalityDescription_Sel)),  AV43TFSecFunctionalityDescription_Sel,  AV43TFSecFunctionalityDescription_Sel) ;
         if ( ! (0==AV59SecRoleId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SECROLEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV59SecRoleId), 4, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
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
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ! (false==AV67SecFunctionalityRoleAtivo1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Ativo",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV67SecFunctionalityRoleAtivo1)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecFunctionalityDescription1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Functionality Description",  AV17DynamicFiltersOperator1,  AV18SecFunctionalityDescription1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18SecFunctionalityDescription1, "Contém"+" "+AV18SecFunctionalityDescription1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ! (false==AV68SecFunctionalityRoleAtivo2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Ativo",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV68SecFunctionalityRoleAtivo2)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SecFunctionalityDescription2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Functionality Description",  AV22DynamicFiltersOperator2,  AV23SecFunctionalityDescription2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV23SecFunctionalityDescription2, "Contém"+" "+AV23SecFunctionalityDescription2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ! (false==AV69SecFunctionalityRoleAtivo3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Ativo",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV69SecFunctionalityRoleAtivo3)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SecFunctionalityDescription3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Functionality Description",  AV27DynamicFiltersOperator3,  AV28SecFunctionalityDescription3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28SecFunctionalityDescription3, "Contém"+" "+AV28SecFunctionalityDescription3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV70Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecFunctionalityRole";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SecRoleId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV59SecRoleId), 4, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E277Y2( )
      {
         /* Btnremover_Click Routine */
         returnInSub = false;
         AV64SecFunctionalityRole.Load(A128SecFunctionalityId, A131SecRoleId);
         AV64SecFunctionalityRole.Delete();
         if ( AV64SecFunctionalityRole.Success() )
         {
            context.CommitDataStores("wpfuncionalidades",pr_default);
            GXt_char4 = "Funcionalidade retirada do perfil";
            new message(context ).gxep_sucesso( ref  GXt_char4) ;
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV67SecFunctionalityRoleAtivo1, AV18SecFunctionalityDescription1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV68SecFunctionalityRoleAtivo2, AV23SecFunctionalityDescription2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV69SecFunctionalityRoleAtivo3, AV28SecFunctionalityDescription3, AV37ManageFiltersExecutionStep, AV70Pgmname, AV59SecRoleId, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV65TFSecFunctionalityModule, AV66TFSecFunctionalityModule_Sel, AV42TFSecFunctionalityDescription, AV43TFSecFunctionalityDescription_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void wb_table3_93_7Y2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalityroleativo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecfunctionalityroleativo3_Internalname, "Sec Functionality Role Ativo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_114_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecfunctionalityroleativo3_Internalname, StringUtil.BoolToStr( AV69SecFunctionalityRoleAtivo3), "", "Sec Functionality Role Ativo3", chkavSecfunctionalityroleativo3.Visible, chkavSecfunctionalityroleativo3.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription3_Internalname, "Sec Functionality Description3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription3_Internalname, AV28SecFunctionalityDescription3, StringUtil.RTrim( context.localUtil.Format( AV28SecFunctionalityDescription3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription3_Visible, edtavSecfunctionalitydescription3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpFuncionalidades.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_93_7Y2e( true) ;
         }
         else
         {
            wb_table3_93_7Y2e( false) ;
         }
      }

      protected void wb_table2_68_7Y2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalityroleativo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecfunctionalityroleativo2_Internalname, "Sec Functionality Role Ativo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_114_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecfunctionalityroleativo2_Internalname, StringUtil.BoolToStr( AV68SecFunctionalityRoleAtivo2), "", "Sec Functionality Role Ativo2", chkavSecfunctionalityroleativo2.Visible, chkavSecfunctionalityroleativo2.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(75, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,75);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription2_Internalname, "Sec Functionality Description2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription2_Internalname, AV23SecFunctionalityDescription2, StringUtil.RTrim( context.localUtil.Format( AV23SecFunctionalityDescription2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription2_Visible, edtavSecfunctionalitydescription2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpFuncionalidades.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpFuncionalidades.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_68_7Y2e( true) ;
         }
         else
         {
            wb_table2_68_7Y2e( false) ;
         }
      }

      protected void wb_table1_43_7Y2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpFuncionalidades.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalityroleativo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecfunctionalityroleativo1_Internalname, "Sec Functionality Role Ativo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_114_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecfunctionalityroleativo1_Internalname, StringUtil.BoolToStr( AV67SecFunctionalityRoleAtivo1), "", "Sec Functionality Role Ativo1", chkavSecfunctionalityroleativo1.Visible, chkavSecfunctionalityroleativo1.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(50, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,50);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secfunctionalitydescription1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecfunctionalitydescription1_Internalname, "Sec Functionality Description1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecfunctionalitydescription1_Internalname, AV18SecFunctionalityDescription1, StringUtil.RTrim( context.localUtil.Format( AV18SecFunctionalityDescription1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecfunctionalitydescription1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecfunctionalitydescription1_Visible, edtavSecfunctionalitydescription1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpFuncionalidades.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpFuncionalidades.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpFuncionalidades.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_7Y2e( true) ;
         }
         else
         {
            wb_table1_43_7Y2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV59SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV59SecRoleId", StringUtil.LTrimStr( (decimal)(AV59SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59SecRoleId), "ZZZ9"), context));
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
         PA7Y2( ) ;
         WS7Y2( ) ;
         WE7Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019272169", true, true);
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
         context.AddJavascriptSource("wpfuncionalidades.js", "?202561019272170", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1142( )
      {
         edtavBtnremover_Internalname = "vBTNREMOVER_"+sGXsfl_114_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_114_idx;
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE_"+sGXsfl_114_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_114_idx;
      }

      protected void SubsflControlProps_fel_1142( )
      {
         edtavBtnremover_Internalname = "vBTNREMOVER_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE_"+sGXsfl_114_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_114_fel_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_114_fel_idx;
      }

      protected void sendrow_1142( )
      {
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         WB7Y0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavBtnremover_Internalname,StringUtil.RTrim( AV62BtnRemover),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"","'"+""+"'"+",false,"+"'"+"EVBTNREMOVER.CLICK."+sGXsfl_114_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavBtnremover_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavBtnremover_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityModule_Internalname,(string)A789SecFunctionalityModule,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityModule_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecRoleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)114,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes7Y2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("SECFUNCTIONALITYROLEATIVO", "Role Ativo", 0);
         cmbavDynamicfiltersselector1.addItem("SECFUNCTIONALITYDESCRIPTION", "Functionality Description", 0);
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
         chkavSecfunctionalityroleativo1.Name = "vSECFUNCTIONALITYROLEATIVO1";
         chkavSecfunctionalityroleativo1.WebTags = "";
         chkavSecfunctionalityroleativo1.Caption = "Sec Functionality Role Ativo1";
         AssignProp("", false, chkavSecfunctionalityroleativo1_Internalname, "TitleCaption", chkavSecfunctionalityroleativo1.Caption, true);
         chkavSecfunctionalityroleativo1.CheckedValue = "false";
         AV67SecFunctionalityRoleAtivo1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV67SecFunctionalityRoleAtivo1));
         AssignAttri("", false, "AV67SecFunctionalityRoleAtivo1", AV67SecFunctionalityRoleAtivo1);
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECFUNCTIONALITYROLEATIVO", "Role Ativo", 0);
         cmbavDynamicfiltersselector2.addItem("SECFUNCTIONALITYDESCRIPTION", "Functionality Description", 0);
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
         chkavSecfunctionalityroleativo2.Name = "vSECFUNCTIONALITYROLEATIVO2";
         chkavSecfunctionalityroleativo2.WebTags = "";
         chkavSecfunctionalityroleativo2.Caption = "Sec Functionality Role Ativo2";
         AssignProp("", false, chkavSecfunctionalityroleativo2_Internalname, "TitleCaption", chkavSecfunctionalityroleativo2.Caption, true);
         chkavSecfunctionalityroleativo2.CheckedValue = "false";
         AV68SecFunctionalityRoleAtivo2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV68SecFunctionalityRoleAtivo2));
         AssignAttri("", false, "AV68SecFunctionalityRoleAtivo2", AV68SecFunctionalityRoleAtivo2);
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECFUNCTIONALITYROLEATIVO", "Role Ativo", 0);
         cmbavDynamicfiltersselector3.addItem("SECFUNCTIONALITYDESCRIPTION", "Functionality Description", 0);
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
         chkavSecfunctionalityroleativo3.Name = "vSECFUNCTIONALITYROLEATIVO3";
         chkavSecfunctionalityroleativo3.WebTags = "";
         chkavSecfunctionalityroleativo3.Caption = "Sec Functionality Role Ativo3";
         AssignProp("", false, chkavSecfunctionalityroleativo3_Internalname, "TitleCaption", chkavSecfunctionalityroleativo3.Caption, true);
         chkavSecfunctionalityroleativo3.CheckedValue = "false";
         AV69SecFunctionalityRoleAtivo3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV69SecFunctionalityRoleAtivo3));
         AssignAttri("", false, "AV69SecFunctionalityRoleAtivo3", AV69SecFunctionalityRoleAtivo3);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Modulo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV62BtnRemover)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavBtnremover_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A789SecFunctionalityModule));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ".", ""))));
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
         bttBtnbtninserir_Internalname = "BTNBTNINSERIR";
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
         chkavSecfunctionalityroleativo1_Internalname = "vSECFUNCTIONALITYROLEATIVO1";
         cellFilter_secfunctionalityroleativo1_cell_Internalname = "FILTER_SECFUNCTIONALITYROLEATIVO1_CELL";
         edtavSecfunctionalitydescription1_Internalname = "vSECFUNCTIONALITYDESCRIPTION1";
         cellFilter_secfunctionalitydescription1_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION1_CELL";
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
         chkavSecfunctionalityroleativo2_Internalname = "vSECFUNCTIONALITYROLEATIVO2";
         cellFilter_secfunctionalityroleativo2_cell_Internalname = "FILTER_SECFUNCTIONALITYROLEATIVO2_CELL";
         edtavSecfunctionalitydescription2_Internalname = "vSECFUNCTIONALITYDESCRIPTION2";
         cellFilter_secfunctionalitydescription2_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION2_CELL";
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
         chkavSecfunctionalityroleativo3_Internalname = "vSECFUNCTIONALITYROLEATIVO3";
         cellFilter_secfunctionalityroleativo3_cell_Internalname = "FILTER_SECFUNCTIONALITYROLEATIVO3_CELL";
         edtavSecfunctionalitydescription3_Internalname = "vSECFUNCTIONALITYDESCRIPTION3";
         cellFilter_secfunctionalitydescription3_cell_Internalname = "FILTER_SECFUNCTIONALITYDESCRIPTION3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavBtnremover_Internalname = "vBTNREMOVER";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityModule_Internalname = "SECFUNCTIONALITYMODULE";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         edtSecRoleId_Internalname = "SECROLEID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
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
         chkavSecfunctionalityroleativo3.Caption = "Sec Functionality Role Ativo3";
         chkavSecfunctionalityroleativo2.Caption = "Sec Functionality Role Ativo2";
         chkavSecfunctionalityroleativo1.Caption = "Sec Functionality Role Ativo1";
         edtSecRoleId_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Link = "";
         edtSecFunctionalityModule_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         edtavBtnremover_Jsonclick = "";
         edtavBtnremover_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecfunctionalitydescription1_Jsonclick = "";
         edtavSecfunctionalitydescription1_Enabled = 1;
         chkavSecfunctionalityroleativo1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecfunctionalitydescription2_Jsonclick = "";
         edtavSecfunctionalitydescription2_Enabled = 1;
         chkavSecfunctionalityroleativo2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecfunctionalitydescription3_Jsonclick = "";
         edtavSecfunctionalitydescription3_Enabled = 1;
         chkavSecfunctionalityroleativo3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecfunctionalitydescription3_Visible = 1;
         chkavSecfunctionalityroleativo3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecfunctionalitydescription2_Visible = 1;
         chkavSecfunctionalityroleativo2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecfunctionalitydescription1_Visible = 1;
         chkavSecfunctionalityroleativo1.Visible = 1;
         edtSecRoleId_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityModule_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
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
         Ddo_grid_Datalistproc = "WpFuncionalidadesGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3";
         Ddo_grid_Columnids = "2:SecFunctionalityModule|3:SecFunctionalityDescription";
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
         Form.Caption = " Functionality - Role";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E267Y2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV62BtnRemover","fld":"vBTNREMOVER","type":"char"},{"av":"edtSecFunctionalityDescription_Link","ctrl":"SECFUNCTIONALITYDESCRIPTION","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E197Y2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"chkavSecfunctionalityroleativo2.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo3.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo1.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E207Y2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"chkavSecfunctionalityroleativo1.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E217Y2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"chkavSecfunctionalityroleativo2.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo3.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo1.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E227Y2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"chkavSecfunctionalityroleativo2.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"chkavSecfunctionalityroleativo2.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo3.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo1.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E237Y2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"chkavSecfunctionalityroleativo3.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"chkavSecfunctionalityroleativo1.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO1","prop":"Visible"},{"av":"edtavSecfunctionalitydescription1_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION1","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo2.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO2","prop":"Visible"},{"av":"edtavSecfunctionalitydescription2_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION2","prop":"Visible"},{"av":"chkavSecfunctionalityroleativo3.Visible","ctrl":"vSECFUNCTIONALITYROLEATIVO3","prop":"Visible"},{"av":"edtavSecfunctionalitydescription3_Visible","ctrl":"vSECFUNCTIONALITYDESCRIPTION3","prop":"Visible"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOBTNINSERIR'","""{"handler":"E187Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'DOBTNINSERIR'",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VBTNREMOVER.CLICK","""{"handler":"E277Y2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV67SecFunctionalityRoleAtivo1","fld":"vSECFUNCTIONALITYROLEATIVO1","type":"boolean"},{"av":"AV18SecFunctionalityDescription1","fld":"vSECFUNCTIONALITYDESCRIPTION1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV68SecFunctionalityRoleAtivo2","fld":"vSECFUNCTIONALITYROLEATIVO2","type":"boolean"},{"av":"AV23SecFunctionalityDescription2","fld":"vSECFUNCTIONALITYDESCRIPTION2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV69SecFunctionalityRoleAtivo3","fld":"vSECFUNCTIONALITYROLEATIVO3","type":"boolean"},{"av":"AV28SecFunctionalityDescription3","fld":"vSECFUNCTIONALITYDESCRIPTION3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV70Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV59SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV65TFSecFunctionalityModule","fld":"vTFSECFUNCTIONALITYMODULE","type":"svchar"},{"av":"AV66TFSecFunctionalityModule_Sel","fld":"vTFSECFUNCTIONALITYMODULE_SEL","type":"svchar"},{"av":"AV42TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV43TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VBTNREMOVER.CLICK",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secroleid","iparms":[]}""");
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
         AV21DynamicFiltersSelector2 = "";
         AV23SecFunctionalityDescription2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SecFunctionalityDescription3 = "";
         AV70Pgmname = "";
         AV65TFSecFunctionalityModule = "";
         AV66TFSecFunctionalityModule_Sel = "";
         AV42TFSecFunctionalityDescription = "";
         AV43TFSecFunctionalityDescription_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55GridAppliedFilters = "";
         AV51DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         bttBtnbtninserir_Jsonclick = "";
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
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV62BtnRemover = "";
         A789SecFunctionalityModule = "";
         A135SecFunctionalityDescription = "";
         GXDecQS = "";
         lV72Wpfuncionalidadesds_2_filterfulltext = "";
         lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = "";
         lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = "";
         lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = "";
         lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = "";
         lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = "";
         AV72Wpfuncionalidadesds_2_filterfulltext = "";
         AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 = "";
         AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 = "";
         AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 = "";
         AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 = "";
         AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 = "";
         AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 = "";
         AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel = "";
         AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule = "";
         AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel = "";
         AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription = "";
         H007Y2_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         H007Y2_A131SecRoleId = new short[1] ;
         H007Y2_A135SecFunctionalityDescription = new string[] {""} ;
         H007Y2_n135SecFunctionalityDescription = new bool[] {false} ;
         H007Y2_A789SecFunctionalityModule = new string[] {""} ;
         H007Y2_n789SecFunctionalityModule = new bool[] {false} ;
         H007Y2_A128SecFunctionalityId = new long[1] ;
         H007Y3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV36ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV64SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
         GXt_char4 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpfuncionalidades__default(),
            new Object[][] {
                new Object[] {
               H007Y2_A735SecFunctionalityRoleAtivo, H007Y2_A131SecRoleId, H007Y2_A135SecFunctionalityDescription, H007Y2_n135SecFunctionalityDescription, H007Y2_A789SecFunctionalityModule, H007Y2_n789SecFunctionalityModule, H007Y2_A128SecFunctionalityId
               }
               , new Object[] {
               H007Y3_AGRID_nRecordCount
               }
            }
         );
         AV70Pgmname = "WpFuncionalidades";
         /* GeneXus formulas. */
         AV70Pgmname = "WpFuncionalidades";
         edtavBtnremover_Enabled = 0;
      }

      private short AV59SecRoleId ;
      private short wcpOAV59SecRoleId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A131SecRoleId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 ;
      private short AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 ;
      private short AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 ;
      private short AV71Wpfuncionalidadesds_1_secroleid ;
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
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavBtnremover_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityModule_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecRoleId_Enabled ;
      private int AV52PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSecfunctionalitydescription1_Visible ;
      private int edtavSecfunctionalitydescription2_Visible ;
      private int edtavSecfunctionalitydescription3_Visible ;
      private int AV91GXV1 ;
      private int edtavSecfunctionalitydescription3_Enabled ;
      private int edtavSecfunctionalitydescription2_Enabled ;
      private int edtavSecfunctionalitydescription1_Enabled ;
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
      private long A128SecFunctionalityId ;
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
      private string AV70Pgmname ;
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
      private string bttBtnbtninserir_Internalname ;
      private string bttBtnbtninserir_Jsonclick ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV62BtnRemover ;
      private string edtavBtnremover_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityModule_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string edtSecRoleId_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string chkavSecfunctionalityroleativo1_Internalname ;
      private string edtavSecfunctionalitydescription1_Internalname ;
      private string chkavSecfunctionalityroleativo2_Internalname ;
      private string edtavSecfunctionalitydescription2_Internalname ;
      private string chkavSecfunctionalityroleativo3_Internalname ;
      private string edtavSecfunctionalitydescription3_Internalname ;
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
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secfunctionalityroleativo3_cell_Internalname ;
      private string cellFilter_secfunctionalitydescription3_cell_Internalname ;
      private string edtavSecfunctionalitydescription3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secfunctionalityroleativo2_cell_Internalname ;
      private string cellFilter_secfunctionalitydescription2_cell_Internalname ;
      private string edtavSecfunctionalitydescription2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secfunctionalityroleativo1_cell_Internalname ;
      private string cellFilter_secfunctionalitydescription1_cell_Internalname ;
      private string edtavSecfunctionalitydescription1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_114_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavBtnremover_Jsonclick ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityModule_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string edtSecRoleId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV67SecFunctionalityRoleAtivo1 ;
      private bool AV68SecFunctionalityRoleAtivo2 ;
      private bool AV69SecFunctionalityRoleAtivo3 ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
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
      private bool n789SecFunctionalityModule ;
      private bool n135SecFunctionalityDescription ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 ;
      private bool AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 ;
      private bool AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 ;
      private bool AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 ;
      private bool AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 ;
      private bool A735SecFunctionalityRoleAtivo ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV36ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18SecFunctionalityDescription1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23SecFunctionalityDescription2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28SecFunctionalityDescription3 ;
      private string AV65TFSecFunctionalityModule ;
      private string AV66TFSecFunctionalityModule_Sel ;
      private string AV42TFSecFunctionalityDescription ;
      private string AV43TFSecFunctionalityDescription_Sel ;
      private string AV55GridAppliedFilters ;
      private string A789SecFunctionalityModule ;
      private string A135SecFunctionalityDescription ;
      private string lV72Wpfuncionalidadesds_2_filterfulltext ;
      private string lV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ;
      private string lV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ;
      private string lV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ;
      private string lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ;
      private string lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ;
      private string AV72Wpfuncionalidadesds_2_filterfulltext ;
      private string AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 ;
      private string AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ;
      private string AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 ;
      private string AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ;
      private string AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 ;
      private string AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ;
      private string AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ;
      private string AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ;
      private string AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ;
      private string AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCheckbox chkavSecfunctionalityroleativo1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCheckbox chkavSecfunctionalityroleativo2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkavSecfunctionalityroleativo3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private bool[] H007Y2_A735SecFunctionalityRoleAtivo ;
      private short[] H007Y2_A131SecRoleId ;
      private string[] H007Y2_A135SecFunctionalityDescription ;
      private bool[] H007Y2_n135SecFunctionalityDescription ;
      private string[] H007Y2_A789SecFunctionalityModule ;
      private bool[] H007Y2_n789SecFunctionalityModule ;
      private long[] H007Y2_A128SecFunctionalityId ;
      private long[] H007Y3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole AV64SecFunctionalityRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpfuncionalidades__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007Y2( IGxContext context ,
                                             string AV72Wpfuncionalidadesds_2_filterfulltext ,
                                             string AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                             bool AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                             short AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                             string AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                             bool AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                             string AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                             bool AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                             short AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                             string AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                             bool AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                             string AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                             bool AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                             short AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                             string AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                             string AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                             string AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                             string AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                             string AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                             string A789SecFunctionalityModule ,
                                             string A135SecFunctionalityDescription ,
                                             bool A735SecFunctionalityRoleAtivo ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV71Wpfuncionalidadesds_1_secroleid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[19];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecFunctionalityRoleAtivo, T1.SecRoleId, T2.SecFunctionalityDescription, T2.SecFunctionalityModule, T1.SecFunctionalityId";
         sFromString = " FROM (SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV71Wpfuncionalidadesds_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityModule like '%' || :lV72Wpfuncionalidadesds_2_filterfulltext) or ( T2.SecFunctionalityDescription like '%' || :lV72Wpfuncionalidadesds_2_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV76Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV76Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV81Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV81Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV86Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV86Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule like :lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule = ( :AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityModule))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityRoleAtivo, T1.SecFunctionalityId, T1.SecRoleId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecFunctionalityModule, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecFunctionalityModule DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId, T1.SecRoleId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H007Y3( IGxContext context ,
                                             string AV72Wpfuncionalidadesds_2_filterfulltext ,
                                             string AV73Wpfuncionalidadesds_3_dynamicfiltersselector1 ,
                                             bool AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1 ,
                                             short AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 ,
                                             string AV76Wpfuncionalidadesds_6_secfunctionalitydescription1 ,
                                             bool AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 ,
                                             string AV78Wpfuncionalidadesds_8_dynamicfiltersselector2 ,
                                             bool AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2 ,
                                             short AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 ,
                                             string AV81Wpfuncionalidadesds_11_secfunctionalitydescription2 ,
                                             bool AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 ,
                                             string AV83Wpfuncionalidadesds_13_dynamicfiltersselector3 ,
                                             bool AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3 ,
                                             short AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 ,
                                             string AV86Wpfuncionalidadesds_16_secfunctionalitydescription3 ,
                                             string AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel ,
                                             string AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule ,
                                             string AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel ,
                                             string AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription ,
                                             string A789SecFunctionalityModule ,
                                             string A135SecFunctionalityDescription ,
                                             bool A735SecFunctionalityRoleAtivo ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV71Wpfuncionalidadesds_1_secroleid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecFunctionalityRole T1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecFunctionalityId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV71Wpfuncionalidadesds_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Wpfuncionalidadesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecFunctionalityModule like '%' || :lV72Wpfuncionalidadesds_2_filterfulltext) or ( T2.SecFunctionalityDescription like '%' || :lV72Wpfuncionalidadesds_2_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV76Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Wpfuncionalidadesds_3_dynamicfiltersselector1, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV74Wpfuncionalidadesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpfuncionalidadesds_6_secfunctionalitydescription1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV76Wpfuncionalidadesds_6_secfunctionalitydescription1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV81Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV77Wpfuncionalidadesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Wpfuncionalidadesds_8_dynamicfiltersselector2, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV79Wpfuncionalidadesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wpfuncionalidadesds_11_secfunctionalitydescription2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV81Wpfuncionalidadesds_11_secfunctionalitydescription2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYROLEATIVO") == 0 ) && ( ! (false==AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityRoleAtivo = :AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV86Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV82Wpfuncionalidadesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Wpfuncionalidadesds_13_dynamicfiltersselector3, "SECFUNCTIONALITYDESCRIPTION") == 0 ) && ( AV84Wpfuncionalidadesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wpfuncionalidadesds_16_secfunctionalitydescription3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like '%' || :lV86Wpfuncionalidadesds_16_secfunctionalitydescription3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule like :lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel)) && ! ( StringUtil.StrCmp(AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityModule = ( :AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecFunctionalityModule))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV13OrderedBy == 1 )
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

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H007Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_H007Y3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmH007Y2;
          prmH007Y2 = new Object[] {
          new ParDef("AV71Wpfuncionalidadesds_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV72Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1",GXType.Boolean,4,0) ,
          new ParDef("lV76Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV76Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2",GXType.Boolean,4,0) ,
          new ParDef("lV81Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3",GXType.Boolean,4,0) ,
          new ParDef("lV86Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV86Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007Y3;
          prmH007Y3 = new Object[] {
          new ParDef("AV71Wpfuncionalidadesds_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV72Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Wpfuncionalidadesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV75Wpfuncionalidadesds_5_secfunctionalityroleativo1",GXType.Boolean,4,0) ,
          new ParDef("lV76Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("lV76Wpfuncionalidadesds_6_secfunctionalitydescription1",GXType.VarChar,100,0) ,
          new ParDef("AV80Wpfuncionalidadesds_10_secfunctionalityroleativo2",GXType.Boolean,4,0) ,
          new ParDef("lV81Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("lV81Wpfuncionalidadesds_11_secfunctionalitydescription2",GXType.VarChar,100,0) ,
          new ParDef("AV85Wpfuncionalidadesds_15_secfunctionalityroleativo3",GXType.Boolean,4,0) ,
          new ParDef("lV86Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV86Wpfuncionalidadesds_16_secfunctionalitydescription3",GXType.VarChar,100,0) ,
          new ParDef("lV87Wpfuncionalidadesds_17_tfsecfunctionalitymodule",GXType.VarChar,100,0) ,
          new ParDef("AV88Wpfuncionalidadesds_18_tfsecfunctionalitymodule_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Wpfuncionalidadesds_19_tfsecfunctionalitydescription",GXType.VarChar,100,0) ,
          new ParDef("AV90Wpfuncionalidadesds_20_tfsecfunctionalitydescription_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Y2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007Y3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
