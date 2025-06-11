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
   public class tipoclienteww : GXDataArea
   {
      public tipoclienteww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipoclienteww( IGxContext context )
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
         cmbTipoClienteTipoPessoa = new GXCombobox();
         cmbTipoClientePortal = new GXCombobox();
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
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV18FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV21TipoClienteDescricao1 = GetPar( "TipoClienteDescricao1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25TipoClienteDescricao2 = GetPar( "TipoClienteDescricao2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV29TipoClienteDescricao3 = GetPar( "TipoClienteDescricao3");
         AV41ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV62Pgmname = GetPar( "Pgmname");
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV26DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV42TFTipoClienteDescricao = GetPar( "TFTipoClienteDescricao");
         AV43TFTipoClienteDescricao_Sel = GetPar( "TFTipoClienteDescricao_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV45TFTipoClienteTipoPessoa_Sels);
         AV61TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFTipoClientePortal_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV12GridState);
         AV31DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV30DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
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
         PA3Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3Q2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tipoclienteww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV16OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV18FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV19DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO1", AV21TipoClienteDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO2", AV25TipoClienteDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV27DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTIPOCLIENTEDESCRICAO3", AV29TipoClienteDescricao3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_109", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_109), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV50GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV26DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO", AV42TFTipoClienteDescricao);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEDESCRICAO_SEL", AV43TFTipoClienteDescricao_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTIPOCLIENTETIPOPESSOA_SELS", AV45TFTipoClienteTipoPessoa_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTIPOCLIENTETIPOPESSOA_SELS", AV45TFTipoClienteTipoPessoa_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTEPORTAL_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV16OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV31DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV30DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFTIPOCLIENTETIPOPESSOA_SELSJSON", AV44TFTipoClienteTipoPessoa_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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
            WE3Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3Q2( ) ;
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
         return formatLink("tipoclienteww")  ;
      }

      public override string GetPgmname( )
      {
         return "TipoClienteWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Tipo Cliente" ;
      }

      protected void WB3Q0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(109), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoClienteWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV39ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV18FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV18FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_TipoClienteWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV19DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_47_3Q2( true) ;
         }
         else
         {
            wb_table1_47_3Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_3Q2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_69_3Q2( true) ;
         }
         else
         {
            wb_table2_69_3Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_69_3Q2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_109_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV27DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_91_3Q2( true) ;
         }
         else
         {
            wb_table3_91_3Q2( false) ;
         }
         return  ;
      }

      protected void wb_table3_91_3Q2e( bool wbgen )
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV48GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV49GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV50GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_TipoClienteWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
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

      protected void START3Q2( )
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
         Form.Meta.addItem("description", " Tipo Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3Q0( ) ;
      }

      protected void WS3Q2( )
      {
         START3Q2( ) ;
         EVT3Q2( ) ;
      }

      protected void EVT3Q2( )
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
                              E113Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E153Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E163Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E173Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E183Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E193Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E203Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E213Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E223Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E233Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E253Q2 ();
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
                              nGXsfl_109_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
                              SubsflControlProps_1092( ) ;
                              AV58Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV58Display);
                              AV59Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
                              A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
                              n193TipoClienteDescricao = false;
                              cmbTipoClienteTipoPessoa.Name = cmbTipoClienteTipoPessoa_Internalname;
                              cmbTipoClienteTipoPessoa.CurrentValue = cgiGet( cmbTipoClienteTipoPessoa_Internalname);
                              A194TipoClienteTipoPessoa = cgiGet( cmbTipoClienteTipoPessoa_Internalname);
                              n194TipoClienteTipoPessoa = false;
                              cmbTipoClientePortal.Name = cmbTipoClientePortal_Internalname;
                              cmbTipoClientePortal.CurrentValue = cgiGet( cmbTipoClientePortal_Internalname);
                              A207TipoClientePortal = StringUtil.StrToBool( cgiGet( cmbTipoClientePortal_Internalname));
                              n207TipoClientePortal = false;
                              A195TipoClienteCreatedAt = context.localUtil.CToT( cgiGet( edtTipoClienteCreatedAt_Internalname), 0);
                              n195TipoClienteCreatedAt = false;
                              A196TipoClienteUpdateAt = context.localUtil.CToT( cgiGet( edtTipoClienteUpdateAt_Internalname), 0);
                              n196TipoClienteUpdateAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E263Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E273Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E283Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV16OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV19DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV21TipoClienteDescricao1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV25TipoClienteDescricao2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tipoclientedescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV29TipoClienteDescricao3) != 0 )
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

      protected void WE3Q2( )
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

      protected void PA3Q2( )
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
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string AV18FilterFullText ,
                                       string AV19DynamicFiltersSelector1 ,
                                       short AV20DynamicFiltersOperator1 ,
                                       string AV21TipoClienteDescricao1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV25TipoClienteDescricao2 ,
                                       string AV27DynamicFiltersSelector3 ,
                                       short AV28DynamicFiltersOperator3 ,
                                       string AV29TipoClienteDescricao3 ,
                                       short AV41ManageFiltersExecutionStep ,
                                       string AV62Pgmname ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV26DynamicFiltersEnabled3 ,
                                       string AV42TFTipoClienteDescricao ,
                                       string AV43TFTipoClienteDescricao_Sel ,
                                       GxSimpleCollection<string> AV45TFTipoClienteTipoPessoa_Sels ,
                                       short AV61TFTipoClientePortal_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ,
                                       bool AV31DynamicFiltersIgnoreFirst ,
                                       bool AV30DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", "")));
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
            AV19DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV19DynamicFiltersSelector1);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV62Pgmname = "TipoClienteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RF3Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 109;
         /* Execute user event: Refresh */
         E273Q2 ();
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
                                                 A194TipoClienteTipoPessoa ,
                                                 AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                                 AV63Tipoclientewwds_1_filterfulltext ,
                                                 AV64Tipoclientewwds_2_dynamicfiltersselector1 ,
                                                 AV65Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                                 AV66Tipoclientewwds_4_tipoclientedescricao1 ,
                                                 AV67Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                                 AV68Tipoclientewwds_6_dynamicfiltersselector2 ,
                                                 AV69Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                                 AV70Tipoclientewwds_8_tipoclientedescricao2 ,
                                                 AV71Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                                 AV72Tipoclientewwds_10_dynamicfiltersselector3 ,
                                                 AV73Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                                 AV74Tipoclientewwds_12_tipoclientedescricao3 ,
                                                 AV76Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                                 AV75Tipoclientewwds_13_tftipoclientedescricao ,
                                                 AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels.Count ,
                                                 AV78Tipoclientewwds_16_tftipoclienteportal_sel ,
                                                 A193TipoClienteDescricao ,
                                                 A207TipoClientePortal ,
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
            lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
            lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
            lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
            lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
            lV66Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1), "%", "");
            lV66Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1), "%", "");
            lV70Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2), "%", "");
            lV70Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2), "%", "");
            lV74Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3), "%", "");
            lV74Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3), "%", "");
            lV75Tipoclientewwds_13_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV75Tipoclientewwds_13_tftipoclientedescricao), "%", "");
            /* Using cursor H003Q2 */
            pr_default.execute(0, new Object[] {lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV66Tipoclientewwds_4_tipoclientedescricao1, lV66Tipoclientewwds_4_tipoclientedescricao1, lV70Tipoclientewwds_8_tipoclientedescricao2, lV70Tipoclientewwds_8_tipoclientedescricao2, lV74Tipoclientewwds_12_tipoclientedescricao3, lV74Tipoclientewwds_12_tipoclientedescricao3, lV75Tipoclientewwds_13_tftipoclientedescricao, AV76Tipoclientewwds_14_tftipoclientedescricao_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_109_idx = 1;
            sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
            SubsflControlProps_1092( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A196TipoClienteUpdateAt = H003Q2_A196TipoClienteUpdateAt[0];
               n196TipoClienteUpdateAt = H003Q2_n196TipoClienteUpdateAt[0];
               A195TipoClienteCreatedAt = H003Q2_A195TipoClienteCreatedAt[0];
               n195TipoClienteCreatedAt = H003Q2_n195TipoClienteCreatedAt[0];
               A207TipoClientePortal = H003Q2_A207TipoClientePortal[0];
               n207TipoClientePortal = H003Q2_n207TipoClientePortal[0];
               A194TipoClienteTipoPessoa = H003Q2_A194TipoClienteTipoPessoa[0];
               n194TipoClienteTipoPessoa = H003Q2_n194TipoClienteTipoPessoa[0];
               A193TipoClienteDescricao = H003Q2_A193TipoClienteDescricao[0];
               n193TipoClienteDescricao = H003Q2_n193TipoClienteDescricao[0];
               A192TipoClienteId = H003Q2_A192TipoClienteId[0];
               /* Execute user event: Grid.Load */
               E283Q2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 109;
            WB3Q0( ) ;
         }
         bGXsfl_109_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Q2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_TIPOCLIENTEID"+"_"+sGXsfl_109_idx, GetSecureSignedToken( sGXsfl_109_idx, context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9"), context));
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
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A194TipoClienteTipoPessoa ,
                                              AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                              AV63Tipoclientewwds_1_filterfulltext ,
                                              AV64Tipoclientewwds_2_dynamicfiltersselector1 ,
                                              AV65Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                              AV66Tipoclientewwds_4_tipoclientedescricao1 ,
                                              AV67Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                              AV68Tipoclientewwds_6_dynamicfiltersselector2 ,
                                              AV69Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                              AV70Tipoclientewwds_8_tipoclientedescricao2 ,
                                              AV71Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                              AV72Tipoclientewwds_10_dynamicfiltersselector3 ,
                                              AV73Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                              AV74Tipoclientewwds_12_tipoclientedescricao3 ,
                                              AV76Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                              AV75Tipoclientewwds_13_tftipoclientedescricao ,
                                              AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels.Count ,
                                              AV78Tipoclientewwds_16_tftipoclienteportal_sel ,
                                              A193TipoClienteDescricao ,
                                              A207TipoClientePortal ,
                                              AV15OrderedBy ,
                                              AV16OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
         lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
         lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
         lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
         lV63Tipoclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext), "%", "");
         lV66Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV66Tipoclientewwds_4_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1), "%", "");
         lV70Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV70Tipoclientewwds_8_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2), "%", "");
         lV74Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV74Tipoclientewwds_12_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3), "%", "");
         lV75Tipoclientewwds_13_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV75Tipoclientewwds_13_tftipoclientedescricao), "%", "");
         /* Using cursor H003Q3 */
         pr_default.execute(1, new Object[] {lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV63Tipoclientewwds_1_filterfulltext, lV66Tipoclientewwds_4_tipoclientedescricao1, lV66Tipoclientewwds_4_tipoclientedescricao1, lV70Tipoclientewwds_8_tipoclientedescricao2, lV70Tipoclientewwds_8_tipoclientedescricao2, lV74Tipoclientewwds_12_tipoclientedescricao3, lV74Tipoclientewwds_12_tipoclientedescricao3, lV75Tipoclientewwds_13_tftipoclientedescricao, AV76Tipoclientewwds_14_tftipoclientedescricao_sel});
         GRID_nRecordCount = H003Q3_AGRID_nRecordCount[0];
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
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV62Pgmname = "TipoClienteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtTipoClienteId_Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         cmbTipoClienteTipoPessoa.Enabled = 0;
         cmbTipoClientePortal.Enabled = 0;
         edtTipoClienteCreatedAt_Enabled = 0;
         edtTipoClienteUpdateAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E263Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV39ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_109 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_109"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV49GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV50GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV18FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV19DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AV21TipoClienteDescricao1 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao1_Internalname));
            AssignAttri("", false, "AV21TipoClienteDescricao1", AV21TipoClienteDescricao1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV25TipoClienteDescricao2 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao2_Internalname));
            AssignAttri("", false, "AV25TipoClienteDescricao2", AV25TipoClienteDescricao2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV27DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AV29TipoClienteDescricao3 = StringUtil.Upper( cgiGet( edtavTipoclientedescricao3_Internalname));
            AssignAttri("", false, "AV29TipoClienteDescricao3", AV29TipoClienteDescricao3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV16OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV19DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV20DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO1"), AV21TipoClienteDescricao1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO2"), AV25TipoClienteDescricao2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV27DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV28DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTIPOCLIENTEDESCRICAO3"), AV29TipoClienteDescricao3) != 0 )
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
         E263Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E263Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV9HTTPRequest.Method, "GET") == 0 )
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
         AV19DynamicFiltersSelector1 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersSelector3 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
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
         Form.Caption = " Tipo Cliente";
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
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV46DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV46DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E273Q2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV41ManageFiltersExecutionStep == 1 )
         {
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV41ManageFiltersExecutionStep == 2 )
         {
            AV41ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
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
         AV48GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV48GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV48GridCurrentPage), 10, 0));
         AV49GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV49GridPageCount", StringUtil.LTrimStr( (decimal)(AV49GridPageCount), 10, 0));
         GXt_char2 = AV50GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV62Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         AV63Tipoclientewwds_1_filterfulltext = AV18FilterFullText;
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV65Tipoclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV66Tipoclientewwds_4_tipoclientedescricao1 = AV21TipoClienteDescricao1;
         AV67Tipoclientewwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV69Tipoclientewwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV70Tipoclientewwds_8_tipoclientedescricao2 = AV25TipoClienteDescricao2;
         AV71Tipoclientewwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV73Tipoclientewwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV74Tipoclientewwds_12_tipoclientedescricao3 = AV29TipoClienteDescricao3;
         AV75Tipoclientewwds_13_tftipoclientedescricao = AV42TFTipoClienteDescricao;
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = AV43TFTipoClienteDescricao_Sel;
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = AV45TFTipoClienteTipoPessoa_Sels;
         AV78Tipoclientewwds_16_tftipoclienteportal_sel = AV61TFTipoClientePortal_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
      }

      protected void E123Q2( )
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
            AV47PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV47PageToGo) ;
         }
      }

      protected void E133Q2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143Q2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoClienteDescricao") == 0 )
            {
               AV42TFTipoClienteDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV42TFTipoClienteDescricao", AV42TFTipoClienteDescricao);
               AV43TFTipoClienteDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV43TFTipoClienteDescricao_Sel", AV43TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoClienteTipoPessoa") == 0 )
            {
               AV44TFTipoClienteTipoPessoa_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFTipoClienteTipoPessoa_SelsJson", AV44TFTipoClienteTipoPessoa_SelsJson);
               AV45TFTipoClienteTipoPessoa_Sels.FromJSonString(AV44TFTipoClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TipoClientePortal") == 0 )
            {
               AV61TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV61TFTipoClientePortal_Sel", StringUtil.Str( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFTipoClienteTipoPessoa_Sels", AV45TFTipoClienteTipoPessoa_Sels);
      }

      private void E283Q2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV58Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV58Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A192TipoClienteId,4,0));
         edtavDisplay_Link = formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV59Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV59Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A192TipoClienteId,4,0));
         edtavUpdate_Link = formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A192TipoClienteId,4,0));
         edtTipoClienteDescricao_Link = formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
      }

      protected void E213Q2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E153Q2( )
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
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E223Q2( )
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

      protected void E233Q2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV26DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E163Q2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
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
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E243Q2( )
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

      protected void E173Q2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV30DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV30DynamicFiltersRemoving", AV30DynamicFiltersRemoving);
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
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
         gxgrGrid_refresh( subGrid_Rows, AV15OrderedBy, AV16OrderedDsc, AV18FilterFullText, AV19DynamicFiltersSelector1, AV20DynamicFiltersOperator1, AV21TipoClienteDescricao1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25TipoClienteDescricao2, AV27DynamicFiltersSelector3, AV28DynamicFiltersOperator3, AV29TipoClienteDescricao3, AV41ManageFiltersExecutionStep, AV62Pgmname, AV22DynamicFiltersEnabled2, AV26DynamicFiltersEnabled3, AV42TFTipoClienteDescricao, AV43TFTipoClienteDescricao_Sel, AV45TFTipoClienteTipoPessoa_Sels, AV61TFTipoClientePortal_Sel, AV12GridState, AV31DynamicFiltersIgnoreFirst, AV30DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E253Q2( )
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

      protected void E113Q2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("TipoClienteWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV62Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("TipoClienteWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV40ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "TipoClienteWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV40ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV40ManageFiltersXml) ;
               AV12GridState.FromXml(AV40ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFTipoClienteTipoPessoa_Sels", AV45TFTipoClienteTipoPessoa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E183Q2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "tipocliente"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         context.PopUp(formatLink("tipocliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
      }

      protected void E193Q2( )
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
         new tipoclientewwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFTipoClienteTipoPessoa_Sels", AV45TFTipoClienteTipoPessoa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E203Q2( )
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
         Innewwindow1_Target = formatLink("tipoclientewwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV45TFTipoClienteTipoPessoa_Sels", AV45TFTipoClienteTipoPessoa_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV19DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV27DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavTipoclientedescricao1_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao1_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTipoclientedescricao2_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao2_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTipoclientedescricao3_Visible = 0;
         AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
         {
            edtavTipoclientedescricao3_Visible = 1;
            AssignProp("", false, edtavTipoclientedescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTipoclientedescricao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25TipoClienteDescricao2 = "";
         AssignAttri("", false, "AV25TipoClienteDescricao2", AV25TipoClienteDescricao2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
         AV27DynamicFiltersSelector3 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         AV28DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         AV29TipoClienteDescricao3 = "";
         AssignAttri("", false, "AV29TipoClienteDescricao3", AV29TipoClienteDescricao3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV39ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "TipoClienteWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV39ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV18FilterFullText = "";
         AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
         AV42TFTipoClienteDescricao = "";
         AssignAttri("", false, "AV42TFTipoClienteDescricao", AV42TFTipoClienteDescricao);
         AV43TFTipoClienteDescricao_Sel = "";
         AssignAttri("", false, "AV43TFTipoClienteDescricao_Sel", AV43TFTipoClienteDescricao_Sel);
         AV45TFTipoClienteTipoPessoa_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV61TFTipoClientePortal_Sel = 0;
         AssignAttri("", false, "AV61TFTipoClientePortal_Sel", StringUtil.Str( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV19DynamicFiltersSelector1 = "TIPOCLIENTEDESCRICAO";
         AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         AV20DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         AV21TipoClienteDescricao1 = "";
         AssignAttri("", false, "AV21TipoClienteDescricao1", AV21TipoClienteDescricao1);
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
         AV12GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV38Session.Get(AV62Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV62Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV38Session.Get(AV62Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV16OrderedDsc", AV16OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV18FilterFullText", AV18FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV42TFTipoClienteDescricao = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFTipoClienteDescricao", AV42TFTipoClienteDescricao);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV43TFTipoClienteDescricao_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFTipoClienteDescricao_Sel", AV43TFTipoClienteDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV44TFTipoClienteTipoPessoa_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFTipoClienteTipoPessoa_SelsJson", AV44TFTipoClienteTipoPessoa_SelsJson);
               AV45TFTipoClienteTipoPessoa_Sels.FromJSonString(AV44TFTipoClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEPORTAL_SEL") == 0 )
            {
               AV61TFTipoClientePortal_Sel = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV61TFTipoClientePortal_Sel", StringUtil.Str( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0));
            }
            AV79GXV1 = (int)(AV79GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipoClienteDescricao_Sel)),  AV43TFTipoClienteDescricao_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV45TFTipoClienteTipoPessoa_Sels.Count==0),  AV44TFTipoClienteTipoPessoa_SelsJson, out  GXt_char4) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+((0==AV61TFTipoClientePortal_Sel) ? "" : StringUtil.Str( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTipoClienteDescricao)),  AV42TFTipoClienteDescricao, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char4+"||";
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
         if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV14GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV14GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
               AV21TipoClienteDescricao1 = AV14GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21TipoClienteDescricao1", AV21TipoClienteDescricao1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV14GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV14GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25TipoClienteDescricao2 = AV14GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV25TipoClienteDescricao2", AV25TipoClienteDescricao2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV12GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV26DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV26DynamicFiltersEnabled3", AV26DynamicFiltersEnabled3);
                  AV14GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV12GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV14GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV14GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
                     AV29TipoClienteDescricao3 = AV14GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV29TipoClienteDescricao3", AV29TipoClienteDescricao3);
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
         AV12GridState.FromXml(AV38Session.Get(AV62Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)),  0,  AV18FilterFullText,  AV18FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFTIPOCLIENTEDESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTipoClienteDescricao)),  0,  AV42TFTipoClienteDescricao,  AV42TFTipoClienteDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTipoClienteDescricao_Sel)),  AV43TFTipoClienteDescricao_Sel,  AV43TFTipoClienteDescricao_Sel) ;
         AV57AuxText = ((AV45TFTipoClienteTipoPessoa_Sels.Count==1) ? "["+((string)AV45TFTipoClienteTipoPessoa_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFTIPOCLIENTETIPOPESSOA_SEL",  "Tipo Pessoa",  !(AV45TFTipoClienteTipoPessoa_Sels.Count==0),  0,  AV45TFTipoClienteTipoPessoa_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV57AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV57AuxText, "[FISICA]", "Física"), "[JURIDICA]", "Jurídica")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFTIPOCLIENTEPORTAL_SEL",  "Acesso ao portal clinica",  !(0==AV61TFTipoClientePortal_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV61TFTipoClientePortal_Sel), 1, 0)),  ((AV61TFTipoClientePortal_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV12GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV31DynamicFiltersIgnoreFirst )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV19DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TipoClienteDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV20DynamicFiltersOperator1,  AV21TipoClienteDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV21TipoClienteDescricao1, "Contém"+" "+AV21TipoClienteDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TipoClienteDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV24DynamicFiltersOperator2,  AV25TipoClienteDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV25TipoClienteDescricao2, "Contém"+" "+AV25TipoClienteDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
         if ( AV26DynamicFiltersEnabled3 )
         {
            AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV14GridStateDynamicFilter.gxTpr_Selected = AV27DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TipoClienteDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV14GridStateDynamicFilter,  "Descrição",  AV28DynamicFiltersOperator3,  AV29TipoClienteDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV29TipoClienteDescricao3, "Contém"+" "+AV29TipoClienteDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV30DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV14GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV12GridState.gxTpr_Dynamicfilters.Add(AV14GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV62Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "TipoCliente";
         AV38Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
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

      protected void wb_table3_91_3Q2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao3_Internalname, "Tipo Cliente Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao3_Internalname, AV29TipoClienteDescricao3, StringUtil.RTrim( context.localUtil.Format( AV29TipoClienteDescricao3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao3_Visible, edtavTipoclientedescricao3_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TipoClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_91_3Q2e( true) ;
         }
         else
         {
            wb_table3_91_3Q2e( false) ;
         }
      }

      protected void wb_table2_69_3Q2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao2_Internalname, "Tipo Cliente Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao2_Internalname, AV25TipoClienteDescricao2, StringUtil.RTrim( context.localUtil.Format( AV25TipoClienteDescricao2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao2_Visible, edtavTipoclientedescricao2_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TipoClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TipoClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_69_3Q2e( true) ;
         }
         else
         {
            wb_table2_69_3Q2e( false) ;
         }
      }

      protected void wb_table1_47_3Q2( bool wbgen )
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_TipoClienteWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tipoclientedescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTipoclientedescricao1_Internalname, "Tipo Cliente Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_109_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTipoclientedescricao1_Internalname, AV21TipoClienteDescricao1, StringUtil.RTrim( context.localUtil.Format( AV21TipoClienteDescricao1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTipoclientedescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTipoclientedescricao1_Visible, edtavTipoclientedescricao1_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TipoClienteWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TipoClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TipoClienteWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_3Q2e( true) ;
         }
         else
         {
            wb_table1_47_3Q2e( false) ;
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
         PA3Q2( ) ;
         WS3Q2( ) ;
         WE3Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101924834", true, true);
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
         context.AddJavascriptSource("tipoclienteww.js", "?20256101924835", false, true);
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
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_109_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_109_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_109_idx;
         cmbTipoClienteTipoPessoa_Internalname = "TIPOCLIENTETIPOPESSOA_"+sGXsfl_109_idx;
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL_"+sGXsfl_109_idx;
         edtTipoClienteCreatedAt_Internalname = "TIPOCLIENTECREATEDAT_"+sGXsfl_109_idx;
         edtTipoClienteUpdateAt_Internalname = "TIPOCLIENTEUPDATEAT_"+sGXsfl_109_idx;
      }

      protected void SubsflControlProps_fel_1092( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_109_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_109_fel_idx;
         edtTipoClienteId_Internalname = "TIPOCLIENTEID_"+sGXsfl_109_fel_idx;
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO_"+sGXsfl_109_fel_idx;
         cmbTipoClienteTipoPessoa_Internalname = "TIPOCLIENTETIPOPESSOA_"+sGXsfl_109_fel_idx;
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL_"+sGXsfl_109_fel_idx;
         edtTipoClienteCreatedAt_Internalname = "TIPOCLIENTECREATEDAT_"+sGXsfl_109_fel_idx;
         edtTipoClienteUpdateAt_Internalname = "TIPOCLIENTEUPDATEAT_"+sGXsfl_109_fel_idx;
      }

      protected void sendrow_1092( )
      {
         sGXsfl_109_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_109_idx), 4, 0), 4, "0");
         SubsflControlProps_1092( ) ;
         WB3Q0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV58Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_109_idx + "',109)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV59Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A192TipoClienteId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteDescricao_Internalname,(string)A193TipoClienteDescricao,StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTipoClienteDescricao_Link,(string)"",(string)"",(string)"",(string)edtTipoClienteDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTipoClienteTipoPessoa.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TIPOCLIENTETIPOPESSOA_" + sGXsfl_109_idx;
               cmbTipoClienteTipoPessoa.Name = GXCCtl;
               cmbTipoClienteTipoPessoa.WebTags = "";
               cmbTipoClienteTipoPessoa.addItem("FISICA", "Física", 0);
               cmbTipoClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
               if ( cmbTipoClienteTipoPessoa.ItemCount > 0 )
               {
                  A194TipoClienteTipoPessoa = cmbTipoClienteTipoPessoa.getValidValue(A194TipoClienteTipoPessoa);
                  n194TipoClienteTipoPessoa = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTipoClienteTipoPessoa,(string)cmbTipoClienteTipoPessoa_Internalname,StringUtil.RTrim( A194TipoClienteTipoPessoa),(short)1,(string)cmbTipoClienteTipoPessoa_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTipoClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A194TipoClienteTipoPessoa);
            AssignProp("", false, cmbTipoClienteTipoPessoa_Internalname, "Values", (string)(cmbTipoClienteTipoPessoa.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTipoClientePortal.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TIPOCLIENTEPORTAL_" + sGXsfl_109_idx;
               cmbTipoClientePortal.Name = GXCCtl;
               cmbTipoClientePortal.WebTags = "";
               cmbTipoClientePortal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbTipoClientePortal.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbTipoClientePortal.ItemCount > 0 )
               {
                  A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
                  n207TipoClientePortal = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTipoClientePortal,(string)cmbTipoClientePortal_Internalname,StringUtil.BoolToStr( A207TipoClientePortal),(short)1,(string)cmbTipoClientePortal_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbTipoClientePortal.CurrentValue = StringUtil.BoolToStr( A207TipoClientePortal);
            AssignProp("", false, cmbTipoClientePortal_Internalname, "Values", (string)(cmbTipoClientePortal.ToJavascriptSource()), !bGXsfl_109_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteCreatedAt_Internalname,context.localUtil.TToC( A195TipoClienteCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A195TipoClienteCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipoClienteUpdateAt_Internalname,context.localUtil.TToC( A196TipoClienteUpdateAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A196TipoClienteUpdateAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipoClienteUpdateAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)109,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes3Q2( ) ;
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
         cmbavDynamicfiltersselector1.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV19DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV19DynamicFiltersSelector1);
            AssignAttri("", false, "AV19DynamicFiltersSelector1", AV19DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV20DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV20DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV20DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV20DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TIPOCLIENTEDESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV27DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV27DynamicFiltersSelector3);
            AssignAttri("", false, "AV27DynamicFiltersSelector3", AV27DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV28DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV28DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV28DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV28DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "TIPOCLIENTETIPOPESSOA_" + sGXsfl_109_idx;
         cmbTipoClienteTipoPessoa.Name = GXCCtl;
         cmbTipoClienteTipoPessoa.WebTags = "";
         cmbTipoClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbTipoClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbTipoClienteTipoPessoa.ItemCount > 0 )
         {
            A194TipoClienteTipoPessoa = cmbTipoClienteTipoPessoa.getValidValue(A194TipoClienteTipoPessoa);
            n194TipoClienteTipoPessoa = false;
         }
         GXCCtl = "TIPOCLIENTEPORTAL_" + sGXsfl_109_idx;
         cmbTipoClientePortal.Name = GXCCtl;
         cmbTipoClientePortal.WebTags = "";
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbTipoClientePortal.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbTipoClientePortal.ItemCount > 0 )
         {
            A207TipoClientePortal = StringUtil.StrToBool( cmbTipoClientePortal.getValidValue(StringUtil.BoolToStr( A207TipoClientePortal)));
            n207TipoClientePortal = false;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo Pessoa") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Acesso ao portal clinica") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created At") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Update At") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV58Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV59Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A193TipoClienteDescricao));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTipoClienteDescricao_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A194TipoClienteTipoPessoa));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A207TipoClientePortal)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A195TipoClienteCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A196TipoClienteUpdateAt, 10, 8, 0, 3, "/", ":", " ")));
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
         edtavTipoclientedescricao1_Internalname = "vTIPOCLIENTEDESCRICAO1";
         cellFilter_tipoclientedescricao1_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO1_CELL";
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
         edtavTipoclientedescricao2_Internalname = "vTIPOCLIENTEDESCRICAO2";
         cellFilter_tipoclientedescricao2_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO2_CELL";
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
         edtavTipoclientedescricao3_Internalname = "vTIPOCLIENTEDESCRICAO3";
         cellFilter_tipoclientedescricao3_cell_Internalname = "FILTER_TIPOCLIENTEDESCRICAO3_CELL";
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
         edtTipoClienteId_Internalname = "TIPOCLIENTEID";
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         cmbTipoClienteTipoPessoa_Internalname = "TIPOCLIENTETIPOPESSOA";
         cmbTipoClientePortal_Internalname = "TIPOCLIENTEPORTAL";
         edtTipoClienteCreatedAt_Internalname = "TIPOCLIENTECREATEDAT";
         edtTipoClienteUpdateAt_Internalname = "TIPOCLIENTEUPDATEAT";
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
         edtTipoClienteUpdateAt_Jsonclick = "";
         edtTipoClienteCreatedAt_Jsonclick = "";
         cmbTipoClientePortal_Jsonclick = "";
         cmbTipoClienteTipoPessoa_Jsonclick = "";
         edtTipoClienteDescricao_Jsonclick = "";
         edtTipoClienteDescricao_Link = "";
         edtTipoClienteId_Jsonclick = "";
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
         edtavTipoclientedescricao1_Jsonclick = "";
         edtavTipoclientedescricao1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTipoclientedescricao2_Jsonclick = "";
         edtavTipoclientedescricao2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTipoclientedescricao3_Jsonclick = "";
         edtavTipoclientedescricao3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTipoclientedescricao3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTipoclientedescricao2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTipoclientedescricao1_Visible = 1;
         edtTipoClienteUpdateAt_Enabled = 0;
         edtTipoClienteCreatedAt_Enabled = 0;
         cmbTipoClientePortal.Enabled = 0;
         cmbTipoClienteTipoPessoa.Enabled = 0;
         edtTipoClienteDescricao_Enabled = 0;
         edtTipoClienteId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "TipoClienteWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|FISICA:Física,JURIDICA:Jurídica|1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Allowmultipleselection = "|T|";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character||";
         Ddo_grid_Includefilter = "T||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "3:TipoClienteDescricao|4:TipoClienteTipoPessoa|5:TipoClientePortal";
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
         Form.Caption = " Tipo Cliente";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E283Q2","iparms":[{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV58Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV59Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtTipoClienteDescricao_Link","ctrl":"TIPOCLIENTEDESCRICAO","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E213Q2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E153Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E223Q2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E233Q2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E163Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E243Q2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E173Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E253Q2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E183Q2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A192TipoClienteId","fld":"TIPOCLIENTEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E193Q2","iparms":[{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E203Q2","iparms":[{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV12GridState","fld":"vGRIDSTATE","type":""},{"av":"AV15OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV16OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV18FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV19DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV20DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV21TipoClienteDescricao1","fld":"vTIPOCLIENTEDESCRICAO1","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25TipoClienteDescricao2","fld":"vTIPOCLIENTEDESCRICAO2","pic":"@!","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV27DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV28DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV29TipoClienteDescricao3","fld":"vTIPOCLIENTEDESCRICAO3","pic":"@!","type":"svchar"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV62Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV26DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV42TFTipoClienteDescricao","fld":"vTFTIPOCLIENTEDESCRICAO","pic":"@!","type":"svchar"},{"av":"AV43TFTipoClienteDescricao_Sel","fld":"vTFTIPOCLIENTEDESCRICAO_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFTipoClienteTipoPessoa_Sels","fld":"vTFTIPOCLIENTETIPOPESSOA_SELS","type":""},{"av":"AV61TFTipoClientePortal_Sel","fld":"vTFTIPOCLIENTEPORTAL_SEL","pic":"9","type":"int"},{"av":"AV31DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV30DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV44TFTipoClienteTipoPessoa_SelsJson","fld":"vTFTIPOCLIENTETIPOPESSOA_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTipoclientedescricao1_Visible","ctrl":"vTIPOCLIENTEDESCRICAO1","prop":"Visible"},{"av":"edtavTipoclientedescricao2_Visible","ctrl":"vTIPOCLIENTEDESCRICAO2","prop":"Visible"},{"av":"edtavTipoclientedescricao3_Visible","ctrl":"vTIPOCLIENTEDESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Tipoclienteupdateat","iparms":[]}""");
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
         AV18FilterFullText = "";
         AV19DynamicFiltersSelector1 = "";
         AV21TipoClienteDescricao1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25TipoClienteDescricao2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29TipoClienteDescricao3 = "";
         AV62Pgmname = "";
         AV42TFTipoClienteDescricao = "";
         AV43TFTipoClienteDescricao_Sel = "";
         AV45TFTipoClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV39ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV50GridAppliedFilters = "";
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV44TFTipoClienteTipoPessoa_SelsJson = "";
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
         AV58Display = "";
         AV59Update = "";
         A193TipoClienteDescricao = "";
         A194TipoClienteTipoPessoa = "";
         A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV63Tipoclientewwds_1_filterfulltext = "";
         lV66Tipoclientewwds_4_tipoclientedescricao1 = "";
         lV70Tipoclientewwds_8_tipoclientedescricao2 = "";
         lV74Tipoclientewwds_12_tipoclientedescricao3 = "";
         lV75Tipoclientewwds_13_tftipoclientedescricao = "";
         AV63Tipoclientewwds_1_filterfulltext = "";
         AV64Tipoclientewwds_2_dynamicfiltersselector1 = "";
         AV66Tipoclientewwds_4_tipoclientedescricao1 = "";
         AV68Tipoclientewwds_6_dynamicfiltersselector2 = "";
         AV70Tipoclientewwds_8_tipoclientedescricao2 = "";
         AV72Tipoclientewwds_10_dynamicfiltersselector3 = "";
         AV74Tipoclientewwds_12_tipoclientedescricao3 = "";
         AV76Tipoclientewwds_14_tftipoclientedescricao_sel = "";
         AV75Tipoclientewwds_13_tftipoclientedescricao = "";
         H003Q2_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         H003Q2_n196TipoClienteUpdateAt = new bool[] {false} ;
         H003Q2_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H003Q2_n195TipoClienteCreatedAt = new bool[] {false} ;
         H003Q2_A207TipoClientePortal = new bool[] {false} ;
         H003Q2_n207TipoClientePortal = new bool[] {false} ;
         H003Q2_A194TipoClienteTipoPessoa = new string[] {""} ;
         H003Q2_n194TipoClienteTipoPessoa = new bool[] {false} ;
         H003Q2_A193TipoClienteDescricao = new string[] {""} ;
         H003Q2_n193TipoClienteDescricao = new bool[] {false} ;
         H003Q2_A192TipoClienteId = new short[1] ;
         H003Q3_AGRID_nRecordCount = new long[1] ;
         AV9HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV40ManageFiltersXml = "";
         AV32ExcelFilename = "";
         AV33ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         AV14GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV57AuxText = "";
         AV10TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoclienteww__default(),
            new Object[][] {
                new Object[] {
               H003Q2_A196TipoClienteUpdateAt, H003Q2_n196TipoClienteUpdateAt, H003Q2_A195TipoClienteCreatedAt, H003Q2_n195TipoClienteCreatedAt, H003Q2_A207TipoClientePortal, H003Q2_n207TipoClientePortal, H003Q2_A194TipoClienteTipoPessoa, H003Q2_n194TipoClienteTipoPessoa, H003Q2_A193TipoClienteDescricao, H003Q2_n193TipoClienteDescricao,
               H003Q2_A192TipoClienteId
               }
               , new Object[] {
               H003Q3_AGRID_nRecordCount
               }
            }
         );
         AV62Pgmname = "TipoClienteWW";
         /* GeneXus formulas. */
         AV62Pgmname = "TipoClienteWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15OrderedBy ;
      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV41ManageFiltersExecutionStep ;
      private short AV61TFTipoClientePortal_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A192TipoClienteId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV65Tipoclientewwds_3_dynamicfiltersoperator1 ;
      private short AV69Tipoclientewwds_7_dynamicfiltersoperator2 ;
      private short AV73Tipoclientewwds_11_dynamicfiltersoperator3 ;
      private short AV78Tipoclientewwds_16_tftipoclienteportal_sel ;
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
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ;
      private int edtTipoClienteId_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int edtTipoClienteCreatedAt_Enabled ;
      private int edtTipoClienteUpdateAt_Enabled ;
      private int AV47PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTipoclientedescricao1_Visible ;
      private int edtavTipoclientedescricao2_Visible ;
      private int edtavTipoclientedescricao3_Visible ;
      private int AV79GXV1 ;
      private int edtavTipoclientedescricao3_Enabled ;
      private int edtavTipoclientedescricao2_Enabled ;
      private int edtavTipoclientedescricao1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
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
      private string AV62Pgmname ;
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
      private string AV58Display ;
      private string edtavDisplay_Internalname ;
      private string AV59Update ;
      private string edtavUpdate_Internalname ;
      private string edtTipoClienteId_Internalname ;
      private string edtTipoClienteDescricao_Internalname ;
      private string cmbTipoClienteTipoPessoa_Internalname ;
      private string cmbTipoClientePortal_Internalname ;
      private string edtTipoClienteCreatedAt_Internalname ;
      private string edtTipoClienteUpdateAt_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTipoclientedescricao1_Internalname ;
      private string edtavTipoclientedescricao2_Internalname ;
      private string edtavTipoclientedescricao3_Internalname ;
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
      private string edtTipoClienteDescricao_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_tipoclientedescricao3_cell_Internalname ;
      private string edtavTipoclientedescricao3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_tipoclientedescricao2_cell_Internalname ;
      private string edtavTipoclientedescricao2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_tipoclientedescricao1_cell_Internalname ;
      private string edtavTipoclientedescricao1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_109_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtTipoClienteId_Jsonclick ;
      private string edtTipoClienteDescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbTipoClienteTipoPessoa_Jsonclick ;
      private string cmbTipoClientePortal_Jsonclick ;
      private string edtTipoClienteCreatedAt_Jsonclick ;
      private string edtTipoClienteUpdateAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A195TipoClienteCreatedAt ;
      private DateTime A196TipoClienteUpdateAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
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
      private bool n193TipoClienteDescricao ;
      private bool n194TipoClienteTipoPessoa ;
      private bool A207TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private bool n195TipoClienteCreatedAt ;
      private bool n196TipoClienteUpdateAt ;
      private bool bGXsfl_109_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV67Tipoclientewwds_5_dynamicfiltersenabled2 ;
      private bool AV71Tipoclientewwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV44TFTipoClienteTipoPessoa_SelsJson ;
      private string AV40ManageFiltersXml ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21TipoClienteDescricao1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25TipoClienteDescricao2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29TipoClienteDescricao3 ;
      private string AV42TFTipoClienteDescricao ;
      private string AV43TFTipoClienteDescricao_Sel ;
      private string AV50GridAppliedFilters ;
      private string A193TipoClienteDescricao ;
      private string A194TipoClienteTipoPessoa ;
      private string lV63Tipoclientewwds_1_filterfulltext ;
      private string lV66Tipoclientewwds_4_tipoclientedescricao1 ;
      private string lV70Tipoclientewwds_8_tipoclientedescricao2 ;
      private string lV74Tipoclientewwds_12_tipoclientedescricao3 ;
      private string lV75Tipoclientewwds_13_tftipoclientedescricao ;
      private string AV63Tipoclientewwds_1_filterfulltext ;
      private string AV64Tipoclientewwds_2_dynamicfiltersselector1 ;
      private string AV66Tipoclientewwds_4_tipoclientedescricao1 ;
      private string AV68Tipoclientewwds_6_dynamicfiltersselector2 ;
      private string AV70Tipoclientewwds_8_tipoclientedescricao2 ;
      private string AV72Tipoclientewwds_10_dynamicfiltersselector3 ;
      private string AV74Tipoclientewwds_12_tipoclientedescricao3 ;
      private string AV76Tipoclientewwds_14_tftipoclientedescricao_sel ;
      private string AV75Tipoclientewwds_13_tftipoclientedescricao ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV57AuxText ;
      private IGxSession AV38Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV9HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbTipoClienteTipoPessoa ;
      private GXCombobox cmbTipoClientePortal ;
      private GxSimpleCollection<string> AV45TFTipoClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV39ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H003Q2_A196TipoClienteUpdateAt ;
      private bool[] H003Q2_n196TipoClienteUpdateAt ;
      private DateTime[] H003Q2_A195TipoClienteCreatedAt ;
      private bool[] H003Q2_n195TipoClienteCreatedAt ;
      private bool[] H003Q2_A207TipoClientePortal ;
      private bool[] H003Q2_n207TipoClientePortal ;
      private string[] H003Q2_A194TipoClienteTipoPessoa ;
      private bool[] H003Q2_n194TipoClienteTipoPessoa ;
      private string[] H003Q2_A193TipoClienteDescricao ;
      private bool[] H003Q2_n193TipoClienteDescricao ;
      private short[] H003Q2_A192TipoClienteId ;
      private long[] H003Q3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV14GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV10TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tipoclienteww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003Q2( IGxContext context ,
                                             string A194TipoClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                             string AV63Tipoclientewwds_1_filterfulltext ,
                                             string AV64Tipoclientewwds_2_dynamicfiltersselector1 ,
                                             short AV65Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV66Tipoclientewwds_4_tipoclientedescricao1 ,
                                             bool AV67Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                             string AV68Tipoclientewwds_6_dynamicfiltersselector2 ,
                                             short AV69Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                             string AV70Tipoclientewwds_8_tipoclientedescricao2 ,
                                             bool AV71Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                             string AV72Tipoclientewwds_10_dynamicfiltersselector3 ,
                                             short AV73Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                             string AV74Tipoclientewwds_12_tipoclientedescricao3 ,
                                             string AV76Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                             string AV75Tipoclientewwds_13_tftipoclientedescricao ,
                                             int AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ,
                                             short AV78Tipoclientewwds_16_tftipoclienteportal_sel ,
                                             string A193TipoClienteDescricao ,
                                             bool A207TipoClientePortal ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " TipoClienteUpdateAt, TipoClienteCreatedAt, TipoClientePortal, TipoClienteTipoPessoa, TipoClienteDescricao, TipoClienteId";
         sFromString = " FROM TipoCliente";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TipoClienteDescricao like '%' || :lV63Tipoclientewwds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'JURIDICA')) or ( 'sim' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClientePortal = TRUE) or ( 'não' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClientePortal = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV65Tipoclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV66Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV65Tipoclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV66Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV67Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV69Tipoclientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV70Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV67Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV69Tipoclientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV70Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV71Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV73Tipoclientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV74Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV71Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV73Tipoclientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV74Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Tipoclientewwds_14_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Tipoclientewwds_13_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV75Tipoclientewwds_13_tftipoclientedescricao)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Tipoclientewwds_14_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV76Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao = ( :AV76Tipoclientewwds_14_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV76Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from TipoClienteDescricao))=0))");
         }
         if ( AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels, "TipoClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV78Tipoclientewwds_16_tftipoclienteportal_sel == 1 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = TRUE)");
         }
         if ( AV78Tipoclientewwds_16_tftipoclienteportal_sel == 2 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = FALSE)");
         }
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY TipoClienteDescricao, TipoClienteId";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY TipoClienteDescricao DESC, TipoClienteId";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY TipoClienteTipoPessoa, TipoClienteId";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY TipoClienteTipoPessoa DESC, TipoClienteId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY TipoClientePortal, TipoClienteId";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY TipoClientePortal DESC, TipoClienteId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY TipoClienteId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H003Q3( IGxContext context ,
                                             string A194TipoClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels ,
                                             string AV63Tipoclientewwds_1_filterfulltext ,
                                             string AV64Tipoclientewwds_2_dynamicfiltersselector1 ,
                                             short AV65Tipoclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV66Tipoclientewwds_4_tipoclientedescricao1 ,
                                             bool AV67Tipoclientewwds_5_dynamicfiltersenabled2 ,
                                             string AV68Tipoclientewwds_6_dynamicfiltersselector2 ,
                                             short AV69Tipoclientewwds_7_dynamicfiltersoperator2 ,
                                             string AV70Tipoclientewwds_8_tipoclientedescricao2 ,
                                             bool AV71Tipoclientewwds_9_dynamicfiltersenabled3 ,
                                             string AV72Tipoclientewwds_10_dynamicfiltersselector3 ,
                                             short AV73Tipoclientewwds_11_dynamicfiltersoperator3 ,
                                             string AV74Tipoclientewwds_12_tipoclientedescricao3 ,
                                             string AV76Tipoclientewwds_14_tftipoclientedescricao_sel ,
                                             string AV75Tipoclientewwds_13_tftipoclientedescricao ,
                                             int AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count ,
                                             short AV78Tipoclientewwds_16_tftipoclienteportal_sel ,
                                             string A193TipoClienteDescricao ,
                                             bool A207TipoClientePortal ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[13];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM TipoCliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Tipoclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TipoClienteDescricao like '%' || :lV63Tipoclientewwds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClienteTipoPessoa = ( 'JURIDICA')) or ( 'sim' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClientePortal = TRUE) or ( 'não' like '%' || LOWER(:lV63Tipoclientewwds_1_filterfulltext) and TipoClientePortal = FALSE))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV65Tipoclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV66Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Tipoclientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV65Tipoclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Tipoclientewwds_4_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV66Tipoclientewwds_4_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV67Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV69Tipoclientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV70Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV67Tipoclientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Tipoclientewwds_6_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV69Tipoclientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Tipoclientewwds_8_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV70Tipoclientewwds_8_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV71Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV73Tipoclientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV74Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV71Tipoclientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Tipoclientewwds_10_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV73Tipoclientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Tipoclientewwds_12_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like '%' || :lV74Tipoclientewwds_12_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Tipoclientewwds_14_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Tipoclientewwds_13_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao like :lV75Tipoclientewwds_13_tftipoclientedescricao)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Tipoclientewwds_14_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV76Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao = ( :AV76Tipoclientewwds_14_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV76Tipoclientewwds_14_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from TipoClienteDescricao))=0))");
         }
         if ( AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV77Tipoclientewwds_15_tftipoclientetipopessoa_sels, "TipoClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV78Tipoclientewwds_16_tftipoclienteportal_sel == 1 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = TRUE)");
         }
         if ( AV78Tipoclientewwds_16_tftipoclienteportal_sel == 2 )
         {
            AddWhere(sWhereString, "(TipoClientePortal = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV15OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
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
                     return conditional_H003Q2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
               case 1 :
                     return conditional_H003Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (bool)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] );
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
          Object[] prmH003Q2;
          prmH003Q2 = new Object[] {
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV66Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV70Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV70Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV74Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV74Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV75Tipoclientewwds_13_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV76Tipoclientewwds_14_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003Q3;
          prmH003Q3 = new Object[] {
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Tipoclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV66Tipoclientewwds_4_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV70Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV70Tipoclientewwds_8_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV74Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV74Tipoclientewwds_12_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV75Tipoclientewwds_13_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV76Tipoclientewwds_14_tftipoclientedescricao_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
