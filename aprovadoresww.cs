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
   public class aprovadoresww : GXWebComponent
   {
      public aprovadoresww( )
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

      public aprovadoresww( IGxContext context )
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
         cmbavAprovadoresstatus1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavAprovadoresstatus2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavAprovadoresstatus3 = new GXCombobox();
         cmbAprovadoresStatus = new GXCombobox();
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
         nRC_GXsfl_116 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_116"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_116_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_116_idx = GetPar( "sGXsfl_116_idx");
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
         cmbavAprovadoresstatus1.FromJSonString( GetNextPar( ));
         AV51AprovadoresStatus1 = StringUtil.StrToBool( GetPar( "AprovadoresStatus1"));
         AV19SecUserName1 = GetPar( "SecUserName1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavAprovadoresstatus2.FromJSonString( GetNextPar( ));
         AV52AprovadoresStatus2 = StringUtil.StrToBool( GetPar( "AprovadoresStatus2"));
         AV24SecUserName2 = GetPar( "SecUserName2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         cmbavAprovadoresstatus3.FromJSonString( GetNextPar( ));
         AV53AprovadoresStatus3 = StringUtil.StrToBool( GetPar( "AprovadoresStatus3"));
         AV29SecUserName3 = GetPar( "SecUserName3");
         AV37ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV55Pgmname = GetPar( "Pgmname");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV38TFSecUserName = GetPar( "TFSecUserName");
         AV39TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV40TFSecUserEmail = GetPar( "TFSecUserEmail");
         AV41TFSecUserEmail_Sel = GetPar( "TFSecUserEmail_Sel");
         AV50TFAprovadoresStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFAprovadoresStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
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
            PA5L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV55Pgmname = "AprovadoresWW";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_116_Refreshing);
               WS5L2( ) ;
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
            context.SendWebValue( " Aprovadores") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aprovadoresww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vAPROVADORESSTATUS1", StringUtil.BoolToStr( AV51AprovadoresStatus1));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME1", AV19SecUserName1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vAPROVADORESSTATUS2", StringUtil.BoolToStr( AV52AprovadoresStatus2));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME2", AV24SecUserName2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vAPROVADORESSTATUS3", StringUtil.BoolToStr( AV53AprovadoresStatus3));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSECUSERNAME3", AV29SecUserName3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_116", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_116), 8, 0, ",", "")));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERNAME", AV38TFSecUserName);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSERNAME_SEL", AV39TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSEREMAIL", AV40TFSecUserEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSECUSEREMAIL_SEL", AV41TFSecUserEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFAPROVADORESSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm5L2( )
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
         return "AprovadoresWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Aprovadores" ;
      }

      protected void WB5L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "aprovadoresww");
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
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(116), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AprovadoresWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_AprovadoresWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_5L2( true) ;
         }
         else
         {
            wb_table1_45_5L2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_5L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_70_5L2( true) ;
         }
         else
         {
            wb_table2_70_5L2( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_5L2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_95_5L2( true) ;
         }
         else
         {
            wb_table3_95_5L2( false) ;
         }
         return  ;
      }

      protected void wb_table3_95_5L2e( bool wbgen )
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
            StartGridControl116( ) ;
         }
         if ( wbEnd == 116 )
         {
            wbEnd = 0;
            nRC_GXsfl_116 = (int)(nGXsfl_116_idx-1);
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AprovadoresWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 116 )
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

      protected void START5L2( )
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
            Form.Meta.addItem("description", " Aprovadores", 0) ;
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
               STRUP5L0( ) ;
            }
         }
      }

      protected void WS5L2( )
      {
         START5L2( ) ;
         EVT5L2( ) ;
      }

      protected void EVT5L2( )
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
                                 STRUP5L0( ) ;
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
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E115L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E125L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E135L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E145L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E155L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E165L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E175L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E185L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E195L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E205L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E215L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E225L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E235L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E245L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavUpdate_Internalname;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5L0( ) ;
                              }
                              nGXsfl_116_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
                              SubsflControlProps_1162( ) ;
                              AV48Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV48Update);
                              A375AprovadoresId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAprovadoresId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n133SecUserId = false;
                              A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
                              n141SecUserName = false;
                              A144SecUserEmail = cgiGet( edtSecUserEmail_Internalname);
                              n144SecUserEmail = false;
                              cmbAprovadoresStatus.Name = cmbAprovadoresStatus_Internalname;
                              cmbAprovadoresStatus.CurrentValue = cgiGet( cmbAprovadoresStatus_Internalname);
                              A380AprovadoresStatus = StringUtil.StrToBool( cgiGet( cmbAprovadoresStatus_Internalname));
                              n380AprovadoresStatus = false;
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
                                          GX_FocusControl = edtavUpdate_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E255L2 ();
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
                                          GX_FocusControl = edtavUpdate_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E265L2 ();
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
                                          GX_FocusControl = edtavUpdate_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E275L2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VUPDATE.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUpdate_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E285L2 ();
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
                                             /* Set Refresh If Aprovadoresstatus1 Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS1")) != AV51AprovadoresStatus1 )
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
                                             /* Set Refresh If Aprovadoresstatus2 Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS2")) != AV52AprovadoresStatus2 )
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
                                             /* Set Refresh If Aprovadoresstatus3 Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS3")) != AV53AprovadoresStatus3 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Secusername3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME3"), AV29SecUserName3) != 0 )
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
                                       STRUP5L0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavUpdate_Internalname;
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

      protected void WE5L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5L2( ) ;
            }
         }
      }

      protected void PA5L2( )
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
         SubsflControlProps_1162( ) ;
         while ( nGXsfl_116_idx <= nRC_GXsfl_116 )
         {
            sendrow_1162( ) ;
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
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
                                       bool AV51AprovadoresStatus1 ,
                                       string AV19SecUserName1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       bool AV52AprovadoresStatus2 ,
                                       string AV24SecUserName2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       bool AV53AprovadoresStatus3 ,
                                       string AV29SecUserName3 ,
                                       short AV37ManageFiltersExecutionStep ,
                                       string AV55Pgmname ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV38TFSecUserName ,
                                       string AV39TFSecUserName_Sel ,
                                       string AV40TFSecUserEmail ,
                                       string AV41TFSecUserEmail_Sel ,
                                       short AV50TFAprovadoresStatus_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_APROVADORESID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"APROVADORESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", "")));
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
         if ( cmbavAprovadoresstatus1.ItemCount > 0 )
         {
            AV51AprovadoresStatus1 = StringUtil.StrToBool( cmbavAprovadoresstatus1.getValidValue(StringUtil.BoolToStr( AV51AprovadoresStatus1)));
            AssignAttri(sPrefix, false, "AV51AprovadoresStatus1", AV51AprovadoresStatus1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
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
         if ( cmbavAprovadoresstatus2.ItemCount > 0 )
         {
            AV52AprovadoresStatus2 = StringUtil.StrToBool( cmbavAprovadoresstatus2.getValidValue(StringUtil.BoolToStr( AV52AprovadoresStatus2)));
            AssignAttri(sPrefix, false, "AV52AprovadoresStatus2", AV52AprovadoresStatus2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
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
         if ( cmbavAprovadoresstatus3.ItemCount > 0 )
         {
            AV53AprovadoresStatus3 = StringUtil.StrToBool( cmbavAprovadoresstatus3.getValidValue(StringUtil.BoolToStr( AV53AprovadoresStatus3)));
            AssignAttri(sPrefix, false, "AV53AprovadoresStatus3", AV53AprovadoresStatus3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "AprovadoresWW";
         edtavUpdate_Enabled = 0;
      }

      protected void RF5L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 116;
         /* Execute user event: Refresh */
         E265L2 ();
         nGXsfl_116_idx = 1;
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         bGXsfl_116_Refreshing = true;
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
            SubsflControlProps_1162( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV56Aprovadoreswwds_1_filterfulltext ,
                                                 AV57Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                                 AV59Aprovadoreswwds_4_aprovadoresstatus1 ,
                                                 AV58Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                                 AV60Aprovadoreswwds_5_secusername1 ,
                                                 AV61Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                                 AV62Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                                 AV64Aprovadoreswwds_9_aprovadoresstatus2 ,
                                                 AV63Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                                 AV65Aprovadoreswwds_10_secusername2 ,
                                                 AV66Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                                 AV67Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                                 AV69Aprovadoreswwds_14_aprovadoresstatus3 ,
                                                 AV68Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                                 AV70Aprovadoreswwds_15_secusername3 ,
                                                 AV72Aprovadoreswwds_17_tfsecusername_sel ,
                                                 AV71Aprovadoreswwds_16_tfsecusername ,
                                                 AV74Aprovadoreswwds_19_tfsecuseremail_sel ,
                                                 AV73Aprovadoreswwds_18_tfsecuseremail ,
                                                 AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                                 A141SecUserName ,
                                                 A144SecUserEmail ,
                                                 A380AprovadoresStatus ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
            lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
            lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
            lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
            lV60Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1), "%", "");
            lV60Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1), "%", "");
            lV65Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2), "%", "");
            lV65Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2), "%", "");
            lV70Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3), "%", "");
            lV70Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3), "%", "");
            lV71Aprovadoreswwds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_16_tfsecusername), "%", "");
            lV73Aprovadoreswwds_18_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV73Aprovadoreswwds_18_tfsecuseremail), "%", "");
            /* Using cursor H005L2 */
            pr_default.execute(0, new Object[] {lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, AV59Aprovadoreswwds_4_aprovadoresstatus1, lV60Aprovadoreswwds_5_secusername1, lV60Aprovadoreswwds_5_secusername1, AV64Aprovadoreswwds_9_aprovadoresstatus2, lV65Aprovadoreswwds_10_secusername2, lV65Aprovadoreswwds_10_secusername2, AV69Aprovadoreswwds_14_aprovadoresstatus3, lV70Aprovadoreswwds_15_secusername3, lV70Aprovadoreswwds_15_secusername3, lV71Aprovadoreswwds_16_tfsecusername, AV72Aprovadoreswwds_17_tfsecusername_sel, lV73Aprovadoreswwds_18_tfsecuseremail, AV74Aprovadoreswwds_19_tfsecuseremail_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_116_idx = 1;
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A380AprovadoresStatus = H005L2_A380AprovadoresStatus[0];
               n380AprovadoresStatus = H005L2_n380AprovadoresStatus[0];
               A144SecUserEmail = H005L2_A144SecUserEmail[0];
               n144SecUserEmail = H005L2_n144SecUserEmail[0];
               A141SecUserName = H005L2_A141SecUserName[0];
               n141SecUserName = H005L2_n141SecUserName[0];
               A133SecUserId = H005L2_A133SecUserId[0];
               n133SecUserId = H005L2_n133SecUserId[0];
               A375AprovadoresId = H005L2_A375AprovadoresId[0];
               A144SecUserEmail = H005L2_A144SecUserEmail[0];
               n144SecUserEmail = H005L2_n144SecUserEmail[0];
               A141SecUserName = H005L2_A141SecUserName[0];
               n141SecUserName = H005L2_n141SecUserName[0];
               /* Execute user event: Grid.Load */
               E275L2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 116;
            WB5L0( ) ;
         }
         bGXsfl_116_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5L2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_APROVADORESID"+"_"+sGXsfl_116_idx, GetSecureSignedToken( sPrefix+sGXsfl_116_idx, context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9"), context));
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
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV56Aprovadoreswwds_1_filterfulltext ,
                                              AV57Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                              AV59Aprovadoreswwds_4_aprovadoresstatus1 ,
                                              AV58Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                              AV60Aprovadoreswwds_5_secusername1 ,
                                              AV61Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                              AV62Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                              AV64Aprovadoreswwds_9_aprovadoresstatus2 ,
                                              AV63Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                              AV65Aprovadoreswwds_10_secusername2 ,
                                              AV66Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                              AV67Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                              AV69Aprovadoreswwds_14_aprovadoresstatus3 ,
                                              AV68Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                              AV70Aprovadoreswwds_15_secusername3 ,
                                              AV72Aprovadoreswwds_17_tfsecusername_sel ,
                                              AV71Aprovadoreswwds_16_tfsecusername ,
                                              AV74Aprovadoreswwds_19_tfsecuseremail_sel ,
                                              AV73Aprovadoreswwds_18_tfsecuseremail ,
                                              AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A380AprovadoresStatus ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
         lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
         lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
         lV56Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext), "%", "");
         lV60Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1), "%", "");
         lV60Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1), "%", "");
         lV65Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2), "%", "");
         lV65Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2), "%", "");
         lV70Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3), "%", "");
         lV70Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3), "%", "");
         lV71Aprovadoreswwds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV71Aprovadoreswwds_16_tfsecusername), "%", "");
         lV73Aprovadoreswwds_18_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV73Aprovadoreswwds_18_tfsecuseremail), "%", "");
         /* Using cursor H005L3 */
         pr_default.execute(1, new Object[] {lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, lV56Aprovadoreswwds_1_filterfulltext, AV59Aprovadoreswwds_4_aprovadoresstatus1, lV60Aprovadoreswwds_5_secusername1, lV60Aprovadoreswwds_5_secusername1, AV64Aprovadoreswwds_9_aprovadoresstatus2, lV65Aprovadoreswwds_10_secusername2, lV65Aprovadoreswwds_10_secusername2, AV69Aprovadoreswwds_14_aprovadoresstatus3, lV70Aprovadoreswwds_15_secusername3, lV70Aprovadoreswwds_15_secusername3, lV71Aprovadoreswwds_16_tfsecusername, AV72Aprovadoreswwds_17_tfsecusername_sel, lV73Aprovadoreswwds_18_tfsecuseremail, AV74Aprovadoreswwds_19_tfsecuseremail_sel});
         GRID_nRecordCount = H005L3_AGRID_nRecordCount[0];
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
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "AprovadoresWW";
         edtavUpdate_Enabled = 0;
         edtAprovadoresId_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         cmbAprovadoresStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E255L2 ();
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
            nRC_GXsfl_116 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_116"), ",", "."), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
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
            cmbavAprovadoresstatus1.Name = cmbavAprovadoresstatus1_Internalname;
            cmbavAprovadoresstatus1.CurrentValue = cgiGet( cmbavAprovadoresstatus1_Internalname);
            AV51AprovadoresStatus1 = StringUtil.StrToBool( cgiGet( cmbavAprovadoresstatus1_Internalname));
            AssignAttri(sPrefix, false, "AV51AprovadoresStatus1", AV51AprovadoresStatus1);
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
            cmbavAprovadoresstatus2.Name = cmbavAprovadoresstatus2_Internalname;
            cmbavAprovadoresstatus2.CurrentValue = cgiGet( cmbavAprovadoresstatus2_Internalname);
            AV52AprovadoresStatus2 = StringUtil.StrToBool( cgiGet( cmbavAprovadoresstatus2_Internalname));
            AssignAttri(sPrefix, false, "AV52AprovadoresStatus2", AV52AprovadoresStatus2);
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
            cmbavAprovadoresstatus3.Name = cmbavAprovadoresstatus3_Internalname;
            cmbavAprovadoresstatus3.CurrentValue = cgiGet( cmbavAprovadoresstatus3_Internalname);
            AV53AprovadoresStatus3 = StringUtil.StrToBool( cgiGet( cmbavAprovadoresstatus3_Internalname));
            AssignAttri(sPrefix, false, "AV53AprovadoresStatus3", AV53AprovadoresStatus3);
            AV29SecUserName3 = StringUtil.Upper( cgiGet( edtavSecusername3_Internalname));
            AssignAttri(sPrefix, false, "AV29SecUserName3", AV29SecUserName3);
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
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS1")) != AV51AprovadoresStatus1 )
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
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS2")) != AV52AprovadoresStatus2 )
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
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vAPROVADORESSTATUS3")) != AV53AprovadoresStatus3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSECUSERNAME3"), AV29SecUserName3) != 0 )
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
         E255L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E255L2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         AV51AprovadoresStatus1 = false;
         AssignAttri(sPrefix, false, "AV51AprovadoresStatus1", AV51AprovadoresStatus1);
         AV16DynamicFiltersSelector1 = "APROVADORESSTATUS";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV52AprovadoresStatus2 = false;
         AssignAttri(sPrefix, false, "AV52AprovadoresStatus2", AV52AprovadoresStatus2);
         AV21DynamicFiltersSelector2 = "APROVADORESSTATUS";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV53AprovadoresStatus3 = false;
         AssignAttri(sPrefix, false, "AV53AprovadoresStatus3", AV53AprovadoresStatus3);
         AV26DynamicFiltersSelector3 = "APROVADORESSTATUS";
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

      protected void E265L2( )
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV55Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         cmbAprovadoresStatus_Columnheaderclass = "WWColumn";
         AssignProp(sPrefix, false, cmbAprovadoresStatus_Internalname, "Columnheaderclass", cmbAprovadoresStatus_Columnheaderclass, !bGXsfl_116_Refreshing);
         AV56Aprovadoreswwds_1_filterfulltext = AV15FilterFullText;
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV58Aprovadoreswwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV59Aprovadoreswwds_4_aprovadoresstatus1 = AV51AprovadoresStatus1;
         AV60Aprovadoreswwds_5_secusername1 = AV19SecUserName1;
         AV61Aprovadoreswwds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Aprovadoreswwds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Aprovadoreswwds_9_aprovadoresstatus2 = AV52AprovadoresStatus2;
         AV65Aprovadoreswwds_10_secusername2 = AV24SecUserName2;
         AV66Aprovadoreswwds_11_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Aprovadoreswwds_13_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Aprovadoreswwds_14_aprovadoresstatus3 = AV53AprovadoresStatus3;
         AV70Aprovadoreswwds_15_secusername3 = AV29SecUserName3;
         AV71Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV72Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV73Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV50TFAprovadoresStatus_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E125L2( )
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

      protected void E135L2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E145L2( )
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
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserEmail") == 0 )
            {
               AV40TFSecUserEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV40TFSecUserEmail", AV40TFSecUserEmail);
               AV41TFSecUserEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV41TFSecUserEmail_Sel", AV41TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AprovadoresStatus") == 0 )
            {
               AV50TFAprovadoresStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV50TFAprovadoresStatus_Sel", StringUtil.Str( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E275L2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV48Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV48Update);
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
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "true") == 0 )
         {
            cmbAprovadoresStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "false") == 0 )
         {
            cmbAprovadoresStatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
         }
         else
         {
            cmbAprovadoresStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 116;
         }
         sendrow_1162( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_116_Refreshing )
         {
            DoAjaxLoad(116, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E205L2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E155L2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E215L2( )
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

      protected void E225L2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E165L2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E235L2( )
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

      protected void E175L2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV51AprovadoresStatus1, AV19SecUserName1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV52AprovadoresStatus2, AV24SecUserName2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV53AprovadoresStatus3, AV29SecUserName3, AV37ManageFiltersExecutionStep, AV55Pgmname, AV20DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV38TFSecUserName, AV39TFSecUserName_Sel, AV40TFSecUserEmail, AV41TFSecUserEmail_Sel, AV50TFAprovadoresStatus_Sel, AV10GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E245L2( )
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

      protected void E115L2( )
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("AprovadoresWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV55Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("AprovadoresWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV37ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV37ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV37ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV36ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "AprovadoresWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV36ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV36ManageFiltersXml) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
      }

      protected void E285L2( )
      {
         /* Update_Click Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "aprovadores"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A375AprovadoresId,9,0));
         context.PopUp(formatLink("aprovadores") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E185L2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "aprovadores"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("aprovadores") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ManageFiltersData", AV35ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E195L2( )
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
         new aprovadoreswwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", cmbavAprovadoresstatus1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", cmbavAprovadoresstatus2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", cmbavAprovadoresstatus3.ToJavascriptSource(), true);
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
         cmbavAprovadoresstatus1.Visible = 0;
         AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus1.Visible), 5, 0), true);
         edtavSecusername1_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "APROVADORESSTATUS") == 0 )
         {
            cmbavAprovadoresstatus1.Visible = 1;
            AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavAprovadoresstatus2.Visible = 0;
         AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus2.Visible), 5, 0), true);
         edtavSecusername2_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "APROVADORESSTATUS") == 0 )
         {
            cmbavAprovadoresstatus2.Visible = 1;
            AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavAprovadoresstatus3.Visible = 0;
         AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus3.Visible), 5, 0), true);
         edtavSecusername3_Visible = 0;
         AssignProp(sPrefix, false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "APROVADORESSTATUS") == 0 )
         {
            cmbavAprovadoresstatus3.Visible = 1;
            AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAprovadoresstatus3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp(sPrefix, false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "APROVADORESSTATUS";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV52AprovadoresStatus2 = false;
         AssignAttri(sPrefix, false, "AV52AprovadoresStatus2", AV52AprovadoresStatus2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "APROVADORESSTATUS";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV53AprovadoresStatus3 = false;
         AssignAttri(sPrefix, false, "AV53AprovadoresStatus3", AV53AprovadoresStatus3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "AprovadoresWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV35ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV38TFSecUserName = "";
         AssignAttri(sPrefix, false, "AV38TFSecUserName", AV38TFSecUserName);
         AV39TFSecUserName_Sel = "";
         AssignAttri(sPrefix, false, "AV39TFSecUserName_Sel", AV39TFSecUserName_Sel);
         AV40TFSecUserEmail = "";
         AssignAttri(sPrefix, false, "AV40TFSecUserEmail", AV40TFSecUserEmail);
         AV41TFSecUserEmail_Sel = "";
         AssignAttri(sPrefix, false, "AV41TFSecUserEmail_Sel", AV41TFSecUserEmail_Sel);
         AV50TFAprovadoresStatus_Sel = 0;
         AssignAttri(sPrefix, false, "AV50TFAprovadoresStatus_Sel", StringUtil.Str( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "APROVADORESSTATUS";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV51AprovadoresStatus1 = false;
         AssignAttri(sPrefix, false, "AV51AprovadoresStatus1", AV51AprovadoresStatus1);
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
         if ( StringUtil.StrCmp(AV34Session.Get(AV55Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV55Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV34Session.Get(AV55Pgmname+"GridState"), null, "", "");
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
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV76GXV1));
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
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV40TFSecUserEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFSecUserEmail", AV40TFSecUserEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV41TFSecUserEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFSecUserEmail_Sel", AV41TFSecUserEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFAPROVADORESSTATUS_SEL") == 0 )
            {
               AV50TFAprovadoresStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV50TFAprovadoresStatus_Sel", StringUtil.Str( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0));
            }
            AV76GXV1 = (int)(AV76GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail_Sel)),  AV41TFSecUserEmail_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+((0==AV50TFAprovadoresStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  AV38TFSecUserName, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserEmail)),  AV40TFSecUserEmail, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char2+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S212( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "APROVADORESSTATUS") == 0 )
            {
               AV51AprovadoresStatus1 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
               AssignAttri(sPrefix, false, "AV51AprovadoresStatus1", AV51AprovadoresStatus1);
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
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "APROVADORESSTATUS") == 0 )
               {
                  AV52AprovadoresStatus2 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                  AssignAttri(sPrefix, false, "AV52AprovadoresStatus2", AV52AprovadoresStatus2);
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
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "APROVADORESSTATUS") == 0 )
                  {
                     AV53AprovadoresStatus3 = BooleanUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value);
                     AssignAttri(sPrefix, false, "AV53AprovadoresStatus3", AV53AprovadoresStatus3);
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
         AV10GridState.FromXml(AV34Session.Get(AV55Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSERNAME",  "Usu�rio",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)),  0,  AV38TFSecUserName,  AV38TFSecUserName,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)),  AV39TFSecUserName_Sel,  AV39TFSecUserName_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSECUSEREMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserEmail)),  0,  AV40TFSecUserEmail,  AV40TFSecUserEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail_Sel)),  AV41TFSecUserEmail_Sel,  AV41TFSecUserEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFAPROVADORESSTATUS_SEL",  "Status",  !(0==AV50TFAprovadoresStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV50TFAprovadoresStatus_Sel), 1, 0)),  ((AV50TFAprovadoresStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "APROVADORESSTATUS") == 0 ) && ! (false==AV51AprovadoresStatus1) )
            {
               AV54AuxText = "[" + StringUtil.Trim( StringUtil.BoolToStr( AV51AprovadoresStatus1)) + "]";
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV51AprovadoresStatus1)),  StringUtil.StringReplace( StringUtil.StringReplace( AV54AuxText, "[true]", "Ativo"), "[false]", "Inativo"),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SecUserName1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usu�rio",  AV17DynamicFiltersOperator1,  AV19SecUserName1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Come�a com"+" "+AV19SecUserName1, "Cont�m"+" "+AV19SecUserName1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "APROVADORESSTATUS") == 0 ) && ! (false==AV52AprovadoresStatus2) )
            {
               AV54AuxText = "[" + StringUtil.Trim( StringUtil.BoolToStr( AV52AprovadoresStatus2)) + "]";
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV52AprovadoresStatus2)),  StringUtil.StringReplace( StringUtil.StringReplace( AV54AuxText, "[true]", "Ativo"), "[false]", "Inativo"),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SecUserName2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usu�rio",  AV22DynamicFiltersOperator2,  AV24SecUserName2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "Come�a com"+" "+AV24SecUserName2, "Cont�m"+" "+AV24SecUserName2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "APROVADORESSTATUS") == 0 ) && ! (false==AV53AprovadoresStatus3) )
            {
               AV54AuxText = "[" + StringUtil.Trim( StringUtil.BoolToStr( AV53AprovadoresStatus3)) + "]";
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Status",  0,  StringUtil.Trim( StringUtil.BoolToStr( AV53AprovadoresStatus3)),  StringUtil.StringReplace( StringUtil.StringReplace( AV54AuxText, "[true]", "Ativo"), "[false]", "Inativo"),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Usu�rio",  AV27DynamicFiltersOperator3,  AV29SecUserName3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Come�a com"+" "+AV29SecUserName3, "Cont�m"+" "+AV29SecUserName3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV55Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Aprovadores";
         AV34Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_95_5L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_aprovadoresstatus3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAprovadoresstatus3_Internalname, "Aprovadores Status3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAprovadoresstatus3, cmbavAprovadoresstatus3_Internalname, StringUtil.BoolToStr( AV53AprovadoresStatus3), 1, cmbavAprovadoresstatus3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavAprovadoresstatus3.Visible, cmbavAprovadoresstatus3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavAprovadoresstatus3.CurrentValue = StringUtil.BoolToStr( AV53AprovadoresStatus3);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus3_Internalname, "Values", (string)(cmbavAprovadoresstatus3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, "Sec User Name3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV29SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV29SecUserName3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,105);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AprovadoresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_95_5L2e( true) ;
         }
         else
         {
            wb_table3_95_5L2e( false) ;
         }
      }

      protected void wb_table2_70_5L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_aprovadoresstatus2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAprovadoresstatus2_Internalname, "Aprovadores Status2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAprovadoresstatus2, cmbavAprovadoresstatus2_Internalname, StringUtil.BoolToStr( AV52AprovadoresStatus2), 1, cmbavAprovadoresstatus2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavAprovadoresstatus2.Visible, cmbavAprovadoresstatus2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavAprovadoresstatus2.CurrentValue = StringUtil.BoolToStr( AV52AprovadoresStatus2);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus2_Internalname, "Values", (string)(cmbavAprovadoresstatus2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, "Sec User Name2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV24SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV24SecUserName2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,80);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AprovadoresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AprovadoresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_5L2e( true) ;
         }
         else
         {
            wb_table2_70_5L2e( false) ;
         }
      }

      protected void wb_table1_45_5L2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_aprovadoresstatus1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAprovadoresstatus1_Internalname, "Aprovadores Status1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAprovadoresstatus1, cmbavAprovadoresstatus1_Internalname, StringUtil.BoolToStr( AV51AprovadoresStatus1), 1, cmbavAprovadoresstatus1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavAprovadoresstatus1.Visible, cmbavAprovadoresstatus1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_AprovadoresWW.htm");
            cmbavAprovadoresstatus1.CurrentValue = StringUtil.BoolToStr( AV51AprovadoresStatus1);
            AssignProp(sPrefix, false, cmbavAprovadoresstatus1_Internalname, "Values", (string)(cmbavAprovadoresstatus1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, "Sec User Name1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV19SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV19SecUserName1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AprovadoresWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AprovadoresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AprovadoresWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_5L2e( true) ;
         }
         else
         {
            wb_table1_45_5L2e( false) ;
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
         PA5L2( ) ;
         WS5L2( ) ;
         WE5L2( ) ;
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
         PA5L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "aprovadoresww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5L2( ) ;
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
         PA5L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5L2( ) ;
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
         WS5L2( ) ;
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
         WE5L2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164315", true, true);
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
         context.AddJavascriptSource("aprovadoresww.js", "?202561019164316", false, true);
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

      protected void SubsflControlProps_1162( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_116_idx;
         edtAprovadoresId_Internalname = sPrefix+"APROVADORESID_"+sGXsfl_116_idx;
         edtSecUserId_Internalname = sPrefix+"SECUSERID_"+sGXsfl_116_idx;
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME_"+sGXsfl_116_idx;
         edtSecUserEmail_Internalname = sPrefix+"SECUSEREMAIL_"+sGXsfl_116_idx;
         cmbAprovadoresStatus_Internalname = sPrefix+"APROVADORESSTATUS_"+sGXsfl_116_idx;
      }

      protected void SubsflControlProps_fel_1162( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_116_fel_idx;
         edtAprovadoresId_Internalname = sPrefix+"APROVADORESID_"+sGXsfl_116_fel_idx;
         edtSecUserId_Internalname = sPrefix+"SECUSERID_"+sGXsfl_116_fel_idx;
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME_"+sGXsfl_116_fel_idx;
         edtSecUserEmail_Internalname = sPrefix+"SECUSEREMAIL_"+sGXsfl_116_fel_idx;
         cmbAprovadoresStatus_Internalname = sPrefix+"APROVADORESSTATUS_"+sGXsfl_116_fel_idx;
      }

      protected void sendrow_1162( )
      {
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         WB5L0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_116_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_116_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_116_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'" + sPrefix + "',false,'" + sGXsfl_116_idx + "',116)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV48Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,117);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUPDATE.CLICK."+sGXsfl_116_idx+"'",(string)"",(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAprovadoresId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A375AprovadoresId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAprovadoresId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A141SecUserName,StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserEmail_Internalname,(string)A144SecUserEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A144SecUserEmail,(string)"",(string)"",(string)"",(string)edtSecUserEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)116,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAprovadoresStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "APROVADORESSTATUS_" + sGXsfl_116_idx;
               cmbAprovadoresStatus.Name = GXCCtl;
               cmbAprovadoresStatus.WebTags = "";
               cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbAprovadoresStatus.ItemCount > 0 )
               {
                  A380AprovadoresStatus = StringUtil.StrToBool( cmbAprovadoresStatus.getValidValue(StringUtil.BoolToStr( A380AprovadoresStatus)));
                  n380AprovadoresStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAprovadoresStatus,(string)cmbAprovadoresStatus_Internalname,StringUtil.BoolToStr( A380AprovadoresStatus),(short)1,(string)cmbAprovadoresStatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbAprovadoresStatus_Columnclass,(string)cmbAprovadoresStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbAprovadoresStatus.CurrentValue = StringUtil.BoolToStr( A380AprovadoresStatus);
            AssignProp(sPrefix, false, cmbAprovadoresStatus_Internalname, "Values", (string)(cmbAprovadoresStatus.ToJavascriptSource()), !bGXsfl_116_Refreshing);
            send_integrity_lvl_hashes5L2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_116_idx = ((subGrid_Islastpage==1)&&(nGXsfl_116_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         /* End function sendrow_1162 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("APROVADORESSTATUS", "Status", 0);
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", "Usu�rio", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavAprovadoresstatus1.Name = "vAPROVADORESSTATUS1";
         cmbavAprovadoresstatus1.WebTags = "";
         cmbavAprovadoresstatus1.addItem(StringUtil.BoolToStr( false), "Todos", 0);
         cmbavAprovadoresstatus1.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbavAprovadoresstatus1.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbavAprovadoresstatus1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("APROVADORESSTATUS", "Status", 0);
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", "Usu�rio", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavAprovadoresstatus2.Name = "vAPROVADORESSTATUS2";
         cmbavAprovadoresstatus2.WebTags = "";
         cmbavAprovadoresstatus2.addItem(StringUtil.BoolToStr( false), "Todos", 0);
         cmbavAprovadoresstatus2.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbavAprovadoresstatus2.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbavAprovadoresstatus2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("APROVADORESSTATUS", "Status", 0);
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", "Usu�rio", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Come�a com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Cont�m", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         cmbavAprovadoresstatus3.Name = "vAPROVADORESSTATUS3";
         cmbavAprovadoresstatus3.WebTags = "";
         cmbavAprovadoresstatus3.addItem(StringUtil.BoolToStr( false), "Todos", 0);
         cmbavAprovadoresstatus3.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbavAprovadoresstatus3.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbavAprovadoresstatus3.ItemCount > 0 )
         {
         }
         GXCCtl = "APROVADORESSTATUS_" + sGXsfl_116_idx;
         cmbAprovadoresStatus.Name = GXCCtl;
         cmbAprovadoresStatus.WebTags = "";
         cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbAprovadoresStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbAprovadoresStatus.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl116( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"116\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Usu�rio") ;
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
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV48Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A375AprovadoresId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A141SecUserName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A144SecUserEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A380AprovadoresStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbAprovadoresStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbAprovadoresStatus_Columnheaderclass));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
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
         cmbavAprovadoresstatus1_Internalname = sPrefix+"vAPROVADORESSTATUS1";
         cellFilter_aprovadoresstatus1_cell_Internalname = sPrefix+"FILTER_APROVADORESSTATUS1_CELL";
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
         cmbavAprovadoresstatus2_Internalname = sPrefix+"vAPROVADORESSTATUS2";
         cellFilter_aprovadoresstatus2_cell_Internalname = sPrefix+"FILTER_APROVADORESSTATUS2_CELL";
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
         cmbavAprovadoresstatus3_Internalname = sPrefix+"vAPROVADORESSTATUS3";
         cellFilter_aprovadoresstatus3_cell_Internalname = sPrefix+"FILTER_APROVADORESSTATUS3_CELL";
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
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtAprovadoresId_Internalname = sPrefix+"APROVADORESID";
         edtSecUserId_Internalname = sPrefix+"SECUSERID";
         edtSecUserName_Internalname = sPrefix+"SECUSERNAME";
         edtSecUserEmail_Internalname = sPrefix+"SECUSEREMAIL";
         cmbAprovadoresStatus_Internalname = sPrefix+"APROVADORESSTATUS";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         lblJsdynamicfilters_Internalname = sPrefix+"JSDYNAMICFILTERS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
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
         cmbAprovadoresStatus_Jsonclick = "";
         cmbAprovadoresStatus_Columnclass = "WWColumn";
         edtSecUserEmail_Jsonclick = "";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Link = "";
         edtSecUserId_Jsonclick = "";
         edtAprovadoresId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
         cmbavAprovadoresstatus1_Jsonclick = "";
         cmbavAprovadoresstatus1.Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
         cmbavAprovadoresstatus2_Jsonclick = "";
         cmbavAprovadoresstatus2.Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
         cmbavAprovadoresstatus3_Jsonclick = "";
         cmbavAprovadoresstatus3.Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavSecusername3_Visible = 1;
         cmbavAprovadoresstatus3.Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavSecusername2_Visible = 1;
         cmbavAprovadoresstatus2.Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavSecusername1_Visible = 1;
         cmbavAprovadoresstatus1.Visible = 1;
         cmbAprovadoresStatus_Columnheaderclass = "";
         cmbAprovadoresStatus.Enabled = 0;
         edtSecUserEmail_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserId_Enabled = 0;
         edtAprovadoresId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = "L;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "AprovadoresWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|";
         Ddo_grid_Includefilter = "T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1";
         Ddo_grid_Columnids = "3:SecUserName|4:SecUserEmail|5:AprovadoresStatus";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P�gina <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Dvpanel_tableheader_Title = "Op��es";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E125L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E135L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E145L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E275L2","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"cmbAprovadoresStatus"},{"av":"A380AprovadoresStatus","fld":"APROVADORESSTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV48Update","fld":"vUPDATE","type":"char"},{"av":"edtSecUserName_Link","ctrl":"SECUSERNAME","prop":"Link"},{"av":"cmbAprovadoresStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E205L2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E155L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E215L2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavAprovadoresstatus1"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E225L2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E165L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E235L2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavAprovadoresstatus2"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E175L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E245L2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavAprovadoresstatus3"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E115L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E285L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A375AprovadoresId","fld":"APROVADORESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E185L2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A375AprovadoresId","fld":"APROVADORESID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAprovadoresStatus"},{"av":"AV35ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E195L2","iparms":[{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus1"},{"av":"AV51AprovadoresStatus1","fld":"vAPROVADORESSTATUS1","type":"boolean"},{"av":"AV19SecUserName1","fld":"vSECUSERNAME1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus2"},{"av":"AV52AprovadoresStatus2","fld":"vAPROVADORESSTATUS2","type":"boolean"},{"av":"AV24SecUserName2","fld":"vSECUSERNAME2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"cmbavAprovadoresstatus3"},{"av":"AV53AprovadoresStatus3","fld":"vAPROVADORESSTATUS3","type":"boolean"},{"av":"AV29SecUserName3","fld":"vSECUSERNAME3","pic":"@!","type":"svchar"},{"av":"AV37ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV38TFSecUserName","fld":"vTFSECUSERNAME","pic":"@!","type":"svchar"},{"av":"AV39TFSecUserName_Sel","fld":"vTFSECUSERNAME_SEL","pic":"@!","type":"svchar"},{"av":"AV40TFSecUserEmail","fld":"vTFSECUSEREMAIL","type":"svchar"},{"av":"AV41TFSecUserEmail_Sel","fld":"vTFSECUSEREMAIL_SEL","type":"svchar"},{"av":"AV50TFAprovadoresStatus_Sel","fld":"vTFAPROVADORESSTATUS_SEL","pic":"9","type":"int"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavSecusername1_Visible","ctrl":"vSECUSERNAME1","prop":"Visible"},{"av":"edtavSecusername2_Visible","ctrl":"vSECUSERNAME2","prop":"Visible"},{"av":"edtavSecusername3_Visible","ctrl":"vSECUSERNAME3","prop":"Visible"}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Aprovadoresstatus","iparms":[]}""");
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
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV19SecUserName1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV24SecUserName2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV29SecUserName3 = "";
         AV55Pgmname = "";
         AV38TFSecUserName = "";
         AV39TFSecUserName_Sel = "";
         AV40TFSecUserEmail = "";
         AV41TFSecUserEmail_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV35ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
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
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV48Update = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         lV56Aprovadoreswwds_1_filterfulltext = "";
         lV60Aprovadoreswwds_5_secusername1 = "";
         lV65Aprovadoreswwds_10_secusername2 = "";
         lV70Aprovadoreswwds_15_secusername3 = "";
         lV71Aprovadoreswwds_16_tfsecusername = "";
         lV73Aprovadoreswwds_18_tfsecuseremail = "";
         AV56Aprovadoreswwds_1_filterfulltext = "";
         AV57Aprovadoreswwds_2_dynamicfiltersselector1 = "";
         AV60Aprovadoreswwds_5_secusername1 = "";
         AV62Aprovadoreswwds_7_dynamicfiltersselector2 = "";
         AV65Aprovadoreswwds_10_secusername2 = "";
         AV67Aprovadoreswwds_12_dynamicfiltersselector3 = "";
         AV70Aprovadoreswwds_15_secusername3 = "";
         AV72Aprovadoreswwds_17_tfsecusername_sel = "";
         AV71Aprovadoreswwds_16_tfsecusername = "";
         AV74Aprovadoreswwds_19_tfsecuseremail_sel = "";
         AV73Aprovadoreswwds_18_tfsecuseremail = "";
         H005L2_A380AprovadoresStatus = new bool[] {false} ;
         H005L2_n380AprovadoresStatus = new bool[] {false} ;
         H005L2_A144SecUserEmail = new string[] {""} ;
         H005L2_n144SecUserEmail = new bool[] {false} ;
         H005L2_A141SecUserName = new string[] {""} ;
         H005L2_n141SecUserName = new bool[] {false} ;
         H005L2_A133SecUserId = new short[1] ;
         H005L2_n133SecUserId = new bool[] {false} ;
         H005L2_A375AprovadoresId = new int[1] ;
         H005L3_AGRID_nRecordCount = new long[1] ;
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
         AV54AuxText = "";
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadoresww__default(),
            new Object[][] {
                new Object[] {
               H005L2_A380AprovadoresStatus, H005L2_n380AprovadoresStatus, H005L2_A144SecUserEmail, H005L2_n144SecUserEmail, H005L2_A141SecUserName, H005L2_n141SecUserName, H005L2_A133SecUserId, H005L2_n133SecUserId, H005L2_A375AprovadoresId
               }
               , new Object[] {
               H005L3_AGRID_nRecordCount
               }
            }
         );
         AV55Pgmname = "AprovadoresWW";
         /* GeneXus formulas. */
         AV55Pgmname = "AprovadoresWW";
         edtavUpdate_Enabled = 0;
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
      private short AV50TFAprovadoresStatus_Sel ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A133SecUserId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV58Aprovadoreswwds_3_dynamicfiltersoperator1 ;
      private short AV63Aprovadoreswwds_8_dynamicfiltersoperator2 ;
      private short AV68Aprovadoreswwds_13_dynamicfiltersoperator3 ;
      private short AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_116 ;
      private int nGXsfl_116_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A375AprovadoresId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAprovadoresId_Enabled ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserEmail_Enabled ;
      private int AV43PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavSecusername1_Visible ;
      private int edtavSecusername2_Visible ;
      private int edtavSecusername3_Visible ;
      private int AV76GXV1 ;
      private int edtavSecusername3_Enabled ;
      private int edtavSecusername2_Enabled ;
      private int edtavSecusername1_Enabled ;
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
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_116_idx="0001" ;
      private string AV55Pgmname ;
      private string edtavUpdate_Internalname ;
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
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV48Update ;
      private string edtAprovadoresId_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserEmail_Internalname ;
      private string cmbAprovadoresStatus_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavAprovadoresstatus1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavAprovadoresstatus2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string cmbavAprovadoresstatus3_Internalname ;
      private string edtavSecusername1_Internalname ;
      private string edtavSecusername2_Internalname ;
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
      private string cmbAprovadoresStatus_Columnheaderclass ;
      private string edtSecUserName_Link ;
      private string GXEncryptionTmp ;
      private string cmbAprovadoresStatus_Columnclass ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_aprovadoresstatus3_cell_Internalname ;
      private string cmbavAprovadoresstatus3_Jsonclick ;
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_aprovadoresstatus2_cell_Internalname ;
      private string cmbavAprovadoresstatus2_Jsonclick ;
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_aprovadoresstatus1_cell_Internalname ;
      private string cmbavAprovadoresstatus1_Jsonclick ;
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_116_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtAprovadoresId_Jsonclick ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserEmail_Jsonclick ;
      private string GXCCtl ;
      private string cmbAprovadoresStatus_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV51AprovadoresStatus1 ;
      private bool AV52AprovadoresStatus2 ;
      private bool AV53AprovadoresStatus3 ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV31DynamicFiltersIgnoreFirst ;
      private bool AV30DynamicFiltersRemoving ;
      private bool bGXsfl_116_Refreshing=false ;
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
      private bool n144SecUserEmail ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV59Aprovadoreswwds_4_aprovadoresstatus1 ;
      private bool AV61Aprovadoreswwds_6_dynamicfiltersenabled2 ;
      private bool AV64Aprovadoreswwds_9_aprovadoresstatus2 ;
      private bool AV66Aprovadoreswwds_11_dynamicfiltersenabled3 ;
      private bool AV69Aprovadoreswwds_14_aprovadoresstatus3 ;
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
      private string AV40TFSecUserEmail ;
      private string AV41TFSecUserEmail_Sel ;
      private string AV46GridAppliedFilters ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
      private string lV56Aprovadoreswwds_1_filterfulltext ;
      private string lV60Aprovadoreswwds_5_secusername1 ;
      private string lV65Aprovadoreswwds_10_secusername2 ;
      private string lV70Aprovadoreswwds_15_secusername3 ;
      private string lV71Aprovadoreswwds_16_tfsecusername ;
      private string lV73Aprovadoreswwds_18_tfsecuseremail ;
      private string AV56Aprovadoreswwds_1_filterfulltext ;
      private string AV57Aprovadoreswwds_2_dynamicfiltersselector1 ;
      private string AV60Aprovadoreswwds_5_secusername1 ;
      private string AV62Aprovadoreswwds_7_dynamicfiltersselector2 ;
      private string AV65Aprovadoreswwds_10_secusername2 ;
      private string AV67Aprovadoreswwds_12_dynamicfiltersselector3 ;
      private string AV70Aprovadoreswwds_15_secusername3 ;
      private string AV72Aprovadoreswwds_17_tfsecusername_sel ;
      private string AV71Aprovadoreswwds_16_tfsecusername ;
      private string AV74Aprovadoreswwds_19_tfsecuseremail_sel ;
      private string AV73Aprovadoreswwds_18_tfsecuseremail ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV54AuxText ;
      private IGxSession AV34Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavAprovadoresstatus1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavAprovadoresstatus2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavAprovadoresstatus3 ;
      private GXCombobox cmbAprovadoresStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV35ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private bool[] H005L2_A380AprovadoresStatus ;
      private bool[] H005L2_n380AprovadoresStatus ;
      private string[] H005L2_A144SecUserEmail ;
      private bool[] H005L2_n144SecUserEmail ;
      private string[] H005L2_A141SecUserName ;
      private bool[] H005L2_n141SecUserName ;
      private short[] H005L2_A133SecUserId ;
      private bool[] H005L2_n133SecUserId ;
      private int[] H005L2_A375AprovadoresId ;
      private long[] H005L3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class aprovadoresww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005L2( IGxContext context ,
                                             string AV56Aprovadoreswwds_1_filterfulltext ,
                                             string AV57Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                             bool AV59Aprovadoreswwds_4_aprovadoresstatus1 ,
                                             short AV58Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Aprovadoreswwds_5_secusername1 ,
                                             bool AV61Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                             string AV62Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                             bool AV64Aprovadoreswwds_9_aprovadoresstatus2 ,
                                             short AV63Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                             string AV65Aprovadoreswwds_10_secusername2 ,
                                             bool AV66Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                             string AV67Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                             bool AV69Aprovadoreswwds_14_aprovadoresstatus3 ,
                                             short AV68Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                             string AV70Aprovadoreswwds_15_secusername3 ,
                                             string AV72Aprovadoreswwds_17_tfsecusername_sel ,
                                             string AV71Aprovadoreswwds_16_tfsecusername ,
                                             string AV74Aprovadoreswwds_19_tfsecuseremail_sel ,
                                             string AV73Aprovadoreswwds_18_tfsecuseremail ,
                                             short AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A380AprovadoresStatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.AprovadoresStatus, T2.SecUserEmail, T2.SecUserName, T1.SecUserId, T1.AprovadoresId";
         sFromString = " FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV56Aprovadoreswwds_1_filterfulltext) or ( T2.SecUserEmail like '%' || :lV56Aprovadoreswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV56Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV56Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV59Aprovadoreswwds_4_aprovadoresstatus1) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV59Aprovadoreswwds_4_aprovadoresstatus1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV58Aprovadoreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV60Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV58Aprovadoreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV60Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV64Aprovadoreswwds_9_aprovadoresstatus2) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV64Aprovadoreswwds_9_aprovadoresstatus2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV63Aprovadoreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV63Aprovadoreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV69Aprovadoreswwds_14_aprovadoresstatus3) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV69Aprovadoreswwds_14_aprovadoresstatus3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV68Aprovadoreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV70Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV68Aprovadoreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV70Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Aprovadoreswwds_16_tfsecusername)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV72Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV72Aprovadoreswwds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV72Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_19_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_18_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail like :lV73Aprovadoreswwds_18_tfsecuseremail)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_19_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV74Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail = ( :AV74Aprovadoreswwds_19_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T2.SecUserEmail))=0))");
         }
         if ( AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = TRUE)");
         }
         if ( AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = FALSE)");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AprovadoresStatus, T1.AprovadoresId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AprovadoresStatus DESC, T1.AprovadoresId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserName, T1.AprovadoresId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserName DESC, T1.AprovadoresId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecUserEmail, T1.AprovadoresId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecUserEmail DESC, T1.AprovadoresId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AprovadoresId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H005L3( IGxContext context ,
                                             string AV56Aprovadoreswwds_1_filterfulltext ,
                                             string AV57Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                             bool AV59Aprovadoreswwds_4_aprovadoresstatus1 ,
                                             short AV58Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Aprovadoreswwds_5_secusername1 ,
                                             bool AV61Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                             string AV62Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                             bool AV64Aprovadoreswwds_9_aprovadoresstatus2 ,
                                             short AV63Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                             string AV65Aprovadoreswwds_10_secusername2 ,
                                             bool AV66Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                             string AV67Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                             bool AV69Aprovadoreswwds_14_aprovadoresstatus3 ,
                                             short AV68Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                             string AV70Aprovadoreswwds_15_secusername3 ,
                                             string AV72Aprovadoreswwds_17_tfsecusername_sel ,
                                             string AV71Aprovadoreswwds_16_tfsecusername ,
                                             string AV74Aprovadoreswwds_19_tfsecuseremail_sel ,
                                             string AV73Aprovadoreswwds_18_tfsecuseremail ,
                                             short AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A380AprovadoresStatus ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Aprovadoreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV56Aprovadoreswwds_1_filterfulltext) or ( T2.SecUserEmail like '%' || :lV56Aprovadoreswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV56Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV56Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = FALSE))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV59Aprovadoreswwds_4_aprovadoresstatus1) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV59Aprovadoreswwds_4_aprovadoresstatus1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV58Aprovadoreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV60Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV58Aprovadoreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV60Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV64Aprovadoreswwds_9_aprovadoresstatus2) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV64Aprovadoreswwds_9_aprovadoresstatus2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV63Aprovadoreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV65Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV61Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV63Aprovadoreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV65Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV69Aprovadoreswwds_14_aprovadoresstatus3) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV69Aprovadoreswwds_14_aprovadoresstatus3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV68Aprovadoreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV70Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV66Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV68Aprovadoreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV70Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Aprovadoreswwds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV71Aprovadoreswwds_16_tfsecusername)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Aprovadoreswwds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV72Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV72Aprovadoreswwds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV72Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_19_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Aprovadoreswwds_18_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail like :lV73Aprovadoreswwds_18_tfsecuseremail)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Aprovadoreswwds_19_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV74Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail = ( :AV74Aprovadoreswwds_19_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV74Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T2.SecUserEmail))=0))");
         }
         if ( AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = TRUE)");
         }
         if ( AV75Aprovadoreswwds_20_tfaprovadoresstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = FALSE)");
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
                     return conditional_H005L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H005L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmH005L2;
          prmH005L2 = new Object[] {
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Aprovadoreswwds_4_aprovadoresstatus1",GXType.Boolean,4,0) ,
          new ParDef("lV60Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV64Aprovadoreswwds_9_aprovadoresstatus2",GXType.Boolean,4,0) ,
          new ParDef("lV65Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV65Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV69Aprovadoreswwds_14_aprovadoresstatus3",GXType.Boolean,4,0) ,
          new ParDef("lV70Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Aprovadoreswwds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV72Aprovadoreswwds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Aprovadoreswwds_18_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV74Aprovadoreswwds_19_tfsecuseremail_sel",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005L3;
          prmH005L3 = new Object[] {
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV59Aprovadoreswwds_4_aprovadoresstatus1",GXType.Boolean,4,0) ,
          new ParDef("lV60Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV60Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV64Aprovadoreswwds_9_aprovadoresstatus2",GXType.Boolean,4,0) ,
          new ParDef("lV65Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV65Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV69Aprovadoreswwds_14_aprovadoresstatus3",GXType.Boolean,4,0) ,
          new ParDef("lV70Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV71Aprovadoreswwds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV72Aprovadoreswwds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV73Aprovadoreswwds_18_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV74Aprovadoreswwds_19_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L3,1, GxCacheFrequency.OFF ,true,false )
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
