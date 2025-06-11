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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityww : GXDataArea
   {
      public secfunctionalityww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityww( IGxContext context )
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
         cmbSecFunctionalityType = new GXCombobox();
         chkSecFunctionalityActive = new GXCheckbox();
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
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
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
         AV29OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV30OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV85FilterFullText = GetPar( "FilterFullText");
         AV34ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV94Pgmname = GetPar( "Pgmname");
         AV41TFSecFunctionalityKey = GetPar( "TFSecFunctionalityKey");
         AV42TFSecFunctionalityKey_Sel = GetPar( "TFSecFunctionalityKey_Sel");
         AV45TFSecFunctionalityDescription = GetPar( "TFSecFunctionalityDescription");
         AV46TFSecFunctionalityDescription_Sel = GetPar( "TFSecFunctionalityDescription_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV81TFSecFunctionalityType_Sels);
         AV52TFSecParentFunctionalityDescription = GetPar( "TFSecParentFunctionalityDescription");
         AV53TFSecParentFunctionalityDescription_Sel = GetPar( "TFSecParentFunctionalityDescription_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
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
         PA2D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2D2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secfunctionalityww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV30OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV85FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV83GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV87GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV55DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV55DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY", AV41TFSecFunctionalityKey);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYKEY_SEL", AV42TFSecFunctionalityKey_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION", AV45TFSecFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYDESCRIPTION_SEL", AV46TFSecFunctionalityDescription_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSECFUNCTIONALITYTYPE_SELS", AV81TFSecFunctionalityType_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSECFUNCTIONALITYTYPE_SELS", AV81TFSecFunctionalityType_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSECPARENTFUNCTIONALITYDESCRIPTION", AV52TFSecParentFunctionalityDescription);
         GxWebStd.gx_hidden_field( context, "vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL", AV53TFSecParentFunctionalityDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV30OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV27GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV27GridState);
         }
         GxWebStd.gx_hidden_field( context, "vTFSECFUNCTIONALITYTYPE_SELSJSON", AV80TFSecFunctionalityType_SelsJson);
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
            WE2D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2D2( ) ;
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
         return formatLink("wwpbaseobjects.secfunctionalityww")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecFunctionalityWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Functionality" ;
      }

      protected void WB2D0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV85FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV85FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecFunctionalityWW.htm");
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
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV83GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV84GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV87GridAppliedFilters);
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV55DDO_TitleSettingsIcons);
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
         if ( wbEnd == 41 )
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

      protected void START2D2( )
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
         Form.Meta.addItem("description", " Functionality", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2D0( ) ;
      }

      protected void WS2D2( )
      {
         START2D2( ) ;
         EVT2D2( ) ;
      }

      protected void EVT2D2( )
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
                              E112D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E122D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E132D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E142D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E152D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E162D2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E172D2 ();
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
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              AV93Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV93Display);
                              AV11Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV11Update);
                              AV12Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV12Delete);
                              AV24UAViewChildren = cgiGet( edtavUaviewchildren_Internalname);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV24UAViewChildren)) ? AV103Uaviewchildren_GXI : context.convertURL( context.PathToRelativeUrl( AV24UAViewChildren))), !bGXsfl_41_Refreshing);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "SrcSet", context.GetImageSrcSet( AV24UAViewChildren), true);
                              A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A130SecFunctionalityKey = StringUtil.Upper( cgiGet( edtSecFunctionalityKey_Internalname));
                              n130SecFunctionalityKey = false;
                              A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
                              n135SecFunctionalityDescription = false;
                              cmbSecFunctionalityType.Name = cmbSecFunctionalityType_Internalname;
                              cmbSecFunctionalityType.CurrentValue = cgiGet( cmbSecFunctionalityType_Internalname);
                              A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbSecFunctionalityType_Internalname), "."), 18, MidpointRounding.ToEven));
                              n136SecFunctionalityType = false;
                              A129SecParentFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecParentFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n129SecParentFunctionalityId = false;
                              A138SecParentFunctionalityDescription = cgiGet( edtSecParentFunctionalityDescription_Internalname);
                              n138SecParentFunctionalityDescription = false;
                              A134SecFunctionalityActive = StringUtil.StrToBool( cgiGet( chkSecFunctionalityActive_Internalname));
                              n134SecFunctionalityActive = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E192D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E202D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV29OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV30OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV85FilterFullText) != 0 )
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

      protected void WE2D2( )
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

      protected void PA2D2( )
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
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV29OrderedBy ,
                                       bool AV30OrderedDsc ,
                                       string AV85FilterFullText ,
                                       short AV34ManageFiltersExecutionStep ,
                                       string AV94Pgmname ,
                                       string AV41TFSecFunctionalityKey ,
                                       string AV42TFSecFunctionalityKey_Sel ,
                                       string AV45TFSecFunctionalityDescription ,
                                       string AV46TFSecFunctionalityDescription_Sel ,
                                       GxSimpleCollection<short> AV81TFSecFunctionalityType_Sels ,
                                       string AV52TFSecParentFunctionalityDescription ,
                                       string AV53TFSecParentFunctionalityDescription_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", "")));
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
         RF2D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV94Pgmname = "WWPBaseObjects.SecFunctionalityWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF2D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E192D2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
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
            SubsflControlProps_412( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A136SecFunctionalityType ,
                                                 AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                                 AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                                 AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                                 AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                                 AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                                 AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                                 AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                                 AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                                 AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                                 A130SecFunctionalityKey ,
                                                 A135SecFunctionalityDescription ,
                                                 A138SecParentFunctionalityDescription ,
                                                 AV29OrderedBy ,
                                                 AV30OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
            lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
            lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
            lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
            /* Using cursor H002D2 */
            pr_default.execute(0, new Object[] {lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A134SecFunctionalityActive = H002D2_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = H002D2_n134SecFunctionalityActive[0];
               A138SecParentFunctionalityDescription = H002D2_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H002D2_n138SecParentFunctionalityDescription[0];
               A129SecParentFunctionalityId = H002D2_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H002D2_n129SecParentFunctionalityId[0];
               A136SecFunctionalityType = H002D2_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H002D2_n136SecFunctionalityType[0];
               A135SecFunctionalityDescription = H002D2_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H002D2_n135SecFunctionalityDescription[0];
               A130SecFunctionalityKey = H002D2_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H002D2_n130SecFunctionalityKey[0];
               A128SecFunctionalityId = H002D2_A128SecFunctionalityId[0];
               A138SecParentFunctionalityDescription = H002D2_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H002D2_n138SecParentFunctionalityDescription[0];
               /* Execute user event: Grid.Load */
               E202D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB2D0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2D2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV94Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV94Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
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
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A136SecFunctionalityType ,
                                              AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                              AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                              AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                              AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                              AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                              AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                              AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels.Count ,
                                              AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                              AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                              A130SecFunctionalityKey ,
                                              A135SecFunctionalityDescription ,
                                              A138SecParentFunctionalityDescription ,
                                              AV29OrderedBy ,
                                              AV30OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext), "%", "");
         lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = StringUtil.Concat( StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey), "%", "");
         lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription), "%", "");
         lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = StringUtil.Concat( StringUtil.RTrim( AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription), "%", "");
         /* Using cursor H002D3 */
         pr_default.execute(1, new Object[] {lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext, lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey, AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription, AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription, AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel});
         GRID_nRecordCount = H002D3_AGRID_nRecordCount[0];
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
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV29OrderedBy, AV30OrderedDsc, AV85FilterFullText, AV34ManageFiltersExecutionStep, AV94Pgmname, AV41TFSecFunctionalityKey, AV42TFSecFunctionalityKey_Sel, AV45TFSecFunctionalityDescription, AV46TFSecFunctionalityDescription_Sel, AV81TFSecFunctionalityType_Sels, AV52TFSecParentFunctionalityDescription, AV53TFSecParentFunctionalityDescription_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV94Pgmname = "WWPBaseObjects.SecFunctionalityWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         chkSecFunctionalityActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV55DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            AV83GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV84GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV87GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV85FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV85FilterFullText", AV85FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV29OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV30OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV85FilterFullText) != 0 )
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
         E182D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182D2( )
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
         Form.Caption = " Functionality";
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
         if ( AV29OrderedBy < 1 )
         {
            AV29OrderedBy = 1;
            AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV55DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV55DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E192D2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV79WWPContext) ;
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV83GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV83GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV83GridCurrentPage), 10, 0));
         AV84GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV84GridPageCount", StringUtil.LTrimStr( (decimal)(AV84GridPageCount), 10, 0));
         GXt_char2 = AV87GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV94Pgmname, out  GXt_char2) ;
         AV87GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV87GridAppliedFilters", AV87GridAppliedFilters);
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = AV85FilterFullText;
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = AV41TFSecFunctionalityKey;
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = AV42TFSecFunctionalityKey_Sel;
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = AV45TFSecFunctionalityDescription;
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = AV46TFSecFunctionalityDescription_Sel;
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = AV81TFSecFunctionalityType_Sels;
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = AV52TFSecParentFunctionalityDescription;
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = AV53TFSecParentFunctionalityDescription_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridState", AV27GridState);
      }

      protected void E122D2( )
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
            AV82PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV82PageToGo) ;
         }
      }

      protected void E132D2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142D2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV29OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
            AV30OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV30OrderedDsc", AV30OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityKey") == 0 )
            {
               AV41TFSecFunctionalityKey = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFSecFunctionalityKey", AV41TFSecFunctionalityKey);
               AV42TFSecFunctionalityKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFSecFunctionalityKey_Sel", AV42TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityDescription") == 0 )
            {
               AV45TFSecFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV45TFSecFunctionalityDescription", AV45TFSecFunctionalityDescription);
               AV46TFSecFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV46TFSecFunctionalityDescription_Sel", AV46TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecFunctionalityType") == 0 )
            {
               AV80TFSecFunctionalityType_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFSecFunctionalityType_SelsJson", AV80TFSecFunctionalityType_SelsJson);
               AV81TFSecFunctionalityType_Sels.FromJSonString(StringUtil.StringReplace( AV80TFSecFunctionalityType_SelsJson, "\"", ""), null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecParentFunctionalityDescription") == 0 )
            {
               AV52TFSecParentFunctionalityDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFSecParentFunctionalityDescription", AV52TFSecParentFunctionalityDescription);
               AV53TFSecParentFunctionalityDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFSecParentFunctionalityDescription_Sel", AV53TFSecParentFunctionalityDescription_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV81TFSecFunctionalityType_Sels", AV81TFSecFunctionalityType_Sels);
      }

      private void E202D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV93Display = "<i class=\"fa fa-search\"></i>";
         AssignAttri("", false, edtavDisplay_Internalname, AV93Display);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavDisplay_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV11Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV11Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavUpdate_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV12Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV12Delete);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtavDelete_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         edtavUaviewchildren_gximage = "ActionDisplay";
         AV24UAViewChildren = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( ));
         AssignAttri("", false, edtavUaviewchildren_Internalname, AV24UAViewChildren);
         AV103Uaviewchildren_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( )), context);
         edtavUaviewchildren_Tooltiptext = "View Actions, Tabs and Modes";
         GXt_boolean3 = AV15TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secfunctionalityhaschildren(context ).execute(  A128SecFunctionalityId, out  GXt_boolean3) ;
         AV15TempBoolean = GXt_boolean3;
         if ( AV15TempBoolean )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.secfunctionalityfilterparentww"+UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
            edtavUaviewchildren_Link = formatLink("wwpbaseobjects.secfunctionalityfilterparentww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavUaviewchildren_Class = "ActionBaseColorAttribute";
         }
         else
         {
            edtavUaviewchildren_Link = "";
            edtavUaviewchildren_Class = "Invisible";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A128SecFunctionalityId,10,0));
         edtSecFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A129SecParentFunctionalityId,10,0));
         edtSecParentFunctionalityDescription_Link = formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 41;
         }
         sendrow_412( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
         {
            DoAjaxLoad(41, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112D2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecFunctionalityWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV94Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecFunctionalityWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV34ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV34ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV34ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV35ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecFunctionalityWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV35ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV35ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV94Pgmname+"GridState",  AV35ManageFiltersXml) ;
               AV27GridState.FromXml(AV35ManageFiltersXml, null, "", "");
               AV29OrderedBy = AV27GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
               AV30OrderedDsc = AV27GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV30OrderedDsc", AV30OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridState", AV27GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV81TFSecFunctionalityType_Sels", AV81TFSecFunctionalityType_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E152D2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secfunctionality"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wwpbaseobjects.secfunctionality") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E162D2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.secfunctionalitywwexport(context ).execute( out  AV32ExcelFilename, out  AV33ErrorMessage) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridState", AV27GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV81TFSecFunctionalityType_Sels", AV81TFSecFunctionalityType_Sels);
      }

      protected void E172D2( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("wwpbaseobjects.secfunctionalitywwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27GridState", AV27GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV81TFSecFunctionalityType_Sels", AV81TFSecFunctionalityType_Sels);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV29OrderedBy), 4, 0))+":"+(AV30OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecFunctionalityWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV85FilterFullText = "";
         AssignAttri("", false, "AV85FilterFullText", AV85FilterFullText);
         AV41TFSecFunctionalityKey = "";
         AssignAttri("", false, "AV41TFSecFunctionalityKey", AV41TFSecFunctionalityKey);
         AV42TFSecFunctionalityKey_Sel = "";
         AssignAttri("", false, "AV42TFSecFunctionalityKey_Sel", AV42TFSecFunctionalityKey_Sel);
         AV45TFSecFunctionalityDescription = "";
         AssignAttri("", false, "AV45TFSecFunctionalityDescription", AV45TFSecFunctionalityDescription);
         AV46TFSecFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV46TFSecFunctionalityDescription_Sel", AV46TFSecFunctionalityDescription_Sel);
         AV81TFSecFunctionalityType_Sels = (GxSimpleCollection<short>)(new GxSimpleCollection<short>());
         AV52TFSecParentFunctionalityDescription = "";
         AssignAttri("", false, "AV52TFSecParentFunctionalityDescription", AV52TFSecParentFunctionalityDescription);
         AV53TFSecParentFunctionalityDescription_Sel = "";
         AssignAttri("", false, "AV53TFSecParentFunctionalityDescription_Sel", AV53TFSecParentFunctionalityDescription_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV13Session.Get(AV94Pgmname+"GridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV94Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV13Session.Get(AV94Pgmname+"GridState"), null, "", "");
         }
         AV29OrderedBy = AV27GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV29OrderedBy", StringUtil.LTrimStr( (decimal)(AV29OrderedBy), 4, 0));
         AV30OrderedDsc = AV27GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV30OrderedDsc", AV30OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV27GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV27GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV27GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV104GXV1 = 1;
         while ( AV104GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV104GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV85FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV85FilterFullText", AV85FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY") == 0 )
            {
               AV41TFSecFunctionalityKey = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFSecFunctionalityKey", AV41TFSecFunctionalityKey);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYKEY_SEL") == 0 )
            {
               AV42TFSecFunctionalityKey_Sel = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFSecFunctionalityKey_Sel", AV42TFSecFunctionalityKey_Sel);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV45TFSecFunctionalityDescription = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFSecFunctionalityDescription", AV45TFSecFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV46TFSecFunctionalityDescription_Sel = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFSecFunctionalityDescription_Sel", AV46TFSecFunctionalityDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECFUNCTIONALITYTYPE_SEL") == 0 )
            {
               AV80TFSecFunctionalityType_SelsJson = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFSecFunctionalityType_SelsJson", AV80TFSecFunctionalityType_SelsJson);
               AV81TFSecFunctionalityType_Sels.FromJSonString(AV80TFSecFunctionalityType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION") == 0 )
            {
               AV52TFSecParentFunctionalityDescription = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFSecParentFunctionalityDescription", AV52TFSecParentFunctionalityDescription);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFSECPARENTFUNCTIONALITYDESCRIPTION_SEL") == 0 )
            {
               AV53TFSecParentFunctionalityDescription_Sel = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFSecParentFunctionalityDescription_Sel", AV53TFSecParentFunctionalityDescription_Sel);
            }
            AV104GXV1 = (int)(AV104GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecFunctionalityKey_Sel)),  AV42TFSecFunctionalityKey_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFSecFunctionalityDescription_Sel)),  AV46TFSecFunctionalityDescription_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFSecParentFunctionalityDescription_Sel)),  AV53TFSecParentFunctionalityDescription_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+((AV81TFSecFunctionalityType_Sels.Count==0) ? "" : AV80TFSecFunctionalityType_SelsJson)+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecFunctionalityKey)),  AV41TFSecFunctionalityKey, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSecFunctionalityDescription)),  AV45TFSecFunctionalityDescription, out  GXt_char5) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecParentFunctionalityDescription)),  AV52TFSecParentFunctionalityDescription, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"||"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV27GridState.FromXml(AV13Session.Get(AV94Pgmname+"GridState"), null, "", "");
         AV27GridState.gxTpr_Orderedby = AV29OrderedBy;
         AV27GridState.gxTpr_Ordereddsc = AV30OrderedDsc;
         AV27GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV27GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85FilterFullText)),  0,  AV85FilterFullText,  AV85FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV27GridState,  "TFSECFUNCTIONALITYKEY",  "Key",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecFunctionalityKey)),  0,  AV41TFSecFunctionalityKey,  AV41TFSecFunctionalityKey,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecFunctionalityKey_Sel)),  AV42TFSecFunctionalityKey_Sel,  AV42TFSecFunctionalityKey_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV27GridState,  "TFSECFUNCTIONALITYDESCRIPTION",  "Description",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSecFunctionalityDescription)),  0,  AV45TFSecFunctionalityDescription,  AV45TFSecFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFSecFunctionalityDescription_Sel)),  AV46TFSecFunctionalityDescription_Sel,  AV46TFSecFunctionalityDescription_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV27GridState,  "TFSECFUNCTIONALITYTYPE_SEL",  "Type",  !(AV81TFSecFunctionalityType_Sels.Count==0),  0,  AV81TFSecFunctionalityType_Sels.ToJSonString(false),  ((AV81TFSecFunctionalityType_Sels.Count==1) ? StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV81TFSecFunctionalityType_Sels.GetNumeric(1)), 10, 0)), "Mode", "Action", "Tab", "Object", "Attribute", "", "", "", "") : "Vários valores"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV27GridState,  "TFSECPARENTFUNCTIONALITYDESCRIPTION",  "Parent Functionality",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecParentFunctionalityDescription)),  0,  AV52TFSecParentFunctionalityDescription,  AV52TFSecParentFunctionalityDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFSecParentFunctionalityDescription_Sel)),  AV53TFSecParentFunctionalityDescription_Sel,  AV53TFSecParentFunctionalityDescription_Sel) ;
         AV27GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV27GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV94Pgmname+"GridState",  AV27GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV94Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecFunctionality";
         AV13Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      protected void S182( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
      }

      protected void S192( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
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
         PA2D2( ) ;
         WS2D2( ) ;
         WE2D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019231748", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secfunctionalityww.js", "?202561019231749", false, true);
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

      protected void SubsflControlProps_412( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_41_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_41_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_41_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_41_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_41_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_41_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_41_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_41_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_41_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_fel_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_41_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_41_fel_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_41_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_41_fel_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_41_fel_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_41_fel_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_41_fel_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         WB2D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_41_idx + "',41)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV93Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_41_idx + "',41)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV11Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_41_idx + "',41)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV12Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = edtavUaviewchildren_Class + " " + ((StringUtil.StrCmp(edtavUaviewchildren_gximage, "")==0) ? "" : "GX_Image_"+edtavUaviewchildren_gximage+"_Class");
            StyleString = "";
            AV24UAViewChildren_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV24UAViewChildren))&&String.IsNullOrEmpty(StringUtil.RTrim( AV103Uaviewchildren_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV24UAViewChildren)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24UAViewChildren)) ? AV103Uaviewchildren_GXI : context.PathToRelativeUrl( AV24UAViewChildren));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaviewchildren_Internalname,(string)sImgUrl,(string)edtavUaviewchildren_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUaviewchildren_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV24UAViewChildren_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A130SecFunctionalityKey,StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecFunctionalityType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_41_idx;
               cmbSecFunctionalityType.Name = GXCCtl;
               cmbSecFunctionalityType.WebTags = "";
               cmbSecFunctionalityType.addItem("1", "Mode", 0);
               cmbSecFunctionalityType.addItem("2", "Action", 0);
               cmbSecFunctionalityType.addItem("3", "Tab", 0);
               cmbSecFunctionalityType.addItem("4", "Object", 0);
               cmbSecFunctionalityType.addItem("5", "Attribute", 0);
               if ( cmbSecFunctionalityType.ItemCount > 0 )
               {
                  A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
                  n136SecFunctionalityType = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecFunctionalityType,(string)cmbSecFunctionalityType_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0)),(short)1,(string)cmbSecFunctionalityType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn hidden-xs",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbSecFunctionalityType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0));
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_41_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescription_Internalname,(string)A138SecParentFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecParentFunctionalityDescription_Link,(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_41_idx;
            chkSecFunctionalityActive.Name = GXCCtl;
            chkSecFunctionalityActive.WebTags = "";
            chkSecFunctionalityActive.Caption = "";
            AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_41_Refreshing);
            chkSecFunctionalityActive.CheckedValue = "false";
            A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
            n134SecFunctionalityActive = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSecFunctionalityActive_Internalname,StringUtil.BoolToStr( A134SecFunctionalityActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            send_integrity_lvl_hashes2D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_41_idx;
         cmbSecFunctionalityType.Name = GXCCtl;
         cmbSecFunctionalityType.WebTags = "";
         cmbSecFunctionalityType.addItem("1", "Mode", 0);
         cmbSecFunctionalityType.addItem("2", "Action", 0);
         cmbSecFunctionalityType.addItem("3", "Tab", 0);
         cmbSecFunctionalityType.addItem("4", "Object", 0);
         cmbSecFunctionalityType.addItem("5", "Attribute", 0);
         if ( cmbSecFunctionalityType.ItemCount > 0 )
         {
            A136SecFunctionalityType = (short)(Math.Round(NumberUtil.Val( cmbSecFunctionalityType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A136SecFunctionalityType), 2, 0))), "."), 18, MidpointRounding.ToEven));
            n136SecFunctionalityType = false;
         }
         GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_41_idx;
         chkSecFunctionalityActive.Name = GXCCtl;
         chkSecFunctionalityActive.WebTags = "";
         chkSecFunctionalityActive.Caption = "";
         AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_41_Refreshing);
         chkSecFunctionalityActive.CheckedValue = "false";
         A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
         n134SecFunctionalityActive = false;
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"41\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavUaviewchildren_Class+" "+((StringUtil.StrCmp(edtavUaviewchildren_gximage, "")==0) ? "" : "GX_Image_"+edtavUaviewchildren_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Key") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Description") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality Id  ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Parent Functionality") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Is Active?") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV93Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV11Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV24UAViewChildren));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUaviewchildren_Class));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUaviewchildren_Link));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUaviewchildren_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A130SecFunctionalityKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135SecFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A138SecParentFunctionalityDescription));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecParentFunctionalityDescription_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A134SecFunctionalityActive)));
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
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN";
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE";
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID";
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION";
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
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
         chkSecFunctionalityActive.Caption = "";
         edtSecParentFunctionalityDescription_Jsonclick = "";
         edtSecParentFunctionalityDescription_Link = "";
         edtSecParentFunctionalityId_Jsonclick = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Link = "";
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         edtavUaviewchildren_gximage = "";
         edtavUaviewchildren_Class = "ActionBaseColorAttribute";
         edtavUaviewchildren_Link = "";
         edtavUaviewchildren_Tooltiptext = "View Actions, Tabs and Modes";
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
         chkSecFunctionalityActive.Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Fixedcolumns = ";L;L;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecFunctionalityWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||1:Mode,2:Action,3:Tab,4:Object,5:Attribute|";
         Ddo_grid_Allowmultipleselection = "||T|";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character||Character";
         Ddo_grid_Includefilter = "T|T||T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "5:SecFunctionalityKey|6:SecFunctionalityDescription|7:SecFunctionalityType|9:SecParentFunctionalityDescription";
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
         Form.Caption = " Functionality";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E122D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E132D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E142D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E202D2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A129SecParentFunctionalityId","fld":"SECPARENTFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV93Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"AV11Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV12Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"AV24UAViewChildren","fld":"vUAVIEWCHILDREN","type":"bits"},{"av":"edtavUaviewchildren_Tooltiptext","ctrl":"vUAVIEWCHILDREN","prop":"Tooltiptext"},{"av":"edtavUaviewchildren_Link","ctrl":"vUAVIEWCHILDREN","prop":"Link"},{"av":"edtavUaviewchildren_Class","ctrl":"vUAVIEWCHILDREN","prop":"Class"},{"av":"edtSecFunctionalityDescription_Link","ctrl":"SECFUNCTIONALITYDESCRIPTION","prop":"Link"},{"av":"edtSecParentFunctionalityDescription_Link","ctrl":"SECPARENTFUNCTIONALITYDESCRIPTION","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E112D2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV83GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV84GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV87GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV38ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E152D2","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E162D2","iparms":[{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E172D2","iparms":[{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV27GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV30OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV85FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV34ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV94Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV41TFSecFunctionalityKey","fld":"vTFSECFUNCTIONALITYKEY","pic":"@!","type":"svchar"},{"av":"AV42TFSecFunctionalityKey_Sel","fld":"vTFSECFUNCTIONALITYKEY_SEL","pic":"@!","type":"svchar"},{"av":"AV45TFSecFunctionalityDescription","fld":"vTFSECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV46TFSecFunctionalityDescription_Sel","fld":"vTFSECFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"AV81TFSecFunctionalityType_Sels","fld":"vTFSECFUNCTIONALITYTYPE_SELS","type":""},{"av":"AV52TFSecParentFunctionalityDescription","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"AV53TFSecParentFunctionalityDescription_Sel","fld":"vTFSECPARENTFUNCTIONALITYDESCRIPTION_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV80TFSecFunctionalityType_SelsJson","fld":"vTFSECFUNCTIONALITYTYPE_SELSJSON","type":"vchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("VALID_SECPARENTFUNCTIONALITYID","""{"handler":"Valid_Secparentfunctionalityid","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Secfunctionalityactive","iparms":[]}""");
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
         AV85FilterFullText = "";
         AV94Pgmname = "";
         AV41TFSecFunctionalityKey = "";
         AV42TFSecFunctionalityKey_Sel = "";
         AV45TFSecFunctionalityDescription = "";
         AV46TFSecFunctionalityDescription_Sel = "";
         AV81TFSecFunctionalityType_Sels = new GxSimpleCollection<short>();
         AV52TFSecParentFunctionalityDescription = "";
         AV53TFSecParentFunctionalityDescription_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV87GridAppliedFilters = "";
         AV55DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV80TFSecFunctionalityType_SelsJson = "";
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV93Display = "";
         AV11Update = "";
         AV12Delete = "";
         AV24UAViewChildren = "";
         AV103Uaviewchildren_GXI = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels = new GxSimpleCollection<short>();
         lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext = "";
         AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel = "";
         AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey = "";
         AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel = "";
         AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription = "";
         AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel = "";
         AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription = "";
         H002D2_A134SecFunctionalityActive = new bool[] {false} ;
         H002D2_n134SecFunctionalityActive = new bool[] {false} ;
         H002D2_A138SecParentFunctionalityDescription = new string[] {""} ;
         H002D2_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H002D2_A129SecParentFunctionalityId = new long[1] ;
         H002D2_n129SecParentFunctionalityId = new bool[] {false} ;
         H002D2_A136SecFunctionalityType = new short[1] ;
         H002D2_n136SecFunctionalityType = new bool[] {false} ;
         H002D2_A135SecFunctionalityDescription = new string[] {""} ;
         H002D2_n135SecFunctionalityDescription = new bool[] {false} ;
         H002D2_A130SecFunctionalityKey = new string[] {""} ;
         H002D2_n130SecFunctionalityKey = new bool[] {false} ;
         H002D2_A128SecFunctionalityId = new long[1] ;
         H002D3_AGRID_nRecordCount = new long[1] ;
         AV7HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV79WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV35ManageFiltersXml = "";
         AV32ExcelFilename = "";
         AV33ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV13Session = context.GetSession();
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityww__default(),
            new Object[][] {
                new Object[] {
               H002D2_A134SecFunctionalityActive, H002D2_n134SecFunctionalityActive, H002D2_A138SecParentFunctionalityDescription, H002D2_n138SecParentFunctionalityDescription, H002D2_A129SecParentFunctionalityId, H002D2_n129SecParentFunctionalityId, H002D2_A136SecFunctionalityType, H002D2_n136SecFunctionalityType, H002D2_A135SecFunctionalityDescription, H002D2_n135SecFunctionalityDescription,
               H002D2_A130SecFunctionalityKey, H002D2_n130SecFunctionalityKey, H002D2_A128SecFunctionalityId
               }
               , new Object[] {
               H002D3_AGRID_nRecordCount
               }
            }
         );
         AV94Pgmname = "WWPBaseObjects.SecFunctionalityWW";
         /* GeneXus formulas. */
         AV94Pgmname = "WWPBaseObjects.SecFunctionalityWW";
         edtavDisplay_Enabled = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV29OrderedBy ;
      private short AV34ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A136SecFunctionalityType ;
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
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecParentFunctionalityDescription_Enabled ;
      private int AV82PageToGo ;
      private int AV104GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV83GridCurrentPage ;
      private long AV84GridPageCount ;
      private long A128SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
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
      private string sGXsfl_41_idx="0001" ;
      private string AV94Pgmname ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV93Display ;
      private string edtavDisplay_Internalname ;
      private string AV11Update ;
      private string edtavUpdate_Internalname ;
      private string AV12Delete ;
      private string edtavDelete_Internalname ;
      private string edtavUaviewchildren_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityDescription_Internalname ;
      private string chkSecFunctionalityActive_Internalname ;
      private string edtavDisplay_Link ;
      private string GXEncryptionTmp ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtavUaviewchildren_gximage ;
      private string edtavUaviewchildren_Tooltiptext ;
      private string edtavUaviewchildren_Link ;
      private string edtavUaviewchildren_Class ;
      private string edtSecFunctionalityDescription_Link ;
      private string edtSecParentFunctionalityDescription_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string sImgUrl ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string GXCCtl ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecParentFunctionalityDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV30OrderedDsc ;
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
      private bool bGXsfl_41_Refreshing=false ;
      private bool n130SecFunctionalityKey ;
      private bool n135SecFunctionalityDescription ;
      private bool n136SecFunctionalityType ;
      private bool n129SecParentFunctionalityId ;
      private bool n138SecParentFunctionalityDescription ;
      private bool A134SecFunctionalityActive ;
      private bool n134SecFunctionalityActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV15TempBoolean ;
      private bool GXt_boolean3 ;
      private bool AV24UAViewChildren_IsBlob ;
      private string AV80TFSecFunctionalityType_SelsJson ;
      private string AV35ManageFiltersXml ;
      private string AV85FilterFullText ;
      private string AV41TFSecFunctionalityKey ;
      private string AV42TFSecFunctionalityKey_Sel ;
      private string AV45TFSecFunctionalityDescription ;
      private string AV46TFSecFunctionalityDescription_Sel ;
      private string AV52TFSecParentFunctionalityDescription ;
      private string AV53TFSecParentFunctionalityDescription_Sel ;
      private string AV87GridAppliedFilters ;
      private string AV103Uaviewchildren_GXI ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ;
      private string AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ;
      private string AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ;
      private string AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ;
      private string AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ;
      private string AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ;
      private string AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ;
      private string AV32ExcelFilename ;
      private string AV33ErrorMessage ;
      private string AV24UAViewChildren ;
      private IGxSession AV13Session ;
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
      private GXCombobox cmbSecFunctionalityType ;
      private GXCheckbox chkSecFunctionalityActive ;
      private GxSimpleCollection<short> AV81TFSecFunctionalityType_Sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV55DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GxSimpleCollection<short> AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ;
      private IDataStoreProvider pr_default ;
      private bool[] H002D2_A134SecFunctionalityActive ;
      private bool[] H002D2_n134SecFunctionalityActive ;
      private string[] H002D2_A138SecParentFunctionalityDescription ;
      private bool[] H002D2_n138SecParentFunctionalityDescription ;
      private long[] H002D2_A129SecParentFunctionalityId ;
      private bool[] H002D2_n129SecParentFunctionalityId ;
      private short[] H002D2_A136SecFunctionalityType ;
      private bool[] H002D2_n136SecFunctionalityType ;
      private string[] H002D2_A135SecFunctionalityDescription ;
      private bool[] H002D2_n135SecFunctionalityDescription ;
      private string[] H002D2_A130SecFunctionalityKey ;
      private bool[] H002D2_n130SecFunctionalityKey ;
      private long[] H002D2_A128SecFunctionalityId ;
      private long[] H002D3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV79WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secfunctionalityww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002D2( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV29OrderedBy ,
                                             bool AV30OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey, T1.SecFunctionalityId";
         sFromString = " FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctiona)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctiona))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         if ( ( AV29OrderedBy == 1 ) && ! AV30OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV29OrderedBy == 1 ) && ( AV30OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV29OrderedBy == 2 ) && ! AV30OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityKey";
         }
         else if ( ( AV29OrderedBy == 2 ) && ( AV30OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV29OrderedBy == 3 ) && ! AV30OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityType, T1.SecFunctionalityId";
         }
         else if ( ( AV29OrderedBy == 3 ) && ( AV30OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityType DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV29OrderedBy == 4 ) && ! AV30OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV29OrderedBy == 4 ) && ( AV30OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H002D3( IGxContext context ,
                                             short A136SecFunctionalityType ,
                                             GxSimpleCollection<short> AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels ,
                                             string AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext ,
                                             string AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel ,
                                             string AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey ,
                                             string AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel ,
                                             string AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription ,
                                             int AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count ,
                                             string AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel ,
                                             string AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription ,
                                             string A130SecFunctionalityKey ,
                                             string A135SecFunctionalityDescription ,
                                             string A138SecParentFunctionalityDescription ,
                                             short AV29OrderedBy ,
                                             bool AV30OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[14];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.SecFunctionalityKey like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( T1.SecFunctionalityDescription like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) or ( 'mode' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 1) or ( 'action' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 2) or ( 'tab' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 3) or ( 'object' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 4) or ( 'attribute' like '%' || LOWER(:lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext) and T1.SecFunctionalityType = 5) or ( T2.SecFunctionalityDescription like '%' || :lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext))");
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey like :lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel)) && ! ( StringUtil.StrCmp(AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey = ( :AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityKey IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription like :lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription = ( :AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T1.SecFunctionalityDescription))=0))");
         }
         if ( AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV100Wwpbaseobjects_secfunctionalitywwds_6_tfsecfunctionalitytype_sels, "T1.SecFunctionalityType IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctionalitydescription)) ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription like :lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctiona)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel)) && ! ( StringUtil.StrCmp(AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription = ( :AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctiona))");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( StringUtil.StrCmp(AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctionalitydescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecFunctionalityDescription IS NULL or (char_length(trim(trailing ' ' from T2.SecFunctionalityDescription))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV29OrderedBy == 1 ) && ! AV30OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 1 ) && ( AV30OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 2 ) && ! AV30OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 2 ) && ( AV30OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 3 ) && ! AV30OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 3 ) && ( AV30OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 4 ) && ! AV30OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV29OrderedBy == 4 ) && ( AV30OrderedDsc ) )
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
                     return conditional_H002D2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H002D3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmH002D2;
          prmH002D2 = new Object[] {
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctiona",GXType.VarChar,100,0) ,
          new ParDef("AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctiona",GXType.VarChar,100,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002D3;
          prmH002D3 = new Object[] {
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wwpbaseobjects_secfunctionalitywwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV96Wwpbaseobjects_secfunctionalitywwds_2_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("AV97Wwpbaseobjects_secfunctionalitywwds_3_tfsecfunctionalitykey",GXType.VarChar,100,0) ,
          new ParDef("lV98Wwpbaseobjects_secfunctionalitywwds_4_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("AV99Wwpbaseobjects_secfunctionalitywwds_5_tfsecfunctionalitydes",GXType.VarChar,100,0) ,
          new ParDef("lV101Wwpbaseobjects_secfunctionalitywwds_7_tfsecparentfunctiona",GXType.VarChar,100,0) ,
          new ParDef("AV102Wwpbaseobjects_secfunctionalitywwds_8_tfsecparentfunctiona",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
