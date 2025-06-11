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
   public class notificacaoagendadaww : GXDataArea
   {
      public notificacaoagendadaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaww( IGxContext context )
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
         cmbNotificacaoAgendadaOrigem = new GXCombobox();
         cmbNotificacaoAgendadaMomentoEnvio = new GXCombobox();
         cmbNotificacaoAgendadaTipo = new GXCombobox();
         cmbNotificacaoAgendadaStatus = new GXCombobox();
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
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
         AV14FilterFullText = GetPar( "FilterFullText");
         AV18ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV43Pgmname = GetPar( "Pgmname");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV22TFNotificacaoAgendadaOrigem_Sels);
         AV23TFNotificacaoAgendadaDescricao = GetPar( "TFNotificacaoAgendadaDescricao");
         AV24TFNotificacaoAgendadaDescricao_Sel = GetPar( "TFNotificacaoAgendadaDescricao_Sel");
         AV25TFNotificacaoAgendadaDias = (int)(Math.Round(NumberUtil.Val( GetPar( "TFNotificacaoAgendadaDias"), "."), 18, MidpointRounding.ToEven));
         AV26TFNotificacaoAgendadaDias_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFNotificacaoAgendadaDias_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV28TFNotificacaoAgendadaMomentoEnvio_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFNotificacaoAgendadaTipo_Sels);
         AV33TFNotificacaoAgendadaStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFNotificacaoAgendadaStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
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
         PA9G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9G2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("notificacaoagendadaww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV16ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV38GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV34DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV13OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFNOTIFICACAOAGENDADAORIGEM_SELS", AV22TFNotificacaoAgendadaOrigem_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFNOTIFICACAOAGENDADAORIGEM_SELS", AV22TFNotificacaoAgendadaOrigem_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADADESCRICAO", AV23TFNotificacaoAgendadaDescricao);
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADADESCRICAO_SEL", AV24TFNotificacaoAgendadaDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADADIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADADIAS_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS", AV28TFNotificacaoAgendadaMomentoEnvio_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS", AV28TFNotificacaoAgendadaMomentoEnvio_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFNOTIFICACAOAGENDADATIPO_SELS", AV30TFNotificacaoAgendadaTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFNOTIFICACAOAGENDADATIPO_SELS", AV30TFNotificacaoAgendadaTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADASTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV10GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV10GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADAORIGEM_SELSJSON", AV21TFNotificacaoAgendadaOrigem_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELSJSON", AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFNOTIFICACAOAGENDADATIPO_SELSJSON", AV29TFNotificacaoAgendadaTipo_SelsJson);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
            WE9G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9G2( ) ;
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
         return formatLink("notificacaoagendadaww")  ;
      }

      public override string GetPgmname( )
      {
         return "NotificacaoAgendadaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Agendar Notificação" ;
      }

      protected void WB9G0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_NotificacaoAgendadaWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV16ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_NotificacaoAgendadaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV36GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV37GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV38GridAppliedFilters);
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV34DDO_TitleSettingsIcons);
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
         if ( wbEnd == 37 )
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

      protected void START9G2( )
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
         Form.Meta.addItem("description", " Agendar Notificação", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9G0( ) ;
      }

      protected void WS9G2( )
      {
         START9G2( ) ;
         EVT9G2( ) ;
      }

      protected void EVT9G2( )
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
                              E119G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149G2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E159G2 ();
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
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV39Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV39Display);
                              AV40Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
                              AV41Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV41Delete);
                              A898NotificacaoAgendadaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              cmbNotificacaoAgendadaOrigem.Name = cmbNotificacaoAgendadaOrigem_Internalname;
                              cmbNotificacaoAgendadaOrigem.CurrentValue = cgiGet( cmbNotificacaoAgendadaOrigem_Internalname);
                              A899NotificacaoAgendadaOrigem = cgiGet( cmbNotificacaoAgendadaOrigem_Internalname);
                              A900NotificacaoAgendadaDescricao = cgiGet( edtNotificacaoAgendadaDescricao_Internalname);
                              A901NotificacaoAgendadaDias = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNotificacaoAgendadaDias_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n901NotificacaoAgendadaDias = false;
                              cmbNotificacaoAgendadaMomentoEnvio.Name = cmbNotificacaoAgendadaMomentoEnvio_Internalname;
                              cmbNotificacaoAgendadaMomentoEnvio.CurrentValue = cgiGet( cmbNotificacaoAgendadaMomentoEnvio_Internalname);
                              A902NotificacaoAgendadaMomentoEnvio = cgiGet( cmbNotificacaoAgendadaMomentoEnvio_Internalname);
                              n902NotificacaoAgendadaMomentoEnvio = false;
                              cmbNotificacaoAgendadaTipo.Name = cmbNotificacaoAgendadaTipo_Internalname;
                              cmbNotificacaoAgendadaTipo.CurrentValue = cgiGet( cmbNotificacaoAgendadaTipo_Internalname);
                              A903NotificacaoAgendadaTipo = cgiGet( cmbNotificacaoAgendadaTipo_Internalname);
                              n903NotificacaoAgendadaTipo = false;
                              cmbNotificacaoAgendadaStatus.Name = cmbNotificacaoAgendadaStatus_Internalname;
                              cmbNotificacaoAgendadaStatus.CurrentValue = cgiGet( cmbNotificacaoAgendadaStatus_Internalname);
                              A905NotificacaoAgendadaStatus = StringUtil.StrToBool( cgiGet( cmbNotificacaoAgendadaStatus_Internalname));
                              n905NotificacaoAgendadaStatus = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E169G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E179G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E189G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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

      protected void WE9G2( )
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

      protected void PA9G2( )
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       string AV14FilterFullText ,
                                       short AV18ManageFiltersExecutionStep ,
                                       string AV43Pgmname ,
                                       GxSimpleCollection<string> AV22TFNotificacaoAgendadaOrigem_Sels ,
                                       string AV23TFNotificacaoAgendadaDescricao ,
                                       string AV24TFNotificacaoAgendadaDescricao_Sel ,
                                       int AV25TFNotificacaoAgendadaDias ,
                                       int AV26TFNotificacaoAgendadaDias_To ,
                                       GxSimpleCollection<string> AV28TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                       GxSimpleCollection<string> AV30TFNotificacaoAgendadaTipo_Sels ,
                                       short AV33TFNotificacaoAgendadaStatus_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_NOTIFICACAOAGENDADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "NOTIFICACAOAGENDADAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A898NotificacaoAgendadaId), 9, 0, ".", "")));
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
         RF9G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV43Pgmname = "NotificacaoAgendadaWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF9G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E179G2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A899NotificacaoAgendadaOrigem ,
                                                 AV22TFNotificacaoAgendadaOrigem_Sels ,
                                                 A902NotificacaoAgendadaMomentoEnvio ,
                                                 AV28TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                                 A903NotificacaoAgendadaTipo ,
                                                 AV30TFNotificacaoAgendadaTipo_Sels ,
                                                 AV14FilterFullText ,
                                                 AV22TFNotificacaoAgendadaOrigem_Sels.Count ,
                                                 AV24TFNotificacaoAgendadaDescricao_Sel ,
                                                 AV23TFNotificacaoAgendadaDescricao ,
                                                 AV25TFNotificacaoAgendadaDias ,
                                                 AV26TFNotificacaoAgendadaDias_To ,
                                                 AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Count ,
                                                 AV30TFNotificacaoAgendadaTipo_Sels.Count ,
                                                 AV33TFNotificacaoAgendadaStatus_Sel ,
                                                 A900NotificacaoAgendadaDescricao ,
                                                 A901NotificacaoAgendadaDias ,
                                                 A905NotificacaoAgendadaStatus ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV23TFNotificacaoAgendadaDescricao = StringUtil.Concat( StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao), "%", "");
            /* Using cursor H009G2 */
            pr_default.execute(0, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A905NotificacaoAgendadaStatus = H009G2_A905NotificacaoAgendadaStatus[0];
               n905NotificacaoAgendadaStatus = H009G2_n905NotificacaoAgendadaStatus[0];
               A903NotificacaoAgendadaTipo = H009G2_A903NotificacaoAgendadaTipo[0];
               n903NotificacaoAgendadaTipo = H009G2_n903NotificacaoAgendadaTipo[0];
               A902NotificacaoAgendadaMomentoEnvio = H009G2_A902NotificacaoAgendadaMomentoEnvio[0];
               n902NotificacaoAgendadaMomentoEnvio = H009G2_n902NotificacaoAgendadaMomentoEnvio[0];
               A901NotificacaoAgendadaDias = H009G2_A901NotificacaoAgendadaDias[0];
               n901NotificacaoAgendadaDias = H009G2_n901NotificacaoAgendadaDias[0];
               A900NotificacaoAgendadaDescricao = H009G2_A900NotificacaoAgendadaDescricao[0];
               A899NotificacaoAgendadaOrigem = H009G2_A899NotificacaoAgendadaOrigem[0];
               A898NotificacaoAgendadaId = H009G2_A898NotificacaoAgendadaId[0];
               /* Execute user event: Grid.Load */
               E189G2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 37;
            WB9G0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9G2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV43Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_NOTIFICACAOAGENDADAID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sGXsfl_37_idx, context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9"), context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A899NotificacaoAgendadaOrigem ,
                                              AV22TFNotificacaoAgendadaOrigem_Sels ,
                                              A902NotificacaoAgendadaMomentoEnvio ,
                                              AV28TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                              A903NotificacaoAgendadaTipo ,
                                              AV30TFNotificacaoAgendadaTipo_Sels ,
                                              AV14FilterFullText ,
                                              AV22TFNotificacaoAgendadaOrigem_Sels.Count ,
                                              AV24TFNotificacaoAgendadaDescricao_Sel ,
                                              AV23TFNotificacaoAgendadaDescricao ,
                                              AV25TFNotificacaoAgendadaDias ,
                                              AV26TFNotificacaoAgendadaDias_To ,
                                              AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Count ,
                                              AV30TFNotificacaoAgendadaTipo_Sels.Count ,
                                              AV33TFNotificacaoAgendadaStatus_Sel ,
                                              A900NotificacaoAgendadaDescricao ,
                                              A901NotificacaoAgendadaDias ,
                                              A905NotificacaoAgendadaStatus ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV23TFNotificacaoAgendadaDescricao = StringUtil.Concat( StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao), "%", "");
         /* Using cursor H009G3 */
         pr_default.execute(1, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To});
         GRID_nRecordCount = H009G3_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV14FilterFullText, AV18ManageFiltersExecutionStep, AV43Pgmname, AV22TFNotificacaoAgendadaOrigem_Sels, AV23TFNotificacaoAgendadaDescricao, AV24TFNotificacaoAgendadaDescricao_Sel, AV25TFNotificacaoAgendadaDias, AV26TFNotificacaoAgendadaDias_To, AV28TFNotificacaoAgendadaMomentoEnvio_Sels, AV30TFNotificacaoAgendadaTipo_Sels, AV33TFNotificacaoAgendadaStatus_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV43Pgmname = "NotificacaoAgendadaWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtNotificacaoAgendadaId_Enabled = 0;
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
         edtNotificacaoAgendadaDescricao_Enabled = 0;
         edtNotificacaoAgendadaDias_Enabled = 0;
         cmbNotificacaoAgendadaMomentoEnvio.Enabled = 0;
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         cmbNotificacaoAgendadaStatus.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E169G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV16ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV34DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_37"), ",", "."), 18, MidpointRounding.ToEven));
            AV36GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV37GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV38GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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
         E169G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E169G2( )
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
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = " Agendar Notificação";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV34DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV34DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E179G2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV18ManageFiltersExecutionStep == 1 )
         {
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV18ManageFiltersExecutionStep == 2 )
         {
            AV18ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV36GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV36GridCurrentPage), 10, 0));
         AV37GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV37GridPageCount", StringUtil.LTrimStr( (decimal)(AV37GridPageCount), 10, 0));
         GXt_char2 = AV38GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV43Pgmname, out  GXt_char2) ;
         AV38GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV38GridAppliedFilters", AV38GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridState", AV10GridState);
      }

      protected void E129G2( )
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
            AV35PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV35PageToGo) ;
         }
      }

      protected void E139G2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149G2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaOrigem") == 0 )
            {
               AV21TFNotificacaoAgendadaOrigem_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV21TFNotificacaoAgendadaOrigem_SelsJson", AV21TFNotificacaoAgendadaOrigem_SelsJson);
               AV22TFNotificacaoAgendadaOrigem_Sels.FromJSonString(AV21TFNotificacaoAgendadaOrigem_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaDescricao") == 0 )
            {
               AV23TFNotificacaoAgendadaDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV23TFNotificacaoAgendadaDescricao", AV23TFNotificacaoAgendadaDescricao);
               AV24TFNotificacaoAgendadaDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV24TFNotificacaoAgendadaDescricao_Sel", AV24TFNotificacaoAgendadaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaDias") == 0 )
            {
               AV25TFNotificacaoAgendadaDias = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFNotificacaoAgendadaDias", StringUtil.LTrimStr( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0));
               AV26TFNotificacaoAgendadaDias_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFNotificacaoAgendadaDias_To", StringUtil.LTrimStr( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaMomentoEnvio") == 0 )
            {
               AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson", AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson);
               AV28TFNotificacaoAgendadaMomentoEnvio_Sels.FromJSonString(AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaTipo") == 0 )
            {
               AV29TFNotificacaoAgendadaTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV29TFNotificacaoAgendadaTipo_SelsJson", AV29TFNotificacaoAgendadaTipo_SelsJson);
               AV30TFNotificacaoAgendadaTipo_Sels.FromJSonString(AV29TFNotificacaoAgendadaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NotificacaoAgendadaStatus") == 0 )
            {
               AV33TFNotificacaoAgendadaStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33TFNotificacaoAgendadaStatus_Sel", StringUtil.Str( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFNotificacaoAgendadaTipo_Sels", AV30TFNotificacaoAgendadaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28TFNotificacaoAgendadaMomentoEnvio_Sels", AV28TFNotificacaoAgendadaMomentoEnvio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22TFNotificacaoAgendadaOrigem_Sels", AV22TFNotificacaoAgendadaOrigem_Sels);
      }

      private void E189G2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV39Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV39Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A898NotificacaoAgendadaId,9,0));
         edtavDisplay_Link = formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV40Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV40Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A898NotificacaoAgendadaId,9,0));
         edtavUpdate_Link = formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV41Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV41Delete);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A898NotificacaoAgendadaId,9,0));
         edtavDelete_Link = formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 37;
         }
         sendrow_372( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E119G2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
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
            S152 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("NotificacaoAgendadaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV43Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("NotificacaoAgendadaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV18ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV18ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV18ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV17ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "NotificacaoAgendadaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV17ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV43Pgmname+"GridState",  AV17ManageFiltersXml) ;
               AV10GridState.FromXml(AV17ManageFiltersXml, null, "", "");
               AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
               AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22TFNotificacaoAgendadaOrigem_Sels", AV22TFNotificacaoAgendadaOrigem_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28TFNotificacaoAgendadaMomentoEnvio_Sels", AV28TFNotificacaoAgendadaMomentoEnvio_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30TFNotificacaoAgendadaTipo_Sels", AV30TFNotificacaoAgendadaTipo_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16ManageFiltersData", AV16ManageFiltersData);
      }

      protected void E159G2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "notificacaoagendada"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("notificacaoagendada") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV16ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "NotificacaoAgendadaWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV16ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV22TFNotificacaoAgendadaOrigem_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23TFNotificacaoAgendadaDescricao = "";
         AssignAttri("", false, "AV23TFNotificacaoAgendadaDescricao", AV23TFNotificacaoAgendadaDescricao);
         AV24TFNotificacaoAgendadaDescricao_Sel = "";
         AssignAttri("", false, "AV24TFNotificacaoAgendadaDescricao_Sel", AV24TFNotificacaoAgendadaDescricao_Sel);
         AV25TFNotificacaoAgendadaDias = 0;
         AssignAttri("", false, "AV25TFNotificacaoAgendadaDias", StringUtil.LTrimStr( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0));
         AV26TFNotificacaoAgendadaDias_To = 0;
         AssignAttri("", false, "AV26TFNotificacaoAgendadaDias_To", StringUtil.LTrimStr( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0));
         AV28TFNotificacaoAgendadaMomentoEnvio_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30TFNotificacaoAgendadaTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33TFNotificacaoAgendadaStatus_Sel = 0;
         AssignAttri("", false, "AV33TFNotificacaoAgendadaStatus_Sel", StringUtil.Str( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15Session.Get(AV43Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV43Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV15Session.Get(AV43Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
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

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV44GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV14FilterFullText = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADAORIGEM_SEL") == 0 )
            {
               AV21TFNotificacaoAgendadaOrigem_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV21TFNotificacaoAgendadaOrigem_SelsJson", AV21TFNotificacaoAgendadaOrigem_SelsJson);
               AV22TFNotificacaoAgendadaOrigem_Sels.FromJSonString(AV21TFNotificacaoAgendadaOrigem_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADESCRICAO") == 0 )
            {
               AV23TFNotificacaoAgendadaDescricao = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23TFNotificacaoAgendadaDescricao", AV23TFNotificacaoAgendadaDescricao);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADESCRICAO_SEL") == 0 )
            {
               AV24TFNotificacaoAgendadaDescricao_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV24TFNotificacaoAgendadaDescricao_Sel", AV24TFNotificacaoAgendadaDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADIAS") == 0 )
            {
               AV25TFNotificacaoAgendadaDias = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFNotificacaoAgendadaDias", StringUtil.LTrimStr( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0));
               AV26TFNotificacaoAgendadaDias_To = (int)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFNotificacaoAgendadaDias_To", StringUtil.LTrimStr( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADAMOMENTOENVIO_SEL") == 0 )
            {
               AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson", AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson);
               AV28TFNotificacaoAgendadaMomentoEnvio_Sels.FromJSonString(AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADATIPO_SEL") == 0 )
            {
               AV29TFNotificacaoAgendadaTipo_SelsJson = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFNotificacaoAgendadaTipo_SelsJson", AV29TFNotificacaoAgendadaTipo_SelsJson);
               AV30TFNotificacaoAgendadaTipo_Sels.FromJSonString(AV29TFNotificacaoAgendadaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADASTATUS_SEL") == 0 )
            {
               AV33TFNotificacaoAgendadaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33TFNotificacaoAgendadaStatus_Sel", StringUtil.Str( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0));
            }
            AV44GXV1 = (int)(AV44GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV22TFNotificacaoAgendadaOrigem_Sels.Count==0),  AV21TFNotificacaoAgendadaOrigem_SelsJson, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)),  AV24TFNotificacaoAgendadaDescricao_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Count==0),  AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFNotificacaoAgendadaTipo_Sels.Count==0),  AV29TFNotificacaoAgendadaTipo_SelsJson, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||"+GXt_char5+"|"+GXt_char6+"|"+((0==AV33TFNotificacaoAgendadaStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao)),  AV23TFNotificacaoAgendadaDescricao, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char6+"|"+((0==AV25TFNotificacaoAgendadaDias) ? "" : StringUtil.Str( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV26TFNotificacaoAgendadaDias_To) ? "" : StringUtil.Str( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV15Session.Get(AV43Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  AV14FilterFullText,  false,  "",  "") ;
         AV42AuxText = ((AV22TFNotificacaoAgendadaOrigem_Sels.Count==1) ? "["+((string)AV22TFNotificacaoAgendadaOrigem_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADAORIGEM_SEL",  "Origem",  !(AV22TFNotificacaoAgendadaOrigem_Sels.Count==0),  0,  AV22TFNotificacaoAgendadaOrigem_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV42AuxText, "")==0) ? "" : StringUtil.StringReplace( AV42AuxText, "[R]", "Título a receber")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADADESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao)),  0,  AV23TFNotificacaoAgendadaDescricao,  AV23TFNotificacaoAgendadaDescricao,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)),  AV24TFNotificacaoAgendadaDescricao_Sel,  AV24TFNotificacaoAgendadaDescricao_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADADIAS",  "Dias",  !((0==AV25TFNotificacaoAgendadaDias)&&(0==AV26TFNotificacaoAgendadaDias_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFNotificacaoAgendadaDias), 9, 0)),  ((0==AV25TFNotificacaoAgendadaDias) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV25TFNotificacaoAgendadaDias), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFNotificacaoAgendadaDias_To), 9, 0)),  ((0==AV26TFNotificacaoAgendadaDias_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV26TFNotificacaoAgendadaDias_To), "ZZZZZZZZ9")))) ;
         AV42AuxText = ((AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Count==1) ? "["+((string)AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADAMOMENTOENVIO_SEL",  "Momento de Envio",  !(AV28TFNotificacaoAgendadaMomentoEnvio_Sels.Count==0),  0,  AV28TFNotificacaoAgendadaMomentoEnvio_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV42AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV42AuxText, "[A]", "Antes"), "[D]", "Depois")),  false,  "",  "") ;
         AV42AuxText = ((AV30TFNotificacaoAgendadaTipo_Sels.Count==1) ? "["+((string)AV30TFNotificacaoAgendadaTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADATIPO_SEL",  "Tipo",  !(AV30TFNotificacaoAgendadaTipo_Sels.Count==0),  0,  AV30TFNotificacaoAgendadaTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV42AuxText, "")==0) ? "" : StringUtil.StringReplace( AV42AuxText, "[E]", "Email")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFNOTIFICACAOAGENDADASTATUS_SEL",  "Ativo",  !(0==AV33TFNotificacaoAgendadaStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFNotificacaoAgendadaStatus_Sel), 1, 0)),  ((AV33TFNotificacaoAgendadaStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV43Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV43Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "NotificacaoAgendada";
         AV15Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
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
         PA9G2( ) ;
         WS9G2( ) ;
         WE9G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928710", true, true);
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
         context.AddJavascriptSource("notificacaoagendadaww.js", "?20256101928711", false, true);
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

      protected void SubsflControlProps_372( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_idx;
         edtNotificacaoAgendadaId_Internalname = "NOTIFICACAOAGENDADAID_"+sGXsfl_37_idx;
         cmbNotificacaoAgendadaOrigem_Internalname = "NOTIFICACAOAGENDADAORIGEM_"+sGXsfl_37_idx;
         edtNotificacaoAgendadaDescricao_Internalname = "NOTIFICACAOAGENDADADESCRICAO_"+sGXsfl_37_idx;
         edtNotificacaoAgendadaDias_Internalname = "NOTIFICACAOAGENDADADIAS_"+sGXsfl_37_idx;
         cmbNotificacaoAgendadaMomentoEnvio_Internalname = "NOTIFICACAOAGENDADAMOMENTOENVIO_"+sGXsfl_37_idx;
         cmbNotificacaoAgendadaTipo_Internalname = "NOTIFICACAOAGENDADATIPO_"+sGXsfl_37_idx;
         cmbNotificacaoAgendadaStatus_Internalname = "NOTIFICACAOAGENDADASTATUS_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_37_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_37_fel_idx;
         edtNotificacaoAgendadaId_Internalname = "NOTIFICACAOAGENDADAID_"+sGXsfl_37_fel_idx;
         cmbNotificacaoAgendadaOrigem_Internalname = "NOTIFICACAOAGENDADAORIGEM_"+sGXsfl_37_fel_idx;
         edtNotificacaoAgendadaDescricao_Internalname = "NOTIFICACAOAGENDADADESCRICAO_"+sGXsfl_37_fel_idx;
         edtNotificacaoAgendadaDias_Internalname = "NOTIFICACAOAGENDADADIAS_"+sGXsfl_37_fel_idx;
         cmbNotificacaoAgendadaMomentoEnvio_Internalname = "NOTIFICACAOAGENDADAMOMENTOENVIO_"+sGXsfl_37_fel_idx;
         cmbNotificacaoAgendadaTipo_Internalname = "NOTIFICACAOAGENDADATIPO_"+sGXsfl_37_fel_idx;
         cmbNotificacaoAgendadaStatus_Internalname = "NOTIFICACAOAGENDADASTATUS_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB9G0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV39Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV40Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV41Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotificacaoAgendadaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A898NotificacaoAgendadaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A898NotificacaoAgendadaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotificacaoAgendadaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbNotificacaoAgendadaOrigem.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "NOTIFICACAOAGENDADAORIGEM_" + sGXsfl_37_idx;
               cmbNotificacaoAgendadaOrigem.Name = GXCCtl;
               cmbNotificacaoAgendadaOrigem.WebTags = "";
               cmbNotificacaoAgendadaOrigem.addItem("R", "Título a receber", 0);
               if ( cmbNotificacaoAgendadaOrigem.ItemCount > 0 )
               {
                  A899NotificacaoAgendadaOrigem = cmbNotificacaoAgendadaOrigem.getValidValue(A899NotificacaoAgendadaOrigem);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotificacaoAgendadaOrigem,(string)cmbNotificacaoAgendadaOrigem_Internalname,StringUtil.RTrim( A899NotificacaoAgendadaOrigem),(short)1,(string)cmbNotificacaoAgendadaOrigem_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbNotificacaoAgendadaOrigem.CurrentValue = StringUtil.RTrim( A899NotificacaoAgendadaOrigem);
            AssignProp("", false, cmbNotificacaoAgendadaOrigem_Internalname, "Values", (string)(cmbNotificacaoAgendadaOrigem.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotificacaoAgendadaDescricao_Internalname,(string)A900NotificacaoAgendadaDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotificacaoAgendadaDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNotificacaoAgendadaDias_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A901NotificacaoAgendadaDias), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNotificacaoAgendadaDias_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbNotificacaoAgendadaMomentoEnvio.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "NOTIFICACAOAGENDADAMOMENTOENVIO_" + sGXsfl_37_idx;
               cmbNotificacaoAgendadaMomentoEnvio.Name = GXCCtl;
               cmbNotificacaoAgendadaMomentoEnvio.WebTags = "";
               cmbNotificacaoAgendadaMomentoEnvio.addItem("A", "Antes", 0);
               cmbNotificacaoAgendadaMomentoEnvio.addItem("D", "Depois", 0);
               if ( cmbNotificacaoAgendadaMomentoEnvio.ItemCount > 0 )
               {
                  A902NotificacaoAgendadaMomentoEnvio = cmbNotificacaoAgendadaMomentoEnvio.getValidValue(A902NotificacaoAgendadaMomentoEnvio);
                  n902NotificacaoAgendadaMomentoEnvio = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotificacaoAgendadaMomentoEnvio,(string)cmbNotificacaoAgendadaMomentoEnvio_Internalname,StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio),(short)1,(string)cmbNotificacaoAgendadaMomentoEnvio_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbNotificacaoAgendadaMomentoEnvio.CurrentValue = StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio);
            AssignProp("", false, cmbNotificacaoAgendadaMomentoEnvio_Internalname, "Values", (string)(cmbNotificacaoAgendadaMomentoEnvio.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbNotificacaoAgendadaTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "NOTIFICACAOAGENDADATIPO_" + sGXsfl_37_idx;
               cmbNotificacaoAgendadaTipo.Name = GXCCtl;
               cmbNotificacaoAgendadaTipo.WebTags = "";
               cmbNotificacaoAgendadaTipo.addItem("E", "Email", 0);
               if ( cmbNotificacaoAgendadaTipo.ItemCount > 0 )
               {
                  A903NotificacaoAgendadaTipo = cmbNotificacaoAgendadaTipo.getValidValue(A903NotificacaoAgendadaTipo);
                  n903NotificacaoAgendadaTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotificacaoAgendadaTipo,(string)cmbNotificacaoAgendadaTipo_Internalname,StringUtil.RTrim( A903NotificacaoAgendadaTipo),(short)1,(string)cmbNotificacaoAgendadaTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbNotificacaoAgendadaTipo.CurrentValue = StringUtil.RTrim( A903NotificacaoAgendadaTipo);
            AssignProp("", false, cmbNotificacaoAgendadaTipo_Internalname, "Values", (string)(cmbNotificacaoAgendadaTipo.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbNotificacaoAgendadaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "NOTIFICACAOAGENDADASTATUS_" + sGXsfl_37_idx;
               cmbNotificacaoAgendadaStatus.Name = GXCCtl;
               cmbNotificacaoAgendadaStatus.WebTags = "";
               cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
               cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
               if ( cmbNotificacaoAgendadaStatus.ItemCount > 0 )
               {
                  A905NotificacaoAgendadaStatus = StringUtil.StrToBool( cmbNotificacaoAgendadaStatus.getValidValue(StringUtil.BoolToStr( A905NotificacaoAgendadaStatus)));
                  n905NotificacaoAgendadaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbNotificacaoAgendadaStatus,(string)cmbNotificacaoAgendadaStatus_Internalname,StringUtil.BoolToStr( A905NotificacaoAgendadaStatus),(short)1,(string)cmbNotificacaoAgendadaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbNotificacaoAgendadaStatus.CurrentValue = StringUtil.BoolToStr( A905NotificacaoAgendadaStatus);
            AssignProp("", false, cmbNotificacaoAgendadaStatus_Internalname, "Values", (string)(cmbNotificacaoAgendadaStatus.ToJavascriptSource()), !bGXsfl_37_Refreshing);
            send_integrity_lvl_hashes9G2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "NOTIFICACAOAGENDADAORIGEM_" + sGXsfl_37_idx;
         cmbNotificacaoAgendadaOrigem.Name = GXCCtl;
         cmbNotificacaoAgendadaOrigem.WebTags = "";
         cmbNotificacaoAgendadaOrigem.addItem("R", "Título a receber", 0);
         if ( cmbNotificacaoAgendadaOrigem.ItemCount > 0 )
         {
            A899NotificacaoAgendadaOrigem = cmbNotificacaoAgendadaOrigem.getValidValue(A899NotificacaoAgendadaOrigem);
         }
         GXCCtl = "NOTIFICACAOAGENDADAMOMENTOENVIO_" + sGXsfl_37_idx;
         cmbNotificacaoAgendadaMomentoEnvio.Name = GXCCtl;
         cmbNotificacaoAgendadaMomentoEnvio.WebTags = "";
         cmbNotificacaoAgendadaMomentoEnvio.addItem("A", "Antes", 0);
         cmbNotificacaoAgendadaMomentoEnvio.addItem("D", "Depois", 0);
         if ( cmbNotificacaoAgendadaMomentoEnvio.ItemCount > 0 )
         {
            A902NotificacaoAgendadaMomentoEnvio = cmbNotificacaoAgendadaMomentoEnvio.getValidValue(A902NotificacaoAgendadaMomentoEnvio);
            n902NotificacaoAgendadaMomentoEnvio = false;
         }
         GXCCtl = "NOTIFICACAOAGENDADATIPO_" + sGXsfl_37_idx;
         cmbNotificacaoAgendadaTipo.Name = GXCCtl;
         cmbNotificacaoAgendadaTipo.WebTags = "";
         cmbNotificacaoAgendadaTipo.addItem("E", "Email", 0);
         if ( cmbNotificacaoAgendadaTipo.ItemCount > 0 )
         {
            A903NotificacaoAgendadaTipo = cmbNotificacaoAgendadaTipo.getValidValue(A903NotificacaoAgendadaTipo);
            n903NotificacaoAgendadaTipo = false;
         }
         GXCCtl = "NOTIFICACAOAGENDADASTATUS_" + sGXsfl_37_idx;
         cmbNotificacaoAgendadaStatus.Name = GXCCtl;
         cmbNotificacaoAgendadaStatus.WebTags = "";
         cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbNotificacaoAgendadaStatus.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbNotificacaoAgendadaStatus.ItemCount > 0 )
         {
            A905NotificacaoAgendadaStatus = StringUtil.StrToBool( cmbNotificacaoAgendadaStatus.getValidValue(StringUtil.BoolToStr( A905NotificacaoAgendadaStatus)));
            n905NotificacaoAgendadaStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Origem") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Dias") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Momento de Envio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ativo") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV39Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV40Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV41Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A898NotificacaoAgendadaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A899NotificacaoAgendadaOrigem));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A900NotificacaoAgendadaDescricao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A901NotificacaoAgendadaDias), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A902NotificacaoAgendadaMomentoEnvio));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A903NotificacaoAgendadaTipo));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A905NotificacaoAgendadaStatus)));
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
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtNotificacaoAgendadaId_Internalname = "NOTIFICACAOAGENDADAID";
         cmbNotificacaoAgendadaOrigem_Internalname = "NOTIFICACAOAGENDADAORIGEM";
         edtNotificacaoAgendadaDescricao_Internalname = "NOTIFICACAOAGENDADADESCRICAO";
         edtNotificacaoAgendadaDias_Internalname = "NOTIFICACAOAGENDADADIAS";
         cmbNotificacaoAgendadaMomentoEnvio_Internalname = "NOTIFICACAOAGENDADAMOMENTOENVIO";
         cmbNotificacaoAgendadaTipo_Internalname = "NOTIFICACAOAGENDADATIPO";
         cmbNotificacaoAgendadaStatus_Internalname = "NOTIFICACAOAGENDADASTATUS";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
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
         cmbNotificacaoAgendadaStatus_Jsonclick = "";
         cmbNotificacaoAgendadaTipo_Jsonclick = "";
         cmbNotificacaoAgendadaMomentoEnvio_Jsonclick = "";
         edtNotificacaoAgendadaDias_Jsonclick = "";
         edtNotificacaoAgendadaDescricao_Jsonclick = "";
         cmbNotificacaoAgendadaOrigem_Jsonclick = "";
         edtNotificacaoAgendadaId_Jsonclick = "";
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
         cmbNotificacaoAgendadaStatus.Enabled = 0;
         cmbNotificacaoAgendadaTipo.Enabled = 0;
         cmbNotificacaoAgendadaMomentoEnvio.Enabled = 0;
         edtNotificacaoAgendadaDias_Enabled = 0;
         edtNotificacaoAgendadaDescricao_Enabled = 0;
         cmbNotificacaoAgendadaOrigem.Enabled = 0;
         edtNotificacaoAgendadaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||9.0|||";
         Ddo_grid_Datalistproc = "NotificacaoAgendadaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "R:Título a receber|||A:Antes,D:Depois|E:Email|1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Allowmultipleselection = "T|||T|T|";
         Ddo_grid_Datalisttype = "FixedValues|Dynamic||FixedValues|FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T|T||T|T|T";
         Ddo_grid_Filterisrange = "||T|||";
         Ddo_grid_Filtertype = "|Character|Numeric|||";
         Ddo_grid_Includefilter = "|T|T|||";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6";
         Ddo_grid_Columnids = "4:NotificacaoAgendadaOrigem|5:NotificacaoAgendadaDescricao|6:NotificacaoAgendadaDias|7:NotificacaoAgendadaMomentoEnvio|8:NotificacaoAgendadaTipo|9:NotificacaoAgendadaStatus";
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
         Form.Caption = " Agendar Notificação";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"AV29TFNotificacaoAgendadaTipo_SelsJson","fld":"vTFNOTIFICACAOAGENDADATIPO_SELSJSON","type":"vchar"},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELSJSON","type":"vchar"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV21TFNotificacaoAgendadaOrigem_SelsJson","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELSJSON","type":"vchar"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E189G2","iparms":[{"av":"A898NotificacaoAgendadaId","fld":"NOTIFICACAOAGENDADAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV39Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV40Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV41Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119G2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV43Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV21TFNotificacaoAgendadaOrigem_SelsJson","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELSJSON","type":"vchar"},{"av":"AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELSJSON","type":"vchar"},{"av":"AV29TFNotificacaoAgendadaTipo_SelsJson","fld":"vTFNOTIFICACAOAGENDADATIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV18ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV10GridState","fld":"vGRIDSTATE","type":""},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV22TFNotificacaoAgendadaOrigem_Sels","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELS","type":""},{"av":"AV23TFNotificacaoAgendadaDescricao","fld":"vTFNOTIFICACAOAGENDADADESCRICAO","type":"svchar"},{"av":"AV24TFNotificacaoAgendadaDescricao_Sel","fld":"vTFNOTIFICACAOAGENDADADESCRICAO_SEL","type":"svchar"},{"av":"AV25TFNotificacaoAgendadaDias","fld":"vTFNOTIFICACAOAGENDADADIAS","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26TFNotificacaoAgendadaDias_To","fld":"vTFNOTIFICACAOAGENDADADIAS_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28TFNotificacaoAgendadaMomentoEnvio_Sels","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELS","type":""},{"av":"AV30TFNotificacaoAgendadaTipo_Sels","fld":"vTFNOTIFICACAOAGENDADATIPO_SELS","type":""},{"av":"AV33TFNotificacaoAgendadaStatus_Sel","fld":"vTFNOTIFICACAOAGENDADASTATUS_SEL","pic":"9","type":"int"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV29TFNotificacaoAgendadaTipo_SelsJson","fld":"vTFNOTIFICACAOAGENDADATIPO_SELSJSON","type":"vchar"},{"av":"AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson","fld":"vTFNOTIFICACAOAGENDADAMOMENTOENVIO_SELSJSON","type":"vchar"},{"av":"AV21TFNotificacaoAgendadaOrigem_SelsJson","fld":"vTFNOTIFICACAOAGENDADAORIGEM_SELSJSON","type":"vchar"},{"av":"AV36GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV37GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV38GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV16ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E159G2","iparms":[{"av":"A898NotificacaoAgendadaId","fld":"NOTIFICACAOAGENDADAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Notificacaoagendadastatus","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14FilterFullText = "";
         AV43Pgmname = "";
         AV22TFNotificacaoAgendadaOrigem_Sels = new GxSimpleCollection<string>();
         AV23TFNotificacaoAgendadaDescricao = "";
         AV24TFNotificacaoAgendadaDescricao_Sel = "";
         AV28TFNotificacaoAgendadaMomentoEnvio_Sels = new GxSimpleCollection<string>();
         AV30TFNotificacaoAgendadaTipo_Sels = new GxSimpleCollection<string>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV16ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38GridAppliedFilters = "";
         AV34DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV21TFNotificacaoAgendadaOrigem_SelsJson = "";
         AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson = "";
         AV29TFNotificacaoAgendadaTipo_SelsJson = "";
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
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV39Display = "";
         AV40Update = "";
         AV41Delete = "";
         A899NotificacaoAgendadaOrigem = "";
         A900NotificacaoAgendadaDescricao = "";
         A902NotificacaoAgendadaMomentoEnvio = "";
         A903NotificacaoAgendadaTipo = "";
         lV14FilterFullText = "";
         lV23TFNotificacaoAgendadaDescricao = "";
         H009G2_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         H009G2_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         H009G2_A903NotificacaoAgendadaTipo = new string[] {""} ;
         H009G2_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         H009G2_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         H009G2_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         H009G2_A901NotificacaoAgendadaDias = new int[1] ;
         H009G2_n901NotificacaoAgendadaDias = new bool[] {false} ;
         H009G2_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         H009G2_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         H009G2_A898NotificacaoAgendadaId = new int[1] ;
         H009G3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV17ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15Session = context.GetSession();
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char4 = "";
         GXt_char5 = "";
         GXt_char6 = "";
         AV42AuxText = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaww__default(),
            new Object[][] {
                new Object[] {
               H009G2_A905NotificacaoAgendadaStatus, H009G2_n905NotificacaoAgendadaStatus, H009G2_A903NotificacaoAgendadaTipo, H009G2_n903NotificacaoAgendadaTipo, H009G2_A902NotificacaoAgendadaMomentoEnvio, H009G2_n902NotificacaoAgendadaMomentoEnvio, H009G2_A901NotificacaoAgendadaDias, H009G2_n901NotificacaoAgendadaDias, H009G2_A900NotificacaoAgendadaDescricao, H009G2_A899NotificacaoAgendadaOrigem,
               H009G2_A898NotificacaoAgendadaId
               }
               , new Object[] {
               H009G3_AGRID_nRecordCount
               }
            }
         );
         AV43Pgmname = "NotificacaoAgendadaWW";
         /* GeneXus formulas. */
         AV43Pgmname = "NotificacaoAgendadaWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV12OrderedBy ;
      private short AV18ManageFiltersExecutionStep ;
      private short AV33TFNotificacaoAgendadaStatus_Sel ;
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
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int AV25TFNotificacaoAgendadaDias ;
      private int AV26TFNotificacaoAgendadaDias_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int A898NotificacaoAgendadaId ;
      private int A901NotificacaoAgendadaDias ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV22TFNotificacaoAgendadaOrigem_Sels_Count ;
      private int AV28TFNotificacaoAgendadaMomentoEnvio_Sels_Count ;
      private int AV30TFNotificacaoAgendadaTipo_Sels_Count ;
      private int edtNotificacaoAgendadaId_Enabled ;
      private int edtNotificacaoAgendadaDescricao_Enabled ;
      private int edtNotificacaoAgendadaDias_Enabled ;
      private int AV35PageToGo ;
      private int AV44GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV36GridCurrentPage ;
      private long AV37GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_37_idx="0001" ;
      private string AV43Pgmname ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV39Display ;
      private string edtavDisplay_Internalname ;
      private string AV40Update ;
      private string edtavUpdate_Internalname ;
      private string AV41Delete ;
      private string edtavDelete_Internalname ;
      private string edtNotificacaoAgendadaId_Internalname ;
      private string cmbNotificacaoAgendadaOrigem_Internalname ;
      private string edtNotificacaoAgendadaDescricao_Internalname ;
      private string edtNotificacaoAgendadaDias_Internalname ;
      private string cmbNotificacaoAgendadaMomentoEnvio_Internalname ;
      private string cmbNotificacaoAgendadaTipo_Internalname ;
      private string cmbNotificacaoAgendadaStatus_Internalname ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string GXt_char2 ;
      private string GXt_char4 ;
      private string GXt_char5 ;
      private string GXt_char6 ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtNotificacaoAgendadaId_Jsonclick ;
      private string GXCCtl ;
      private string cmbNotificacaoAgendadaOrigem_Jsonclick ;
      private string edtNotificacaoAgendadaDescricao_Jsonclick ;
      private string edtNotificacaoAgendadaDias_Jsonclick ;
      private string cmbNotificacaoAgendadaMomentoEnvio_Jsonclick ;
      private string cmbNotificacaoAgendadaTipo_Jsonclick ;
      private string cmbNotificacaoAgendadaStatus_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
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
      private bool n901NotificacaoAgendadaDias ;
      private bool n902NotificacaoAgendadaMomentoEnvio ;
      private bool n903NotificacaoAgendadaTipo ;
      private bool A905NotificacaoAgendadaStatus ;
      private bool n905NotificacaoAgendadaStatus ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV21TFNotificacaoAgendadaOrigem_SelsJson ;
      private string AV27TFNotificacaoAgendadaMomentoEnvio_SelsJson ;
      private string AV29TFNotificacaoAgendadaTipo_SelsJson ;
      private string AV17ManageFiltersXml ;
      private string AV14FilterFullText ;
      private string AV23TFNotificacaoAgendadaDescricao ;
      private string AV24TFNotificacaoAgendadaDescricao_Sel ;
      private string AV38GridAppliedFilters ;
      private string A899NotificacaoAgendadaOrigem ;
      private string A900NotificacaoAgendadaDescricao ;
      private string A902NotificacaoAgendadaMomentoEnvio ;
      private string A903NotificacaoAgendadaTipo ;
      private string lV14FilterFullText ;
      private string lV23TFNotificacaoAgendadaDescricao ;
      private string AV42AuxText ;
      private IGxSession AV15Session ;
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
      private GXCombobox cmbNotificacaoAgendadaOrigem ;
      private GXCombobox cmbNotificacaoAgendadaMomentoEnvio ;
      private GXCombobox cmbNotificacaoAgendadaTipo ;
      private GXCombobox cmbNotificacaoAgendadaStatus ;
      private GxSimpleCollection<string> AV22TFNotificacaoAgendadaOrigem_Sels ;
      private GxSimpleCollection<string> AV28TFNotificacaoAgendadaMomentoEnvio_Sels ;
      private GxSimpleCollection<string> AV30TFNotificacaoAgendadaTipo_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV16ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV34DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H009G2_A905NotificacaoAgendadaStatus ;
      private bool[] H009G2_n905NotificacaoAgendadaStatus ;
      private string[] H009G2_A903NotificacaoAgendadaTipo ;
      private bool[] H009G2_n903NotificacaoAgendadaTipo ;
      private string[] H009G2_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] H009G2_n902NotificacaoAgendadaMomentoEnvio ;
      private int[] H009G2_A901NotificacaoAgendadaDias ;
      private bool[] H009G2_n901NotificacaoAgendadaDias ;
      private string[] H009G2_A900NotificacaoAgendadaDescricao ;
      private string[] H009G2_A899NotificacaoAgendadaOrigem ;
      private int[] H009G2_A898NotificacaoAgendadaId ;
      private long[] H009G3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notificacaoagendadaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009G2( IGxContext context ,
                                             string A899NotificacaoAgendadaOrigem ,
                                             GxSimpleCollection<string> AV22TFNotificacaoAgendadaOrigem_Sels ,
                                             string A902NotificacaoAgendadaMomentoEnvio ,
                                             GxSimpleCollection<string> AV28TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                             string A903NotificacaoAgendadaTipo ,
                                             GxSimpleCollection<string> AV30TFNotificacaoAgendadaTipo_Sels ,
                                             string AV14FilterFullText ,
                                             int AV22TFNotificacaoAgendadaOrigem_Sels_Count ,
                                             string AV24TFNotificacaoAgendadaDescricao_Sel ,
                                             string AV23TFNotificacaoAgendadaDescricao ,
                                             int AV25TFNotificacaoAgendadaDias ,
                                             int AV26TFNotificacaoAgendadaDias_To ,
                                             int AV28TFNotificacaoAgendadaMomentoEnvio_Sels_Count ,
                                             int AV30TFNotificacaoAgendadaTipo_Sels_Count ,
                                             short AV33TFNotificacaoAgendadaStatus_Sel ,
                                             string A900NotificacaoAgendadaDescricao ,
                                             int A901NotificacaoAgendadaDias ,
                                             bool A905NotificacaoAgendadaStatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " NotificacaoAgendadaStatus, NotificacaoAgendadaTipo, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaDias, NotificacaoAgendadaDescricao, NotificacaoAgendadaOrigem, NotificacaoAgendadaId";
         sFromString = " FROM NotificacaoAgendada";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( 'título a receber' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaOrigem = ( 'R')) or ( NotificacaoAgendadaDescricao like '%' || :lV14FilterFullText) or ( SUBSTR(TO_CHAR(NotificacaoAgendadaDias,'999999999'), 2) like '%' || :lV14FilterFullText) or ( 'antes' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'A')) or ( 'depois' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'D')) or ( 'email' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaTipo = ( 'E')) or ( 'sim' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaStatus = TRUE) or ( 'não' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaStatus = FALSE))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
         }
         if ( AV22TFNotificacaoAgendadaOrigem_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV22TFNotificacaoAgendadaOrigem_Sels, "NotificacaoAgendadaOrigem IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao)) ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao like :lV23TFNotificacaoAgendadaDescricao)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)) && ! ( StringUtil.StrCmp(AV24TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao = ( :AV24TFNotificacaoAgendadaDescricao_Sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from NotificacaoAgendadaDescricao))=0))");
         }
         if ( ! (0==AV25TFNotificacaoAgendadaDias) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias >= :AV25TFNotificacaoAgendadaDias)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (0==AV26TFNotificacaoAgendadaDias_To) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias <= :AV26TFNotificacaoAgendadaDias_To)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV28TFNotificacaoAgendadaMomentoEnvio_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFNotificacaoAgendadaMomentoEnvio_Sels, "NotificacaoAgendadaMomentoEnvio IN (", ")")+")");
         }
         if ( AV30TFNotificacaoAgendadaTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV30TFNotificacaoAgendadaTipo_Sels, "NotificacaoAgendadaTipo IN (", ")")+")");
         }
         if ( AV33TFNotificacaoAgendadaStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = TRUE)");
         }
         if ( AV33TFNotificacaoAgendadaStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = FALSE)");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaOrigem, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaOrigem DESC, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaDescricao, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaDescricao DESC, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaDias, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaDias DESC, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaMomentoEnvio DESC, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaTipo, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaTipo DESC, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaStatus, NotificacaoAgendadaId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaStatus DESC, NotificacaoAgendadaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY NotificacaoAgendadaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H009G3( IGxContext context ,
                                             string A899NotificacaoAgendadaOrigem ,
                                             GxSimpleCollection<string> AV22TFNotificacaoAgendadaOrigem_Sels ,
                                             string A902NotificacaoAgendadaMomentoEnvio ,
                                             GxSimpleCollection<string> AV28TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                             string A903NotificacaoAgendadaTipo ,
                                             GxSimpleCollection<string> AV30TFNotificacaoAgendadaTipo_Sels ,
                                             string AV14FilterFullText ,
                                             int AV22TFNotificacaoAgendadaOrigem_Sels_Count ,
                                             string AV24TFNotificacaoAgendadaDescricao_Sel ,
                                             string AV23TFNotificacaoAgendadaDescricao ,
                                             int AV25TFNotificacaoAgendadaDias ,
                                             int AV26TFNotificacaoAgendadaDias_To ,
                                             int AV28TFNotificacaoAgendadaMomentoEnvio_Sels_Count ,
                                             int AV30TFNotificacaoAgendadaTipo_Sels_Count ,
                                             short AV33TFNotificacaoAgendadaStatus_Sel ,
                                             string A900NotificacaoAgendadaDescricao ,
                                             int A901NotificacaoAgendadaDias ,
                                             bool A905NotificacaoAgendadaStatus ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[12];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM NotificacaoAgendada";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( 'título a receber' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaOrigem = ( 'R')) or ( NotificacaoAgendadaDescricao like '%' || :lV14FilterFullText) or ( SUBSTR(TO_CHAR(NotificacaoAgendadaDias,'999999999'), 2) like '%' || :lV14FilterFullText) or ( 'antes' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'A')) or ( 'depois' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'D')) or ( 'email' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaTipo = ( 'E')) or ( 'sim' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaStatus = TRUE) or ( 'não' like '%' || LOWER(:lV14FilterFullText) and NotificacaoAgendadaStatus = FALSE))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
         }
         if ( AV22TFNotificacaoAgendadaOrigem_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV22TFNotificacaoAgendadaOrigem_Sels, "NotificacaoAgendadaOrigem IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNotificacaoAgendadaDescricao)) ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao like :lV23TFNotificacaoAgendadaDescricao)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNotificacaoAgendadaDescricao_Sel)) && ! ( StringUtil.StrCmp(AV24TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao = ( :AV24TFNotificacaoAgendadaDescricao_Sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from NotificacaoAgendadaDescricao))=0))");
         }
         if ( ! (0==AV25TFNotificacaoAgendadaDias) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias >= :AV25TFNotificacaoAgendadaDias)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV26TFNotificacaoAgendadaDias_To) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias <= :AV26TFNotificacaoAgendadaDias_To)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV28TFNotificacaoAgendadaMomentoEnvio_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFNotificacaoAgendadaMomentoEnvio_Sels, "NotificacaoAgendadaMomentoEnvio IN (", ")")+")");
         }
         if ( AV30TFNotificacaoAgendadaTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV30TFNotificacaoAgendadaTipo_Sels, "NotificacaoAgendadaTipo IN (", ")")+")");
         }
         if ( AV33TFNotificacaoAgendadaStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = TRUE)");
         }
         if ( AV33TFNotificacaoAgendadaStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = FALSE)");
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
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
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
                     return conditional_H009G2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
               case 1 :
                     return conditional_H009G3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmH009G2;
          prmH009G2 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV23TFNotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("AV24TFNotificacaoAgendadaDescricao_Sel",GXType.VarChar,120,0) ,
          new ParDef("AV25TFNotificacaoAgendadaDias",GXType.Int32,9,0) ,
          new ParDef("AV26TFNotificacaoAgendadaDias_To",GXType.Int32,9,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009G3;
          prmH009G3 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV23TFNotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("AV24TFNotificacaoAgendadaDescricao_Sel",GXType.VarChar,120,0) ,
          new ParDef("AV25TFNotificacaoAgendadaDias",GXType.Int32,9,0) ,
          new ParDef("AV26TFNotificacaoAgendadaDias_To",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009G2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009G3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
