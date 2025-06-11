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
   public class secrolefunroleassociationww : GXDataArea
   {
      public secrolefunroleassociationww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolefunroleassociationww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecRoleId )
      {
         this.AV8SecRoleId = aP0_SecRoleId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavIsassociated = new GXCheckbox();
         chkavIsassociatedold = new GXCheckbox();
         cmbSecFunctionalityType = new GXCombobox();
         chkSecFunctionalityActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SecRoleId");
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
               gxfirstwebparm = GetFirstPar( "SecRoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SecRoleId");
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
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
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
         AV26OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV27OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV55Pgmname = GetPar( "Pgmname");
         AV15SecFunctionalityIdRemovedXml = GetPar( "SecFunctionalityIdRemovedXml");
         AV14SecFunctionalityIdAddedXml = GetPar( "SecFunctionalityIdAddedXml");
         AV8SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         A131SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
         AV20i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11SecFunctionalityIdRemoved);
         AV13SecFunctionalityIdToFind = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityIdToFind"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV10SecFunctionalityIdAdded);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
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
         PA322( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START322( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrolefunroleassociationww"+UrlEncode(StringUtil.LTrimStr(AV8SecRoleId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secrolefunroleassociationww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecRoleId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV27OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDREMOVEDXML", AV15SecFunctionalityIdRemovedXml);
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDADDEDXML", AV14SecFunctionalityIdAddedXml);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV27OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vSECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecRoleId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20i), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYIDREMOVED", AV11SecFunctionalityIdRemoved);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYIDREMOVED", AV11SecFunctionalityIdRemoved);
         }
         GxWebStd.gx_hidden_field( context, "vSECFUNCTIONALITYIDTOFIND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13SecFunctionalityIdToFind), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYIDADDED", AV10SecFunctionalityIdAdded);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYIDADDED", AV10SecFunctionalityIdAdded);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSECFUNCTIONALITYROLE", AV21SecFunctionalityRole);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSECFUNCTIONALITYROLE", AV21SecFunctionalityRole);
         }
         GxWebStd.gx_hidden_field( context, "vSECROLEID_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53SecRoleId_Selected), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Title", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Result", StringUtil.RTrim( Dvelop_confirmpanel_uaviewchildren_Result));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
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
            WE322( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT322( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "wwpbaseobjects.secrolefunroleassociationww"+UrlEncode(StringUtil.LTrimStr(AV8SecRoleId,4,0));
         return formatLink("wwpbaseobjects.secrolefunroleassociationww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecRoleFunRoleAssociationWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Associado com Role" ;
      }

      protected void WB320( )
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
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(15), 2, 0)+","+"null"+");", "Confirmar", bttBtnconfirm_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleFunRoleAssociationWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(15), 2, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecRoleFunRoleAssociationWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV46DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            wb_table1_40_322( true) ;
         }
         else
         {
            wb_table1_40_322( false) ;
         }
         return  ;
      }

      protected void wb_table1_40_322e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
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

      protected void START322( )
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
         Form.Meta.addItem("description", "Associado com Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP320( ) ;
      }

      protected void WS322( )
      {
         START322( ) ;
         EVT322( ) ;
      }

      protected void EVT322( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E11322 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E12322 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E13322 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 /* Set Refresh If Orderedby Changed */
                                 if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV26OrderedBy )) )
                                 {
                                    Rfr0gs = true;
                                 }
                                 /* Set Refresh If Ordereddsc Changed */
                                 if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
                                 {
                                    Rfr0gs = true;
                                 }
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E14322 ();
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VISASSOCIATED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "VISASSOCIATED.CLICK") == 0 ) )
                           {
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              AV18IsAssociated = StringUtil.StrToBool( cgiGet( chkavIsassociated_Internalname));
                              AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
                              AV19IsAssociatedOld = StringUtil.StrToBool( cgiGet( chkavIsassociatedold_Internalname));
                              AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
                              GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
                              AV51UAViewChildren = cgiGet( edtavUaviewchildren_Internalname);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV51UAViewChildren)) ? AV56Uaviewchildren_GXI : context.convertURL( context.PathToRelativeUrl( AV51UAViewChildren))), !bGXsfl_15_Refreshing);
                              AssignProp("", false, edtavUaviewchildren_Internalname, "SrcSet", context.GetImageSrcSet( AV51UAViewChildren), true);
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
                                    E15322 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E16322 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E17322 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VISASSOCIATED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E18322 ();
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

      protected void WE322( )
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

      protected void PA322( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.secrolefunroleassociationww")), "wwpbaseobjects.secrolefunroleassociationww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.secrolefunroleassociationww")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "SecRoleId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV8SecRoleId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecRoleId), "ZZZ9"), context));
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
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV26OrderedBy ,
                                       bool AV27OrderedDsc ,
                                       string AV55Pgmname ,
                                       string AV15SecFunctionalityIdRemovedXml ,
                                       string AV14SecFunctionalityIdAddedXml ,
                                       short AV8SecRoleId ,
                                       short A131SecRoleId ,
                                       long AV20i ,
                                       GxSimpleCollection<long> AV11SecFunctionalityIdRemoved ,
                                       long AV13SecFunctionalityIdToFind ,
                                       GxSimpleCollection<long> AV10SecFunctionalityIdAdded )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF322( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECFUNCTIONALITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD", GetSecureSignedToken( "", AV19IsAssociatedOld, context));
         GxWebStd.gx_hidden_field( context, "vISASSOCIATEDOLD", StringUtil.BoolToStr( AV19IsAssociatedOld));
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
         RF322( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
      }

      protected void RF322( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E16322 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
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
            SubsflControlProps_152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV26OrderedBy ,
                                                 AV27OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H00322 */
            pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A128SecFunctionalityId = H00322_A128SecFunctionalityId[0];
               A134SecFunctionalityActive = H00322_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = H00322_n134SecFunctionalityActive[0];
               A138SecParentFunctionalityDescription = H00322_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H00322_n138SecParentFunctionalityDescription[0];
               A129SecParentFunctionalityId = H00322_A129SecParentFunctionalityId[0];
               n129SecParentFunctionalityId = H00322_n129SecParentFunctionalityId[0];
               A136SecFunctionalityType = H00322_A136SecFunctionalityType[0];
               n136SecFunctionalityType = H00322_n136SecFunctionalityType[0];
               A135SecFunctionalityDescription = H00322_A135SecFunctionalityDescription[0];
               n135SecFunctionalityDescription = H00322_n135SecFunctionalityDescription[0];
               A130SecFunctionalityKey = H00322_A130SecFunctionalityKey[0];
               n130SecFunctionalityKey = H00322_n130SecFunctionalityKey[0];
               A138SecParentFunctionalityDescription = H00322_A138SecParentFunctionalityDescription[0];
               n138SecParentFunctionalityDescription = H00322_n138SecParentFunctionalityDescription[0];
               /* Execute user event: Grid.Load */
               E17322 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WB320( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes322( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECFUNCTIONALITYID"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
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
                                              AV26OrderedBy ,
                                              AV27OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H00323 */
         pr_default.execute(1);
         GRID_nRecordCount = H00323_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV26OrderedBy, AV27OrderedDsc, AV55Pgmname, AV15SecFunctionalityIdRemovedXml, AV14SecFunctionalityIdAddedXml, AV8SecRoleId, A131SecRoleId, AV20i, AV11SecFunctionalityIdRemoved, AV13SecFunctionalityIdToFind, AV10SecFunctionalityIdAdded) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
         edtSecFunctionalityId_Enabled = 0;
         edtSecFunctionalityKey_Enabled = 0;
         edtSecFunctionalityDescription_Enabled = 0;
         cmbSecFunctionalityType.Enabled = 0;
         edtSecParentFunctionalityId_Enabled = 0;
         edtSecParentFunctionalityDescription_Enabled = 0;
         chkSecFunctionalityActive.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP320( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15322 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV46DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_15"), ",", "."), 18, MidpointRounding.ToEven));
            AV48GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV49GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV50GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECROLEID"), ",", "."), 18, MidpointRounding.ToEven));
            AV53SecRoleId_Selected = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSECROLEID_SELECTED"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Dvelop_confirmpanel_uaviewchildren_Title = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Title");
            Dvelop_confirmpanel_uaviewchildren_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmationtext");
            Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Nobuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Cancelbuttoncaption");
            Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Yesbuttonposition");
            Dvelop_confirmpanel_uaviewchildren_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV26OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV27OrderedDsc )
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
         E15322 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15322( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Associado com Role";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV26OrderedBy < 1 )
         {
            AV26OrderedBy = 1;
            AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
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

      protected void E16322( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'LOAD LISTS' */
         S122 ();
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
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV55Pgmname, out  GXt_char2) ;
         AV50GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV50GridAppliedFilters", AV50GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E11322( )
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

      protected void E12322( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13322( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV26OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26OrderedBy", StringUtil.LTrimStr( (decimal)(AV26OrderedBy), 4, 0));
            AV27OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV27OrderedDsc", AV27OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E17322( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUaviewchildren_gximage = "ActionDisplay";
         AV51UAViewChildren = context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( ));
         AssignAttri("", false, edtavUaviewchildren_Internalname, AV51UAViewChildren);
         AV56Uaviewchildren_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f11923b6-6acd-4a79-bfc0-0cfc6f3bced5", "", context.GetTheme( )), context);
         edtavUaviewchildren_Tooltiptext = "View Actions, Tabs and Modes";
         GXt_boolean3 = AV52TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secfunctionalityhaschildren(context ).execute(  A128SecFunctionalityId, out  GXt_boolean3) ;
         AV52TempBoolean = GXt_boolean3;
         if ( AV52TempBoolean )
         {
            edtavUaviewchildren_Class = "ActionBaseColorAttribute";
         }
         else
         {
            edtavUaviewchildren_Class = "Invisible";
         }
         AV9SecRoleIdParm = AV8SecRoleId;
         AssignAttri("", false, "AV9SecRoleIdParm", StringUtil.LTrimStr( (decimal)(AV9SecRoleIdParm), 4, 0));
         AV19IsAssociatedOld = false;
         AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
         /* Using cursor H00324 */
         pr_default.execute(2, new Object[] {A128SecFunctionalityId, AV9SecRoleIdParm});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A131SecRoleId = H00324_A131SecRoleId[0];
            AV19IsAssociatedOld = true;
            AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
            GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         AV13SecFunctionalityIdToFind = A128SecFunctionalityId;
         AssignAttri("", false, "AV13SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV13SecFunctionalityIdToFind), 10, 0));
         if ( AV19IsAssociatedOld )
         {
            /* Execute user subroutine: 'FIND IN REMOVED' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'FIND IN ADDED' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         if ( AV20i > 0 )
         {
            AV18IsAssociated = (bool)(!AV19IsAssociatedOld);
            AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
         }
         else
         {
            AV18IsAssociated = AV19IsAssociatedOld;
            AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            DoAjaxLoad(15, GridRow);
         }
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14322 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14322( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOAD LISTS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV17Success = true;
         AV20i = 1;
         AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV11SecFunctionalityIdRemoved.Count )
         {
            AV12SecFunctionalityId = (long)(AV11SecFunctionalityIdRemoved.GetNumeric(AV58GXV1));
            AV21SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            AV21SecFunctionalityRole.Load(AV12SecFunctionalityId, AV8SecRoleId);
            if ( AV21SecFunctionalityRole.Success() )
            {
               AV21SecFunctionalityRole.Delete();
            }
            if ( ! AV21SecFunctionalityRole.Success() )
            {
               AV17Success = false;
               /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV20i = (long)(AV20i+1);
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         AV20i = 1;
         AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         AV59GXV2 = 1;
         while ( AV59GXV2 <= AV10SecFunctionalityIdAdded.Count )
         {
            AV12SecFunctionalityId = (long)(AV10SecFunctionalityIdAdded.GetNumeric(AV59GXV2));
            AV21SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            AV21SecFunctionalityRole.gxTpr_Secroleid = AV8SecRoleId;
            AV21SecFunctionalityRole.gxTpr_Secfunctionalityid = AV12SecFunctionalityId;
            AV21SecFunctionalityRole.Save();
            if ( ! AV21SecFunctionalityRole.Success() )
            {
               AV17Success = false;
               /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV20i = (long)(AV20i+1);
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
            AV59GXV2 = (int)(AV59GXV2+1);
         }
         if ( AV17Success )
         {
            if ( AV10SecFunctionalityIdAdded.Count + AV11SecFunctionalityIdRemoved.Count > 0 )
            {
               context.CommitDataStores("wwpbaseobjects.secrolefunroleassociationww",pr_default);
               AV14SecFunctionalityIdAddedXml = "";
               AssignAttri("", false, "AV14SecFunctionalityIdAddedXml", AV14SecFunctionalityIdAddedXml);
               AV15SecFunctionalityIdRemovedXml = "";
               AssignAttri("", false, "AV15SecFunctionalityIdRemovedXml", AV15SecFunctionalityIdRemovedXml);
               GX_msglist.addItem("Dados atualizados com sucesso.");
            }
            else
            {
               GX_msglist.addItem("Nenhuma alteração foi realizada.");
            }
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21SecFunctionalityRole", AV21SecFunctionalityRole);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void E18322( )
      {
         /* Isassociated_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOAD LISTS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13SecFunctionalityIdToFind = A128SecFunctionalityId;
         AssignAttri("", false, "AV13SecFunctionalityIdToFind", StringUtil.LTrimStr( (decimal)(AV13SecFunctionalityIdToFind), 10, 0));
         if ( AV18IsAssociated )
         {
            if ( AV19IsAssociatedOld )
            {
               /* Execute user subroutine: 'FIND IN REMOVED' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV11SecFunctionalityIdRemoved.RemoveItem((int)(AV20i));
            }
            else
            {
               AV10SecFunctionalityIdAdded.Add(AV13SecFunctionalityIdToFind, 0);
            }
         }
         else
         {
            if ( AV19IsAssociatedOld )
            {
               AV11SecFunctionalityIdRemoved.Add(AV13SecFunctionalityIdToFind, 0);
            }
            else
            {
               /* Execute user subroutine: 'FIND IN ADDED' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               AV10SecFunctionalityIdAdded.RemoveItem((int)(AV20i));
            }
         }
         /* Execute user subroutine: 'SAVE LISTS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11SecFunctionalityIdRemoved", AV11SecFunctionalityIdRemoved);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10SecFunctionalityIdAdded", AV10SecFunctionalityIdAdded);
      }

      protected void S112( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV26OrderedBy), 4, 0))+":"+(AV27OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'DO UAVIEWCHILDREN' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'FIND IN ADDED' Routine */
         returnInSub = false;
         AV20i = 1;
         AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         AV60GXV3 = 1;
         while ( AV60GXV3 <= AV10SecFunctionalityIdAdded.Count )
         {
            AV12SecFunctionalityId = (long)(AV10SecFunctionalityIdAdded.GetNumeric(AV60GXV3));
            if ( AV12SecFunctionalityId == AV13SecFunctionalityIdToFind )
            {
               if (true) break;
            }
            AV20i = (long)(AV20i+1);
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
            AV60GXV3 = (int)(AV60GXV3+1);
         }
         if ( AV20i > AV10SecFunctionalityIdAdded.Count )
         {
            AV20i = 0;
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         }
      }

      protected void S132( )
      {
         /* 'FIND IN REMOVED' Routine */
         returnInSub = false;
         AV20i = 1;
         AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         AV61GXV4 = 1;
         while ( AV61GXV4 <= AV11SecFunctionalityIdRemoved.Count )
         {
            AV12SecFunctionalityId = (long)(AV11SecFunctionalityIdRemoved.GetNumeric(AV61GXV4));
            if ( AV12SecFunctionalityId == AV13SecFunctionalityIdToFind )
            {
               if (true) break;
            }
            AV20i = (long)(AV20i+1);
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
            AV61GXV4 = (int)(AV61GXV4+1);
         }
         if ( AV20i > AV11SecFunctionalityIdRemoved.Count )
         {
            AV20i = 0;
            AssignAttri("", false, "AV20i", StringUtil.LTrimStr( (decimal)(AV20i), 10, 0));
         }
      }

      protected void S122( )
      {
         /* 'LOAD LISTS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15SecFunctionalityIdRemovedXml)) )
         {
            AV11SecFunctionalityIdRemoved.FromXml(AV15SecFunctionalityIdRemovedXml, null, "Collection", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SecFunctionalityIdAddedXml)) )
         {
            AV10SecFunctionalityIdAdded.FromXml(AV14SecFunctionalityIdAddedXml, null, "Collection", "");
         }
      }

      protected void S172( )
      {
         /* 'SAVE LISTS' Routine */
         returnInSub = false;
         if ( AV11SecFunctionalityIdRemoved.Count > 0 )
         {
            AV15SecFunctionalityIdRemovedXml = AV11SecFunctionalityIdRemoved.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV15SecFunctionalityIdRemovedXml", AV15SecFunctionalityIdRemovedXml);
         }
         else
         {
            AV15SecFunctionalityIdRemovedXml = "";
            AssignAttri("", false, "AV15SecFunctionalityIdRemovedXml", AV15SecFunctionalityIdRemovedXml);
         }
         if ( AV10SecFunctionalityIdAdded.Count > 0 )
         {
            AV14SecFunctionalityIdAddedXml = AV10SecFunctionalityIdAdded.ToXml(false, true, "Collection", "");
            AssignAttri("", false, "AV14SecFunctionalityIdAddedXml", AV14SecFunctionalityIdAddedXml);
         }
         else
         {
            AV14SecFunctionalityIdAddedXml = "";
            AssignAttri("", false, "AV14SecFunctionalityIdAddedXml", AV14SecFunctionalityIdAddedXml);
         }
      }

      protected void S152( )
      {
         /* 'SHOW ERROR MESSAGES' Routine */
         returnInSub = false;
         AV63GXV6 = 1;
         AV62GXV5 = AV21SecFunctionalityRole.GetMessages();
         while ( AV63GXV6 <= AV62GXV5.Count )
         {
            AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV62GXV5.Item(AV63GXV6));
            if ( AV16Message.gxTpr_Type == 1 )
            {
               GX_msglist.addItem(AV16Message.gxTpr_Description);
            }
            AV63GXV6 = (int)(AV63GXV6+1);
         }
      }

      protected void wb_table1_40_322( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_uaviewchildren_Internalname, tblTabledvelop_confirmpanel_uaviewchildren_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("Title", Dvelop_confirmpanel_uaviewchildren_Title);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("ConfirmationText", Dvelop_confirmpanel_uaviewchildren_Confirmationtext);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("YesButtonCaption", Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("NoButtonCaption", Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("YesButtonPosition", Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition);
            ucDvelop_confirmpanel_uaviewchildren.SetProperty("ConfirmType", Dvelop_confirmpanel_uaviewchildren_Confirmtype);
            ucDvelop_confirmpanel_uaviewchildren.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_uaviewchildren_Internalname, "DVELOP_CONFIRMPANEL_UAVIEWCHILDRENContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_UAVIEWCHILDRENContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_40_322e( true) ;
         }
         else
         {
            wb_table1_40_322e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8SecRoleId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8SecRoleId), "ZZZ9"), context));
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
         PA322( ) ;
         WS322( ) ;
         WE322( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019234277", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secrolefunroleassociationww.js", "?202561019234277", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         chkavIsassociated_Internalname = "vISASSOCIATED_"+sGXsfl_15_idx;
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD_"+sGXsfl_15_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_15_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_15_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_15_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_15_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_15_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_15_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_15_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         chkavIsassociated_Internalname = "vISASSOCIATED_"+sGXsfl_15_fel_idx;
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD_"+sGXsfl_15_fel_idx;
         edtavUaviewchildren_Internalname = "vUAVIEWCHILDREN_"+sGXsfl_15_fel_idx;
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID_"+sGXsfl_15_fel_idx;
         edtSecFunctionalityKey_Internalname = "SECFUNCTIONALITYKEY_"+sGXsfl_15_fel_idx;
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION_"+sGXsfl_15_fel_idx;
         cmbSecFunctionalityType_Internalname = "SECFUNCTIONALITYTYPE_"+sGXsfl_15_fel_idx;
         edtSecParentFunctionalityId_Internalname = "SECPARENTFUNCTIONALITYID_"+sGXsfl_15_fel_idx;
         edtSecParentFunctionalityDescription_Internalname = "SECPARENTFUNCTIONALITYDESCRIPTION_"+sGXsfl_15_fel_idx;
         chkSecFunctionalityActive_Internalname = "SECFUNCTIONALITYACTIVE_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WB320( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_15_idx + "',15)\"";
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vISASSOCIATED_" + sGXsfl_15_idx;
            chkavIsassociated.Name = GXCCtl;
            chkavIsassociated.WebTags = "";
            chkavIsassociated.Caption = "";
            AssignProp("", false, chkavIsassociated_Internalname, "TitleCaption", chkavIsassociated.Caption, !bGXsfl_15_Refreshing);
            chkavIsassociated.CheckedValue = "false";
            AV18IsAssociated = StringUtil.StrToBool( StringUtil.BoolToStr( AV18IsAssociated));
            AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsassociated_Internalname,StringUtil.BoolToStr( AV18IsAssociated),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onblur=\""+""+";gx.evt.onblur(this,16);\""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vISASSOCIATEDOLD_" + sGXsfl_15_idx;
            chkavIsassociatedold.Name = GXCCtl;
            chkavIsassociatedold.WebTags = "";
            chkavIsassociatedold.Caption = "";
            AssignProp("", false, chkavIsassociatedold_Internalname, "TitleCaption", chkavIsassociatedold.Caption, !bGXsfl_15_Refreshing);
            chkavIsassociatedold.CheckedValue = "false";
            AV19IsAssociatedOld = StringUtil.StrToBool( StringUtil.BoolToStr( AV19IsAssociatedOld));
            AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
            GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsassociatedold_Internalname,StringUtil.BoolToStr( AV19IsAssociatedOld),(string)"",(string)"",(short)0,chkavIsassociatedold.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',15)\"";
            ClassString = edtavUaviewchildren_Class + " " + ((StringUtil.StrCmp(edtavUaviewchildren_gximage, "")==0) ? "" : "GX_Image_"+edtavUaviewchildren_gximage+"_Class");
            StyleString = "";
            AV51UAViewChildren_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV51UAViewChildren))&&String.IsNullOrEmpty(StringUtil.RTrim( AV56Uaviewchildren_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV51UAViewChildren)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV51UAViewChildren)) ? AV56Uaviewchildren_GXI : context.PathToRelativeUrl( AV51UAViewChildren));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaviewchildren_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavUaviewchildren_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUaviewchildren_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e19322_client"+"'",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV51UAViewChildren_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityKey_Internalname,(string)A130SecFunctionalityKey,StringUtil.RTrim( context.localUtil.Format( A130SecFunctionalityKey, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityKey_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecFunctionalityDescription_Internalname,(string)A135SecFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbSecFunctionalityType.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_15_idx;
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
            AssignProp("", false, cmbSecFunctionalityType_Internalname, "Values", (string)(cmbSecFunctionalityType.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A129SecParentFunctionalityId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecParentFunctionalityDescription_Internalname,(string)A138SecParentFunctionalityDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecParentFunctionalityDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_15_idx;
            chkSecFunctionalityActive.Name = GXCCtl;
            chkSecFunctionalityActive.WebTags = "";
            chkSecFunctionalityActive.Caption = "";
            AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_15_Refreshing);
            chkSecFunctionalityActive.CheckedValue = "false";
            A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
            n134SecFunctionalityActive = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSecFunctionalityActive_Internalname,StringUtil.BoolToStr( A134SecFunctionalityActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn hidden-xs",(string)"",(string)""});
            send_integrity_lvl_hashes322( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vISASSOCIATED_" + sGXsfl_15_idx;
         chkavIsassociated.Name = GXCCtl;
         chkavIsassociated.WebTags = "";
         chkavIsassociated.Caption = "";
         AssignProp("", false, chkavIsassociated_Internalname, "TitleCaption", chkavIsassociated.Caption, !bGXsfl_15_Refreshing);
         chkavIsassociated.CheckedValue = "false";
         AV18IsAssociated = StringUtil.StrToBool( StringUtil.BoolToStr( AV18IsAssociated));
         AssignAttri("", false, chkavIsassociated_Internalname, AV18IsAssociated);
         GXCCtl = "vISASSOCIATEDOLD_" + sGXsfl_15_idx;
         chkavIsassociatedold.Name = GXCCtl;
         chkavIsassociatedold.WebTags = "";
         chkavIsassociatedold.Caption = "";
         AssignProp("", false, chkavIsassociatedold_Internalname, "TitleCaption", chkavIsassociatedold.Caption, !bGXsfl_15_Refreshing);
         chkavIsassociatedold.CheckedValue = "false";
         AV19IsAssociatedOld = StringUtil.StrToBool( StringUtil.BoolToStr( AV19IsAssociatedOld));
         AssignAttri("", false, chkavIsassociatedold_Internalname, AV19IsAssociatedOld);
         GxWebStd.gx_hidden_field( context, "gxhash_vISASSOCIATEDOLD"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sGXsfl_15_idx, AV19IsAssociatedOld, context));
         GXCCtl = "SECFUNCTIONALITYTYPE_" + sGXsfl_15_idx;
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
         GXCCtl = "SECFUNCTIONALITYACTIVE_" + sGXsfl_15_idx;
         chkSecFunctionalityActive.Name = GXCCtl;
         chkSecFunctionalityActive.WebTags = "";
         chkSecFunctionalityActive.Caption = "";
         AssignProp("", false, chkSecFunctionalityActive_Internalname, "TitleCaption", chkSecFunctionalityActive.Caption, !bGXsfl_15_Refreshing);
         chkSecFunctionalityActive.CheckedValue = "false";
         A134SecFunctionalityActive = StringUtil.StrToBool( StringUtil.BoolToStr( A134SecFunctionalityActive));
         n134SecFunctionalityActive = false;
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"15\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV18IsAssociated)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV19IsAssociatedOld)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsassociatedold.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV51UAViewChildren));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( edtavUaviewchildren_Class));
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
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A136SecFunctionalityType), 2, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A129SecParentFunctionalityId), 10, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A138SecParentFunctionalityDescription));
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
         chkavIsassociated_Internalname = "vISASSOCIATED";
         chkavIsassociatedold_Internalname = "vISASSOCIATEDOLD";
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
         bttBtnconfirm_Internalname = "BTNCONFIRM";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Dvelop_confirmpanel_uaviewchildren_Internalname = "DVELOP_CONFIRMPANEL_UAVIEWCHILDREN";
         tblTabledvelop_confirmpanel_uaviewchildren_Internalname = "TABLEDVELOP_CONFIRMPANEL_UAVIEWCHILDREN";
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
         edtSecParentFunctionalityId_Jsonclick = "";
         cmbSecFunctionalityType_Jsonclick = "";
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityKey_Jsonclick = "";
         edtSecFunctionalityId_Jsonclick = "";
         edtavUaviewchildren_Jsonclick = "";
         edtavUaviewchildren_gximage = "";
         edtavUaviewchildren_Class = "ActionBaseColorAttribute";
         edtavUaviewchildren_Tooltiptext = "View Actions, Tabs and Modes";
         chkavIsassociatedold.Caption = "";
         chkavIsassociatedold.Enabled = 1;
         chkavIsassociated.Caption = "";
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
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_uaviewchildren_Confirmtype = "1";
         Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition = "left";
         Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_uaviewchildren_Confirmationtext = "You will lose the changes made. Are you sure you want to continue?";
         Dvelop_confirmpanel_uaviewchildren_Title = "Confirmation of loss changes";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "4:SecFunctionalityKey|5:SecFunctionalityDescription|6:SecFunctionalityType|8:SecParentFunctionalityDescription";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Associado com Role";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV48GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV49GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV50GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E11322","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E12322","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E13322","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV55Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV26OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV27OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E17322","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV51UAViewChildren","fld":"vUAVIEWCHILDREN","type":"bits"},{"av":"edtavUaviewchildren_Tooltiptext","ctrl":"vUAVIEWCHILDREN","prop":"Tooltiptext"},{"av":"edtavUaviewchildren_Class","ctrl":"vUAVIEWCHILDREN","prop":"Class"},{"av":"AV9SecRoleIdParm","fld":"vSECROLEIDPARM","pic":"ZZZ9","type":"int"},{"av":"AV19IsAssociatedOld","fld":"vISASSOCIATEDOLD","hsh":true,"type":"boolean"},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV18IsAssociated","fld":"vISASSOCIATED","type":"boolean"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14322","iparms":[{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV8SecRoleId","fld":"vSECROLEID","pic":"ZZZ9","hsh":true,"type":"int"},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV21SecFunctionalityRole","fld":"vSECFUNCTIONALITYROLE","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV21SecFunctionalityRole","fld":"vSECFUNCTIONALITYROLE","type":""},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""}]}""");
         setEventMetadata("'DOUAVIEWCHILDREN'","""{"handler":"E19322","iparms":[{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VISASSOCIATED.CLICK","""{"handler":"E18322","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV18IsAssociated","fld":"vISASSOCIATED","type":"boolean"},{"av":"AV19IsAssociatedOld","fld":"vISASSOCIATEDOLD","hsh":true,"type":"boolean"},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"},{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VISASSOCIATED.CLICK",""","oparms":[{"av":"AV13SecFunctionalityIdToFind","fld":"vSECFUNCTIONALITYIDTOFIND","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV11SecFunctionalityIdRemoved","fld":"vSECFUNCTIONALITYIDREMOVED","type":""},{"av":"AV10SecFunctionalityIdAdded","fld":"vSECFUNCTIONALITYIDADDED","type":""},{"av":"AV20i","fld":"vI","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV15SecFunctionalityIdRemovedXml","fld":"vSECFUNCTIONALITYIDREMOVEDXML","type":"vchar"},{"av":"AV14SecFunctionalityIdAddedXml","fld":"vSECFUNCTIONALITYIDADDEDXML","type":"vchar"}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[]}""");
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
         Dvelop_confirmpanel_uaviewchildren_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV55Pgmname = "";
         AV15SecFunctionalityIdRemovedXml = "";
         AV14SecFunctionalityIdAddedXml = "";
         AV11SecFunctionalityIdRemoved = new GxSimpleCollection<long>();
         AV10SecFunctionalityIdAdded = new GxSimpleCollection<long>();
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV50GridAppliedFilters = "";
         AV46DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         TempTags = "";
         bttBtnconfirm_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV51UAViewChildren = "";
         AV56Uaviewchildren_GXI = "";
         A130SecFunctionalityKey = "";
         A135SecFunctionalityDescription = "";
         A138SecParentFunctionalityDescription = "";
         GXDecQS = "";
         H00322_A128SecFunctionalityId = new long[1] ;
         H00322_A134SecFunctionalityActive = new bool[] {false} ;
         H00322_n134SecFunctionalityActive = new bool[] {false} ;
         H00322_A138SecParentFunctionalityDescription = new string[] {""} ;
         H00322_n138SecParentFunctionalityDescription = new bool[] {false} ;
         H00322_A129SecParentFunctionalityId = new long[1] ;
         H00322_n129SecParentFunctionalityId = new bool[] {false} ;
         H00322_A136SecFunctionalityType = new short[1] ;
         H00322_n136SecFunctionalityType = new bool[] {false} ;
         H00322_A135SecFunctionalityDescription = new string[] {""} ;
         H00322_n135SecFunctionalityDescription = new bool[] {false} ;
         H00322_A130SecFunctionalityKey = new string[] {""} ;
         H00322_n130SecFunctionalityKey = new bool[] {false} ;
         H00323_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         H00324_A128SecFunctionalityId = new long[1] ;
         H00324_A131SecRoleId = new short[1] ;
         GridRow = new GXWebRow();
         AV62GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         ucDvelop_confirmpanel_uaviewchildren = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         sImgUrl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolefunroleassociationww__default(),
            new Object[][] {
                new Object[] {
               H00322_A128SecFunctionalityId, H00322_A134SecFunctionalityActive, H00322_n134SecFunctionalityActive, H00322_A138SecParentFunctionalityDescription, H00322_n138SecParentFunctionalityDescription, H00322_A129SecParentFunctionalityId, H00322_n129SecParentFunctionalityId, H00322_A136SecFunctionalityType, H00322_n136SecFunctionalityType, H00322_A135SecFunctionalityDescription,
               H00322_n135SecFunctionalityDescription, H00322_A130SecFunctionalityKey, H00322_n130SecFunctionalityKey
               }
               , new Object[] {
               H00323_AGRID_nRecordCount
               }
               , new Object[] {
               H00324_A128SecFunctionalityId, H00324_A131SecRoleId
               }
            }
         );
         AV55Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         /* GeneXus formulas. */
         AV55Pgmname = "WWPBaseObjects.SecRoleFunRoleAssociationWW";
         chkavIsassociatedold.Enabled = 0;
      }

      private short AV8SecRoleId ;
      private short wcpOAV8SecRoleId ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26OrderedBy ;
      private short A131SecRoleId ;
      private short gxajaxcallmode ;
      private short AV53SecRoleId_Selected ;
      private short wbEnd ;
      private short wbStart ;
      private short A136SecFunctionalityType ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV9SecRoleIdParm ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_15 ;
      private int subGrid_Rows ;
      private int nGXsfl_15_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityKey_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecParentFunctionalityId_Enabled ;
      private int edtSecParentFunctionalityDescription_Enabled ;
      private int AV47PageToGo ;
      private int AV58GXV1 ;
      private int AV59GXV2 ;
      private int AV60GXV3 ;
      private int AV61GXV4 ;
      private int AV63GXV6 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV20i ;
      private long AV13SecFunctionalityIdToFind ;
      private long AV48GridCurrentPage ;
      private long AV49GridPageCount ;
      private long A128SecFunctionalityId ;
      private long A129SecParentFunctionalityId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long AV12SecFunctionalityId ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Dvelop_confirmpanel_uaviewchildren_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_15_idx="0001" ;
      private string AV55Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Dvelop_confirmpanel_uaviewchildren_Title ;
      private string Dvelop_confirmpanel_uaviewchildren_Confirmationtext ;
      private string Dvelop_confirmpanel_uaviewchildren_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Nobuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_uaviewchildren_Yesbuttonposition ;
      private string Dvelop_confirmpanel_uaviewchildren_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string TempTags ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavIsassociated_Internalname ;
      private string chkavIsassociatedold_Internalname ;
      private string edtavUaviewchildren_Internalname ;
      private string edtSecFunctionalityId_Internalname ;
      private string edtSecFunctionalityKey_Internalname ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string cmbSecFunctionalityType_Internalname ;
      private string edtSecParentFunctionalityId_Internalname ;
      private string edtSecParentFunctionalityDescription_Internalname ;
      private string chkSecFunctionalityActive_Internalname ;
      private string GXDecQS ;
      private string GXt_char2 ;
      private string edtavUaviewchildren_gximage ;
      private string edtavUaviewchildren_Tooltiptext ;
      private string edtavUaviewchildren_Class ;
      private string tblTabledvelop_confirmpanel_uaviewchildren_Internalname ;
      private string Dvelop_confirmpanel_uaviewchildren_Internalname ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string sImgUrl ;
      private string edtavUaviewchildren_Jsonclick ;
      private string ROClassString ;
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityKey_Jsonclick ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string cmbSecFunctionalityType_Jsonclick ;
      private string edtSecParentFunctionalityId_Jsonclick ;
      private string edtSecParentFunctionalityDescription_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV27OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV18IsAssociated ;
      private bool AV19IsAssociatedOld ;
      private bool bGXsfl_15_Refreshing=false ;
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
      private bool AV52TempBoolean ;
      private bool GXt_boolean3 ;
      private bool AV17Success ;
      private bool AV51UAViewChildren_IsBlob ;
      private string AV15SecFunctionalityIdRemovedXml ;
      private string AV14SecFunctionalityIdAddedXml ;
      private string AV50GridAppliedFilters ;
      private string AV56Uaviewchildren_GXI ;
      private string A130SecFunctionalityKey ;
      private string A135SecFunctionalityDescription ;
      private string A138SecParentFunctionalityDescription ;
      private string AV51UAViewChildren ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_uaviewchildren ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsassociated ;
      private GXCheckbox chkavIsassociatedold ;
      private GXCombobox cmbSecFunctionalityType ;
      private GXCheckbox chkSecFunctionalityActive ;
      private GxSimpleCollection<long> AV11SecFunctionalityIdRemoved ;
      private GxSimpleCollection<long> AV10SecFunctionalityIdAdded ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV46DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole AV21SecFunctionalityRole ;
      private IDataStoreProvider pr_default ;
      private long[] H00322_A128SecFunctionalityId ;
      private bool[] H00322_A134SecFunctionalityActive ;
      private bool[] H00322_n134SecFunctionalityActive ;
      private string[] H00322_A138SecParentFunctionalityDescription ;
      private bool[] H00322_n138SecParentFunctionalityDescription ;
      private long[] H00322_A129SecParentFunctionalityId ;
      private bool[] H00322_n129SecParentFunctionalityId ;
      private short[] H00322_A136SecFunctionalityType ;
      private bool[] H00322_n136SecFunctionalityType ;
      private string[] H00322_A135SecFunctionalityDescription ;
      private bool[] H00322_n135SecFunctionalityDescription ;
      private string[] H00322_A130SecFunctionalityKey ;
      private bool[] H00322_n130SecFunctionalityKey ;
      private long[] H00323_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private long[] H00324_A128SecFunctionalityId ;
      private short[] H00324_A131SecRoleId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV62GXV5 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secrolefunroleassociationww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00322( IGxContext context ,
                                             short AV26OrderedBy ,
                                             bool AV27OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.SecFunctionalityId, T1.SecFunctionalityActive, T2.SecFunctionalityDescription AS SecParentFunctionalityDescription, T1.SecParentFunctionalityId AS SecParentFunctionalityId, T1.SecFunctionalityType, T1.SecFunctionalityDescription, T1.SecFunctionalityKey";
         sFromString = " FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         sOrderString = "";
         if ( ( AV26OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityKey";
         }
         else if ( ( AV26OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityKey DESC";
         }
         else if ( ( AV26OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityType, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityType DESC, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            sOrderString += " ORDER BY T2.SecFunctionalityDescription, T1.SecFunctionalityId";
         }
         else if ( ( AV26OrderedBy == 4 ) && ( AV27OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.SecFunctionalityDescription DESC, T1.SecFunctionalityId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.SecFunctionalityId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00323( IGxContext context ,
                                             short AV26OrderedBy ,
                                             bool AV27OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (SecFunctionality T1 LEFT JOIN SecFunctionality T2 ON T2.SecFunctionalityId = T1.SecParentFunctionalityId)";
         scmdbuf += sWhereString;
         if ( ( AV26OrderedBy == 1 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 1 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 2 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 2 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 3 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 3 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 4 ) && ! AV27OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV26OrderedBy == 4 ) && ( AV27OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00322(context, (short)dynConstraints[0] , (bool)dynConstraints[1] );
               case 1 :
                     return conditional_H00323(context, (short)dynConstraints[0] , (bool)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00324;
          prmH00324 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("AV9SecRoleIdParm",GXType.Int16,4,0)
          };
          Object[] prmH00322;
          prmH00322 = new Object[] {
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00323;
          prmH00323 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00322", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00322,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00323", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00323,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00324", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId and SecRoleId = :AV9SecRoleIdParm ORDER BY SecFunctionalityId, SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00324,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
