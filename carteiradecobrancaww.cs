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
   public class carteiradecobrancaww : GXDataArea
   {
      public carteiradecobrancaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobrancaww( IGxContext context )
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
         cmbavGridactiongroup1 = new GXCombobox();
         cmbCarteiraDeCobrancaStatus = new GXCombobox();
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
         nRC_GXsfl_109 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_109"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_109_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_109_idx = GetPar( "sGXsfl_109_idx");
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
         AV18CarteiraDeCobrancaCodigo1 = GetPar( "CarteiraDeCobrancaCodigo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV22CarteiraDeCobrancaCodigo2 = GetPar( "CarteiraDeCobrancaCodigo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV26CarteiraDeCobrancaCodigo3 = GetPar( "CarteiraDeCobrancaCodigo3");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV51Pgmname = GetPar( "Pgmname");
         AV19DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV23DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV37TFCarteiraDeCobrancaNome = GetPar( "TFCarteiraDeCobrancaNome");
         AV38TFCarteiraDeCobrancaNome_Sel = GetPar( "TFCarteiraDeCobrancaNome_Sel");
         AV39TFCarteiraDeCobrancaConvenio = GetPar( "TFCarteiraDeCobrancaConvenio");
         AV40TFCarteiraDeCobrancaConvenio_Sel = GetPar( "TFCarteiraDeCobrancaConvenio_Sel");
         AV41TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFCarteiraDeCobrancaStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV28DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV27DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
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
         PAA72( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA72( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carteiradecobrancaww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vCARTEIRADECOBRANCACODIGO1", AV18CarteiraDeCobrancaCodigo1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV20DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCARTEIRADECOBRANCACODIGO2", AV22CarteiraDeCobrancaCodigo2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV24DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCARTEIRADECOBRANCACODIGO3", AV26CarteiraDeCobrancaCodigo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_109", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_109), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV32ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV46GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV19DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV23DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFCARTEIRADECOBRANCANOME", AV37TFCarteiraDeCobrancaNome);
         GxWebStd.gx_hidden_field( context, "vTFCARTEIRADECOBRANCANOME_SEL", AV38TFCarteiraDeCobrancaNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCARTEIRADECOBRANCACONVENIO", AV39TFCarteiraDeCobrancaConvenio);
         GxWebStd.gx_hidden_field( context, "vTFCARTEIRADECOBRANCACONVENIO_SEL", AV40TFCarteiraDeCobrancaConvenio_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCARTEIRADECOBRANCASTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0, ",", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV28DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV27DynamicFiltersRemoving);
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
            WEA72( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA72( ) ;
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
         return formatLink("carteiradecobrancaww")  ;
      }

      public override string GetPgmname( )
      {
         return "CarteiraDeCobrancaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Carteira De Cobranca" ;
      }

      protected void WBA70( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarteiraDeCobrancaWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV32ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV15FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV15FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_CarteiraDeCobrancaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV16DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_A72( true) ;
         }
         else
         {
            wb_table1_47_A72( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_A72e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV20DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_69_A72( true) ;
         }
         else
         {
            wb_table2_69_A72( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_A72e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_91_A72( true) ;
         }
         else
         {
            wb_table3_91_A72( false) ;
         }
         return  ;
      }

      protected void wb_table3_91_A72e( bool wbgen )
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
            StartGridControl109( ) ;
         }
         if ( wbEnd == 109 )
         {
            wbEnd = 0;
            nRC_GXsfl_109 = (int)(nGXsfl_109_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV44GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV45GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV46GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_CarteiraDeCobrancaWW.htm");
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
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 109 )
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

      protected void STARTA72( )
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
         Form.Meta.addItem("description", " Carteira De Cobranca", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA70( ) ;
      }

      protected void WSA72( )
      {
         STARTA72( ) ;
         EVTA72( ) ;
      }

      protected void EVTA72( )
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
                              E11A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E19A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E20A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E21A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E23A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24A72 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25A72 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
                              SubsflControlProps_1092( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV50GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActionGroup1), 4, 0));
                              A1069CarteiraDeCobrancaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCarteiraDeCobrancaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A1070CarteiraDeCobrancaCodigo = cgiGet( edtCarteiraDeCobrancaCodigo_Internalname);
                              n1070CarteiraDeCobrancaCodigo = false;
                              A1071CarteiraDeCobrancaNome = cgiGet( edtCarteiraDeCobrancaNome_Internalname);
                              n1071CarteiraDeCobrancaNome = false;
                              A1072CarteiraDeCobrancaWorkspaceId = StringUtil.StrToGuid( cgiGet( edtCarteiraDeCobrancaWorkspaceId_Internalname));
                              n1072CarteiraDeCobrancaWorkspaceId = false;
                              A1073CarteiraDeCobrancaConvenio = cgiGet( edtCarteiraDeCobrancaConvenio_Internalname);
                              n1073CarteiraDeCobrancaConvenio = false;
                              cmbCarteiraDeCobrancaStatus.Name = cmbCarteiraDeCobrancaStatus_Internalname;
                              cmbCarteiraDeCobrancaStatus.CurrentValue = cgiGet( cmbCarteiraDeCobrancaStatus_Internalname);
                              A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cgiGet( cmbCarteiraDeCobrancaStatus_Internalname));
                              n1074CarteiraDeCobrancaStatus = false;
                              A1075CarteiraDeCobrancaCreatedAt = context.localUtil.CToT( cgiGet( edtCarteiraDeCobrancaCreatedAt_Internalname), 0);
                              n1075CarteiraDeCobrancaCreatedAt = false;
                              A1076CarteiraDeCobrancaUpdatedAt = context.localUtil.CToT( cgiGet( edtCarteiraDeCobrancaUpdatedAt_Internalname), 0);
                              n1076CarteiraDeCobrancaUpdatedAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E26A72 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E27A72 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E28A72 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E29A72 ();
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
                                       /* Set Refresh If Carteiradecobrancacodigo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO1"), AV18CarteiraDeCobrancaCodigo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Carteiradecobrancacodigo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO2"), AV22CarteiraDeCobrancaCodigo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Carteiradecobrancacodigo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO3"), AV26CarteiraDeCobrancaCodigo3) != 0 )
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

      protected void WEA72( )
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

      protected void PAA72( )
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
         SubsflControlProps_1092( ) ;
         while ( nGXsfl_109_idx <= nRC_GXsfl_109 )
         {
            sendrow_1092( ) ;
            nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
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
                                       string AV18CarteiraDeCobrancaCodigo1 ,
                                       string AV20DynamicFiltersSelector2 ,
                                       short AV21DynamicFiltersOperator2 ,
                                       string AV22CarteiraDeCobrancaCodigo2 ,
                                       string AV24DynamicFiltersSelector3 ,
                                       short AV25DynamicFiltersOperator3 ,
                                       string AV26CarteiraDeCobrancaCodigo3 ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV51Pgmname ,
                                       bool AV19DynamicFiltersEnabled2 ,
                                       bool AV23DynamicFiltersEnabled3 ,
                                       string AV37TFCarteiraDeCobrancaNome ,
                                       string AV38TFCarteiraDeCobrancaNome_Sel ,
                                       string AV39TFCarteiraDeCobrancaConvenio ,
                                       string AV40TFCarteiraDeCobrancaConvenio_Sel ,
                                       short AV41TFCarteiraDeCobrancaStatus_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV28DynamicFiltersIgnoreFirst ,
                                       bool AV27DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA72( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CARTEIRADECOBRANCAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CARTEIRADECOBRANCAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", "")));
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
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA72( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV51Pgmname = "CarteiraDeCobrancaWW";
      }

      protected void RFA72( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E27A72 ();
         nGXsfl_109_idx = 1;
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         bGXsfl_109_Refreshing = true;
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
            SubsflControlProps_1092( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV52Carteiradecobrancawwds_1_filterfulltext ,
                                                 AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                                 AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                                 AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                                 AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                                 AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                                 AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                                 AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                                 AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                                 AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                                 AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                                 AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                                 AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                                 AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                                 AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                                 AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                                 AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                                 A1071CarteiraDeCobrancaNome ,
                                                 A1073CarteiraDeCobrancaConvenio ,
                                                 A1074CarteiraDeCobrancaStatus ,
                                                 A1070CarteiraDeCobrancaCodigo ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
            lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
            lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
            lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
            lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
            lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
            lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
            lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
            lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
            lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
            lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
            lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
            /* Using cursor H00A72 */
            pr_default.execute(0, new Object[] {lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_109_idx = 1;
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1076CarteiraDeCobrancaUpdatedAt = H00A72_A1076CarteiraDeCobrancaUpdatedAt[0];
               n1076CarteiraDeCobrancaUpdatedAt = H00A72_n1076CarteiraDeCobrancaUpdatedAt[0];
               A1075CarteiraDeCobrancaCreatedAt = H00A72_A1075CarteiraDeCobrancaCreatedAt[0];
               n1075CarteiraDeCobrancaCreatedAt = H00A72_n1075CarteiraDeCobrancaCreatedAt[0];
               A1074CarteiraDeCobrancaStatus = H00A72_A1074CarteiraDeCobrancaStatus[0];
               n1074CarteiraDeCobrancaStatus = H00A72_n1074CarteiraDeCobrancaStatus[0];
               A1073CarteiraDeCobrancaConvenio = H00A72_A1073CarteiraDeCobrancaConvenio[0];
               n1073CarteiraDeCobrancaConvenio = H00A72_n1073CarteiraDeCobrancaConvenio[0];
               A1072CarteiraDeCobrancaWorkspaceId = H00A72_A1072CarteiraDeCobrancaWorkspaceId[0];
               n1072CarteiraDeCobrancaWorkspaceId = H00A72_n1072CarteiraDeCobrancaWorkspaceId[0];
               A1071CarteiraDeCobrancaNome = H00A72_A1071CarteiraDeCobrancaNome[0];
               n1071CarteiraDeCobrancaNome = H00A72_n1071CarteiraDeCobrancaNome[0];
               A1070CarteiraDeCobrancaCodigo = H00A72_A1070CarteiraDeCobrancaCodigo[0];
               n1070CarteiraDeCobrancaCodigo = H00A72_n1070CarteiraDeCobrancaCodigo[0];
               A1069CarteiraDeCobrancaId = H00A72_A1069CarteiraDeCobrancaId[0];
               /* Execute user event: Grid.Load */
               E28A72 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 109;
            WBA70( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA72( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV51Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV51Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CARTEIRADECOBRANCAID"+"_"+sGXsfl_109_idx, GetSecureSignedToken( sGXsfl_109_idx, context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9"), context));
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
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV52Carteiradecobrancawwds_1_filterfulltext ,
                                              AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                              AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                              AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                              AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                              AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                              AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                              AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                              AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                              AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                              AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                              AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                              AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                              AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                              AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                              AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                              AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                              A1071CarteiraDeCobrancaNome ,
                                              A1073CarteiraDeCobrancaConvenio ,
                                              A1074CarteiraDeCobrancaStatus ,
                                              A1070CarteiraDeCobrancaCodigo ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV52Carteiradecobrancawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext), "%", "");
         lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = StringUtil.Concat( StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1), "%", "");
         lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = StringUtil.Concat( StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2), "%", "");
         lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = StringUtil.Concat( StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3), "%", "");
         lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = StringUtil.Concat( StringUtil.RTrim( AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome), "%", "");
         lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = StringUtil.Concat( StringUtil.RTrim( AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio), "%", "");
         /* Using cursor H00A73 */
         pr_default.execute(1, new Object[] {lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV52Carteiradecobrancawwds_1_filterfulltext, lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1, lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2, lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3, lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome, AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio, AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel});
         GRID_nRecordCount = H00A73_AGRID_nRecordCount[0];
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
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV51Pgmname = "CarteiraDeCobrancaWW";
         edtCarteiraDeCobrancaId_Enabled = 0;
         edtCarteiraDeCobrancaCodigo_Enabled = 0;
         edtCarteiraDeCobrancaNome_Enabled = 0;
         edtCarteiraDeCobrancaWorkspaceId_Enabled = 0;
         edtCarteiraDeCobrancaConvenio_Enabled = 0;
         cmbCarteiraDeCobrancaStatus.Enabled = 0;
         edtCarteiraDeCobrancaCreatedAt_Enabled = 0;
         edtCarteiraDeCobrancaUpdatedAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA70( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E26A72 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV32ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_109"), ",", "."), 18, MidpointRounding.ToEven));
            AV44GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV45GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV46GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV18CarteiraDeCobrancaCodigo1 = cgiGet( edtavCarteiradecobrancacodigo1_Internalname);
            AssignAttri("", false, "AV18CarteiraDeCobrancaCodigo1", AV18CarteiraDeCobrancaCodigo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV20DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AV22CarteiraDeCobrancaCodigo2 = cgiGet( edtavCarteiradecobrancacodigo2_Internalname);
            AssignAttri("", false, "AV22CarteiraDeCobrancaCodigo2", AV22CarteiraDeCobrancaCodigo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV24DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AV26CarteiraDeCobrancaCodigo3 = cgiGet( edtavCarteiradecobrancacodigo3_Internalname);
            AssignAttri("", false, "AV26CarteiraDeCobrancaCodigo3", AV26CarteiraDeCobrancaCodigo3);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO1"), AV18CarteiraDeCobrancaCodigo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV20DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV21DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO2"), AV22CarteiraDeCobrancaCodigo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV24DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV25DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCARTEIRADECOBRANCACODIGO3"), AV26CarteiraDeCobrancaCodigo3) != 0 )
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
         E26A72 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E26A72( )
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
         AV16DynamicFiltersSelector1 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersSelector2 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersSelector3 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
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
         Form.Caption = " Carteira De Cobranca";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E27A72( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV34ManageFiltersExecutionStep == 1 )
         {
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV34ManageFiltersExecutionStep == 2 )
         {
            AV34ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
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
         AssignAttri("", false, "AV44GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV44GridCurrentPage), 10, 0));
         AV45GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV45GridPageCount", StringUtil.LTrimStr( (decimal)(AV45GridPageCount), 10, 0));
         GXt_char2 = AV46GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV51Pgmname, out  GXt_char2) ;
         AV46GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV46GridAppliedFilters", AV46GridAppliedFilters);
         AV52Carteiradecobrancawwds_1_filterfulltext = AV15FilterFullText;
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = AV16DynamicFiltersSelector1;
         AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 = AV17DynamicFiltersOperator1;
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = AV18CarteiraDeCobrancaCodigo1;
         AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = AV22CarteiraDeCobrancaCodigo2;
         AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = AV26CarteiraDeCobrancaCodigo3;
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = AV37TFCarteiraDeCobrancaNome;
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = AV38TFCarteiraDeCobrancaNome_Sel;
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = AV39TFCarteiraDeCobrancaConvenio;
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = AV40TFCarteiraDeCobrancaConvenio_Sel;
         AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel = AV41TFCarteiraDeCobrancaStatus_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A72( )
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

      protected void E13A72( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A72( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CarteiraDeCobrancaNome") == 0 )
            {
               AV37TFCarteiraDeCobrancaNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV37TFCarteiraDeCobrancaNome", AV37TFCarteiraDeCobrancaNome);
               AV38TFCarteiraDeCobrancaNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV38TFCarteiraDeCobrancaNome_Sel", AV38TFCarteiraDeCobrancaNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CarteiraDeCobrancaConvenio") == 0 )
            {
               AV39TFCarteiraDeCobrancaConvenio = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV39TFCarteiraDeCobrancaConvenio", AV39TFCarteiraDeCobrancaConvenio);
               AV40TFCarteiraDeCobrancaConvenio_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV40TFCarteiraDeCobrancaConvenio_Sel", AV40TFCarteiraDeCobrancaConvenio_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CarteiraDeCobrancaStatus") == 0 )
            {
               AV41TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFCarteiraDeCobrancaStatus_Sel", StringUtil.Str( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E28A72( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Mostrar", "fa fa-search", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("3", StringUtil.Format( "%1;%2", "Boletos", "fas fa-file-invoice-dollar", "", "", "", "", "", "", ""), 0);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 109;
         }
         sendrow_1092( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_109_Refreshing )
         {
            DoAjaxLoad(109, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0));
      }

      protected void E21A72( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15A72( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
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
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV28DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV28DynamicFiltersIgnoreFirst", AV28DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E22A72( )
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

      protected void E23A72( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16A72( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
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
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E24A72( )
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

      protected void E17A72( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV27DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
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
         AssignAttri("", false, "AV27DynamicFiltersRemoving", AV27DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedBy, AV14OrderedDsc, AV15FilterFullText, AV16DynamicFiltersSelector1, AV17DynamicFiltersOperator1, AV18CarteiraDeCobrancaCodigo1, AV20DynamicFiltersSelector2, AV21DynamicFiltersOperator2, AV22CarteiraDeCobrancaCodigo2, AV24DynamicFiltersSelector3, AV25DynamicFiltersOperator3, AV26CarteiraDeCobrancaCodigo3, AV34ManageFiltersExecutionStep, AV51Pgmname, AV19DynamicFiltersEnabled2, AV23DynamicFiltersEnabled3, AV37TFCarteiraDeCobrancaNome, AV38TFCarteiraDeCobrancaNome_Sel, AV39TFCarteiraDeCobrancaConvenio, AV40TFCarteiraDeCobrancaConvenio_Sel, AV41TFCarteiraDeCobrancaStatus_Sel, AV10GridState, AV28DynamicFiltersIgnoreFirst, AV27DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E25A72( )
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

      protected void E11A72( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("CarteiraDeCobrancaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV51Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("CarteiraDeCobrancaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV33ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "CarteiraDeCobrancaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV33ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV33ManageFiltersXml) ;
               AV10GridState.FromXml(AV33ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ManageFiltersData", AV32ManageFiltersData);
      }

      protected void E29A72( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV50GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV50GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV50GridActionGroup1 == 3 )
         {
            /* Execute user subroutine: 'DO BOLETOS' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV50GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
      }

      protected void E18A72( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "carteiradecobranca"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("carteiradecobranca") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E19A72( )
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
         new carteiradecobrancawwexport(context ).execute( out  AV29ExcelFilename, out  AV30ErrorMessage) ;
         if ( StringUtil.StrCmp(AV29ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV29ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV30ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV16DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E20A72( )
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
         Innewwindow1_Target = formatLink("carteiradecobrancawwexportreport") ;
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV20DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
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
         edtavCarteiradecobrancacodigo1_Visible = 0;
         AssignProp("", false, edtavCarteiradecobrancacodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 )
         {
            edtavCarteiradecobrancacodigo1_Visible = 1;
            AssignProp("", false, edtavCarteiradecobrancacodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavCarteiradecobrancacodigo2_Visible = 0;
         AssignProp("", false, edtavCarteiradecobrancacodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 )
         {
            edtavCarteiradecobrancacodigo2_Visible = 1;
            AssignProp("", false, edtavCarteiradecobrancacodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavCarteiradecobrancacodigo3_Visible = 0;
         AssignProp("", false, edtavCarteiradecobrancacodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 )
         {
            edtavCarteiradecobrancacodigo3_Visible = 1;
            AssignProp("", false, edtavCarteiradecobrancacodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCarteiradecobrancacodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV19DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
         AV20DynamicFiltersSelector2 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         AV21DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         AV22CarteiraDeCobrancaCodigo2 = "";
         AssignAttri("", false, "AV22CarteiraDeCobrancaCodigo2", AV22CarteiraDeCobrancaCodigo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
         AV24DynamicFiltersSelector3 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         AV25DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         AV26CarteiraDeCobrancaCodigo3 = "";
         AssignAttri("", false, "AV26CarteiraDeCobrancaCodigo3", AV26CarteiraDeCobrancaCodigo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV32ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "CarteiraDeCobrancaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV32ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV15FilterFullText = "";
         AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
         AV37TFCarteiraDeCobrancaNome = "";
         AssignAttri("", false, "AV37TFCarteiraDeCobrancaNome", AV37TFCarteiraDeCobrancaNome);
         AV38TFCarteiraDeCobrancaNome_Sel = "";
         AssignAttri("", false, "AV38TFCarteiraDeCobrancaNome_Sel", AV38TFCarteiraDeCobrancaNome_Sel);
         AV39TFCarteiraDeCobrancaConvenio = "";
         AssignAttri("", false, "AV39TFCarteiraDeCobrancaConvenio", AV39TFCarteiraDeCobrancaConvenio);
         AV40TFCarteiraDeCobrancaConvenio_Sel = "";
         AssignAttri("", false, "AV40TFCarteiraDeCobrancaConvenio_Sel", AV40TFCarteiraDeCobrancaConvenio_Sel);
         AV41TFCarteiraDeCobrancaStatus_Sel = 0;
         AssignAttri("", false, "AV41TFCarteiraDeCobrancaStatus_Sel", StringUtil.Str( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV16DynamicFiltersSelector1 = "CARTEIRADECOBRANCACODIGO";
         AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
         AV17DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
         AV18CarteiraDeCobrancaCodigo1 = "";
         AssignAttri("", false, "AV18CarteiraDeCobrancaCodigo1", AV18CarteiraDeCobrancaCodigo1);
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

      protected void S242( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "carteiradecobranca"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A1069CarteiraDeCobrancaId,9,0));
         CallWebObject(formatLink("carteiradecobranca") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S252( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "carteiradecobranca"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A1069CarteiraDeCobrancaId,9,0));
         CallWebObject(formatLink("carteiradecobranca") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S262( )
      {
         /* 'DO BOLETOS' Routine */
         returnInSub = false;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get(AV51Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV51Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV31Session.Get(AV51Pgmname+"GridState"), null, "", "");
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
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV15FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilterFullText", AV15FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME") == 0 )
            {
               AV37TFCarteiraDeCobrancaNome = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFCarteiraDeCobrancaNome", AV37TFCarteiraDeCobrancaNome);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCANOME_SEL") == 0 )
            {
               AV38TFCarteiraDeCobrancaNome_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV38TFCarteiraDeCobrancaNome_Sel", AV38TFCarteiraDeCobrancaNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO") == 0 )
            {
               AV39TFCarteiraDeCobrancaConvenio = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV39TFCarteiraDeCobrancaConvenio", AV39TFCarteiraDeCobrancaConvenio);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCACONVENIO_SEL") == 0 )
            {
               AV40TFCarteiraDeCobrancaConvenio_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFCarteiraDeCobrancaConvenio_Sel", AV40TFCarteiraDeCobrancaConvenio_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFCARTEIRADECOBRANCASTATUS_SEL") == 0 )
            {
               AV41TFCarteiraDeCobrancaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFCarteiraDeCobrancaStatus_Sel", StringUtil.Str( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0));
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCarteiraDeCobrancaNome_Sel)),  AV38TFCarteiraDeCobrancaNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCarteiraDeCobrancaConvenio_Sel)),  AV40TFCarteiraDeCobrancaConvenio_Sel, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+((0==AV41TFCarteiraDeCobrancaStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCarteiraDeCobrancaNome)),  AV37TFCarteiraDeCobrancaNome, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCarteiraDeCobrancaConvenio)),  AV39TFCarteiraDeCobrancaConvenio, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"|"+GXt_char2+"|";
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
         if ( AV10GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(1));
            AV16DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV16DynamicFiltersSelector1", AV16DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 )
            {
               AV17DynamicFiltersOperator1 = AV12GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV17DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
               AV18CarteiraDeCobrancaCodigo1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV18CarteiraDeCobrancaCodigo1", AV18CarteiraDeCobrancaCodigo1);
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
               AV19DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV19DynamicFiltersEnabled2", AV19DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV12GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
                  AV22CarteiraDeCobrancaCodigo2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV22CarteiraDeCobrancaCodigo2", AV22CarteiraDeCobrancaCodigo2);
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
                  AV23DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV23DynamicFiltersEnabled3", AV23DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV12GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
                     AV26CarteiraDeCobrancaCodigo3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV26CarteiraDeCobrancaCodigo3", AV26CarteiraDeCobrancaCodigo3);
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
         if ( AV27DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV31Session.Get(AV51Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilterFullText)),  0,  AV15FilterFullText,  AV15FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCARTEIRADECOBRANCANOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCarteiraDeCobrancaNome)),  0,  AV37TFCarteiraDeCobrancaNome,  AV37TFCarteiraDeCobrancaNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCarteiraDeCobrancaNome_Sel)),  AV38TFCarteiraDeCobrancaNome_Sel,  AV38TFCarteiraDeCobrancaNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFCARTEIRADECOBRANCACONVENIO",  "Convênio",  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCarteiraDeCobrancaConvenio)),  0,  AV39TFCarteiraDeCobrancaConvenio,  AV39TFCarteiraDeCobrancaConvenio,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCarteiraDeCobrancaConvenio_Sel)),  AV40TFCarteiraDeCobrancaConvenio_Sel,  AV40TFCarteiraDeCobrancaConvenio_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFCARTEIRADECOBRANCASTATUS_SEL",  "Status",  !(0==AV41TFCarteiraDeCobrancaStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFCarteiraDeCobrancaStatus_Sel), 1, 0)),  ((AV41TFCarteiraDeCobrancaStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV51Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
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
            if ( ( StringUtil.StrCmp(AV16DynamicFiltersSelector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CarteiraDeCobrancaCodigo1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Código",  AV17DynamicFiltersOperator1,  AV18CarteiraDeCobrancaCodigo1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV18CarteiraDeCobrancaCodigo1, "Contém"+" "+AV18CarteiraDeCobrancaCodigo1, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CarteiraDeCobrancaCodigo2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Código",  AV21DynamicFiltersOperator2,  AV22CarteiraDeCobrancaCodigo2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV22CarteiraDeCobrancaCodigo2, "Contém"+" "+AV22CarteiraDeCobrancaCodigo2, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CarteiraDeCobrancaCodigo3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Código",  AV25DynamicFiltersOperator3,  AV26CarteiraDeCobrancaCodigo3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV26CarteiraDeCobrancaCodigo3, "Contém"+" "+AV26CarteiraDeCobrancaCodigo3, "", "", "", "", "", "", ""),  false,  "",  "") ;
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
         AV8TrnContext.gxTpr_Callerobject = AV51Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "CarteiraDeCobranca";
         AV31Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_91_A72( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_carteiradecobrancacodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancacodigo3_Internalname, "Carteira De Cobranca Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancacodigo3_Internalname, AV26CarteiraDeCobrancaCodigo3, StringUtil.RTrim( context.localUtil.Format( AV26CarteiraDeCobrancaCodigo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancacodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCarteiradecobrancacodigo3_Visible, edtavCarteiradecobrancacodigo3_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarteiraDeCobrancaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_91_A72e( true) ;
         }
         else
         {
            wb_table3_91_A72e( false) ;
         }
      }

      protected void wb_table2_69_A72( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_carteiradecobrancacodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancacodigo2_Internalname, "Carteira De Cobranca Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancacodigo2_Internalname, AV22CarteiraDeCobrancaCodigo2, StringUtil.RTrim( context.localUtil.Format( AV22CarteiraDeCobrancaCodigo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancacodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCarteiradecobrancacodigo2_Visible, edtavCarteiradecobrancacodigo2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarteiraDeCobrancaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarteiraDeCobrancaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_A72e( true) ;
         }
         else
         {
            wb_table2_69_A72e( false) ;
         }
      }

      protected void wb_table1_47_A72( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_CarteiraDeCobrancaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_carteiradecobrancacodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarteiradecobrancacodigo1_Internalname, "Carteira De Cobranca Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCarteiradecobrancacodigo1_Internalname, AV18CarteiraDeCobrancaCodigo1, StringUtil.RTrim( context.localUtil.Format( AV18CarteiraDeCobrancaCodigo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarteiradecobrancacodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCarteiradecobrancacodigo1_Visible, edtavCarteiradecobrancacodigo1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CarteiraDeCobrancaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarteiraDeCobrancaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarteiraDeCobrancaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_A72e( true) ;
         }
         else
         {
            wb_table1_47_A72e( false) ;
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
         PAA72( ) ;
         WSA72( ) ;
         WEA72( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019292829", true, true);
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
         context.AddJavascriptSource("carteiradecobrancaww.js", "?202561019292830", false, true);
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

      protected void SubsflControlProps_1092( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaCodigo_Internalname = "CARTEIRADECOBRANCACODIGO_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaNome_Internalname = "CARTEIRADECOBRANCANOME_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaWorkspaceId_Internalname = "CARTEIRADECOBRANCAWORKSPACEID_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaConvenio_Internalname = "CARTEIRADECOBRANCACONVENIO_"+sGXsfl_109_idx;
         cmbCarteiraDeCobrancaStatus_Internalname = "CARTEIRADECOBRANCASTATUS_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaCreatedAt_Internalname = "CARTEIRADECOBRANCACREATEDAT_"+sGXsfl_109_idx;
         edtCarteiraDeCobrancaUpdatedAt_Internalname = "CARTEIRADECOBRANCAUPDATEDAT_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaCodigo_Internalname = "CARTEIRADECOBRANCACODIGO_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaNome_Internalname = "CARTEIRADECOBRANCANOME_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaWorkspaceId_Internalname = "CARTEIRADECOBRANCAWORKSPACEID_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaConvenio_Internalname = "CARTEIRADECOBRANCACONVENIO_"+sGXsfl_109_fel_idx;
         cmbCarteiraDeCobrancaStatus_Internalname = "CARTEIRADECOBRANCASTATUS_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaCreatedAt_Internalname = "CARTEIRADECOBRANCACREATEDAT_"+sGXsfl_109_fel_idx;
         edtCarteiraDeCobrancaUpdatedAt_Internalname = "CARTEIRADECOBRANCAUPDATEDAT_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         WBA70( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_109_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_109_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_109_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_109_idx + "',109)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_109_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV50GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_109_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1069CarteiraDeCobrancaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaCodigo_Internalname,(string)A1070CarteiraDeCobrancaCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaNome_Internalname,(string)A1071CarteiraDeCobrancaNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaWorkspaceId_Internalname,A1072CarteiraDeCobrancaWorkspaceId.ToString(),A1072CarteiraDeCobrancaWorkspaceId.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaWorkspaceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)109,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaConvenio_Internalname,(string)A1073CarteiraDeCobrancaConvenio,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaConvenio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbCarteiraDeCobrancaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "CARTEIRADECOBRANCASTATUS_" + sGXsfl_109_idx;
               cmbCarteiraDeCobrancaStatus.Name = GXCCtl;
               cmbCarteiraDeCobrancaStatus.WebTags = "";
               cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
               {
                  A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
                  n1074CarteiraDeCobrancaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCarteiraDeCobrancaStatus,(string)cmbCarteiraDeCobrancaStatus_Internalname,StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus),(short)1,(string)cmbCarteiraDeCobrancaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbCarteiraDeCobrancaStatus.CurrentValue = StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus);
            AssignProp("", false, cmbCarteiraDeCobrancaStatus_Internalname, "Values", (string)(cmbCarteiraDeCobrancaStatus.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaCreatedAt_Internalname,context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1075CarteiraDeCobrancaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarteiraDeCobrancaUpdatedAt_Internalname,context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A1076CarteiraDeCobrancaUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarteiraDeCobrancaUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesA72( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_109_idx = ((subGrid_Islastpage==1)&&(nGXsfl_109_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_109_idx+1);
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
         }
         /* End function sendrow_1092 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CARTEIRADECOBRANCACODIGO", "Código", 0);
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
         cmbavDynamicfiltersselector2.addItem("CARTEIRADECOBRANCACODIGO", "Código", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV20DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV20DynamicFiltersSelector2);
            AssignAttri("", false, "AV20DynamicFiltersSelector2", AV20DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV21DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV21DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CARTEIRADECOBRANCACODIGO", "Código", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV24DynamicFiltersSelector3);
            AssignAttri("", false, "AV24DynamicFiltersSelector3", AV24DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_109_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV50GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV50GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV50GridActionGroup1), 4, 0));
         }
         GXCCtl = "CARTEIRADECOBRANCASTATUS_" + sGXsfl_109_idx;
         cmbCarteiraDeCobrancaStatus.Name = GXCCtl;
         cmbCarteiraDeCobrancaStatus.WebTags = "";
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbCarteiraDeCobrancaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbCarteiraDeCobrancaStatus.ItemCount > 0 )
         {
            A1074CarteiraDeCobrancaStatus = StringUtil.StrToBool( cmbCarteiraDeCobrancaStatus.getValidValue(StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            n1074CarteiraDeCobrancaStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl109( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"109\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cobranca Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Código") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Workspace Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Convênio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created At") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Updated At") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1069CarteiraDeCobrancaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1070CarteiraDeCobrancaCodigo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1071CarteiraDeCobrancaNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1072CarteiraDeCobrancaWorkspaceId.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1073CarteiraDeCobrancaConvenio));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A1074CarteiraDeCobrancaStatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1075CarteiraDeCobrancaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A1076CarteiraDeCobrancaUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
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
         edtavCarteiradecobrancacodigo1_Internalname = "vCARTEIRADECOBRANCACODIGO1";
         cellFilter_carteiradecobrancacodigo1_cell_Internalname = "FILTER_CARTEIRADECOBRANCACODIGO1_CELL";
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
         edtavCarteiradecobrancacodigo2_Internalname = "vCARTEIRADECOBRANCACODIGO2";
         cellFilter_carteiradecobrancacodigo2_cell_Internalname = "FILTER_CARTEIRADECOBRANCACODIGO2_CELL";
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
         edtavCarteiradecobrancacodigo3_Internalname = "vCARTEIRADECOBRANCACODIGO3";
         cellFilter_carteiradecobrancacodigo3_cell_Internalname = "FILTER_CARTEIRADECOBRANCACODIGO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtCarteiraDeCobrancaId_Internalname = "CARTEIRADECOBRANCAID";
         edtCarteiraDeCobrancaCodigo_Internalname = "CARTEIRADECOBRANCACODIGO";
         edtCarteiraDeCobrancaNome_Internalname = "CARTEIRADECOBRANCANOME";
         edtCarteiraDeCobrancaWorkspaceId_Internalname = "CARTEIRADECOBRANCAWORKSPACEID";
         edtCarteiraDeCobrancaConvenio_Internalname = "CARTEIRADECOBRANCACONVENIO";
         cmbCarteiraDeCobrancaStatus_Internalname = "CARTEIRADECOBRANCASTATUS";
         edtCarteiraDeCobrancaCreatedAt_Internalname = "CARTEIRADECOBRANCACREATEDAT";
         edtCarteiraDeCobrancaUpdatedAt_Internalname = "CARTEIRADECOBRANCAUPDATEDAT";
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
         edtCarteiraDeCobrancaUpdatedAt_Jsonclick = "";
         edtCarteiraDeCobrancaCreatedAt_Jsonclick = "";
         cmbCarteiraDeCobrancaStatus_Jsonclick = "";
         edtCarteiraDeCobrancaConvenio_Jsonclick = "";
         edtCarteiraDeCobrancaWorkspaceId_Jsonclick = "";
         edtCarteiraDeCobrancaNome_Jsonclick = "";
         edtCarteiraDeCobrancaCodigo_Jsonclick = "";
         edtCarteiraDeCobrancaId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavCarteiradecobrancacodigo1_Jsonclick = "";
         edtavCarteiradecobrancacodigo1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavCarteiradecobrancacodigo2_Jsonclick = "";
         edtavCarteiradecobrancacodigo2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCarteiradecobrancacodigo3_Jsonclick = "";
         edtavCarteiradecobrancacodigo3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavCarteiradecobrancacodigo3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavCarteiradecobrancacodigo2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavCarteiradecobrancacodigo1_Visible = 1;
         edtCarteiraDeCobrancaUpdatedAt_Enabled = 0;
         edtCarteiraDeCobrancaCreatedAt_Enabled = 0;
         cmbCarteiraDeCobrancaStatus.Enabled = 0;
         edtCarteiraDeCobrancaConvenio_Enabled = 0;
         edtCarteiraDeCobrancaWorkspaceId_Enabled = 0;
         edtCarteiraDeCobrancaNome_Enabled = 0;
         edtCarteiraDeCobrancaCodigo_Enabled = 0;
         edtCarteiraDeCobrancaId_Enabled = 0;
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
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "CarteiraDeCobrancaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|";
         Ddo_grid_Includefilter = "T|T|";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4";
         Ddo_grid_Columnids = "3:CarteiraDeCobrancaNome|5:CarteiraDeCobrancaConvenio|6:CarteiraDeCobrancaStatus";
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
         Form.Caption = " Carteira De Cobranca";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E28A72","iparms":[]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV50GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E21A72","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E22A72","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E23A72","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E24A72","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E25A72","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A72","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"},{"av":"AV44GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV45GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV46GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV32ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E29A72","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV50GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV50GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18A72","iparms":[{"av":"A1069CarteiraDeCobrancaId","fld":"CARTEIRADECOBRANCAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19A72","iparms":[{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E20A72","iparms":[{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV14OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV15FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV16DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV17DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV18CarteiraDeCobrancaCodigo1","fld":"vCARTEIRADECOBRANCACODIGO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV20DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV21DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV22CarteiraDeCobrancaCodigo2","fld":"vCARTEIRADECOBRANCACODIGO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV24DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV25DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV26CarteiraDeCobrancaCodigo3","fld":"vCARTEIRADECOBRANCACODIGO3","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV51Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV19DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV23DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV37TFCarteiraDeCobrancaNome","fld":"vTFCARTEIRADECOBRANCANOME","type":"svchar"},{"av":"AV38TFCarteiraDeCobrancaNome_Sel","fld":"vTFCARTEIRADECOBRANCANOME_SEL","type":"svchar"},{"av":"AV39TFCarteiraDeCobrancaConvenio","fld":"vTFCARTEIRADECOBRANCACONVENIO","type":"svchar"},{"av":"AV40TFCarteiraDeCobrancaConvenio_Sel","fld":"vTFCARTEIRADECOBRANCACONVENIO_SEL","type":"svchar"},{"av":"AV41TFCarteiraDeCobrancaStatus_Sel","fld":"vTFCARTEIRADECOBRANCASTATUS_SEL","pic":"9","type":"int"},{"av":"AV28DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV27DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavCarteiradecobrancacodigo1_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO1","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo2_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO2","prop":"Visible"},{"av":"edtavCarteiradecobrancacodigo3_Visible","ctrl":"vCARTEIRADECOBRANCACODIGO3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Carteiradecobrancaupdatedat","iparms":[]}""");
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
         AV18CarteiraDeCobrancaCodigo1 = "";
         AV20DynamicFiltersSelector2 = "";
         AV22CarteiraDeCobrancaCodigo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26CarteiraDeCobrancaCodigo3 = "";
         AV51Pgmname = "";
         AV37TFCarteiraDeCobrancaNome = "";
         AV38TFCarteiraDeCobrancaNome_Sel = "";
         AV39TFCarteiraDeCobrancaConvenio = "";
         AV40TFCarteiraDeCobrancaConvenio_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV46GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
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
         A1070CarteiraDeCobrancaCodigo = "";
         A1071CarteiraDeCobrancaNome = "";
         A1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         A1073CarteiraDeCobrancaConvenio = "";
         A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         lV52Carteiradecobrancawwds_1_filterfulltext = "";
         lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         AV52Carteiradecobrancawwds_1_filterfulltext = "";
         AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 = "";
         AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 = "";
         AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 = "";
         AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 = "";
         AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 = "";
         AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 = "";
         AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel = "";
         AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome = "";
         AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel = "";
         AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio = "";
         H00A72_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A72_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         H00A72_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H00A72_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         H00A72_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         H00A72_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         H00A72_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         H00A72_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         H00A72_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         H00A72_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         H00A72_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         H00A72_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         H00A72_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         H00A72_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         H00A72_A1069CarteiraDeCobrancaId = new int[1] ;
         H00A73_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV33ManageFiltersXml = "";
         AV29ExcelFilename = "";
         AV30ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV31Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobrancaww__default(),
            new Object[][] {
                new Object[] {
               H00A72_A1076CarteiraDeCobrancaUpdatedAt, H00A72_n1076CarteiraDeCobrancaUpdatedAt, H00A72_A1075CarteiraDeCobrancaCreatedAt, H00A72_n1075CarteiraDeCobrancaCreatedAt, H00A72_A1074CarteiraDeCobrancaStatus, H00A72_n1074CarteiraDeCobrancaStatus, H00A72_A1073CarteiraDeCobrancaConvenio, H00A72_n1073CarteiraDeCobrancaConvenio, H00A72_A1072CarteiraDeCobrancaWorkspaceId, H00A72_n1072CarteiraDeCobrancaWorkspaceId,
               H00A72_A1071CarteiraDeCobrancaNome, H00A72_n1071CarteiraDeCobrancaNome, H00A72_A1070CarteiraDeCobrancaCodigo, H00A72_n1070CarteiraDeCobrancaCodigo, H00A72_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               H00A73_AGRID_nRecordCount
               }
            }
         );
         AV51Pgmname = "CarteiraDeCobrancaWW";
         /* GeneXus formulas. */
         AV51Pgmname = "CarteiraDeCobrancaWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
      private short AV17DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV34ManageFiltersExecutionStep ;
      private short AV41TFCarteiraDeCobrancaStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV50GridActionGroup1 ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 ;
      private short AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 ;
      private short AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 ;
      private short AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_109 ;
      private int nGXsfl_109_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A1069CarteiraDeCobrancaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtCarteiraDeCobrancaId_Enabled ;
      private int edtCarteiraDeCobrancaCodigo_Enabled ;
      private int edtCarteiraDeCobrancaNome_Enabled ;
      private int edtCarteiraDeCobrancaWorkspaceId_Enabled ;
      private int edtCarteiraDeCobrancaConvenio_Enabled ;
      private int edtCarteiraDeCobrancaCreatedAt_Enabled ;
      private int edtCarteiraDeCobrancaUpdatedAt_Enabled ;
      private int AV43PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavCarteiradecobrancacodigo1_Visible ;
      private int edtavCarteiradecobrancacodigo2_Visible ;
      private int edtavCarteiradecobrancacodigo3_Visible ;
      private int AV69GXV1 ;
      private int edtavCarteiradecobrancacodigo3_Enabled ;
      private int edtavCarteiradecobrancacodigo2_Enabled ;
      private int edtavCarteiradecobrancacodigo1_Enabled ;
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
      private string sGXsfl_109_idx="0001" ;
      private string AV51Pgmname ;
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
      private string cmbavGridactiongroup1_Internalname ;
      private string edtCarteiraDeCobrancaId_Internalname ;
      private string edtCarteiraDeCobrancaCodigo_Internalname ;
      private string edtCarteiraDeCobrancaNome_Internalname ;
      private string edtCarteiraDeCobrancaWorkspaceId_Internalname ;
      private string edtCarteiraDeCobrancaConvenio_Internalname ;
      private string cmbCarteiraDeCobrancaStatus_Internalname ;
      private string edtCarteiraDeCobrancaCreatedAt_Internalname ;
      private string edtCarteiraDeCobrancaUpdatedAt_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavCarteiradecobrancacodigo1_Internalname ;
      private string edtavCarteiradecobrancacodigo2_Internalname ;
      private string edtavCarteiradecobrancacodigo3_Internalname ;
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
      private string GXEncryptionTmp ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_carteiradecobrancacodigo3_cell_Internalname ;
      private string edtavCarteiradecobrancacodigo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_carteiradecobrancacodigo2_cell_Internalname ;
      private string edtavCarteiradecobrancacodigo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_carteiradecobrancacodigo1_cell_Internalname ;
      private string edtavCarteiradecobrancacodigo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtCarteiraDeCobrancaId_Jsonclick ;
      private string edtCarteiraDeCobrancaCodigo_Jsonclick ;
      private string edtCarteiraDeCobrancaNome_Jsonclick ;
      private string edtCarteiraDeCobrancaWorkspaceId_Jsonclick ;
      private string edtCarteiraDeCobrancaConvenio_Jsonclick ;
      private string cmbCarteiraDeCobrancaStatus_Jsonclick ;
      private string edtCarteiraDeCobrancaCreatedAt_Jsonclick ;
      private string edtCarteiraDeCobrancaUpdatedAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A1075CarteiraDeCobrancaCreatedAt ;
      private DateTime A1076CarteiraDeCobrancaUpdatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV28DynamicFiltersIgnoreFirst ;
      private bool AV27DynamicFiltersRemoving ;
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
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1072CarteiraDeCobrancaWorkspaceId ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1075CarteiraDeCobrancaCreatedAt ;
      private bool n1076CarteiraDeCobrancaUpdatedAt ;
      private bool bGXsfl_109_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 ;
      private bool AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV33ManageFiltersXml ;
      private string AV15FilterFullText ;
      private string AV16DynamicFiltersSelector1 ;
      private string AV18CarteiraDeCobrancaCodigo1 ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22CarteiraDeCobrancaCodigo2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26CarteiraDeCobrancaCodigo3 ;
      private string AV37TFCarteiraDeCobrancaNome ;
      private string AV38TFCarteiraDeCobrancaNome_Sel ;
      private string AV39TFCarteiraDeCobrancaConvenio ;
      private string AV40TFCarteiraDeCobrancaConvenio_Sel ;
      private string AV46GridAppliedFilters ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private string A1071CarteiraDeCobrancaNome ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private string lV52Carteiradecobrancawwds_1_filterfulltext ;
      private string lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string AV52Carteiradecobrancawwds_1_filterfulltext ;
      private string AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 ;
      private string AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ;
      private string AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 ;
      private string AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ;
      private string AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 ;
      private string AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ;
      private string AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ;
      private string AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ;
      private string AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ;
      private string AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ;
      private string AV29ExcelFilename ;
      private string AV30ErrorMessage ;
      private Guid A1072CarteiraDeCobrancaWorkspaceId ;
      private IGxSession AV31Session ;
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
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbCarteiraDeCobrancaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV32ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00A72_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] H00A72_n1076CarteiraDeCobrancaUpdatedAt ;
      private DateTime[] H00A72_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] H00A72_n1075CarteiraDeCobrancaCreatedAt ;
      private bool[] H00A72_A1074CarteiraDeCobrancaStatus ;
      private bool[] H00A72_n1074CarteiraDeCobrancaStatus ;
      private string[] H00A72_A1073CarteiraDeCobrancaConvenio ;
      private bool[] H00A72_n1073CarteiraDeCobrancaConvenio ;
      private Guid[] H00A72_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] H00A72_n1072CarteiraDeCobrancaWorkspaceId ;
      private string[] H00A72_A1071CarteiraDeCobrancaNome ;
      private bool[] H00A72_n1071CarteiraDeCobrancaNome ;
      private string[] H00A72_A1070CarteiraDeCobrancaCodigo ;
      private bool[] H00A72_n1070CarteiraDeCobrancaCodigo ;
      private int[] H00A72_A1069CarteiraDeCobrancaId ;
      private long[] H00A73_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class carteiradecobrancaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A72( IGxContext context ,
                                             string AV52Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaStatus, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaNome, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaId";
         sFromString = " FROM CarteiraDeCobranca";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV52Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV52Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV52Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaCodigo, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaNome, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaNome DESC, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaConvenio, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaConvenio DESC, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaStatus, CarteiraDeCobrancaId";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaStatus DESC, CarteiraDeCobrancaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY CarteiraDeCobrancaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H00A73( IGxContext context ,
                                             string AV52Carteiradecobrancawwds_1_filterfulltext ,
                                             string AV53Carteiradecobrancawwds_2_dynamicfiltersselector1 ,
                                             short AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 ,
                                             string AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1 ,
                                             bool AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 ,
                                             string AV57Carteiradecobrancawwds_6_dynamicfiltersselector2 ,
                                             short AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 ,
                                             string AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2 ,
                                             bool AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 ,
                                             string AV61Carteiradecobrancawwds_10_dynamicfiltersselector3 ,
                                             short AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 ,
                                             string AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3 ,
                                             string AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel ,
                                             string AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome ,
                                             string AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel ,
                                             string AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio ,
                                             short AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel ,
                                             string A1071CarteiraDeCobrancaNome ,
                                             string A1073CarteiraDeCobrancaConvenio ,
                                             bool A1074CarteiraDeCobrancaStatus ,
                                             string A1070CarteiraDeCobrancaCodigo ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[14];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM CarteiraDeCobranca";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Carteiradecobrancawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CarteiraDeCobrancaNome like '%' || :lV52Carteiradecobrancawwds_1_filterfulltext) or ( CarteiraDeCobrancaConvenio like '%' || :lV52Carteiradecobrancawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV52Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV52Carteiradecobrancawwds_1_filterfulltext) and CarteiraDeCobrancaStatus = FALSE))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Carteiradecobrancawwds_2_dynamicfiltersselector1, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV54Carteiradecobrancawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV56Carteiradecobrancawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Carteiradecobrancawwds_6_dynamicfiltersselector2, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV58Carteiradecobrancawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like :lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV60Carteiradecobrancawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Carteiradecobrancawwds_10_dynamicfiltersselector3, "CARTEIRADECOBRANCACODIGO") == 0 ) && ( AV62Carteiradecobrancawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome like :lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel)) && ! ( StringUtil.StrCmp(AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome = ( :AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaNome IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)) ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio like :lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel)) && ! ( StringUtil.StrCmp(AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio = ( :AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaConvenio IS NULL or (char_length(trim(trailing ' ' from CarteiraDeCobrancaConvenio))=0))");
         }
         if ( AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = TRUE)");
         }
         if ( AV68Carteiradecobrancawwds_17_tfcarteiradecobrancastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaStatus = FALSE)");
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
                     return conditional_H00A72(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
               case 1 :
                     return conditional_H00A73(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmH00A72;
          prmH00A72 = new Object[] {
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00A73;
          prmH00A73 = new Object[] {
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Carteiradecobrancawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV55Carteiradecobrancawwds_4_carteiradecobrancacodigo1",GXType.VarChar,50,0) ,
          new ParDef("lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV59Carteiradecobrancawwds_8_carteiradecobrancacodigo2",GXType.VarChar,50,0) ,
          new ParDef("lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV63Carteiradecobrancawwds_12_carteiradecobrancacodigo3",GXType.VarChar,50,0) ,
          new ParDef("lV64Carteiradecobrancawwds_13_tfcarteiradecobrancanome",GXType.VarChar,100,0) ,
          new ParDef("AV65Carteiradecobrancawwds_14_tfcarteiradecobrancanome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Carteiradecobrancawwds_15_tfcarteiradecobrancaconvenio",GXType.VarChar,20,0) ,
          new ParDef("AV67Carteiradecobrancawwds_16_tfcarteiradecobrancaconvenio_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A72,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A73,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
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
