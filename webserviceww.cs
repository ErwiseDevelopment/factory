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
   public class webserviceww : GXDataArea
   {
      public webserviceww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webserviceww( IGxContext context )
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
         cmbavWebservicetipodmws1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavWebservicetipodmws2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavWebservicetipodmws3 = new GXCombobox();
         cmbWebServiceTipoDmWS = new GXCombobox();
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
         nRC_GXsfl_96 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_96"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_96_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_96_idx = GetPar( "sGXsfl_96_idx");
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
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV15DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavWebservicetipodmws1.FromJSonString( GetNextPar( ));
         AV16WebServiceTipoDmWS1 = GetPar( "WebServiceTipoDmWS1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavWebservicetipodmws2.FromJSonString( GetNextPar( ));
         AV19WebServiceTipoDmWS2 = GetPar( "WebServiceTipoDmWS2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavWebservicetipodmws3.FromJSonString( GetNextPar( ));
         AV22WebServiceTipoDmWS3 = GetPar( "WebServiceTipoDmWS3");
         AV28ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV44Pgmname = GetPar( "Pgmname");
         AV14FilterFullText = GetPar( "FilterFullText");
         AV17DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV20DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFWebServiceTipoDmWS_Sels);
         AV40TFWebServiceEndPointDecrypted = GetPar( "TFWebServiceEndPointDecrypted");
         AV41TFWebServiceEndPointDecrypted_Sel = GetPar( "TFWebServiceEndPointDecrypted_Sel");
         AV42TFWebServiceAuthTipoDecrypted = GetPar( "TFWebServiceAuthTipoDecrypted");
         AV43TFWebServiceAuthTipoDecrypted_Sel = GetPar( "TFWebServiceAuthTipoDecrypted_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridState);
         AV24DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV23DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV59Webserviceid = (int)(Math.Round(NumberUtil.Val( GetPar( "Webserviceid"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
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
         PAA62( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTA62( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webserviceww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWEBSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59Webserviceid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWEBSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59Webserviceid), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV15DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vWEBSERVICETIPODMWS1", AV16WebServiceTipoDmWS1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV18DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vWEBSERVICETIPODMWS2", AV19WebServiceTipoDmWS2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV21DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vWEBSERVICETIPODMWS3", AV22WebServiceTipoDmWS3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_96", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_96), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV26ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV26ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV35GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV31DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV31DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV17DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV20DynamicFiltersEnabled3);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFWEBSERVICETIPODMWS_SELS", AV30TFWebServiceTipoDmWS_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFWEBSERVICETIPODMWS_SELS", AV30TFWebServiceTipoDmWS_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFWEBSERVICEENDPOINTDECRYPTED", AV40TFWebServiceEndPointDecrypted);
         GxWebStd.gx_hidden_field( context, "vTFWEBSERVICEENDPOINTDECRYPTED_SEL", AV41TFWebServiceEndPointDecrypted_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWEBSERVICEAUTHTIPODECRYPTED", AV42TFWebServiceAuthTipoDecrypted);
         GxWebStd.gx_hidden_field( context, "vTFWEBSERVICEAUTHTIPODECRYPTED_SEL", AV43TFWebServiceAuthTipoDecrypted_Sel);
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV24DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV23DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFWEBSERVICETIPODMWS_SELSJSON", AV29TFWebServiceTipoDmWS_SelsJson);
         GxWebStd.gx_hidden_field( context, "vWEBSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59Webserviceid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWEBSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59Webserviceid), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WEBSERVICEENDPOINT", A658WebServiceEndPoint);
         GxWebStd.gx_hidden_field( context, "WEBSERVICEAUTHTIPO", A659WebServiceAuthTipo);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WEA62( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTA62( ) ;
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
         return formatLink("webserviceww")  ;
      }

      public override string GetPgmname( )
      {
         return "WebServiceWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Web Service" ;
      }

      protected void WBA60( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(96), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WebServiceWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV26ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_96_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WebServiceWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV15DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_A62( true) ;
         }
         else
         {
            wb_table1_43_A62( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_A62e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_62_A62( true) ;
         }
         else
         {
            wb_table2_62_A62( false) ;
         }
         return  ;
      }

      protected void wb_table2_62_A62e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WebServiceWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_81_A62( true) ;
         }
         else
         {
            wb_table3_81_A62( false) ;
         }
         return  ;
      }

      protected void wb_table3_81_A62e( bool wbgen )
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
            StartGridControl96( ) ;
         }
         if ( wbEnd == 96 )
         {
            wbEnd = 0;
            nRC_GXsfl_96 = (int)(nGXsfl_96_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV33GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV34GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV35GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WebServiceWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV31DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
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
         if ( wbEnd == 96 )
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

      protected void STARTA62( )
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
         Form.Meta.addItem("description", " Web Service", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPA60( ) ;
      }

      protected void WSA62( )
      {
         STARTA62( ) ;
         EVTA62( ) ;
      }

      protected void EVTA62( )
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
                              E11A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E19A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E21A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22A62 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23A62 ();
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
                              nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
                              SubsflControlProps_962( ) ;
                              AV36Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV36Display);
                              AV37Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV37Update);
                              AV38Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV38Delete);
                              A656WebServiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtWebServiceId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              cmbWebServiceTipoDmWS.Name = cmbWebServiceTipoDmWS_Internalname;
                              cmbWebServiceTipoDmWS.CurrentValue = cgiGet( cmbWebServiceTipoDmWS_Internalname);
                              A657WebServiceTipoDmWS = cgiGet( cmbWebServiceTipoDmWS_Internalname);
                              n657WebServiceTipoDmWS = false;
                              A1061WebServiceEndPointDecrypted = cgiGet( edtWebServiceEndPointDecrypted_Internalname);
                              A1062WebServiceAuthTipoDecrypted = cgiGet( edtWebServiceAuthTipoDecrypted_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E24A62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E25A62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E26A62 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Webservicetipodmws1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS1"), AV16WebServiceTipoDmWS1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV18DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Webservicetipodmws2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS2"), AV19WebServiceTipoDmWS2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV21DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Webservicetipodmws3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS3"), AV22WebServiceTipoDmWS3) != 0 )
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

      protected void WEA62( )
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

      protected void PAA62( )
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
         SubsflControlProps_962( ) ;
         while ( nGXsfl_96_idx <= nRC_GXsfl_96 )
         {
            sendrow_962( ) ;
            nGXsfl_96_idx = ((subGrid_Islastpage==1)&&(nGXsfl_96_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       bool AV13OrderedDsc ,
                                       string AV15DynamicFiltersSelector1 ,
                                       string AV16WebServiceTipoDmWS1 ,
                                       string AV18DynamicFiltersSelector2 ,
                                       string AV19WebServiceTipoDmWS2 ,
                                       string AV21DynamicFiltersSelector3 ,
                                       string AV22WebServiceTipoDmWS3 ,
                                       short AV28ManageFiltersExecutionStep ,
                                       string AV44Pgmname ,
                                       string AV14FilterFullText ,
                                       bool AV17DynamicFiltersEnabled2 ,
                                       bool AV20DynamicFiltersEnabled3 ,
                                       GxSimpleCollection<string> AV30TFWebServiceTipoDmWS_Sels ,
                                       string AV40TFWebServiceEndPointDecrypted ,
                                       string AV41TFWebServiceEndPointDecrypted_Sel ,
                                       string AV42TFWebServiceAuthTipoDecrypted ,
                                       string AV43TFWebServiceAuthTipoDecrypted_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ,
                                       bool AV24DynamicFiltersIgnoreFirst ,
                                       bool AV23DynamicFiltersRemoving ,
                                       int AV59Webserviceid )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFA62( ) ;
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
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavWebservicetipodmws1.ItemCount > 0 )
         {
            AV16WebServiceTipoDmWS1 = cmbavWebservicetipodmws1.getValidValue(AV16WebServiceTipoDmWS1);
            AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
            AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", cmbavWebservicetipodmws1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV18DynamicFiltersSelector2);
            AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavWebservicetipodmws2.ItemCount > 0 )
         {
            AV19WebServiceTipoDmWS2 = cmbavWebservicetipodmws2.getValidValue(AV19WebServiceTipoDmWS2);
            AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
            AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", cmbavWebservicetipodmws2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV21DynamicFiltersSelector3);
            AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavWebservicetipodmws3.ItemCount > 0 )
         {
            AV22WebServiceTipoDmWS3 = cmbavWebservicetipodmws3.getValidValue(AV22WebServiceTipoDmWS3);
            AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
            AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", cmbavWebservicetipodmws3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFA62( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "WebServiceWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A657WebServiceTipoDmWS ,
                                              AV54Webservicewwds_10_tfwebservicetipodmws_sels ,
                                              AV46Webservicewwds_2_dynamicfiltersselector1 ,
                                              AV47Webservicewwds_3_webservicetipodmws1 ,
                                              AV48Webservicewwds_4_dynamicfiltersenabled2 ,
                                              AV49Webservicewwds_5_dynamicfiltersselector2 ,
                                              AV50Webservicewwds_6_webservicetipodmws2 ,
                                              AV51Webservicewwds_7_dynamicfiltersenabled3 ,
                                              AV52Webservicewwds_8_dynamicfiltersselector3 ,
                                              AV53Webservicewwds_9_webservicetipodmws3 ,
                                              AV54Webservicewwds_10_tfwebservicetipodmws_sels.Count ,
                                              AV13OrderedDsc ,
                                              AV45Webservicewwds_1_filterfulltext ,
                                              A1061WebServiceEndPointDecrypted ,
                                              A1062WebServiceAuthTipoDecrypted ,
                                              AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                              AV55Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                              AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                              AV57Webservicewwds_13_tfwebserviceauthtipodecrypted } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H00A62 */
         pr_default.execute(0, new Object[] {AV47Webservicewwds_3_webservicetipodmws1, AV50Webservicewwds_6_webservicetipodmws2, AV53Webservicewwds_9_webservicetipodmws3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A657WebServiceTipoDmWS = H00A62_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = H00A62_n657WebServiceTipoDmWS[0];
            A656WebServiceId = H00A62_A656WebServiceId[0];
            A658WebServiceEndPoint = H00A62_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = H00A62_n658WebServiceEndPoint[0];
            A659WebServiceAuthTipo = H00A62_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = H00A62_n659WebServiceAuthTipo[0];
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Webservicewwds_13_tfwebserviceauthtipodecrypted)) ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( AV57Webservicewwds_13_tfwebserviceauthtipodecrypted , 2097152 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ! ( StringUtil.StrCmp(AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1062WebServiceAuthTipoDecrypted, AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1062WebServiceAuthTipoDecrypted)) ) )
                  {
                     GXt_char1 = A1061WebServiceEndPointDecrypted;
                     new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
                     A1061WebServiceEndPointDecrypted = GXt_char1;
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Webservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( "serasa_auth" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) ) || ( StringUtil.Like( "serasa_proposta_pf" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) ) || ( StringUtil.Like( "santander" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( "%" + AV45Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( "%" + AV45Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
                     {
                        if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Webservicewwds_11_tfwebserviceendpointdecrypted)) ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( AV55Webservicewwds_11_tfwebserviceendpointdecrypted , 2097152 , "%"),  ' ' ) ) )
                        {
                           if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ! ( StringUtil.StrCmp(AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1061WebServiceEndPointDecrypted, AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel) == 0 ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1061WebServiceEndPointDecrypted)) ) )
                              {
                                 GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RFA62( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 96;
         /* Execute user event: Refresh */
         E25A62 ();
         nGXsfl_96_idx = 1;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_962( ) ;
         bGXsfl_96_Refreshing = true;
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
            SubsflControlProps_962( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A657WebServiceTipoDmWS ,
                                                 AV54Webservicewwds_10_tfwebservicetipodmws_sels ,
                                                 AV46Webservicewwds_2_dynamicfiltersselector1 ,
                                                 AV47Webservicewwds_3_webservicetipodmws1 ,
                                                 AV48Webservicewwds_4_dynamicfiltersenabled2 ,
                                                 AV49Webservicewwds_5_dynamicfiltersselector2 ,
                                                 AV50Webservicewwds_6_webservicetipodmws2 ,
                                                 AV51Webservicewwds_7_dynamicfiltersenabled3 ,
                                                 AV52Webservicewwds_8_dynamicfiltersselector3 ,
                                                 AV53Webservicewwds_9_webservicetipodmws3 ,
                                                 AV54Webservicewwds_10_tfwebservicetipodmws_sels.Count ,
                                                 AV13OrderedDsc ,
                                                 AV45Webservicewwds_1_filterfulltext ,
                                                 A1061WebServiceEndPointDecrypted ,
                                                 A1062WebServiceAuthTipoDecrypted ,
                                                 AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                                 AV55Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                                 AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                                 AV57Webservicewwds_13_tfwebserviceauthtipodecrypted } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H00A63 */
            pr_default.execute(1, new Object[] {AV47Webservicewwds_3_webservicetipodmws1, AV50Webservicewwds_6_webservicetipodmws2, AV53Webservicewwds_9_webservicetipodmws3});
            nGXsfl_96_idx = 1;
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A657WebServiceTipoDmWS = H00A63_A657WebServiceTipoDmWS[0];
               n657WebServiceTipoDmWS = H00A63_n657WebServiceTipoDmWS[0];
               A656WebServiceId = H00A63_A656WebServiceId[0];
               A658WebServiceEndPoint = H00A63_A658WebServiceEndPoint[0];
               n658WebServiceEndPoint = H00A63_n658WebServiceEndPoint[0];
               A659WebServiceAuthTipo = H00A63_A659WebServiceAuthTipo[0];
               n659WebServiceAuthTipo = H00A63_n659WebServiceAuthTipo[0];
               GXt_char1 = A1062WebServiceAuthTipoDecrypted;
               new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
               A1062WebServiceAuthTipoDecrypted = GXt_char1;
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Webservicewwds_13_tfwebserviceauthtipodecrypted)) ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( AV57Webservicewwds_13_tfwebserviceauthtipodecrypted , 2097152 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel)) && ! ( StringUtil.StrCmp(AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1062WebServiceAuthTipoDecrypted, AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1062WebServiceAuthTipoDecrypted)) ) )
                     {
                        GXt_char1 = A1061WebServiceEndPointDecrypted;
                        new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
                        A1061WebServiceEndPointDecrypted = GXt_char1;
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Webservicewwds_1_filterfulltext)) || ( ( StringUtil.Like( "serasa_auth" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_AUTH") == 0 ) ) || ( StringUtil.Like( "serasa_proposta_pf" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Serasa_PROPOSTA_PF") == 0 ) ) || ( StringUtil.Like( "santander" , StringUtil.PadR( "%" + StringUtil.Lower( AV45Webservicewwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A657WebServiceTipoDmWS, "Santander") == 0 ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( "%" + AV45Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) || ( StringUtil.Like( A1062WebServiceAuthTipoDecrypted , StringUtil.PadR( "%" + AV45Webservicewwds_1_filterfulltext , 2097152 , "%"),  ' ' ) ) ) )
                        {
                           if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Webservicewwds_11_tfwebserviceendpointdecrypted)) ) ) || ( StringUtil.Like( A1061WebServiceEndPointDecrypted , StringUtil.PadR( AV55Webservicewwds_11_tfwebserviceendpointdecrypted , 2097152 , "%"),  ' ' ) ) )
                           {
                              if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel)) && ! ( StringUtil.StrCmp(AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A1061WebServiceEndPointDecrypted, AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel) == 0 ) ) )
                              {
                                 if ( ( StringUtil.StrCmp(AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A1061WebServiceEndPointDecrypted)) ) )
                                 {
                                    /* Execute user event: Grid.Load */
                                    E26A62 ();
                                 }
                              }
                           }
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 96;
            WBA60( ) ;
         }
         bGXsfl_96_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesA62( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV44Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV44Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vWEBSERVICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59Webserviceid), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vWEBSERVICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV59Webserviceid), "ZZZZZZZZ9"), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "WebServiceWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtWebServiceId_Enabled = 0;
         cmbWebServiceTipoDmWS.Enabled = 0;
         edtWebServiceEndPointDecrypted_Enabled = 0;
         edtWebServiceAuthTipoDecrypted_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPA60( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E24A62 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV26ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV31DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_96 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_96"), ",", "."), 18, MidpointRounding.ToEven));
            AV33GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV34GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV35GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV15DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            cmbavWebservicetipodmws1.Name = cmbavWebservicetipodmws1_Internalname;
            cmbavWebservicetipodmws1.CurrentValue = cgiGet( cmbavWebservicetipodmws1_Internalname);
            AV16WebServiceTipoDmWS1 = cgiGet( cmbavWebservicetipodmws1_Internalname);
            AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV18DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
            cmbavWebservicetipodmws2.Name = cmbavWebservicetipodmws2_Internalname;
            cmbavWebservicetipodmws2.CurrentValue = cgiGet( cmbavWebservicetipodmws2_Internalname);
            AV19WebServiceTipoDmWS2 = cgiGet( cmbavWebservicetipodmws2_Internalname);
            AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV21DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
            cmbavWebservicetipodmws3.Name = cmbavWebservicetipodmws3_Internalname;
            cmbavWebservicetipodmws3.CurrentValue = cgiGet( cmbavWebservicetipodmws3_Internalname);
            AV22WebServiceTipoDmWS3 = cgiGet( cmbavWebservicetipodmws3_Internalname);
            AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV15DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS1"), AV16WebServiceTipoDmWS1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV18DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS2"), AV19WebServiceTipoDmWS2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV21DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vWEBSERVICETIPODMWS3"), AV22WebServiceTipoDmWS3) != 0 )
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
         E24A62 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E24A62( )
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
         AV16WebServiceTipoDmWS1 = "";
         AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
         AV15DynamicFiltersSelector1 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV19WebServiceTipoDmWS2 = "";
         AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
         AV18DynamicFiltersSelector2 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22WebServiceTipoDmWS3 = "";
         AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
         AV21DynamicFiltersSelector3 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
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
         Form.Caption = " Web Service";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV31DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV31DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E25A62( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV28ManageFiltersExecutionStep == 1 )
         {
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV28ManageFiltersExecutionStep == 2 )
         {
            AV28ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV33GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV33GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV33GridCurrentPage), 10, 0));
         AV34GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV34GridPageCount", StringUtil.LTrimStr( (decimal)(AV34GridPageCount), 10, 0));
         GXt_char1 = AV35GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV44Pgmname, out  GXt_char1) ;
         AV35GridAppliedFilters = GXt_char1;
         AssignAttri("", false, "AV35GridAppliedFilters", AV35GridAppliedFilters);
         AV45Webservicewwds_1_filterfulltext = AV14FilterFullText;
         AV46Webservicewwds_2_dynamicfiltersselector1 = AV15DynamicFiltersSelector1;
         AV47Webservicewwds_3_webservicetipodmws1 = AV16WebServiceTipoDmWS1;
         AV48Webservicewwds_4_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV49Webservicewwds_5_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV50Webservicewwds_6_webservicetipodmws2 = AV19WebServiceTipoDmWS2;
         AV51Webservicewwds_7_dynamicfiltersenabled3 = AV20DynamicFiltersEnabled3;
         AV52Webservicewwds_8_dynamicfiltersselector3 = AV21DynamicFiltersSelector3;
         AV53Webservicewwds_9_webservicetipodmws3 = AV22WebServiceTipoDmWS3;
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = AV30TFWebServiceTipoDmWS_Sels;
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = AV40TFWebServiceEndPointDecrypted;
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = AV41TFWebServiceEndPointDecrypted_Sel;
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = AV42TFWebServiceAuthTipoDecrypted;
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = AV43TFWebServiceAuthTipoDecrypted_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E12A62( )
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
            AV32PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV32PageToGo) ;
         }
      }

      protected void E13A62( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14A62( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WebServiceTipoDmWS") == 0 )
            {
               AV29TFWebServiceTipoDmWS_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFWebServiceTipoDmWS_SelsJson", AV29TFWebServiceTipoDmWS_SelsJson);
               AV30TFWebServiceTipoDmWS_Sels.FromJSonString(AV29TFWebServiceTipoDmWS_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WebServiceEndPointDecrypted") == 0 )
            {
               AV40TFWebServiceEndPointDecrypted = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV40TFWebServiceEndPointDecrypted", AV40TFWebServiceEndPointDecrypted);
               AV41TFWebServiceEndPointDecrypted_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV41TFWebServiceEndPointDecrypted_Sel", AV41TFWebServiceEndPointDecrypted_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WebServiceAuthTipoDecrypted") == 0 )
            {
               AV42TFWebServiceAuthTipoDecrypted = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFWebServiceAuthTipoDecrypted", AV42TFWebServiceAuthTipoDecrypted);
               AV43TFWebServiceAuthTipoDecrypted_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFWebServiceAuthTipoDecrypted_Sel", AV43TFWebServiceAuthTipoDecrypted_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFWebServiceTipoDmWS_Sels", AV30TFWebServiceTipoDmWS_Sels);
      }

      private void E26A62( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV36Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV36Display);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "webservice"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A656WebServiceId,9,0));
            edtavDisplay_Link = formatLink("webservice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV37Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri("", false, edtavUpdate_Internalname, AV37Update);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "webservice"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A656WebServiceId,9,0));
            edtavUpdate_Link = formatLink("webservice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV38Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri("", false, edtavDelete_Internalname, AV38Delete);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "webservice"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A656WebServiceId,9,0));
            edtavDelete_Link = formatLink("webservice") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 96;
            }
            sendrow_962( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_96_Refreshing )
         {
            DoAjaxLoad(96, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E19A62( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV17DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV17DynamicFiltersEnabled2", AV17DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15A62( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV23DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         AV24DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV24DynamicFiltersIgnoreFirst", AV24DynamicFiltersIgnoreFirst);
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
         AV23DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         AV24DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV24DynamicFiltersIgnoreFirst", AV24DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
         AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", cmbavWebservicetipodmws2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
         AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", cmbavWebservicetipodmws3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
         AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", cmbavWebservicetipodmws1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E20A62( )
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

      protected void E21A62( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled3", AV20DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16A62( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV23DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         AV17DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV17DynamicFiltersEnabled2", AV17DynamicFiltersEnabled2);
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
         AV23DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
         AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", cmbavWebservicetipodmws2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
         AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", cmbavWebservicetipodmws3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
         AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", cmbavWebservicetipodmws1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E22A62( )
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

      protected void E17A62( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV23DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled3", AV20DynamicFiltersEnabled3);
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
         AV23DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV23DynamicFiltersRemoving", AV23DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV13OrderedDsc, AV15DynamicFiltersSelector1, AV16WebServiceTipoDmWS1, AV18DynamicFiltersSelector2, AV19WebServiceTipoDmWS2, AV21DynamicFiltersSelector3, AV22WebServiceTipoDmWS3, AV28ManageFiltersExecutionStep, AV44Pgmname, AV14FilterFullText, AV17DynamicFiltersEnabled2, AV20DynamicFiltersEnabled3, AV30TFWebServiceTipoDmWS_Sels, AV40TFWebServiceEndPointDecrypted, AV41TFWebServiceEndPointDecrypted_Sel, AV42TFWebServiceAuthTipoDecrypted, AV43TFWebServiceAuthTipoDecrypted_Sel, AV10GridState, AV24DynamicFiltersIgnoreFirst, AV23DynamicFiltersRemoving, AV59Webserviceid) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
         AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", cmbavWebservicetipodmws2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
         AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", cmbavWebservicetipodmws3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
         AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", cmbavWebservicetipodmws1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E23A62( )
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

      protected void E11A62( )
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
            S172 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WebServiceWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV44Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WebServiceWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV28ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV28ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV28ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char1 = AV27ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WebServiceWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char1) ;
            AV27ManageFiltersXml = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV27ManageFiltersXml) ;
               AV10GridState.FromXml(AV27ManageFiltersXml, null, "", "");
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S182 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFWebServiceTipoDmWS_Sels", AV30TFWebServiceTipoDmWS_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV15DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
         AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", cmbavWebservicetipodmws1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
         AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", cmbavWebservicetipodmws2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
         AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", cmbavWebservicetipodmws3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26ManageFiltersData", AV26ManageFiltersData);
      }

      protected void E18A62( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "webserviceconfig"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("webserviceconfig") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S182( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = "-1:"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         cmbavWebservicetipodmws1.Visible = 0;
         AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "WEBSERVICETIPODMWS") == 0 )
         {
            cmbavWebservicetipodmws1.Visible = 1;
            AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         cmbavWebservicetipodmws2.Visible = 0;
         AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "WEBSERVICETIPODMWS") == 0 )
         {
            cmbavWebservicetipodmws2.Visible = 1;
            AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         cmbavWebservicetipodmws3.Visible = 0;
         AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector3, "WEBSERVICETIPODMWS") == 0 )
         {
            cmbavWebservicetipodmws3.Visible = 1;
            AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavWebservicetipodmws3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV17DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV17DynamicFiltersEnabled2", AV17DynamicFiltersEnabled2);
         AV18DynamicFiltersSelector2 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
         AV19WebServiceTipoDmWS2 = "";
         AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled3", AV20DynamicFiltersEnabled3);
         AV21DynamicFiltersSelector3 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
         AV22WebServiceTipoDmWS3 = "";
         AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV26ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WebServiceWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV26ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV30TFWebServiceTipoDmWS_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40TFWebServiceEndPointDecrypted = "";
         AssignAttri("", false, "AV40TFWebServiceEndPointDecrypted", AV40TFWebServiceEndPointDecrypted);
         AV41TFWebServiceEndPointDecrypted_Sel = "";
         AssignAttri("", false, "AV41TFWebServiceEndPointDecrypted_Sel", AV41TFWebServiceEndPointDecrypted_Sel);
         AV42TFWebServiceAuthTipoDecrypted = "";
         AssignAttri("", false, "AV42TFWebServiceAuthTipoDecrypted", AV42TFWebServiceAuthTipoDecrypted);
         AV43TFWebServiceAuthTipoDecrypted_Sel = "";
         AssignAttri("", false, "AV43TFWebServiceAuthTipoDecrypted_Sel", AV43TFWebServiceAuthTipoDecrypted_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV15DynamicFiltersSelector1 = "WEBSERVICETIPODMWS";
         AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         AV16WebServiceTipoDmWS1 = "";
         AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
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
         if ( StringUtil.StrCmp(AV25Session.Get(AV44Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV44Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV25Session.Get(AV44Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S182 ();
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
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWEBSERVICETIPODMWS_SEL") == 0 )
            {
               AV29TFWebServiceTipoDmWS_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFWebServiceTipoDmWS_SelsJson", AV29TFWebServiceTipoDmWS_SelsJson);
               AV30TFWebServiceTipoDmWS_Sels.FromJSonString(AV29TFWebServiceTipoDmWS_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEENDPOINTDECRYPTED") == 0 )
            {
               AV40TFWebServiceEndPointDecrypted = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV40TFWebServiceEndPointDecrypted", AV40TFWebServiceEndPointDecrypted);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEENDPOINTDECRYPTED_SEL") == 0 )
            {
               AV41TFWebServiceEndPointDecrypted_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFWebServiceEndPointDecrypted_Sel", AV41TFWebServiceEndPointDecrypted_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEAUTHTIPODECRYPTED") == 0 )
            {
               AV42TFWebServiceAuthTipoDecrypted = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFWebServiceAuthTipoDecrypted", AV42TFWebServiceAuthTipoDecrypted);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFWEBSERVICEAUTHTIPODECRYPTED_SEL") == 0 )
            {
               AV43TFWebServiceAuthTipoDecrypted_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFWebServiceAuthTipoDecrypted_Sel", AV43TFWebServiceAuthTipoDecrypted_Sel);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFWebServiceTipoDmWS_Sels.Count==0),  AV29TFWebServiceTipoDmWS_SelsJson, out  GXt_char1) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFWebServiceEndPointDecrypted_Sel)),  AV41TFWebServiceEndPointDecrypted_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFWebServiceAuthTipoDecrypted_Sel)),  AV43TFWebServiceAuthTipoDecrypted_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char1+"|"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWebServiceEndPointDecrypted)),  AV40TFWebServiceEndPointDecrypted, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFWebServiceAuthTipoDecrypted)),  AV42TFWebServiceAuthTipoDecrypted, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char5+"|"+GXt_char4;
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
            AV15DynamicFiltersSelector1 = AV12GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "WEBSERVICETIPODMWS") == 0 )
            {
               AV16WebServiceTipoDmWS1 = AV12GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
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
               AV17DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV17DynamicFiltersEnabled2", AV17DynamicFiltersEnabled2);
               AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV12GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "WEBSERVICETIPODMWS") == 0 )
               {
                  AV19WebServiceTipoDmWS2 = AV12GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
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
                  AV20DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV20DynamicFiltersEnabled3", AV20DynamicFiltersEnabled3);
                  AV12GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV10GridState.gxTpr_Dynamicfilters.Item(3));
                  AV21DynamicFiltersSelector3 = AV12GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV21DynamicFiltersSelector3, "WEBSERVICETIPODMWS") == 0 )
                  {
                     AV22WebServiceTipoDmWS3 = AV12GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
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
         if ( AV23DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S172( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV25Session.Get(AV44Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         AV39AuxText = ((AV30TFWebServiceTipoDmWS_Sels.Count==1) ? "["+((string)AV30TFWebServiceTipoDmWS_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFWEBSERVICETIPODMWS_SEL",  "Tipo",  !(AV30TFWebServiceTipoDmWS_Sels.Count==0),  0,  AV30TFWebServiceTipoDmWS_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV39AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV39AuxText, "[Serasa_AUTH]", "Serasa_AUTH"), "[Serasa_PROPOSTA_PF]", "Serasa_PROPOSTA_PF"), "[Santander]", "Santander")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFWEBSERVICEENDPOINTDECRYPTED",  "Endpoint(URL)",  !String.IsNullOrEmpty(StringUtil.RTrim( AV40TFWebServiceEndPointDecrypted)),  0,  AV40TFWebServiceEndPointDecrypted,  AV40TFWebServiceEndPointDecrypted,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFWebServiceEndPointDecrypted_Sel)),  AV41TFWebServiceEndPointDecrypted_Sel,  AV41TFWebServiceEndPointDecrypted_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFWEBSERVICEAUTHTIPODECRYPTED",  "Tipo Autorização",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFWebServiceAuthTipoDecrypted)),  0,  AV42TFWebServiceAuthTipoDecrypted,  AV42TFWebServiceAuthTipoDecrypted,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFWebServiceAuthTipoDecrypted_Sel)),  AV43TFWebServiceAuthTipoDecrypted_Sel,  AV43TFWebServiceAuthTipoDecrypted_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV44Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV10GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV24DynamicFiltersIgnoreFirst )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV15DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV15DynamicFiltersSelector1, "WEBSERVICETIPODMWS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV16WebServiceTipoDmWS1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo WS",  0,  AV16WebServiceTipoDmWS1,  StringUtil.Trim( gxdomaindmws.getDescription(context,AV16WebServiceTipoDmWS1)),  false,  "",  "") ;
            }
            if ( AV23DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV17DynamicFiltersEnabled2 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "WEBSERVICETIPODMWS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV19WebServiceTipoDmWS2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo WS",  0,  AV19WebServiceTipoDmWS2,  StringUtil.Trim( gxdomaindmws.getDescription(context,AV19WebServiceTipoDmWS2)),  false,  "",  "") ;
            }
            if ( AV23DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV10GridState.gxTpr_Dynamicfilters.Add(AV12GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled3 )
         {
            AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV12GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector3, "WEBSERVICETIPODMWS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22WebServiceTipoDmWS3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV12GridStateDynamicFilter,  "Tipo WS",  0,  AV22WebServiceTipoDmWS3,  StringUtil.Trim( gxdomaindmws.getDescription(context,AV22WebServiceTipoDmWS3)),  false,  "",  "") ;
            }
            if ( AV23DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV12GridStateDynamicFilter.gxTpr_Value)) )
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
         AV8TrnContext.gxTpr_Callerobject = AV44Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WebService";
         AV25Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_81_A62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_3_Internalname, tblUnnamedtabledynamicfilters_3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_webservicetipodmws3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWebservicetipodmws3_Internalname, "Web Service Tipo Dm WS3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWebservicetipodmws3, cmbavWebservicetipodmws3_Internalname, StringUtil.RTrim( AV22WebServiceTipoDmWS3), 1, cmbavWebservicetipodmws3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavWebservicetipodmws3.Visible, cmbavWebservicetipodmws3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavWebservicetipodmws3.CurrentValue = StringUtil.RTrim( AV22WebServiceTipoDmWS3);
            AssignProp("", false, cmbavWebservicetipodmws3_Internalname, "Values", (string)(cmbavWebservicetipodmws3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebServiceWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_81_A62e( true) ;
         }
         else
         {
            wb_table3_81_A62e( false) ;
         }
      }

      protected void wb_table2_62_A62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_2_Internalname, tblUnnamedtabledynamicfilters_2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_webservicetipodmws2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWebservicetipodmws2_Internalname, "Web Service Tipo Dm WS2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWebservicetipodmws2, cmbavWebservicetipodmws2_Internalname, StringUtil.RTrim( AV19WebServiceTipoDmWS2), 1, cmbavWebservicetipodmws2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavWebservicetipodmws2.Visible, cmbavWebservicetipodmws2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavWebservicetipodmws2.CurrentValue = StringUtil.RTrim( AV19WebServiceTipoDmWS2);
            AssignProp("", false, cmbavWebservicetipodmws2_Internalname, "Values", (string)(cmbavWebservicetipodmws2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebServiceWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebServiceWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_62_A62e( true) ;
         }
         else
         {
            wb_table2_62_A62e( false) ;
         }
      }

      protected void wb_table1_43_A62( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtabledynamicfilters_1_Internalname, tblUnnamedtabledynamicfilters_1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_webservicetipodmws1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavWebservicetipodmws1_Internalname, "Web Service Tipo Dm WS1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_96_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavWebservicetipodmws1, cmbavWebservicetipodmws1_Internalname, StringUtil.RTrim( AV16WebServiceTipoDmWS1), 1, cmbavWebservicetipodmws1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavWebservicetipodmws1.Visible, cmbavWebservicetipodmws1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WebServiceWW.htm");
            cmbavWebservicetipodmws1.CurrentValue = StringUtil.RTrim( AV16WebServiceTipoDmWS1);
            AssignProp("", false, cmbavWebservicetipodmws1_Internalname, "Values", (string)(cmbavWebservicetipodmws1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebServiceWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebServiceWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_A62e( true) ;
         }
         else
         {
            wb_table1_43_A62e( false) ;
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
         PAA62( ) ;
         WSA62( ) ;
         WEA62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019291591", true, true);
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
         context.AddJavascriptSource("webserviceww.js", "?202561019291591", false, true);
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

      protected void SubsflControlProps_962( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_96_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_96_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_96_idx;
         edtWebServiceId_Internalname = "WEBSERVICEID_"+sGXsfl_96_idx;
         cmbWebServiceTipoDmWS_Internalname = "WEBSERVICETIPODMWS_"+sGXsfl_96_idx;
         edtWebServiceEndPointDecrypted_Internalname = "WEBSERVICEENDPOINTDECRYPTED_"+sGXsfl_96_idx;
         edtWebServiceAuthTipoDecrypted_Internalname = "WEBSERVICEAUTHTIPODECRYPTED_"+sGXsfl_96_idx;
      }

      protected void SubsflControlProps_fel_962( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_96_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_96_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_96_fel_idx;
         edtWebServiceId_Internalname = "WEBSERVICEID_"+sGXsfl_96_fel_idx;
         cmbWebServiceTipoDmWS_Internalname = "WEBSERVICETIPODMWS_"+sGXsfl_96_fel_idx;
         edtWebServiceEndPointDecrypted_Internalname = "WEBSERVICEENDPOINTDECRYPTED_"+sGXsfl_96_fel_idx;
         edtWebServiceAuthTipoDecrypted_Internalname = "WEBSERVICEAUTHTIPODECRYPTED_"+sGXsfl_96_fel_idx;
      }

      protected void sendrow_962( )
      {
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_962( ) ;
         WBA60( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_96_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_96_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_96_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_96_idx + "',96)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV36Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_96_idx + "',96)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV37Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_96_idx + "',96)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV38Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWebServiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A656WebServiceId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A656WebServiceId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWebServiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbWebServiceTipoDmWS.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "WEBSERVICETIPODMWS_" + sGXsfl_96_idx;
               cmbWebServiceTipoDmWS.Name = GXCCtl;
               cmbWebServiceTipoDmWS.WebTags = "";
               cmbWebServiceTipoDmWS.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
               cmbWebServiceTipoDmWS.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
               cmbWebServiceTipoDmWS.addItem("Santander", "Santander", 0);
               if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
               {
                  A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
                  n657WebServiceTipoDmWS = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbWebServiceTipoDmWS,(string)cmbWebServiceTipoDmWS_Internalname,StringUtil.RTrim( A657WebServiceTipoDmWS),(short)1,(string)cmbWebServiceTipoDmWS_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbWebServiceTipoDmWS.CurrentValue = StringUtil.RTrim( A657WebServiceTipoDmWS);
            AssignProp("", false, cmbWebServiceTipoDmWS_Internalname, "Values", (string)(cmbWebServiceTipoDmWS.ToJavascriptSource()), !bGXsfl_96_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWebServiceEndPointDecrypted_Internalname,(string)A1061WebServiceEndPointDecrypted,(string)A1061WebServiceEndPointDecrypted,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWebServiceEndPointDecrypted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)96,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWebServiceAuthTipoDecrypted_Internalname,(string)A1062WebServiceAuthTipoDecrypted,(string)A1062WebServiceAuthTipoDecrypted,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWebServiceAuthTipoDecrypted_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)96,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            send_integrity_lvl_hashesA62( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_96_idx = ((subGrid_Islastpage==1)&&(nGXsfl_96_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_962( ) ;
         }
         /* End function sendrow_962 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("WEBSERVICETIPODMWS", "Tipo WS", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV15DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV15DynamicFiltersSelector1);
            AssignAttri("", false, "AV15DynamicFiltersSelector1", AV15DynamicFiltersSelector1);
         }
         cmbavWebservicetipodmws1.Name = "vWEBSERVICETIPODMWS1";
         cmbavWebservicetipodmws1.WebTags = "";
         cmbavWebservicetipodmws1.addItem("", "Todos", 0);
         cmbavWebservicetipodmws1.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbavWebservicetipodmws1.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         cmbavWebservicetipodmws1.addItem("Santander", "Santander", 0);
         if ( cmbavWebservicetipodmws1.ItemCount > 0 )
         {
            AV16WebServiceTipoDmWS1 = cmbavWebservicetipodmws1.getValidValue(AV16WebServiceTipoDmWS1);
            AssignAttri("", false, "AV16WebServiceTipoDmWS1", AV16WebServiceTipoDmWS1);
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("WEBSERVICETIPODMWS", "Tipo WS", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV18DynamicFiltersSelector2);
            AssignAttri("", false, "AV18DynamicFiltersSelector2", AV18DynamicFiltersSelector2);
         }
         cmbavWebservicetipodmws2.Name = "vWEBSERVICETIPODMWS2";
         cmbavWebservicetipodmws2.WebTags = "";
         cmbavWebservicetipodmws2.addItem("", "Todos", 0);
         cmbavWebservicetipodmws2.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbavWebservicetipodmws2.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         cmbavWebservicetipodmws2.addItem("Santander", "Santander", 0);
         if ( cmbavWebservicetipodmws2.ItemCount > 0 )
         {
            AV19WebServiceTipoDmWS2 = cmbavWebservicetipodmws2.getValidValue(AV19WebServiceTipoDmWS2);
            AssignAttri("", false, "AV19WebServiceTipoDmWS2", AV19WebServiceTipoDmWS2);
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("WEBSERVICETIPODMWS", "Tipo WS", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV21DynamicFiltersSelector3);
            AssignAttri("", false, "AV21DynamicFiltersSelector3", AV21DynamicFiltersSelector3);
         }
         cmbavWebservicetipodmws3.Name = "vWEBSERVICETIPODMWS3";
         cmbavWebservicetipodmws3.WebTags = "";
         cmbavWebservicetipodmws3.addItem("", "Todos", 0);
         cmbavWebservicetipodmws3.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbavWebservicetipodmws3.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         cmbavWebservicetipodmws3.addItem("Santander", "Santander", 0);
         if ( cmbavWebservicetipodmws3.ItemCount > 0 )
         {
            AV22WebServiceTipoDmWS3 = cmbavWebservicetipodmws3.getValidValue(AV22WebServiceTipoDmWS3);
            AssignAttri("", false, "AV22WebServiceTipoDmWS3", AV22WebServiceTipoDmWS3);
         }
         GXCCtl = "WEBSERVICETIPODMWS_" + sGXsfl_96_idx;
         cmbWebServiceTipoDmWS.Name = GXCCtl;
         cmbWebServiceTipoDmWS.WebTags = "";
         cmbWebServiceTipoDmWS.addItem("Serasa_AUTH", "Serasa_AUTH", 0);
         cmbWebServiceTipoDmWS.addItem("Serasa_PROPOSTA_PF", "Serasa_PROPOSTA_PF", 0);
         cmbWebServiceTipoDmWS.addItem("Santander", "Santander", 0);
         if ( cmbWebServiceTipoDmWS.ItemCount > 0 )
         {
            A657WebServiceTipoDmWS = cmbWebServiceTipoDmWS.getValidValue(A657WebServiceTipoDmWS);
            n657WebServiceTipoDmWS = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl96( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"96\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Service Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Endpoint(URL)") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Autorização") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV36Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV37Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV38Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A656WebServiceId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A657WebServiceTipoDmWS));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1061WebServiceEndPointDecrypted));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1062WebServiceAuthTipoDecrypted));
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
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavWebservicetipodmws1_Internalname = "vWEBSERVICETIPODMWS1";
         cellFilter_webservicetipodmws1_cell_Internalname = "FILTER_WEBSERVICETIPODMWS1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblUnnamedtabledynamicfilters_1_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavWebservicetipodmws2_Internalname = "vWEBSERVICETIPODMWS2";
         cellFilter_webservicetipodmws2_cell_Internalname = "FILTER_WEBSERVICETIPODMWS2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblUnnamedtabledynamicfilters_2_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavWebservicetipodmws3_Internalname = "vWEBSERVICETIPODMWS3";
         cellFilter_webservicetipodmws3_cell_Internalname = "FILTER_WEBSERVICETIPODMWS3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblUnnamedtabledynamicfilters_3_Internalname = "UNNAMEDTABLEDYNAMICFILTERS_3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtWebServiceId_Internalname = "WEBSERVICEID";
         cmbWebServiceTipoDmWS_Internalname = "WEBSERVICETIPODMWS";
         edtWebServiceEndPointDecrypted_Internalname = "WEBSERVICEENDPOINTDECRYPTED";
         edtWebServiceAuthTipoDecrypted_Internalname = "WEBSERVICEAUTHTIPODECRYPTED";
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
         edtWebServiceAuthTipoDecrypted_Jsonclick = "";
         edtWebServiceEndPointDecrypted_Jsonclick = "";
         cmbWebServiceTipoDmWS_Jsonclick = "";
         edtWebServiceId_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
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
         cmbavWebservicetipodmws1_Jsonclick = "";
         cmbavWebservicetipodmws1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavWebservicetipodmws2_Jsonclick = "";
         cmbavWebservicetipodmws2.Enabled = 1;
         cmbavWebservicetipodmws3_Jsonclick = "";
         cmbavWebservicetipodmws3.Enabled = 1;
         cmbavWebservicetipodmws3.Visible = 1;
         cmbavWebservicetipodmws2.Visible = 1;
         cmbavWebservicetipodmws1.Visible = 1;
         edtWebServiceAuthTipoDecrypted_Enabled = 0;
         edtWebServiceEndPointDecrypted_Enabled = 0;
         cmbWebServiceTipoDmWS.Enabled = 0;
         edtWebServiceId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;L;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "WebServiceWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "Serasa_AUTH:Serasa_AUTH,Serasa_PROPOSTA_PF:Serasa_PROPOSTA_PF,Santander:Santander||";
         Ddo_grid_Allowmultipleselection = "T||";
         Ddo_grid_Datalisttype = "FixedValues|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "|Character|Character";
         Ddo_grid_Includefilter = "|T|T";
         Ddo_grid_Includesortasc = "T||";
         Ddo_grid_Columnssortvalues = "-1||";
         Ddo_grid_Columnids = "4:WebServiceTipoDmWS|5:WebServiceEndPointDecrypted|6:WebServiceAuthTipoDecrypted";
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
         Form.Caption = " Web Service";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV33GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV29TFWebServiceTipoDmWS_SelsJson","fld":"vTFWEBSERVICETIPODMWS_SELSJSON","type":"vchar"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E26A62","iparms":[{"av":"A656WebServiceId","fld":"WEBSERVICEID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV36Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV37Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV38Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E19A62","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV33GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E20A62","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"cmbavWebservicetipodmws1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E21A62","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV33GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E22A62","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"cmbavWebservicetipodmws2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV33GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E23A62","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"cmbavWebservicetipodmws3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11A62","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV44Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV24DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV23DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV29TFWebServiceTipoDmWS_SelsJson","fld":"vTFWEBSERVICETIPODMWS_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV28ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV30TFWebServiceTipoDmWS_Sels","fld":"vTFWEBSERVICETIPODMWS_SELS","type":""},{"av":"AV40TFWebServiceEndPointDecrypted","fld":"vTFWEBSERVICEENDPOINTDECRYPTED","type":"svchar"},{"av":"AV41TFWebServiceEndPointDecrypted_Sel","fld":"vTFWEBSERVICEENDPOINTDECRYPTED_SEL","type":"svchar"},{"av":"AV42TFWebServiceAuthTipoDecrypted","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED","type":"svchar"},{"av":"AV43TFWebServiceAuthTipoDecrypted_Sel","fld":"vTFWEBSERVICEAUTHTIPODECRYPTED_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV15DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavWebservicetipodmws1"},{"av":"AV16WebServiceTipoDmWS1","fld":"vWEBSERVICETIPODMWS1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV29TFWebServiceTipoDmWS_SelsJson","fld":"vTFWEBSERVICETIPODMWS_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV17DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV18DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavWebservicetipodmws2"},{"av":"AV19WebServiceTipoDmWS2","fld":"vWEBSERVICETIPODMWS2","type":"svchar"},{"av":"AV20DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV21DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavWebservicetipodmws3"},{"av":"AV22WebServiceTipoDmWS3","fld":"vWEBSERVICETIPODMWS3","type":"svchar"},{"av":"AV33GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV34GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV35GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV26ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18A62","iparms":[{"av":"AV59Webserviceid","fld":"vWEBSERVICEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("VALIDV_WEBSERVICETIPODMWS1","""{"handler":"Validv_Webservicetipodmws1","iparms":[]}""");
         setEventMetadata("VALIDV_WEBSERVICETIPODMWS2","""{"handler":"Validv_Webservicetipodmws2","iparms":[]}""");
         setEventMetadata("VALIDV_WEBSERVICETIPODMWS3","""{"handler":"Validv_Webservicetipodmws3","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICETIPODMWS","""{"handler":"Valid_Webservicetipodmws","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICEENDPOINTDECRYPTED","""{"handler":"Valid_Webserviceendpointdecrypted","iparms":[]}""");
         setEventMetadata("VALID_WEBSERVICEAUTHTIPODECRYPTED","""{"handler":"Valid_Webserviceauthtipodecrypted","iparms":[]}""");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV15DynamicFiltersSelector1 = "";
         AV16WebServiceTipoDmWS1 = "";
         AV18DynamicFiltersSelector2 = "";
         AV19WebServiceTipoDmWS2 = "";
         AV21DynamicFiltersSelector3 = "";
         AV22WebServiceTipoDmWS3 = "";
         AV44Pgmname = "";
         AV14FilterFullText = "";
         AV30TFWebServiceTipoDmWS_Sels = new GxSimpleCollection<string>();
         AV40TFWebServiceEndPointDecrypted = "";
         AV41TFWebServiceEndPointDecrypted_Sel = "";
         AV42TFWebServiceAuthTipoDecrypted = "";
         AV43TFWebServiceAuthTipoDecrypted_Sel = "";
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV26ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV35GridAppliedFilters = "";
         AV31DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV29TFWebServiceTipoDmWS_SelsJson = "";
         A658WebServiceEndPoint = "";
         A659WebServiceAuthTipo = "";
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
         AV36Display = "";
         AV37Update = "";
         AV38Delete = "";
         A657WebServiceTipoDmWS = "";
         A1061WebServiceEndPointDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         AV45Webservicewwds_1_filterfulltext = "";
         AV46Webservicewwds_2_dynamicfiltersselector1 = "";
         AV47Webservicewwds_3_webservicetipodmws1 = "";
         AV49Webservicewwds_5_dynamicfiltersselector2 = "";
         AV50Webservicewwds_6_webservicetipodmws2 = "";
         AV52Webservicewwds_8_dynamicfiltersselector3 = "";
         AV53Webservicewwds_9_webservicetipodmws3 = "";
         AV54Webservicewwds_10_tfwebservicetipodmws_sels = new GxSimpleCollection<string>();
         AV55Webservicewwds_11_tfwebserviceendpointdecrypted = "";
         AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel = "";
         AV57Webservicewwds_13_tfwebserviceauthtipodecrypted = "";
         AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel = "";
         H00A62_A657WebServiceTipoDmWS = new string[] {""} ;
         H00A62_n657WebServiceTipoDmWS = new bool[] {false} ;
         H00A62_A656WebServiceId = new int[1] ;
         H00A62_A658WebServiceEndPoint = new string[] {""} ;
         H00A62_n658WebServiceEndPoint = new bool[] {false} ;
         H00A62_A659WebServiceAuthTipo = new string[] {""} ;
         H00A62_n659WebServiceAuthTipo = new bool[] {false} ;
         H00A63_A657WebServiceTipoDmWS = new string[] {""} ;
         H00A63_n657WebServiceTipoDmWS = new bool[] {false} ;
         H00A63_A656WebServiceId = new int[1] ;
         H00A63_A658WebServiceEndPoint = new string[] {""} ;
         H00A63_n658WebServiceEndPoint = new bool[] {false} ;
         H00A63_A659WebServiceAuthTipo = new string[] {""} ;
         H00A63_n659WebServiceAuthTipo = new bool[] {false} ;
         AV7HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV27ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV25Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char1 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV12GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV39AuxText = "";
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webserviceww__default(),
            new Object[][] {
                new Object[] {
               H00A62_A657WebServiceTipoDmWS, H00A62_n657WebServiceTipoDmWS, H00A62_A656WebServiceId, H00A62_A658WebServiceEndPoint, H00A62_n658WebServiceEndPoint, H00A62_A659WebServiceAuthTipo, H00A62_n659WebServiceAuthTipo
               }
               , new Object[] {
               H00A63_A657WebServiceTipoDmWS, H00A63_n657WebServiceTipoDmWS, H00A63_A656WebServiceId, H00A63_A658WebServiceEndPoint, H00A63_n658WebServiceEndPoint, H00A63_A659WebServiceAuthTipo, H00A63_n659WebServiceAuthTipo
               }
            }
         );
         AV44Pgmname = "WebServiceWW";
         /* GeneXus formulas. */
         AV44Pgmname = "WebServiceWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV28ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_96 ;
      private int nGXsfl_96_idx=1 ;
      private int AV59Webserviceid ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A656WebServiceId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int AV54Webservicewwds_10_tfwebservicetipodmws_sels_Count ;
      private int edtWebServiceId_Enabled ;
      private int edtWebServiceEndPointDecrypted_Enabled ;
      private int edtWebServiceAuthTipoDecrypted_Enabled ;
      private int AV32PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int AV60GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV33GridCurrentPage ;
      private long AV34GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_96_idx="0001" ;
      private string AV44Pgmname ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
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
      private string AV36Display ;
      private string edtavDisplay_Internalname ;
      private string AV37Update ;
      private string edtavUpdate_Internalname ;
      private string AV38Delete ;
      private string edtavDelete_Internalname ;
      private string edtWebServiceId_Internalname ;
      private string cmbWebServiceTipoDmWS_Internalname ;
      private string edtWebServiceEndPointDecrypted_Internalname ;
      private string edtWebServiceAuthTipoDecrypted_Internalname ;
      private string cmbavWebservicetipodmws1_Internalname ;
      private string cmbavWebservicetipodmws2_Internalname ;
      private string cmbavWebservicetipodmws3_Internalname ;
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
      private string edtavDelete_Link ;
      private string GXt_char1 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblUnnamedtabledynamicfilters_3_Internalname ;
      private string cellFilter_webservicetipodmws3_cell_Internalname ;
      private string cmbavWebservicetipodmws3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblUnnamedtabledynamicfilters_2_Internalname ;
      private string cellFilter_webservicetipodmws2_cell_Internalname ;
      private string cmbavWebservicetipodmws2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblUnnamedtabledynamicfilters_1_Internalname ;
      private string cellFilter_webservicetipodmws1_cell_Internalname ;
      private string cmbavWebservicetipodmws1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_96_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtWebServiceId_Jsonclick ;
      private string GXCCtl ;
      private string cmbWebServiceTipoDmWS_Jsonclick ;
      private string edtWebServiceEndPointDecrypted_Jsonclick ;
      private string edtWebServiceAuthTipoDecrypted_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV20DynamicFiltersEnabled3 ;
      private bool AV24DynamicFiltersIgnoreFirst ;
      private bool AV23DynamicFiltersRemoving ;
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
      private bool n657WebServiceTipoDmWS ;
      private bool AV48Webservicewwds_4_dynamicfiltersenabled2 ;
      private bool AV51Webservicewwds_7_dynamicfiltersenabled3 ;
      private bool n658WebServiceEndPoint ;
      private bool n659WebServiceAuthTipo ;
      private bool bGXsfl_96_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV29TFWebServiceTipoDmWS_SelsJson ;
      private string A658WebServiceEndPoint ;
      private string A659WebServiceAuthTipo ;
      private string A1061WebServiceEndPointDecrypted ;
      private string A1062WebServiceAuthTipoDecrypted ;
      private string AV27ManageFiltersXml ;
      private string AV15DynamicFiltersSelector1 ;
      private string AV16WebServiceTipoDmWS1 ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV19WebServiceTipoDmWS2 ;
      private string AV21DynamicFiltersSelector3 ;
      private string AV22WebServiceTipoDmWS3 ;
      private string AV14FilterFullText ;
      private string AV40TFWebServiceEndPointDecrypted ;
      private string AV41TFWebServiceEndPointDecrypted_Sel ;
      private string AV42TFWebServiceAuthTipoDecrypted ;
      private string AV43TFWebServiceAuthTipoDecrypted_Sel ;
      private string AV35GridAppliedFilters ;
      private string A657WebServiceTipoDmWS ;
      private string AV45Webservicewwds_1_filterfulltext ;
      private string AV46Webservicewwds_2_dynamicfiltersselector1 ;
      private string AV47Webservicewwds_3_webservicetipodmws1 ;
      private string AV49Webservicewwds_5_dynamicfiltersselector2 ;
      private string AV50Webservicewwds_6_webservicetipodmws2 ;
      private string AV52Webservicewwds_8_dynamicfiltersselector3 ;
      private string AV53Webservicewwds_9_webservicetipodmws3 ;
      private string AV55Webservicewwds_11_tfwebserviceendpointdecrypted ;
      private string AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel ;
      private string AV57Webservicewwds_13_tfwebserviceauthtipodecrypted ;
      private string AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ;
      private string AV39AuxText ;
      private IGxSession AV25Session ;
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
      private GXCombobox cmbavWebservicetipodmws1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavWebservicetipodmws2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavWebservicetipodmws3 ;
      private GXCombobox cmbWebServiceTipoDmWS ;
      private GxSimpleCollection<string> AV30TFWebServiceTipoDmWS_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV26ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV31DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV54Webservicewwds_10_tfwebservicetipodmws_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H00A62_A657WebServiceTipoDmWS ;
      private bool[] H00A62_n657WebServiceTipoDmWS ;
      private int[] H00A62_A656WebServiceId ;
      private string[] H00A62_A658WebServiceEndPoint ;
      private bool[] H00A62_n658WebServiceEndPoint ;
      private string[] H00A62_A659WebServiceAuthTipo ;
      private bool[] H00A62_n659WebServiceAuthTipo ;
      private string[] H00A63_A657WebServiceTipoDmWS ;
      private bool[] H00A63_n657WebServiceTipoDmWS ;
      private int[] H00A63_A656WebServiceId ;
      private string[] H00A63_A658WebServiceEndPoint ;
      private bool[] H00A63_n658WebServiceEndPoint ;
      private string[] H00A63_A659WebServiceAuthTipo ;
      private bool[] H00A63_n659WebServiceAuthTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV12GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class webserviceww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00A62( IGxContext context ,
                                             string A657WebServiceTipoDmWS ,
                                             GxSimpleCollection<string> AV54Webservicewwds_10_tfwebservicetipodmws_sels ,
                                             string AV46Webservicewwds_2_dynamicfiltersselector1 ,
                                             string AV47Webservicewwds_3_webservicetipodmws1 ,
                                             bool AV48Webservicewwds_4_dynamicfiltersenabled2 ,
                                             string AV49Webservicewwds_5_dynamicfiltersselector2 ,
                                             string AV50Webservicewwds_6_webservicetipodmws2 ,
                                             bool AV51Webservicewwds_7_dynamicfiltersenabled3 ,
                                             string AV52Webservicewwds_8_dynamicfiltersselector3 ,
                                             string AV53Webservicewwds_9_webservicetipodmws3 ,
                                             int AV54Webservicewwds_10_tfwebservicetipodmws_sels_Count ,
                                             bool AV13OrderedDsc ,
                                             string AV45Webservicewwds_1_filterfulltext ,
                                             string A1061WebServiceEndPointDecrypted ,
                                             string A1062WebServiceAuthTipoDecrypted ,
                                             string AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                             string AV55Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                             string AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                             string AV57Webservicewwds_13_tfwebserviceauthtipodecrypted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[3];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT WebServiceTipoDmWS, WebServiceId, WebServiceEndPoint, WebServiceAuthTipo FROM WebService";
         if ( ( StringUtil.StrCmp(AV46Webservicewwds_2_dynamicfiltersselector1, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Webservicewwds_3_webservicetipodmws1)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV47Webservicewwds_3_webservicetipodmws1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( AV48Webservicewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV49Webservicewwds_5_dynamicfiltersselector2, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Webservicewwds_6_webservicetipodmws2)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV50Webservicewwds_6_webservicetipodmws2))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV51Webservicewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Webservicewwds_8_dynamicfiltersselector3, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Webservicewwds_9_webservicetipodmws3)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV53Webservicewwds_9_webservicetipodmws3))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV54Webservicewwds_10_tfwebservicetipodmws_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Webservicewwds_10_tfwebservicetipodmws_sels, "WebServiceTipoDmWS IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY WebServiceTipoDmWS, WebServiceId";
         }
         else if ( AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY WebServiceTipoDmWS DESC, WebServiceId";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00A63( IGxContext context ,
                                             string A657WebServiceTipoDmWS ,
                                             GxSimpleCollection<string> AV54Webservicewwds_10_tfwebservicetipodmws_sels ,
                                             string AV46Webservicewwds_2_dynamicfiltersselector1 ,
                                             string AV47Webservicewwds_3_webservicetipodmws1 ,
                                             bool AV48Webservicewwds_4_dynamicfiltersenabled2 ,
                                             string AV49Webservicewwds_5_dynamicfiltersselector2 ,
                                             string AV50Webservicewwds_6_webservicetipodmws2 ,
                                             bool AV51Webservicewwds_7_dynamicfiltersenabled3 ,
                                             string AV52Webservicewwds_8_dynamicfiltersselector3 ,
                                             string AV53Webservicewwds_9_webservicetipodmws3 ,
                                             int AV54Webservicewwds_10_tfwebservicetipodmws_sels_Count ,
                                             bool AV13OrderedDsc ,
                                             string AV45Webservicewwds_1_filterfulltext ,
                                             string A1061WebServiceEndPointDecrypted ,
                                             string A1062WebServiceAuthTipoDecrypted ,
                                             string AV56Webservicewwds_12_tfwebserviceendpointdecrypted_sel ,
                                             string AV55Webservicewwds_11_tfwebserviceendpointdecrypted ,
                                             string AV58Webservicewwds_14_tfwebserviceauthtipodecrypted_sel ,
                                             string AV57Webservicewwds_13_tfwebserviceauthtipodecrypted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[3];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT WebServiceTipoDmWS, WebServiceId, WebServiceEndPoint, WebServiceAuthTipo FROM WebService";
         if ( ( StringUtil.StrCmp(AV46Webservicewwds_2_dynamicfiltersselector1, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Webservicewwds_3_webservicetipodmws1)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV47Webservicewwds_3_webservicetipodmws1))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( AV48Webservicewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV49Webservicewwds_5_dynamicfiltersselector2, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Webservicewwds_6_webservicetipodmws2)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV50Webservicewwds_6_webservicetipodmws2))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( AV51Webservicewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Webservicewwds_8_dynamicfiltersselector3, "WEBSERVICETIPODMWS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Webservicewwds_9_webservicetipodmws3)) ) )
         {
            AddWhere(sWhereString, "(WebServiceTipoDmWS = ( :AV53Webservicewwds_9_webservicetipodmws3))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( AV54Webservicewwds_10_tfwebservicetipodmws_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV54Webservicewwds_10_tfwebservicetipodmws_sels, "WebServiceTipoDmWS IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ! AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY WebServiceTipoDmWS, WebServiceId";
         }
         else if ( AV13OrderedDsc )
         {
            scmdbuf += " ORDER BY WebServiceTipoDmWS DESC, WebServiceId";
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
                     return conditional_H00A62(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_H00A63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
          Object[] prmH00A62;
          prmH00A62 = new Object[] {
          new ParDef("AV47Webservicewwds_3_webservicetipodmws1",GXType.VarChar,40,0) ,
          new ParDef("AV50Webservicewwds_6_webservicetipodmws2",GXType.VarChar,40,0) ,
          new ParDef("AV53Webservicewwds_9_webservicetipodmws3",GXType.VarChar,40,0)
          };
          Object[] prmH00A63;
          prmH00A63 = new Object[] {
          new ParDef("AV47Webservicewwds_3_webservicetipodmws1",GXType.VarChar,40,0) ,
          new ParDef("AV50Webservicewwds_6_webservicetipodmws2",GXType.VarChar,40,0) ,
          new ParDef("AV53Webservicewwds_9_webservicetipodmws3",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00A62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A62,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00A63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00A63,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
