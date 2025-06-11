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
   public class reembolsoflowlogww : GXWebComponent
   {
      public reembolsoflowlogww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public reembolsoflowlogww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ReembolsoLogId )
      {
         this.AV23ReembolsoLogId = aP0_ReembolsoLogId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ReembolsoLogId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV23ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoLogId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV23ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV23ReembolsoLogId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV23ReembolsoLogId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ReembolsoLogId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ReembolsoLogId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV23ReembolsoLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoLogId"), "."), 18, MidpointRounding.ToEven));
         AV15TFLogWorkflowConvenioDesc = GetPar( "TFLogWorkflowConvenioDesc");
         AV16TFLogWorkflowConvenioDesc_Sel = GetPar( "TFLogWorkflowConvenioDesc_Sel");
         AV17TFReembolsoFlowLogDate = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDate"));
         AV18TFReembolsoFlowLogDate_To = context.localUtil.ParseDTimeParm( GetPar( "TFReembolsoFlowLogDate_To"));
         AV29Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA812( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV29Pgmname = "ReembolsoFlowLogWW";
               WS812( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( " Reembolso Flow Log") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "reembolsoflowlogww"+UrlEncode(StringUtil.LTrimStr(AV23ReembolsoLogId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsoflowlogww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV22DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE", context.localUtil.DToC( AV19DDO_ReembolsoFlowLogDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO", context.localUtil.DToC( AV20DDO_ReembolsoFlowLogDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV23ReembolsoLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV23ReembolsoLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vREEMBOLSOLOGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ReembolsoLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOGWORKFLOWCONVENIODESC", AV15TFLogWorkflowConvenioDesc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFLOGWORKFLOWCONVENIODESC_SEL", AV16TFLogWorkflowConvenioDesc_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATE", context.localUtil.TToC( AV17TFReembolsoFlowLogDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFREEMBOLSOFLOWLOGDATE_TO", context.localUtil.TToC( AV18TFReembolsoFlowLogDate_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
      }

      protected void RenderHtmlCloseForm812( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ReembolsoFlowLogWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Reembolso Flow Log" ;
      }

      protected void WB810( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "reembolsoflowlogww");
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
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV22DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_reembolsoflowlogdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'" + sGXsfl_9_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_reembolsoflowlogdateauxdatetext_Internalname, AV21DDO_ReembolsoFlowLogDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV21DDO_ReembolsoFlowLogDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoFlowLogWW.htm");
            /* User Defined Control */
            ucTfreembolsoflowlogdate_rangepicker.SetProperty("Start Date", AV19DDO_ReembolsoFlowLogDateAuxDate);
            ucTfreembolsoflowlogdate_rangepicker.SetProperty("End Date", AV20DDO_ReembolsoFlowLogDateAuxDateTo);
            ucTfreembolsoflowlogdate_rangepicker.Render(context, "wwp.daterangepicker", Tfreembolsoflowlogdate_rangepicker_Internalname, sPrefix+"TFREEMBOLSOFLOWLOGDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 9 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START812( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", " Reembolso Flow Log", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP810( ) ;
            }
         }
      }

      protected void WS812( )
      {
         START812( ) ;
         EVT812( ) ;
      }

      protected void EVT812( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP810( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP810( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E11812 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP810( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP810( ) ;
                              }
                              AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
                              AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
                              AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
                              AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
                              AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP810( ) ;
                              }
                              nGXsfl_9_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              A746ReembolsoFlowLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A750LogWorkflowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLogWorkflowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n750LogWorkflowConvenioId = false;
                              A752LogWorkflowConvenioDesc = cgiGet( edtLogWorkflowConvenioDesc_Internalname);
                              n752LogWorkflowConvenioDesc = false;
                              A747ReembolsoFlowLogDate = context.localUtil.CToT( cgiGet( edtReembolsoFlowLogDate_Internalname), 0);
                              n747ReembolsoFlowLogDate = false;
                              A744ReembolsoFlowLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoFlowLogUser_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n744ReembolsoFlowLogUser = false;
                              A745ReembolsoFlowLogUserNome = StringUtil.Upper( cgiGet( edtReembolsoFlowLogUserNome_Internalname));
                              n745ReembolsoFlowLogUserNome = false;
                              A748ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n748ReembolsoLogId = false;
                              A749ReembolsoWorkFlowConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoWorkFlowConvenioId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n749ReembolsoWorkFlowConvenioId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12812 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13812 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E14812 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP810( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE812( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm812( ) ;
            }
         }
      }

      protected void PA812( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reembolsoflowlogww")), "reembolsoflowlogww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reembolsoflowlogww")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "ReembolsoLogId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavDdo_reembolsoflowlogdateauxdatetext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV23ReembolsoLogId ,
                                       string AV15TFLogWorkflowConvenioDesc ,
                                       string AV16TFLogWorkflowConvenioDesc_Sel ,
                                       DateTime AV17TFReembolsoFlowLogDate ,
                                       DateTime AV18TFReembolsoFlowLogDate_To ,
                                       string AV29Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF812( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF812( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV29Pgmname = "ReembolsoFlowLogWW";
      }

      protected void RF812( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 9;
         /* Execute user event: Refresh */
         E13812 ();
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
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
            SubsflControlProps_92( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                                 AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                                 AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                                 AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                                 A752LogWorkflowConvenioDesc ,
                                                 A747ReembolsoFlowLogDate ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A748ReembolsoLogId ,
                                                 AV24Reembolsoflowlogwwds_1_reembolsologid } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc), "%", "");
            /* Using cursor H00812 */
            pr_default.execute(0, new Object[] {AV24Reembolsoflowlogwwds_1_reembolsologid, lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc, AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate, AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_9_idx = 1;
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A749ReembolsoWorkFlowConvenioId = H00812_A749ReembolsoWorkFlowConvenioId[0];
               n749ReembolsoWorkFlowConvenioId = H00812_n749ReembolsoWorkFlowConvenioId[0];
               A748ReembolsoLogId = H00812_A748ReembolsoLogId[0];
               n748ReembolsoLogId = H00812_n748ReembolsoLogId[0];
               A745ReembolsoFlowLogUserNome = H00812_A745ReembolsoFlowLogUserNome[0];
               n745ReembolsoFlowLogUserNome = H00812_n745ReembolsoFlowLogUserNome[0];
               A744ReembolsoFlowLogUser = H00812_A744ReembolsoFlowLogUser[0];
               n744ReembolsoFlowLogUser = H00812_n744ReembolsoFlowLogUser[0];
               A747ReembolsoFlowLogDate = H00812_A747ReembolsoFlowLogDate[0];
               n747ReembolsoFlowLogDate = H00812_n747ReembolsoFlowLogDate[0];
               A752LogWorkflowConvenioDesc = H00812_A752LogWorkflowConvenioDesc[0];
               n752LogWorkflowConvenioDesc = H00812_n752LogWorkflowConvenioDesc[0];
               A750LogWorkflowConvenioId = H00812_A750LogWorkflowConvenioId[0];
               n750LogWorkflowConvenioId = H00812_n750LogWorkflowConvenioId[0];
               A746ReembolsoFlowLogId = H00812_A746ReembolsoFlowLogId[0];
               A749ReembolsoWorkFlowConvenioId = H00812_A749ReembolsoWorkFlowConvenioId[0];
               n749ReembolsoWorkFlowConvenioId = H00812_n749ReembolsoWorkFlowConvenioId[0];
               A745ReembolsoFlowLogUserNome = H00812_A745ReembolsoFlowLogUserNome[0];
               n745ReembolsoFlowLogUserNome = H00812_n745ReembolsoFlowLogUserNome[0];
               A752LogWorkflowConvenioDesc = H00812_A752LogWorkflowConvenioDesc[0];
               n752LogWorkflowConvenioDesc = H00812_n752LogWorkflowConvenioDesc[0];
               /* Execute user event: Grid.Load */
               E14812 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 9;
            WB810( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes812( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV29Pgmname, "")), context));
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
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                              AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                              AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                              AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                              A752LogWorkflowConvenioDesc ,
                                              A747ReembolsoFlowLogDate ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A748ReembolsoLogId ,
                                              AV24Reembolsoflowlogwwds_1_reembolsologid } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = StringUtil.Concat( StringUtil.RTrim( AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc), "%", "");
         /* Using cursor H00813 */
         pr_default.execute(1, new Object[] {AV24Reembolsoflowlogwwds_1_reembolsologid, lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc, AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate, AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to});
         GRID_nRecordCount = H00813_AGRID_nRecordCount[0];
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
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV23ReembolsoLogId, AV15TFLogWorkflowConvenioDesc, AV16TFLogWorkflowConvenioDesc_Sel, AV17TFReembolsoFlowLogDate, AV18TFReembolsoFlowLogDate_To, AV29Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV29Pgmname = "ReembolsoFlowLogWW";
         edtReembolsoFlowLogId_Enabled = 0;
         edtLogWorkflowConvenioId_Enabled = 0;
         edtLogWorkflowConvenioDesc_Enabled = 0;
         edtReembolsoFlowLogDate_Enabled = 0;
         edtReembolsoFlowLogUser_Enabled = 0;
         edtReembolsoFlowLogUserNome_Enabled = 0;
         edtReembolsoLogId_Enabled = 0;
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP810( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12812 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV22DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_9"), ",", "."), 18, MidpointRounding.ToEven));
            AV19DDO_ReembolsoFlowLogDateAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV19DDO_ReembolsoFlowLogDateAuxDate", context.localUtil.Format(AV19DDO_ReembolsoFlowLogDateAuxDate, "99/99/99"));
            AV20DDO_ReembolsoFlowLogDateAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV20DDO_ReembolsoFlowLogDateAuxDateTo", context.localUtil.Format(AV20DDO_ReembolsoFlowLogDateAuxDateTo, "99/99/99"));
            wcpOAV23ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV23ReembolsoLogId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
            AV21DDO_ReembolsoFlowLogDateAuxDateText = cgiGet( edtavDdo_reembolsoflowlogdateauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV21DDO_ReembolsoFlowLogDateAuxDateText", AV21DDO_ReembolsoFlowLogDateAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
         E12812 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12812( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFREEMBOLSOFLOWLOGDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_reembolsoflowlogdateauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = true;
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV22DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV22DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13812( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24Reembolsoflowlogwwds_1_reembolsologid = AV23ReembolsoLogId;
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = AV15TFLogWorkflowConvenioDesc;
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = AV16TFLogWorkflowConvenioDesc_Sel;
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = AV17TFReembolsoFlowLogDate;
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = AV18TFReembolsoFlowLogDate_To;
      }

      protected void E11812( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LogWorkflowConvenioDesc") == 0 )
            {
               AV15TFLogWorkflowConvenioDesc = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV15TFLogWorkflowConvenioDesc", AV15TFLogWorkflowConvenioDesc);
               AV16TFLogWorkflowConvenioDesc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV16TFLogWorkflowConvenioDesc_Sel", AV16TFLogWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ReembolsoFlowLogDate") == 0 )
            {
               AV17TFReembolsoFlowLogDate = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV17TFReembolsoFlowLogDate", context.localUtil.TToC( AV17TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               AV18TFReembolsoFlowLogDate_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV18TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV18TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV18TFReembolsoFlowLogDate_To) )
               {
                  AV18TFReembolsoFlowLogDate_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV18TFReembolsoFlowLogDate_To)), (short)(DateTimeUtil.Month( AV18TFReembolsoFlowLogDate_To)), (short)(DateTimeUtil.Day( AV18TFReembolsoFlowLogDate_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV18TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV18TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E14812( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 9;
         }
         sendrow_92( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, GridRow);
         }
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV29Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV29Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV29Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30GXV1 = 1;
         while ( AV30GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV30GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC") == 0 )
            {
               AV15TFLogWorkflowConvenioDesc = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15TFLogWorkflowConvenioDesc", AV15TFLogWorkflowConvenioDesc);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFLOGWORKFLOWCONVENIODESC_SEL") == 0 )
            {
               AV16TFLogWorkflowConvenioDesc_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16TFLogWorkflowConvenioDesc_Sel", AV16TFLogWorkflowConvenioDesc_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFREEMBOLSOFLOWLOGDATE") == 0 )
            {
               AV17TFReembolsoFlowLogDate = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV17TFReembolsoFlowLogDate", context.localUtil.TToC( AV17TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " "));
               AV18TFReembolsoFlowLogDate_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV18TFReembolsoFlowLogDate_To", context.localUtil.TToC( AV18TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " "));
               AV19DDO_ReembolsoFlowLogDateAuxDate = DateTimeUtil.ResetTime(AV17TFReembolsoFlowLogDate);
               AssignAttri(sPrefix, false, "AV19DDO_ReembolsoFlowLogDateAuxDate", context.localUtil.Format(AV19DDO_ReembolsoFlowLogDateAuxDate, "99/99/99"));
               AV20DDO_ReembolsoFlowLogDateAuxDateTo = DateTimeUtil.ResetTime(AV18TFReembolsoFlowLogDate_To);
               AssignAttri(sPrefix, false, "AV20DDO_ReembolsoFlowLogDateAuxDateTo", context.localUtil.Format(AV20DDO_ReembolsoFlowLogDateAuxDateTo, "99/99/99"));
            }
            AV30GXV1 = (int)(AV30GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLogWorkflowConvenioDesc_Sel)),  AV16TFLogWorkflowConvenioDesc_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV15TFLogWorkflowConvenioDesc)),  AV15TFLogWorkflowConvenioDesc, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"|"+((DateTime.MinValue==AV17TFReembolsoFlowLogDate) ? "" : context.localUtil.DToC( AV19DDO_ReembolsoFlowLogDateAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((DateTime.MinValue==AV18TFReembolsoFlowLogDate_To) ? "" : context.localUtil.DToC( AV20DDO_ReembolsoFlowLogDateAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV29Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFLOGWORKFLOWCONVENIODESC",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15TFLogWorkflowConvenioDesc)),  0,  AV15TFLogWorkflowConvenioDesc,  AV15TFLogWorkflowConvenioDesc,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFLogWorkflowConvenioDesc_Sel)),  AV16TFLogWorkflowConvenioDesc_Sel,  AV16TFLogWorkflowConvenioDesc_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFREEMBOLSOFLOWLOGDATE",  "",  !((DateTime.MinValue==AV17TFReembolsoFlowLogDate)&&(DateTime.MinValue==AV18TFReembolsoFlowLogDate_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV17TFReembolsoFlowLogDate, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV17TFReembolsoFlowLogDate) ? "" : StringUtil.Trim( context.localUtil.Format( AV17TFReembolsoFlowLogDate, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV18TFReembolsoFlowLogDate_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV18TFReembolsoFlowLogDate_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV18TFReembolsoFlowLogDate_To, "99/99/99 99:99")))) ;
         if ( ! (0==AV23ReembolsoLogId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&REEMBOLSOLOGID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV23ReembolsoLogId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV29Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV29Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ReembolsoFlowLog";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "ReembolsoLogId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV23ReembolsoLogId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV23ReembolsoLogId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV23ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV23ReembolsoLogId), 9, 0));
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
         PA812( ) ;
         WS812( ) ;
         WE812( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV23ReembolsoLogId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA812( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "reembolsoflowlogww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA812( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV23ReembolsoLogId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV23ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV23ReembolsoLogId), 9, 0));
         }
         wcpOAV23ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV23ReembolsoLogId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV23ReembolsoLogId != wcpOAV23ReembolsoLogId ) ) )
         {
            setjustcreated();
         }
         wcpOAV23ReembolsoLogId = AV23ReembolsoLogId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV23ReembolsoLogId = cgiGet( sPrefix+"AV23ReembolsoLogId_CTRL");
         if ( StringUtil.Len( sCtrlAV23ReembolsoLogId) > 0 )
         {
            AV23ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV23ReembolsoLogId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV23ReembolsoLogId", StringUtil.LTrimStr( (decimal)(AV23ReembolsoLogId), 9, 0));
         }
         else
         {
            AV23ReembolsoLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV23ReembolsoLogId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA812( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS812( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS812( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV23ReembolsoLogId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ReembolsoLogId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV23ReembolsoLogId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV23ReembolsoLogId_CTRL", StringUtil.RTrim( sCtrlAV23ReembolsoLogId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE812( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019204389", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("reembolsoflowlogww.js", "?202561019204389", false, true);
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
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_92( )
      {
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID_"+sGXsfl_9_idx;
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID_"+sGXsfl_9_idx;
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC_"+sGXsfl_9_idx;
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE_"+sGXsfl_9_idx;
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER_"+sGXsfl_9_idx;
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME_"+sGXsfl_9_idx;
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID_"+sGXsfl_9_idx;
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID_"+sGXsfl_9_fel_idx;
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID_"+sGXsfl_9_fel_idx;
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC_"+sGXsfl_9_fel_idx;
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE_"+sGXsfl_9_fel_idx;
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER_"+sGXsfl_9_fel_idx;
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME_"+sGXsfl_9_fel_idx;
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID_"+sGXsfl_9_fel_idx;
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         WB810( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_9_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_9_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ReembolsoFlowLogId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A746ReembolsoFlowLogId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLogWorkflowConvenioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A750LogWorkflowConvenioId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLogWorkflowConvenioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLogWorkflowConvenioDesc_Internalname,(string)A752LogWorkflowConvenioDesc,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLogWorkflowConvenioDesc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogDate_Internalname,context.localUtil.TToC( A747ReembolsoFlowLogDate, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A747ReembolsoFlowLogDate, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogUser_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A744ReembolsoFlowLogUser), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogUser_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoFlowLogUserNome_Internalname,(string)A745ReembolsoFlowLogUserNome,StringUtil.RTrim( context.localUtil.Format( A745ReembolsoFlowLogUserNome, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoFlowLogUserNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A748ReembolsoLogId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtReembolsoWorkFlowConvenioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A749ReembolsoWorkFlowConvenioId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtReembolsoWorkFlowConvenioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes812( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_9_idx = ((subGrid_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Convenio Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Passo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data de início") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log User") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "User Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Convenio Id") ;
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
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A746ReembolsoFlowLogId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A750LogWorkflowConvenioId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A752LogWorkflowConvenioDesc));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A747ReembolsoFlowLogDate, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A744ReembolsoFlowLogUser), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A745ReembolsoFlowLogUserNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A748ReembolsoLogId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A749ReembolsoWorkFlowConvenioId), 9, 0, ".", ""))));
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
         edtReembolsoFlowLogId_Internalname = sPrefix+"REEMBOLSOFLOWLOGID";
         edtLogWorkflowConvenioId_Internalname = sPrefix+"LOGWORKFLOWCONVENIOID";
         edtLogWorkflowConvenioDesc_Internalname = sPrefix+"LOGWORKFLOWCONVENIODESC";
         edtReembolsoFlowLogDate_Internalname = sPrefix+"REEMBOLSOFLOWLOGDATE";
         edtReembolsoFlowLogUser_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSER";
         edtReembolsoFlowLogUserNome_Internalname = sPrefix+"REEMBOLSOFLOWLOGUSERNOME";
         edtReembolsoLogId_Internalname = sPrefix+"REEMBOLSOLOGID";
         edtReembolsoWorkFlowConvenioId_Internalname = sPrefix+"REEMBOLSOWORKFLOWCONVENIOID";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_reembolsoflowlogdateauxdatetext_Internalname = sPrefix+"vDDO_REEMBOLSOFLOWLOGDATEAUXDATETEXT";
         Tfreembolsoflowlogdate_rangepicker_Internalname = sPrefix+"TFREEMBOLSOFLOWLOGDATE_RANGEPICKER";
         divDdo_reembolsoflowlogdateauxdates_Internalname = sPrefix+"DDO_REEMBOLSOFLOWLOGDATEAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtReembolsoWorkFlowConvenioId_Jsonclick = "";
         edtReembolsoLogId_Jsonclick = "";
         edtReembolsoFlowLogUserNome_Jsonclick = "";
         edtReembolsoFlowLogUser_Jsonclick = "";
         edtReembolsoFlowLogDate_Jsonclick = "";
         edtLogWorkflowConvenioDesc_Jsonclick = "";
         edtLogWorkflowConvenioId_Jsonclick = "";
         edtReembolsoFlowLogId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtReembolsoWorkFlowConvenioId_Enabled = 0;
         edtReembolsoLogId_Enabled = 0;
         edtReembolsoFlowLogUserNome_Enabled = 0;
         edtReembolsoFlowLogUser_Enabled = 0;
         edtReembolsoFlowLogDate_Enabled = 0;
         edtLogWorkflowConvenioDesc_Enabled = 0;
         edtLogWorkflowConvenioId_Enabled = 0;
         edtReembolsoFlowLogId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "ReembolsoFlowLogWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|";
         Ddo_grid_Includedatalist = "T|";
         Ddo_grid_Filterisrange = "|P";
         Ddo_grid_Filtertype = "Character|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1";
         Ddo_grid_Columnids = "2:LogWorkflowConvenioDesc|3:ReembolsoFlowLogDate";
         Ddo_grid_Gridinternalname = "";
         subGrid_Rows = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11812","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14812","iparms":[]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV23ReembolsoLogId","fld":"vREEMBOLSOLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFLogWorkflowConvenioDesc","fld":"vTFLOGWORKFLOWCONVENIODESC","type":"svchar"},{"av":"AV16TFLogWorkflowConvenioDesc_Sel","fld":"vTFLOGWORKFLOWCONVENIODESC_SEL","type":"svchar"},{"av":"AV17TFReembolsoFlowLogDate","fld":"vTFREEMBOLSOFLOWLOGDATE","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV18TFReembolsoFlowLogDate_To","fld":"vTFREEMBOLSOFLOWLOGDATE_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV29Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("VALID_LOGWORKFLOWCONVENIOID","""{"handler":"Valid_Logworkflowconvenioid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOFLOWLOGUSER","""{"handler":"Valid_Reembolsoflowloguser","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOLOGID","""{"handler":"Valid_Reembolsologid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Reembolsoworkflowconvenioid","iparms":[]}""");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15TFLogWorkflowConvenioDesc = "";
         AV16TFLogWorkflowConvenioDesc_Sel = "";
         AV17TFReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         AV18TFReembolsoFlowLogDate_To = (DateTime)(DateTime.MinValue);
         AV29Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV22DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV19DDO_ReembolsoFlowLogDateAuxDate = DateTime.MinValue;
         AV20DDO_ReembolsoFlowLogDateAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV21DDO_ReembolsoFlowLogDateAuxDateText = "";
         ucTfreembolsoflowlogdate_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = "";
         AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel = "";
         AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to = (DateTime)(DateTime.MinValue);
         A752LogWorkflowConvenioDesc = "";
         A747ReembolsoFlowLogDate = (DateTime)(DateTime.MinValue);
         A745ReembolsoFlowLogUserNome = "";
         GXDecQS = "";
         lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc = "";
         H00812_A749ReembolsoWorkFlowConvenioId = new int[1] ;
         H00812_n749ReembolsoWorkFlowConvenioId = new bool[] {false} ;
         H00812_A748ReembolsoLogId = new int[1] ;
         H00812_n748ReembolsoLogId = new bool[] {false} ;
         H00812_A745ReembolsoFlowLogUserNome = new string[] {""} ;
         H00812_n745ReembolsoFlowLogUserNome = new bool[] {false} ;
         H00812_A744ReembolsoFlowLogUser = new short[1] ;
         H00812_n744ReembolsoFlowLogUser = new bool[] {false} ;
         H00812_A747ReembolsoFlowLogDate = new DateTime[] {DateTime.MinValue} ;
         H00812_n747ReembolsoFlowLogDate = new bool[] {false} ;
         H00812_A752LogWorkflowConvenioDesc = new string[] {""} ;
         H00812_n752LogWorkflowConvenioDesc = new bool[] {false} ;
         H00812_A750LogWorkflowConvenioId = new int[1] ;
         H00812_n750LogWorkflowConvenioId = new bool[] {false} ;
         H00812_A746ReembolsoFlowLogId = new int[1] ;
         H00813_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV23ReembolsoLogId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoflowlogww__default(),
            new Object[][] {
                new Object[] {
               H00812_A749ReembolsoWorkFlowConvenioId, H00812_n749ReembolsoWorkFlowConvenioId, H00812_A748ReembolsoLogId, H00812_n748ReembolsoLogId, H00812_A745ReembolsoFlowLogUserNome, H00812_n745ReembolsoFlowLogUserNome, H00812_A744ReembolsoFlowLogUser, H00812_n744ReembolsoFlowLogUser, H00812_A747ReembolsoFlowLogDate, H00812_n747ReembolsoFlowLogDate,
               H00812_A752LogWorkflowConvenioDesc, H00812_n752LogWorkflowConvenioDesc, H00812_A750LogWorkflowConvenioId, H00812_n750LogWorkflowConvenioId, H00812_A746ReembolsoFlowLogId
               }
               , new Object[] {
               H00813_AGRID_nRecordCount
               }
            }
         );
         AV29Pgmname = "ReembolsoFlowLogWW";
         /* GeneXus formulas. */
         AV29Pgmname = "ReembolsoFlowLogWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A744ReembolsoFlowLogUser ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV23ReembolsoLogId ;
      private int wcpOAV23ReembolsoLogId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int AV24Reembolsoflowlogwwds_1_reembolsologid ;
      private int A746ReembolsoFlowLogId ;
      private int A750LogWorkflowConvenioId ;
      private int A748ReembolsoLogId ;
      private int A749ReembolsoWorkFlowConvenioId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtReembolsoFlowLogId_Enabled ;
      private int edtLogWorkflowConvenioId_Enabled ;
      private int edtLogWorkflowConvenioDesc_Enabled ;
      private int edtReembolsoFlowLogDate_Enabled ;
      private int edtReembolsoFlowLogUser_Enabled ;
      private int edtReembolsoFlowLogUserNome_Enabled ;
      private int edtReembolsoLogId_Enabled ;
      private int edtReembolsoWorkFlowConvenioId_Enabled ;
      private int AV30GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_9_idx="0001" ;
      private string AV29Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_reembolsoflowlogdateauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_reembolsoflowlogdateauxdatetext_Internalname ;
      private string edtavDdo_reembolsoflowlogdateauxdatetext_Jsonclick ;
      private string Tfreembolsoflowlogdate_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtReembolsoFlowLogId_Internalname ;
      private string edtLogWorkflowConvenioId_Internalname ;
      private string edtLogWorkflowConvenioDesc_Internalname ;
      private string edtReembolsoFlowLogDate_Internalname ;
      private string edtReembolsoFlowLogUser_Internalname ;
      private string edtReembolsoFlowLogUserNome_Internalname ;
      private string edtReembolsoLogId_Internalname ;
      private string edtReembolsoWorkFlowConvenioId_Internalname ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string sCtrlAV23ReembolsoLogId ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtReembolsoFlowLogId_Jsonclick ;
      private string edtLogWorkflowConvenioId_Jsonclick ;
      private string edtLogWorkflowConvenioDesc_Jsonclick ;
      private string edtReembolsoFlowLogDate_Jsonclick ;
      private string edtReembolsoFlowLogUser_Jsonclick ;
      private string edtReembolsoFlowLogUserNome_Jsonclick ;
      private string edtReembolsoLogId_Jsonclick ;
      private string edtReembolsoWorkFlowConvenioId_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV17TFReembolsoFlowLogDate ;
      private DateTime AV18TFReembolsoFlowLogDate_To ;
      private DateTime AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ;
      private DateTime AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ;
      private DateTime A747ReembolsoFlowLogDate ;
      private DateTime AV19DDO_ReembolsoFlowLogDateAuxDate ;
      private DateTime AV20DDO_ReembolsoFlowLogDateAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n750LogWorkflowConvenioId ;
      private bool n752LogWorkflowConvenioDesc ;
      private bool n747ReembolsoFlowLogDate ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n745ReembolsoFlowLogUserNome ;
      private bool n748ReembolsoLogId ;
      private bool n749ReembolsoWorkFlowConvenioId ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15TFLogWorkflowConvenioDesc ;
      private string AV16TFLogWorkflowConvenioDesc_Sel ;
      private string AV21DDO_ReembolsoFlowLogDateAuxDateText ;
      private string AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ;
      private string AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ;
      private string A752LogWorkflowConvenioDesc ;
      private string A745ReembolsoFlowLogUserNome ;
      private string lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfreembolsoflowlogdate_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV22DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private int[] H00812_A749ReembolsoWorkFlowConvenioId ;
      private bool[] H00812_n749ReembolsoWorkFlowConvenioId ;
      private int[] H00812_A748ReembolsoLogId ;
      private bool[] H00812_n748ReembolsoLogId ;
      private string[] H00812_A745ReembolsoFlowLogUserNome ;
      private bool[] H00812_n745ReembolsoFlowLogUserNome ;
      private short[] H00812_A744ReembolsoFlowLogUser ;
      private bool[] H00812_n744ReembolsoFlowLogUser ;
      private DateTime[] H00812_A747ReembolsoFlowLogDate ;
      private bool[] H00812_n747ReembolsoFlowLogDate ;
      private string[] H00812_A752LogWorkflowConvenioDesc ;
      private bool[] H00812_n752LogWorkflowConvenioDesc ;
      private int[] H00812_A750LogWorkflowConvenioId ;
      private bool[] H00812_n750LogWorkflowConvenioId ;
      private int[] H00812_A746ReembolsoFlowLogId ;
      private long[] H00813_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoflowlogww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00812( IGxContext context ,
                                             string AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                             string AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                             DateTime AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                             DateTime AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                             string A752LogWorkflowConvenioDesc ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A748ReembolsoLogId ,
                                             int AV24Reembolsoflowlogwwds_1_reembolsologid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.WorkflowConvenioId AS ReembolsoWorkFlowConvenioId, T1.ReembolsoLogId AS ReembolsoLogId, T3.SecUserName AS ReembolsoFlowLogUserNome, T1.ReembolsoFlowLogUser AS ReembolsoFlowLogUser, T1.ReembolsoFlowLogDate, T4.WorkflowConvenioDesc AS LogWorkflowConvenioDesc, T1.LogWorkflowConvenioId AS LogWorkflowConvenioId, T1.ReembolsoFlowLogId";
         sFromString = " FROM (((ReembolsoFlowLog T1 LEFT JOIN Reembolso T2 ON T2.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN WorkflowConvenio T4 ON T4.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.ReembolsoLogId = :AV24Reembolsoflowlogwwds_1_reembolsologid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc like :lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc = ( :AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T4.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoLogId, T1.ReembolsoFlowLogDate, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoLogId DESC, T1.ReembolsoFlowLogDate DESC, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY T1.ReembolsoLogId, T4.WorkflowConvenioDesc, T1.ReembolsoFlowLogId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.ReembolsoLogId DESC, T4.WorkflowConvenioDesc DESC, T1.ReembolsoFlowLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.ReembolsoFlowLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00813( IGxContext context ,
                                             string AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel ,
                                             string AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc ,
                                             DateTime AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate ,
                                             DateTime AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to ,
                                             string A752LogWorkflowConvenioDesc ,
                                             DateTime A747ReembolsoFlowLogDate ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A748ReembolsoLogId ,
                                             int AV24Reembolsoflowlogwwds_1_reembolsologid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((ReembolsoFlowLog T1 LEFT JOIN Reembolso T4 ON T4.ReembolsoId = T1.ReembolsoLogId) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ReembolsoFlowLogUser) LEFT JOIN WorkflowConvenio T2 ON T2.WorkflowConvenioId = T1.LogWorkflowConvenioId)";
         AddWhere(sWhereString, "(T1.ReembolsoLogId = :AV24Reembolsoflowlogwwds_1_reembolsologid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)) ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc like :lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel)) && ! ( StringUtil.StrCmp(AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc = ( :AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.WorkflowConvenioDesc IS NULL or (char_length(trim(trailing ' ' from T2.WorkflowConvenioDesc))=0))");
         }
         if ( ! (DateTime.MinValue==AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate >= :AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to) )
         {
            AddWhere(sWhereString, "(T1.ReembolsoFlowLogDate <= :AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00812(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 1 :
                     return conditional_H00813(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmH00812;
          prmH00812 = new Object[] {
          new ParDef("AV24Reembolsoflowlogwwds_1_reembolsologid",GXType.Int32,9,0) ,
          new ParDef("lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to",GXType.DateTime,8,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00813;
          prmH00813 = new Object[] {
          new ParDef("AV24Reembolsoflowlogwwds_1_reembolsologid",GXType.Int32,9,0) ,
          new ParDef("lV25Reembolsoflowlogwwds_2_tflogworkflowconveniodesc",GXType.VarChar,60,0) ,
          new ParDef("AV26Reembolsoflowlogwwds_3_tflogworkflowconveniodesc_sel",GXType.VarChar,60,0) ,
          new ParDef("AV27Reembolsoflowlogwwds_4_tfreembolsoflowlogdate",GXType.DateTime,8,5) ,
          new ParDef("AV28Reembolsoflowlogwwds_5_tfreembolsoflowlogdate_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00812", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00812,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00813", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00813,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
