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
   public class wpperfilusuario : GXDataArea
   {
      public wpperfilusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpperfilusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId ,
                           string aP1_SecRoleName )
      {
         this.AV50SecRoleId = aP0_SecRoleId;
         this.AV53SecRoleName = aP1_SecRoleName;
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
         chkavSecuserroleactive1 = new GXCheckbox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         chkavSecuserroleactive2 = new GXCheckbox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         chkavSecuserroleactive3 = new GXCheckbox();
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
         nRC_GXsfl_126 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_126"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_126_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_126_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_126_idx = GetPar( "sGXsfl_126_idx");
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
         AV54SecUserRoleActive1 = StringUtil.StrToBool( GetPar( "SecUserRoleActive1"));
         AV18SecUserName1 = GetPar( "SecUserName1");
         AV19SecRoleName1 = GetPar( "SecRoleName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV55SecUserRoleActive2 = StringUtil.StrToBool( GetPar( "SecUserRoleActive2"));
         AV23SecUserName2 = GetPar( "SecUserName2");
         AV24SecRoleName2 = GetPar( "SecRoleName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV56SecUserRoleActive3 = StringUtil.StrToBool( GetPar( "SecUserRoleActive3"));
         AV28SecUserName3 = GetPar( "SecUserName3");
         AV29SecRoleName3 = GetPar( "SecRoleName3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV57Pgmname = GetPar( "Pgmname");
         AV50SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         AV38TFSecUserName = GetPar( "TFSecUserName");
         AV39TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV42TFSecRoleDescription = GetPar( "TFSecRoleDescription");
         AV43TFSecRoleDescription_Sel = GetPar( "TFSecRoleDescription_Sel");
         AV53SecRoleName = GetPar( "SecRoleName");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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
         PA7R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7R2( ) ;
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
         GXEncryptionTmp = "wpperfilusuario"+UrlEncode(StringUtil.LTrimStr(AV50SecRoleId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV53SecRoleName));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpperfilusuario") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSECROLENAME", AV53SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53SecRoleName, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERROLEACTIVE1", StringUtil.BoolToStr( AV54SecUserRoleActive1));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME1", AV18SecUserName1);
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME1", AV19SecRoleName1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERROLEACTIVE2", StringUtil.BoolToStr( AV55SecUserRoleActive2));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME2", AV23SecUserName2);
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME2", AV24SecRoleName2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERROLEACTIVE3", StringUtil.BoolToStr( AV56SecUserRoleActive3));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME3", AV28SecUserName3);
         GxWebStd.gx_hidden_field( context, "GXH_vSECROLENAME3", AV29SecRoleName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_126", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_126), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV48GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV44DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV44DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME", AV38TFSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME_SEL", AV39TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECROLEDESCRIPTION", AV42TFSecRoleDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECROLEDESCRIPTION_SEL", AV43TFSecRoleDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vSECROLENAME", AV53SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53SecRoleName, "")), context));
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
            WE7R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7R2( ) ;
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
         GXEncryptionTmp = "wpperfilusuario"+UrlEncode(StringUtil.LTrimStr(AV50SecRoleId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV53SecRoleName));
         return formatLink("wpperfilusuario") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpPerfilUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return " Sec User Role" ;
      }

      protected void WB7R0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrolename_Internalname, lblLblrolename_Caption, "", "", lblLblrolename_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninserir_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(126), 3, 0)+","+"null"+");", "Inserir", bttBtninserir_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERIR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpPerfilUsuario.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpPerfilUsuario.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_46_7R2( true) ;
         }
         else
         {
            wb_table1_46_7R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_46_7R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_74_7R2( true) ;
         }
         else
         {
            wb_table2_74_7R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_74_7R2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_102_7R2( true) ;
         }
         else
         {
            wb_table3_102_7R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_102_7R2e( bool wbgen )
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
            StartGridControl126( ) ;
         }
         if ( wbEnd == 126 )
         {
            wbEnd = 0;
            nRC_GXsfl_126 = (int)(nGXsfl_126_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV46GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV47GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV48GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpPerfilUsuario.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV44DDO_TitleSettingsIcons);
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
         if ( wbEnd == 126 )
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

      protected void START7R2( )
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
         Form.Meta.addItem("description", " Sec User Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7R0( ) ;
      }

      protected void WS7R2( )
      {
         START7R2( ) ;
         EVT7R2( ) ;
      }

      protected void EVT7R2( )
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
                              E117R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E127R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E137R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E147R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E157R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E167R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E177R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERIR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Doinserir' */
                              E187R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E197R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E207R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E217R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E227R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E237R2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDELETAR.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VDELETAR.CLICK") == 0 ) )
                           {
                              nGXsfl_126_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
                              SubsflControlProps_1262( ) ;
                              AV51Deletar = cgiGet( edtavDeletar_Internalname);
                              AssignAttri("", false, edtavDeletar_Internalname, AV51Deletar);
                              A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
                              n141SecUserName = false;
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
                                    E247R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E257R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E267R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETAR.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E277R2 ();
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
                                       /* Set Refresh If Secuserroleactive1 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE1")) != AV54SecUserRoleActive1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV18SecUserName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME1"), AV19SecRoleName1) != 0 )
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
                                       /* Set Refresh If Secuserroleactive2 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE2")) != AV55SecUserRoleActive2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV23SecUserName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME2"), AV24SecRoleName2) != 0 )
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
                                       /* Set Refresh If Secuserroleactive3 Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE3")) != AV56SecUserRoleActive3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV28SecUserName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secrolename3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME3"), AV29SecRoleName3) != 0 )
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

      protected void WE7R2( )
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

      protected void PA7R2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpperfilusuario")), "wpperfilusuario") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpperfilusuario")))) ;
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
                     AV50SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV50SecRoleId", StringUtil.LTrimStr( (decimal)(AV50SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50SecRoleId), "ZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV53SecRoleName = GetPar( "SecRoleName");
                        AssignAttri("", false, "AV53SecRoleName", AV53SecRoleName);
                        GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53SecRoleName, "")), context));
                     }
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
         SubsflControlProps_1262( ) ;
         while ( nGXsfl_126_idx <= nRC_GXsfl_126 )
         {
            sendrow_1262( ) ;
            nGXsfl_126_idx = ((subGrid_Islastpage==1)&&(nGXsfl_126_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
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
                                       bool AV54SecUserRoleActive1 ,
                                       string AV18SecUserName1 ,
                                       string AV19SecRoleName1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       bool AV55SecUserRoleActive2 ,
                                       string AV23SecUserName2 ,
                                       string AV24SecRoleName2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       bool AV56SecUserRoleActive3 ,
                                       string AV28SecUserName3 ,
                                       string AV29SecRoleName3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV57Pgmname ,
                                       short AV50SecRoleId ,
                                       string AV38TFSecUserName ,
                                       string AV39TFSecUserName_Sel ,
                                       string AV42TFSecRoleDescription ,
                                       string AV43TFSecRoleDescription_Sel ,
                                       string AV53SecRoleName ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF7R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", "")));
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
         AV54SecUserRoleActive1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV54SecUserRoleActive1));
         AssignAttri("", false, "AV54SecUserRoleActive1", AV54SecUserRoleActive1);
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
         AV55SecUserRoleActive2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV55SecUserRoleActive2));
         AssignAttri("", false, "AV55SecUserRoleActive2", AV55SecUserRoleActive2);
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
         AV56SecUserRoleActive3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV56SecUserRoleActive3));
         AssignAttri("", false, "AV56SecUserRoleActive3", AV56SecUserRoleActive3);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV57Pgmname = "WpPerfilUsuario";
         edtavDeletar_Enabled = 0;
      }

      protected void RF7R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 126;
         /* Execute user event: Refresh */
         E257R2 ();
         nGXsfl_126_idx = 1;
         sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
         SubsflControlProps_1262( ) ;
         bGXsfl_126_Refreshing = true;
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
            SubsflControlProps_1262( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV59Wpperfilusuariods_2_filterfulltext ,
                                                 AV60Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                                 AV62Wpperfilusuariods_5_secuserroleactive1 ,
                                                 AV61Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                                 AV63Wpperfilusuariods_6_secusername1 ,
                                                 AV64Wpperfilusuariods_7_secrolename1 ,
                                                 AV65Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                                 AV66Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                                 AV68Wpperfilusuariods_11_secuserroleactive2 ,
                                                 AV67Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                                 AV69Wpperfilusuariods_12_secusername2 ,
                                                 AV70Wpperfilusuariods_13_secrolename2 ,
                                                 AV71Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                                 AV72Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                                 AV74Wpperfilusuariods_17_secuserroleactive3 ,
                                                 AV73Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                                 AV75Wpperfilusuariods_18_secusername3 ,
                                                 AV76Wpperfilusuariods_19_secrolename3 ,
                                                 AV78Wpperfilusuariods_21_tfsecusername_sel ,
                                                 AV77Wpperfilusuariods_20_tfsecusername ,
                                                 AV80Wpperfilusuariods_23_tfsecroledescription_sel ,
                                                 AV79Wpperfilusuariods_22_tfsecroledescription ,
                                                 A141SecUserName ,
                                                 A139SecRoleDescription ,
                                                 A647SecUserRoleActive ,
                                                 A140SecRoleName ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc ,
                                                 A131SecRoleId ,
                                                 AV58Wpperfilusuariods_1_secroleid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV59Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext), "%", "");
            lV59Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext), "%", "");
            lV63Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1), "%", "");
            lV63Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1), "%", "");
            lV64Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1), "%", "");
            lV64Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1), "%", "");
            lV69Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2), "%", "");
            lV69Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2), "%", "");
            lV70Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2), "%", "");
            lV70Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2), "%", "");
            lV75Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3), "%", "");
            lV75Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3), "%", "");
            lV76Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3), "%", "");
            lV76Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3), "%", "");
            lV77Wpperfilusuariods_20_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_20_tfsecusername), "%", "");
            lV79Wpperfilusuariods_22_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV79Wpperfilusuariods_22_tfsecroledescription), "%", "");
            /* Using cursor H007R2 */
            pr_default.execute(0, new Object[] {AV58Wpperfilusuariods_1_secroleid, lV59Wpperfilusuariods_2_filterfulltext, lV59Wpperfilusuariods_2_filterfulltext, AV62Wpperfilusuariods_5_secuserroleactive1, lV63Wpperfilusuariods_6_secusername1, lV63Wpperfilusuariods_6_secusername1, lV64Wpperfilusuariods_7_secrolename1, lV64Wpperfilusuariods_7_secrolename1, AV68Wpperfilusuariods_11_secuserroleactive2, lV69Wpperfilusuariods_12_secusername2, lV69Wpperfilusuariods_12_secusername2, lV70Wpperfilusuariods_13_secrolename2, lV70Wpperfilusuariods_13_secrolename2, AV74Wpperfilusuariods_17_secuserroleactive3, lV75Wpperfilusuariods_18_secusername3, lV75Wpperfilusuariods_18_secusername3, lV76Wpperfilusuariods_19_secrolename3, lV76Wpperfilusuariods_19_secrolename3, lV77Wpperfilusuariods_20_tfsecusername, AV78Wpperfilusuariods_21_tfsecusername_sel, lV79Wpperfilusuariods_22_tfsecroledescription, AV80Wpperfilusuariods_23_tfsecroledescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_126_idx = 1;
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A140SecRoleName = H007R2_A140SecRoleName[0];
               A647SecUserRoleActive = H007R2_A647SecUserRoleActive[0];
               A139SecRoleDescription = H007R2_A139SecRoleDescription[0];
               A141SecUserName = H007R2_A141SecUserName[0];
               n141SecUserName = H007R2_n141SecUserName[0];
               A131SecRoleId = H007R2_A131SecRoleId[0];
               A133SecUserId = H007R2_A133SecUserId[0];
               A140SecRoleName = H007R2_A140SecRoleName[0];
               A139SecRoleDescription = H007R2_A139SecRoleDescription[0];
               A141SecUserName = H007R2_A141SecUserName[0];
               n141SecUserName = H007R2_n141SecUserName[0];
               /* Execute user event: Grid.Load */
               E267R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 126;
            WB7R0( ) ;
         }
         bGXsfl_126_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes7R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV57Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECROLEID"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"), context));
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
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV59Wpperfilusuariods_2_filterfulltext ,
                                              AV60Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                              AV62Wpperfilusuariods_5_secuserroleactive1 ,
                                              AV61Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                              AV63Wpperfilusuariods_6_secusername1 ,
                                              AV64Wpperfilusuariods_7_secrolename1 ,
                                              AV65Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                              AV66Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                              AV68Wpperfilusuariods_11_secuserroleactive2 ,
                                              AV67Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                              AV69Wpperfilusuariods_12_secusername2 ,
                                              AV70Wpperfilusuariods_13_secrolename2 ,
                                              AV71Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                              AV72Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                              AV74Wpperfilusuariods_17_secuserroleactive3 ,
                                              AV73Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                              AV75Wpperfilusuariods_18_secusername3 ,
                                              AV76Wpperfilusuariods_19_secrolename3 ,
                                              AV78Wpperfilusuariods_21_tfsecusername_sel ,
                                              AV77Wpperfilusuariods_20_tfsecusername ,
                                              AV80Wpperfilusuariods_23_tfsecroledescription_sel ,
                                              AV79Wpperfilusuariods_22_tfsecroledescription ,
                                              A141SecUserName ,
                                              A139SecRoleDescription ,
                                              A647SecUserRoleActive ,
                                              A140SecRoleName ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc ,
                                              A131SecRoleId ,
                                              AV58Wpperfilusuariods_1_secroleid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV59Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext), "%", "");
         lV59Wpperfilusuariods_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext), "%", "");
         lV63Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1), "%", "");
         lV63Wpperfilusuariods_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1), "%", "");
         lV64Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1), "%", "");
         lV64Wpperfilusuariods_7_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1), "%", "");
         lV69Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2), "%", "");
         lV69Wpperfilusuariods_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2), "%", "");
         lV70Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2), "%", "");
         lV70Wpperfilusuariods_13_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2), "%", "");
         lV75Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3), "%", "");
         lV75Wpperfilusuariods_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3), "%", "");
         lV76Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3), "%", "");
         lV76Wpperfilusuariods_19_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3), "%", "");
         lV77Wpperfilusuariods_20_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV77Wpperfilusuariods_20_tfsecusername), "%", "");
         lV79Wpperfilusuariods_22_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV79Wpperfilusuariods_22_tfsecroledescription), "%", "");
         /* Using cursor H007R3 */
         pr_default.execute(1, new Object[] {AV58Wpperfilusuariods_1_secroleid, lV59Wpperfilusuariods_2_filterfulltext, lV59Wpperfilusuariods_2_filterfulltext, AV62Wpperfilusuariods_5_secuserroleactive1, lV63Wpperfilusuariods_6_secusername1, lV63Wpperfilusuariods_6_secusername1, lV64Wpperfilusuariods_7_secrolename1, lV64Wpperfilusuariods_7_secrolename1, AV68Wpperfilusuariods_11_secuserroleactive2, lV69Wpperfilusuariods_12_secusername2, lV69Wpperfilusuariods_12_secusername2, lV70Wpperfilusuariods_13_secrolename2, lV70Wpperfilusuariods_13_secrolename2, AV74Wpperfilusuariods_17_secuserroleactive3, lV75Wpperfilusuariods_18_secusername3, lV75Wpperfilusuariods_18_secusername3, lV76Wpperfilusuariods_19_secrolename3, lV76Wpperfilusuariods_19_secrolename3, lV77Wpperfilusuariods_20_tfsecusername, AV78Wpperfilusuariods_21_tfsecusername_sel, lV79Wpperfilusuariods_22_tfsecroledescription, AV80Wpperfilusuariods_23_tfsecroledescription_sel});
         GRID_nRecordCount = H007R3_AGRID_nRecordCount[0];
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
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV57Pgmname = "WpPerfilUsuario";
         edtavDeletar_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtSecRoleId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecRoleDescription_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E247R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV44DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_126 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_126"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV47GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV54SecUserRoleActive1 = StringUtil.StrToBool( cgiGet( chkavSecuserroleactive1_Internalname));
            AssignAttri("", false, "AV54SecUserRoleActive1", AV54SecUserRoleActive1);
            AV18SecUserName1 = StringUtil.Upper( cgiGet( edtavSecusername1_Internalname));
            AssignAttri("", false, "AV18SecUserName1", AV18SecUserName1);
            AV19SecRoleName1 = cgiGet( edtavSecrolename1_Internalname);
            AssignAttri("", false, "AV19SecRoleName1", AV19SecRoleName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV55SecUserRoleActive2 = StringUtil.StrToBool( cgiGet( chkavSecuserroleactive2_Internalname));
            AssignAttri("", false, "AV55SecUserRoleActive2", AV55SecUserRoleActive2);
            AV23SecUserName2 = StringUtil.Upper( cgiGet( edtavSecusername2_Internalname));
            AssignAttri("", false, "AV23SecUserName2", AV23SecUserName2);
            AV24SecRoleName2 = cgiGet( edtavSecrolename2_Internalname);
            AssignAttri("", false, "AV24SecRoleName2", AV24SecRoleName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV56SecUserRoleActive3 = StringUtil.StrToBool( cgiGet( chkavSecuserroleactive3_Internalname));
            AssignAttri("", false, "AV56SecUserRoleActive3", AV56SecUserRoleActive3);
            AV28SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri("", false, "AV28SecUserName3", AV28SecUserName3);
            AV29SecRoleName3 = cgiGet( edtavSecrolename3_Internalname);
            AssignAttri("", false, "AV29SecRoleName3", AV29SecRoleName3);
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE1")) != AV54SecUserRoleActive1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV18SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME1"), AV19SecRoleName1) != 0 )
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE2")) != AV55SecUserRoleActive2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV23SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME2"), AV24SecRoleName2) != 0 )
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
            if ( StringUtil.StrToBool( cgiGet( "GXH_vSECUSERROLEACTIVE3")) != AV56SecUserRoleActive3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV28SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECROLENAME3"), AV29SecRoleName3) != 0 )
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
         E247R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E247R2( )
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
         AV16DynamicFiltersSelector1 = "SECUSERROLEACTIVE";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "SECUSERROLEACTIVE";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "SECUSERROLEACTIVE";
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
         Form.Caption = " Sec User Role";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV44DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV44DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         lblLblrolename_Caption = StringUtil.Format( "<h3> %1 </h3>", AV53SecRoleName, "", "", "", "", "", "", "", "");
         AssignProp("", false, lblLblrolename_Internalname, "Caption", lblLblrolename_Caption, true);
      }

      protected void E257R2( )
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
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECROLENAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECROLENAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECROLENAME") == 0 )
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
         AV46GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV46GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV46GridCurrentPage), 10, 0));
         AV47GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV47GridPageCount", StringUtil.LTrimStr( (decimal)(AV47GridPageCount), 10, 0));
         GXt_char2 = AV48GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV57Pgmname, out  GXt_char2) ;
         AV48GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV48GridAppliedFilters", AV48GridAppliedFilters);
         AV58Wpperfilusuariods_1_secroleid = AV50SecRoleId;
         AV59Wpperfilusuariods_2_filterfulltext = AV15FilterFullText;
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV61Wpperfilusuariods_4_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV62Wpperfilusuariods_5_secuserroleactive1 = AV54SecUserRoleActive1;
         AV63Wpperfilusuariods_6_secusername1 = AV18SecUserName1;
         AV64Wpperfilusuariods_7_secrolename1 = AV19SecRoleName1;
         AV65Wpperfilusuariods_8_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV67Wpperfilusuariods_10_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV68Wpperfilusuariods_11_secuserroleactive2 = AV55SecUserRoleActive2;
         AV69Wpperfilusuariods_12_secusername2 = AV23SecUserName2;
         AV70Wpperfilusuariods_13_secrolename2 = AV24SecRoleName2;
         AV71Wpperfilusuariods_14_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV73Wpperfilusuariods_16_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV74Wpperfilusuariods_17_secuserroleactive3 = AV56SecUserRoleActive3;
         AV75Wpperfilusuariods_18_secusername3 = AV28SecUserName3;
         AV76Wpperfilusuariods_19_secrolename3 = AV29SecRoleName3;
         AV77Wpperfilusuariods_20_tfsecusername = AV38TFSecUserName;
         AV78Wpperfilusuariods_21_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV79Wpperfilusuariods_22_tfsecroledescription = AV42TFSecRoleDescription;
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = AV43TFSecRoleDescription_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E127R2( )
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
            AV45PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV45PageToGo) ;
         }
      }

      protected void E137R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E147R2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserName") == 0 )
            {
               AV38TFSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV38TFSecUserName", AV38TFSecUserName);
               AV39TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecRoleDescription") == 0 )
            {
               AV42TFSecRoleDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFSecRoleDescription", AV42TFSecRoleDescription);
               AV43TFSecRoleDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFSecRoleDescription_Sel", AV43TFSecRoleDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E267R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV51Deletar = "<i class=\"fas fa-times\"></i>";
         AssignAttri("", false, edtavDeletar_Internalname, AV51Deletar);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 126;
         }
         sendrow_1262( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_126_Refreshing )
         {
            DoAjaxLoad(126, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E197R2( )
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

      protected void E157R2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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

      protected void E207R2( )
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

      protected void E217R2( )
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

      protected void E167R2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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

      protected void E227R2( )
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

      protected void E177R2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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

      protected void E237R2( )
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

      protected void E117R2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpPerfilUsuarioFilters")) + "," + UrlEncode(StringUtil.RTrim(AV57Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpPerfilUsuarioFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpPerfilUsuarioFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV36ManageFiltersXml) ;
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

      protected void E187R2( )
      {
         /* 'Doinserir' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpselectuser"+UrlEncode(StringUtil.LTrimStr(AV50SecRoleId,4,0));
         context.PopUp(formatLink("wpselectuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
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
         chkavSecuserroleactive1.Visible = 0;
         AssignProp("", false, chkavSecuserroleactive1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive1.Visible), 5, 0), true);
         edtavSecusername1_Visible = 0;
         AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
         edtavSecrolename1_Visible = 0;
         AssignProp("", false, edtavSecrolename1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERROLEACTIVE") == 0 )
         {
            chkavSecuserroleactive1.Visible = 1;
            AssignProp("", false, chkavSecuserroleactive1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECROLENAME") == 0 )
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
         chkavSecuserroleactive2.Visible = 0;
         AssignProp("", false, chkavSecuserroleactive2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive2.Visible), 5, 0), true);
         edtavSecusername2_Visible = 0;
         AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
         edtavSecrolename2_Visible = 0;
         AssignProp("", false, edtavSecrolename2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERROLEACTIVE") == 0 )
         {
            chkavSecuserroleactive2.Visible = 1;
            AssignProp("", false, chkavSecuserroleactive2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECROLENAME") == 0 )
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
         chkavSecuserroleactive3.Visible = 0;
         AssignProp("", false, chkavSecuserroleactive3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive3.Visible), 5, 0), true);
         edtavSecusername3_Visible = 0;
         AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
         edtavSecrolename3_Visible = 0;
         AssignProp("", false, edtavSecrolename3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecrolename3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERROLEACTIVE") == 0 )
         {
            chkavSecuserroleactive3.Visible = 1;
            AssignProp("", false, chkavSecuserroleactive3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavSecuserroleactive3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECROLENAME") == 0 )
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
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "SECUSERROLEACTIVE";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV55SecUserRoleActive2 = false;
         AssignAttri("", false, "AV55SecUserRoleActive2", AV55SecUserRoleActive2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "SECUSERROLEACTIVE";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV56SecUserRoleActive3 = false;
         AssignAttri("", false, "AV56SecUserRoleActive3", AV56SecUserRoleActive3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpPerfilUsuarioFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFSecUserName = "";
         AssignAttri("", false, "AV38TFSecUserName", AV38TFSecUserName);
         AV39TFSecUserName_Sel = "";
         AssignAttri("", false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
         AV42TFSecRoleDescription = "";
         AssignAttri("", false, "AV42TFSecRoleDescription", AV42TFSecRoleDescription);
         AV43TFSecRoleDescription_Sel = "";
         AssignAttri("", false, "AV43TFSecRoleDescription_Sel", AV43TFSecRoleDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "SECUSERROLEACTIVE";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV54SecUserRoleActive1 = false;
         AssignAttri("", false, "AV54SecUserRoleActive1", AV54SecUserRoleActive1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV57Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV57Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV57Pgmname+"GridState"), null, "", "");
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
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV81GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV38TFSecUserName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFSecUserName", AV38TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV39TFSecUserName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV42TFSecRoleDescription = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSecRoleDescription", AV42TFSecRoleDescription);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV43TFSecRoleDescription_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFSecRoleDescription_Sel", AV43TFSecRoleDescription_Sel);
            }
            AV81GXV1 = (int)(AV81GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecRoleDescription_Sel)),  AV43TFSecRoleDescription_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  AV38TFSecUserName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecRoleDescription)),  AV42TFSecRoleDescription, out  GXt_char2) ;
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
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERROLEACTIVE") == 0 )
            {
               AV54SecUserRoleActive1 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
               AssignAttri("", false, "AV54SecUserRoleActive1", AV54SecUserRoleActive1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18SecUserName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18SecUserName1", AV18SecUserName1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19SecRoleName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19SecRoleName1", AV19SecRoleName1);
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
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERROLEACTIVE") == 0 )
               {
                  AV55SecUserRoleActive2 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                  AssignAttri("", false, "AV55SecUserRoleActive2", AV55SecUserRoleActive2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23SecUserName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV23SecUserName2", AV23SecUserName2);
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24SecRoleName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24SecRoleName2", AV24SecRoleName2);
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
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERROLEACTIVE") == 0 )
                  {
                     AV56SecUserRoleActive3 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                     AssignAttri("", false, "AV56SecUserRoleActive3", AV56SecUserRoleActive3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28SecUserName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28SecUserName3", AV28SecUserName3);
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29SecRoleName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29SecRoleName3", AV29SecRoleName3);
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
         AV10GridState.FromXml(AV34Session.Get(AV57Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSERNAME",  "Usuário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  0,  AV38TFSecUserName,  AV38TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel,  AV39TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECROLEDESCRIPTION",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecRoleDescription)),  0,  AV42TFSecRoleDescription,  AV42TFSecRoleDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSecRoleDescription_Sel)),  AV43TFSecRoleDescription_Sel,  AV43TFSecRoleDescription_Sel) ;
         if ( ! (0==AV50SecRoleId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SECROLEID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV50SecRoleId), 4, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53SecRoleName)) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SECROLENAME";
            AV11GridStateFilterValue.gxTpr_Value = AV53SecRoleName;
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
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV57Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERROLEACTIVE") == 0 ) && ! (false==AV54SecUserRoleActive1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Active",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV54SecUserRoleActive1)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV17DynamicFiltersOperator1,  AV18SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18SecUserName1, "Contém"+" "+AV18SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SecRoleName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Name",  AV17DynamicFiltersOperator1,  AV19SecRoleName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19SecRoleName1, "Contém"+" "+AV19SecRoleName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERROLEACTIVE") == 0 ) && ! (false==AV55SecUserRoleActive2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Active",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV55SecUserRoleActive2)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV22DynamicFiltersOperator2,  AV23SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV23SecUserName2, "Contém"+" "+AV23SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecRoleName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Name",  AV22DynamicFiltersOperator2,  AV24SecRoleName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24SecRoleName2, "Contém"+" "+AV24SecRoleName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERROLEACTIVE") == 0 ) && ! (false==AV56SecUserRoleActive3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Active",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV56SecUserRoleActive3)),  "",  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV27DynamicFiltersOperator3,  AV28SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28SecUserName3, "Contém"+" "+AV28SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECROLENAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecRoleName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Role Name",  AV27DynamicFiltersOperator3,  AV29SecRoleName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29SecRoleName3, "Contém"+" "+AV29SecRoleName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV57Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecUserRole";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SecRoleId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV50SecRoleId), 4, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void E277R2( )
      {
         /* Deletar_Click Routine */
         returnInSub = false;
         AV52SecUserRole.Load(A133SecUserId, A131SecRoleId);
         AV52SecUserRole.Delete();
         if ( AV52SecUserRole.Success() )
         {
            context.CommitDataStores("wpperfilusuario",pr_default);
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Sucesso!",  "Usuário removido com sucesso!",  "success",  "",  "true",  ""));
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV54SecUserRoleActive1, AV18SecUserName1, AV19SecRoleName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV55SecUserRoleActive2, AV23SecUserName2, AV24SecRoleName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV56SecUserRoleActive3, AV28SecUserName3, AV29SecRoleName3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV57Pgmname, AV50SecRoleId, AV38TFSecUserName, AV39TFSecUserName_Sel, AV42TFSecRoleDescription, AV43TFSecRoleDescription_Sel, AV53SecRoleName, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Atenção!",  StringUtil.Trim( ((GeneXus.Utils.SdtMessages_Message)AV52SecUserRole.GetMessages().Item(1)).gxTpr_Description),  "error",  "",  "true",  ""));
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void wb_table3_102_7R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserroleactive3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecuserroleactive3_Internalname, "Sec User Role Active3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecuserroleactive3_Internalname, StringUtil.BoolToStr( AV56SecUserRoleActive3), "", "Sec User Role Active3", chkavSecuserroleactive3.Visible, chkavSecuserroleactive3.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV28SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV28SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename3_Internalname, "Sec Role Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename3_Internalname, AV29SecRoleName3, StringUtil.RTrim( context.localUtil.Format( AV29SecRoleName3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename3_Visible, edtavSecrolename3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPerfilUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_102_7R2e( true) ;
         }
         else
         {
            wb_table3_102_7R2e( false) ;
         }
      }

      protected void wb_table2_74_7R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserroleactive2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecuserroleactive2_Internalname, "Sec User Role Active2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecuserroleactive2_Internalname, StringUtil.BoolToStr( AV55SecUserRoleActive2), "", "Sec User Role Active2", chkavSecuserroleactive2.Visible, chkavSecuserroleactive2.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(81, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,81);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV23SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV23SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename2_Internalname, "Sec Role Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename2_Internalname, AV24SecRoleName2, StringUtil.RTrim( context.localUtil.Format( AV24SecRoleName2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename2_Visible, edtavSecrolename2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPerfilUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPerfilUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_74_7R2e( true) ;
         }
         else
         {
            wb_table2_74_7R2e( false) ;
         }
      }

      protected void wb_table1_46_7R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_WpPerfilUsuario.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserroleactive1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavSecuserroleactive1_Internalname, "Sec User Role Active1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSecuserroleactive1_Internalname, StringUtil.BoolToStr( AV54SecUserRoleActive1), "", "Sec User Role Active1", chkavSecuserroleactive1.Visible, chkavSecuserroleactive1.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV18SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV18SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secrolename1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecrolename1_Internalname, "Sec Role Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecrolename1_Internalname, AV19SecRoleName1, StringUtil.RTrim( context.localUtil.Format( AV19SecRoleName1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecrolename1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecrolename1_Visible, edtavSecrolename1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpPerfilUsuario.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPerfilUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpPerfilUsuario.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_46_7R2e( true) ;
         }
         else
         {
            wb_table1_46_7R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV50SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV50SecRoleId", StringUtil.LTrimStr( (decimal)(AV50SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV50SecRoleId), "ZZZ9"), context));
         AV53SecRoleName = (string)getParm(obj,1);
         AssignAttri("", false, "AV53SecRoleName", AV53SecRoleName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53SecRoleName, "")), context));
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
         PA7R2( ) ;
         WS7R2( ) ;
         WE7R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019271226", true, true);
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
         context.AddJavascriptSource("wpperfilusuario.js", "?202561019271227", false, true);
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

      protected void SubsflControlProps_1262( )
      {
         edtavDeletar_Internalname = "vDELETAR_"+sGXsfl_126_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_126_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_126_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_126_idx;
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION_"+sGXsfl_126_idx;
      }

      protected void SubsflControlProps_fel_1262( )
      {
         edtavDeletar_Internalname = "vDELETAR_"+sGXsfl_126_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_126_fel_idx;
         edtSecRoleId_Internalname = "SECROLEID_"+sGXsfl_126_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_126_fel_idx;
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION_"+sGXsfl_126_fel_idx;
      }

      protected void sendrow_1262( )
      {
         sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
         SubsflControlProps_1262( ) ;
         WB7R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_126_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_126_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_126_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_126_idx + "',126)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDeletar_Internalname,StringUtil.RTrim( AV51Deletar),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"","'"+""+"'"+",false,"+"'"+"EVDELETAR.CLICK."+sGXsfl_126_idx+"'",(string)"",(string)"",(string)"Remover usuário do perfil",(string)"",(string)edtavDeletar_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDeletar_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecRoleId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecRoleDescription_Internalname,(string)A139SecRoleDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecRoleDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)126,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes7R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_126_idx = ((subGrid_Islastpage==1)&&(nGXsfl_126_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         /* End function sendrow_1262 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SECUSERROLEACTIVE", "Role Active", 0);
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector1.addItem("SECROLENAME", "Role Name", 0);
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
         chkavSecuserroleactive1.Name = "vSECUSERROLEACTIVE1";
         chkavSecuserroleactive1.WebTags = "";
         chkavSecuserroleactive1.Caption = "Sec User Role Active1";
         AssignProp("", false, chkavSecuserroleactive1_Internalname, "TitleCaption", chkavSecuserroleactive1.Caption, true);
         chkavSecuserroleactive1.CheckedValue = "false";
         AV54SecUserRoleActive1 = StringUtil.StrToBool( StringUtil.BoolToStr( AV54SecUserRoleActive1));
         AssignAttri("", false, "AV54SecUserRoleActive1", AV54SecUserRoleActive1);
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECUSERROLEACTIVE", "Role Active", 0);
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector2.addItem("SECROLENAME", "Role Name", 0);
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
         chkavSecuserroleactive2.Name = "vSECUSERROLEACTIVE2";
         chkavSecuserroleactive2.WebTags = "";
         chkavSecuserroleactive2.Caption = "Sec User Role Active2";
         AssignProp("", false, chkavSecuserroleactive2_Internalname, "TitleCaption", chkavSecuserroleactive2.Caption, true);
         chkavSecuserroleactive2.CheckedValue = "false";
         AV55SecUserRoleActive2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV55SecUserRoleActive2));
         AssignAttri("", false, "AV55SecUserRoleActive2", AV55SecUserRoleActive2);
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECUSERROLEACTIVE", "Role Active", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usuário", 0);
         cmbavDynamicfiltersselector3.addItem("SECROLENAME", "Role Name", 0);
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
         chkavSecuserroleactive3.Name = "vSECUSERROLEACTIVE3";
         chkavSecuserroleactive3.WebTags = "";
         chkavSecuserroleactive3.Caption = "Sec User Role Active3";
         AssignProp("", false, chkavSecuserroleactive3_Internalname, "TitleCaption", chkavSecuserroleactive3.Caption, true);
         chkavSecuserroleactive3.CheckedValue = "false";
         AV56SecUserRoleActive3 = StringUtil.StrToBool( StringUtil.BoolToStr( AV56SecUserRoleActive3));
         AssignAttri("", false, "AV56SecUserRoleActive3", AV56SecUserRoleActive3);
         /* End function init_web_controls */
      }

      protected void StartGridControl126( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"126\">") ;
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
            context.SendWebValue( "Usuário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Role Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Usuário") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV51Deletar)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDeletar_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A141SecUserName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
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
         lblLblrolename_Internalname = "LBLROLENAME";
         bttBtninserir_Internalname = "BTNINSERIR";
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
         chkavSecuserroleactive1_Internalname = "vSECUSERROLEACTIVE1";
         cellFilter_secuserroleactive1_cell_Internalname = "FILTER_SECUSERROLEACTIVE1_CELL";
         edtavSecusername1_Internalname = "vSECUSERNAME1";
         cellFilter_secusername1_cell_Internalname = "FILTER_SECUSERNAME1_CELL";
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
         chkavSecuserroleactive2_Internalname = "vSECUSERROLEACTIVE2";
         cellFilter_secuserroleactive2_cell_Internalname = "FILTER_SECUSERROLEACTIVE2_CELL";
         edtavSecusername2_Internalname = "vSECUSERNAME2";
         cellFilter_secusername2_cell_Internalname = "FILTER_SECUSERNAME2_CELL";
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
         chkavSecuserroleactive3_Internalname = "vSECUSERROLEACTIVE3";
         cellFilter_secuserroleactive3_cell_Internalname = "FILTER_SECUSERROLEACTIVE3_CELL";
         edtavSecusername3_Internalname = "vSECUSERNAME3";
         cellFilter_secusername3_cell_Internalname = "FILTER_SECUSERNAME3_CELL";
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
         edtavDeletar_Internalname = "vDELETAR";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecRoleId_Internalname = "SECROLEID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION";
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
         chkavSecuserroleactive3.Caption = "Sec User Role Active3";
         chkavSecuserroleactive2.Caption = "Sec User Role Active2";
         chkavSecuserroleactive1.Caption = "Sec User Role Active1";
         edtSecRoleDescription_Jsonclick = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtSecRoleId_Jsonclick = "";
         edtSecUserId_Jsonclick = "";
         edtavDeletar_Jsonclick = "";
         edtavDeletar_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecrolename1_Jsonclick = "";
         edtavSecrolename1_Enabled = 1;
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
         chkavSecuserroleactive1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecrolename2_Jsonclick = "";
         edtavSecrolename2_Enabled = 1;
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
         chkavSecuserroleactive2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecrolename3_Jsonclick = "";
         edtavSecrolename3_Enabled = 1;
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
         chkavSecuserroleactive3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecrolename3_Visible = 1;
         edtavSecusername3_Visible = 1;
         chkavSecuserroleactive3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecrolename2_Visible = 1;
         edtavSecusername2_Visible = 1;
         chkavSecuserroleactive2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecrolename1_Visible = 1;
         edtavSecusername1_Visible = 1;
         chkavSecuserroleactive1.Visible = 1;
         edtSecRoleDescription_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecRoleId_Enabled = 0;
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
         lblLblrolename_Caption = "<h3>Nome do perfil</h3>";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WpPerfilUsuarioGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3";
         Ddo_grid_Columnids = "3:SecUserName|4:SecRoleDescription";
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
         Form.Caption = " Sec User Role";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E127R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E137R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E147R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E267R2","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV51Deletar","fld":"vDELETAR","type":"char"},{"av":"edtSecUserName_Link","ctrl":"SECUSERNAME","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E197R2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E157R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"chkavSecuserroleactive2.Visible","ctrl":"vSECUSERROLEACTIVE2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"chkavSecuserroleactive3.Visible","ctrl":"vSECUSERROLEACTIVE3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"chkavSecuserroleactive1.Visible","ctrl":"vSECUSERROLEACTIVE1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E207R2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"chkavSecuserroleactive1.Visible","ctrl":"vSECUSERROLEACTIVE1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E217R2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E167R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"chkavSecuserroleactive2.Visible","ctrl":"vSECUSERROLEACTIVE2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"chkavSecuserroleactive3.Visible","ctrl":"vSECUSERROLEACTIVE3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"chkavSecuserroleactive1.Visible","ctrl":"vSECUSERROLEACTIVE1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E227R2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"chkavSecuserroleactive2.Visible","ctrl":"vSECUSERROLEACTIVE2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E177R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"chkavSecuserroleactive2.Visible","ctrl":"vSECUSERROLEACTIVE2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"chkavSecuserroleactive3.Visible","ctrl":"vSECUSERROLEACTIVE3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"chkavSecuserroleactive1.Visible","ctrl":"vSECUSERROLEACTIVE1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E237R2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"chkavSecuserroleactive3.Visible","ctrl":"vSECUSERROLEACTIVE3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E117R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"chkavSecuserroleactive1.Visible","ctrl":"vSECUSERROLEACTIVE1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecrolename1_Visible","ctrl":"vSECROLENAME1","prop":"Visible"},{"av":"chkavSecuserroleactive2.Visible","ctrl":"vSECUSERROLEACTIVE2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecrolename2_Visible","ctrl":"vSECROLENAME2","prop":"Visible"},{"av":"chkavSecuserroleactive3.Visible","ctrl":"vSECUSERROLEACTIVE3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecrolename3_Visible","ctrl":"vSECROLENAME3","prop":"Visible"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERIR'","""{"handler":"E187R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'DOINSERIR'",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VDELETAR.CLICK","""{"handler":"E277R2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserRoleActive1","fld":"vSECUSERROLEACTIVE1","type":"boolean"},{"av":"AV18SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"AV19SecRoleName1","fld":"vSECROLENAME1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV55SecUserRoleActive2","fld":"vSECUSERROLEACTIVE2","type":"boolean"},{"av":"AV23SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV24SecRoleName2","fld":"vSECROLENAME2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserRoleActive3","fld":"vSECUSERROLEACTIVE3","type":"boolean"},{"av":"AV28SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV29SecRoleName3","fld":"vSECROLENAME3","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV57Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV50SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV42TFSecRoleDescription","fld":"vTFSECROLEDESCRIPTION","type":"svchar"},{"av":"AV43TFSecRoleDescription_Sel","fld":"vTFSECROLEDESCRIPTION_SEL","type":"svchar"},{"av":"AV53SecRoleName","fld":"vSECROLENAME","hsh":true,"type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VDELETAR.CLICK",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV46GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV47GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV48GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[]}""");
         setEventMetadata("VALID_SECROLEID","""{"handler":"Valid_Secroleid","iparms":[]}""");
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
         wcpOAV53SecRoleName = "";
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
         AV18SecUserName1 = "";
         AV19SecRoleName1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23SecUserName2 = "";
         AV24SecRoleName2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SecUserName3 = "";
         AV29SecRoleName3 = "";
         AV57Pgmname = "";
         AV38TFSecUserName = "";
         AV39TFSecUserName_Sel = "";
         AV42TFSecRoleDescription = "";
         AV43TFSecRoleDescription_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV48GridAppliedFilters = "";
         AV44DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblrolename_Jsonclick = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninserir_Jsonclick = "";
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
         AV51Deletar = "";
         A141SecUserName = "";
         A139SecRoleDescription = "";
         GXDecQS = "";
         lV59Wpperfilusuariods_2_filterfulltext = "";
         lV63Wpperfilusuariods_6_secusername1 = "";
         lV64Wpperfilusuariods_7_secrolename1 = "";
         lV69Wpperfilusuariods_12_secusername2 = "";
         lV70Wpperfilusuariods_13_secrolename2 = "";
         lV75Wpperfilusuariods_18_secusername3 = "";
         lV76Wpperfilusuariods_19_secrolename3 = "";
         lV77Wpperfilusuariods_20_tfsecusername = "";
         lV79Wpperfilusuariods_22_tfsecroledescription = "";
         AV59Wpperfilusuariods_2_filterfulltext = "";
         AV60Wpperfilusuariods_3_dynamicfiltersselector1 = "";
         AV63Wpperfilusuariods_6_secusername1 = "";
         AV64Wpperfilusuariods_7_secrolename1 = "";
         AV66Wpperfilusuariods_9_dynamicfiltersselector2 = "";
         AV69Wpperfilusuariods_12_secusername2 = "";
         AV70Wpperfilusuariods_13_secrolename2 = "";
         AV72Wpperfilusuariods_15_dynamicfiltersselector3 = "";
         AV75Wpperfilusuariods_18_secusername3 = "";
         AV76Wpperfilusuariods_19_secrolename3 = "";
         AV78Wpperfilusuariods_21_tfsecusername_sel = "";
         AV77Wpperfilusuariods_20_tfsecusername = "";
         AV80Wpperfilusuariods_23_tfsecroledescription_sel = "";
         AV79Wpperfilusuariods_22_tfsecroledescription = "";
         A140SecRoleName = "";
         H007R2_A140SecRoleName = new string[] {""} ;
         H007R2_A647SecUserRoleActive = new bool[] {false} ;
         H007R2_A139SecRoleDescription = new string[] {""} ;
         H007R2_A141SecUserName = new string[] {""} ;
         H007R2_n141SecUserName = new bool[] {false} ;
         H007R2_A131SecRoleId = new short[1] ;
         H007R2_A133SecUserId = new short[1] ;
         H007R3_AGRID_nRecordCount = new long[1] ;
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
         GXt_char4 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV52SecUserRole = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpperfilusuario__default(),
            new Object[][] {
                new Object[] {
               H007R2_A140SecRoleName, H007R2_A647SecUserRoleActive, H007R2_A139SecRoleDescription, H007R2_A141SecUserName, H007R2_n141SecUserName, H007R2_A131SecRoleId, H007R2_A133SecUserId
               }
               , new Object[] {
               H007R3_AGRID_nRecordCount
               }
            }
         );
         AV57Pgmname = "WpPerfilUsuario";
         /* GeneXus formulas. */
         AV57Pgmname = "WpPerfilUsuario";
         edtavDeletar_Enabled = 0;
      }

      private short AV50SecRoleId ;
      private short wcpOAV50SecRoleId ;
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
      private short A133SecUserId ;
      private short A131SecRoleId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV61Wpperfilusuariods_4_dynamicfiltersoperator1 ;
      private short AV67Wpperfilusuariods_10_dynamicfiltersoperator2 ;
      private short AV73Wpperfilusuariods_16_dynamicfiltersoperator3 ;
      private short AV58Wpperfilusuariods_1_secroleid ;
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
      private int nRC_GXsfl_126 ;
      private int nGXsfl_126_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDeletar_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecUserId_Enabled ;
      private int edtSecRoleId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecRoleDescription_Enabled ;
      private int AV45PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSecusername1_Visible ;
      private int edtavSecrolename1_Visible ;
      private int edtavSecusername2_Visible ;
      private int edtavSecrolename2_Visible ;
      private int edtavSecusername3_Visible ;
      private int edtavSecrolename3_Visible ;
      private int AV81GXV1 ;
      private int edtavSecusername3_Enabled ;
      private int edtavSecrolename3_Enabled ;
      private int edtavSecusername2_Enabled ;
      private int edtavSecrolename2_Enabled ;
      private int edtavSecusername1_Enabled ;
      private int edtavSecrolename1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV46GridCurrentPage ;
      private long AV47GridPageCount ;
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
      private string sGXsfl_126_idx="0001" ;
      private string AV57Pgmname ;
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
      private string lblLblrolename_Internalname ;
      private string lblLblrolename_Caption ;
      private string lblLblrolename_Jsonclick ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninserir_Internalname ;
      private string bttBtninserir_Jsonclick ;
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
      private string AV51Deletar ;
      private string edtavDeletar_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecRoleId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecRoleDescription_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string chkavSecuserroleactive1_Internalname ;
      private string edtavSecusername1_Internalname ;
      private string edtavSecrolename1_Internalname ;
      private string chkavSecuserroleactive2_Internalname ;
      private string edtavSecusername2_Internalname ;
      private string edtavSecrolename2_Internalname ;
      private string chkavSecuserroleactive3_Internalname ;
      private string edtavSecusername3_Internalname ;
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
      private string edtSecUserName_Link ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secuserroleactive3_cell_Internalname ;
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
      private string cellFilter_secrolename3_cell_Internalname ;
      private string edtavSecrolename3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secuserroleactive2_cell_Internalname ;
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
      private string cellFilter_secrolename2_cell_Internalname ;
      private string edtavSecrolename2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secuserroleactive1_cell_Internalname ;
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
      private string cellFilter_secrolename1_cell_Internalname ;
      private string edtavSecrolename1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_126_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDeletar_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecRoleId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecRoleDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV54SecUserRoleActive1 ;
      private bool AV55SecUserRoleActive2 ;
      private bool AV56SecUserRoleActive3 ;
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
      private bool n141SecUserName ;
      private bool bGXsfl_126_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV62Wpperfilusuariods_5_secuserroleactive1 ;
      private bool AV65Wpperfilusuariods_8_dynamicfiltersenabled2 ;
      private bool AV68Wpperfilusuariods_11_secuserroleactive2 ;
      private bool AV71Wpperfilusuariods_14_dynamicfiltersenabled3 ;
      private bool AV74Wpperfilusuariods_17_secuserroleactive3 ;
      private bool A647SecUserRoleActive ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV36ManageFiltersXml ;
      private string AV53SecRoleName ;
      private string wcpOAV53SecRoleName ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18SecUserName1 ;
      private string AV19SecRoleName1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23SecUserName2 ;
      private string AV24SecRoleName2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28SecUserName3 ;
      private string AV29SecRoleName3 ;
      private string AV38TFSecUserName ;
      private string AV39TFSecUserName_Sel ;
      private string AV42TFSecRoleDescription ;
      private string AV43TFSecRoleDescription_Sel ;
      private string AV48GridAppliedFilters ;
      private string A141SecUserName ;
      private string A139SecRoleDescription ;
      private string lV59Wpperfilusuariods_2_filterfulltext ;
      private string lV63Wpperfilusuariods_6_secusername1 ;
      private string lV64Wpperfilusuariods_7_secrolename1 ;
      private string lV69Wpperfilusuariods_12_secusername2 ;
      private string lV70Wpperfilusuariods_13_secrolename2 ;
      private string lV75Wpperfilusuariods_18_secusername3 ;
      private string lV76Wpperfilusuariods_19_secrolename3 ;
      private string lV77Wpperfilusuariods_20_tfsecusername ;
      private string lV79Wpperfilusuariods_22_tfsecroledescription ;
      private string AV59Wpperfilusuariods_2_filterfulltext ;
      private string AV60Wpperfilusuariods_3_dynamicfiltersselector1 ;
      private string AV63Wpperfilusuariods_6_secusername1 ;
      private string AV64Wpperfilusuariods_7_secrolename1 ;
      private string AV66Wpperfilusuariods_9_dynamicfiltersselector2 ;
      private string AV69Wpperfilusuariods_12_secusername2 ;
      private string AV70Wpperfilusuariods_13_secrolename2 ;
      private string AV72Wpperfilusuariods_15_dynamicfiltersselector3 ;
      private string AV75Wpperfilusuariods_18_secusername3 ;
      private string AV76Wpperfilusuariods_19_secrolename3 ;
      private string AV78Wpperfilusuariods_21_tfsecusername_sel ;
      private string AV77Wpperfilusuariods_20_tfsecusername ;
      private string AV80Wpperfilusuariods_23_tfsecroledescription_sel ;
      private string AV79Wpperfilusuariods_22_tfsecroledescription ;
      private string A140SecRoleName ;
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
      private GXCheckbox chkavSecuserroleactive1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCheckbox chkavSecuserroleactive2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkavSecuserroleactive3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV44DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H007R2_A140SecRoleName ;
      private bool[] H007R2_A647SecUserRoleActive ;
      private string[] H007R2_A139SecRoleDescription ;
      private string[] H007R2_A141SecUserName ;
      private bool[] H007R2_n141SecUserName ;
      private short[] H007R2_A131SecRoleId ;
      private short[] H007R2_A133SecUserId ;
      private long[] H007R3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole AV52SecUserRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wpperfilusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H007R2( IGxContext context ,
                                             string AV59Wpperfilusuariods_2_filterfulltext ,
                                             string AV60Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                             bool AV62Wpperfilusuariods_5_secuserroleactive1 ,
                                             short AV61Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                             string AV63Wpperfilusuariods_6_secusername1 ,
                                             string AV64Wpperfilusuariods_7_secrolename1 ,
                                             bool AV65Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                             string AV66Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                             bool AV68Wpperfilusuariods_11_secuserroleactive2 ,
                                             short AV67Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                             string AV69Wpperfilusuariods_12_secusername2 ,
                                             string AV70Wpperfilusuariods_13_secrolename2 ,
                                             bool AV71Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                             string AV72Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                             bool AV74Wpperfilusuariods_17_secuserroleactive3 ,
                                             short AV73Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                             string AV75Wpperfilusuariods_18_secusername3 ,
                                             string AV76Wpperfilusuariods_19_secrolename3 ,
                                             string AV78Wpperfilusuariods_21_tfsecusername_sel ,
                                             string AV77Wpperfilusuariods_20_tfsecusername ,
                                             string AV80Wpperfilusuariods_23_tfsecroledescription_sel ,
                                             string AV79Wpperfilusuariods_22_tfsecroledescription ,
                                             string A141SecUserName ,
                                             string A139SecRoleDescription ,
                                             bool A647SecUserRoleActive ,
                                             string A140SecRoleName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV58Wpperfilusuariods_1_secroleid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[25];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.SecRoleName, T1.SecUserRoleActive, T2.SecRoleDescription, T3.SecUserName, T1.SecRoleId, T1.SecUserId";
         sFromString = " FROM ((SecUserRole T1 INNER JOIN SecRole T2 ON T2.SecRoleId = T1.SecRoleId) INNER JOIN SecUser T3 ON T3.SecUserId = T1.SecUserId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV58Wpperfilusuariods_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.SecUserName like '%' || :lV59Wpperfilusuariods_2_filterfulltext) or ( T2.SecRoleDescription like '%' || :lV59Wpperfilusuariods_2_filterfulltext))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV62Wpperfilusuariods_5_secuserroleactive1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV62Wpperfilusuariods_5_secuserroleactive1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV63Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV63Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV64Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV64Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV68Wpperfilusuariods_11_secuserroleactive2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV68Wpperfilusuariods_11_secuserroleactive2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV69Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV69Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV70Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV70Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV74Wpperfilusuariods_17_secuserroleactive3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV74Wpperfilusuariods_17_secuserroleactive3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV75Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV75Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like :lV76Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleName like '%' || :lV76Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_21_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_20_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV77Wpperfilusuariods_20_tfsecusername)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_21_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV78Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV78Wpperfilusuariods_21_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_23_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpperfilusuariods_22_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription like :lV79Wpperfilusuariods_22_tfsecroledescription)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_23_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV80Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecRoleDescription = ( :AV80Wpperfilusuariods_23_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.SecRoleDescription))=0))");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.SecUserRoleActive, T1.SecUserId, T1.SecRoleId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T3.SecUserName, T1.SecUserId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T3.SecUserName DESC, T1.SecUserId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecRoleId, T2.SecRoleDescription, T1.SecUserId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecRoleId DESC, T2.SecRoleDescription DESC, T1.SecUserId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecUserId, T1.SecRoleId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H007R3( IGxContext context ,
                                             string AV59Wpperfilusuariods_2_filterfulltext ,
                                             string AV60Wpperfilusuariods_3_dynamicfiltersselector1 ,
                                             bool AV62Wpperfilusuariods_5_secuserroleactive1 ,
                                             short AV61Wpperfilusuariods_4_dynamicfiltersoperator1 ,
                                             string AV63Wpperfilusuariods_6_secusername1 ,
                                             string AV64Wpperfilusuariods_7_secrolename1 ,
                                             bool AV65Wpperfilusuariods_8_dynamicfiltersenabled2 ,
                                             string AV66Wpperfilusuariods_9_dynamicfiltersselector2 ,
                                             bool AV68Wpperfilusuariods_11_secuserroleactive2 ,
                                             short AV67Wpperfilusuariods_10_dynamicfiltersoperator2 ,
                                             string AV69Wpperfilusuariods_12_secusername2 ,
                                             string AV70Wpperfilusuariods_13_secrolename2 ,
                                             bool AV71Wpperfilusuariods_14_dynamicfiltersenabled3 ,
                                             string AV72Wpperfilusuariods_15_dynamicfiltersselector3 ,
                                             bool AV74Wpperfilusuariods_17_secuserroleactive3 ,
                                             short AV73Wpperfilusuariods_16_dynamicfiltersoperator3 ,
                                             string AV75Wpperfilusuariods_18_secusername3 ,
                                             string AV76Wpperfilusuariods_19_secrolename3 ,
                                             string AV78Wpperfilusuariods_21_tfsecusername_sel ,
                                             string AV77Wpperfilusuariods_20_tfsecusername ,
                                             string AV80Wpperfilusuariods_23_tfsecroledescription_sel ,
                                             string AV79Wpperfilusuariods_22_tfsecroledescription ,
                                             string A141SecUserName ,
                                             string A139SecRoleDescription ,
                                             bool A647SecUserRoleActive ,
                                             string A140SecRoleName ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc ,
                                             short A131SecRoleId ,
                                             short AV58Wpperfilusuariods_1_secroleid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[22];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((SecUserRole T1 INNER JOIN SecRole T3 ON T3.SecRoleId = T1.SecRoleId) INNER JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         AddWhere(sWhereString, "(T1.SecRoleId = :AV58Wpperfilusuariods_1_secroleid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wpperfilusuariods_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV59Wpperfilusuariods_2_filterfulltext) or ( T3.SecRoleDescription like '%' || :lV59Wpperfilusuariods_2_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV62Wpperfilusuariods_5_secuserroleactive1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV62Wpperfilusuariods_5_secuserroleactive1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV63Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wpperfilusuariods_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV63Wpperfilusuariods_6_secusername1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV64Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Wpperfilusuariods_3_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV61Wpperfilusuariods_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wpperfilusuariods_7_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV64Wpperfilusuariods_7_secrolename1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV68Wpperfilusuariods_11_secuserroleactive2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV68Wpperfilusuariods_11_secuserroleactive2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV69Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wpperfilusuariods_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV69Wpperfilusuariods_12_secusername2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV70Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV65Wpperfilusuariods_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wpperfilusuariods_9_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV67Wpperfilusuariods_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wpperfilusuariods_13_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV70Wpperfilusuariods_13_secrolename2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERROLEACTIVE") == 0 ) && ( ! (false==AV74Wpperfilusuariods_17_secuserroleactive3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserRoleActive = :AV74Wpperfilusuariods_17_secuserroleactive3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV75Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wpperfilusuariods_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV75Wpperfilusuariods_18_secusername3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like :lV76Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV71Wpperfilusuariods_14_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Wpperfilusuariods_15_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV73Wpperfilusuariods_16_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wpperfilusuariods_19_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleName like '%' || :lV76Wpperfilusuariods_19_secrolename3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_21_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wpperfilusuariods_20_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV77Wpperfilusuariods_20_tfsecusername)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wpperfilusuariods_21_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV78Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV78Wpperfilusuariods_21_tfsecusername_sel))");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wpperfilusuariods_21_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_23_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wpperfilusuariods_22_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleDescription like :lV79Wpperfilusuariods_22_tfsecroledescription)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wpperfilusuariods_23_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV80Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecRoleDescription = ( :AV80Wpperfilusuariods_23_tfsecroledescription_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wpperfilusuariods_23_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.SecRoleDescription))=0))");
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
                     return conditional_H007R2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] );
               case 1 :
                     return conditional_H007R3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (bool)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] );
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
          Object[] prmH007R2;
          prmH007R2 = new Object[] {
          new ParDef("AV58Wpperfilusuariods_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV59Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV62Wpperfilusuariods_5_secuserroleactive1",GXType.Boolean,4,0) ,
          new ParDef("lV63Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV63Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV64Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV64Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("AV68Wpperfilusuariods_11_secuserroleactive2",GXType.Boolean,4,0) ,
          new ParDef("lV69Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV70Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("AV74Wpperfilusuariods_17_secuserroleactive3",GXType.Boolean,4,0) ,
          new ParDef("lV75Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV76Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV76Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV77Wpperfilusuariods_20_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV78Wpperfilusuariods_21_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpperfilusuariods_22_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV80Wpperfilusuariods_23_tfsecroledescription_sel",GXType.VarChar,120,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH007R3;
          prmH007R3 = new Object[] {
          new ParDef("AV58Wpperfilusuariods_1_secroleid",GXType.Int16,4,0) ,
          new ParDef("lV59Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Wpperfilusuariods_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV62Wpperfilusuariods_5_secuserroleactive1",GXType.Boolean,4,0) ,
          new ParDef("lV63Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV63Wpperfilusuariods_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV64Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("lV64Wpperfilusuariods_7_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("AV68Wpperfilusuariods_11_secuserroleactive2",GXType.Boolean,4,0) ,
          new ParDef("lV69Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV69Wpperfilusuariods_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV70Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("lV70Wpperfilusuariods_13_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("AV74Wpperfilusuariods_17_secuserroleactive3",GXType.Boolean,4,0) ,
          new ParDef("lV75Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV75Wpperfilusuariods_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV76Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV76Wpperfilusuariods_19_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("lV77Wpperfilusuariods_20_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV78Wpperfilusuariods_21_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Wpperfilusuariods_22_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("AV80Wpperfilusuariods_23_tfsecroledescription_sel",GXType.VarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
