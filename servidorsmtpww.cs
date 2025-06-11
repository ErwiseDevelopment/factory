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
   public class servidorsmtpww : GXWebComponent
   {
      public servidorsmtpww( )
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

      public servidorsmtpww( IGxContext context )
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
         nRC_GXsfl_102 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_102"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_102_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_102_idx = GetPar( "sGXsfl_102_idx");
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
         AV18ServidorSMTPServer1 = GetPar( "ServidorSMTPServer1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22ServidorSMTPServer2 = GetPar( "ServidorSMTPServer2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26ServidorSMTPServer3 = GetPar( "ServidorSMTPServer3");
         AV32ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV33TFServidorSMTPServer = GetPar( "TFServidorSMTPServer");
         AV34TFServidorSMTPServer_Sel = GetPar( "TFServidorSMTPServer_Sel");
         AV35TFServidorSMTPPorta = GetPar( "TFServidorSMTPPorta");
         AV36TFServidorSMTPPorta_Sel = GetPar( "TFServidorSMTPPorta_Sel");
         AV37TFServidorSMTPEmail = GetPar( "TFServidorSMTPEmail");
         AV38TFServidorSMTPEmail_Sel = GetPar( "TFServidorSMTPEmail_Sel");
         AV39TFServidorSMTPUsuario = GetPar( "TFServidorSMTPUsuario");
         AV40TFServidorSMTPUsuario_Sel = GetPar( "TFServidorSMTPUsuario_Sel");
         AV63Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
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
            PA562( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV63Pgmname = "ServidorSMTPWW";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_102_Refreshing);
               WS562( ) ;
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
            context.SendWebValue( " Servidor SMTP") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("servidorsmtpww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERVIDORSMTPSERVER1", AV18ServidorSMTPServer1);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERVIDORSMTPSERVER2", AV22ServidorSMTPServer2);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vSERVIDORSMTPSERVER3", AV26ServidorSMTPServer3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_102", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_102), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV30ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV41DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPSERVER", AV33TFServidorSMTPServer);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPSERVER_SEL", AV34TFServidorSMTPServer_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPPORTA", AV35TFServidorSMTPPorta);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPPORTA_SEL", AV36TFServidorSMTPPorta_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPEMAIL", AV37TFServidorSMTPEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPEMAIL_SEL", AV38TFServidorSMTPEmail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPUSUARIO", AV39TFServidorSMTPUsuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERVIDORSMTPUSUARIO_SEL", AV40TFServidorSMTPUsuario_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm562( )
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
         return "ServidorSMTPWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Servidor SMTP" ;
      }

      protected void WB560( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "servidorsmtpww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(102), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ServidorSMTPWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV30ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_ServidorSMTPWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_562( true) ;
         }
         else
         {
            wb_table1_43_562( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_562e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_65_562( true) ;
         }
         else
         {
            wb_table2_65_562( false) ;
         }
         return  ;
      }

      protected void wb_table2_65_562e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_87_562( true) ;
         }
         else
         {
            wb_table3_87_562( false) ;
         }
         return  ;
      }

      protected void wb_table3_87_562e( bool wbgen )
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
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl102( ) ;
         }
         if ( wbEnd == 102 )
         {
            wbEnd = 0;
            nRC_GXsfl_102 = (int)(nGXsfl_102_idx-1);
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_ServidorSMTPWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV41DDO_TitleSettingsIcons);
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
         if ( wbEnd == 102 )
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

      protected void START562( )
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
            Form.Meta.addItem("description", " Servidor SMTP", 0) ;
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
               STRUP560( ) ;
            }
         }
      }

      protected void WS562( )
      {
         START562( ) ;
         EVT562( ) ;
      }

      protected void EVT562( )
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
                                 STRUP560( ) ;
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
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E11562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E12562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters1' */
                                    E13562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters2' */
                                    E14562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'RemoveDynamicFilters3' */
                                    E15562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E16562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters1' */
                                    E17562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E18562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'AddDynamicFilters2' */
                                    E19562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21562 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
                              AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
                              AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
                              AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
                              AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
                              AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
                              AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
                              AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
                              AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
                              AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
                              AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
                              AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
                              AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
                              AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
                              AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
                              AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
                              AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
                              AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
                              AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
                              AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VUPDATE.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP560( ) ;
                              }
                              nGXsfl_102_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
                              SubsflControlProps_1022( ) ;
                              AV42Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV42Update);
                              A158ServidorSMTPId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtServidorSMTPId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A159ServidorSMTPServer = cgiGet( edtServidorSMTPServer_Internalname);
                              n159ServidorSMTPServer = false;
                              A160ServidorSMTPPorta = cgiGet( edtServidorSMTPPorta_Internalname);
                              n160ServidorSMTPPorta = false;
                              A161ServidorSMTPEmail = cgiGet( edtServidorSMTPEmail_Internalname);
                              n161ServidorSMTPEmail = false;
                              A163ServidorSMTPUsuario = cgiGet( edtServidorSMTPUsuario_Internalname);
                              n163ServidorSMTPUsuario = false;
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
                                          E22562 ();
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
                                          E23562 ();
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
                                          E24562 ();
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
                                          E25562 ();
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
                                             /* Set Refresh If Servidorsmtpserver1 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER1"), AV18ServidorSMTPServer1) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Servidorsmtpserver2 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER2"), AV22ServidorSMTPServer2) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersselector3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Servidorsmtpserver3 Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER3"), AV26ServidorSMTPServer3) != 0 )
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
                                       STRUP560( ) ;
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

      protected void WE562( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm562( ) ;
            }
         }
      }

      protected void PA562( )
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
         SubsflControlProps_1022( ) ;
         while ( nGXsfl_102_idx <= nRC_GXsfl_102 )
         {
            sendrow_1022( ) ;
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
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
                                       string AV18ServidorSMTPServer1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22ServidorSMTPServer2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26ServidorSMTPServer3 ,
                                       short AV32ManageFiltersExecutionStep ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV33TFServidorSMTPServer ,
                                       string AV34TFServidorSMTPServer_Sel ,
                                       string AV35TFServidorSMTPPorta ,
                                       string AV36TFServidorSMTPPorta_Sel ,
                                       string AV37TFServidorSMTPEmail ,
                                       string AV38TFServidorSMTPEmail_Sel ,
                                       string AV39TFServidorSMTPUsuario ,
                                       string AV40TFServidorSMTPUsuario_Sel ,
                                       string AV63Pgmname ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF562( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SERVIDORSMTPID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SERVIDORSMTPID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ServidorSMTPId), 4, 0, ".", "")));
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
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF562( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV63Pgmname = "ServidorSMTPWW";
         edtavUpdate_Enabled = 0;
      }

      protected void RF562( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 102;
         /* Execute user event: Refresh */
         E23562 ();
         nGXsfl_102_idx = 1;
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         bGXsfl_102_Refreshing = true;
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
            SubsflControlProps_1022( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV43Servidorsmtpwwds_1_filterfulltext ,
                                                 AV44Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                                 AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                                 AV46Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                                 AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                                 AV48Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                                 AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                                 AV50Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                                 AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                                 AV52Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                                 AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                                 AV54Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                                 AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                                 AV55Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                                 AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                                 AV57Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                                 AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                                 AV59Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                                 AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                                 AV61Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                                 A159ServidorSMTPServer ,
                                                 A160ServidorSMTPPorta ,
                                                 A161ServidorSMTPEmail ,
                                                 A163ServidorSMTPUsuario ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
            lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
            lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
            lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
            lV46Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
            lV46Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
            lV50Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
            lV50Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
            lV54Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
            lV54Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
            lV55Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV55Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
            lV57Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
            lV59Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV59Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
            lV61Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
            /* Using cursor H00562 */
            pr_default.execute(0, new Object[] {lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV46Servidorsmtpwwds_4_servidorsmtpserver1, lV46Servidorsmtpwwds_4_servidorsmtpserver1, lV50Servidorsmtpwwds_8_servidorsmtpserver2, lV50Servidorsmtpwwds_8_servidorsmtpserver2, lV54Servidorsmtpwwds_12_servidorsmtpserver3, lV54Servidorsmtpwwds_12_servidorsmtpserver3, lV55Servidorsmtpwwds_13_tfservidorsmtpserver, AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV57Servidorsmtpwwds_15_tfservidorsmtpporta, AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV59Servidorsmtpwwds_17_tfservidorsmtpemail, AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV61Servidorsmtpwwds_19_tfservidorsmtpusuario, AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_102_idx = 1;
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A163ServidorSMTPUsuario = H00562_A163ServidorSMTPUsuario[0];
               n163ServidorSMTPUsuario = H00562_n163ServidorSMTPUsuario[0];
               A161ServidorSMTPEmail = H00562_A161ServidorSMTPEmail[0];
               n161ServidorSMTPEmail = H00562_n161ServidorSMTPEmail[0];
               A160ServidorSMTPPorta = H00562_A160ServidorSMTPPorta[0];
               n160ServidorSMTPPorta = H00562_n160ServidorSMTPPorta[0];
               A159ServidorSMTPServer = H00562_A159ServidorSMTPServer[0];
               n159ServidorSMTPServer = H00562_n159ServidorSMTPServer[0];
               A158ServidorSMTPId = H00562_A158ServidorSMTPId[0];
               /* Execute user event: Grid.Load */
               E24562 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 102;
            WB560( ) ;
         }
         bGXsfl_102_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes562( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SERVIDORSMTPID"+"_"+sGXsfl_102_idx, GetSecureSignedToken( sPrefix+sGXsfl_102_idx, context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9"), context));
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
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV43Servidorsmtpwwds_1_filterfulltext ,
                                              AV44Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                              AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                              AV46Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                              AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                              AV48Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                              AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                              AV50Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                              AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                              AV52Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                              AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                              AV54Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                              AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                              AV55Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                              AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                              AV57Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                              AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                              AV59Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                              AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                              AV61Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                              A159ServidorSMTPServer ,
                                              A160ServidorSMTPPorta ,
                                              A161ServidorSMTPEmail ,
                                              A163ServidorSMTPUsuario ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV43Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV46Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV46Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV50Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV50Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV54Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV54Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV55Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV55Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
         lV57Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
         lV59Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV59Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
         lV61Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
         /* Using cursor H00563 */
         pr_default.execute(1, new Object[] {lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV43Servidorsmtpwwds_1_filterfulltext, lV46Servidorsmtpwwds_4_servidorsmtpserver1, lV46Servidorsmtpwwds_4_servidorsmtpserver1, lV50Servidorsmtpwwds_8_servidorsmtpserver2, lV50Servidorsmtpwwds_8_servidorsmtpserver2, lV54Servidorsmtpwwds_12_servidorsmtpserver3, lV54Servidorsmtpwwds_12_servidorsmtpserver3, lV55Servidorsmtpwwds_13_tfservidorsmtpserver, AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV57Servidorsmtpwwds_15_tfservidorsmtpporta, AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV59Servidorsmtpwwds_17_tfservidorsmtpemail, AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV61Servidorsmtpwwds_19_tfservidorsmtpusuario, AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel});
         GRID_nRecordCount = H00563_AGRID_nRecordCount[0];
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
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV63Pgmname = "ServidorSMTPWW";
         edtavUpdate_Enabled = 0;
         edtServidorSMTPId_Enabled = 0;
         edtServidorSMTPServer_Enabled = 0;
         edtServidorSMTPPorta_Enabled = 0;
         edtServidorSMTPEmail_Enabled = 0;
         edtServidorSMTPUsuario_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP560( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22562 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV30ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV41DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_102 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_102"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            AV18ServidorSMTPServer1 = cgiGet( edtavServidorsmtpserver1_Internalname);
            AssignAttri(sPrefix, false, "AV18ServidorSMTPServer1", AV18ServidorSMTPServer1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22ServidorSMTPServer2 = cgiGet( edtavServidorsmtpserver2_Internalname);
            AssignAttri(sPrefix, false, "AV22ServidorSMTPServer2", AV22ServidorSMTPServer2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26ServidorSMTPServer3 = cgiGet( edtavServidorsmtpserver3_Internalname);
            AssignAttri(sPrefix, false, "AV26ServidorSMTPServer3", AV26ServidorSMTPServer3);
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER1"), AV18ServidorSMTPServer1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER2"), AV22ServidorSMTPServer2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vSERVIDORSMTPSERVER3"), AV26ServidorSMTPServer3) != 0 )
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
         E22562 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22562( )
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
         AV16DynamicFiltersSelector1 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV41DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV41DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E23562( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV32ManageFiltersExecutionStep == 1 )
         {
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV32ManageFiltersExecutionStep == 2 )
         {
            AV32ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
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
         AV43Servidorsmtpwwds_1_filterfulltext = AV15FilterFullText;
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = AV18ServidorSMTPServer1;
         AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = AV22ServidorSMTPServer2;
         AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = AV26ServidorSMTPServer3;
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = AV33TFServidorSMTPServer;
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV34TFServidorSMTPServer_Sel;
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = AV35TFServidorSMTPPorta;
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV36TFServidorSMTPPorta_Sel;
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = AV37TFServidorSMTPEmail;
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV38TFServidorSMTPEmail_Sel;
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = AV39TFServidorSMTPUsuario;
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV40TFServidorSMTPUsuario_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E12562( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServidorSMTPServer") == 0 )
            {
               AV33TFServidorSMTPServer = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV33TFServidorSMTPServer", AV33TFServidorSMTPServer);
               AV34TFServidorSMTPServer_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV34TFServidorSMTPServer_Sel", AV34TFServidorSMTPServer_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServidorSMTPPorta") == 0 )
            {
               AV35TFServidorSMTPPorta = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFServidorSMTPPorta", AV35TFServidorSMTPPorta);
               AV36TFServidorSMTPPorta_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFServidorSMTPPorta_Sel", AV36TFServidorSMTPPorta_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServidorSMTPEmail") == 0 )
            {
               AV37TFServidorSMTPEmail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV37TFServidorSMTPEmail", AV37TFServidorSMTPEmail);
               AV38TFServidorSMTPEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV38TFServidorSMTPEmail_Sel", AV38TFServidorSMTPEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ServidorSMTPUsuario") == 0 )
            {
               AV39TFServidorSMTPUsuario = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV39TFServidorSMTPUsuario", AV39TFServidorSMTPUsuario);
               AV40TFServidorSMTPUsuario_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV40TFServidorSMTPUsuario_Sel", AV40TFServidorSMTPUsuario_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E24562( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV42Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV42Update);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "servidorsmtp"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A158ServidorSMTPId,4,0));
         edtServidorSMTPServer_Link = formatLink("servidorsmtp") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 102;
         }
         sendrow_1022( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_102_Refreshing )
         {
            DoAjaxLoad(102, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E17562( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E13562( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri(sPrefix, false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E18562( )
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

      protected void E19562( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E14562( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E20562( )
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

      protected void E15562( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AV27DynamicFiltersRemoving = false;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18ServidorSMTPServer1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22ServidorSMTPServer2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26ServidorSMTPServer3, AV32ManageFiltersExecutionStep, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV33TFServidorSMTPServer, AV34TFServidorSMTPServer_Sel, AV35TFServidorSMTPPorta, AV36TFServidorSMTPPorta_Sel, AV37TFServidorSMTPEmail, AV38TFServidorSMTPEmail_Sel, AV39TFServidorSMTPUsuario, AV40TFServidorSMTPUsuario_Sel, AV63Pgmname, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E21562( )
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

      protected void E11562( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("ServidorSMTPWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV63Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("ServidorSMTPWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV32ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV32ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV32ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV31ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "ServidorSMTPWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV31ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV31ManageFiltersXml) ;
               AV10GridState.FromXml(AV31ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp(sPrefix, false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
      }

      protected void E25562( )
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
         GXEncryptionTmp = "servidorsmtp"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A158ServidorSMTPId,4,0));
         context.PopUp(formatLink("servidorsmtp") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
      }

      protected void E16562( )
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
         GXEncryptionTmp = "servidorsmtp"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("servidorsmtp") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefreshCmp(sPrefix);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30ManageFiltersData", AV30ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10GridState", AV10GridState);
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
         edtavServidorsmtpserver1_Visible = 0;
         AssignProp(sPrefix, false, edtavServidorsmtpserver1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERVIDORSMTPSERVER") == 0 )
         {
            edtavServidorsmtpserver1_Visible = 1;
            AssignProp(sPrefix, false, edtavServidorsmtpserver1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavServidorsmtpserver2_Visible = 0;
         AssignProp(sPrefix, false, edtavServidorsmtpserver2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERVIDORSMTPSERVER") == 0 )
         {
            edtavServidorsmtpserver2_Visible = 1;
            AssignProp(sPrefix, false, edtavServidorsmtpserver2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavServidorsmtpserver3_Visible = 0;
         AssignProp(sPrefix, false, edtavServidorsmtpserver3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERVIDORSMTPSERVER") == 0 )
         {
            edtavServidorsmtpserver3_Visible = 1;
            AssignProp(sPrefix, false, edtavServidorsmtpserver3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavServidorsmtpserver3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22ServidorSMTPServer2 = "";
         AssignAttri(sPrefix, false, "AV22ServidorSMTPServer2", AV22ServidorSMTPServer2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26ServidorSMTPServer3 = "";
         AssignAttri(sPrefix, false, "AV26ServidorSMTPServer3", AV26ServidorSMTPServer3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV30ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "ServidorSMTPWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV30ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
         AV33TFServidorSMTPServer = "";
         AssignAttri(sPrefix, false, "AV33TFServidorSMTPServer", AV33TFServidorSMTPServer);
         AV34TFServidorSMTPServer_Sel = "";
         AssignAttri(sPrefix, false, "AV34TFServidorSMTPServer_Sel", AV34TFServidorSMTPServer_Sel);
         AV35TFServidorSMTPPorta = "";
         AssignAttri(sPrefix, false, "AV35TFServidorSMTPPorta", AV35TFServidorSMTPPorta);
         AV36TFServidorSMTPPorta_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFServidorSMTPPorta_Sel", AV36TFServidorSMTPPorta_Sel);
         AV37TFServidorSMTPEmail = "";
         AssignAttri(sPrefix, false, "AV37TFServidorSMTPEmail", AV37TFServidorSMTPEmail);
         AV38TFServidorSMTPEmail_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFServidorSMTPEmail_Sel", AV38TFServidorSMTPEmail_Sel);
         AV39TFServidorSMTPUsuario = "";
         AssignAttri(sPrefix, false, "AV39TFServidorSMTPUsuario", AV39TFServidorSMTPUsuario);
         AV40TFServidorSMTPUsuario_Sel = "";
         AssignAttri(sPrefix, false, "AV40TFServidorSMTPUsuario_Sel", AV40TFServidorSMTPUsuario_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "SERVIDORSMTPSERVER";
         AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18ServidorSMTPServer1 = "";
         AssignAttri(sPrefix, false, "AV18ServidorSMTPServer1", AV18ServidorSMTPServer1);
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
         if ( StringUtil.StrCmp(AV29Session.Get(AV63Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV63Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV29Session.Get(AV63Pgmname+"GridState"), null, "", "");
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
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPSERVER") == 0 )
            {
               AV33TFServidorSMTPServer = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV33TFServidorSMTPServer", AV33TFServidorSMTPServer);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPSERVER_SEL") == 0 )
            {
               AV34TFServidorSMTPServer_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFServidorSMTPServer_Sel", AV34TFServidorSMTPServer_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPPORTA") == 0 )
            {
               AV35TFServidorSMTPPorta = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFServidorSMTPPorta", AV35TFServidorSMTPPorta);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPPORTA_SEL") == 0 )
            {
               AV36TFServidorSMTPPorta_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFServidorSMTPPorta_Sel", AV36TFServidorSMTPPorta_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPEMAIL") == 0 )
            {
               AV37TFServidorSMTPEmail = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFServidorSMTPEmail", AV37TFServidorSMTPEmail);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPEMAIL_SEL") == 0 )
            {
               AV38TFServidorSMTPEmail_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFServidorSMTPEmail_Sel", AV38TFServidorSMTPEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPUSUARIO") == 0 )
            {
               AV39TFServidorSMTPUsuario = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFServidorSMTPUsuario", AV39TFServidorSMTPUsuario);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPUSUARIO_SEL") == 0 )
            {
               AV40TFServidorSMTPUsuario_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV40TFServidorSMTPUsuario_Sel", AV40TFServidorSMTPUsuario_Sel);
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFServidorSMTPServer_Sel)),  AV34TFServidorSMTPServer_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFServidorSMTPPorta_Sel)),  AV36TFServidorSMTPPorta_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFServidorSMTPEmail_Sel)),  AV38TFServidorSMTPEmail_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFServidorSMTPUsuario_Sel)),  AV40TFServidorSMTPUsuario_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFServidorSMTPServer)),  AV33TFServidorSMTPServer, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFServidorSMTPPorta)),  AV35TFServidorSMTPPorta, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFServidorSMTPEmail)),  AV37TFServidorSMTPEmail, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFServidorSMTPUsuario)),  AV39TFServidorSMTPUsuario, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char2;
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
         imgAdddynamicfilters2_Visible = 1;
         AssignProp(sPrefix, false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp(sPrefix, false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERVIDORSMTPSERVER") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18ServidorSMTPServer1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18ServidorSMTPServer1", AV18ServidorSMTPServer1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERVIDORSMTPSERVER") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22ServidorSMTPServer2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV22ServidorSMTPServer2", AV22ServidorSMTPServer2);
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
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERVIDORSMTPSERVER") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26ServidorSMTPServer3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV26ServidorSMTPServer3", AV26ServidorSMTPServer3);
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
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp(sPrefix, false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV29Session.Get(AV63Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERVIDORSMTPSERVER",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFServidorSMTPServer)),  0,  AV33TFServidorSMTPServer,  AV33TFServidorSMTPServer,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFServidorSMTPServer_Sel)),  AV34TFServidorSMTPServer_Sel,  AV34TFServidorSMTPServer_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERVIDORSMTPPORTA",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFServidorSMTPPorta)),  0,  AV35TFServidorSMTPPorta,  AV35TFServidorSMTPPorta,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFServidorSMTPPorta_Sel)),  AV36TFServidorSMTPPorta_Sel,  AV36TFServidorSMTPPorta_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERVIDORSMTPEMAIL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFServidorSMTPEmail)),  0,  AV37TFServidorSMTPEmail,  AV37TFServidorSMTPEmail,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFServidorSMTPEmail_Sel)),  AV38TFServidorSMTPEmail_Sel,  AV38TFServidorSMTPEmail_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERVIDORSMTPUSUARIO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFServidorSMTPUsuario)),  0,  AV39TFServidorSMTPUsuario,  AV39TFServidorSMTPUsuario,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFServidorSMTPUsuario_Sel)),  AV40TFServidorSMTPUsuario_Sel,  AV40TFServidorSMTPUsuario_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV28DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "SERVIDORSMTPSERVER") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ServidorSMTPServer1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "SMTPServer",  AV17DynamicFiltersOperator1,  AV18ServidorSMTPServer1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18ServidorSMTPServer1, "Contém"+" "+AV18ServidorSMTPServer1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV19DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV20DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "SERVIDORSMTPSERVER") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ServidorSMTPServer2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "SMTPServer",  AV21DynamicFiltersOperator2,  AV22ServidorSMTPServer2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22ServidorSMTPServer2, "Contém"+" "+AV22ServidorSMTPServer2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV23DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "SERVIDORSMTPSERVER") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ServidorSMTPServer3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "SMTPServer",  AV25DynamicFiltersOperator3,  AV26ServidorSMTPServer3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26ServidorSMTPServer3, "Contém"+" "+AV26ServidorSMTPServer3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV27DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV63Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "ServidorSMTP";
         AV29Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_87_562( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_servidorsmtpserver3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServidorsmtpserver3_Internalname, "Servidor SMTPServer3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServidorsmtpserver3_Internalname, AV26ServidorSMTPServer3, StringUtil.RTrim( context.localUtil.Format( AV26ServidorSMTPServer3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServidorsmtpserver3_Jsonclick, 0, "Attribute", "", "", "", "", edtavServidorsmtpserver3_Visible, edtavServidorsmtpserver3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ServidorSMTPWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_87_562e( true) ;
         }
         else
         {
            wb_table3_87_562e( false) ;
         }
      }

      protected void wb_table2_65_562( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_servidorsmtpserver2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServidorsmtpserver2_Internalname, "Servidor SMTPServer2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServidorsmtpserver2_Internalname, AV22ServidorSMTPServer2, StringUtil.RTrim( context.localUtil.Format( AV22ServidorSMTPServer2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServidorsmtpserver2_Jsonclick, 0, "Attribute", "", "", "", "", edtavServidorsmtpserver2_Visible, edtavServidorsmtpserver2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ServidorSMTPWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ServidorSMTPWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_65_562e( true) ;
         }
         else
         {
            wb_table2_65_562e( false) ;
         }
      }

      protected void wb_table1_43_562( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_ServidorSMTPWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp(sPrefix, false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_servidorsmtpserver1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavServidorsmtpserver1_Internalname, "Servidor SMTPServer1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavServidorsmtpserver1_Internalname, AV18ServidorSMTPServer1, StringUtil.RTrim( context.localUtil.Format( AV18ServidorSMTPServer1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavServidorsmtpserver1_Jsonclick, 0, "Attribute", "", "", "", "", edtavServidorsmtpserver1_Visible, edtavServidorsmtpserver1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ServidorSMTPWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ServidorSMTPWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ServidorSMTPWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_562e( true) ;
         }
         else
         {
            wb_table1_43_562e( false) ;
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
         PA562( ) ;
         WS562( ) ;
         WE562( ) ;
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
         PA562( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "servidorsmtpww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA562( ) ;
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
         PA562( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS562( ) ;
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
         WS562( ) ;
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
         WE562( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019131224", true, true);
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
         context.AddJavascriptSource("servidorsmtpww.js", "?202561019131225", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1022( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_102_idx;
         edtServidorSMTPId_Internalname = sPrefix+"SERVIDORSMTPID_"+sGXsfl_102_idx;
         edtServidorSMTPServer_Internalname = sPrefix+"SERVIDORSMTPSERVER_"+sGXsfl_102_idx;
         edtServidorSMTPPorta_Internalname = sPrefix+"SERVIDORSMTPPORTA_"+sGXsfl_102_idx;
         edtServidorSMTPEmail_Internalname = sPrefix+"SERVIDORSMTPEMAIL_"+sGXsfl_102_idx;
         edtServidorSMTPUsuario_Internalname = sPrefix+"SERVIDORSMTPUSUARIO_"+sGXsfl_102_idx;
      }

      protected void SubsflControlProps_fel_1022( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_102_fel_idx;
         edtServidorSMTPId_Internalname = sPrefix+"SERVIDORSMTPID_"+sGXsfl_102_fel_idx;
         edtServidorSMTPServer_Internalname = sPrefix+"SERVIDORSMTPSERVER_"+sGXsfl_102_fel_idx;
         edtServidorSMTPPorta_Internalname = sPrefix+"SERVIDORSMTPPORTA_"+sGXsfl_102_fel_idx;
         edtServidorSMTPEmail_Internalname = sPrefix+"SERVIDORSMTPEMAIL_"+sGXsfl_102_fel_idx;
         edtServidorSMTPUsuario_Internalname = sPrefix+"SERVIDORSMTPUSUARIO_"+sGXsfl_102_fel_idx;
      }

      protected void sendrow_1022( )
      {
         sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
         SubsflControlProps_1022( ) ;
         WB560( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_102_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_102_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_102_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'" + sPrefix + "',false,'" + sGXsfl_102_idx + "',102)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV42Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"","'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVUPDATE.CLICK."+sGXsfl_102_idx+"'",(string)"",(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServidorSMTPId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ServidorSMTPId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A158ServidorSMTPId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServidorSMTPId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServidorSMTPServer_Internalname,(string)A159ServidorSMTPServer,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtServidorSMTPServer_Link,(string)"",(string)"",(string)"",(string)edtServidorSMTPServer_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServidorSMTPPorta_Internalname,(string)A160ServidorSMTPPorta,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServidorSMTPPorta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServidorSMTPEmail_Internalname,(string)A161ServidorSMTPEmail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A161ServidorSMTPEmail,(string)"",(string)"",(string)"",(string)edtServidorSMTPEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtServidorSMTPUsuario_Internalname,(string)A163ServidorSMTPUsuario,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtServidorSMTPUsuario_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)90,(short)0,(short)0,(short)102,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes562( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_102_idx = ((subGrid_Islastpage==1)&&(nGXsfl_102_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_102_idx+1);
            sGXsfl_102_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_102_idx), 4, 0), 4, "0");
            SubsflControlProps_1022( ) ;
         }
         /* End function sendrow_1022 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SERVIDORSMTPSERVER", "SMTPServer", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SERVIDORSMTPSERVER", "SMTPServer", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SERVIDORSMTPSERVER", "SMTPServer", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl102( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"102\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "SMTPId") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Server") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Porta") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Email") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Usuário") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV42Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A158ServidorSMTPId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A159ServidorSMTPServer));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtServidorSMTPServer_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A160ServidorSMTPPorta));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A161ServidorSMTPEmail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A163ServidorSMTPUsuario));
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
         edtavServidorsmtpserver1_Internalname = sPrefix+"vSERVIDORSMTPSERVER1";
         cellFilter_servidorsmtpserver1_cell_Internalname = sPrefix+"FILTER_SERVIDORSMTPSERVER1_CELL";
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
         edtavServidorsmtpserver2_Internalname = sPrefix+"vSERVIDORSMTPSERVER2";
         cellFilter_servidorsmtpserver2_cell_Internalname = sPrefix+"FILTER_SERVIDORSMTPSERVER2_CELL";
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
         edtavServidorsmtpserver3_Internalname = sPrefix+"vSERVIDORSMTPSERVER3";
         cellFilter_servidorsmtpserver3_cell_Internalname = sPrefix+"FILTER_SERVIDORSMTPSERVER3_CELL";
         imgRemovedynamicfilters3_Internalname = sPrefix+"REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = sPrefix+"DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = sPrefix+"TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = sPrefix+"TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = sPrefix+"TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = sPrefix+"ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         Dvpanel_tableheader_Internalname = sPrefix+"DVPANEL_TABLEHEADER";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtServidorSMTPId_Internalname = sPrefix+"SERVIDORSMTPID";
         edtServidorSMTPServer_Internalname = sPrefix+"SERVIDORSMTPSERVER";
         edtServidorSMTPPorta_Internalname = sPrefix+"SERVIDORSMTPPORTA";
         edtServidorSMTPEmail_Internalname = sPrefix+"SERVIDORSMTPEMAIL";
         edtServidorSMTPUsuario_Internalname = sPrefix+"SERVIDORSMTPUSUARIO";
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
         edtServidorSMTPUsuario_Jsonclick = "";
         edtServidorSMTPEmail_Jsonclick = "";
         edtServidorSMTPPorta_Jsonclick = "";
         edtServidorSMTPServer_Jsonclick = "";
         edtServidorSMTPServer_Link = "";
         edtServidorSMTPId_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Enabled = 1;
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavServidorsmtpserver1_Jsonclick = "";
         edtavServidorsmtpserver1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavServidorsmtpserver2_Jsonclick = "";
         edtavServidorsmtpserver2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavServidorsmtpserver3_Jsonclick = "";
         edtavServidorsmtpserver3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavServidorsmtpserver3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavServidorsmtpserver2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavServidorsmtpserver1_Visible = 1;
         edtServidorSMTPUsuario_Enabled = 0;
         edtServidorSMTPEmail_Enabled = 0;
         edtServidorSMTPPorta_Enabled = 0;
         edtServidorSMTPServer_Enabled = 0;
         edtServidorSMTPId_Enabled = 0;
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
         Ddo_grid_Datalistproc = "ServidorSMTPWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "2:ServidorSMTPServer|3:ServidorSMTPPorta|4:ServidorSMTPEmail|5:ServidorSMTPUsuario";
         Ddo_grid_Gridinternalname = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E12562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E24562","iparms":[{"av":"A158ServidorSMTPId","fld":"SERVIDORSMTPID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV42Update","fld":"vUPDATE","type":"char"},{"av":"edtServidorSMTPServer_Link","ctrl":"SERVIDORSMTPSERVER","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E17562","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E13562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavServidorsmtpserver2_Visible","ctrl":"vSERVIDORSMTPSERVER2","prop":"Visible"},{"av":"edtavServidorsmtpserver3_Visible","ctrl":"vSERVIDORSMTPSERVER3","prop":"Visible"},{"av":"edtavServidorsmtpserver1_Visible","ctrl":"vSERVIDORSMTPSERVER1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E18562","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavServidorsmtpserver1_Visible","ctrl":"vSERVIDORSMTPSERVER1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E19562","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E14562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavServidorsmtpserver2_Visible","ctrl":"vSERVIDORSMTPSERVER2","prop":"Visible"},{"av":"edtavServidorsmtpserver3_Visible","ctrl":"vSERVIDORSMTPSERVER3","prop":"Visible"},{"av":"edtavServidorsmtpserver1_Visible","ctrl":"vSERVIDORSMTPSERVER1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E20562","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavServidorsmtpserver2_Visible","ctrl":"vSERVIDORSMTPSERVER2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E15562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavServidorsmtpserver2_Visible","ctrl":"vSERVIDORSMTPSERVER2","prop":"Visible"},{"av":"edtavServidorsmtpserver3_Visible","ctrl":"vSERVIDORSMTPSERVER3","prop":"Visible"},{"av":"edtavServidorsmtpserver1_Visible","ctrl":"vSERVIDORSMTPSERVER1","prop":"Visible"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E21562","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavServidorsmtpserver3_Visible","ctrl":"vSERVIDORSMTPSERVER3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"edtavServidorsmtpserver1_Visible","ctrl":"vSERVIDORSMTPSERVER1","prop":"Visible"},{"av":"edtavServidorsmtpserver2_Visible","ctrl":"vSERVIDORSMTPSERVER2","prop":"Visible"},{"av":"edtavServidorsmtpserver3_Visible","ctrl":"vSERVIDORSMTPSERVER3","prop":"Visible"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VUPDATE.CLICK","""{"handler":"E25562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A158ServidorSMTPId","fld":"SERVIDORSMTPID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VUPDATE.CLICK",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E16562","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"sPrefix","type":"char"},{"av":"A158ServidorSMTPId","fld":"SERVIDORSMTPID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18ServidorSMTPServer1","fld":"vSERVIDORSMTPSERVER1","type":"svchar"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22ServidorSMTPServer2","fld":"vSERVIDORSMTPSERVER2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26ServidorSMTPServer3","fld":"vSERVIDORSMTPSERVER3","type":"svchar"},{"av":"AV33TFServidorSMTPServer","fld":"vTFSERVIDORSMTPSERVER","type":"svchar"},{"av":"AV34TFServidorSMTPServer_Sel","fld":"vTFSERVIDORSMTPSERVER_SEL","type":"svchar"},{"av":"AV35TFServidorSMTPPorta","fld":"vTFSERVIDORSMTPPORTA","type":"svchar"},{"av":"AV36TFServidorSMTPPorta_Sel","fld":"vTFSERVIDORSMTPPORTA_SEL","type":"svchar"},{"av":"AV37TFServidorSMTPEmail","fld":"vTFSERVIDORSMTPEMAIL","type":"svchar"},{"av":"AV38TFServidorSMTPEmail_Sel","fld":"vTFSERVIDORSMTPEMAIL_SEL","type":"svchar"},{"av":"AV39TFServidorSMTPUsuario","fld":"vTFSERVIDORSMTPUSUARIO","type":"svchar"},{"av":"AV40TFServidorSMTPUsuario_Sel","fld":"vTFSERVIDORSMTPUSUARIO_SEL","type":"svchar"},{"av":"AV63Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"av":"AV32ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV30ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Servidorsmtpusuario","iparms":[]}""");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV18ServidorSMTPServer1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ServidorSMTPServer2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ServidorSMTPServer3 = "";
         AV33TFServidorSMTPServer = "";
         AV34TFServidorSMTPServer_Sel = "";
         AV35TFServidorSMTPPorta = "";
         AV36TFServidorSMTPPorta_Sel = "";
         AV37TFServidorSMTPEmail = "";
         AV38TFServidorSMTPEmail_Sel = "";
         AV39TFServidorSMTPUsuario = "";
         AV40TFServidorSMTPUsuario_Sel = "";
         AV63Pgmname = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV30ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV41DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV43Servidorsmtpwwds_1_filterfulltext = "";
         AV44Servidorsmtpwwds_2_dynamicfiltersselector1 = "";
         AV46Servidorsmtpwwds_4_servidorsmtpserver1 = "";
         AV48Servidorsmtpwwds_6_dynamicfiltersselector2 = "";
         AV50Servidorsmtpwwds_8_servidorsmtpserver2 = "";
         AV52Servidorsmtpwwds_10_dynamicfiltersselector3 = "";
         AV54Servidorsmtpwwds_12_servidorsmtpserver3 = "";
         AV55Servidorsmtpwwds_13_tfservidorsmtpserver = "";
         AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel = "";
         AV57Servidorsmtpwwds_15_tfservidorsmtpporta = "";
         AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel = "";
         AV59Servidorsmtpwwds_17_tfservidorsmtpemail = "";
         AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel = "";
         AV61Servidorsmtpwwds_19_tfservidorsmtpusuario = "";
         AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = "";
         AV42Update = "";
         A159ServidorSMTPServer = "";
         A160ServidorSMTPPorta = "";
         A161ServidorSMTPEmail = "";
         A163ServidorSMTPUsuario = "";
         lV43Servidorsmtpwwds_1_filterfulltext = "";
         lV46Servidorsmtpwwds_4_servidorsmtpserver1 = "";
         lV50Servidorsmtpwwds_8_servidorsmtpserver2 = "";
         lV54Servidorsmtpwwds_12_servidorsmtpserver3 = "";
         lV55Servidorsmtpwwds_13_tfservidorsmtpserver = "";
         lV57Servidorsmtpwwds_15_tfservidorsmtpporta = "";
         lV59Servidorsmtpwwds_17_tfservidorsmtpemail = "";
         lV61Servidorsmtpwwds_19_tfservidorsmtpusuario = "";
         H00562_A163ServidorSMTPUsuario = new string[] {""} ;
         H00562_n163ServidorSMTPUsuario = new bool[] {false} ;
         H00562_A161ServidorSMTPEmail = new string[] {""} ;
         H00562_n161ServidorSMTPEmail = new bool[] {false} ;
         H00562_A160ServidorSMTPPorta = new string[] {""} ;
         H00562_n160ServidorSMTPPorta = new bool[] {false} ;
         H00562_A159ServidorSMTPServer = new string[] {""} ;
         H00562_n159ServidorSMTPServer = new bool[] {false} ;
         H00562_A158ServidorSMTPId = new short[1] ;
         H00563_AGRID_nRecordCount = new long[1] ;
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV31ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV29Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servidorsmtpww__default(),
            new Object[][] {
                new Object[] {
               H00562_A163ServidorSMTPUsuario, H00562_n163ServidorSMTPUsuario, H00562_A161ServidorSMTPEmail, H00562_n161ServidorSMTPEmail, H00562_A160ServidorSMTPPorta, H00562_n160ServidorSMTPPorta, H00562_A159ServidorSMTPServer, H00562_n159ServidorSMTPServer, H00562_A158ServidorSMTPId
               }
               , new Object[] {
               H00563_AGRID_nRecordCount
               }
            }
         );
         AV63Pgmname = "ServidorSMTPWW";
         /* GeneXus formulas. */
         AV63Pgmname = "ServidorSMTPWW";
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV32ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 ;
      private short AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 ;
      private short AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 ;
      private short A158ServidorSMTPId ;
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
      private int nRC_GXsfl_102 ;
      private int nGXsfl_102_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtServidorSMTPId_Enabled ;
      private int edtServidorSMTPServer_Enabled ;
      private int edtServidorSMTPPorta_Enabled ;
      private int edtServidorSMTPEmail_Enabled ;
      private int edtServidorSMTPUsuario_Enabled ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavServidorsmtpserver1_Visible ;
      private int edtavServidorsmtpserver2_Visible ;
      private int edtavServidorsmtpserver3_Visible ;
      private int AV64GXV1 ;
      private int edtavServidorsmtpserver3_Enabled ;
      private int edtavServidorsmtpserver2_Enabled ;
      private int edtavServidorsmtpserver1_Enabled ;
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
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_102_idx="0001" ;
      private string AV63Pgmname ;
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
      private string sStyleString ;
      private string subGrid_Internalname ;
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
      private string AV42Update ;
      private string edtServidorSMTPId_Internalname ;
      private string edtServidorSMTPServer_Internalname ;
      private string edtServidorSMTPPorta_Internalname ;
      private string edtServidorSMTPEmail_Internalname ;
      private string edtServidorSMTPUsuario_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavServidorsmtpserver1_Internalname ;
      private string edtavServidorsmtpserver2_Internalname ;
      private string edtavServidorsmtpserver3_Internalname ;
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
      private string edtServidorSMTPServer_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_servidorsmtpserver3_cell_Internalname ;
      private string edtavServidorsmtpserver3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_servidorsmtpserver2_cell_Internalname ;
      private string edtavServidorsmtpserver2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_servidorsmtpserver1_cell_Internalname ;
      private string edtavServidorsmtpserver1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_102_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtServidorSMTPId_Jsonclick ;
      private string edtServidorSMTPServer_Jsonclick ;
      private string edtServidorSMTPPorta_Jsonclick ;
      private string edtServidorSMTPEmail_Jsonclick ;
      private string edtServidorSMTPUsuario_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
      private bool bGXsfl_102_Refreshing=false ;
      private bool Dvpanel_tableheader_Autowidth ;
      private bool Dvpanel_tableheader_Autoheight ;
      private bool Dvpanel_tableheader_Collapsible ;
      private bool Dvpanel_tableheader_Collapsed ;
      private bool Dvpanel_tableheader_Showcollapseicon ;
      private bool Dvpanel_tableheader_Autoscroll ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 ;
      private bool AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 ;
      private bool n159ServidorSMTPServer ;
      private bool n160ServidorSMTPPorta ;
      private bool n161ServidorSMTPEmail ;
      private bool n163ServidorSMTPUsuario ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV31ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18ServidorSMTPServer1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22ServidorSMTPServer2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26ServidorSMTPServer3 ;
      private string AV33TFServidorSMTPServer ;
      private string AV34TFServidorSMTPServer_Sel ;
      private string AV35TFServidorSMTPPorta ;
      private string AV36TFServidorSMTPPorta_Sel ;
      private string AV37TFServidorSMTPEmail ;
      private string AV38TFServidorSMTPEmail_Sel ;
      private string AV39TFServidorSMTPUsuario ;
      private string AV40TFServidorSMTPUsuario_Sel ;
      private string AV43Servidorsmtpwwds_1_filterfulltext ;
      private string AV44Servidorsmtpwwds_2_dynamicfiltersselector1 ;
      private string AV46Servidorsmtpwwds_4_servidorsmtpserver1 ;
      private string AV48Servidorsmtpwwds_6_dynamicfiltersselector2 ;
      private string AV50Servidorsmtpwwds_8_servidorsmtpserver2 ;
      private string AV52Servidorsmtpwwds_10_dynamicfiltersselector3 ;
      private string AV54Servidorsmtpwwds_12_servidorsmtpserver3 ;
      private string AV55Servidorsmtpwwds_13_tfservidorsmtpserver ;
      private string AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel ;
      private string AV57Servidorsmtpwwds_15_tfservidorsmtpporta ;
      private string AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel ;
      private string AV59Servidorsmtpwwds_17_tfservidorsmtpemail ;
      private string AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel ;
      private string AV61Servidorsmtpwwds_19_tfservidorsmtpusuario ;
      private string AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ;
      private string A159ServidorSMTPServer ;
      private string A160ServidorSMTPPorta ;
      private string A161ServidorSMTPEmail ;
      private string A163ServidorSMTPUsuario ;
      private string lV43Servidorsmtpwwds_1_filterfulltext ;
      private string lV46Servidorsmtpwwds_4_servidorsmtpserver1 ;
      private string lV50Servidorsmtpwwds_8_servidorsmtpserver2 ;
      private string lV54Servidorsmtpwwds_12_servidorsmtpserver3 ;
      private string lV55Servidorsmtpwwds_13_tfservidorsmtpserver ;
      private string lV57Servidorsmtpwwds_15_tfservidorsmtpporta ;
      private string lV59Servidorsmtpwwds_17_tfservidorsmtpemail ;
      private string lV61Servidorsmtpwwds_19_tfservidorsmtpusuario ;
      private IGxSession AV29Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
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
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV30ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV41DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00562_A163ServidorSMTPUsuario ;
      private bool[] H00562_n163ServidorSMTPUsuario ;
      private string[] H00562_A161ServidorSMTPEmail ;
      private bool[] H00562_n161ServidorSMTPEmail ;
      private string[] H00562_A160ServidorSMTPPorta ;
      private bool[] H00562_n160ServidorSMTPPorta ;
      private string[] H00562_A159ServidorSMTPServer ;
      private bool[] H00562_n159ServidorSMTPServer ;
      private short[] H00562_A158ServidorSMTPId ;
      private long[] H00563_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class servidorsmtpww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00562( IGxContext context ,
                                             string AV43Servidorsmtpwwds_1_filterfulltext ,
                                             string AV44Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV46Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV48Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV50Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV52Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV54Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV55Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV57Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV59Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV61Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[21];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ServidorSMTPUsuario, ServidorSMTPEmail, ServidorSMTPPorta, ServidorSMTPServer, ServidorSMTPId";
         sFromString = " FROM ServidorSMTP";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV43Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV46Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV46Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV50Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV50Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV54Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV55Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV57Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV59Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV61Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ServidorSMTPServer, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ServidorSMTPServer DESC, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ServidorSMTPPorta, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ServidorSMTPPorta DESC, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ServidorSMTPEmail, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ServidorSMTPEmail DESC, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY ServidorSMTPUsuario, ServidorSMTPId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY ServidorSMTPUsuario DESC, ServidorSMTPId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY ServidorSMTPId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H00563( IGxContext context ,
                                             string AV43Servidorsmtpwwds_1_filterfulltext ,
                                             string AV44Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV46Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV48Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV50Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV52Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV54Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV55Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV57Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV59Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV61Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ServidorSMTP";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV43Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV43Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV46Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV45Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV46Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV50Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV47Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV49Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV50Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV54Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV51Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV53Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV55Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV57Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV59Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( StringUtil.StrCmp(AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV61Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( StringUtil.StrCmp(AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
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
                     return conditional_H00562(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
               case 1 :
                     return conditional_H00563(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmH00562;
          prmH00562 = new Object[] {
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV46Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV50Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV50Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV54Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV54Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV55Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00563;
          prmH00563 = new Object[] {
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV46Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV50Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV50Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV54Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV54Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV55Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV56Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV58Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV59Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV60Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV61Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV62Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00562,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00563", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00563,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
