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
   public class layoutcontratoww : GXDataArea
   {
      public layoutcontratoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontratoww( IGxContext context )
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
         cmbLayoutContratoStatus = new GXCombobox();
         cmbLayoutContratoTipo = new GXCombobox();
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
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
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
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20LayoutContratoDescricao1 = GetPar( "LayoutContratoDescricao1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24LayoutContratoDescricao2 = GetPar( "LayoutContratoDescricao2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28LayoutContratoDescricao3 = GetPar( "LayoutContratoDescricao3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV69Pgmname = GetPar( "Pgmname");
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV43TFLayoutContratoDescricao = GetPar( "TFLayoutContratoDescricao");
         AV44TFLayoutContratoDescricao_Sel = GetPar( "TFLayoutContratoDescricao_Sel");
         AV45TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFLayoutContratoStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV65TFLayoutContratoTipo_Sels);
         AV67TFLayoutContratoTag = GetPar( "TFLayoutContratoTag");
         AV68TFLayoutContratoTag_Sel = GetPar( "TFLayoutContratoTag_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
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
         PA3E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("layoutcontratoww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLAYOUTCONTRATODESCRICAO1", AV20LayoutContratoDescricao1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLAYOUTCONTRATODESCRICAO2", AV24LayoutContratoDescricao2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vLAYOUTCONTRATODESCRICAO3", AV28LayoutContratoDescricao3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV54GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV55GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV56GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV46DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATODESCRICAO", AV43TFLayoutContratoDescricao);
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATODESCRICAO_SEL", AV44TFLayoutContratoDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATOSTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFLAYOUTCONTRATOTIPO_SELS", AV65TFLayoutContratoTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFLAYOUTCONTRATOTIPO_SELS", AV65TFLayoutContratoTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATOTAG", AV67TFLayoutContratoTag);
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATOTAG_SEL", AV68TFLayoutContratoTag_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTFLAYOUTCONTRATOTIPO_SELSJSON", AV64TFLayoutContratoTipo_SelsJson);
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
            WE3E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3E2( ) ;
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
         return formatLink("layoutcontratoww")  ;
      }

      public override string GetPgmname( )
      {
         return "LayoutContratoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Modelos de contratos" ;
      }

      protected void WB3E0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(107), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_LayoutContratoWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_LayoutContratoWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_45_3E2( true) ;
         }
         else
         {
            wb_table1_45_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_45_3E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_3E2( true) ;
         }
         else
         {
            wb_table2_67_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_3E2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,85);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_89_3E2( true) ;
         }
         else
         {
            wb_table3_89_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_89_3E2e( bool wbgen )
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
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV54GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV55GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV56GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_LayoutContratoWW.htm");
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
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 107 )
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

      protected void START3E2( )
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
         Form.Meta.addItem("description", "Modelos de contratos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3E0( ) ;
      }

      protected void WS3E2( )
      {
         START3E2( ) ;
         EVT3E2( ) ;
      }

      protected void EVT3E2( )
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
                              E113E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E123E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E133E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E143E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E153E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E163E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E173E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E183E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E193E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E203E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E213E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E223E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E233E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243E2 ();
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
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1072( ) ;
                              AV61Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV61Display);
                              AV62Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV62Update);
                              A154LayoutContratoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLayoutContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A155LayoutContratoDescricao = cgiGet( edtLayoutContratoDescricao_Internalname);
                              n155LayoutContratoDescricao = false;
                              cmbLayoutContratoStatus.Name = cmbLayoutContratoStatus_Internalname;
                              cmbLayoutContratoStatus.CurrentValue = cgiGet( cmbLayoutContratoStatus_Internalname);
                              A156LayoutContratoStatus = StringUtil.StrToBool( cgiGet( cmbLayoutContratoStatus_Internalname));
                              n156LayoutContratoStatus = false;
                              cmbLayoutContratoTipo.Name = cmbLayoutContratoTipo_Internalname;
                              cmbLayoutContratoTipo.CurrentValue = cgiGet( cmbLayoutContratoTipo_Internalname);
                              A906LayoutContratoTipo = cgiGet( cmbLayoutContratoTipo_Internalname);
                              n906LayoutContratoTipo = false;
                              A1000LayoutContratoTag = cgiGet( edtLayoutContratoTag_Internalname);
                              n1000LayoutContratoTag = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E253E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E263E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E273E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Layoutcontratodescricao1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO1"), AV20LayoutContratoDescricao1) != 0 )
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
                                       /* Set Refresh If Layoutcontratodescricao2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO2"), AV24LayoutContratoDescricao2) != 0 )
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
                                       /* Set Refresh If Layoutcontratodescricao3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO3"), AV28LayoutContratoDescricao3) != 0 )
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

      protected void WE3E2( )
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

      protected void PA3E2( )
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
         SubsflControlProps_1072( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1072( ) ;
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20LayoutContratoDescricao1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24LayoutContratoDescricao2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28LayoutContratoDescricao3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       string AV69Pgmname ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV43TFLayoutContratoDescricao ,
                                       string AV44TFLayoutContratoDescricao_Sel ,
                                       short AV45TFLayoutContratoStatus_Sel ,
                                       GxSimpleCollection<string> AV65TFLayoutContratoTipo_Sels ,
                                       string AV67TFLayoutContratoTag ,
                                       string AV68TFLayoutContratoTag_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_LAYOUTCONTRATOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LAYOUTCONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ".", "")));
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
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "LayoutContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      protected void RF3E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 107;
         /* Execute user event: Refresh */
         E263E2 ();
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         bGXsfl_107_Refreshing = true;
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
            SubsflControlProps_1072( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A906LayoutContratoTipo ,
                                                 AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                                 AV70Layoutcontratowwds_1_filterfulltext ,
                                                 AV71Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                                 AV72Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                                 AV73Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                                 AV74Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                                 AV75Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                                 AV76Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                                 AV77Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                                 AV78Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                                 AV79Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                                 AV80Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                                 AV81Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                                 AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                                 AV82Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                                 AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                                 AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                                 AV87Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                                 AV86Layoutcontratowwds_17_tflayoutcontratotag ,
                                                 A155LayoutContratoDescricao ,
                                                 A156LayoutContratoStatus ,
                                                 A1000LayoutContratoTag ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
            lV73Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
            lV73Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
            lV77Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
            lV77Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
            lV81Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
            lV81Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
            lV82Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV82Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
            lV86Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV86Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
            /* Using cursor H003E2 */
            pr_default.execute(0, new Object[] {lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV73Layoutcontratowwds_4_layoutcontratodescricao1, lV73Layoutcontratowwds_4_layoutcontratodescricao1, lV77Layoutcontratowwds_8_layoutcontratodescricao2, lV77Layoutcontratowwds_8_layoutcontratodescricao2, lV81Layoutcontratowwds_12_layoutcontratodescricao3, lV81Layoutcontratowwds_12_layoutcontratodescricao3, lV82Layoutcontratowwds_13_tflayoutcontratodescricao, AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV86Layoutcontratowwds_17_tflayoutcontratotag, AV87Layoutcontratowwds_18_tflayoutcontratotag_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_107_idx = 1;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A1000LayoutContratoTag = H003E2_A1000LayoutContratoTag[0];
               n1000LayoutContratoTag = H003E2_n1000LayoutContratoTag[0];
               A906LayoutContratoTipo = H003E2_A906LayoutContratoTipo[0];
               n906LayoutContratoTipo = H003E2_n906LayoutContratoTipo[0];
               A156LayoutContratoStatus = H003E2_A156LayoutContratoStatus[0];
               n156LayoutContratoStatus = H003E2_n156LayoutContratoStatus[0];
               A155LayoutContratoDescricao = H003E2_A155LayoutContratoDescricao[0];
               n155LayoutContratoDescricao = H003E2_n155LayoutContratoDescricao[0];
               A154LayoutContratoId = H003E2_A154LayoutContratoId[0];
               /* Execute user event: Grid.Load */
               E273E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 107;
            WB3E0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_LAYOUTCONTRATOID"+"_"+sGXsfl_107_idx, GetSecureSignedToken( sGXsfl_107_idx, context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9"), context));
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
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A906LayoutContratoTipo ,
                                              AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                              AV70Layoutcontratowwds_1_filterfulltext ,
                                              AV71Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                              AV72Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                              AV73Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                              AV74Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                              AV75Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                              AV76Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                              AV77Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                              AV78Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                              AV79Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                              AV80Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                              AV81Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                              AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                              AV82Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                              AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                              AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels.Count ,
                                              AV87Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                              AV86Layoutcontratowwds_17_tflayoutcontratotag ,
                                              A155LayoutContratoDescricao ,
                                              A156LayoutContratoStatus ,
                                              A1000LayoutContratoTag ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV70Layoutcontratowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext), "%", "");
         lV73Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV73Layoutcontratowwds_4_layoutcontratodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1), "%", "");
         lV77Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV77Layoutcontratowwds_8_layoutcontratodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2), "%", "");
         lV81Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV81Layoutcontratowwds_12_layoutcontratodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3), "%", "");
         lV82Layoutcontratowwds_13_tflayoutcontratodescricao = StringUtil.Concat( StringUtil.RTrim( AV82Layoutcontratowwds_13_tflayoutcontratodescricao), "%", "");
         lV86Layoutcontratowwds_17_tflayoutcontratotag = StringUtil.Concat( StringUtil.RTrim( AV86Layoutcontratowwds_17_tflayoutcontratotag), "%", "");
         /* Using cursor H003E3 */
         pr_default.execute(1, new Object[] {lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV70Layoutcontratowwds_1_filterfulltext, lV73Layoutcontratowwds_4_layoutcontratodescricao1, lV73Layoutcontratowwds_4_layoutcontratodescricao1, lV77Layoutcontratowwds_8_layoutcontratodescricao2, lV77Layoutcontratowwds_8_layoutcontratodescricao2, lV81Layoutcontratowwds_12_layoutcontratodescricao3, lV81Layoutcontratowwds_12_layoutcontratodescricao3, lV82Layoutcontratowwds_13_tflayoutcontratodescricao, AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, lV86Layoutcontratowwds_17_tflayoutcontratotag, AV87Layoutcontratowwds_18_tflayoutcontratotag_sel});
         GRID_nRecordCount = H003E3_AGRID_nRecordCount[0];
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
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "LayoutContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtLayoutContratoId_Enabled = 0;
         edtLayoutContratoDescricao_Enabled = 0;
         cmbLayoutContratoStatus.Enabled = 0;
         cmbLayoutContratoTipo.Enabled = 0;
         edtLayoutContratoTag_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E253E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), ",", "."), 18, MidpointRounding.ToEven));
            AV54GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV55GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV20LayoutContratoDescricao1 = cgiGet( edtavLayoutcontratodescricao1_Internalname);
            AssignAttri("", false, "AV20LayoutContratoDescricao1", AV20LayoutContratoDescricao1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24LayoutContratoDescricao2 = cgiGet( edtavLayoutcontratodescricao2_Internalname);
            AssignAttri("", false, "AV24LayoutContratoDescricao2", AV24LayoutContratoDescricao2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28LayoutContratoDescricao3 = cgiGet( edtavLayoutcontratodescricao3_Internalname);
            AssignAttri("", false, "AV28LayoutContratoDescricao3", AV28LayoutContratoDescricao3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO1"), AV20LayoutContratoDescricao1) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO2"), AV24LayoutContratoDescricao2) != 0 )
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vLAYOUTCONTRATODESCRICAO3"), AV28LayoutContratoDescricao3) != 0 )
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
         E253E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E253E2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
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
         AV18DynamicFiltersSelector1 = "LAYOUTCONTRATODESCRICAO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "LAYOUTCONTRATODESCRICAO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "LAYOUTCONTRATODESCRICAO";
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
         Form.Caption = "Modelos de contratos";
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
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
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

      protected void E263E2( )
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
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV54GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV54GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV54GridCurrentPage), 10, 0));
         AV55GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV55GridPageCount", StringUtil.LTrimStr( (decimal)(AV55GridPageCount), 10, 0));
         GXt_char2 = AV56GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char2) ;
         AV56GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV56GridAppliedFilters", AV56GridAppliedFilters);
         AV70Layoutcontratowwds_1_filterfulltext = AV17FilterFullText;
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV72Layoutcontratowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = AV20LayoutContratoDescricao1;
         AV74Layoutcontratowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Layoutcontratowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = AV24LayoutContratoDescricao2;
         AV78Layoutcontratowwds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV80Layoutcontratowwds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = AV28LayoutContratoDescricao3;
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = AV43TFLayoutContratoDescricao;
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = AV44TFLayoutContratoDescricao_Sel;
         AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel = AV45TFLayoutContratoStatus_Sel;
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = AV65TFLayoutContratoTipo_Sels;
         AV86Layoutcontratowwds_17_tflayoutcontratotag = AV67TFLayoutContratoTag;
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = AV68TFLayoutContratoTag_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123E2( )
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
            AV53PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV53PageToGo) ;
         }
      }

      protected void E133E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E143E2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LayoutContratoDescricao") == 0 )
            {
               AV43TFLayoutContratoDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFLayoutContratoDescricao", AV43TFLayoutContratoDescricao);
               AV44TFLayoutContratoDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFLayoutContratoDescricao_Sel", AV44TFLayoutContratoDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LayoutContratoStatus") == 0 )
            {
               AV45TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFLayoutContratoStatus_Sel", StringUtil.Str( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LayoutContratoTipo") == 0 )
            {
               AV64TFLayoutContratoTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV64TFLayoutContratoTipo_SelsJson", AV64TFLayoutContratoTipo_SelsJson);
               AV65TFLayoutContratoTipo_Sels.FromJSonString(AV64TFLayoutContratoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "LayoutContratoTag") == 0 )
            {
               AV67TFLayoutContratoTag = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFLayoutContratoTag", AV67TFLayoutContratoTag);
               AV68TFLayoutContratoTag_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFLayoutContratoTag_Sel", AV68TFLayoutContratoTag_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65TFLayoutContratoTipo_Sels", AV65TFLayoutContratoTipo_Sels);
      }

      private void E273E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV61Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV61Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpmodelocontrato"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A154LayoutContratoId,4,0));
         edtavDisplay_Link = formatLink("wpmodelocontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV62Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV62Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpmodelocontrato"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A154LayoutContratoId,4,0));
         edtavUpdate_Link = formatLink("wpmodelocontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "layoutcontrato"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A154LayoutContratoId,4,0));
         edtLayoutContratoDescricao_Link = formatLink("layoutcontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 107;
         }
         sendrow_1072( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
         {
            DoAjaxLoad(107, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E203E2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E153E2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E213E2( )
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

      protected void E223E2( )
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

      protected void E163E2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E233E2( )
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

      protected void E173E2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20LayoutContratoDescricao1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24LayoutContratoDescricao2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28LayoutContratoDescricao3, AV40ManageFiltersExecutionStep, AV69Pgmname, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV43TFLayoutContratoDescricao, AV44TFLayoutContratoDescricao_Sel, AV45TFLayoutContratoStatus_Sel, AV65TFLayoutContratoTipo_Sels, AV67TFLayoutContratoTag, AV68TFLayoutContratoTag_Sel, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E243E2( )
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

      protected void E113E2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("LayoutContratoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("LayoutContratoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "LayoutContratoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65TFLayoutContratoTipo_Sels", AV65TFLayoutContratoTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E183E2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wpmodelocontrato"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wpmodelocontrato") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E193E2( )
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
         new layoutcontratowwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV65TFLayoutContratoTipo_Sels", AV65TFLayoutContratoTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavLayoutcontratodescricao1_Visible = 0;
         AssignProp("", false, edtavLayoutcontratodescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 )
         {
            edtavLayoutcontratodescricao1_Visible = 1;
            AssignProp("", false, edtavLayoutcontratodescricao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavLayoutcontratodescricao2_Visible = 0;
         AssignProp("", false, edtavLayoutcontratodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 )
         {
            edtavLayoutcontratodescricao2_Visible = 1;
            AssignProp("", false, edtavLayoutcontratodescricao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavLayoutcontratodescricao3_Visible = 0;
         AssignProp("", false, edtavLayoutcontratodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 )
         {
            edtavLayoutcontratodescricao3_Visible = 1;
            AssignProp("", false, edtavLayoutcontratodescricao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavLayoutcontratodescricao3_Visible), 5, 0), true);
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
         AV22DynamicFiltersSelector2 = "LAYOUTCONTRATODESCRICAO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24LayoutContratoDescricao2 = "";
         AssignAttri("", false, "AV24LayoutContratoDescricao2", AV24LayoutContratoDescricao2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "LAYOUTCONTRATODESCRICAO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28LayoutContratoDescricao3 = "";
         AssignAttri("", false, "AV28LayoutContratoDescricao3", AV28LayoutContratoDescricao3);
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "LayoutContratoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV43TFLayoutContratoDescricao = "";
         AssignAttri("", false, "AV43TFLayoutContratoDescricao", AV43TFLayoutContratoDescricao);
         AV44TFLayoutContratoDescricao_Sel = "";
         AssignAttri("", false, "AV44TFLayoutContratoDescricao_Sel", AV44TFLayoutContratoDescricao_Sel);
         AV45TFLayoutContratoStatus_Sel = 0;
         AssignAttri("", false, "AV45TFLayoutContratoStatus_Sel", StringUtil.Str( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0));
         AV65TFLayoutContratoTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV67TFLayoutContratoTag = "";
         AssignAttri("", false, "AV67TFLayoutContratoTag", AV67TFLayoutContratoTag);
         AV68TFLayoutContratoTag_Sel = "";
         AssignAttri("", false, "AV68TFLayoutContratoTag_Sel", AV68TFLayoutContratoTag_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV18DynamicFiltersSelector1 = "LAYOUTCONTRATODESCRICAO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20LayoutContratoDescricao1 = "";
         AssignAttri("", false, "AV20LayoutContratoDescricao1", AV20LayoutContratoDescricao1);
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
         AV11GridState.gxTpr_Dynamicfilters.Clear();
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
         if ( StringUtil.StrCmp(AV37Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S232( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV88GXV1 = 1;
         while ( AV88GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV88GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV43TFLayoutContratoDescricao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFLayoutContratoDescricao", AV43TFLayoutContratoDescricao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATODESCRICAO_SEL") == 0 )
            {
               AV44TFLayoutContratoDescricao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFLayoutContratoDescricao_Sel", AV44TFLayoutContratoDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOSTATUS_SEL") == 0 )
            {
               AV45TFLayoutContratoStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFLayoutContratoStatus_Sel", StringUtil.Str( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTIPO_SEL") == 0 )
            {
               AV64TFLayoutContratoTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFLayoutContratoTipo_SelsJson", AV64TFLayoutContratoTipo_SelsJson);
               AV65TFLayoutContratoTipo_Sels.FromJSonString(AV64TFLayoutContratoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG") == 0 )
            {
               AV67TFLayoutContratoTag = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFLayoutContratoTag", AV67TFLayoutContratoTag);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFLAYOUTCONTRATOTAG_SEL") == 0 )
            {
               AV68TFLayoutContratoTag_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFLayoutContratoTag_Sel", AV68TFLayoutContratoTag_Sel);
            }
            AV88GXV1 = (int)(AV88GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLayoutContratoDescricao_Sel)),  AV44TFLayoutContratoDescricao_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV65TFLayoutContratoTipo_Sels.Count==0),  AV64TFLayoutContratoTipo_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFLayoutContratoTag_Sel)),  AV68TFLayoutContratoTag_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+((0==AV45TFLayoutContratoStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0))+"|"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLayoutContratoDescricao)),  AV43TFLayoutContratoDescricao, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFLayoutContratoTag)),  AV67TFLayoutContratoTag, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|||"+GXt_char4;
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
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20LayoutContratoDescricao1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20LayoutContratoDescricao1", AV20LayoutContratoDescricao1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
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
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24LayoutContratoDescricao2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24LayoutContratoDescricao2", AV24LayoutContratoDescricao2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28LayoutContratoDescricao3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28LayoutContratoDescricao3", AV28LayoutContratoDescricao3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  AV17FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLAYOUTCONTRATODESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFLayoutContratoDescricao)),  0,  AV43TFLayoutContratoDescricao,  AV43TFLayoutContratoDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFLayoutContratoDescricao_Sel)),  AV44TFLayoutContratoDescricao_Sel,  AV44TFLayoutContratoDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLAYOUTCONTRATOSTATUS_SEL",  "Ativo",  !(0==AV45TFLayoutContratoStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFLayoutContratoStatus_Sel), 1, 0)),  ((AV45TFLayoutContratoStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         AV66AuxText = ((AV65TFLayoutContratoTipo_Sels.Count==1) ? "["+((string)AV65TFLayoutContratoTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFLAYOUTCONTRATOTIPO_SEL",  "Tipo",  !(AV65TFLayoutContratoTipo_Sels.Count==0),  0,  AV65TFLayoutContratoTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV66AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV66AuxText, "[C]", "Contrato"), "[M]", "Mensagem"), "[A]", "Acoplado")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFLAYOUTCONTRATOTAG",  "Tag",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFLayoutContratoTag)),  0,  AV67TFLayoutContratoTag,  AV67TFLayoutContratoTag,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFLayoutContratoTag_Sel)),  AV68TFLayoutContratoTag_Sel,  AV68TFLayoutContratoTag_Sel) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20LayoutContratoDescricao1)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Descrição",  AV19DynamicFiltersOperator1,  AV20LayoutContratoDescricao1,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1+1), 10, 0)), "Começa com"+" "+AV20LayoutContratoDescricao1, "Contém"+" "+AV20LayoutContratoDescricao1, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24LayoutContratoDescricao2)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Descrição",  AV23DynamicFiltersOperator2,  AV24LayoutContratoDescricao2,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2+1), 10, 0)), "Começa com"+" "+AV24LayoutContratoDescricao2, "Contém"+" "+AV24LayoutContratoDescricao2, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28LayoutContratoDescricao3)) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Descrição",  AV27DynamicFiltersOperator3,  AV28LayoutContratoDescricao3,  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3+1), 10, 0)), "Começa com"+" "+AV28LayoutContratoDescricao3, "Contém"+" "+AV28LayoutContratoDescricao3, "", "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "LayoutContrato";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S242( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
      }

      protected void wb_table3_89_3E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_layoutcontratodescricao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLayoutcontratodescricao3_Internalname, "Layout Contrato Descricao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratodescricao3_Internalname, AV28LayoutContratoDescricao3, StringUtil.RTrim( context.localUtil.Format( AV28LayoutContratoDescricao3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratodescricao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratodescricao3_Visible, edtavLayoutcontratodescricao3_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_LayoutContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_89_3E2e( true) ;
         }
         else
         {
            wb_table3_89_3E2e( false) ;
         }
      }

      protected void wb_table2_67_3E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_layoutcontratodescricao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLayoutcontratodescricao2_Internalname, "Layout Contrato Descricao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratodescricao2_Internalname, AV24LayoutContratoDescricao2, StringUtil.RTrim( context.localUtil.Format( AV24LayoutContratoDescricao2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratodescricao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratodescricao2_Visible, edtavLayoutcontratodescricao2_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_LayoutContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_LayoutContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_3E2e( true) ;
         }
         else
         {
            wb_table2_67_3E2e( false) ;
         }
      }

      protected void wb_table1_45_3E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_107_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_LayoutContratoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_layoutcontratodescricao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLayoutcontratodescricao1_Internalname, "Layout Contrato Descricao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_107_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLayoutcontratodescricao1_Internalname, AV20LayoutContratoDescricao1, StringUtil.RTrim( context.localUtil.Format( AV20LayoutContratoDescricao1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLayoutcontratodescricao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavLayoutcontratodescricao1_Visible, edtavLayoutcontratodescricao1_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LayoutContratoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_LayoutContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_LayoutContratoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_45_3E2e( true) ;
         }
         else
         {
            wb_table1_45_3E2e( false) ;
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
         PA3E2( ) ;
         WS3E2( ) ;
         WE3E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101924351", true, true);
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
         context.AddJavascriptSource("layoutcontratoww.js", "?20256101924352", false, true);
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

      protected void SubsflControlProps_1072( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_107_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_107_idx;
         edtLayoutContratoId_Internalname = "LAYOUTCONTRATOID_"+sGXsfl_107_idx;
         edtLayoutContratoDescricao_Internalname = "LAYOUTCONTRATODESCRICAO_"+sGXsfl_107_idx;
         cmbLayoutContratoStatus_Internalname = "LAYOUTCONTRATOSTATUS_"+sGXsfl_107_idx;
         cmbLayoutContratoTipo_Internalname = "LAYOUTCONTRATOTIPO_"+sGXsfl_107_idx;
         edtLayoutContratoTag_Internalname = "LAYOUTCONTRATOTAG_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1072( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_107_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_107_fel_idx;
         edtLayoutContratoId_Internalname = "LAYOUTCONTRATOID_"+sGXsfl_107_fel_idx;
         edtLayoutContratoDescricao_Internalname = "LAYOUTCONTRATODESCRICAO_"+sGXsfl_107_fel_idx;
         cmbLayoutContratoStatus_Internalname = "LAYOUTCONTRATOSTATUS_"+sGXsfl_107_fel_idx;
         cmbLayoutContratoTipo_Internalname = "LAYOUTCONTRATOTIPO_"+sGXsfl_107_fel_idx;
         edtLayoutContratoTag_Internalname = "LAYOUTCONTRATOTAG_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1072( )
      {
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1072( ) ;
         WB3E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_107_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV61Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_107_idx + "',107)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV62Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLayoutContratoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A154LayoutContratoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLayoutContratoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLayoutContratoDescricao_Internalname,(string)A155LayoutContratoDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtLayoutContratoDescricao_Link,(string)"",(string)"",(string)"",(string)edtLayoutContratoDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbLayoutContratoStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LAYOUTCONTRATOSTATUS_" + sGXsfl_107_idx;
               cmbLayoutContratoStatus.Name = GXCCtl;
               cmbLayoutContratoStatus.WebTags = "";
               cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbLayoutContratoStatus.ItemCount > 0 )
               {
                  A156LayoutContratoStatus = StringUtil.StrToBool( cmbLayoutContratoStatus.getValidValue(StringUtil.BoolToStr( A156LayoutContratoStatus)));
                  n156LayoutContratoStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLayoutContratoStatus,(string)cmbLayoutContratoStatus_Internalname,StringUtil.BoolToStr( A156LayoutContratoStatus),(short)1,(string)cmbLayoutContratoStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbLayoutContratoStatus.CurrentValue = StringUtil.BoolToStr( A156LayoutContratoStatus);
            AssignProp("", false, cmbLayoutContratoStatus_Internalname, "Values", (string)(cmbLayoutContratoStatus.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbLayoutContratoTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "LAYOUTCONTRATOTIPO_" + sGXsfl_107_idx;
               cmbLayoutContratoTipo.Name = GXCCtl;
               cmbLayoutContratoTipo.WebTags = "";
               cmbLayoutContratoTipo.addItem("C", "Contrato", 0);
               cmbLayoutContratoTipo.addItem("M", "Mensagem", 0);
               cmbLayoutContratoTipo.addItem("A", "Acoplado", 0);
               if ( cmbLayoutContratoTipo.ItemCount > 0 )
               {
                  A906LayoutContratoTipo = cmbLayoutContratoTipo.getValidValue(A906LayoutContratoTipo);
                  n906LayoutContratoTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbLayoutContratoTipo,(string)cmbLayoutContratoTipo_Internalname,StringUtil.RTrim( A906LayoutContratoTipo),(short)1,(string)cmbLayoutContratoTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbLayoutContratoTipo.CurrentValue = StringUtil.RTrim( A906LayoutContratoTipo);
            AssignProp("", false, cmbLayoutContratoTipo_Internalname, "Values", (string)(cmbLayoutContratoTipo.ToJavascriptSource()), !bGXsfl_107_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLayoutContratoTag_Internalname,(string)A1000LayoutContratoTag,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLayoutContratoTag_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_107_idx = ((subGrid_Islastpage==1)&&(nGXsfl_107_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1072( ) ;
         }
         /* End function sendrow_1072 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("LAYOUTCONTRATODESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("LAYOUTCONTRATODESCRICAO", "Descrição", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("LAYOUTCONTRATODESCRICAO", "Descrição", 0);
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
         GXCCtl = "LAYOUTCONTRATOSTATUS_" + sGXsfl_107_idx;
         cmbLayoutContratoStatus.Name = GXCCtl;
         cmbLayoutContratoStatus.WebTags = "";
         cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbLayoutContratoStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbLayoutContratoStatus.ItemCount > 0 )
         {
            A156LayoutContratoStatus = StringUtil.StrToBool( cmbLayoutContratoStatus.getValidValue(StringUtil.BoolToStr( A156LayoutContratoStatus)));
            n156LayoutContratoStatus = false;
         }
         GXCCtl = "LAYOUTCONTRATOTIPO_" + sGXsfl_107_idx;
         cmbLayoutContratoTipo.Name = GXCCtl;
         cmbLayoutContratoTipo.WebTags = "";
         cmbLayoutContratoTipo.addItem("C", "Contrato", 0);
         cmbLayoutContratoTipo.addItem("M", "Mensagem", 0);
         cmbLayoutContratoTipo.addItem("A", "Acoplado", 0);
         if ( cmbLayoutContratoTipo.ItemCount > 0 )
         {
            A906LayoutContratoTipo = cmbLayoutContratoTipo.getValidValue(A906LayoutContratoTipo);
            n906LayoutContratoTipo = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl107( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"107\">") ;
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
            context.SendWebValue( "Contrato Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ativo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tag") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV61Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV62Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154LayoutContratoId), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A155LayoutContratoDescricao));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtLayoutContratoDescricao_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A156LayoutContratoStatus)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A906LayoutContratoTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1000LayoutContratoTag));
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
         edtavLayoutcontratodescricao1_Internalname = "vLAYOUTCONTRATODESCRICAO1";
         cellFilter_layoutcontratodescricao1_cell_Internalname = "FILTER_LAYOUTCONTRATODESCRICAO1_CELL";
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
         edtavLayoutcontratodescricao2_Internalname = "vLAYOUTCONTRATODESCRICAO2";
         cellFilter_layoutcontratodescricao2_cell_Internalname = "FILTER_LAYOUTCONTRATODESCRICAO2_CELL";
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
         edtavLayoutcontratodescricao3_Internalname = "vLAYOUTCONTRATODESCRICAO3";
         cellFilter_layoutcontratodescricao3_cell_Internalname = "FILTER_LAYOUTCONTRATODESCRICAO3_CELL";
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
         edtLayoutContratoId_Internalname = "LAYOUTCONTRATOID";
         edtLayoutContratoDescricao_Internalname = "LAYOUTCONTRATODESCRICAO";
         cmbLayoutContratoStatus_Internalname = "LAYOUTCONTRATOSTATUS";
         cmbLayoutContratoTipo_Internalname = "LAYOUTCONTRATOTIPO";
         edtLayoutContratoTag_Internalname = "LAYOUTCONTRATOTAG";
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
         edtLayoutContratoTag_Jsonclick = "";
         cmbLayoutContratoTipo_Jsonclick = "";
         cmbLayoutContratoStatus_Jsonclick = "";
         edtLayoutContratoDescricao_Jsonclick = "";
         edtLayoutContratoDescricao_Link = "";
         edtLayoutContratoId_Jsonclick = "";
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
         edtavLayoutcontratodescricao1_Jsonclick = "";
         edtavLayoutcontratodescricao1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavLayoutcontratodescricao2_Jsonclick = "";
         edtavLayoutcontratodescricao2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavLayoutcontratodescricao3_Jsonclick = "";
         edtavLayoutcontratodescricao3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavLayoutcontratodescricao3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavLayoutcontratodescricao2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavLayoutcontratodescricao1_Visible = 1;
         edtLayoutContratoTag_Enabled = 0;
         cmbLayoutContratoTipo.Enabled = 0;
         cmbLayoutContratoStatus.Enabled = 0;
         edtLayoutContratoDescricao_Enabled = 0;
         edtLayoutContratoId_Enabled = 0;
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
         Grid_empowerer_Fixedcolumns = ";L;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "LayoutContratoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|1:WWP_TSChecked,2:WWP_TSUnChecked|C:Contrato,M:Mensagem,A:Acoplado|";
         Ddo_grid_Allowmultipleselection = "||T|";
         Ddo_grid_Datalisttype = "Dynamic|FixedValues|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|||Character";
         Ddo_grid_Includefilter = "T|||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "3:LayoutContratoDescricao|4:LayoutContratoStatus|5:LayoutContratoTipo|6:LayoutContratoTag";
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
         Form.Caption = "Modelos de contratos";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E123E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E133E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E143E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV64TFLayoutContratoTipo_SelsJson","fld":"vTFLAYOUTCONTRATOTIPO_SELSJSON","type":"vchar"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E273E2","iparms":[{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV61Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV62Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtLayoutContratoDescricao_Link","ctrl":"LAYOUTCONTRATODESCRICAO","prop":"Link"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E203E2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E153E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"},{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E213E2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E223E2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E163E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"},{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E233E2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E173E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"},{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E243E2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E113E2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV64TFLayoutContratoTipo_SelsJson","fld":"vTFLAYOUTCONTRATOTIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV64TFLayoutContratoTipo_SelsJson","fld":"vTFLAYOUTCONTRATOTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"},{"av":"AV54GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV55GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV56GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E183E2","iparms":[{"av":"A154LayoutContratoId","fld":"LAYOUTCONTRATOID","pic":"ZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E193E2","iparms":[{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV64TFLayoutContratoTipo_SelsJson","fld":"vTFLAYOUTCONTRATOTIPO_SELSJSON","type":"vchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV17FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV18DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV19DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV20LayoutContratoDescricao1","fld":"vLAYOUTCONTRATODESCRICAO1","type":"svchar"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV22DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV23DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV24LayoutContratoDescricao2","fld":"vLAYOUTCONTRATODESCRICAO2","type":"svchar"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV26DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV27DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV28LayoutContratoDescricao3","fld":"vLAYOUTCONTRATODESCRICAO3","type":"svchar"},{"av":"AV40ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV69Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV21DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV25DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV43TFLayoutContratoDescricao","fld":"vTFLAYOUTCONTRATODESCRICAO","type":"svchar"},{"av":"AV44TFLayoutContratoDescricao_Sel","fld":"vTFLAYOUTCONTRATODESCRICAO_SEL","type":"svchar"},{"av":"AV45TFLayoutContratoStatus_Sel","fld":"vTFLAYOUTCONTRATOSTATUS_SEL","pic":"9","type":"int"},{"av":"AV65TFLayoutContratoTipo_Sels","fld":"vTFLAYOUTCONTRATOTIPO_SELS","type":""},{"av":"AV67TFLayoutContratoTag","fld":"vTFLAYOUTCONTRATOTAG","type":"svchar"},{"av":"AV68TFLayoutContratoTag_Sel","fld":"vTFLAYOUTCONTRATOTAG_SEL","type":"svchar"},{"av":"AV30DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV29DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV64TFLayoutContratoTipo_SelsJson","fld":"vTFLAYOUTCONTRATOTIPO_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavLayoutcontratodescricao1_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO1","prop":"Visible"},{"av":"edtavLayoutcontratodescricao2_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO2","prop":"Visible"},{"av":"edtavLayoutcontratodescricao3_Visible","ctrl":"vLAYOUTCONTRATODESCRICAO3","prop":"Visible"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Layoutcontratotag","iparms":[]}""");
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
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20LayoutContratoDescricao1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24LayoutContratoDescricao2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28LayoutContratoDescricao3 = "";
         AV69Pgmname = "";
         AV43TFLayoutContratoDescricao = "";
         AV44TFLayoutContratoDescricao_Sel = "";
         AV65TFLayoutContratoTipo_Sels = new GxSimpleCollection<string>();
         AV67TFLayoutContratoTag = "";
         AV68TFLayoutContratoTag_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56GridAppliedFilters = "";
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV64TFLayoutContratoTipo_SelsJson = "";
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
         AV61Display = "";
         AV62Update = "";
         A155LayoutContratoDescricao = "";
         A906LayoutContratoTipo = "";
         A1000LayoutContratoTag = "";
         AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels = new GxSimpleCollection<string>();
         lV70Layoutcontratowwds_1_filterfulltext = "";
         lV73Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         lV77Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         lV81Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         lV82Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         lV86Layoutcontratowwds_17_tflayoutcontratotag = "";
         AV70Layoutcontratowwds_1_filterfulltext = "";
         AV71Layoutcontratowwds_2_dynamicfiltersselector1 = "";
         AV73Layoutcontratowwds_4_layoutcontratodescricao1 = "";
         AV75Layoutcontratowwds_6_dynamicfiltersselector2 = "";
         AV77Layoutcontratowwds_8_layoutcontratodescricao2 = "";
         AV79Layoutcontratowwds_10_dynamicfiltersselector3 = "";
         AV81Layoutcontratowwds_12_layoutcontratodescricao3 = "";
         AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel = "";
         AV82Layoutcontratowwds_13_tflayoutcontratodescricao = "";
         AV87Layoutcontratowwds_18_tflayoutcontratotag_sel = "";
         AV86Layoutcontratowwds_17_tflayoutcontratotag = "";
         H003E2_A1000LayoutContratoTag = new string[] {""} ;
         H003E2_n1000LayoutContratoTag = new bool[] {false} ;
         H003E2_A906LayoutContratoTipo = new string[] {""} ;
         H003E2_n906LayoutContratoTipo = new bool[] {false} ;
         H003E2_A156LayoutContratoStatus = new bool[] {false} ;
         H003E2_n156LayoutContratoStatus = new bool[] {false} ;
         H003E2_A155LayoutContratoDescricao = new string[] {""} ;
         H003E2_n155LayoutContratoDescricao = new bool[] {false} ;
         H003E2_A154LayoutContratoId = new short[1] ;
         H003E3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
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
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV66AuxText = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontratoww__default(),
            new Object[][] {
                new Object[] {
               H003E2_A1000LayoutContratoTag, H003E2_n1000LayoutContratoTag, H003E2_A906LayoutContratoTipo, H003E2_n906LayoutContratoTipo, H003E2_A156LayoutContratoStatus, H003E2_n156LayoutContratoStatus, H003E2_A155LayoutContratoDescricao, H003E2_n155LayoutContratoDescricao, H003E2_A154LayoutContratoId
               }
               , new Object[] {
               H003E3_AGRID_nRecordCount
               }
            }
         );
         AV69Pgmname = "LayoutContratoWW";
         /* GeneXus formulas. */
         AV69Pgmname = "LayoutContratoWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV45TFLayoutContratoStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A154LayoutContratoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV72Layoutcontratowwds_3_dynamicfiltersoperator1 ;
      private short AV76Layoutcontratowwds_7_dynamicfiltersoperator2 ;
      private short AV80Layoutcontratowwds_11_dynamicfiltersoperator3 ;
      private short AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_107 ;
      private int nGXsfl_107_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ;
      private int edtLayoutContratoId_Enabled ;
      private int edtLayoutContratoDescricao_Enabled ;
      private int edtLayoutContratoTag_Enabled ;
      private int AV53PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavLayoutcontratodescricao1_Visible ;
      private int edtavLayoutcontratodescricao2_Visible ;
      private int edtavLayoutcontratodescricao3_Visible ;
      private int AV88GXV1 ;
      private int edtavLayoutcontratodescricao3_Enabled ;
      private int edtavLayoutcontratodescricao2_Enabled ;
      private int edtavLayoutcontratodescricao1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV54GridCurrentPage ;
      private long AV55GridPageCount ;
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
      private string sGXsfl_107_idx="0001" ;
      private string AV69Pgmname ;
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
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV61Display ;
      private string edtavDisplay_Internalname ;
      private string AV62Update ;
      private string edtavUpdate_Internalname ;
      private string edtLayoutContratoId_Internalname ;
      private string edtLayoutContratoDescricao_Internalname ;
      private string cmbLayoutContratoStatus_Internalname ;
      private string cmbLayoutContratoTipo_Internalname ;
      private string edtLayoutContratoTag_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavLayoutcontratodescricao1_Internalname ;
      private string edtavLayoutcontratodescricao2_Internalname ;
      private string edtavLayoutcontratodescricao3_Internalname ;
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
      private string edtLayoutContratoDescricao_Link ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_layoutcontratodescricao3_cell_Internalname ;
      private string edtavLayoutcontratodescricao3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_layoutcontratodescricao2_cell_Internalname ;
      private string edtavLayoutcontratodescricao2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_layoutcontratodescricao1_cell_Internalname ;
      private string edtavLayoutcontratodescricao1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtLayoutContratoId_Jsonclick ;
      private string edtLayoutContratoDescricao_Jsonclick ;
      private string GXCCtl ;
      private string cmbLayoutContratoStatus_Jsonclick ;
      private string cmbLayoutContratoTipo_Jsonclick ;
      private string edtLayoutContratoTag_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
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
      private bool n155LayoutContratoDescricao ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n906LayoutContratoTipo ;
      private bool n1000LayoutContratoTag ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV74Layoutcontratowwds_5_dynamicfiltersenabled2 ;
      private bool AV78Layoutcontratowwds_9_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV64TFLayoutContratoTipo_SelsJson ;
      private string AV39ManageFiltersXml ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20LayoutContratoDescricao1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24LayoutContratoDescricao2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28LayoutContratoDescricao3 ;
      private string AV43TFLayoutContratoDescricao ;
      private string AV44TFLayoutContratoDescricao_Sel ;
      private string AV67TFLayoutContratoTag ;
      private string AV68TFLayoutContratoTag_Sel ;
      private string AV56GridAppliedFilters ;
      private string A155LayoutContratoDescricao ;
      private string A906LayoutContratoTipo ;
      private string A1000LayoutContratoTag ;
      private string lV70Layoutcontratowwds_1_filterfulltext ;
      private string lV73Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string lV77Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string lV81Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string lV82Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string lV86Layoutcontratowwds_17_tflayoutcontratotag ;
      private string AV70Layoutcontratowwds_1_filterfulltext ;
      private string AV71Layoutcontratowwds_2_dynamicfiltersselector1 ;
      private string AV73Layoutcontratowwds_4_layoutcontratodescricao1 ;
      private string AV75Layoutcontratowwds_6_dynamicfiltersselector2 ;
      private string AV77Layoutcontratowwds_8_layoutcontratodescricao2 ;
      private string AV79Layoutcontratowwds_10_dynamicfiltersselector3 ;
      private string AV81Layoutcontratowwds_12_layoutcontratodescricao3 ;
      private string AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel ;
      private string AV82Layoutcontratowwds_13_tflayoutcontratodescricao ;
      private string AV87Layoutcontratowwds_18_tflayoutcontratotag_sel ;
      private string AV86Layoutcontratowwds_17_tflayoutcontratotag ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private string AV66AuxText ;
      private IGxSession AV37Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbLayoutContratoStatus ;
      private GXCombobox cmbLayoutContratoTipo ;
      private GxSimpleCollection<string> AV65TFLayoutContratoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H003E2_A1000LayoutContratoTag ;
      private bool[] H003E2_n1000LayoutContratoTag ;
      private string[] H003E2_A906LayoutContratoTipo ;
      private bool[] H003E2_n906LayoutContratoTipo ;
      private bool[] H003E2_A156LayoutContratoStatus ;
      private bool[] H003E2_n156LayoutContratoStatus ;
      private string[] H003E2_A155LayoutContratoDescricao ;
      private bool[] H003E2_n155LayoutContratoDescricao ;
      private short[] H003E2_A154LayoutContratoId ;
      private long[] H003E3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class layoutcontratoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003E2( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV70Layoutcontratowwds_1_filterfulltext ,
                                             string AV71Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV72Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV73Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV74Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV75Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV76Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV77Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV78Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV79Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV80Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV81Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV82Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV87Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV86Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[20];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " LayoutContratoTag, LayoutContratoTipo, LayoutContratoStatus, LayoutContratoDescricao, LayoutContratoId";
         sFromString = " FROM LayoutContrato";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV70Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV70Layoutcontratowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV73Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV73Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV74Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV77Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV74Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV77Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV78Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV80Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV81Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV78Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV80Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV81Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV82Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV86Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV87Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV87Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV87Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY LayoutContratoDescricao, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY LayoutContratoDescricao DESC, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY LayoutContratoStatus, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY LayoutContratoStatus DESC, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY LayoutContratoTipo, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY LayoutContratoTipo DESC, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY LayoutContratoTag, LayoutContratoId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY LayoutContratoTag DESC, LayoutContratoId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY LayoutContratoId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H003E3( IGxContext context ,
                                             string A906LayoutContratoTipo ,
                                             GxSimpleCollection<string> AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels ,
                                             string AV70Layoutcontratowwds_1_filterfulltext ,
                                             string AV71Layoutcontratowwds_2_dynamicfiltersselector1 ,
                                             short AV72Layoutcontratowwds_3_dynamicfiltersoperator1 ,
                                             string AV73Layoutcontratowwds_4_layoutcontratodescricao1 ,
                                             bool AV74Layoutcontratowwds_5_dynamicfiltersenabled2 ,
                                             string AV75Layoutcontratowwds_6_dynamicfiltersselector2 ,
                                             short AV76Layoutcontratowwds_7_dynamicfiltersoperator2 ,
                                             string AV77Layoutcontratowwds_8_layoutcontratodescricao2 ,
                                             bool AV78Layoutcontratowwds_9_dynamicfiltersenabled3 ,
                                             string AV79Layoutcontratowwds_10_dynamicfiltersselector3 ,
                                             short AV80Layoutcontratowwds_11_dynamicfiltersoperator3 ,
                                             string AV81Layoutcontratowwds_12_layoutcontratodescricao3 ,
                                             string AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel ,
                                             string AV82Layoutcontratowwds_13_tflayoutcontratodescricao ,
                                             short AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel ,
                                             int AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count ,
                                             string AV87Layoutcontratowwds_18_tflayoutcontratotag_sel ,
                                             string AV86Layoutcontratowwds_17_tflayoutcontratotag ,
                                             string A155LayoutContratoDescricao ,
                                             bool A156LayoutContratoStatus ,
                                             string A1000LayoutContratoTag ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM LayoutContrato";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Layoutcontratowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LayoutContratoDescricao like '%' || :lV70Layoutcontratowwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = TRUE) or ( 'não' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoStatus = FALSE) or ( 'contrato' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'C')) or ( 'mensagem' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'M')) or ( 'acoplado' like '%' || LOWER(:lV70Layoutcontratowwds_1_filterfulltext) and LayoutContratoTipo = ( 'A')) or ( LayoutContratoTag like '%' || :lV70Layoutcontratowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV73Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV71Layoutcontratowwds_2_dynamicfiltersselector1, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV72Layoutcontratowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Layoutcontratowwds_4_layoutcontratodescricao1)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV73Layoutcontratowwds_4_layoutcontratodescricao1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV74Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV77Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV74Layoutcontratowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Layoutcontratowwds_6_dynamicfiltersselector2, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV76Layoutcontratowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Layoutcontratowwds_8_layoutcontratodescricao2)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV77Layoutcontratowwds_8_layoutcontratodescricao2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV78Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV80Layoutcontratowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV81Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV78Layoutcontratowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Layoutcontratowwds_10_dynamicfiltersselector3, "LAYOUTCONTRATODESCRICAO") == 0 ) && ( AV80Layoutcontratowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Layoutcontratowwds_12_layoutcontratodescricao3)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like '%' || :lV81Layoutcontratowwds_12_layoutcontratodescricao3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Layoutcontratowwds_13_tflayoutcontratodescricao)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao like :lV82Layoutcontratowwds_13_tflayoutcontratodescricao)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel)) && ! ( StringUtil.StrCmp(AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao = ( :AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoDescricao IS NULL or (char_length(trim(trailing ' ' from LayoutContratoDescricao))=0))");
         }
         if ( AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel == 1 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = TRUE)");
         }
         if ( AV84Layoutcontratowwds_15_tflayoutcontratostatus_sel == 2 )
         {
            AddWhere(sWhereString, "(LayoutContratoStatus = FALSE)");
         }
         if ( AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV85Layoutcontratowwds_16_tflayoutcontratotipo_sels, "LayoutContratoTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Layoutcontratowwds_17_tflayoutcontratotag)) ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag like :lV86Layoutcontratowwds_17_tflayoutcontratotag)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Layoutcontratowwds_18_tflayoutcontratotag_sel)) && ! ( StringUtil.StrCmp(AV87Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(LayoutContratoTag = ( :AV87Layoutcontratowwds_18_tflayoutcontratotag_sel))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV87Layoutcontratowwds_18_tflayoutcontratotag_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(LayoutContratoTag IS NULL or (char_length(trim(trailing ' ' from LayoutContratoTag))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
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
                     return conditional_H003E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
               case 1 :
                     return conditional_H003E3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmH003E2;
          prmH003E2 = new Object[] {
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV73Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV81Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV81Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV82Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV86Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV87Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003E3;
          prmH003E3 = new Object[] {
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Layoutcontratowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV73Layoutcontratowwds_4_layoutcontratodescricao1",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV77Layoutcontratowwds_8_layoutcontratodescricao2",GXType.VarChar,60,0) ,
          new ParDef("lV81Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV81Layoutcontratowwds_12_layoutcontratodescricao3",GXType.VarChar,60,0) ,
          new ParDef("lV82Layoutcontratowwds_13_tflayoutcontratodescricao",GXType.VarChar,60,0) ,
          new ParDef("AV83Layoutcontratowwds_14_tflayoutcontratodescricao_sel",GXType.VarChar,60,0) ,
          new ParDef("lV86Layoutcontratowwds_17_tflayoutcontratotag",GXType.VarChar,40,0) ,
          new ParDef("AV87Layoutcontratowwds_18_tflayoutcontratotag_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
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
