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
   public class financiamentoww : GXDataArea
   {
      public financiamentoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamentoww( IGxContext context )
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
         nRC_GXsfl_127 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_127"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_127_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_127_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_127_idx = GetPar( "sGXsfl_127_idx");
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
         AV18FinanciamentoValor1 = NumberUtil.Val( GetPar( "FinanciamentoValor1"), ".");
         AV19ClienteDocumento1 = GetPar( "ClienteDocumento1");
         AV20IntermediadorClienteDocumento1 = GetPar( "IntermediadorClienteDocumento1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24FinanciamentoValor2 = NumberUtil.Val( GetPar( "FinanciamentoValor2"), ".");
         AV25ClienteDocumento2 = GetPar( "ClienteDocumento2");
         AV26IntermediadorClienteDocumento2 = GetPar( "IntermediadorClienteDocumento2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV30FinanciamentoValor3 = NumberUtil.Val( GetPar( "FinanciamentoValor3"), ".");
         AV31ClienteDocumento3 = GetPar( "ClienteDocumento3");
         AV32IntermediadorClienteDocumento3 = GetPar( "IntermediadorClienteDocumento3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV60Pgmname = GetPar( "Pgmname");
         AV41TFClienteRazaoSocial = GetPar( "TFClienteRazaoSocial");
         AV42TFClienteRazaoSocial_Sel = GetPar( "TFClienteRazaoSocial_Sel");
         AV43TFClienteDocumento = GetPar( "TFClienteDocumento");
         AV44TFClienteDocumento_Sel = GetPar( "TFClienteDocumento_Sel");
         AV45TFFinanciamentoValor = NumberUtil.Val( GetPar( "TFFinanciamentoValor"), ".");
         AV46TFFinanciamentoValor_To = NumberUtil.Val( GetPar( "TFFinanciamentoValor_To"), ".");
         AV47TFIntermediadorClienteRazaoSocial = GetPar( "TFIntermediadorClienteRazaoSocial");
         AV48TFIntermediadorClienteRazaoSocial_Sel = GetPar( "TFIntermediadorClienteRazaoSocial_Sel");
         AV49TFIntermediadorClienteDocumento = GetPar( "TFIntermediadorClienteDocumento");
         AV50TFIntermediadorClienteDocumento_Sel = GetPar( "TFIntermediadorClienteDocumento_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV34DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV33DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
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
         PA4E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("financiamentoww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vFINANCIAMENTOVALOR1", StringUtil.LTrim( StringUtil.NToC( AV18FinanciamentoValor1, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO1", AV19ClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vINTERMEDIADORCLIENTEDOCUMENTO1", AV20IntermediadorClienteDocumento1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFINANCIAMENTOVALOR2", StringUtil.LTrim( StringUtil.NToC( AV24FinanciamentoValor2, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO2", AV25ClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vINTERMEDIADORCLIENTEDOCUMENTO2", AV26IntermediadorClienteDocumento2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFINANCIAMENTOVALOR3", StringUtil.LTrim( StringUtil.NToC( AV30FinanciamentoValor3, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCLIENTEDOCUMENTO3", AV31ClienteDocumento3);
         GxWebStd.gx_hidden_field( context, "GXH_vINTERMEDIADORCLIENTEDOCUMENTO3", AV32IntermediadorClienteDocumento3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_127", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_127), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
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
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL", AV41TFClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTERAZAOSOCIAL_SEL", AV42TFClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO", AV43TFClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFCLIENTEDOCUMENTO_SEL", AV44TFClienteDocumento_Sel);
         GxWebStd.gx_hidden_field( context, "vTFFINANCIAMENTOVALOR", StringUtil.LTrim( StringUtil.NToC( AV45TFFinanciamentoValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFFINANCIAMENTOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV46TFFinanciamentoValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFINTERMEDIADORCLIENTERAZAOSOCIAL", AV47TFIntermediadorClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL", AV48TFIntermediadorClienteRazaoSocial_Sel);
         GxWebStd.gx_hidden_field( context, "vTFINTERMEDIADORCLIENTEDOCUMENTO", AV49TFIntermediadorClienteDocumento);
         GxWebStd.gx_hidden_field( context, "vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL", AV50TFIntermediadorClienteDocumento_Sel);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE4E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4E2( ) ;
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
         return formatLink("financiamentoww")  ;
      }

      public override string GetPgmname( )
      {
         return "FinanciamentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Financiamento" ;
      }

      protected void WB4E0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_FinanciamentoWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_FinanciamentoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_4E2( true) ;
         }
         else
         {
            wb_table1_47_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_4E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_75_4E2( true) ;
         }
         else
         {
            wb_table2_75_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_75_4E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_103_4E2( true) ;
         }
         else
         {
            wb_table3_103_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_103_4E2e( bool wbgen )
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
            StartGridControl127( ) ;
         }
         if ( wbEnd == 127 )
         {
            wbEnd = 0;
            nRC_GXsfl_127 = (int)(nGXsfl_127_idx-1);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_FinanciamentoWW.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV51DDO_TitleSettingsIcons);
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
         if ( wbEnd == 127 )
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

      protected void START4E2( )
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
         Form.Meta.addItem("description", " Financiamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4E0( ) ;
      }

      protected void WS4E2( )
      {
         START4E2( ) ;
         EVT4E2( ) ;
      }

      protected void EVT4E2( )
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
                              E114E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E124E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E134E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E144E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E154E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E164E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E174E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E184E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E194E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E204E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E214E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E224E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E234E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E244E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E254E2 ();
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
                              nGXsfl_127_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
                              SubsflControlProps_1272( ) ;
                              AV56Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV56Display);
                              AV57Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
                              A223FinanciamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFinanciamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
                              n169ClienteDocumento = false;
                              A224FinanciamentoValor = context.localUtil.CToN( cgiGet( edtFinanciamentoValor_Internalname), ",", ".");
                              n224FinanciamentoValor = false;
                              A220IntermediadorClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtIntermediadorClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n220IntermediadorClienteId = false;
                              A221IntermediadorClienteRazaoSocial = StringUtil.Upper( cgiGet( edtIntermediadorClienteRazaoSocial_Internalname));
                              n221IntermediadorClienteRazaoSocial = false;
                              A222IntermediadorClienteDocumento = cgiGet( edtIntermediadorClienteDocumento_Internalname);
                              n222IntermediadorClienteDocumento = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E264E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E274E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E284E2 ();
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
                                       /* Set Refresh If Financiamentovalor1 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR1"), ",", ".") != AV18FinanciamentoValor1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV19ClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Intermediadorclientedocumento1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO1"), AV20IntermediadorClienteDocumento1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Financiamentovalor2 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR2"), ",", ".") != AV24FinanciamentoValor2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV25ClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Intermediadorclientedocumento2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO2"), AV26IntermediadorClienteDocumento2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Financiamentovalor3 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR3"), ",", ".") != AV30FinanciamentoValor3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Clientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV31ClienteDocumento3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Intermediadorclientedocumento3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO3"), AV32IntermediadorClienteDocumento3) != 0 )
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

      protected void WE4E2( )
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

      protected void PA4E2( )
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
         SubsflControlProps_1272( ) ;
         while ( nGXsfl_127_idx <= nRC_GXsfl_127 )
         {
            sendrow_1272( ) ;
            nGXsfl_127_idx = ((subGrid_Islastpage==1)&&(nGXsfl_127_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
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
                                       decimal AV18FinanciamentoValor1 ,
                                       string AV19ClienteDocumento1 ,
                                       string AV20IntermediadorClienteDocumento1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       decimal AV24FinanciamentoValor2 ,
                                       string AV25ClienteDocumento2 ,
                                       string AV26IntermediadorClienteDocumento2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       decimal AV30FinanciamentoValor3 ,
                                       string AV31ClienteDocumento3 ,
                                       string AV32IntermediadorClienteDocumento3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       string AV60Pgmname ,
                                       string AV41TFClienteRazaoSocial ,
                                       string AV42TFClienteRazaoSocial_Sel ,
                                       string AV43TFClienteDocumento ,
                                       string AV44TFClienteDocumento_Sel ,
                                       decimal AV45TFFinanciamentoValor ,
                                       decimal AV46TFFinanciamentoValor_To ,
                                       string AV47TFIntermediadorClienteRazaoSocial ,
                                       string AV48TFIntermediadorClienteRazaoSocial_Sel ,
                                       string AV49TFIntermediadorClienteDocumento ,
                                       string AV50TFIntermediadorClienteDocumento_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV34DynamicFiltersIgnoreFirst ,
                                       bool AV33DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FINANCIAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FINANCIAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A223FinanciamentoId), 9, 0, ".", "")));
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
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV60Pgmname = "FinanciamentoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RF4E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 127;
         /* Execute user event: Refresh */
         E274E2 ();
         nGXsfl_127_idx = 1;
         sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
         SubsflControlProps_1272( ) ;
         bGXsfl_127_Refreshing = true;
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
            SubsflControlProps_1272( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV61Financiamentowwds_1_filterfulltext ,
                                                 AV62Financiamentowwds_2_dynamicfiltersselector1 ,
                                                 AV63Financiamentowwds_3_dynamicfiltersoperator1 ,
                                                 AV64Financiamentowwds_4_financiamentovalor1 ,
                                                 AV65Financiamentowwds_5_clientedocumento1 ,
                                                 AV66Financiamentowwds_6_intermediadorclientedocumento1 ,
                                                 AV67Financiamentowwds_7_dynamicfiltersenabled2 ,
                                                 AV68Financiamentowwds_8_dynamicfiltersselector2 ,
                                                 AV69Financiamentowwds_9_dynamicfiltersoperator2 ,
                                                 AV70Financiamentowwds_10_financiamentovalor2 ,
                                                 AV71Financiamentowwds_11_clientedocumento2 ,
                                                 AV72Financiamentowwds_12_intermediadorclientedocumento2 ,
                                                 AV73Financiamentowwds_13_dynamicfiltersenabled3 ,
                                                 AV74Financiamentowwds_14_dynamicfiltersselector3 ,
                                                 AV75Financiamentowwds_15_dynamicfiltersoperator3 ,
                                                 AV76Financiamentowwds_16_financiamentovalor3 ,
                                                 AV77Financiamentowwds_17_clientedocumento3 ,
                                                 AV78Financiamentowwds_18_intermediadorclientedocumento3 ,
                                                 AV80Financiamentowwds_20_tfclienterazaosocial_sel ,
                                                 AV79Financiamentowwds_19_tfclienterazaosocial ,
                                                 AV82Financiamentowwds_22_tfclientedocumento_sel ,
                                                 AV81Financiamentowwds_21_tfclientedocumento ,
                                                 AV83Financiamentowwds_23_tffinanciamentovalor ,
                                                 AV84Financiamentowwds_24_tffinanciamentovalor_to ,
                                                 AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                                 AV85Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                                 AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                                 AV87Financiamentowwds_27_tfintermediadorclientedocumento ,
                                                 A170ClienteRazaoSocial ,
                                                 A169ClienteDocumento ,
                                                 A224FinanciamentoValor ,
                                                 A221IntermediadorClienteRazaoSocial ,
                                                 A222IntermediadorClienteDocumento ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
            lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
            lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
            lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
            lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
            lV65Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1), "%", "");
            lV65Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1), "%", "");
            lV66Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
            lV66Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
            lV71Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2), "%", "");
            lV71Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2), "%", "");
            lV72Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
            lV72Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
            lV77Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3), "%", "");
            lV77Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3), "%", "");
            lV78Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
            lV78Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
            lV79Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_19_tfclienterazaosocial), "%", "");
            lV81Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV81Financiamentowwds_21_tfclientedocumento), "%", "");
            lV85Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV85Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
            lV87Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV87Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
            /* Using cursor H004E2 */
            pr_default.execute(0, new Object[] {lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, AV64Financiamentowwds_4_financiamentovalor1, AV64Financiamentowwds_4_financiamentovalor1, AV64Financiamentowwds_4_financiamentovalor1, lV65Financiamentowwds_5_clientedocumento1, lV65Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_6_intermediadorclientedocumento1, lV66Financiamentowwds_6_intermediadorclientedocumento1, AV70Financiamentowwds_10_financiamentovalor2, AV70Financiamentowwds_10_financiamentovalor2, AV70Financiamentowwds_10_financiamentovalor2, lV71Financiamentowwds_11_clientedocumento2, lV71Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_12_intermediadorclientedocumento2, lV72Financiamentowwds_12_intermediadorclientedocumento2, AV76Financiamentowwds_16_financiamentovalor3, AV76Financiamentowwds_16_financiamentovalor3, AV76Financiamentowwds_16_financiamentovalor3, lV77Financiamentowwds_17_clientedocumento3, lV77Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_18_intermediadorclientedocumento3, lV78Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_19_tfclienterazaosocial, AV80Financiamentowwds_20_tfclienterazaosocial_sel, lV81Financiamentowwds_21_tfclientedocumento, AV82Financiamentowwds_22_tfclientedocumento_sel, AV83Financiamentowwds_23_tffinanciamentovalor, AV84Financiamentowwds_24_tffinanciamentovalor_to, lV85Financiamentowwds_25_tfintermediadorclienterazaosocial, AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV87Financiamentowwds_27_tfintermediadorclientedocumento, AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_127_idx = 1;
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A222IntermediadorClienteDocumento = H004E2_A222IntermediadorClienteDocumento[0];
               n222IntermediadorClienteDocumento = H004E2_n222IntermediadorClienteDocumento[0];
               A221IntermediadorClienteRazaoSocial = H004E2_A221IntermediadorClienteRazaoSocial[0];
               n221IntermediadorClienteRazaoSocial = H004E2_n221IntermediadorClienteRazaoSocial[0];
               A220IntermediadorClienteId = H004E2_A220IntermediadorClienteId[0];
               n220IntermediadorClienteId = H004E2_n220IntermediadorClienteId[0];
               A224FinanciamentoValor = H004E2_A224FinanciamentoValor[0];
               n224FinanciamentoValor = H004E2_n224FinanciamentoValor[0];
               A169ClienteDocumento = H004E2_A169ClienteDocumento[0];
               n169ClienteDocumento = H004E2_n169ClienteDocumento[0];
               A170ClienteRazaoSocial = H004E2_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H004E2_n170ClienteRazaoSocial[0];
               A168ClienteId = H004E2_A168ClienteId[0];
               n168ClienteId = H004E2_n168ClienteId[0];
               A223FinanciamentoId = H004E2_A223FinanciamentoId[0];
               A222IntermediadorClienteDocumento = H004E2_A222IntermediadorClienteDocumento[0];
               n222IntermediadorClienteDocumento = H004E2_n222IntermediadorClienteDocumento[0];
               A221IntermediadorClienteRazaoSocial = H004E2_A221IntermediadorClienteRazaoSocial[0];
               n221IntermediadorClienteRazaoSocial = H004E2_n221IntermediadorClienteRazaoSocial[0];
               A169ClienteDocumento = H004E2_A169ClienteDocumento[0];
               n169ClienteDocumento = H004E2_n169ClienteDocumento[0];
               A170ClienteRazaoSocial = H004E2_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H004E2_n170ClienteRazaoSocial[0];
               /* Execute user event: Grid.Load */
               E284E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 127;
            WB4E0( ) ;
         }
         bGXsfl_127_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV60Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV60Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_FINANCIAMENTOID"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sGXsfl_127_idx, context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9"), context));
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
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV61Financiamentowwds_1_filterfulltext ,
                                              AV62Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV63Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV64Financiamentowwds_4_financiamentovalor1 ,
                                              AV65Financiamentowwds_5_clientedocumento1 ,
                                              AV66Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV67Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV68Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV69Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV70Financiamentowwds_10_financiamentovalor2 ,
                                              AV71Financiamentowwds_11_clientedocumento2 ,
                                              AV72Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV73Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV74Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV75Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV76Financiamentowwds_16_financiamentovalor3 ,
                                              AV77Financiamentowwds_17_clientedocumento3 ,
                                              AV78Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV80Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV79Financiamentowwds_19_tfclienterazaosocial ,
                                              AV82Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV81Financiamentowwds_21_tfclientedocumento ,
                                              AV83Financiamentowwds_23_tffinanciamentovalor ,
                                              AV84Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV85Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV87Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
         lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
         lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
         lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
         lV61Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext), "%", "");
         lV65Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1), "%", "");
         lV65Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1), "%", "");
         lV66Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV66Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV71Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2), "%", "");
         lV71Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2), "%", "");
         lV72Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV72Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV77Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3), "%", "");
         lV77Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3), "%", "");
         lV78Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV78Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV79Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV79Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV81Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV81Financiamentowwds_21_tfclientedocumento), "%", "");
         lV85Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV85Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV87Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV87Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor H004E3 */
         pr_default.execute(1, new Object[] {lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, lV61Financiamentowwds_1_filterfulltext, AV64Financiamentowwds_4_financiamentovalor1, AV64Financiamentowwds_4_financiamentovalor1, AV64Financiamentowwds_4_financiamentovalor1, lV65Financiamentowwds_5_clientedocumento1, lV65Financiamentowwds_5_clientedocumento1, lV66Financiamentowwds_6_intermediadorclientedocumento1, lV66Financiamentowwds_6_intermediadorclientedocumento1, AV70Financiamentowwds_10_financiamentovalor2, AV70Financiamentowwds_10_financiamentovalor2, AV70Financiamentowwds_10_financiamentovalor2, lV71Financiamentowwds_11_clientedocumento2, lV71Financiamentowwds_11_clientedocumento2, lV72Financiamentowwds_12_intermediadorclientedocumento2, lV72Financiamentowwds_12_intermediadorclientedocumento2, AV76Financiamentowwds_16_financiamentovalor3, AV76Financiamentowwds_16_financiamentovalor3, AV76Financiamentowwds_16_financiamentovalor3, lV77Financiamentowwds_17_clientedocumento3, lV77Financiamentowwds_17_clientedocumento3, lV78Financiamentowwds_18_intermediadorclientedocumento3, lV78Financiamentowwds_18_intermediadorclientedocumento3, lV79Financiamentowwds_19_tfclienterazaosocial, AV80Financiamentowwds_20_tfclienterazaosocial_sel, lV81Financiamentowwds_21_tfclientedocumento, AV82Financiamentowwds_22_tfclientedocumento_sel, AV83Financiamentowwds_23_tffinanciamentovalor, AV84Financiamentowwds_24_tffinanciamentovalor_to, lV85Financiamentowwds_25_tfintermediadorclienterazaosocial, AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV87Financiamentowwds_27_tfintermediadorclientedocumento, AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         GRID_nRecordCount = H004E3_AGRID_nRecordCount[0];
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
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV60Pgmname = "FinanciamentoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtFinanciamentoId_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtFinanciamentoValor_Enabled = 0;
         edtIntermediadorClienteId_Enabled = 0;
         edtIntermediadorClienteRazaoSocial_Enabled = 0;
         edtIntermediadorClienteDocumento_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E264E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV51DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_127 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_127"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor1_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFINANCIAMENTOVALOR1");
               GX_FocusControl = edtavFinanciamentovalor1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18FinanciamentoValor1 = 0;
               AssignAttri("", false, "AV18FinanciamentoValor1", StringUtil.LTrimStr( AV18FinanciamentoValor1, 18, 2));
            }
            else
            {
               AV18FinanciamentoValor1 = context.localUtil.CToN( cgiGet( edtavFinanciamentovalor1_Internalname), ",", ".");
               AssignAttri("", false, "AV18FinanciamentoValor1", StringUtil.LTrimStr( AV18FinanciamentoValor1, 18, 2));
            }
            AV19ClienteDocumento1 = cgiGet( edtavClientedocumento1_Internalname);
            AssignAttri("", false, "AV19ClienteDocumento1", AV19ClienteDocumento1);
            AV20IntermediadorClienteDocumento1 = cgiGet( edtavIntermediadorclientedocumento1_Internalname);
            AssignAttri("", false, "AV20IntermediadorClienteDocumento1", AV20IntermediadorClienteDocumento1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor2_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFINANCIAMENTOVALOR2");
               GX_FocusControl = edtavFinanciamentovalor2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV24FinanciamentoValor2 = 0;
               AssignAttri("", false, "AV24FinanciamentoValor2", StringUtil.LTrimStr( AV24FinanciamentoValor2, 18, 2));
            }
            else
            {
               AV24FinanciamentoValor2 = context.localUtil.CToN( cgiGet( edtavFinanciamentovalor2_Internalname), ",", ".");
               AssignAttri("", false, "AV24FinanciamentoValor2", StringUtil.LTrimStr( AV24FinanciamentoValor2, 18, 2));
            }
            AV25ClienteDocumento2 = cgiGet( edtavClientedocumento2_Internalname);
            AssignAttri("", false, "AV25ClienteDocumento2", AV25ClienteDocumento2);
            AV26IntermediadorClienteDocumento2 = cgiGet( edtavIntermediadorclientedocumento2_Internalname);
            AssignAttri("", false, "AV26IntermediadorClienteDocumento2", AV26IntermediadorClienteDocumento2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFinanciamentovalor3_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFINANCIAMENTOVALOR3");
               GX_FocusControl = edtavFinanciamentovalor3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30FinanciamentoValor3 = 0;
               AssignAttri("", false, "AV30FinanciamentoValor3", StringUtil.LTrimStr( AV30FinanciamentoValor3, 18, 2));
            }
            else
            {
               AV30FinanciamentoValor3 = context.localUtil.CToN( cgiGet( edtavFinanciamentovalor3_Internalname), ",", ".");
               AssignAttri("", false, "AV30FinanciamentoValor3", StringUtil.LTrimStr( AV30FinanciamentoValor3, 18, 2));
            }
            AV31ClienteDocumento3 = cgiGet( edtavClientedocumento3_Internalname);
            AssignAttri("", false, "AV31ClienteDocumento3", AV31ClienteDocumento3);
            AV32IntermediadorClienteDocumento3 = cgiGet( edtavIntermediadorclientedocumento3_Internalname);
            AssignAttri("", false, "AV32IntermediadorClienteDocumento3", AV32IntermediadorClienteDocumento3);
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
            if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR1"), ",", ".") != AV18FinanciamentoValor1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO1"), AV19ClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO1"), AV20IntermediadorClienteDocumento1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR2"), ",", ".") != AV24FinanciamentoValor2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO2"), AV25ClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO2"), AV26IntermediadorClienteDocumento2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vFINANCIAMENTOVALOR3"), ",", ".") != AV30FinanciamentoValor3 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCLIENTEDOCUMENTO3"), AV31ClienteDocumento3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vINTERMEDIADORCLIENTEDOCUMENTO3"), AV32IntermediadorClienteDocumento3) != 0 )
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
         E264E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E264E2( )
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
         AV16DynamicFiltersSelector1 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
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
         Form.Caption = " Financiamento";
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

      protected void E274E2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
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
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
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
         AV53GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV53GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV53GridCurrentPage), 10, 0));
         AV54GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV54GridPageCount", StringUtil.LTrimStr( (decimal)(AV54GridPageCount), 10, 0));
         GXt_char2 = AV55GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV60Pgmname, out  GXt_char2) ;
         AV55GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV55GridAppliedFilters", AV55GridAppliedFilters);
         AV61Financiamentowwds_1_filterfulltext = AV15FilterFullText;
         AV62Financiamentowwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV63Financiamentowwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV64Financiamentowwds_4_financiamentovalor1 = AV18FinanciamentoValor1;
         AV65Financiamentowwds_5_clientedocumento1 = AV19ClienteDocumento1;
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = AV20IntermediadorClienteDocumento1;
         AV67Financiamentowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV68Financiamentowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV69Financiamentowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV70Financiamentowwds_10_financiamentovalor2 = AV24FinanciamentoValor2;
         AV71Financiamentowwds_11_clientedocumento2 = AV25ClienteDocumento2;
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = AV26IntermediadorClienteDocumento2;
         AV73Financiamentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV74Financiamentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV75Financiamentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV76Financiamentowwds_16_financiamentovalor3 = AV30FinanciamentoValor3;
         AV77Financiamentowwds_17_clientedocumento3 = AV31ClienteDocumento3;
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = AV32IntermediadorClienteDocumento3;
         AV79Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV81Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV82Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV83Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV84Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E124E2( )
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

      protected void E134E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E144E2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteRazaoSocial") == 0 )
            {
               AV41TFClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
               AV42TFClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ClienteDocumento") == 0 )
            {
               AV43TFClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFClienteDocumento", AV43TFClienteDocumento);
               AV44TFClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFClienteDocumento_Sel", AV44TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "FinanciamentoValor") == 0 )
            {
               AV45TFFinanciamentoValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV45TFFinanciamentoValor", StringUtil.LTrimStr( AV45TFFinanciamentoValor, 18, 2));
               AV46TFFinanciamentoValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV46TFFinanciamentoValor_To", StringUtil.LTrimStr( AV46TFFinanciamentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IntermediadorClienteRazaoSocial") == 0 )
            {
               AV47TFIntermediadorClienteRazaoSocial = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV47TFIntermediadorClienteRazaoSocial", AV47TFIntermediadorClienteRazaoSocial);
               AV48TFIntermediadorClienteRazaoSocial_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV48TFIntermediadorClienteRazaoSocial_Sel", AV48TFIntermediadorClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IntermediadorClienteDocumento") == 0 )
            {
               AV49TFIntermediadorClienteDocumento = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV49TFIntermediadorClienteDocumento", AV49TFIntermediadorClienteDocumento);
               AV50TFIntermediadorClienteDocumento_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV50TFIntermediadorClienteDocumento_Sel", AV50TFIntermediadorClienteDocumento_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E284E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV56Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV56Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A223FinanciamentoId,9,0));
         edtavDisplay_Link = formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV57Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV57Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A223FinanciamentoId,9,0));
         edtavUpdate_Link = formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A168ClienteId,9,0));
         edtClienteDocumento_Link = formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A223FinanciamentoId,9,0));
         edtFinanciamentoValor_Link = formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A220IntermediadorClienteId,9,0));
         edtIntermediadorClienteDocumento_Link = formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 127;
         }
         sendrow_1272( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_127_Refreshing )
         {
            DoAjaxLoad(127, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E214E2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E154E2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E224E2( )
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

      protected void E234E2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E164E2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E244E2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E174E2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV33DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV33DynamicFiltersRemoving", AV33DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
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
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18FinanciamentoValor1, AV19ClienteDocumento1, AV20IntermediadorClienteDocumento1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24FinanciamentoValor2, AV25ClienteDocumento2, AV26IntermediadorClienteDocumento2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30FinanciamentoValor3, AV31ClienteDocumento3, AV32IntermediadorClienteDocumento3, AV40ManageFiltersExecutionStep, AV21DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV60Pgmname, AV41TFClienteRazaoSocial, AV42TFClienteRazaoSocial_Sel, AV43TFClienteDocumento, AV44TFClienteDocumento_Sel, AV45TFFinanciamentoValor, AV46TFFinanciamentoValor_To, AV47TFIntermediadorClienteRazaoSocial, AV48TFIntermediadorClienteRazaoSocial_Sel, AV49TFIntermediadorClienteDocumento, AV50TFIntermediadorClienteDocumento_Sel, AV10GridState, AV34DynamicFiltersIgnoreFirst, AV33DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E254E2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E114E2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("FinanciamentoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV60Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("FinanciamentoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "FinanciamentoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV10GridState.FromXml(AV39ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E184E2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "financiamento"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("financiamento") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E194E2( )
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
         new financiamentowwexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         if ( StringUtil.StrCmp(AV35ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV35ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV36ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E204E2( )
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
         Innewwindow1_Target = formatLink("financiamentowwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
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
         edtavFinanciamentovalor1_Visible = 0;
         AssignProp("", false, edtavFinanciamentovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor1_Visible), 5, 0), true);
         edtavClientedocumento1_Visible = 0;
         AssignProp("", false, edtavClientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento1_Visible), 5, 0), true);
         edtavIntermediadorclientedocumento1_Visible = 0;
         AssignProp("", false, edtavIntermediadorclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
         {
            edtavFinanciamentovalor1_Visible = 1;
            AssignProp("", false, edtavFinanciamentovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento1_Visible = 1;
            AssignProp("", false, edtavClientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
         {
            edtavIntermediadorclientedocumento1_Visible = 1;
            AssignProp("", false, edtavIntermediadorclientedocumento1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavFinanciamentovalor2_Visible = 0;
         AssignProp("", false, edtavFinanciamentovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor2_Visible), 5, 0), true);
         edtavClientedocumento2_Visible = 0;
         AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
         edtavIntermediadorclientedocumento2_Visible = 0;
         AssignProp("", false, edtavIntermediadorclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
         {
            edtavFinanciamentovalor2_Visible = 1;
            AssignProp("", false, edtavFinanciamentovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento2_Visible = 1;
            AssignProp("", false, edtavClientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
         {
            edtavIntermediadorclientedocumento2_Visible = 1;
            AssignProp("", false, edtavIntermediadorclientedocumento2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavFinanciamentovalor3_Visible = 0;
         AssignProp("", false, edtavFinanciamentovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor3_Visible), 5, 0), true);
         edtavClientedocumento3_Visible = 0;
         AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
         edtavIntermediadorclientedocumento3_Visible = 0;
         AssignProp("", false, edtavIntermediadorclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
         {
            edtavFinanciamentovalor3_Visible = 1;
            AssignProp("", false, edtavFinanciamentovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFinanciamentovalor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
         {
            edtavClientedocumento3_Visible = 1;
            AssignProp("", false, edtavClientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavClientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
         {
            edtavIntermediadorclientedocumento3_Visible = 1;
            AssignProp("", false, edtavIntermediadorclientedocumento3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavIntermediadorclientedocumento3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24FinanciamentoValor2 = 0;
         AssignAttri("", false, "AV24FinanciamentoValor2", StringUtil.LTrimStr( AV24FinanciamentoValor2, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30FinanciamentoValor3 = 0;
         AssignAttri("", false, "AV30FinanciamentoValor3", StringUtil.LTrimStr( AV30FinanciamentoValor3, 18, 2));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "FinanciamentoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV41TFClienteRazaoSocial = "";
         AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
         AV42TFClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
         AV43TFClienteDocumento = "";
         AssignAttri("", false, "AV43TFClienteDocumento", AV43TFClienteDocumento);
         AV44TFClienteDocumento_Sel = "";
         AssignAttri("", false, "AV44TFClienteDocumento_Sel", AV44TFClienteDocumento_Sel);
         AV45TFFinanciamentoValor = 0;
         AssignAttri("", false, "AV45TFFinanciamentoValor", StringUtil.LTrimStr( AV45TFFinanciamentoValor, 18, 2));
         AV46TFFinanciamentoValor_To = 0;
         AssignAttri("", false, "AV46TFFinanciamentoValor_To", StringUtil.LTrimStr( AV46TFFinanciamentoValor_To, 18, 2));
         AV47TFIntermediadorClienteRazaoSocial = "";
         AssignAttri("", false, "AV47TFIntermediadorClienteRazaoSocial", AV47TFIntermediadorClienteRazaoSocial);
         AV48TFIntermediadorClienteRazaoSocial_Sel = "";
         AssignAttri("", false, "AV48TFIntermediadorClienteRazaoSocial_Sel", AV48TFIntermediadorClienteRazaoSocial_Sel);
         AV49TFIntermediadorClienteDocumento = "";
         AssignAttri("", false, "AV49TFIntermediadorClienteDocumento", AV49TFIntermediadorClienteDocumento);
         AV50TFIntermediadorClienteDocumento_Sel = "";
         AssignAttri("", false, "AV50TFIntermediadorClienteDocumento_Sel", AV50TFIntermediadorClienteDocumento_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV16DynamicFiltersSelector1 = "FINANCIAMENTOVALOR";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18FinanciamentoValor1 = 0;
         AssignAttri("", false, "AV18FinanciamentoValor1", StringUtil.LTrimStr( AV18FinanciamentoValor1, 18, 2));
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
         if ( StringUtil.StrCmp(AV37Session.Get(AV60Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV60Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV37Session.Get(AV60Pgmname+"GridState"), null, "", "");
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
         AV89GXV1 = 1;
         while ( AV89GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV89GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFClienteRazaoSocial", AV41TFClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFClienteRazaoSocial_Sel", AV42TFClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV43TFClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFClienteDocumento", AV43TFClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV44TFClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFClienteDocumento_Sel", AV44TFClienteDocumento_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFFINANCIAMENTOVALOR") == 0 )
            {
               AV45TFFinanciamentoValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV45TFFinanciamentoValor", StringUtil.LTrimStr( AV45TFFinanciamentoValor, 18, 2));
               AV46TFFinanciamentoValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV46TFFinanciamentoValor_To", StringUtil.LTrimStr( AV46TFFinanciamentoValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL") == 0 )
            {
               AV47TFIntermediadorClienteRazaoSocial = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFIntermediadorClienteRazaoSocial", AV47TFIntermediadorClienteRazaoSocial);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV48TFIntermediadorClienteRazaoSocial_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFIntermediadorClienteRazaoSocial_Sel", AV48TFIntermediadorClienteRazaoSocial_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV49TFIntermediadorClienteDocumento = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFIntermediadorClienteDocumento", AV49TFIntermediadorClienteDocumento);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV50TFIntermediadorClienteDocumento_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFIntermediadorClienteDocumento_Sel", AV50TFIntermediadorClienteDocumento_Sel);
            }
            AV89GXV1 = (int)(AV89GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)),  AV42TFClienteRazaoSocial_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteDocumento_Sel)),  AV44TFClienteDocumento_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIntermediadorClienteRazaoSocial_Sel)),  AV48TFIntermediadorClienteRazaoSocial_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIntermediadorClienteDocumento_Sel)),  AV50TFIntermediadorClienteDocumento_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)),  AV41TFClienteRazaoSocial, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteDocumento)),  AV43TFClienteDocumento, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIntermediadorClienteRazaoSocial)),  AV47TFIntermediadorClienteRazaoSocial, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIntermediadorClienteDocumento)),  AV49TFIntermediadorClienteDocumento, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((Convert.ToDecimal(0)==AV45TFFinanciamentoValor) ? "" : StringUtil.Str( AV45TFFinanciamentoValor, 18, 2))+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((Convert.ToDecimal(0)==AV46TFFinanciamentoValor_To) ? "" : StringUtil.Str( AV46TFFinanciamentoValor_To, 18, 2))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18FinanciamentoValor1 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri("", false, "AV18FinanciamentoValor1", StringUtil.LTrimStr( AV18FinanciamentoValor1, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV19ClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV19ClienteDocumento1", AV19ClienteDocumento1);
            }
            else if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV20IntermediadorClienteDocumento1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20IntermediadorClienteDocumento1", AV20IntermediadorClienteDocumento1);
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
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24FinanciamentoValor2 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri("", false, "AV24FinanciamentoValor2", StringUtil.LTrimStr( AV24FinanciamentoValor2, 18, 2));
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV25ClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25ClienteDocumento2", AV25ClienteDocumento2);
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV26IntermediadorClienteDocumento2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26IntermediadorClienteDocumento2", AV26IntermediadorClienteDocumento2);
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
                  AV27DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30FinanciamentoValor3 = NumberUtil.Val( AV12GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri("", false, "AV30FinanciamentoValor3", StringUtil.LTrimStr( AV30FinanciamentoValor3, 18, 2));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31ClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31ClienteDocumento3", AV31ClienteDocumento3);
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV32IntermediadorClienteDocumento3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV32IntermediadorClienteDocumento3", AV32IntermediadorClienteDocumento3);
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
         AV10GridState.FromXml(AV37Session.Get(AV60Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTERAZAOSOCIAL",  "Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)),  0,  AV41TFClienteRazaoSocial,  AV41TFClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)),  AV42TFClienteRazaoSocial_Sel,  AV42TFClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCLIENTEDOCUMENTO",  "Cliente CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteDocumento)),  0,  AV43TFClienteDocumento,  AV43TFClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteDocumento_Sel)),  AV44TFClienteDocumento_Sel,  AV44TFClienteDocumento_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFFINANCIAMENTOVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV45TFFinanciamentoValor)&&(Convert.ToDecimal(0)==AV46TFFinanciamentoValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV45TFFinanciamentoValor, 18, 2)),  ((Convert.ToDecimal(0)==AV45TFFinanciamentoValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV45TFFinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV46TFFinanciamentoValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV46TFFinanciamentoValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV46TFFinanciamentoValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFINTERMEDIADORCLIENTERAZAOSOCIAL",  "Intermediador",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIntermediadorClienteRazaoSocial)),  0,  AV47TFIntermediadorClienteRazaoSocial,  AV47TFIntermediadorClienteRazaoSocial,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIntermediadorClienteRazaoSocial_Sel)),  AV48TFIntermediadorClienteRazaoSocial_Sel,  AV48TFIntermediadorClienteRazaoSocial_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFINTERMEDIADORCLIENTEDOCUMENTO",  "Intermediador CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIntermediadorClienteDocumento)),  0,  AV49TFIntermediadorClienteDocumento,  AV49TFIntermediadorClienteDocumento,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIntermediadorClienteDocumento_Sel)),  AV50TFIntermediadorClienteDocumento_Sel,  AV50TFIntermediadorClienteDocumento_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV60Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV34DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV16DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV18FinanciamentoValor1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV17DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV18FinanciamentoValor1, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV18FinanciamentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV18FinanciamentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV18FinanciamentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV17DynamicFiltersOperator1,  AV19ClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV19ClienteDocumento1, "Contém"+" "+AV19ClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20IntermediadorClienteDocumento1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV17DynamicFiltersOperator1,  AV20IntermediadorClienteDocumento1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20IntermediadorClienteDocumento1, "Contém"+" "+AV20IntermediadorClienteDocumento1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV24FinanciamentoValor2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV23DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV24FinanciamentoValor2, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV24FinanciamentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV24FinanciamentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV24FinanciamentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV23DynamicFiltersOperator2,  AV25ClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV25ClienteDocumento2, "Contém"+" "+AV25ClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26IntermediadorClienteDocumento2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV23DynamicFiltersOperator2,  AV26IntermediadorClienteDocumento2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV26IntermediadorClienteDocumento2, "Contém"+" "+AV26IntermediadorClienteDocumento2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV30FinanciamentoValor3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Valor",  AV29DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV30FinanciamentoValor3, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV30FinanciamentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV30FinanciamentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV30FinanciamentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Documento",  AV29DynamicFiltersOperator3,  AV31ClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV31ClienteDocumento3, "Contém"+" "+AV31ClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32IntermediadorClienteDocumento3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Cliente Documento",  AV29DynamicFiltersOperator3,  AV32IntermediadorClienteDocumento3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV32IntermediadorClienteDocumento3, "Contém"+" "+AV32IntermediadorClienteDocumento3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV33DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV60Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "Financiamento";
         AV37Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
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

      protected void wb_table3_103_4E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_financiamentovalor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFinanciamentovalor3_Internalname, "Financiamento Valor3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFinanciamentovalor3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV30FinanciamentoValor3, 18, 2, ",", "")), StringUtil.LTrim( ((edtavFinanciamentovalor3_Enabled!=0) ? context.localUtil.Format( AV30FinanciamentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV30FinanciamentoValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFinanciamentovalor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavFinanciamentovalor3_Visible, edtavFinanciamentovalor3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento3_Internalname, "Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento3_Internalname, AV31ClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV31ClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento3_Visible, edtavClientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_intermediadorclientedocumento3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIntermediadorclientedocumento3_Internalname, "Intermediador Cliente Documento3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIntermediadorclientedocumento3_Internalname, AV32IntermediadorClienteDocumento3, StringUtil.RTrim( context.localUtil.Format( AV32IntermediadorClienteDocumento3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIntermediadorclientedocumento3_Jsonclick, 0, "Attribute", "", "", "", "", edtavIntermediadorclientedocumento3_Visible, edtavIntermediadorclientedocumento3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinanciamentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_103_4E2e( true) ;
         }
         else
         {
            wb_table3_103_4E2e( false) ;
         }
      }

      protected void wb_table2_75_4E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_financiamentovalor2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFinanciamentovalor2_Internalname, "Financiamento Valor2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFinanciamentovalor2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV24FinanciamentoValor2, 18, 2, ",", "")), StringUtil.LTrim( ((edtavFinanciamentovalor2_Enabled!=0) ? context.localUtil.Format( AV24FinanciamentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV24FinanciamentoValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFinanciamentovalor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavFinanciamentovalor2_Visible, edtavFinanciamentovalor2_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento2_Internalname, "Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento2_Internalname, AV25ClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV25ClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento2_Visible, edtavClientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_intermediadorclientedocumento2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIntermediadorclientedocumento2_Internalname, "Intermediador Cliente Documento2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIntermediadorclientedocumento2_Internalname, AV26IntermediadorClienteDocumento2, StringUtil.RTrim( context.localUtil.Format( AV26IntermediadorClienteDocumento2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIntermediadorclientedocumento2_Jsonclick, 0, "Attribute", "", "", "", "", edtavIntermediadorclientedocumento2_Visible, edtavIntermediadorclientedocumento2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinanciamentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinanciamentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_75_4E2e( true) ;
         }
         else
         {
            wb_table2_75_4E2e( false) ;
         }
      }

      protected void wb_table1_47_4E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_FinanciamentoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_financiamentovalor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFinanciamentovalor1_Internalname, "Financiamento Valor1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFinanciamentovalor1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18FinanciamentoValor1, 18, 2, ",", "")), StringUtil.LTrim( ((edtavFinanciamentovalor1_Enabled!=0) ? context.localUtil.Format( AV18FinanciamentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV18FinanciamentoValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFinanciamentovalor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavFinanciamentovalor1_Visible, edtavFinanciamentovalor1_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_clientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClientedocumento1_Internalname, "Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClientedocumento1_Internalname, AV19ClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV19ClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavClientedocumento1_Visible, edtavClientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_intermediadorclientedocumento1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavIntermediadorclientedocumento1_Internalname, "Intermediador Cliente Documento1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavIntermediadorclientedocumento1_Internalname, AV20IntermediadorClienteDocumento1, StringUtil.RTrim( context.localUtil.Format( AV20IntermediadorClienteDocumento1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavIntermediadorclientedocumento1_Jsonclick, 0, "Attribute", "", "", "", "", edtavIntermediadorclientedocumento1_Visible, edtavIntermediadorclientedocumento1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FinanciamentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinanciamentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_FinanciamentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_4E2e( true) ;
         }
         else
         {
            wb_table1_47_4E2e( false) ;
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
         PA4E2( ) ;
         WS4E2( ) ;
         WE4E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019244058", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("financiamentoww.js", "?202561019244058", false, true);
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

      protected void SubsflControlProps_1272( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_127_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_127_idx;
         edtFinanciamentoId_Internalname = "FINANCIAMENTOID_"+sGXsfl_127_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_127_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_127_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_127_idx;
         edtFinanciamentoValor_Internalname = "FINANCIAMENTOVALOR_"+sGXsfl_127_idx;
         edtIntermediadorClienteId_Internalname = "INTERMEDIADORCLIENTEID_"+sGXsfl_127_idx;
         edtIntermediadorClienteRazaoSocial_Internalname = "INTERMEDIADORCLIENTERAZAOSOCIAL_"+sGXsfl_127_idx;
         edtIntermediadorClienteDocumento_Internalname = "INTERMEDIADORCLIENTEDOCUMENTO_"+sGXsfl_127_idx;
      }

      protected void SubsflControlProps_fel_1272( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_127_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_127_fel_idx;
         edtFinanciamentoId_Internalname = "FINANCIAMENTOID_"+sGXsfl_127_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_127_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_127_fel_idx;
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO_"+sGXsfl_127_fel_idx;
         edtFinanciamentoValor_Internalname = "FINANCIAMENTOVALOR_"+sGXsfl_127_fel_idx;
         edtIntermediadorClienteId_Internalname = "INTERMEDIADORCLIENTEID_"+sGXsfl_127_fel_idx;
         edtIntermediadorClienteRazaoSocial_Internalname = "INTERMEDIADORCLIENTERAZAOSOCIAL_"+sGXsfl_127_fel_idx;
         edtIntermediadorClienteDocumento_Internalname = "INTERMEDIADORCLIENTEDOCUMENTO_"+sGXsfl_127_fel_idx;
      }

      protected void sendrow_1272( )
      {
         sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
         SubsflControlProps_1272( ) ;
         WB4E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_127_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_127_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_127_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'" + sGXsfl_127_idx + "',127)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV56Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_127_idx + "',127)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV57Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFinanciamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A223FinanciamentoId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A223FinanciamentoId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFinanciamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteDocumento_Internalname,(string)A169ClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtClienteDocumento_Link,(string)"",(string)"",(string)"",(string)edtClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFinanciamentoValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A224FinanciamentoValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtFinanciamentoValor_Link,(string)"",(string)"",(string)"",(string)edtFinanciamentoValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIntermediadorClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A220IntermediadorClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIntermediadorClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIntermediadorClienteRazaoSocial_Internalname,(string)A221IntermediadorClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A221IntermediadorClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIntermediadorClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIntermediadorClienteDocumento_Internalname,(string)A222IntermediadorClienteDocumento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtIntermediadorClienteDocumento_Link,(string)"",(string)"",(string)"",(string)edtIntermediadorClienteDocumento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)127,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_127_idx = ((subGrid_Islastpage==1)&&(nGXsfl_127_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         /* End function sendrow_1272 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("FINANCIAMENTOVALOR", "Valor", 0);
         cmbavDynamicfiltersselector1.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector1.addItem("INTERMEDIADORCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV16DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV16DynamicFiltersSelector1);
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV17DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("FINANCIAMENTOVALOR", "Valor", 0);
         cmbavDynamicfiltersselector2.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector2.addItem("INTERMEDIADORCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("FINANCIAMENTOVALOR", "Valor", 0);
         cmbavDynamicfiltersselector3.addItem("CLIENTEDOCUMENTO", "Documento", 0);
         cmbavDynamicfiltersselector3.addItem("INTERMEDIADORCLIENTEDOCUMENTO", "Cliente Documento", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl127( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"127\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Intermediador") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Intermediador CPF") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV56Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV57Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A223FinanciamentoId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A169ClienteDocumento));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtClienteDocumento_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A224FinanciamentoValor, 18, 2, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtFinanciamentoValor_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A220IntermediadorClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A221IntermediadorClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A222IntermediadorClienteDocumento));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtIntermediadorClienteDocumento_Link));
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
         edtavFinanciamentovalor1_Internalname = "vFINANCIAMENTOVALOR1";
         cellFilter_financiamentovalor1_cell_Internalname = "FILTER_FINANCIAMENTOVALOR1_CELL";
         edtavClientedocumento1_Internalname = "vCLIENTEDOCUMENTO1";
         cellFilter_clientedocumento1_cell_Internalname = "FILTER_CLIENTEDOCUMENTO1_CELL";
         edtavIntermediadorclientedocumento1_Internalname = "vINTERMEDIADORCLIENTEDOCUMENTO1";
         cellFilter_intermediadorclientedocumento1_cell_Internalname = "FILTER_INTERMEDIADORCLIENTEDOCUMENTO1_CELL";
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
         edtavFinanciamentovalor2_Internalname = "vFINANCIAMENTOVALOR2";
         cellFilter_financiamentovalor2_cell_Internalname = "FILTER_FINANCIAMENTOVALOR2_CELL";
         edtavClientedocumento2_Internalname = "vCLIENTEDOCUMENTO2";
         cellFilter_clientedocumento2_cell_Internalname = "FILTER_CLIENTEDOCUMENTO2_CELL";
         edtavIntermediadorclientedocumento2_Internalname = "vINTERMEDIADORCLIENTEDOCUMENTO2";
         cellFilter_intermediadorclientedocumento2_cell_Internalname = "FILTER_INTERMEDIADORCLIENTEDOCUMENTO2_CELL";
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
         edtavFinanciamentovalor3_Internalname = "vFINANCIAMENTOVALOR3";
         cellFilter_financiamentovalor3_cell_Internalname = "FILTER_FINANCIAMENTOVALOR3_CELL";
         edtavClientedocumento3_Internalname = "vCLIENTEDOCUMENTO3";
         cellFilter_clientedocumento3_cell_Internalname = "FILTER_CLIENTEDOCUMENTO3_CELL";
         edtavIntermediadorclientedocumento3_Internalname = "vINTERMEDIADORCLIENTEDOCUMENTO3";
         cellFilter_intermediadorclientedocumento3_cell_Internalname = "FILTER_INTERMEDIADORCLIENTEDOCUMENTO3_CELL";
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
         edtFinanciamentoId_Internalname = "FINANCIAMENTOID";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtFinanciamentoValor_Internalname = "FINANCIAMENTOVALOR";
         edtIntermediadorClienteId_Internalname = "INTERMEDIADORCLIENTEID";
         edtIntermediadorClienteRazaoSocial_Internalname = "INTERMEDIADORCLIENTERAZAOSOCIAL";
         edtIntermediadorClienteDocumento_Internalname = "INTERMEDIADORCLIENTEDOCUMENTO";
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
         edtIntermediadorClienteDocumento_Jsonclick = "";
         edtIntermediadorClienteDocumento_Link = "";
         edtIntermediadorClienteRazaoSocial_Jsonclick = "";
         edtIntermediadorClienteId_Jsonclick = "";
         edtFinanciamentoValor_Jsonclick = "";
         edtFinanciamentoValor_Link = "";
         edtClienteDocumento_Jsonclick = "";
         edtClienteDocumento_Link = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtFinanciamentoId_Jsonclick = "";
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
         edtavIntermediadorclientedocumento1_Jsonclick = "";
         edtavIntermediadorclientedocumento1_Enabled = 1;
         edtavClientedocumento1_Jsonclick = "";
         edtavClientedocumento1_Enabled = 1;
         edtavFinanciamentovalor1_Jsonclick = "";
         edtavFinanciamentovalor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavIntermediadorclientedocumento2_Jsonclick = "";
         edtavIntermediadorclientedocumento2_Enabled = 1;
         edtavClientedocumento2_Jsonclick = "";
         edtavClientedocumento2_Enabled = 1;
         edtavFinanciamentovalor2_Jsonclick = "";
         edtavFinanciamentovalor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavIntermediadorclientedocumento3_Jsonclick = "";
         edtavIntermediadorclientedocumento3_Enabled = 1;
         edtavClientedocumento3_Jsonclick = "";
         edtavClientedocumento3_Enabled = 1;
         edtavFinanciamentovalor3_Jsonclick = "";
         edtavFinanciamentovalor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavIntermediadorclientedocumento3_Visible = 1;
         edtavClientedocumento3_Visible = 1;
         edtavFinanciamentovalor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavIntermediadorclientedocumento2_Visible = 1;
         edtavClientedocumento2_Visible = 1;
         edtavFinanciamentovalor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavIntermediadorclientedocumento1_Visible = 1;
         edtavClientedocumento1_Visible = 1;
         edtavFinanciamentovalor1_Visible = 1;
         edtIntermediadorClienteDocumento_Enabled = 0;
         edtIntermediadorClienteRazaoSocial_Enabled = 0;
         edtIntermediadorClienteId_Enabled = 0;
         edtFinanciamentoValor_Enabled = 0;
         edtClienteDocumento_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtFinanciamentoId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "||18.2||";
         Ddo_grid_Datalistproc = "FinanciamentoWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T||T|T";
         Ddo_grid_Filterisrange = "||T||";
         Ddo_grid_Filtertype = "Character|Character|Numeric|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|1|4|5";
         Ddo_grid_Columnids = "4:ClienteRazaoSocial|5:ClienteDocumento|6:FinanciamentoValor|8:IntermediadorClienteRazaoSocial|9:IntermediadorClienteDocumento";
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
         Form.Caption = " Financiamento";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E124E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E134E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E144E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E284E2","iparms":[{"av":"A223FinanciamentoId","fld":"FINANCIAMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A220IntermediadorClienteId","fld":"INTERMEDIADORCLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV56Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV57Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtClienteDocumento_Link","ctrl":"CLIENTEDOCUMENTO","prop":"Link"},{"av":"edtFinanciamentoValor_Link","ctrl":"FINANCIAMENTOVALOR","prop":"Link"},{"av":"edtIntermediadorClienteDocumento_Link","ctrl":"INTERMEDIADORCLIENTEDOCUMENTO","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E214E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E154E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E224E2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E234E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E164E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E244E2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E174E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E254E2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E114E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"AV53GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV54GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E184E2","iparms":[{"av":"A223FinanciamentoId","fld":"FINANCIAMENTOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E194E2","iparms":[{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E204E2","iparms":[{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18FinanciamentoValor1","fld":"vFINANCIAMENTOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV19ClienteDocumento1","fld":"vCLIENTEDOCUMENTO1","type":"svchar"},{"av":"AV20IntermediadorClienteDocumento1","fld":"vINTERMEDIADORCLIENTEDOCUMENTO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24FinanciamentoValor2","fld":"vFINANCIAMENTOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25ClienteDocumento2","fld":"vCLIENTEDOCUMENTO2","type":"svchar"},{"av":"AV26IntermediadorClienteDocumento2","fld":"vINTERMEDIADORCLIENTEDOCUMENTO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV28DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV29DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV30FinanciamentoValor3","fld":"vFINANCIAMENTOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV31ClienteDocumento3","fld":"vCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV32IntermediadorClienteDocumento3","fld":"vINTERMEDIADORCLIENTEDOCUMENTO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV27DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV60Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFClienteRazaoSocial","fld":"vTFCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV42TFClienteRazaoSocial_Sel","fld":"vTFCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV43TFClienteDocumento","fld":"vTFCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV44TFClienteDocumento_Sel","fld":"vTFCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV45TFFinanciamentoValor","fld":"vTFFINANCIAMENTOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV46TFFinanciamentoValor_To","fld":"vTFFINANCIAMENTOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV47TFIntermediadorClienteRazaoSocial","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"AV48TFIntermediadorClienteRazaoSocial_Sel","fld":"vTFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL","pic":"@!","type":"svchar"},{"av":"AV49TFIntermediadorClienteDocumento","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO","type":"svchar"},{"av":"AV50TFIntermediadorClienteDocumento_Sel","fld":"vTFINTERMEDIADORCLIENTEDOCUMENTO_SEL","type":"svchar"},{"av":"AV34DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV33DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavFinanciamentovalor1_Visible","ctrl":"vFINANCIAMENTOVALOR1","prop":"Visible"},{"av":"edtavClientedocumento1_Visible","ctrl":"vCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento1_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO1","prop":"Visible"},{"av":"edtavFinanciamentovalor2_Visible","ctrl":"vFINANCIAMENTOVALOR2","prop":"Visible"},{"av":"edtavClientedocumento2_Visible","ctrl":"vCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento2_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO2","prop":"Visible"},{"av":"edtavFinanciamentovalor3_Visible","ctrl":"vFINANCIAMENTOVALOR3","prop":"Visible"},{"av":"edtavClientedocumento3_Visible","ctrl":"vCLIENTEDOCUMENTO3","prop":"Visible"},{"av":"edtavIntermediadorclientedocumento3_Visible","ctrl":"vINTERMEDIADORCLIENTEDOCUMENTO3","prop":"Visible"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_INTERMEDIADORCLIENTEID","""{"handler":"Valid_Intermediadorclienteid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Intermediadorclientedocumento","iparms":[]}""");
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
         AV15FilterFullText = "";
         AV16DynamicFiltersSelector1 = "";
         AV19ClienteDocumento1 = "";
         AV20IntermediadorClienteDocumento1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV25ClienteDocumento2 = "";
         AV26IntermediadorClienteDocumento2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31ClienteDocumento3 = "";
         AV32IntermediadorClienteDocumento3 = "";
         AV60Pgmname = "";
         AV41TFClienteRazaoSocial = "";
         AV42TFClienteRazaoSocial_Sel = "";
         AV43TFClienteDocumento = "";
         AV44TFClienteDocumento_Sel = "";
         AV47TFIntermediadorClienteRazaoSocial = "";
         AV48TFIntermediadorClienteRazaoSocial_Sel = "";
         AV49TFIntermediadorClienteDocumento = "";
         AV50TFIntermediadorClienteDocumento_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55GridAppliedFilters = "";
         AV51DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         AV56Display = "";
         AV57Update = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A221IntermediadorClienteRazaoSocial = "";
         A222IntermediadorClienteDocumento = "";
         lV61Financiamentowwds_1_filterfulltext = "";
         lV65Financiamentowwds_5_clientedocumento1 = "";
         lV66Financiamentowwds_6_intermediadorclientedocumento1 = "";
         lV71Financiamentowwds_11_clientedocumento2 = "";
         lV72Financiamentowwds_12_intermediadorclientedocumento2 = "";
         lV77Financiamentowwds_17_clientedocumento3 = "";
         lV78Financiamentowwds_18_intermediadorclientedocumento3 = "";
         lV79Financiamentowwds_19_tfclienterazaosocial = "";
         lV81Financiamentowwds_21_tfclientedocumento = "";
         lV85Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         lV87Financiamentowwds_27_tfintermediadorclientedocumento = "";
         AV61Financiamentowwds_1_filterfulltext = "";
         AV62Financiamentowwds_2_dynamicfiltersselector1 = "";
         AV65Financiamentowwds_5_clientedocumento1 = "";
         AV66Financiamentowwds_6_intermediadorclientedocumento1 = "";
         AV68Financiamentowwds_8_dynamicfiltersselector2 = "";
         AV71Financiamentowwds_11_clientedocumento2 = "";
         AV72Financiamentowwds_12_intermediadorclientedocumento2 = "";
         AV74Financiamentowwds_14_dynamicfiltersselector3 = "";
         AV77Financiamentowwds_17_clientedocumento3 = "";
         AV78Financiamentowwds_18_intermediadorclientedocumento3 = "";
         AV80Financiamentowwds_20_tfclienterazaosocial_sel = "";
         AV79Financiamentowwds_19_tfclienterazaosocial = "";
         AV82Financiamentowwds_22_tfclientedocumento_sel = "";
         AV81Financiamentowwds_21_tfclientedocumento = "";
         AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = "";
         AV85Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel = "";
         AV87Financiamentowwds_27_tfintermediadorclientedocumento = "";
         H004E2_A222IntermediadorClienteDocumento = new string[] {""} ;
         H004E2_n222IntermediadorClienteDocumento = new bool[] {false} ;
         H004E2_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         H004E2_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         H004E2_A220IntermediadorClienteId = new int[1] ;
         H004E2_n220IntermediadorClienteId = new bool[] {false} ;
         H004E2_A224FinanciamentoValor = new decimal[1] ;
         H004E2_n224FinanciamentoValor = new bool[] {false} ;
         H004E2_A169ClienteDocumento = new string[] {""} ;
         H004E2_n169ClienteDocumento = new bool[] {false} ;
         H004E2_A170ClienteRazaoSocial = new string[] {""} ;
         H004E2_n170ClienteRazaoSocial = new bool[] {false} ;
         H004E2_A168ClienteId = new int[1] ;
         H004E2_n168ClienteId = new bool[] {false} ;
         H004E2_A223FinanciamentoId = new int[1] ;
         H004E3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamentoww__default(),
            new Object[][] {
                new Object[] {
               H004E2_A222IntermediadorClienteDocumento, H004E2_n222IntermediadorClienteDocumento, H004E2_A221IntermediadorClienteRazaoSocial, H004E2_n221IntermediadorClienteRazaoSocial, H004E2_A220IntermediadorClienteId, H004E2_n220IntermediadorClienteId, H004E2_A224FinanciamentoValor, H004E2_n224FinanciamentoValor, H004E2_A169ClienteDocumento, H004E2_n169ClienteDocumento,
               H004E2_A170ClienteRazaoSocial, H004E2_n170ClienteRazaoSocial, H004E2_A168ClienteId, H004E2_n168ClienteId, H004E2_A223FinanciamentoId
               }
               , new Object[] {
               H004E3_AGRID_nRecordCount
               }
            }
         );
         AV60Pgmname = "FinanciamentoWW";
         /* GeneXus formulas. */
         AV60Pgmname = "FinanciamentoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV63Financiamentowwds_3_dynamicfiltersoperator1 ;
      private short AV69Financiamentowwds_9_dynamicfiltersoperator2 ;
      private short AV75Financiamentowwds_15_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_127 ;
      private int nGXsfl_127_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A223FinanciamentoId ;
      private int A168ClienteId ;
      private int A220IntermediadorClienteId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtFinanciamentoId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int edtFinanciamentoValor_Enabled ;
      private int edtIntermediadorClienteId_Enabled ;
      private int edtIntermediadorClienteRazaoSocial_Enabled ;
      private int edtIntermediadorClienteDocumento_Enabled ;
      private int AV52PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavFinanciamentovalor1_Visible ;
      private int edtavClientedocumento1_Visible ;
      private int edtavIntermediadorclientedocumento1_Visible ;
      private int edtavFinanciamentovalor2_Visible ;
      private int edtavClientedocumento2_Visible ;
      private int edtavIntermediadorclientedocumento2_Visible ;
      private int edtavFinanciamentovalor3_Visible ;
      private int edtavClientedocumento3_Visible ;
      private int edtavIntermediadorclientedocumento3_Visible ;
      private int AV89GXV1 ;
      private int edtavFinanciamentovalor3_Enabled ;
      private int edtavClientedocumento3_Enabled ;
      private int edtavIntermediadorclientedocumento3_Enabled ;
      private int edtavFinanciamentovalor2_Enabled ;
      private int edtavClientedocumento2_Enabled ;
      private int edtavIntermediadorclientedocumento2_Enabled ;
      private int edtavFinanciamentovalor1_Enabled ;
      private int edtavClientedocumento1_Enabled ;
      private int edtavIntermediadorclientedocumento1_Enabled ;
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
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV18FinanciamentoValor1 ;
      private decimal AV24FinanciamentoValor2 ;
      private decimal AV30FinanciamentoValor3 ;
      private decimal AV45TFFinanciamentoValor ;
      private decimal AV46TFFinanciamentoValor_To ;
      private decimal A224FinanciamentoValor ;
      private decimal AV64Financiamentowwds_4_financiamentovalor1 ;
      private decimal AV70Financiamentowwds_10_financiamentovalor2 ;
      private decimal AV76Financiamentowwds_16_financiamentovalor3 ;
      private decimal AV83Financiamentowwds_23_tffinanciamentovalor ;
      private decimal AV84Financiamentowwds_24_tffinanciamentovalor_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_127_idx="0001" ;
      private string AV60Pgmname ;
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
      private string Ddo_grid_Format ;
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
      private string AV56Display ;
      private string edtavDisplay_Internalname ;
      private string AV57Update ;
      private string edtavUpdate_Internalname ;
      private string edtFinanciamentoId_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteDocumento_Internalname ;
      private string edtFinanciamentoValor_Internalname ;
      private string edtIntermediadorClienteId_Internalname ;
      private string edtIntermediadorClienteRazaoSocial_Internalname ;
      private string edtIntermediadorClienteDocumento_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavFinanciamentovalor1_Internalname ;
      private string edtavClientedocumento1_Internalname ;
      private string edtavIntermediadorclientedocumento1_Internalname ;
      private string edtavFinanciamentovalor2_Internalname ;
      private string edtavClientedocumento2_Internalname ;
      private string edtavIntermediadorclientedocumento2_Internalname ;
      private string edtavFinanciamentovalor3_Internalname ;
      private string edtavClientedocumento3_Internalname ;
      private string edtavIntermediadorclientedocumento3_Internalname ;
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
      private string edtClienteDocumento_Link ;
      private string edtFinanciamentoValor_Link ;
      private string edtIntermediadorClienteDocumento_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_financiamentovalor3_cell_Internalname ;
      private string edtavFinanciamentovalor3_Jsonclick ;
      private string cellFilter_clientedocumento3_cell_Internalname ;
      private string edtavClientedocumento3_Jsonclick ;
      private string cellFilter_intermediadorclientedocumento3_cell_Internalname ;
      private string edtavIntermediadorclientedocumento3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_financiamentovalor2_cell_Internalname ;
      private string edtavFinanciamentovalor2_Jsonclick ;
      private string cellFilter_clientedocumento2_cell_Internalname ;
      private string edtavClientedocumento2_Jsonclick ;
      private string cellFilter_intermediadorclientedocumento2_cell_Internalname ;
      private string edtavIntermediadorclientedocumento2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_financiamentovalor1_cell_Internalname ;
      private string edtavFinanciamentovalor1_Jsonclick ;
      private string cellFilter_clientedocumento1_cell_Internalname ;
      private string edtavClientedocumento1_Jsonclick ;
      private string cellFilter_intermediadorclientedocumento1_cell_Internalname ;
      private string edtavIntermediadorclientedocumento1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_127_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtFinanciamentoId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtFinanciamentoValor_Jsonclick ;
      private string edtIntermediadorClienteId_Jsonclick ;
      private string edtIntermediadorClienteRazaoSocial_Jsonclick ;
      private string edtIntermediadorClienteDocumento_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
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
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n224FinanciamentoValor ;
      private bool n220IntermediadorClienteId ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool n222IntermediadorClienteDocumento ;
      private bool bGXsfl_127_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV67Financiamentowwds_7_dynamicfiltersenabled2 ;
      private bool AV73Financiamentowwds_13_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV39ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV19ClienteDocumento1 ;
      private string AV20IntermediadorClienteDocumento1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV25ClienteDocumento2 ;
      private string AV26IntermediadorClienteDocumento2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV31ClienteDocumento3 ;
      private string AV32IntermediadorClienteDocumento3 ;
      private string AV41TFClienteRazaoSocial ;
      private string AV42TFClienteRazaoSocial_Sel ;
      private string AV43TFClienteDocumento ;
      private string AV44TFClienteDocumento_Sel ;
      private string AV47TFIntermediadorClienteRazaoSocial ;
      private string AV48TFIntermediadorClienteRazaoSocial_Sel ;
      private string AV49TFIntermediadorClienteDocumento ;
      private string AV50TFIntermediadorClienteDocumento_Sel ;
      private string AV55GridAppliedFilters ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string A222IntermediadorClienteDocumento ;
      private string lV61Financiamentowwds_1_filterfulltext ;
      private string lV65Financiamentowwds_5_clientedocumento1 ;
      private string lV66Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string lV71Financiamentowwds_11_clientedocumento2 ;
      private string lV72Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string lV77Financiamentowwds_17_clientedocumento3 ;
      private string lV78Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string lV79Financiamentowwds_19_tfclienterazaosocial ;
      private string lV81Financiamentowwds_21_tfclientedocumento ;
      private string lV85Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string lV87Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string AV61Financiamentowwds_1_filterfulltext ;
      private string AV62Financiamentowwds_2_dynamicfiltersselector1 ;
      private string AV65Financiamentowwds_5_clientedocumento1 ;
      private string AV66Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string AV68Financiamentowwds_8_dynamicfiltersselector2 ;
      private string AV71Financiamentowwds_11_clientedocumento2 ;
      private string AV72Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string AV74Financiamentowwds_14_dynamicfiltersselector3 ;
      private string AV77Financiamentowwds_17_clientedocumento3 ;
      private string AV78Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string AV80Financiamentowwds_20_tfclienterazaosocial_sel ;
      private string AV79Financiamentowwds_19_tfclienterazaosocial ;
      private string AV82Financiamentowwds_22_tfclientedocumento_sel ;
      private string AV81Financiamentowwds_21_tfclientedocumento ;
      private string AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ;
      private string AV85Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel ;
      private string AV87Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private IGxSession AV37Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV51DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H004E2_A222IntermediadorClienteDocumento ;
      private bool[] H004E2_n222IntermediadorClienteDocumento ;
      private string[] H004E2_A221IntermediadorClienteRazaoSocial ;
      private bool[] H004E2_n221IntermediadorClienteRazaoSocial ;
      private int[] H004E2_A220IntermediadorClienteId ;
      private bool[] H004E2_n220IntermediadorClienteId ;
      private decimal[] H004E2_A224FinanciamentoValor ;
      private bool[] H004E2_n224FinanciamentoValor ;
      private string[] H004E2_A169ClienteDocumento ;
      private bool[] H004E2_n169ClienteDocumento ;
      private string[] H004E2_A170ClienteRazaoSocial ;
      private bool[] H004E2_n170ClienteRazaoSocial ;
      private int[] H004E2_A168ClienteId ;
      private bool[] H004E2_n168ClienteId ;
      private int[] H004E2_A223FinanciamentoId ;
      private long[] H004E3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class financiamentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004E2( IGxContext context ,
                                             string AV61Financiamentowwds_1_filterfulltext ,
                                             string AV62Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV63Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV64Financiamentowwds_4_financiamentovalor1 ,
                                             string AV65Financiamentowwds_5_clientedocumento1 ,
                                             string AV66Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV67Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV68Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV69Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV70Financiamentowwds_10_financiamentovalor2 ,
                                             string AV71Financiamentowwds_11_clientedocumento2 ,
                                             string AV72Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV73Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV74Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV75Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV76Financiamentowwds_16_financiamentovalor3 ,
                                             string AV77Financiamentowwds_17_clientedocumento3 ,
                                             string AV78Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV80Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV79Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV82Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV81Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV83Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV84Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV85Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV87Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[39];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.ClienteDocumento AS IntermediadorClienteDocumento, T2.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T1.IntermediadorClienteId AS IntermediadorClienteId, T1.FinanciamentoValor, T3.ClienteDocumento, T3.ClienteRazaoSocial, T1.ClienteId, T1.FinanciamentoId";
         sFromString = " FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.IntermediadorClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T3.ClienteRazaoSocial like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T2.ClienteRazaoSocial like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV61Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV65Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV65Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV66Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV66Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV71Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV71Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV72Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV72Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV77Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV77Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV78Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV78Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV79Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV80Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV80Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( StringUtil.StrCmp(AV80Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV81Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV82Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV82Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( StringUtil.StrCmp(AV82Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV83Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV83Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV84Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV85Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( StringUtil.StrCmp(AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV87Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( StringUtil.StrCmp(AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T1.FinanciamentoValor, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.FinanciamentoValor DESC, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ClienteRazaoSocial, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ClienteRazaoSocial DESC, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T3.ClienteDocumento, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.ClienteDocumento DESC, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ClienteRazaoSocial DESC, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY T2.ClienteDocumento, T1.FinanciamentoId";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.ClienteDocumento DESC, T1.FinanciamentoId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.FinanciamentoId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H004E3( IGxContext context ,
                                             string AV61Financiamentowwds_1_filterfulltext ,
                                             string AV62Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV63Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV64Financiamentowwds_4_financiamentovalor1 ,
                                             string AV65Financiamentowwds_5_clientedocumento1 ,
                                             string AV66Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV67Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV68Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV69Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV70Financiamentowwds_10_financiamentovalor2 ,
                                             string AV71Financiamentowwds_11_clientedocumento2 ,
                                             string AV72Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV73Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV74Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV75Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV76Financiamentowwds_16_financiamentovalor3 ,
                                             string AV77Financiamentowwds_17_clientedocumento3 ,
                                             string AV78Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV80Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV79Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV82Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV81Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV83Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV84Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV85Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV87Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[36];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((Financiamento T1 LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId) LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV61Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV61Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV64Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV64Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV65Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV65Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV66Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV63Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV66Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV70Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV70Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV71Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV71Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV72Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV67Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV69Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV72Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV76Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV76Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV77Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV77Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV78Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( AV73Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV75Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV78Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV79Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV80Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV80Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( StringUtil.StrCmp(AV80Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV81Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV82Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV82Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( StringUtil.StrCmp(AV82Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV83Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV83Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV84Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV85Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( StringUtil.StrCmp(AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV87Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( StringUtil.StrCmp(AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
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
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H004E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
               case 1 :
                     return conditional_H004E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmH004E2;
          prmH004E2 = new Object[] {
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV65Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV65Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV71Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV71Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV77Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV77Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV80Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV81Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV82Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV84Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV85Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV87Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004E3;
          prmH004E3 = new Object[] {
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV64Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV65Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV65Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV66Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV70Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV71Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV71Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV72Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV76Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV77Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV77Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV78Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV79Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV80Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV81Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV82Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV83Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV84Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV85Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV86Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV87Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV88Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
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
