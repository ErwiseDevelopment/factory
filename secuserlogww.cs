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
   public class secuserlogww : GXWebComponent
   {
      public secuserlogww( )
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

      public secuserlogww( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
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
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
         nRC_GXsfl_123 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_123"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_123_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_123_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_123_idx = GetPar( "sGXsfl_123_idx");
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
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV15FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV16DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19SecUserName1 = GetPar( "SecUserName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24SecUserName2 = GetPar( "SecUserName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV29SecUserName3 = GetPar( "SecUserName3");
         AV52SecUserLogDateTime1 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime1"));
         AV54SecUserLogDateTime2 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime2"));
         AV56SecUserLogDateTime3 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime3"));
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV61Pgmname = GetPar( "Pgmname");
         AV53SecUserLogDateTime_To1 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime_To1"));
         AV55SecUserLogDateTime_To2 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime_To2"));
         AV57SecUserLogDateTime_To3 = context.localUtil.ParseDTimeParm( GetPar( "SecUserLogDateTime_To3"));
         AV38TFSecUserName = GetPar( "TFSecUserName");
         AV39TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV40TFSecUserFullName = GetPar( "TFSecUserFullName");
         AV41TFSecUserFullName_Sel = GetPar( "TFSecUserFullName_Sel");
         AV47TFSecUserLogDateTime = context.localUtil.ParseDTimeParm( GetPar( "TFSecUserLogDateTime"));
         AV48TFSecUserLogDateTime_To = context.localUtil.ParseDTimeParm( GetPar( "TFSecUserLogDateTime_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
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
            PA762( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               AV61Pgmname = "SecUserLogWW";
               WS762( ) ;
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
            context.SendWebValue( " Log entrada de usuário") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("secuserlogww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV14OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV15FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1", AV16DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME1", AV19SecUserName1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME2", AV24SecUserName2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME3", AV29SecUserName3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERLOGDATETIME1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERLOGDATETIME2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERLOGDATETIME3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 8, 0, 3, "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_123", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_123), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV35ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME_TO1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME_TO2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSECUSERLOGDATETIME_TO3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SECUSERLOGDATETIMEAUXDATE", context.localUtil.DToC( AV49DDO_SecUserLogDateTimeAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SECUSERLOGDATETIMEAUXDATETO", context.localUtil.DToC( AV50DDO_SecUserLogDateTimeAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERNAME", AV38TFSecUserName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERNAME_SEL", AV39TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERFULLNAME", AV40TFSecUserFullName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERFULLNAME_SEL", AV41TFSecUserFullName_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERLOGDATETIME", context.localUtil.TToC( AV47TFSecUserLogDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERLOGDATETIME_TO", context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV14OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Width", StringUtil.RTrim( Dvpanel_tableheader_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autowidth", StringUtil.BoolToStr( Dvpanel_tableheader_Autowidth));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoheight", StringUtil.BoolToStr( Dvpanel_tableheader_Autoheight));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Cls", StringUtil.RTrim( Dvpanel_tableheader_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Title", StringUtil.RTrim( Dvpanel_tableheader_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsible", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsible));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Collapsed", StringUtil.BoolToStr( Dvpanel_tableheader_Collapsed));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableheader_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Iconposition", StringUtil.RTrim( Dvpanel_tableheader_Iconposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVPANEL_TABLEHEADER_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableheader_Autoscroll));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm762( )
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
         return "SecUserLogWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Log entrada de usuário" ;
      }

      protected void WB760( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "secuserlogww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            ucDvpanel_tableheader.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableheader_Internalname, sPrefix+"DVPANEL_TABLEHEADERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVPANEL_TABLEHEADERContainer"+"TableHeader"+"\" style=\"display:none;\">") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(123), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserLogWW.htm");
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
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_SecUserLogWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_762( true) ;
         }
         else
         {
            wb_table1_43_762( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_762e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_71_762( true) ;
         }
         else
         {
            wb_table2_71_762( false) ;
         }
         return  ;
      }

      protected void wb_table2_71_762e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_99_762( true) ;
         }
         else
         {
            wb_table3_99_762( false) ;
         }
         return  ;
      }

      protected void wb_table3_99_762e( bool wbgen )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl123( ) ;
         }
         if ( wbEnd == 123 )
         {
            wbEnd = 0;
            nRC_GXsfl_123 = (int)(nGXsfl_123_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
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
            /* User Defined Control */
            ucSecuserlogdatetime_rangepicker1.SetProperty("Start Date", AV52SecUserLogDateTime1);
            ucSecuserlogdatetime_rangepicker1.SetProperty("End Date", AV53SecUserLogDateTime_To1);
            ucSecuserlogdatetime_rangepicker1.Render(context, "wwp.daterangepicker", Secuserlogdatetime_rangepicker1_Internalname, sPrefix+"SECUSERLOGDATETIME_RANGEPICKER1Container");
            /* User Defined Control */
            ucSecuserlogdatetime_rangepicker2.SetProperty("Start Date", AV54SecUserLogDateTime2);
            ucSecuserlogdatetime_rangepicker2.SetProperty("End Date", AV55SecUserLogDateTime_To2);
            ucSecuserlogdatetime_rangepicker2.Render(context, "wwp.daterangepicker", Secuserlogdatetime_rangepicker2_Internalname, sPrefix+"SECUSERLOGDATETIME_RANGEPICKER2Container");
            /* User Defined Control */
            ucSecuserlogdatetime_rangepicker3.SetProperty("Start Date", AV56SecUserLogDateTime3);
            ucSecuserlogdatetime_rangepicker3.SetProperty("End Date", AV57SecUserLogDateTime_To3);
            ucSecuserlogdatetime_rangepicker3.Render(context, "wwp.daterangepicker", Secuserlogdatetime_rangepicker3_Internalname, sPrefix+"SECUSERLOGDATETIME_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_SecUserLogWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_secuserlogdatetimeauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_secuserlogdatetimeauxdatetext_Internalname, AV51DDO_SecUserLogDateTimeAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV51DDO_SecUserLogDateTimeAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_secuserlogdatetimeauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            /* User Defined Control */
            ucTfsecuserlogdatetime_rangepicker.SetProperty("Start Date", AV49DDO_SecUserLogDateTimeAuxDate);
            ucTfsecuserlogdatetime_rangepicker.SetProperty("End Date", AV50DDO_SecUserLogDateTimeAuxDateTo);
            ucTfsecuserlogdatetime_rangepicker.Render(context, "wwp.daterangepicker", Tfsecuserlogdatetime_rangepicker_Internalname, sPrefix+"TFSECUSERLOGDATETIME_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 123 )
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

      protected void START762( )
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
            Form.Meta.addItem("description", " Log entrada de usuário", 0) ;
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
               STRUP760( ) ;
            }
         }
      }

      protected void WS762( )
      {
         START762( ) ;
         EVT762( ) ;
      }

      protected void EVT762( )
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
                                 STRUP760( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E12762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E13762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SECUSERLOGDATETIME_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Secuserlogdatetime_rangepicker1.Daterangechanged */
                                    E14762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SECUSERLOGDATETIME_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Secuserlogdatetime_rangepicker2.Daterangechanged */
                                    E15762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SECUSERLOGDATETIME_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Secuserlogdatetime_rangepicker3.Daterangechanged */
                                    E16762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E17762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E18762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E19762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E20762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E21762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E22762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E23762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E24762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E25762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E26762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E27762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E28762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E29762 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP760( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
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
                                 STRUP760( ) ;
                              }
                              nGXsfl_123_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
                              SubsflControlProps_1232( ) ;
                              A559SecUserLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n133SecUserId = false;
                              A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
                              n141SecUserName = false;
                              A143SecUserFullName = StringUtil.Upper( cgiGet( edtSecUserFullName_Internalname));
                              n143SecUserFullName = false;
                              A560SecUserLogDateTime = context.localUtil.CToT( cgiGet( edtSecUserLogDateTime_Internalname), 0);
                              n560SecUserLogDateTime = false;
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E30762 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E31762 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E32762 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secusername1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME1"), AV19SecUserName1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secusername2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME2"), AV24SecUserName2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secusername3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME3"), AV29SecUserName3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secuserlogdatetime1 Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME1"), 0) != AV52SecUserLogDateTime1 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secuserlogdatetime2 Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME2"), 0) != AV54SecUserLogDateTime2 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secuserlogdatetime3 Changed */
                                             if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME3"), 0) != AV56SecUserLogDateTime3 )
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
                                       STRUP760( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
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

      protected void WE762( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm762( ) ;
            }
         }
      }

      protected void PA762( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
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
         SubsflControlProps_1232( ) ;
         while ( nGXsfl_123_idx <= nRC_GXsfl_123 )
         {
            sendrow_1232( ) ;
            nGXsfl_123_idx = ((subGrid_Islastpage==1)&&(nGXsfl_123_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_123_idx+1);
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1232( ) ;
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
                                       string AV19SecUserName1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV24SecUserName2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV29SecUserName3 ,
                                       DateTime AV52SecUserLogDateTime1 ,
                                       DateTime AV54SecUserLogDateTime2 ,
                                       DateTime AV56SecUserLogDateTime3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV61Pgmname ,
                                       DateTime AV53SecUserLogDateTime_To1 ,
                                       DateTime AV55SecUserLogDateTime_To2 ,
                                       DateTime AV57SecUserLogDateTime_To3 ,
                                       string AV38TFSecUserName ,
                                       string AV39TFSecUserName_Sel ,
                                       string AV40TFSecUserFullName ,
                                       string AV41TFSecUserFullName_Sel ,
                                       DateTime AV47TFSecUserLogDateTime ,
                                       DateTime AV48TFSecUserLogDateTime_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       DateTime Gx_date ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF762( ) ;
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF762( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "SecUserLogWW";
      }

      protected void RF762( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 123;
         /* Execute user event: Refresh */
         E31762 ();
         nGXsfl_123_idx = 1;
         sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
         SubsflControlProps_1232( ) ;
         bGXsfl_123_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            SubsflControlProps_1232( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV62Secuserlogwwds_1_filterfulltext ,
                                                 AV63Secuserlogwwds_2_dynamicfiltersselector1 ,
                                                 AV64Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                                 AV65Secuserlogwwds_4_secuserlogdatetime1 ,
                                                 AV66Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                                 AV67Secuserlogwwds_6_secusername1 ,
                                                 AV68Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                                 AV69Secuserlogwwds_8_dynamicfiltersselector2 ,
                                                 AV70Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                                 AV71Secuserlogwwds_10_secuserlogdatetime2 ,
                                                 AV72Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                                 AV73Secuserlogwwds_12_secusername2 ,
                                                 AV74Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                                 AV75Secuserlogwwds_14_dynamicfiltersselector3 ,
                                                 AV76Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                                 AV77Secuserlogwwds_16_secuserlogdatetime3 ,
                                                 AV78Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                                 AV79Secuserlogwwds_18_secusername3 ,
                                                 AV81Secuserlogwwds_20_tfsecusername_sel ,
                                                 AV80Secuserlogwwds_19_tfsecusername ,
                                                 AV83Secuserlogwwds_22_tfsecuserfullname_sel ,
                                                 AV82Secuserlogwwds_21_tfsecuserfullname ,
                                                 AV84Secuserlogwwds_23_tfsecuserlogdatetime ,
                                                 AV85Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                                 A141SecUserName ,
                                                 A143SecUserFullName ,
                                                 A560SecUserLogDateTime ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV62Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext), "%", "");
            lV62Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext), "%", "");
            lV67Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1), "%", "");
            lV67Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1), "%", "");
            lV73Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2), "%", "");
            lV73Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2), "%", "");
            lV79Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3), "%", "");
            lV79Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3), "%", "");
            lV80Secuserlogwwds_19_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV80Secuserlogwwds_19_tfsecusername), "%", "");
            lV82Secuserlogwwds_21_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV82Secuserlogwwds_21_tfsecuserfullname), "%", "");
            /* Using cursor H00762 */
            pr_default.execute(0, new Object[] {lV62Secuserlogwwds_1_filterfulltext, lV62Secuserlogwwds_1_filterfulltext, AV65Secuserlogwwds_4_secuserlogdatetime1, AV65Secuserlogwwds_4_secuserlogdatetime1, AV66Secuserlogwwds_5_secuserlogdatetime_to1, AV66Secuserlogwwds_5_secuserlogdatetime_to1, lV67Secuserlogwwds_6_secusername1, lV67Secuserlogwwds_6_secusername1, AV71Secuserlogwwds_10_secuserlogdatetime2, AV71Secuserlogwwds_10_secuserlogdatetime2, AV72Secuserlogwwds_11_secuserlogdatetime_to2, AV72Secuserlogwwds_11_secuserlogdatetime_to2, lV73Secuserlogwwds_12_secusername2, lV73Secuserlogwwds_12_secusername2, AV77Secuserlogwwds_16_secuserlogdatetime3, AV77Secuserlogwwds_16_secuserlogdatetime3, AV78Secuserlogwwds_17_secuserlogdatetime_to3, AV78Secuserlogwwds_17_secuserlogdatetime_to3, lV79Secuserlogwwds_18_secusername3, lV79Secuserlogwwds_18_secusername3, lV80Secuserlogwwds_19_tfsecusername, AV81Secuserlogwwds_20_tfsecusername_sel, lV82Secuserlogwwds_21_tfsecuserfullname, AV83Secuserlogwwds_22_tfsecuserfullname_sel, AV84Secuserlogwwds_23_tfsecuserlogdatetime, AV85Secuserlogwwds_24_tfsecuserlogdatetime_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_123_idx = 1;
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1232( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A560SecUserLogDateTime = H00762_A560SecUserLogDateTime[0];
               n560SecUserLogDateTime = H00762_n560SecUserLogDateTime[0];
               A143SecUserFullName = H00762_A143SecUserFullName[0];
               n143SecUserFullName = H00762_n143SecUserFullName[0];
               A141SecUserName = H00762_A141SecUserName[0];
               n141SecUserName = H00762_n141SecUserName[0];
               A133SecUserId = H00762_A133SecUserId[0];
               n133SecUserId = H00762_n133SecUserId[0];
               A559SecUserLogId = H00762_A559SecUserLogId[0];
               A143SecUserFullName = H00762_A143SecUserFullName[0];
               n143SecUserFullName = H00762_n143SecUserFullName[0];
               A141SecUserName = H00762_A141SecUserName[0];
               n141SecUserName = H00762_n141SecUserName[0];
               /* Execute user event: Grid.Load */
               E32762 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 123;
            WB760( ) ;
         }
         bGXsfl_123_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes762( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTODAY", GetSecureSignedToken( sPrefix, Gx_date, context));
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
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV62Secuserlogwwds_1_filterfulltext ,
                                              AV63Secuserlogwwds_2_dynamicfiltersselector1 ,
                                              AV64Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                              AV65Secuserlogwwds_4_secuserlogdatetime1 ,
                                              AV66Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                              AV67Secuserlogwwds_6_secusername1 ,
                                              AV68Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                              AV69Secuserlogwwds_8_dynamicfiltersselector2 ,
                                              AV70Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                              AV71Secuserlogwwds_10_secuserlogdatetime2 ,
                                              AV72Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                              AV73Secuserlogwwds_12_secusername2 ,
                                              AV74Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                              AV75Secuserlogwwds_14_dynamicfiltersselector3 ,
                                              AV76Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                              AV77Secuserlogwwds_16_secuserlogdatetime3 ,
                                              AV78Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                              AV79Secuserlogwwds_18_secusername3 ,
                                              AV81Secuserlogwwds_20_tfsecusername_sel ,
                                              AV80Secuserlogwwds_19_tfsecusername ,
                                              AV83Secuserlogwwds_22_tfsecuserfullname_sel ,
                                              AV82Secuserlogwwds_21_tfsecuserfullname ,
                                              AV84Secuserlogwwds_23_tfsecuserlogdatetime ,
                                              AV85Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A560SecUserLogDateTime ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV62Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext), "%", "");
         lV62Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext), "%", "");
         lV67Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1), "%", "");
         lV67Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1), "%", "");
         lV73Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2), "%", "");
         lV73Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2), "%", "");
         lV79Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3), "%", "");
         lV79Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3), "%", "");
         lV80Secuserlogwwds_19_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV80Secuserlogwwds_19_tfsecusername), "%", "");
         lV82Secuserlogwwds_21_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV82Secuserlogwwds_21_tfsecuserfullname), "%", "");
         /* Using cursor H00763 */
         pr_default.execute(1, new Object[] {lV62Secuserlogwwds_1_filterfulltext, lV62Secuserlogwwds_1_filterfulltext, AV65Secuserlogwwds_4_secuserlogdatetime1, AV65Secuserlogwwds_4_secuserlogdatetime1, AV66Secuserlogwwds_5_secuserlogdatetime_to1, AV66Secuserlogwwds_5_secuserlogdatetime_to1, lV67Secuserlogwwds_6_secusername1, lV67Secuserlogwwds_6_secusername1, AV71Secuserlogwwds_10_secuserlogdatetime2, AV71Secuserlogwwds_10_secuserlogdatetime2, AV72Secuserlogwwds_11_secuserlogdatetime_to2, AV72Secuserlogwwds_11_secuserlogdatetime_to2, lV73Secuserlogwwds_12_secusername2, lV73Secuserlogwwds_12_secusername2, AV77Secuserlogwwds_16_secuserlogdatetime3, AV77Secuserlogwwds_16_secuserlogdatetime3, AV78Secuserlogwwds_17_secuserlogdatetime_to3, AV78Secuserlogwwds_17_secuserlogdatetime_to3, lV79Secuserlogwwds_18_secusername3, lV79Secuserlogwwds_18_secusername3, lV80Secuserlogwwds_19_tfsecusername, AV81Secuserlogwwds_20_tfsecusername_sel, lV82Secuserlogwwds_21_tfsecuserfullname, AV83Secuserlogwwds_22_tfsecuserfullname_sel, AV84Secuserlogwwds_23_tfsecuserlogdatetime, AV85Secuserlogwwds_24_tfsecuserlogdatetime_to});
         GRID_nRecordCount = H00763_AGRID_nRecordCount[0];
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
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "SecUserLogWW";
         edtSecUserLogId_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserLogDateTime_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP760( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E30762 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV35ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_123 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_123"), ",", "."), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            AV52SecUserLogDateTime1 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME1"), 0);
            AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
            AV53SecUserLogDateTime_To1 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME_TO1"), 0);
            AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
            AV54SecUserLogDateTime2 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME2"), 0);
            AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
            AV55SecUserLogDateTime_To2 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME_TO2"), 0);
            AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
            AV56SecUserLogDateTime3 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME3"), 0);
            AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
            AV57SecUserLogDateTime_To3 = context.localUtil.CToT( cgiGet( sPrefix+"vSECUSERLOGDATETIME_TO3"), 0);
            AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
            AV49DDO_SecUserLogDateTimeAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SECUSERLOGDATETIMEAUXDATE"), 0);
            AssignAttri(sPrefix, false, "AV49DDO_SecUserLogDateTimeAuxDate", context.localUtil.Format(AV49DDO_SecUserLogDateTimeAuxDate, "99/99/9999"));
            AV50DDO_SecUserLogDateTimeAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SECUSERLOGDATETIMEAUXDATETO"), 0);
            AssignAttri(sPrefix, false, "AV50DDO_SecUserLogDateTimeAuxDateTo", context.localUtil.Format(AV50DDO_SecUserLogDateTimeAuxDateTo, "99/99/9999"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Dvpanel_tableheader_Width = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Width");
            Dvpanel_tableheader_Autowidth = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autowidth"));
            Dvpanel_tableheader_Autoheight = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoheight"));
            Dvpanel_tableheader_Cls = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Cls");
            Dvpanel_tableheader_Title = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Title");
            Dvpanel_tableheader_Collapsible = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsible"));
            Dvpanel_tableheader_Collapsed = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Collapsed"));
            Dvpanel_tableheader_Showcollapseicon = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Showcollapseicon"));
            Dvpanel_tableheader_Iconposition = cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Iconposition");
            Dvpanel_tableheader_Autoscroll = StringUtil.StrToBool( cgiGet( sPrefix+"DVPANEL_TABLEHEADER_Autoscroll"));
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
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
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV15FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV16DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AV58SecUserLogDateTime_RangeText1 = cgiGet( edtavSecuserlogdatetime_rangetext1_Internalname);
            AssignAttri(sPrefix, false, "AV58SecUserLogDateTime_RangeText1", AV58SecUserLogDateTime_RangeText1);
            AV19SecUserName1 = StringUtil.Upper( cgiGet( edtavSecusername1_Internalname));
            AssignAttri(sPrefix, false, "AV19SecUserName1", AV19SecUserName1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AV59SecUserLogDateTime_RangeText2 = cgiGet( edtavSecuserlogdatetime_rangetext2_Internalname);
            AssignAttri(sPrefix, false, "AV59SecUserLogDateTime_RangeText2", AV59SecUserLogDateTime_RangeText2);
            AV24SecUserName2 = StringUtil.Upper( cgiGet( edtavSecusername2_Internalname));
            AssignAttri(sPrefix, false, "AV24SecUserName2", AV24SecUserName2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV60SecUserLogDateTime_RangeText3 = cgiGet( edtavSecuserlogdatetime_rangetext3_Internalname);
            AssignAttri(sPrefix, false, "AV60SecUserLogDateTime_RangeText3", AV60SecUserLogDateTime_RangeText3);
            AV29SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri(sPrefix, false, "AV29SecUserName3", AV29SecUserName3);
            AV51DDO_SecUserLogDateTimeAuxDateText = cgiGet( edtavDdo_secuserlogdatetimeauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV51DDO_SecUserLogDateTimeAuxDateText", AV51DDO_SecUserLogDateTimeAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV13OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV14OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV15FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR1"), AV16DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV17DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME1"), AV19SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME2"), AV24SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME3"), AV29SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME1")) != AV52SecUserLogDateTime1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME2")) != AV54SecUserLogDateTime2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( sPrefix+"GXH_vSECUSERLOGDATETIME3")) != AV56SecUserLogDateTime3 )
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
         E30762 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E30762( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFSECUSERLOGDATETIME_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_secuserlogdatetimeauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         this.executeUsercontrolMethod(sPrefix, false, "SECUSERLOGDATETIME_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavSecuserlogdatetime_rangetext1_Internalname});
         AV16DynamicFiltersSelector1 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod(sPrefix, false, "SECUSERLOGDATETIME_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavSecuserlogdatetime_rangetext2_Internalname});
         AV21DynamicFiltersSelector2 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod(sPrefix, false, "SECUSERLOGDATETIME_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavSecuserlogdatetime_rangetext3_Internalname});
         AV26DynamicFiltersSelector3 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
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
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E31762( )
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
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV37ManageFiltersExecutionStep == 2 )
         {
            AV37ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Passado", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Hoje", 0);
            cmbavDynamicfiltersoperator1.addItem("2", "No futuro", 0);
            cmbavDynamicfiltersoperator1.addItem("3", "Período", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Passado", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Hoje", 0);
               cmbavDynamicfiltersoperator2.addItem("2", "No futuro", 0);
               cmbavDynamicfiltersoperator2.addItem("3", "Período", 0);
            }
            else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV25DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Passado", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Hoje", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", "No futuro", 0);
                  cmbavDynamicfiltersoperator3.addItem("3", "Período", 0);
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
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
         AV44GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char2 = AV46GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV61Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         AV62Secuserlogwwds_1_filterfulltext = AV15FilterFullText;
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV64Secuserlogwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV65Secuserlogwwds_4_secuserlogdatetime1 = AV52SecUserLogDateTime1;
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = AV53SecUserLogDateTime_To1;
         AV67Secuserlogwwds_6_secusername1 = AV19SecUserName1;
         AV68Secuserlogwwds_7_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV70Secuserlogwwds_9_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV71Secuserlogwwds_10_secuserlogdatetime2 = AV54SecUserLogDateTime2;
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = AV55SecUserLogDateTime_To2;
         AV73Secuserlogwwds_12_secusername2 = AV24SecUserName2;
         AV74Secuserlogwwds_13_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV76Secuserlogwwds_15_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV77Secuserlogwwds_16_secuserlogdatetime3 = AV56SecUserLogDateTime3;
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = AV57SecUserLogDateTime_To3;
         AV79Secuserlogwwds_18_secusername3 = AV29SecUserName3;
         AV80Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV81Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV82Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = AV47TFSecUserLogDateTime;
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = AV48TFSecUserLogDateTime_To;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12762( )
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
            AV43PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV43PageToGo) ;
         }
      }

      protected void E13762( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E17762( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
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
               AssignAttri(sPrefix, false, "AV38TFSecUserName", AV38TFSecUserName);
               AV39TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserFullName") == 0 )
            {
               AV40TFSecUserFullName = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV40TFSecUserFullName", AV40TFSecUserFullName);
               AV41TFSecUserFullName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV41TFSecUserFullName_Sel", AV41TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserLogDateTime") == 0 )
            {
               AV47TFSecUserLogDateTime = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV47TFSecUserLogDateTime", context.localUtil.TToC( AV47TFSecUserLogDateTime, 10, 5, 0, 3, "/", ":", " "));
               AV48TFSecUserLogDateTime_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV48TFSecUserLogDateTime_To", context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV48TFSecUserLogDateTime_To) )
               {
                  AV48TFSecUserLogDateTime_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV48TFSecUserLogDateTime_To)), (short)(DateTimeUtil.Month( AV48TFSecUserLogDateTime_To)), (short)(DateTimeUtil.Day( AV48TFSecUserLogDateTime_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV48TFSecUserLogDateTime_To", context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E32762( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuser"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserName_Link = formatLink("secuser") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secusercliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A133SecUserId,4,0));
         edtSecUserFullName_Link = formatLink("secusercliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "secuserlog"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A559SecUserLogId,9,0));
         edtSecUserLogDateTime_Link = formatLink("secuserlog") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 123;
         }
         sendrow_1232( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_123_Refreshing )
         {
            DoAjaxLoad(123, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E22762( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E18762( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV31DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV31DynamicFiltersIgnoreFirst", AV31DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E23762( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E14762( )
      {
         /* Secuserlogdatetime_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
         AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E24762( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
         {
            AV52SecUserLogDateTime1 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
            AV53SecUserLogDateTime_To1 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME1OPERATORVALUES' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E25762( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E19762( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E26762( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E15762( )
      {
         /* Secuserlogdatetime_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
         AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E27762( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
         {
            AV54SecUserLogDateTime2 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
            AV55SecUserLogDateTime_To2 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME2OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E20762( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AssignAttri(sPrefix, false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E28762( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E16762( )
      {
         /* Secuserlogdatetime_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
         AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E29762( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
         {
            AV56SecUserLogDateTime3 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
            AV57SecUserLogDateTime_To3 = (DateTime)(DateTime.MinValue);
            AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME3OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV29SecUserName3, AV52SecUserLogDateTime1, AV54SecUserLogDateTime2, AV56SecUserLogDateTime3, AV37ManageFiltersExecutionStep, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV61Pgmname, AV53SecUserLogDateTime_To1, AV55SecUserLogDateTime_To2, AV57SecUserLogDateTime_To3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserFullName, AV41TFSecUserFullName_Sel, AV47TFSecUserLogDateTime, AV48TFSecUserLogDateTime_To, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, Gx_date, sPrefix) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E11762( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S252 ();
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("SecUserLogWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV61Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("SecUserLogWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "SecUserLogWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV36ManageFiltersXml) ;
               AV10GridState.FromXml(AV36ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S262 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E21762( )
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
         new secuserlogwwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
         if ( StringUtil.StrCmp(AV32ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV32ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV33ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterssecuserlogdatetime1_Visible = 0;
         AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime1_Visible), 5, 0), true);
         edtavSecusername1_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
         {
            tblTablemergeddynamicfilterssecuserlogdatetime1_Visible = 1;
            AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME1OPERATORVALUES' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'UPDATESECUSERLOGDATETIME1OPERATORVALUES' Routine */
         returnInSub = false;
         cellSecuserlogdatetime_range_cell1_Class = "Invisible";
         AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell1_Internalname, "Class", cellSecuserlogdatetime_range_cell1_Class, true);
         if ( AV17DynamicFiltersOperator1 == 0 )
         {
            AV52SecUserLogDateTime1 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV17DynamicFiltersOperator1 == 1 )
         {
            AV52SecUserLogDateTime1 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
            AV53SecUserLogDateTime_To1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV17DynamicFiltersOperator1 == 2 )
         {
            AV52SecUserLogDateTime1 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV17DynamicFiltersOperator1 == 3 )
         {
            cellSecuserlogdatetime_range_cell1_Class = "";
            AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell1_Internalname, "Class", cellSecuserlogdatetime_range_cell1_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterssecuserlogdatetime2_Visible = 0;
         AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime2_Visible), 5, 0), true);
         edtavSecusername2_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
         {
            tblTablemergeddynamicfilterssecuserlogdatetime2_Visible = 1;
            AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME2OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'UPDATESECUSERLOGDATETIME2OPERATORVALUES' Routine */
         returnInSub = false;
         cellSecuserlogdatetime_range_cell2_Class = "Invisible";
         AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell2_Internalname, "Class", cellSecuserlogdatetime_range_cell2_Class, true);
         if ( AV22DynamicFiltersOperator2 == 0 )
         {
            AV54SecUserLogDateTime2 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV22DynamicFiltersOperator2 == 1 )
         {
            AV54SecUserLogDateTime2 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
            AV55SecUserLogDateTime_To2 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV22DynamicFiltersOperator2 == 2 )
         {
            AV54SecUserLogDateTime2 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV22DynamicFiltersOperator2 == 3 )
         {
            cellSecuserlogdatetime_range_cell2_Class = "";
            AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell2_Internalname, "Class", cellSecuserlogdatetime_range_cell2_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         tblTablemergeddynamicfilterssecuserlogdatetime3_Visible = 0;
         AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime3_Visible), 5, 0), true);
         edtavSecusername3_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
         {
            tblTablemergeddynamicfilterssecuserlogdatetime3_Visible = 1;
            AssignProp(sPrefix, false, tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfilterssecuserlogdatetime3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATESECUSERLOGDATETIME3OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S242( )
      {
         /* 'UPDATESECUSERLOGDATETIME3OPERATORVALUES' Routine */
         returnInSub = false;
         cellSecuserlogdatetime_range_cell3_Class = "Invisible";
         AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell3_Internalname, "Class", cellSecuserlogdatetime_range_cell3_Class, true);
         if ( AV27DynamicFiltersOperator3 == 0 )
         {
            AV56SecUserLogDateTime3 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV27DynamicFiltersOperator3 == 1 )
         {
            AV56SecUserLogDateTime3 = DateTimeUtil.ResetTime( Gx_date ) ;
            AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
            AV57SecUserLogDateTime_To3 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date , + ( (int)(1) )) ) ;
            AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV27DynamicFiltersOperator3 == 2 )
         {
            AV56SecUserLogDateTime3 = DateTimeUtil.ResetTime( DateTimeUtil.DAdd( Gx_date, (1)) ) ;
            AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
         }
         else if ( AV27DynamicFiltersOperator3 == 3 )
         {
            cellSecuserlogdatetime_range_cell3_Class = "";
            AssignProp(sPrefix, false, cellSecuserlogdatetime_range_cell3_Internalname, "Class", cellSecuserlogdatetime_range_cell3_Class, true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV54SecUserLogDateTime2 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
         AV55SecUserLogDateTime_To2 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV56SecUserLogDateTime3 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
         AV57SecUserLogDateTime_To3 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "SecUserLogWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S252( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFSecUserName = "";
         AssignAttri(sPrefix, false, "AV38TFSecUserName", AV38TFSecUserName);
         AV39TFSecUserName_Sel = "";
         AssignAttri(sPrefix, false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
         AV40TFSecUserFullName = "";
         AssignAttri(sPrefix, false, "AV40TFSecUserFullName", AV40TFSecUserFullName);
         AV41TFSecUserFullName_Sel = "";
         AssignAttri(sPrefix, false, "AV41TFSecUserFullName_Sel", AV41TFSecUserFullName_Sel);
         AV47TFSecUserLogDateTime = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV47TFSecUserLogDateTime", context.localUtil.TToC( AV47TFSecUserLogDateTime, 10, 5, 0, 3, "/", ":", " "));
         AV48TFSecUserLogDateTime_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV48TFSecUserLogDateTime_To", context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 5, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "SECUSERLOGDATETIME";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV52SecUserLogDateTime1 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
         AV53SecUserLogDateTime_To1 = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV61Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S262 ();
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S262( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV38TFSecUserName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFSecUserName", AV38TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV39TFSecUserName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV40TFSecUserFullName = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFSecUserFullName", AV40TFSecUserFullName);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV41TFSecUserFullName_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFSecUserFullName_Sel", AV41TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSERLOGDATETIME") == 0 )
            {
               AV47TFSecUserLogDateTime = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV47TFSecUserLogDateTime", context.localUtil.TToC( AV47TFSecUserLogDateTime, 10, 5, 0, 3, "/", ":", " "));
               AV48TFSecUserLogDateTime_To = context.localUtil.CToT( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV48TFSecUserLogDateTime_To", context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 5, 0, 3, "/", ":", " "));
               AV49DDO_SecUserLogDateTimeAuxDate = DateTimeUtil.ResetTime(AV47TFSecUserLogDateTime);
               AssignAttri(sPrefix, false, "AV49DDO_SecUserLogDateTimeAuxDate", context.localUtil.Format(AV49DDO_SecUserLogDateTimeAuxDate, "99/99/9999"));
               AV50DDO_SecUserLogDateTimeAuxDateTo = DateTimeUtil.ResetTime(AV48TFSecUserLogDateTime_To);
               AssignAttri(sPrefix, false, "AV50DDO_SecUserLogDateTimeAuxDateTo", context.localUtil.Format(AV50DDO_SecUserLogDateTimeAuxDateTo, "99/99/9999"));
            }
            AV87GXV1 = (int)(AV87GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName_Sel)),  AV41TFSecUserFullName_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  AV38TFSecUserName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName)),  AV40TFSecUserFullName, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char2+"|"+((DateTime.MinValue==AV47TFSecUserLogDateTime) ? "" : context.localUtil.DToC( AV49DDO_SecUserLogDateTimeAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV48TFSecUserLogDateTime_To) ? "" : context.localUtil.DToC( AV50DDO_SecUserLogDateTimeAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV52SecUserLogDateTime1 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV52SecUserLogDateTime1", context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " "));
               AV53SecUserLogDateTime_To1 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV53SecUserLogDateTime_To1", context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " "));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19SecUserName1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19SecUserName1", AV19SecUserName1);
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
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV54SecUserLogDateTime2 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Value, 4);
                  AssignAttri(sPrefix, false, "AV54SecUserLogDateTime2", context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " "));
                  AV55SecUserLogDateTime_To2 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Valueto, 4);
                  AssignAttri(sPrefix, false, "AV55SecUserLogDateTime_To2", context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " "));
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV24SecUserName2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV24SecUserName2", AV24SecUserName2);
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
                  AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV56SecUserLogDateTime3 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Value, 4);
                     AssignAttri(sPrefix, false, "AV56SecUserLogDateTime3", context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " "));
                     AV57SecUserLogDateTime_To3 = context.localUtil.CToT( AV12GridStateDynamicFilter.gxTpr_Valueto, 4);
                     AssignAttri(sPrefix, false, "AV57SecUserLogDateTime_To3", context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " "));
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV29SecUserName3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV29SecUserName3", AV29SecUserName3);
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
               AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV30DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV34Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSERNAME",  "Usuário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  0,  AV38TFSecUserName,  AV38TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel,  AV39TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSERFULLNAME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName)),  0,  AV40TFSecUserFullName,  AV40TFSecUserFullName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName_Sel)),  AV41TFSecUserFullName_Sel,  AV41TFSecUserFullName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSECUSERLOGDATETIME",  "Data",  !((DateTime.MinValue==AV47TFSecUserLogDateTime)&&(DateTime.MinValue==AV48TFSecUserLogDateTime_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV47TFSecUserLogDateTime, 10, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV47TFSecUserLogDateTime) ? "" : StringUtil.Trim( context.localUtil.Format( AV47TFSecUserLogDateTime, "99/99/9999 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV48TFSecUserLogDateTime_To, 10, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV48TFSecUserLogDateTime_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV48TFSecUserLogDateTime_To, "99/99/9999 99:99")))) ;
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
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 ) && ! ( (DateTime.MinValue==AV52SecUserLogDateTime1) && (DateTime.MinValue==AV53SecUserLogDateTime_To1) ) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Date Time",  AV17DynamicFiltersOperator1,  StringUtil.Trim( context.localUtil.TToC( AV52SecUserLogDateTime1, 10, 5, 0, 3, "/", ":", " ")),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Passado", "Hoje", "No futuro", "Período"+" "+StringUtil.Trim( context.localUtil.Format( AV52SecUserLogDateTime1, "99/99/9999 99:99")), "", "", "", "", ""),  (AV17DynamicFiltersOperator1==3),  StringUtil.Trim( context.localUtil.TToC( AV53SecUserLogDateTime_To1, 10, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV53SecUserLogDateTime_To1) ? "" : StringUtil.Trim( context.localUtil.Format( AV53SecUserLogDateTime_To1, "99/99/9999 99:99")))) ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV17DynamicFiltersOperator1,  AV19SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19SecUserName1, "Contém"+" "+AV19SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 ) && ! ( (DateTime.MinValue==AV54SecUserLogDateTime2) && (DateTime.MinValue==AV55SecUserLogDateTime_To2) ) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Date Time",  AV22DynamicFiltersOperator2,  StringUtil.Trim( context.localUtil.TToC( AV54SecUserLogDateTime2, 10, 5, 0, 3, "/", ":", " ")),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Passado", "Hoje", "No futuro", "Período"+" "+StringUtil.Trim( context.localUtil.Format( AV54SecUserLogDateTime2, "99/99/9999 99:99")), "", "", "", "", ""),  (AV22DynamicFiltersOperator2==3),  StringUtil.Trim( context.localUtil.TToC( AV55SecUserLogDateTime_To2, 10, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV55SecUserLogDateTime_To2) ? "" : StringUtil.Trim( context.localUtil.Format( AV55SecUserLogDateTime_To2, "99/99/9999 99:99")))) ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV22DynamicFiltersOperator2,  AV24SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24SecUserName2, "Contém"+" "+AV24SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 ) && ! ( (DateTime.MinValue==AV56SecUserLogDateTime3) && (DateTime.MinValue==AV57SecUserLogDateTime_To3) ) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Date Time",  AV27DynamicFiltersOperator3,  StringUtil.Trim( context.localUtil.TToC( AV56SecUserLogDateTime3, 10, 5, 0, 3, "/", ":", " ")),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Passado", "Hoje", "No futuro", "Período"+" "+StringUtil.Trim( context.localUtil.Format( AV56SecUserLogDateTime3, "99/99/9999 99:99")), "", "", "", "", ""),  (AV27DynamicFiltersOperator3==3),  StringUtil.Trim( context.localUtil.TToC( AV57SecUserLogDateTime_To3, 10, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV57SecUserLogDateTime_To3) ? "" : StringUtil.Trim( context.localUtil.Format( AV57SecUserLogDateTime_To3, "99/99/9999 99:99")))) ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usuário",  AV27DynamicFiltersOperator3,  AV29SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29SecUserName3, "Contém"+" "+AV29SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Valueto)) )
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
         AV8TrnContext.gxTpr_Transactionname = "SecUserLog";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_99_762( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserlogdatetime3_cell_Internalname+"\"  class=''>") ;
            wb_table4_105_762( true) ;
         }
         else
         {
            wb_table4_105_762( false) ;
         }
         return  ;
      }

      protected void wb_table4_105_762e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV29SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV29SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,112);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserLogWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_99_762e( true) ;
         }
         else
         {
            wb_table3_99_762e( false) ;
         }
      }

      protected void wb_table4_105_762( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterssecuserlogdatetime3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname, tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellSecuserlogdatetime_range_cell3_Internalname+"\"  class='"+cellSecuserlogdatetime_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuserlogdatetime_rangetext3_Internalname, "Sec User Log Date Time_Range Text3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuserlogdatetime_rangetext3_Internalname, AV60SecUserLogDateTime_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV60SecUserLogDateTime_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuserlogdatetime_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuserlogdatetime_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_105_762e( true) ;
         }
         else
         {
            wb_table4_105_762e( false) ;
         }
      }

      protected void wb_table2_71_762( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserlogdatetime2_cell_Internalname+"\"  class=''>") ;
            wb_table5_77_762( true) ;
         }
         else
         {
            wb_table5_77_762( false) ;
         }
         return  ;
      }

      protected void wb_table5_77_762e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV24SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV24SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserLogWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserLogWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_71_762e( true) ;
         }
         else
         {
            wb_table2_71_762e( false) ;
         }
      }

      protected void wb_table5_77_762( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterssecuserlogdatetime2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname, tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellSecuserlogdatetime_range_cell2_Internalname+"\"  class='"+cellSecuserlogdatetime_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuserlogdatetime_rangetext2_Internalname, "Sec User Log Date Time_Range Text2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuserlogdatetime_rangetext2_Internalname, AV59SecUserLogDateTime_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV59SecUserLogDateTime_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuserlogdatetime_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuserlogdatetime_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_77_762e( true) ;
         }
         else
         {
            wb_table5_77_762e( false) ;
         }
      }

      protected void wb_table1_43_762( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_SecUserLogWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secuserlogdatetime1_cell_Internalname+"\"  class=''>") ;
            wb_table6_49_762( true) ;
         }
         else
         {
            wb_table6_49_762( false) ;
         }
         return  ;
      }

      protected void wb_table6_49_762e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV19SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV19SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserLogWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SecUserLogWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_762e( true) ;
         }
         else
         {
            wb_table1_43_762e( false) ;
         }
      }

      protected void wb_table6_49_762( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfilterssecuserlogdatetime1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname, tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellSecuserlogdatetime_range_cell1_Internalname+"\"  class='"+cellSecuserlogdatetime_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuserlogdatetime_rangetext1_Internalname, "Sec User Log Date Time_Range Text1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'" + sGXsfl_123_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuserlogdatetime_rangetext1_Internalname, AV58SecUserLogDateTime_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV58SecUserLogDateTime_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecuserlogdatetime_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavSecuserlogdatetime_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SecUserLogWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_49_762e( true) ;
         }
         else
         {
            wb_table6_49_762e( false) ;
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
         PA762( ) ;
         WS762( ) ;
         WE762( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA762( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "secuserlogww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA762( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA762( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS762( ) ;
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
         WS762( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE762( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019193291", true, true);
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
         context.AddJavascriptSource("secuserlogww.js", "?202561019193292", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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

      protected void SubsflControlProps_1232( )
      {
         edtSecUserLogId_Internalname = sPrefix+"SECUSERLOGID_"+sGXsfl_123_idx;
         edtSecUserId_Internalname = sPrefix+"SECUSERID_"+sGXsfl_123_idx;
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME_"+sGXsfl_123_idx;
         edtSecUserFullName_Internalname = sPrefix+"SECUSERFULLNAME_"+sGXsfl_123_idx;
         edtSecUserLogDateTime_Internalname = sPrefix+"SECUSERLOGDATETIME_"+sGXsfl_123_idx;
      }

      protected void SubsflControlProps_fel_1232( )
      {
         edtSecUserLogId_Internalname = sPrefix+"SECUSERLOGID_"+sGXsfl_123_fel_idx;
         edtSecUserId_Internalname = sPrefix+"SECUSERID_"+sGXsfl_123_fel_idx;
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME_"+sGXsfl_123_fel_idx;
         edtSecUserFullName_Internalname = sPrefix+"SECUSERFULLNAME_"+sGXsfl_123_fel_idx;
         edtSecUserLogDateTime_Internalname = sPrefix+"SECUSERLOGDATETIME_"+sGXsfl_123_fel_idx;
      }

      protected void sendrow_1232( )
      {
         sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
         SubsflControlProps_1232( ) ;
         WB760( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_123_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_123_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_123_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserLogId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A559SecUserLogId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A559SecUserLogId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserLogId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserFullName_Internalname,(string)A143SecUserFullName,StringUtil.RTrim( context.localUtil.Format( A143SecUserFullName, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecUserFullName_Link,(string)"",(string)"",(string)"",(string)edtSecUserFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserLogDateTime_Internalname,context.localUtil.TToC( A560SecUserLogDateTime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A560SecUserLogDateTime, "99/99/9999 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecUserLogDateTime_Link,(string)"",(string)"",(string)"",(string)edtSecUserLogDateTime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes762( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_123_idx = ((subGrid_Islastpage==1)&&(nGXsfl_123_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_123_idx+1);
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1232( ) ;
         }
         /* End function sendrow_1232 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SECUSERLOGDATETIME", "Date Time", 0);
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usuário", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator1.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator1.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECUSERLOGDATETIME", "Date Time", 0);
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usuário", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator2.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator2.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECUSERLOGDATETIME", "Date Time", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usuário", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator3.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator3.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl123( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"123\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Log Id") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A559SecUserLogId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A560SecUserLogDateTime, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserLogDateTime_Link));
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
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         divTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         divTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = sPrefix+"DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR1";
         edtavSecuserlogdatetime_rangetext1_Internalname = sPrefix+"vSECUSERLOGDATETIME_RANGETEXT1";
         cellSecuserlogdatetime_range_cell1_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGE_CELL1";
         tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1";
         cellFilter_secuserlogdatetime1_cell_Internalname = sPrefix+"FILTER_SECUSERLOGDATETIME1_CELL";
         edtavSecusername1_Internalname = sPrefix+"vSECUSERNAME1";
         cellFilter_secusername1_cell_Internalname = sPrefix+"FILTER_SECUSERNAME1_CELL";
         imgAdddynamicfilters1_Internalname = sPrefix+"ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = sPrefix+"REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = sPrefix+"DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR2";
         edtavSecuserlogdatetime_rangetext2_Internalname = sPrefix+"vSECUSERLOGDATETIME_RANGETEXT2";
         cellSecuserlogdatetime_range_cell2_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGE_CELL2";
         tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2";
         cellFilter_secuserlogdatetime2_cell_Internalname = sPrefix+"FILTER_SECUSERLOGDATETIME2_CELL";
         edtavSecusername2_Internalname = sPrefix+"vSECUSERNAME2";
         cellFilter_secusername2_cell_Internalname = sPrefix+"FILTER_SECUSERNAME2_CELL";
         imgAdddynamicfilters2_Internalname = sPrefix+"ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = sPrefix+"REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = sPrefix+"DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = sPrefix+"vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = sPrefix+"DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = sPrefix+"vDYNAMICFILTERSOPERATOR3";
         edtavSecuserlogdatetime_rangetext3_Internalname = sPrefix+"vSECUSERLOGDATETIME_RANGETEXT3";
         cellSecuserlogdatetime_range_cell3_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGE_CELL3";
         tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3";
         cellFilter_secuserlogdatetime3_cell_Internalname = sPrefix+"FILTER_SECUSERLOGDATETIME3_CELL";
         edtavSecusername3_Internalname = sPrefix+"vSECUSERNAME3";
         cellFilter_secusername3_cell_Internalname = sPrefix+"FILTER_SECUSERNAME3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtSecUserLogId_Internalname = sPrefix+"SECUSERLOGID";
         edtSecUserId_Internalname = sPrefix+"SECUSERID";
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME";
         edtSecUserFullName_Internalname = sPrefix+"SECUSERFULLNAME";
         edtSecUserLogDateTime_Internalname = sPrefix+"SECUSERLOGDATETIME";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Secuserlogdatetime_rangepicker1_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGEPICKER1";
         Secuserlogdatetime_rangepicker2_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGEPICKER2";
         Secuserlogdatetime_rangepicker3_Internalname = sPrefix+"SECUSERLOGDATETIME_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_secuserlogdatetimeauxdatetext_Internalname = sPrefix+"vDDO_SECUSERLOGDATETIMEAUXDATETEXT";
         Tfsecuserlogdatetime_rangepicker_Internalname = sPrefix+"TFSECUSERLOGDATETIME_RANGEPICKER";
         divDdo_secuserlogdatetimeauxdates_Internalname = sPrefix+"DDO_SECUSERLOGDATETIMEAUXDATES";
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
         edtSecUserLogDateTime_Jsonclick = "";
         edtSecUserLogDateTime_Link = "";
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Link = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtSecUserId_Jsonclick = "";
         edtSecUserLogId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSecuserlogdatetime_rangetext1_Jsonclick = "";
         edtavSecuserlogdatetime_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavSecuserlogdatetime_rangetext2_Jsonclick = "";
         edtavSecuserlogdatetime_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecuserlogdatetime_rangetext3_Jsonclick = "";
         edtavSecuserlogdatetime_rangetext3_Enabled = 1;
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cellSecuserlogdatetime_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecusername3_Visible = 1;
         tblTablemergeddynamicfilterssecuserlogdatetime3_Visible = 1;
         cellSecuserlogdatetime_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecusername2_Visible = 1;
         tblTablemergeddynamicfilterssecuserlogdatetime2_Visible = 1;
         cellSecuserlogdatetime_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecusername1_Visible = 1;
         tblTablemergeddynamicfilterssecuserlogdatetime1_Visible = 1;
         edtSecUserLogDateTime_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtSecUserLogId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_secuserlogdatetimeauxdatetext_Jsonclick = "";
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
         Ddo_grid_Datalistproc = "SecUserLogWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "T|T|";
         Ddo_grid_Filterisrange = "||P";
         Ddo_grid_Filtertype = "Character|Character|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1";
         Ddo_grid_Columnids = "2:SecUserName|3:SecUserFullName|4:SecUserLogDateTime";
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
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E17762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E32762","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A559SecUserLogId","fld":"SECUSERLOGID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSecUserName_Link","ctrl":"SECUSERNAME","prop":"Link"},{"av":"edtSecUserFullName_Link","ctrl":"SECUSERFULLNAME","prop":"Link"},{"av":"edtSecUserLogDateTime_Link","ctrl":"SECUSERLOGDATETIME","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E22762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E18762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E23762","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"}]}""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER1.DATERANGECHANGED","""{"handler":"E14762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER1.DATERANGECHANGED",""","oparms":[{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","""{"handler":"E24762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",""","oparms":[{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E25762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E19762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E26762","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"}]}""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER2.DATERANGECHANGED","""{"handler":"E15762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER2.DATERANGECHANGED",""","oparms":[{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","""{"handler":"E27762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",""","oparms":[{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E20762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E28762","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"}]}""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER3.DATERANGECHANGED","""{"handler":"E16762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("SECUSERLOGDATETIME_RANGEPICKER3.DATERANGECHANGED",""","oparms":[{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","""{"handler":"E29762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",""","oparms":[{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11762","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV49DDO_SecUserLogDateTimeAuxDate","fld":"vDDO_SECUSERLOGDATETIMEAUXDATE","type":"date"},{"av":"AV50DDO_SecUserLogDateTimeAuxDateTo","fld":"vDDO_SECUSERLOGDATETIMEAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV49DDO_SecUserLogDateTimeAuxDate","fld":"vDDO_SECUSERLOGDATETIMEAUXDATE","type":"date"},{"av":"AV50DDO_SecUserLogDateTimeAuxDateTo","fld":"vDDO_SECUSERLOGDATETIMEAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E21762","iparms":[{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV49DDO_SecUserLogDateTimeAuxDate","fld":"vDDO_SECUSERLOGDATETIMEAUXDATE","type":"date"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV50DDO_SecUserLogDateTimeAuxDateTo","fld":"vDDO_SECUSERLOGDATETIMEAUXDATETO","type":"date"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV52SecUserLogDateTime1","fld":"vSECUSERLOGDATETIME1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV54SecUserLogDateTime2","fld":"vSECUSERLOGDATETIME2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV56SecUserLogDateTime3","fld":"vSECUSERLOGDATETIME3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV53SecUserLogDateTime_To1","fld":"vSECUSERLOGDATETIME_TO1","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV55SecUserLogDateTime_To2","fld":"vSECUSERLOGDATETIME_TO2","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV57SecUserLogDateTime_To3","fld":"vSECUSERLOGDATETIME_TO3","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserFullName","fld":"vTFSECUSERFULLNAME","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserFullName_Sel","fld":"vTFSECUSERFULLNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV47TFSecUserLogDateTime","fld":"vTFSECUSERLOGDATETIME","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV48TFSecUserLogDateTime_To","fld":"vTFSECUSERLOGDATETIME_TO","pic":"99/99/9999 99:99","type":"dtime"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV49DDO_SecUserLogDateTimeAuxDate","fld":"vDDO_SECUSERLOGDATETIMEAUXDATE","type":"date"},{"av":"AV50DDO_SecUserLogDateTimeAuxDateTo","fld":"vDDO_SECUSERLOGDATETIMEAUXDATETO","type":"date"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime1_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME1","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime2_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME2","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"tblTablemergeddynamicfilterssecuserlogdatetime3_Visible","ctrl":"TABLEMERGEDDYNAMICFILTERSSECUSERLOGDATETIME3","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"cellSecuserlogdatetime_range_cell1_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL1","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell2_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL2","prop":"Class"},{"av":"cellSecuserlogdatetime_range_cell3_Class","ctrl":"SECUSERLOGDATETIME_RANGE_CELL3","prop":"Class"}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secuserlogdatetime","iparms":[]}""");
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
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV19SecUserName1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV24SecUserName2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV29SecUserName3 = "";
         AV52SecUserLogDateTime1 = (DateTime)(DateTime.MinValue);
         AV54SecUserLogDateTime2 = (DateTime)(DateTime.MinValue);
         AV56SecUserLogDateTime3 = (DateTime)(DateTime.MinValue);
         AV61Pgmname = "";
         AV53SecUserLogDateTime_To1 = (DateTime)(DateTime.MinValue);
         AV55SecUserLogDateTime_To2 = (DateTime)(DateTime.MinValue);
         AV57SecUserLogDateTime_To3 = (DateTime)(DateTime.MinValue);
         AV38TFSecUserName = "";
         AV39TFSecUserName_Sel = "";
         AV40TFSecUserFullName = "";
         AV41TFSecUserFullName_Sel = "";
         AV47TFSecUserLogDateTime = (DateTime)(DateTime.MinValue);
         AV48TFSecUserLogDateTime_To = (DateTime)(DateTime.MinValue);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV49DDO_SecUserLogDateTimeAuxDate = DateTime.MinValue;
         AV50DDO_SecUserLogDateTimeAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ucDvpanel_tableheader = new GXUserControl();
         TempTags = "";
         ClassString = "";
         StyleString = "";
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
         ucSecuserlogdatetime_rangepicker1 = new GXUserControl();
         ucSecuserlogdatetime_rangepicker2 = new GXUserControl();
         ucSecuserlogdatetime_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV51DDO_SecUserLogDateTimeAuxDateText = "";
         ucTfsecuserlogdatetime_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         lV62Secuserlogwwds_1_filterfulltext = "";
         lV67Secuserlogwwds_6_secusername1 = "";
         lV73Secuserlogwwds_12_secusername2 = "";
         lV79Secuserlogwwds_18_secusername3 = "";
         lV80Secuserlogwwds_19_tfsecusername = "";
         lV82Secuserlogwwds_21_tfsecuserfullname = "";
         AV62Secuserlogwwds_1_filterfulltext = "";
         AV63Secuserlogwwds_2_dynamicfiltersselector1 = "";
         AV65Secuserlogwwds_4_secuserlogdatetime1 = (DateTime)(DateTime.MinValue);
         AV66Secuserlogwwds_5_secuserlogdatetime_to1 = (DateTime)(DateTime.MinValue);
         AV67Secuserlogwwds_6_secusername1 = "";
         AV69Secuserlogwwds_8_dynamicfiltersselector2 = "";
         AV71Secuserlogwwds_10_secuserlogdatetime2 = (DateTime)(DateTime.MinValue);
         AV72Secuserlogwwds_11_secuserlogdatetime_to2 = (DateTime)(DateTime.MinValue);
         AV73Secuserlogwwds_12_secusername2 = "";
         AV75Secuserlogwwds_14_dynamicfiltersselector3 = "";
         AV77Secuserlogwwds_16_secuserlogdatetime3 = (DateTime)(DateTime.MinValue);
         AV78Secuserlogwwds_17_secuserlogdatetime_to3 = (DateTime)(DateTime.MinValue);
         AV79Secuserlogwwds_18_secusername3 = "";
         AV81Secuserlogwwds_20_tfsecusername_sel = "";
         AV80Secuserlogwwds_19_tfsecusername = "";
         AV83Secuserlogwwds_22_tfsecuserfullname_sel = "";
         AV82Secuserlogwwds_21_tfsecuserfullname = "";
         AV84Secuserlogwwds_23_tfsecuserlogdatetime = (DateTime)(DateTime.MinValue);
         AV85Secuserlogwwds_24_tfsecuserlogdatetime_to = (DateTime)(DateTime.MinValue);
         H00762_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         H00762_n560SecUserLogDateTime = new bool[] {false} ;
         H00762_A143SecUserFullName = new string[] {""} ;
         H00762_n143SecUserFullName = new bool[] {false} ;
         H00762_A141SecUserName = new string[] {""} ;
         H00762_n141SecUserName = new bool[] {false} ;
         H00762_A133SecUserId = new short[1] ;
         H00762_n133SecUserId = new bool[] {false} ;
         H00762_A559SecUserLogId = new int[1] ;
         H00763_AGRID_nRecordCount = new long[1] ;
         AV58SecUserLogDateTime_RangeText1 = "";
         AV59SecUserLogDateTime_RangeText2 = "";
         AV60SecUserLogDateTime_RangeText3 = "";
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV36ManageFiltersXml = "";
         AV32ExcelFilename = "";
         AV33ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV34Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char4 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserlogww__default(),
            new Object[][] {
                new Object[] {
               H00762_A560SecUserLogDateTime, H00762_n560SecUserLogDateTime, H00762_A143SecUserFullName, H00762_n143SecUserFullName, H00762_A141SecUserName, H00762_n141SecUserName, H00762_A133SecUserId, H00762_n133SecUserId, H00762_A559SecUserLogId
               }
               , new Object[] {
               H00763_AGRID_nRecordCount
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "SecUserLogWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "SecUserLogWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV37ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A133SecUserId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV64Secuserlogwwds_3_dynamicfiltersoperator1 ;
      private short AV70Secuserlogwwds_9_dynamicfiltersoperator2 ;
      private short AV76Secuserlogwwds_15_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_123 ;
      private int nGXsfl_123_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A559SecUserLogId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecUserLogId_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtSecUserLogDateTime_Enabled ;
      private int AV43PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int tblTablemergeddynamicfilterssecuserlogdatetime1_Visible ;
      private int edtavSecusername1_Visible ;
      private int tblTablemergeddynamicfilterssecuserlogdatetime2_Visible ;
      private int edtavSecusername2_Visible ;
      private int tblTablemergeddynamicfilterssecuserlogdatetime3_Visible ;
      private int edtavSecusername3_Visible ;
      private int AV87GXV1 ;
      private int edtavSecusername3_Enabled ;
      private int edtavSecuserlogdatetime_rangetext3_Enabled ;
      private int edtavSecusername2_Enabled ;
      private int edtavSecuserlogdatetime_rangetext2_Enabled ;
      private int edtavSecusername1_Enabled ;
      private int edtavSecuserlogdatetime_rangetext1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV44GridCurrentPage ;
      private long AV45GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_123_idx="0001" ;
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
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
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
      private string Secuserlogdatetime_rangepicker1_Internalname ;
      private string Secuserlogdatetime_rangepicker2_Internalname ;
      private string Secuserlogdatetime_rangepicker3_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_secuserlogdatetimeauxdates_Internalname ;
      private string edtavDdo_secuserlogdatetimeauxdatetext_Internalname ;
      private string edtavDdo_secuserlogdatetimeauxdatetext_Jsonclick ;
      private string Tfsecuserlogdatetime_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSecUserLogId_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserFullName_Internalname ;
      private string edtSecUserLogDateTime_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavSecuserlogdatetime_rangetext1_Internalname ;
      private string edtavSecusername1_Internalname ;
      private string edtavSecuserlogdatetime_rangetext2_Internalname ;
      private string edtavSecusername2_Internalname ;
      private string edtavSecuserlogdatetime_rangetext3_Internalname ;
      private string edtavSecusername3_Internalname ;
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
      private string GXEncryptionTmp ;
      private string edtSecUserFullName_Link ;
      private string edtSecUserLogDateTime_Link ;
      private string tblTablemergeddynamicfilterssecuserlogdatetime1_Internalname ;
      private string cellSecuserlogdatetime_range_cell1_Class ;
      private string cellSecuserlogdatetime_range_cell1_Internalname ;
      private string tblTablemergeddynamicfilterssecuserlogdatetime2_Internalname ;
      private string cellSecuserlogdatetime_range_cell2_Class ;
      private string cellSecuserlogdatetime_range_cell2_Internalname ;
      private string tblTablemergeddynamicfilterssecuserlogdatetime3_Internalname ;
      private string cellSecuserlogdatetime_range_cell3_Class ;
      private string cellSecuserlogdatetime_range_cell3_Internalname ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secuserlogdatetime3_cell_Internalname ;
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string edtavSecuserlogdatetime_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secuserlogdatetime2_cell_Internalname ;
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string edtavSecuserlogdatetime_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secuserlogdatetime1_cell_Internalname ;
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string edtavSecuserlogdatetime_rangetext1_Jsonclick ;
      private string sGXsfl_123_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSecUserLogId_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtSecUserLogDateTime_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV52SecUserLogDateTime1 ;
      private DateTime AV54SecUserLogDateTime2 ;
      private DateTime AV56SecUserLogDateTime3 ;
      private DateTime AV53SecUserLogDateTime_To1 ;
      private DateTime AV55SecUserLogDateTime_To2 ;
      private DateTime AV57SecUserLogDateTime_To3 ;
      private DateTime AV47TFSecUserLogDateTime ;
      private DateTime AV48TFSecUserLogDateTime_To ;
      private DateTime A560SecUserLogDateTime ;
      private DateTime AV65Secuserlogwwds_4_secuserlogdatetime1 ;
      private DateTime AV66Secuserlogwwds_5_secuserlogdatetime_to1 ;
      private DateTime AV71Secuserlogwwds_10_secuserlogdatetime2 ;
      private DateTime AV72Secuserlogwwds_11_secuserlogdatetime_to2 ;
      private DateTime AV77Secuserlogwwds_16_secuserlogdatetime3 ;
      private DateTime AV78Secuserlogwwds_17_secuserlogdatetime_to3 ;
      private DateTime AV84Secuserlogwwds_23_tfsecuserlogdatetime ;
      private DateTime AV85Secuserlogwwds_24_tfsecuserlogdatetime_to ;
      private DateTime Gx_date ;
      private DateTime AV49DDO_SecUserLogDateTimeAuxDate ;
      private DateTime AV50DDO_SecUserLogDateTimeAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
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
      private bool n133SecUserId ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n560SecUserLogDateTime ;
      private bool bGXsfl_123_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV68Secuserlogwwds_7_dynamicfiltersenabled2 ;
      private bool AV74Secuserlogwwds_13_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV36ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV19SecUserName1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV24SecUserName2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV29SecUserName3 ;
      private string AV38TFSecUserName ;
      private string AV39TFSecUserName_Sel ;
      private string AV40TFSecUserFullName ;
      private string AV41TFSecUserFullName_Sel ;
      private string AV46GridAppliedFilters ;
      private string AV51DDO_SecUserLogDateTimeAuxDateText ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string lV62Secuserlogwwds_1_filterfulltext ;
      private string lV67Secuserlogwwds_6_secusername1 ;
      private string lV73Secuserlogwwds_12_secusername2 ;
      private string lV79Secuserlogwwds_18_secusername3 ;
      private string lV80Secuserlogwwds_19_tfsecusername ;
      private string lV82Secuserlogwwds_21_tfsecuserfullname ;
      private string AV62Secuserlogwwds_1_filterfulltext ;
      private string AV63Secuserlogwwds_2_dynamicfiltersselector1 ;
      private string AV67Secuserlogwwds_6_secusername1 ;
      private string AV69Secuserlogwwds_8_dynamicfiltersselector2 ;
      private string AV73Secuserlogwwds_12_secusername2 ;
      private string AV75Secuserlogwwds_14_dynamicfiltersselector3 ;
      private string AV79Secuserlogwwds_18_secusername3 ;
      private string AV81Secuserlogwwds_20_tfsecusername_sel ;
      private string AV80Secuserlogwwds_19_tfsecusername ;
      private string AV83Secuserlogwwds_22_tfsecuserfullname_sel ;
      private string AV82Secuserlogwwds_21_tfsecuserfullname ;
      private string AV58SecUserLogDateTime_RangeText1 ;
      private string AV59SecUserLogDateTime_RangeText2 ;
      private string AV60SecUserLogDateTime_RangeText3 ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucSecuserlogdatetime_rangepicker1 ;
      private GXUserControl ucSecuserlogdatetime_rangepicker2 ;
      private GXUserControl ucSecuserlogdatetime_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfsecuserlogdatetime_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00762_A560SecUserLogDateTime ;
      private bool[] H00762_n560SecUserLogDateTime ;
      private string[] H00762_A143SecUserFullName ;
      private bool[] H00762_n143SecUserFullName ;
      private string[] H00762_A141SecUserName ;
      private bool[] H00762_n141SecUserName ;
      private short[] H00762_A133SecUserId ;
      private bool[] H00762_n133SecUserId ;
      private int[] H00762_A559SecUserLogId ;
      private long[] H00763_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuserlogww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00762( IGxContext context ,
                                             string AV62Secuserlogwwds_1_filterfulltext ,
                                             string AV63Secuserlogwwds_2_dynamicfiltersselector1 ,
                                             short AV64Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV65Secuserlogwwds_4_secuserlogdatetime1 ,
                                             DateTime AV66Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                             string AV67Secuserlogwwds_6_secusername1 ,
                                             bool AV68Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                             string AV69Secuserlogwwds_8_dynamicfiltersselector2 ,
                                             short AV70Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV71Secuserlogwwds_10_secuserlogdatetime2 ,
                                             DateTime AV72Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                             string AV73Secuserlogwwds_12_secusername2 ,
                                             bool AV74Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                             string AV75Secuserlogwwds_14_dynamicfiltersselector3 ,
                                             short AV76Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV77Secuserlogwwds_16_secuserlogdatetime3 ,
                                             DateTime AV78Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                             string AV79Secuserlogwwds_18_secusername3 ,
                                             string AV81Secuserlogwwds_20_tfsecusername_sel ,
                                             string AV80Secuserlogwwds_19_tfsecusername ,
                                             string AV83Secuserlogwwds_22_tfsecuserfullname_sel ,
                                             string AV82Secuserlogwwds_21_tfsecuserfullname ,
                                             DateTime AV84Secuserlogwwds_23_tfsecuserlogdatetime ,
                                             DateTime AV85Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             DateTime A560SecUserLogDateTime ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[29];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecUserLogDateTime, T2.SecUserFullName, T2.SecUserName, T1.SecUserId, T1.SecUserLogId";
         sFromString = " FROM (SecUserLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV62Secuserlogwwds_1_filterfulltext) or ( T2.SecUserFullName like '%' || :lV62Secuserlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV65Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV65Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV66Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV66Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV66Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV66Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV71Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV71Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV72Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV72Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV72Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV72Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV73Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV73Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV77Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV77Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV78Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV78Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV78Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV78Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV79Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV79Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_20_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_19_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV80Secuserlogwwds_19_tfsecusername)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_20_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV81Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV81Secuserlogwwds_20_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserlogwwds_22_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_21_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName like :lV82Secuserlogwwds_21_tfsecuserfullname)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserlogwwds_22_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV83Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName = ( :AV83Secuserlogwwds_22_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserFullName))=0))");
         }
         if ( ! (DateTime.MinValue==AV84Secuserlogwwds_23_tfsecuserlogdatetime) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV84Secuserlogwwds_23_tfsecuserlogdatetime)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Secuserlogwwds_24_tfsecuserlogdatetime_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV85Secuserlogwwds_24_tfsecuserlogdatetime_to)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecUserLogDateTime, T1.SecUserLogId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecUserLogDateTime DESC, T1.SecUserLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserName, T1.SecUserLogId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserName DESC, T1.SecUserLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserFullName, T1.SecUserLogId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserFullName DESC, T1.SecUserLogId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecUserLogId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00763( IGxContext context ,
                                             string AV62Secuserlogwwds_1_filterfulltext ,
                                             string AV63Secuserlogwwds_2_dynamicfiltersselector1 ,
                                             short AV64Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV65Secuserlogwwds_4_secuserlogdatetime1 ,
                                             DateTime AV66Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                             string AV67Secuserlogwwds_6_secusername1 ,
                                             bool AV68Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                             string AV69Secuserlogwwds_8_dynamicfiltersselector2 ,
                                             short AV70Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV71Secuserlogwwds_10_secuserlogdatetime2 ,
                                             DateTime AV72Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                             string AV73Secuserlogwwds_12_secusername2 ,
                                             bool AV74Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                             string AV75Secuserlogwwds_14_dynamicfiltersselector3 ,
                                             short AV76Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV77Secuserlogwwds_16_secuserlogdatetime3 ,
                                             DateTime AV78Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                             string AV79Secuserlogwwds_18_secusername3 ,
                                             string AV81Secuserlogwwds_20_tfsecusername_sel ,
                                             string AV80Secuserlogwwds_19_tfsecusername ,
                                             string AV83Secuserlogwwds_22_tfsecuserfullname_sel ,
                                             string AV82Secuserlogwwds_21_tfsecuserfullname ,
                                             DateTime AV84Secuserlogwwds_23_tfsecuserlogdatetime ,
                                             DateTime AV85Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             DateTime A560SecUserLogDateTime ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[26];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecUserLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Secuserlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV62Secuserlogwwds_1_filterfulltext) or ( T2.SecUserFullName like '%' || :lV62Secuserlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV65Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV65Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV65Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV66Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV66Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV66Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV66Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV67Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV64Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV67Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV71Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV71Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV71Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV72Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV72Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV72Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV72Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV73Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV68Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV70Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV73Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV77Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV77Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV77Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV78Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV78Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV78Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV78Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV79Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV74Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV76Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV79Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_20_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Secuserlogwwds_19_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV80Secuserlogwwds_19_tfsecusername)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Secuserlogwwds_20_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV81Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV81Secuserlogwwds_20_tfsecusername_sel))");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserlogwwds_22_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Secuserlogwwds_21_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName like :lV82Secuserlogwwds_21_tfsecuserfullname)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Secuserlogwwds_22_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV83Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName = ( :AV83Secuserlogwwds_22_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserFullName))=0))");
         }
         if ( ! (DateTime.MinValue==AV84Secuserlogwwds_23_tfsecuserlogdatetime) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV84Secuserlogwwds_23_tfsecuserlogdatetime)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Secuserlogwwds_24_tfsecuserlogdatetime_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV85Secuserlogwwds_24_tfsecuserlogdatetime_to)");
         }
         else
         {
            GXv_int7[25] = 1;
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

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00762(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
               case 1 :
                     return conditional_H00763(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmH00762;
          prmH00762 = new Object[] {
          new ParDef("lV62Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV66Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("AV66Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("lV67Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV67Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV71Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV72Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("AV72Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("lV73Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV73Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV77Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV78Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("AV78Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("lV79Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV79Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV80Secuserlogwwds_19_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV81Secuserlogwwds_20_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Secuserlogwwds_21_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV83Secuserlogwwds_22_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("AV84Secuserlogwwds_23_tfsecuserlogdatetime",GXType.DateTime,10,5) ,
          new ParDef("AV85Secuserlogwwds_24_tfsecuserlogdatetime_to",GXType.DateTime,10,5) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00763;
          prmH00763 = new Object[] {
          new ParDef("lV62Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV65Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV66Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("AV66Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("lV67Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV67Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV71Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV71Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV72Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("AV72Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("lV73Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV73Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV77Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV77Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV78Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("AV78Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("lV79Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV79Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV80Secuserlogwwds_19_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV81Secuserlogwwds_20_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Secuserlogwwds_21_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV83Secuserlogwwds_22_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("AV84Secuserlogwwds_23_tfsecuserlogdatetime",GXType.DateTime,10,5) ,
          new ParDef("AV85Secuserlogwwds_24_tfsecuserlogdatetime_to",GXType.DateTime,10,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00762", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00762,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00763", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00763,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
