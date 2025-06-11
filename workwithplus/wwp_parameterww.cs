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
namespace GeneXus.Programs.workwithplus {
   public class wwp_parameterww : GXDataArea
   {
      public wwp_parameterww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_parameterww( IGxContext context )
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
         AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV17OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV19FilterFullText = GetPar( "FilterFullText");
         AV29ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV47Pgmname = GetPar( "Pgmname");
         AV30TFWWPParameterKey = GetPar( "TFWWPParameterKey");
         AV31TFWWPParameterKey_Sel = GetPar( "TFWWPParameterKey_Sel");
         AV32TFWWPParameterCategory = GetPar( "TFWWPParameterCategory");
         AV33TFWWPParameterCategory_Sel = GetPar( "TFWWPParameterCategory_Sel");
         AV34TFWWPParameterDescription = GetPar( "TFWWPParameterDescription");
         AV35TFWWPParameterDescription_Sel = GetPar( "TFWWPParameterDescription_Sel");
         AV36TFWWPParameterValueTrimmed = GetPar( "TFWWPParameterValueTrimmed");
         AV37TFWWPParameterValueTrimmed_Sel = GetPar( "TFWWPParameterValueTrimmed_Sel");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
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
         PA0P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0P2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("workwithplus.wwp_parameterww") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV17OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV19FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV27ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV8GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERKEY", AV30TFWWPParameterKey);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERKEY_SEL", AV31TFWWPParameterKey_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERCATEGORY", AV32TFWWPParameterCategory);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERCATEGORY_SEL", AV33TFWWPParameterCategory_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERDESCRIPTION", AV34TFWWPParameterDescription);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERDESCRIPTION_SEL", AV35TFWWPParameterDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERVALUETRIMMED", AV36TFWWPParameterValueTrimmed);
         GxWebStd.gx_hidden_field( context, "vTFWWPPARAMETERVALUETRIMMED_SEL", AV37TFWWPParameterValueTrimmed_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV17OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "WWPPARAMETERDISABLEDELETE", A5WWPParameterDisableDelete);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV14GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV14GridState);
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPPARAMETERVALUE", A2WWPParameterValue);
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
            WE0P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0P2( ) ;
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
         return formatLink("workwithplus.wwp_parameterww")  ;
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.WWP_ParameterWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parâmetro" ;
      }

      protected void WB0P0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_ParameterWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_ParameterWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/WWP_ParameterWW.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV27ManageFiltersData);
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
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV19FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV19FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WorkWithPlus/WWP_ParameterWW.htm");
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV40GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV41GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV8GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
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

      protected void START0P2( )
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
         Form.Meta.addItem("description", "Parâmetro", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0P0( ) ;
      }

      protected void WS0P2( )
      {
         START0P2( ) ;
         EVT0P2( ) ;
      }

      protected void EVT0P2( )
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
                              E110P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E120P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E130P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E140P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E150P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E160P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E170P2 ();
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
                              AV45Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV45Update);
                              AV46Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
                              A1WWPParameterKey = cgiGet( edtWWPParameterKey_Internalname);
                              A3WWPParameterCategory = cgiGet( edtWWPParameterCategory_Internalname);
                              A4WWPParameterDescription = cgiGet( edtWWPParameterDescription_Internalname);
                              A6WWPParameterValueTrimmed = cgiGet( edtWWPParameterValueTrimmed_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E190P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E200P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV16OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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

      protected void WE0P2( )
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

      protected void PA0P2( )
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
                                       short AV16OrderedBy ,
                                       bool AV17OrderedDsc ,
                                       string AV19FilterFullText ,
                                       short AV29ManageFiltersExecutionStep ,
                                       string AV47Pgmname ,
                                       string AV30TFWWPParameterKey ,
                                       string AV31TFWWPParameterKey_Sel ,
                                       string AV32TFWWPParameterCategory ,
                                       string AV33TFWWPParameterCategory_Sel ,
                                       string AV34TFWWPParameterDescription ,
                                       string AV35TFWWPParameterDescription_Sel ,
                                       string AV36TFWWPParameterValueTrimmed ,
                                       string AV37TFWWPParameterValueTrimmed_Sel )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_WWPPARAMETERKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A1WWPParameterKey, "")), context));
         GxWebStd.gx_hidden_field( context, "WWPPARAMETERKEY", A1WWPParameterKey);
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
         RF0P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV47Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected void RF0P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E190P2 ();
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
                                                 AV48Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                                 AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                                 AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                                 AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                                 AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                                 AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                                 AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                                 AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                                 AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                                 A1WWPParameterKey ,
                                                 A3WWPParameterCategory ,
                                                 A4WWPParameterDescription ,
                                                 A2WWPParameterValue ,
                                                 AV16OrderedBy ,
                                                 AV17OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
            lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
            lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
            lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
            lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
            /* Using cursor H000P2 */
            pr_default.execute(0, new Object[] {lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A5WWPParameterDisableDelete = H000P2_A5WWPParameterDisableDelete[0];
               A4WWPParameterDescription = H000P2_A4WWPParameterDescription[0];
               A3WWPParameterCategory = H000P2_A3WWPParameterCategory[0];
               A1WWPParameterKey = H000P2_A1WWPParameterKey[0];
               A2WWPParameterValue = H000P2_A2WWPParameterValue[0];
               if ( StringUtil.Len( A2WWPParameterValue) <= 30 )
               {
                  A6WWPParameterValueTrimmed = A2WWPParameterValue;
               }
               else
               {
                  A6WWPParameterValueTrimmed = StringUtil.Trim( StringUtil.Substring( A2WWPParameterValue, 1, 27)) + "...";
               }
               /* Execute user event: Grid.Load */
               E200P2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB0P0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0P2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV47Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_WWPPARAMETERKEY"+"_"+sGXsfl_41_idx, GetSecureSignedToken( sGXsfl_41_idx, StringUtil.RTrim( context.localUtil.Format( A1WWPParameterKey, "")), context));
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
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV48Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                              AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                              AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                              AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                              AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                              AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                              AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                              AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                              AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                              A1WWPParameterKey ,
                                              A3WWPParameterCategory ,
                                              A4WWPParameterDescription ,
                                              A2WWPParameterValue ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext), "%", "");
         lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = StringUtil.Concat( StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey), "%", "");
         lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = StringUtil.Concat( StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory), "%", "");
         lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = StringUtil.Concat( StringUtil.RTrim( AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription), "%", "");
         lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = StringUtil.Concat( StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed), "%", "");
         /* Using cursor H000P3 */
         pr_default.execute(1, new Object[] {lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV48Workwithplus_wwp_parameterwwds_1_filterfulltext, lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey, AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory, AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription, AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed, AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel});
         GRID_nRecordCount = H000P3_AGRID_nRecordCount[0];
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
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16OrderedBy, AV17OrderedDsc, AV19FilterFullText, AV29ManageFiltersExecutionStep, AV47Pgmname, AV30TFWWPParameterKey, AV31TFWWPParameterKey_Sel, AV32TFWWPParameterCategory, AV33TFWWPParameterCategory_Sel, AV34TFWWPParameterDescription, AV35TFWWPParameterDescription_Sel, AV36TFWWPParameterValueTrimmed, AV37TFWWPParameterValueTrimmed_Sel) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV47Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtWWPParameterKey_Enabled = 0;
         edtWWPParameterCategory_Enabled = 0;
         edtWWPParameterDescription_Enabled = 0;
         edtWWPParameterValueTrimmed_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV27ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV38DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV41GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV8GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            AV19FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV16OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV17OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV19FilterFullText) != 0 )
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
         E180P2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180P2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         if ( StringUtil.StrCmp(AV11HTTPRequest.Method, "GET") == 0 )
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
         Form.Caption = "Parâmetro";
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
         if ( AV16OrderedBy < 1 )
         {
            AV16OrderedBy = 1;
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV38DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV38DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E190P2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV29ManageFiltersExecutionStep == 1 )
         {
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV29ManageFiltersExecutionStep == 2 )
         {
            AV29ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
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
         AV40GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV40GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV40GridCurrentPage), 10, 0));
         AV41GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV41GridPageCount", StringUtil.LTrimStr( (decimal)(AV41GridPageCount), 10, 0));
         GXt_char2 = AV8GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV47Pgmname, out  GXt_char2) ;
         AV8GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV8GridAppliedFilters", AV8GridAppliedFilters);
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = AV19FilterFullText;
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = AV30TFWWPParameterKey;
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = AV31TFWWPParameterKey_Sel;
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = AV32TFWWPParameterCategory;
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = AV33TFWWPParameterCategory_Sel;
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = AV34TFWWPParameterDescription;
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = AV35TFWWPParameterDescription_Sel;
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = AV36TFWWPParameterValueTrimmed;
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = AV37TFWWPParameterValueTrimmed_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void E120P2( )
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
            AV39PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV39PageToGo) ;
         }
      }

      protected void E130P2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E140P2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV16OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
            AV17OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterKey") == 0 )
            {
               AV30TFWWPParameterKey = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
               AV31TFWWPParameterKey_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterCategory") == 0 )
            {
               AV32TFWWPParameterCategory = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
               AV33TFWWPParameterCategory_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterDescription") == 0 )
            {
               AV34TFWWPParameterDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
               AV35TFWWPParameterDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "WWPParameterValueTrimmed") == 0 )
            {
               AV36TFWWPParameterValueTrimmed = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
               AV37TFWWPParameterValueTrimmed_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E200P2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV45Update = "<i class=\"fa fa-pen\"></i>";
         AssignAttri("", false, edtavUpdate_Internalname, AV45Update);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.wwp_parameter"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A1WWPParameterKey));
         edtavUpdate_Link = formatLink("workwithplus.wwp_parameter") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV46Delete = "<i class=\"fa fa-times\"></i>";
         AssignAttri("", false, edtavDelete_Internalname, AV46Delete);
         if ( ! A5WWPParameterDisableDelete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.wwp_parameter"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(A1WWPParameterKey));
            edtavDelete_Link = formatLink("workwithplus.wwp_parameter") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            edtavDelete_Class = "Attribute";
         }
         else
         {
            edtavDelete_Link = "";
            edtavDelete_Class = "Invisible";
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.wwp_parameter"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.RTrim(A1WWPParameterKey));
         edtWWPParameterCategory_Link = formatLink("workwithplus.wwp_parameter") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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

      protected void E110P2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WorkWithPlus.WWP_ParameterWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV47Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WorkWithPlus.WWP_ParameterWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV29ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV29ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV29ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV28ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WorkWithPlus.WWP_ParameterWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV28ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV47Pgmname+"GridState",  AV28ManageFiltersXml) ;
               AV14GridState.FromXml(AV28ManageFiltersXml, null, "", "");
               AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
               AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ManageFiltersData", AV27ManageFiltersData);
      }

      protected void E150P2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "workwithplus.wwp_parameter"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("workwithplus.wwp_parameter") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E160P2( )
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
         new GeneXus.Programs.workwithplus.wwp_parameterwwexport(context ).execute( out  AV20ExcelFilename, out  AV21ErrorMessage) ;
         if ( StringUtil.StrCmp(AV20ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV20ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV21ErrorMessage);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void E170P2( )
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
         Innewwindow1_Target = formatLink("workwithplus.wwp_parameterwwexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14GridState", AV14GridState);
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderedBy), 4, 0))+":"+(AV17OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV27ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WorkWithPlus.WWP_ParameterWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV27ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV19FilterFullText = "";
         AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
         AV30TFWWPParameterKey = "";
         AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
         AV31TFWWPParameterKey_Sel = "";
         AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
         AV32TFWWPParameterCategory = "";
         AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
         AV33TFWWPParameterCategory_Sel = "";
         AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
         AV34TFWWPParameterDescription = "";
         AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
         AV35TFWWPParameterDescription_Sel = "";
         AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
         AV36TFWWPParameterValueTrimmed = "";
         AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
         AV37TFWWPParameterValueTrimmed_Sel = "";
         AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get(AV47Pgmname+"GridState"), "") == 0 )
         {
            AV14GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV47Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV14GridState.FromXml(AV26Session.Get(AV47Pgmname+"GridState"), null, "", "");
         }
         AV16OrderedBy = AV14GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV16OrderedBy", StringUtil.LTrimStr( (decimal)(AV16OrderedBy), 4, 0));
         AV17OrderedDsc = AV14GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV17OrderedDsc", AV17OrderedDsc);
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV14GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV14GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV14GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV14GridState.gxTpr_Filtervalues.Count )
         {
            AV15GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV14GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV19FilterFullText", AV19FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY") == 0 )
            {
               AV30TFWWPParameterKey = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFWWPParameterKey", AV30TFWWPParameterKey);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERKEY_SEL") == 0 )
            {
               AV31TFWWPParameterKey_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFWWPParameterKey_Sel", AV31TFWWPParameterKey_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY") == 0 )
            {
               AV32TFWWPParameterCategory = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFWWPParameterCategory", AV32TFWWPParameterCategory);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERCATEGORY_SEL") == 0 )
            {
               AV33TFWWPParameterCategory_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFWWPParameterCategory_Sel", AV33TFWWPParameterCategory_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION") == 0 )
            {
               AV34TFWWPParameterDescription = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFWWPParameterDescription", AV34TFWWPParameterDescription);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERDESCRIPTION_SEL") == 0 )
            {
               AV35TFWWPParameterDescription_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFWWPParameterDescription_Sel", AV35TFWWPParameterDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED") == 0 )
            {
               AV36TFWWPParameterValueTrimmed = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFWWPParameterValueTrimmed", AV36TFWWPParameterValueTrimmed);
            }
            else if ( StringUtil.StrCmp(AV15GridStateFilterValue.gxTpr_Name, "TFWWPPARAMETERVALUETRIMMED_SEL") == 0 )
            {
               AV37TFWWPParameterValueTrimmed_Sel = AV15GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV37TFWWPParameterValueTrimmed_Sel", AV37TFWWPParameterValueTrimmed_Sel);
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPParameterKey_Sel)),  AV31TFWWPParameterKey_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFWWPParameterCategory_Sel)),  AV33TFWWPParameterCategory_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPParameterDescription_Sel)),  AV35TFWWPParameterDescription_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPParameterValueTrimmed_Sel)),  AV37TFWWPParameterValueTrimmed_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterKey)),  AV30TFWWPParameterKey, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFWWPParameterCategory)),  AV32TFWWPParameterCategory, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFWWPParameterDescription)),  AV34TFWWPParameterDescription, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPParameterValueTrimmed)),  AV36TFWWPParameterValueTrimmed, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV14GridState.FromXml(AV26Session.Get(AV47Pgmname+"GridState"), null, "", "");
         AV14GridState.gxTpr_Orderedby = AV16OrderedBy;
         AV14GridState.gxTpr_Ordereddsc = AV17OrderedDsc;
         AV14GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV14GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)),  0,  AV19FilterFullText,  AV19FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERKEY",  "Chave",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFWWPParameterKey)),  0,  AV30TFWWPParameterKey,  AV30TFWWPParameterKey,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFWWPParameterKey_Sel)),  AV31TFWWPParameterKey_Sel,  AV31TFWWPParameterKey_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERCATEGORY",  "Categoria",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFWWPParameterCategory)),  0,  AV32TFWWPParameterCategory,  AV32TFWWPParameterCategory,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFWWPParameterCategory_Sel)),  AV33TFWWPParameterCategory_Sel,  AV33TFWWPParameterCategory_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERDESCRIPTION",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFWWPParameterDescription)),  0,  AV34TFWWPParameterDescription,  AV34TFWWPParameterDescription,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFWWPParameterDescription_Sel)),  AV35TFWWPParameterDescription_Sel,  AV35TFWWPParameterDescription_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV14GridState,  "TFWWPPARAMETERVALUETRIMMED",  "Valor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFWWPParameterValueTrimmed)),  0,  AV36TFWWPParameterValueTrimmed,  AV36TFWWPParameterValueTrimmed,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV37TFWWPParameterValueTrimmed_Sel)),  AV37TFWWPParameterValueTrimmed_Sel,  AV37TFWWPParameterValueTrimmed_Sel) ;
         AV14GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV14GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV47Pgmname+"GridState",  AV14GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12TrnContext.gxTpr_Callerobject = AV47Pgmname;
         AV12TrnContext.gxTpr_Callerondelete = true;
         AV12TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV12TrnContext.gxTpr_Transactionname = "WorkWithPlus.WWP_Parameter";
         AV26Session.Set("TrnContext", AV12TrnContext.ToXml(false, true, "", ""));
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
         PA0P2( ) ;
         WS0P2( ) ;
         WE0P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019225664", true, true);
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
         context.AddJavascriptSource("workwithplus/wwp_parameterww.js", "?202561019225664", false, true);
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
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_idx;
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY_"+sGXsfl_41_idx;
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY_"+sGXsfl_41_idx;
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION_"+sGXsfl_41_idx;
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_41_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_41_fel_idx;
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY_"+sGXsfl_41_fel_idx;
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY_"+sGXsfl_41_fel_idx;
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION_"+sGXsfl_41_fel_idx;
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         WB0P0( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV45Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"Modifica",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_41_idx + "',41)\"";
            ROClassString = edtavDelete_Class;
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV46Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"Eliminar",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)edtavDelete_Class,(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterKey_Internalname,(string)A1WWPParameterKey,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterCategory_Internalname,(string)A3WWPParameterCategory,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtWWPParameterCategory_Link,(string)"",(string)"",(string)"",(string)edtWWPParameterCategory_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterDescription_Internalname,(string)A4WWPParameterDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPParameterValueTrimmed_Internalname,(string)A6WWPParameterValueTrimmed,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPParameterValueTrimmed_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0P2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+edtavDelete_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Chave") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Categoria") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV45Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV46Delete)));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavDelete_Class));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A1WWPParameterKey));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A3WWPParameterCategory));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtWWPParameterCategory_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A4WWPParameterDescription));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A6WWPParameterValueTrimmed));
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
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         edtWWPParameterKey_Internalname = "WWPPARAMETERKEY";
         edtWWPParameterCategory_Internalname = "WWPPARAMETERCATEGORY";
         edtWWPParameterDescription_Internalname = "WWPPARAMETERDESCRIPTION";
         edtWWPParameterValueTrimmed_Internalname = "WWPPARAMETERVALUETRIMMED";
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
         edtWWPParameterValueTrimmed_Jsonclick = "";
         edtWWPParameterDescription_Jsonclick = "";
         edtWWPParameterCategory_Jsonclick = "";
         edtWWPParameterCategory_Link = "";
         edtWWPParameterKey_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Class = "Attribute";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtWWPParameterValueTrimmed_Enabled = 0;
         edtWWPParameterDescription_Enabled = 0;
         edtWWPParameterCategory_Enabled = 0;
         edtWWPParameterKey_Enabled = 0;
         subGrid_Sortable = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "WorkWithPlus.WWP_ParameterWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T|T|T|";
         Ddo_grid_Columnssortvalues = "1|2|3|";
         Ddo_grid_Columnids = "2:WWPParameterKey|3:WWPParameterCategory|4:WWPParameterDescription|5:WWPParameterValueTrimmed";
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
         Form.Caption = "Parâmetro";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E120P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E130P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E140P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E200P2","iparms":[{"av":"A1WWPParameterKey","fld":"WWPPARAMETERKEY","hsh":true,"type":"svchar"},{"av":"A5WWPParameterDisableDelete","fld":"WWPPARAMETERDISABLEDELETE","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV45Update","fld":"vUPDATE","type":"char"},{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"AV46Delete","fld":"vDELETE","type":"char"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtavDelete_Class","ctrl":"vDELETE","prop":"Class"},{"av":"edtWWPParameterCategory_Link","ctrl":"WWPPARAMETERCATEGORY","prop":"Link"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E110P2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV40GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV41GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV8GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV27ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E150P2","iparms":[{"av":"A1WWPParameterKey","fld":"WWPPARAMETERKEY","hsh":true,"type":"svchar"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E160P2","iparms":[{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"}]""");
         setEventMetadata("'DOEXPORT'",""","oparms":[{"av":"AV14GridState","fld":"vGRIDSTATE","type":""},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E170P2","iparms":[{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"}]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"},{"av":"AV14GridState","fld":"vGRIDSTATE","type":""},{"av":"AV16OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV17OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV19FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV29ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV47Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV30TFWWPParameterKey","fld":"vTFWWPPARAMETERKEY","type":"svchar"},{"av":"AV31TFWWPParameterKey_Sel","fld":"vTFWWPPARAMETERKEY_SEL","type":"svchar"},{"av":"AV32TFWWPParameterCategory","fld":"vTFWWPPARAMETERCATEGORY","type":"svchar"},{"av":"AV33TFWWPParameterCategory_Sel","fld":"vTFWWPPARAMETERCATEGORY_SEL","type":"svchar"},{"av":"AV34TFWWPParameterDescription","fld":"vTFWWPPARAMETERDESCRIPTION","type":"svchar"},{"av":"AV35TFWWPParameterDescription_Sel","fld":"vTFWWPPARAMETERDESCRIPTION_SEL","type":"svchar"},{"av":"AV36TFWWPParameterValueTrimmed","fld":"vTFWWPPARAMETERVALUETRIMMED","type":"svchar"},{"av":"AV37TFWWPParameterValueTrimmed_Sel","fld":"vTFWWPPARAMETERVALUETRIMMED_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Wwpparametervaluetrimmed","iparms":[]}""");
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
         AV19FilterFullText = "";
         AV47Pgmname = "";
         AV30TFWWPParameterKey = "";
         AV31TFWWPParameterKey_Sel = "";
         AV32TFWWPParameterCategory = "";
         AV33TFWWPParameterCategory_Sel = "";
         AV34TFWWPParameterDescription = "";
         AV35TFWWPParameterDescription_Sel = "";
         AV36TFWWPParameterValueTrimmed = "";
         AV37TFWWPParameterValueTrimmed_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV8GridAppliedFilters = "";
         AV38DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         A2WWPParameterValue = "";
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
         AV45Update = "";
         AV46Delete = "";
         A1WWPParameterKey = "";
         A3WWPParameterCategory = "";
         A4WWPParameterDescription = "";
         A6WWPParameterValueTrimmed = "";
         lV48Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         AV48Workwithplus_wwp_parameterwwds_1_filterfulltext = "";
         AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel = "";
         AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey = "";
         AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel = "";
         AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory = "";
         AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel = "";
         AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription = "";
         AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel = "";
         AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed = "";
         H000P2_A5WWPParameterDisableDelete = new bool[] {false} ;
         H000P2_A4WWPParameterDescription = new string[] {""} ;
         H000P2_A3WWPParameterCategory = new string[] {""} ;
         H000P2_A1WWPParameterKey = new string[] {""} ;
         H000P2_A2WWPParameterValue = new string[] {""} ;
         H000P3_AGRID_nRecordCount = new long[1] ;
         AV11HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV28ManageFiltersXml = "";
         AV20ExcelFilename = "";
         AV21ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV26Session = context.GetSession();
         AV15GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.wwp_parameterww__default(),
            new Object[][] {
                new Object[] {
               H000P2_A5WWPParameterDisableDelete, H000P2_A4WWPParameterDescription, H000P2_A3WWPParameterCategory, H000P2_A1WWPParameterKey, H000P2_A2WWPParameterValue
               }
               , new Object[] {
               H000P3_AGRID_nRecordCount
               }
            }
         );
         AV47Pgmname = "WorkWithPlus.WWP_ParameterWW";
         /* GeneXus formulas. */
         AV47Pgmname = "WorkWithPlus.WWP_ParameterWW";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16OrderedBy ;
      private short AV29ManageFiltersExecutionStep ;
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
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavFilterfulltext_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtWWPParameterKey_Enabled ;
      private int edtWWPParameterCategory_Enabled ;
      private int edtWWPParameterDescription_Enabled ;
      private int edtWWPParameterValueTrimmed_Enabled ;
      private int AV39PageToGo ;
      private int AV57GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV40GridCurrentPage ;
      private long AV41GridPageCount ;
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
      private string AV47Pgmname ;
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
      private string AV45Update ;
      private string edtavUpdate_Internalname ;
      private string AV46Delete ;
      private string edtavDelete_Internalname ;
      private string edtWWPParameterKey_Internalname ;
      private string edtWWPParameterCategory_Internalname ;
      private string edtWWPParameterDescription_Internalname ;
      private string edtWWPParameterValueTrimmed_Internalname ;
      private string edtavUpdate_Link ;
      private string GXEncryptionTmp ;
      private string edtavDelete_Link ;
      private string edtavDelete_Class ;
      private string edtWWPParameterCategory_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtWWPParameterKey_Jsonclick ;
      private string edtWWPParameterCategory_Jsonclick ;
      private string edtWWPParameterDescription_Jsonclick ;
      private string edtWWPParameterValueTrimmed_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17OrderedDsc ;
      private bool A5WWPParameterDisableDelete ;
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
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A2WWPParameterValue ;
      private string AV28ManageFiltersXml ;
      private string AV19FilterFullText ;
      private string AV30TFWWPParameterKey ;
      private string AV31TFWWPParameterKey_Sel ;
      private string AV32TFWWPParameterCategory ;
      private string AV33TFWWPParameterCategory_Sel ;
      private string AV34TFWWPParameterDescription ;
      private string AV35TFWWPParameterDescription_Sel ;
      private string AV36TFWWPParameterValueTrimmed ;
      private string AV37TFWWPParameterValueTrimmed_Sel ;
      private string AV8GridAppliedFilters ;
      private string A1WWPParameterKey ;
      private string A3WWPParameterCategory ;
      private string A4WWPParameterDescription ;
      private string A6WWPParameterValueTrimmed ;
      private string lV48Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV48Workwithplus_wwp_parameterwwds_1_filterfulltext ;
      private string AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ;
      private string AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ;
      private string AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ;
      private string AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ;
      private string AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ;
      private string AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ;
      private string AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ;
      private string AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ;
      private string AV20ExcelFilename ;
      private string AV21ErrorMessage ;
      private IGxSession AV26Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GxHttpRequest AV11HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV27ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV38DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV14GridState ;
      private IDataStoreProvider pr_default ;
      private bool[] H000P2_A5WWPParameterDisableDelete ;
      private string[] H000P2_A4WWPParameterDescription ;
      private string[] H000P2_A3WWPParameterCategory ;
      private string[] H000P2_A1WWPParameterKey ;
      private string[] H000P2_A2WWPParameterValue ;
      private long[] H000P3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV15GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwp_parameterww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000P2( IGxContext context ,
                                             string AV48Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WWPParameterDisableDelete, WWPParameterDescription, WWPParameterCategory, WWPParameterKey, WWPParameterValue";
         sFromString = " FROM WWP_Parameter";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterKey DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterCategory, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterCategory DESC, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            sOrderString += " ORDER BY WWPParameterDescription, WWPParameterKey";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            sOrderString += " ORDER BY WWPParameterDescription DESC, WWPParameterKey";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY WWPParameterKey";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H000P3( IGxContext context ,
                                             string AV48Workwithplus_wwp_parameterwwds_1_filterfulltext ,
                                             string AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel ,
                                             string AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey ,
                                             string AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel ,
                                             string AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory ,
                                             string AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel ,
                                             string AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription ,
                                             string AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel ,
                                             string AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed ,
                                             string A1WWPParameterKey ,
                                             string A3WWPParameterCategory ,
                                             string A4WWPParameterDescription ,
                                             string A2WWPParameterValue ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[12];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM WWP_Parameter";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Workwithplus_wwp_parameterwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( WWPParameterKey like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterCategory like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( WWPParameterDescription like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext) or ( ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like '%' || :lV48Workwithplus_wwp_parameterwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey like :lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel)) && ! ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterKey = ( :AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterKey))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory like :lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel)) && ! ( StringUtil.StrCmp(AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterCategory = ( :AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterCategory))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)) ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription like :lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel)) && ! ( StringUtil.StrCmp(AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(WWPParameterDescription = ( :AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from WWPParameterDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)) ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) like :lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel)) && ! ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END) = ( :AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ( CASE  WHEN LENGTH(RTRIM(WWPParameterValue)) <= 30 THEN WWPParameterValue ELSE RTRIM(LTRIM(SUBSTR(WWPParameterValue, 1, 27))) || '...' END)))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
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
                     return conditional_H000P2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H000P3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmH000P2;
          prmH000P2 = new Object[] {
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000P3;
          prmH000P3 = new Object[] {
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV48Workwithplus_wwp_parameterwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Workwithplus_wwp_parameterwwds_2_tfwwpparameterkey",GXType.VarChar,300,0) ,
          new ParDef("AV50Workwithplus_wwp_parameterwwds_3_tfwwpparameterkey_sel",GXType.VarChar,300,0) ,
          new ParDef("lV51Workwithplus_wwp_parameterwwds_4_tfwwpparametercategory",GXType.VarChar,200,0) ,
          new ParDef("AV52Workwithplus_wwp_parameterwwds_5_tfwwpparametercategory_sel",GXType.VarChar,200,0) ,
          new ParDef("lV53Workwithplus_wwp_parameterwwds_6_tfwwpparameterdescription",GXType.VarChar,200,0) ,
          new ParDef("AV54Workwithplus_wwp_parameterwwds_7_tfwwpparameterdescription_",GXType.VarChar,200,0) ,
          new ParDef("lV55Workwithplus_wwp_parameterwwds_8_tfwwpparametervaluetrimmed",GXType.VarChar,30,0) ,
          new ParDef("AV56Workwithplus_wwp_parameterwwds_9_tfwwpparametervaluetrimmed",GXType.VarChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000P2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000P3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
