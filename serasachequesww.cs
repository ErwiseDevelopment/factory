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
   public class serasachequesww : GXWebComponent
   {
      public serasachequesww( )
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

      public serasachequesww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SerasaId )
      {
         this.AV29SerasaId = aP0_SerasaId;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "SerasaId");
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
                  AV29SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV29SerasaId", StringUtil.LTrimStr( (decimal)(AV29SerasaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV29SerasaId});
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
                  gxfirstwebparm = GetFirstPar( "SerasaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SerasaId");
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
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
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
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV29SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
         AV15TFSerasaChequesTotalCons = NumberUtil.Val( GetPar( "TFSerasaChequesTotalCons"), ".");
         AV16TFSerasaChequesTotalCons_To = NumberUtil.Val( GetPar( "TFSerasaChequesTotalCons_To"), ".");
         AV17TFSerasaChequesQtdSemFundo = NumberUtil.Val( GetPar( "TFSerasaChequesQtdSemFundo"), ".");
         AV18TFSerasaChequesQtdSemFundo_To = NumberUtil.Val( GetPar( "TFSerasaChequesQtdSemFundo_To"), ".");
         AV19TFSerasaChequesUltOcorSus = context.localUtil.ParseDateParm( GetPar( "TFSerasaChequesUltOcorSus"));
         AV20TFSerasaChequesUltOcorSus_To = context.localUtil.ParseDateParm( GetPar( "TFSerasaChequesUltOcorSus_To"));
         AV24TFSerasaChequesValorSemFundo = NumberUtil.Val( GetPar( "TFSerasaChequesValorSemFundo"), ".");
         AV25TFSerasaChequesValorSemFundo_To = NumberUtil.Val( GetPar( "TFSerasaChequesValorSemFundo_To"), ".");
         AV26TFSerasaChequesTotalSust = NumberUtil.Val( GetPar( "TFSerasaChequesTotalSust"), ".");
         AV27TFSerasaChequesTotalSust_To = NumberUtil.Val( GetPar( "TFSerasaChequesTotalSust_To"), ".");
         AV41Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
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
            PA882( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV41Pgmname = "SerasaChequesWW";
               WS882( ) ;
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
            context.SendWebValue( " Serasa Cheques") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "serasachequesww"+UrlEncode(StringUtil.LTrimStr(AV29SerasaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("serasachequesww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV28DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV28DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASACHEQUESULTOCORSUSAUXDATE", context.localUtil.DToC( AV21DDO_SerasaChequesUltOcorSusAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASACHEQUESULTOCORSUSAUXDATETO", context.localUtil.DToC( AV22DDO_SerasaChequesUltOcorSusAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV29SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV29SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESTOTALCONS", StringUtil.LTrim( StringUtil.NToC( AV15TFSerasaChequesTotalCons, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESTOTALCONS_TO", StringUtil.LTrim( StringUtil.NToC( AV16TFSerasaChequesTotalCons_To, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESQTDSEMFUNDO", StringUtil.LTrim( StringUtil.NToC( AV17TFSerasaChequesQtdSemFundo, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESQTDSEMFUNDO_TO", StringUtil.LTrim( StringUtil.NToC( AV18TFSerasaChequesQtdSemFundo_To, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESULTOCORSUS", context.localUtil.DToC( AV19TFSerasaChequesUltOcorSus, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESULTOCORSUS_TO", context.localUtil.DToC( AV20TFSerasaChequesUltOcorSus_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESVALORSEMFUNDO", StringUtil.LTrim( StringUtil.NToC( AV24TFSerasaChequesValorSemFundo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESVALORSEMFUNDO_TO", StringUtil.LTrim( StringUtil.NToC( AV25TFSerasaChequesValorSemFundo_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESTOTALSUST", StringUtil.LTrim( StringUtil.NToC( AV26TFSerasaChequesTotalSust, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASACHEQUESTOTALSUST_TO", StringUtil.LTrim( StringUtil.NToC( AV27TFSerasaChequesTotalSust_To, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
      }

      protected void RenderHtmlCloseForm882( )
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
         return "SerasaChequesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Serasa Cheques" ;
      }

      protected void WB880( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "serasachequesww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV28DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_serasachequesultocorsusauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_serasachequesultocorsusauxdatetext_Internalname, AV23DDO_SerasaChequesUltOcorSusAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV23DDO_SerasaChequesUltOcorSusAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_serasachequesultocorsusauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaChequesWW.htm");
            /* User Defined Control */
            ucTfserasachequesultocorsus_rangepicker.SetProperty("Start Date", AV21DDO_SerasaChequesUltOcorSusAuxDate);
            ucTfserasachequesultocorsus_rangepicker.SetProperty("End Date", AV22DDO_SerasaChequesUltOcorSusAuxDateTo);
            ucTfserasachequesultocorsus_rangepicker.Render(context, "wwp.daterangepicker", Tfserasachequesultocorsus_rangepicker_Internalname, sPrefix+"TFSERASACHEQUESULTOCORSUS_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
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

      protected void START882( )
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
            Form.Meta.addItem("description", " Serasa Cheques", 0) ;
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
               STRUP880( ) ;
            }
         }
      }

      protected void WS882( )
      {
         START882( ) ;
         EVT882( ) ;
      }

      protected void EVT882( )
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
                                 STRUP880( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP880( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E11882 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP880( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP880( ) ;
                              }
                              AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
                              AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
                              AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
                              AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
                              AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
                              AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
                              AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
                              AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
                              AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
                              AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
                              AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP880( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A693SerasaChequesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaChequesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n662SerasaId = false;
                              A694SerasaChequesTotalCons = context.localUtil.CToN( cgiGet( edtSerasaChequesTotalCons_Internalname), ",", ".");
                              n694SerasaChequesTotalCons = false;
                              A695SerasaChequesQtdSemFundo = context.localUtil.CToN( cgiGet( edtSerasaChequesQtdSemFundo_Internalname), ",", ".");
                              n695SerasaChequesQtdSemFundo = false;
                              A696SerasaChequesUltOcorSus = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSerasaChequesUltOcorSus_Internalname), 0));
                              n696SerasaChequesUltOcorSus = false;
                              A697SerasaChequesValorSemFundo = context.localUtil.CToN( cgiGet( edtSerasaChequesValorSemFundo_Internalname), ",", ".");
                              n697SerasaChequesValorSemFundo = false;
                              A698SerasaChequesTotalSust = context.localUtil.CToN( cgiGet( edtSerasaChequesTotalSust_Internalname), ",", ".");
                              n698SerasaChequesTotalSust = false;
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
                                          GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12882 ();
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
                                          GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13882 ();
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
                                          GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E14882 ();
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
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
                                       STRUP880( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
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

      protected void WE882( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm882( ) ;
            }
         }
      }

      protected void PA882( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasachequesww")), "serasachequesww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasachequesww")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "SerasaId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
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
               GX_FocusControl = edtavDdo_serasachequesultocorsusauxdatetext_Internalname;
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
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV29SerasaId ,
                                       decimal AV15TFSerasaChequesTotalCons ,
                                       decimal AV16TFSerasaChequesTotalCons_To ,
                                       decimal AV17TFSerasaChequesQtdSemFundo ,
                                       decimal AV18TFSerasaChequesQtdSemFundo_To ,
                                       DateTime AV19TFSerasaChequesUltOcorSus ,
                                       DateTime AV20TFSerasaChequesUltOcorSus_To ,
                                       decimal AV24TFSerasaChequesValorSemFundo ,
                                       decimal AV25TFSerasaChequesValorSemFundo_To ,
                                       decimal AV26TFSerasaChequesTotalSust ,
                                       decimal AV27TFSerasaChequesTotalSust_To ,
                                       string AV41Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF882( ) ;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF882( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV41Pgmname = "SerasaChequesWW";
      }

      protected void RF882( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13882 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
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
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31Serasachequeswwds_2_tfserasachequestotalcons ,
                                                 AV32Serasachequeswwds_3_tfserasachequestotalcons_to ,
                                                 AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo ,
                                                 AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to ,
                                                 AV35Serasachequeswwds_6_tfserasachequesultocorsus ,
                                                 AV36Serasachequeswwds_7_tfserasachequesultocorsus_to ,
                                                 AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo ,
                                                 AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to ,
                                                 AV39Serasachequeswwds_10_tfserasachequestotalsust ,
                                                 AV40Serasachequeswwds_11_tfserasachequestotalsust_to ,
                                                 A694SerasaChequesTotalCons ,
                                                 A695SerasaChequesQtdSemFundo ,
                                                 A696SerasaChequesUltOcorSus ,
                                                 A697SerasaChequesValorSemFundo ,
                                                 A698SerasaChequesTotalSust ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A662SerasaId ,
                                                 AV30Serasachequeswwds_1_serasaid } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00882 */
            pr_default.execute(0, new Object[] {AV30Serasachequeswwds_1_serasaid, AV31Serasachequeswwds_2_tfserasachequestotalcons, AV32Serasachequeswwds_3_tfserasachequestotalcons_to, AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo, AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to, AV35Serasachequeswwds_6_tfserasachequesultocorsus, AV36Serasachequeswwds_7_tfserasachequesultocorsus_to, AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo, AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to, AV39Serasachequeswwds_10_tfserasachequestotalsust, AV40Serasachequeswwds_11_tfserasachequestotalsust_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A698SerasaChequesTotalSust = H00882_A698SerasaChequesTotalSust[0];
               n698SerasaChequesTotalSust = H00882_n698SerasaChequesTotalSust[0];
               A697SerasaChequesValorSemFundo = H00882_A697SerasaChequesValorSemFundo[0];
               n697SerasaChequesValorSemFundo = H00882_n697SerasaChequesValorSemFundo[0];
               A696SerasaChequesUltOcorSus = H00882_A696SerasaChequesUltOcorSus[0];
               n696SerasaChequesUltOcorSus = H00882_n696SerasaChequesUltOcorSus[0];
               A695SerasaChequesQtdSemFundo = H00882_A695SerasaChequesQtdSemFundo[0];
               n695SerasaChequesQtdSemFundo = H00882_n695SerasaChequesQtdSemFundo[0];
               A694SerasaChequesTotalCons = H00882_A694SerasaChequesTotalCons[0];
               n694SerasaChequesTotalCons = H00882_n694SerasaChequesTotalCons[0];
               A662SerasaId = H00882_A662SerasaId[0];
               n662SerasaId = H00882_n662SerasaId[0];
               A693SerasaChequesId = H00882_A693SerasaChequesId[0];
               /* Execute user event: Grid.Load */
               E14882 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB880( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes882( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV41Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")), context));
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
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV31Serasachequeswwds_2_tfserasachequestotalcons ,
                                              AV32Serasachequeswwds_3_tfserasachequestotalcons_to ,
                                              AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo ,
                                              AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to ,
                                              AV35Serasachequeswwds_6_tfserasachequesultocorsus ,
                                              AV36Serasachequeswwds_7_tfserasachequesultocorsus_to ,
                                              AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo ,
                                              AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to ,
                                              AV39Serasachequeswwds_10_tfserasachequestotalsust ,
                                              AV40Serasachequeswwds_11_tfserasachequestotalsust_to ,
                                              A694SerasaChequesTotalCons ,
                                              A695SerasaChequesQtdSemFundo ,
                                              A696SerasaChequesUltOcorSus ,
                                              A697SerasaChequesValorSemFundo ,
                                              A698SerasaChequesTotalSust ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A662SerasaId ,
                                              AV30Serasachequeswwds_1_serasaid } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor H00883 */
         pr_default.execute(1, new Object[] {AV30Serasachequeswwds_1_serasaid, AV31Serasachequeswwds_2_tfserasachequestotalcons, AV32Serasachequeswwds_3_tfserasachequestotalcons_to, AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo, AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to, AV35Serasachequeswwds_6_tfserasachequesultocorsus, AV36Serasachequeswwds_7_tfserasachequesultocorsus_to, AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo, AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to, AV39Serasachequeswwds_10_tfserasachequestotalsust, AV40Serasachequeswwds_11_tfserasachequestotalsust_to});
         GRID_nRecordCount = H00883_AGRID_nRecordCount[0];
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
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV29SerasaId, AV15TFSerasaChequesTotalCons, AV16TFSerasaChequesTotalCons_To, AV17TFSerasaChequesQtdSemFundo, AV18TFSerasaChequesQtdSemFundo_To, AV19TFSerasaChequesUltOcorSus, AV20TFSerasaChequesUltOcorSus_To, AV24TFSerasaChequesValorSemFundo, AV25TFSerasaChequesValorSemFundo_To, AV26TFSerasaChequesTotalSust, AV27TFSerasaChequesTotalSust_To, AV41Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV41Pgmname = "SerasaChequesWW";
         edtSerasaChequesId_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaChequesTotalCons_Enabled = 0;
         edtSerasaChequesQtdSemFundo_Enabled = 0;
         edtSerasaChequesUltOcorSus_Enabled = 0;
         edtSerasaChequesValorSemFundo_Enabled = 0;
         edtSerasaChequesTotalSust_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP880( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12882 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV28DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            AV21DDO_SerasaChequesUltOcorSusAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASACHEQUESULTOCORSUSAUXDATE"), 0);
            AV22DDO_SerasaChequesUltOcorSusAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASACHEQUESULTOCORSUSAUXDATETO"), 0);
            wcpOAV29SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV29SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            /* Read variables values. */
            AV23DDO_SerasaChequesUltOcorSusAuxDateText = cgiGet( edtavDdo_serasachequesultocorsusauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV23DDO_SerasaChequesUltOcorSusAuxDateText", AV23DDO_SerasaChequesUltOcorSusAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
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
         E12882 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12882( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFSERASACHEQUESULTOCORSUS_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_serasachequesultocorsusauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV28DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV28DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13882( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30Serasachequeswwds_1_serasaid = AV29SerasaId;
         AV31Serasachequeswwds_2_tfserasachequestotalcons = AV15TFSerasaChequesTotalCons;
         AV32Serasachequeswwds_3_tfserasachequestotalcons_to = AV16TFSerasaChequesTotalCons_To;
         AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo = AV17TFSerasaChequesQtdSemFundo;
         AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to = AV18TFSerasaChequesQtdSemFundo_To;
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = AV19TFSerasaChequesUltOcorSus;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = AV20TFSerasaChequesUltOcorSus_To;
         AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo = AV24TFSerasaChequesValorSemFundo;
         AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to = AV25TFSerasaChequesValorSemFundo_To;
         AV39Serasachequeswwds_10_tfserasachequestotalsust = AV26TFSerasaChequesTotalSust;
         AV40Serasachequeswwds_11_tfserasachequestotalsust_to = AV27TFSerasaChequesTotalSust_To;
      }

      protected void E11882( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaChequesTotalCons") == 0 )
            {
               AV15TFSerasaChequesTotalCons = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV15TFSerasaChequesTotalCons", StringUtil.LTrimStr( AV15TFSerasaChequesTotalCons, 15, 2));
               AV16TFSerasaChequesTotalCons_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV16TFSerasaChequesTotalCons_To", StringUtil.LTrimStr( AV16TFSerasaChequesTotalCons_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaChequesQtdSemFundo") == 0 )
            {
               AV17TFSerasaChequesQtdSemFundo = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV17TFSerasaChequesQtdSemFundo", StringUtil.LTrimStr( AV17TFSerasaChequesQtdSemFundo, 15, 2));
               AV18TFSerasaChequesQtdSemFundo_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV18TFSerasaChequesQtdSemFundo_To", StringUtil.LTrimStr( AV18TFSerasaChequesQtdSemFundo_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaChequesUltOcorSus") == 0 )
            {
               AV19TFSerasaChequesUltOcorSus = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV19TFSerasaChequesUltOcorSus", context.localUtil.Format(AV19TFSerasaChequesUltOcorSus, "99/99/99"));
               AV20TFSerasaChequesUltOcorSus_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV20TFSerasaChequesUltOcorSus_To", context.localUtil.Format(AV20TFSerasaChequesUltOcorSus_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaChequesValorSemFundo") == 0 )
            {
               AV24TFSerasaChequesValorSemFundo = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV24TFSerasaChequesValorSemFundo", StringUtil.LTrimStr( AV24TFSerasaChequesValorSemFundo, 18, 2));
               AV25TFSerasaChequesValorSemFundo_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV25TFSerasaChequesValorSemFundo_To", StringUtil.LTrimStr( AV25TFSerasaChequesValorSemFundo_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaChequesTotalSust") == 0 )
            {
               AV26TFSerasaChequesTotalSust = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV26TFSerasaChequesTotalSust", StringUtil.LTrimStr( AV26TFSerasaChequesTotalSust, 15, 2));
               AV27TFSerasaChequesTotalSust_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV27TFSerasaChequesTotalSust_To", StringUtil.LTrimStr( AV27TFSerasaChequesTotalSust_To, 15, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E14882( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "serasacheques"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A693SerasaChequesId,9,0));
         edtSerasaChequesTotalCons_Link = formatLink("serasacheques") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV41Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV41Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV41Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACHEQUESTOTALCONS") == 0 )
            {
               AV15TFSerasaChequesTotalCons = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV15TFSerasaChequesTotalCons", StringUtil.LTrimStr( AV15TFSerasaChequesTotalCons, 15, 2));
               AV16TFSerasaChequesTotalCons_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV16TFSerasaChequesTotalCons_To", StringUtil.LTrimStr( AV16TFSerasaChequesTotalCons_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACHEQUESQTDSEMFUNDO") == 0 )
            {
               AV17TFSerasaChequesQtdSemFundo = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV17TFSerasaChequesQtdSemFundo", StringUtil.LTrimStr( AV17TFSerasaChequesQtdSemFundo, 15, 2));
               AV18TFSerasaChequesQtdSemFundo_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV18TFSerasaChequesQtdSemFundo_To", StringUtil.LTrimStr( AV18TFSerasaChequesQtdSemFundo_To, 15, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACHEQUESULTOCORSUS") == 0 )
            {
               AV19TFSerasaChequesUltOcorSus = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV19TFSerasaChequesUltOcorSus", context.localUtil.Format(AV19TFSerasaChequesUltOcorSus, "99/99/99"));
               AV20TFSerasaChequesUltOcorSus_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV20TFSerasaChequesUltOcorSus_To", context.localUtil.Format(AV20TFSerasaChequesUltOcorSus_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACHEQUESVALORSEMFUNDO") == 0 )
            {
               AV24TFSerasaChequesValorSemFundo = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV24TFSerasaChequesValorSemFundo", StringUtil.LTrimStr( AV24TFSerasaChequesValorSemFundo, 18, 2));
               AV25TFSerasaChequesValorSemFundo_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV25TFSerasaChequesValorSemFundo_To", StringUtil.LTrimStr( AV25TFSerasaChequesValorSemFundo_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASACHEQUESTOTALSUST") == 0 )
            {
               AV26TFSerasaChequesTotalSust = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV26TFSerasaChequesTotalSust", StringUtil.LTrimStr( AV26TFSerasaChequesTotalSust, 15, 2));
               AV27TFSerasaChequesTotalSust_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV27TFSerasaChequesTotalSust_To", StringUtil.LTrimStr( AV27TFSerasaChequesTotalSust_To, 15, 2));
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         Ddo_grid_Filteredtext_set = ((Convert.ToDecimal(0)==AV15TFSerasaChequesTotalCons) ? "" : StringUtil.Str( AV15TFSerasaChequesTotalCons, 15, 2))+"|"+((Convert.ToDecimal(0)==AV17TFSerasaChequesQtdSemFundo) ? "" : StringUtil.Str( AV17TFSerasaChequesQtdSemFundo, 15, 2))+"|"+((DateTime.MinValue==AV19TFSerasaChequesUltOcorSus) ? "" : context.localUtil.DToC( AV19TFSerasaChequesUltOcorSus, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV24TFSerasaChequesValorSemFundo) ? "" : StringUtil.Str( AV24TFSerasaChequesValorSemFundo, 18, 2))+"|"+((Convert.ToDecimal(0)==AV26TFSerasaChequesTotalSust) ? "" : StringUtil.Str( AV26TFSerasaChequesTotalSust, 15, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((Convert.ToDecimal(0)==AV16TFSerasaChequesTotalCons_To) ? "" : StringUtil.Str( AV16TFSerasaChequesTotalCons_To, 15, 2))+"|"+((Convert.ToDecimal(0)==AV18TFSerasaChequesQtdSemFundo_To) ? "" : StringUtil.Str( AV18TFSerasaChequesQtdSemFundo_To, 15, 2))+"|"+((DateTime.MinValue==AV20TFSerasaChequesUltOcorSus_To) ? "" : context.localUtil.DToC( AV20TFSerasaChequesUltOcorSus_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV25TFSerasaChequesValorSemFundo_To) ? "" : StringUtil.Str( AV25TFSerasaChequesValorSemFundo_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV27TFSerasaChequesTotalSust_To) ? "" : StringUtil.Str( AV27TFSerasaChequesTotalSust_To, 15, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV41Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACHEQUESTOTALCONS",  "",  !((Convert.ToDecimal(0)==AV15TFSerasaChequesTotalCons)&&(Convert.ToDecimal(0)==AV16TFSerasaChequesTotalCons_To)),  0,  StringUtil.Trim( StringUtil.Str( AV15TFSerasaChequesTotalCons, 15, 2)),  ((Convert.ToDecimal(0)==AV15TFSerasaChequesTotalCons) ? "" : StringUtil.Trim( context.localUtil.Format( AV15TFSerasaChequesTotalCons, "ZZZZZZZZZZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV16TFSerasaChequesTotalCons_To, 15, 2)),  ((Convert.ToDecimal(0)==AV16TFSerasaChequesTotalCons_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV16TFSerasaChequesTotalCons_To, "ZZZZZZZZZZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACHEQUESQTDSEMFUNDO",  "",  !((Convert.ToDecimal(0)==AV17TFSerasaChequesQtdSemFundo)&&(Convert.ToDecimal(0)==AV18TFSerasaChequesQtdSemFundo_To)),  0,  StringUtil.Trim( StringUtil.Str( AV17TFSerasaChequesQtdSemFundo, 15, 2)),  ((Convert.ToDecimal(0)==AV17TFSerasaChequesQtdSemFundo) ? "" : StringUtil.Trim( context.localUtil.Format( AV17TFSerasaChequesQtdSemFundo, "ZZZZZZZZZZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV18TFSerasaChequesQtdSemFundo_To, 15, 2)),  ((Convert.ToDecimal(0)==AV18TFSerasaChequesQtdSemFundo_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV18TFSerasaChequesQtdSemFundo_To, "ZZZZZZZZZZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACHEQUESULTOCORSUS",  "",  !((DateTime.MinValue==AV19TFSerasaChequesUltOcorSus)&&(DateTime.MinValue==AV20TFSerasaChequesUltOcorSus_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV19TFSerasaChequesUltOcorSus, 4, "/")),  ((DateTime.MinValue==AV19TFSerasaChequesUltOcorSus) ? "" : StringUtil.Trim( context.localUtil.Format( AV19TFSerasaChequesUltOcorSus, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV20TFSerasaChequesUltOcorSus_To, 4, "/")),  ((DateTime.MinValue==AV20TFSerasaChequesUltOcorSus_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV20TFSerasaChequesUltOcorSus_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACHEQUESVALORSEMFUNDO",  "",  !((Convert.ToDecimal(0)==AV24TFSerasaChequesValorSemFundo)&&(Convert.ToDecimal(0)==AV25TFSerasaChequesValorSemFundo_To)),  0,  StringUtil.Trim( StringUtil.Str( AV24TFSerasaChequesValorSemFundo, 18, 2)),  ((Convert.ToDecimal(0)==AV24TFSerasaChequesValorSemFundo) ? "" : StringUtil.Trim( context.localUtil.Format( AV24TFSerasaChequesValorSemFundo, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV25TFSerasaChequesValorSemFundo_To, 18, 2)),  ((Convert.ToDecimal(0)==AV25TFSerasaChequesValorSemFundo_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV25TFSerasaChequesValorSemFundo_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASACHEQUESTOTALSUST",  "",  !((Convert.ToDecimal(0)==AV26TFSerasaChequesTotalSust)&&(Convert.ToDecimal(0)==AV27TFSerasaChequesTotalSust_To)),  0,  StringUtil.Trim( StringUtil.Str( AV26TFSerasaChequesTotalSust, 15, 2)),  ((Convert.ToDecimal(0)==AV26TFSerasaChequesTotalSust) ? "" : StringUtil.Trim( context.localUtil.Format( AV26TFSerasaChequesTotalSust, "ZZZZZZZZZZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV27TFSerasaChequesTotalSust_To, 15, 2)),  ((Convert.ToDecimal(0)==AV27TFSerasaChequesTotalSust_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV27TFSerasaChequesTotalSust_To, "ZZZZZZZZZZZ9.99")))) ;
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV41Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV41Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "SerasaCheques";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SerasaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV29SerasaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV29SerasaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV29SerasaId", StringUtil.LTrimStr( (decimal)(AV29SerasaId), 9, 0));
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
         PA882( ) ;
         WS882( ) ;
         WE882( ) ;
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
         sCtrlAV29SerasaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA882( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "serasachequesww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA882( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV29SerasaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV29SerasaId", StringUtil.LTrimStr( (decimal)(AV29SerasaId), 9, 0));
         }
         wcpOAV29SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV29SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV29SerasaId != wcpOAV29SerasaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV29SerasaId = AV29SerasaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV29SerasaId = cgiGet( sPrefix+"AV29SerasaId_CTRL");
         if ( StringUtil.Len( sCtrlAV29SerasaId) > 0 )
         {
            AV29SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV29SerasaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV29SerasaId", StringUtil.LTrimStr( (decimal)(AV29SerasaId), 9, 0));
         }
         else
         {
            AV29SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV29SerasaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
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
         PA882( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS882( ) ;
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
         WS882( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV29SerasaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29SerasaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV29SerasaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV29SerasaId_CTRL", StringUtil.RTrim( sCtrlAV29SerasaId));
         }
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
         WE882( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019195547", true, true);
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
         context.AddJavascriptSource("serasachequesww.js", "?202561019195548", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtSerasaChequesId_Internalname = sPrefix+"SERASACHEQUESID_"+sGXsfl_12_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_idx;
         edtSerasaChequesTotalCons_Internalname = sPrefix+"SERASACHEQUESTOTALCONS_"+sGXsfl_12_idx;
         edtSerasaChequesQtdSemFundo_Internalname = sPrefix+"SERASACHEQUESQTDSEMFUNDO_"+sGXsfl_12_idx;
         edtSerasaChequesUltOcorSus_Internalname = sPrefix+"SERASACHEQUESULTOCORSUS_"+sGXsfl_12_idx;
         edtSerasaChequesValorSemFundo_Internalname = sPrefix+"SERASACHEQUESVALORSEMFUNDO_"+sGXsfl_12_idx;
         edtSerasaChequesTotalSust_Internalname = sPrefix+"SERASACHEQUESTOTALSUST_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtSerasaChequesId_Internalname = sPrefix+"SERASACHEQUESID_"+sGXsfl_12_fel_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_fel_idx;
         edtSerasaChequesTotalCons_Internalname = sPrefix+"SERASACHEQUESTOTALCONS_"+sGXsfl_12_fel_idx;
         edtSerasaChequesQtdSemFundo_Internalname = sPrefix+"SERASACHEQUESQTDSEMFUNDO_"+sGXsfl_12_fel_idx;
         edtSerasaChequesUltOcorSus_Internalname = sPrefix+"SERASACHEQUESULTOCORSUS_"+sGXsfl_12_fel_idx;
         edtSerasaChequesValorSemFundo_Internalname = sPrefix+"SERASACHEQUESVALORSEMFUNDO_"+sGXsfl_12_fel_idx;
         edtSerasaChequesTotalSust_Internalname = sPrefix+"SERASACHEQUESTOTALSUST_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB880( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A693SerasaChequesId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A693SerasaChequesId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaChequesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesTotalCons_Internalname,StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A694SerasaChequesTotalCons, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSerasaChequesTotalCons_Link,(string)"",(string)"",(string)"",(string)edtSerasaChequesTotalCons_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesQtdSemFundo_Internalname,StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A695SerasaChequesQtdSemFundo, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaChequesQtdSemFundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesUltOcorSus_Internalname,context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99"),context.localUtil.Format( A696SerasaChequesUltOcorSus, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaChequesUltOcorSus_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesValorSemFundo_Internalname,StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A697SerasaChequesValorSemFundo, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaChequesValorSemFundo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaChequesTotalSust_Internalname,StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A698SerasaChequesTotalSust, "ZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaChequesTotalSust_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes882( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cheques Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total de consultas de cheques") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantidade de cheques sem fundo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Último cheque sustado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor dos cheques sem fundo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total sustado") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A693SerasaChequesId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A694SerasaChequesTotalCons, 15, 2, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSerasaChequesTotalCons_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A695SerasaChequesQtdSemFundo, 15, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A696SerasaChequesUltOcorSus, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A697SerasaChequesValorSemFundo, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A698SerasaChequesTotalSust, 15, 2, ".", ""))));
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
         edtSerasaChequesId_Internalname = sPrefix+"SERASACHEQUESID";
         edtSerasaId_Internalname = sPrefix+"SERASAID";
         edtSerasaChequesTotalCons_Internalname = sPrefix+"SERASACHEQUESTOTALCONS";
         edtSerasaChequesQtdSemFundo_Internalname = sPrefix+"SERASACHEQUESQTDSEMFUNDO";
         edtSerasaChequesUltOcorSus_Internalname = sPrefix+"SERASACHEQUESULTOCORSUS";
         edtSerasaChequesValorSemFundo_Internalname = sPrefix+"SERASACHEQUESVALORSEMFUNDO";
         edtSerasaChequesTotalSust_Internalname = sPrefix+"SERASACHEQUESTOTALSUST";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_serasachequesultocorsusauxdatetext_Internalname = sPrefix+"vDDO_SERASACHEQUESULTOCORSUSAUXDATETEXT";
         Tfserasachequesultocorsus_rangepicker_Internalname = sPrefix+"TFSERASACHEQUESULTOCORSUS_RANGEPICKER";
         divDdo_serasachequesultocorsusauxdates_Internalname = sPrefix+"DDO_SERASACHEQUESULTOCORSUSAUXDATES";
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
         edtSerasaChequesTotalSust_Jsonclick = "";
         edtSerasaChequesValorSemFundo_Jsonclick = "";
         edtSerasaChequesUltOcorSus_Jsonclick = "";
         edtSerasaChequesQtdSemFundo_Jsonclick = "";
         edtSerasaChequesTotalCons_Jsonclick = "";
         edtSerasaChequesTotalCons_Link = "";
         edtSerasaId_Jsonclick = "";
         edtSerasaChequesId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtSerasaChequesTotalSust_Enabled = 0;
         edtSerasaChequesValorSemFundo_Enabled = 0;
         edtSerasaChequesUltOcorSus_Enabled = 0;
         edtSerasaChequesQtdSemFundo_Enabled = 0;
         edtSerasaChequesTotalCons_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaChequesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_serasachequesultocorsusauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "15.2|15.2||18.2|15.2";
         Ddo_grid_Filterisrange = "T|T|P|T|T";
         Ddo_grid_Filtertype = "Numeric|Numeric|Date|Numeric|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5";
         Ddo_grid_Columnids = "2:SerasaChequesTotalCons|3:SerasaChequesQtdSemFundo|4:SerasaChequesUltOcorSus|5:SerasaChequesValorSemFundo|6:SerasaChequesTotalSust";
         Ddo_grid_Gridinternalname = "";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11882","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14882","iparms":[{"av":"A693SerasaChequesId","fld":"SERASACHEQUESID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSerasaChequesTotalCons_Link","ctrl":"SERASACHEQUESTOTALCONS","prop":"Link"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV29SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaChequesTotalCons","fld":"vTFSERASACHEQUESTOTALCONS","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV16TFSerasaChequesTotalCons_To","fld":"vTFSERASACHEQUESTOTALCONS_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV17TFSerasaChequesQtdSemFundo","fld":"vTFSERASACHEQUESQTDSEMFUNDO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV18TFSerasaChequesQtdSemFundo_To","fld":"vTFSERASACHEQUESQTDSEMFUNDO_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV19TFSerasaChequesUltOcorSus","fld":"vTFSERASACHEQUESULTOCORSUS","type":"date"},{"av":"AV20TFSerasaChequesUltOcorSus_To","fld":"vTFSERASACHEQUESULTOCORSUS_TO","type":"date"},{"av":"AV24TFSerasaChequesValorSemFundo","fld":"vTFSERASACHEQUESVALORSEMFUNDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV25TFSerasaChequesValorSemFundo_To","fld":"vTFSERASACHEQUESVALORSEMFUNDO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV26TFSerasaChequesTotalSust","fld":"vTFSERASACHEQUESTOTALSUST","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV27TFSerasaChequesTotalSust_To","fld":"vTFSERASACHEQUESTOTALSUST_TO","pic":"ZZZZZZZZZZZ9.99","type":"decimal"},{"av":"AV41Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Serasachequestotalsust","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV19TFSerasaChequesUltOcorSus = DateTime.MinValue;
         AV20TFSerasaChequesUltOcorSus_To = DateTime.MinValue;
         AV41Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV28DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21DDO_SerasaChequesUltOcorSusAuxDate = DateTime.MinValue;
         AV22DDO_SerasaChequesUltOcorSusAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         TempTags = "";
         AV23DDO_SerasaChequesUltOcorSusAuxDateText = "";
         ucTfserasachequesultocorsus_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV35Serasachequeswwds_6_tfserasachequesultocorsus = DateTime.MinValue;
         AV36Serasachequeswwds_7_tfserasachequesultocorsus_to = DateTime.MinValue;
         A696SerasaChequesUltOcorSus = DateTime.MinValue;
         GXDecQS = "";
         H00882_A698SerasaChequesTotalSust = new decimal[1] ;
         H00882_n698SerasaChequesTotalSust = new bool[] {false} ;
         H00882_A697SerasaChequesValorSemFundo = new decimal[1] ;
         H00882_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         H00882_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         H00882_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         H00882_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         H00882_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         H00882_A694SerasaChequesTotalCons = new decimal[1] ;
         H00882_n694SerasaChequesTotalCons = new bool[] {false} ;
         H00882_A662SerasaId = new int[1] ;
         H00882_n662SerasaId = new bool[] {false} ;
         H00882_A693SerasaChequesId = new int[1] ;
         H00883_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV29SerasaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasachequesww__default(),
            new Object[][] {
                new Object[] {
               H00882_A698SerasaChequesTotalSust, H00882_n698SerasaChequesTotalSust, H00882_A697SerasaChequesValorSemFundo, H00882_n697SerasaChequesValorSemFundo, H00882_A696SerasaChequesUltOcorSus, H00882_n696SerasaChequesUltOcorSus, H00882_A695SerasaChequesQtdSemFundo, H00882_n695SerasaChequesQtdSemFundo, H00882_A694SerasaChequesTotalCons, H00882_n694SerasaChequesTotalCons,
               H00882_A662SerasaId, H00882_n662SerasaId, H00882_A693SerasaChequesId
               }
               , new Object[] {
               H00883_AGRID_nRecordCount
               }
            }
         );
         AV41Pgmname = "SerasaChequesWW";
         /* GeneXus formulas. */
         AV41Pgmname = "SerasaChequesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV29SerasaId ;
      private int wcpOAV29SerasaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV30Serasachequeswwds_1_serasaid ;
      private int A693SerasaChequesId ;
      private int A662SerasaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSerasaChequesId_Enabled ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaChequesTotalCons_Enabled ;
      private int edtSerasaChequesQtdSemFundo_Enabled ;
      private int edtSerasaChequesUltOcorSus_Enabled ;
      private int edtSerasaChequesValorSemFundo_Enabled ;
      private int edtSerasaChequesTotalSust_Enabled ;
      private int AV42GXV1 ;
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
      private decimal AV15TFSerasaChequesTotalCons ;
      private decimal AV16TFSerasaChequesTotalCons_To ;
      private decimal AV17TFSerasaChequesQtdSemFundo ;
      private decimal AV18TFSerasaChequesQtdSemFundo_To ;
      private decimal AV24TFSerasaChequesValorSemFundo ;
      private decimal AV25TFSerasaChequesValorSemFundo_To ;
      private decimal AV26TFSerasaChequesTotalSust ;
      private decimal AV27TFSerasaChequesTotalSust_To ;
      private decimal AV31Serasachequeswwds_2_tfserasachequestotalcons ;
      private decimal AV32Serasachequeswwds_3_tfserasachequestotalcons_to ;
      private decimal AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo ;
      private decimal AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to ;
      private decimal AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo ;
      private decimal AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to ;
      private decimal AV39Serasachequeswwds_10_tfserasachequestotalsust ;
      private decimal AV40Serasachequeswwds_11_tfserasachequestotalsust_to ;
      private decimal A694SerasaChequesTotalCons ;
      private decimal A695SerasaChequesQtdSemFundo ;
      private decimal A697SerasaChequesValorSemFundo ;
      private decimal A698SerasaChequesTotalSust ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string AV41Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_serasachequesultocorsusauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_serasachequesultocorsusauxdatetext_Internalname ;
      private string edtavDdo_serasachequesultocorsusauxdatetext_Jsonclick ;
      private string Tfserasachequesultocorsus_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSerasaChequesId_Internalname ;
      private string edtSerasaId_Internalname ;
      private string edtSerasaChequesTotalCons_Internalname ;
      private string edtSerasaChequesQtdSemFundo_Internalname ;
      private string edtSerasaChequesUltOcorSus_Internalname ;
      private string edtSerasaChequesValorSemFundo_Internalname ;
      private string edtSerasaChequesTotalSust_Internalname ;
      private string GXDecQS ;
      private string edtSerasaChequesTotalCons_Link ;
      private string sCtrlAV29SerasaId ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSerasaChequesId_Jsonclick ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaChequesTotalCons_Jsonclick ;
      private string edtSerasaChequesQtdSemFundo_Jsonclick ;
      private string edtSerasaChequesUltOcorSus_Jsonclick ;
      private string edtSerasaChequesValorSemFundo_Jsonclick ;
      private string edtSerasaChequesTotalSust_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV19TFSerasaChequesUltOcorSus ;
      private DateTime AV20TFSerasaChequesUltOcorSus_To ;
      private DateTime AV21DDO_SerasaChequesUltOcorSusAuxDate ;
      private DateTime AV22DDO_SerasaChequesUltOcorSusAuxDateTo ;
      private DateTime AV35Serasachequeswwds_6_tfserasachequesultocorsus ;
      private DateTime AV36Serasachequeswwds_7_tfserasachequesultocorsus_to ;
      private DateTime A696SerasaChequesUltOcorSus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n662SerasaId ;
      private bool n694SerasaChequesTotalCons ;
      private bool n695SerasaChequesQtdSemFundo ;
      private bool n696SerasaChequesUltOcorSus ;
      private bool n697SerasaChequesValorSemFundo ;
      private bool n698SerasaChequesTotalSust ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV23DDO_SerasaChequesUltOcorSusAuxDateText ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfserasachequesultocorsus_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV28DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00882_A698SerasaChequesTotalSust ;
      private bool[] H00882_n698SerasaChequesTotalSust ;
      private decimal[] H00882_A697SerasaChequesValorSemFundo ;
      private bool[] H00882_n697SerasaChequesValorSemFundo ;
      private DateTime[] H00882_A696SerasaChequesUltOcorSus ;
      private bool[] H00882_n696SerasaChequesUltOcorSus ;
      private decimal[] H00882_A695SerasaChequesQtdSemFundo ;
      private bool[] H00882_n695SerasaChequesQtdSemFundo ;
      private decimal[] H00882_A694SerasaChequesTotalCons ;
      private bool[] H00882_n694SerasaChequesTotalCons ;
      private int[] H00882_A662SerasaId ;
      private bool[] H00882_n662SerasaId ;
      private int[] H00882_A693SerasaChequesId ;
      private long[] H00883_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasachequesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00882( IGxContext context ,
                                             decimal AV31Serasachequeswwds_2_tfserasachequestotalcons ,
                                             decimal AV32Serasachequeswwds_3_tfserasachequestotalcons_to ,
                                             decimal AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo ,
                                             decimal AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to ,
                                             DateTime AV35Serasachequeswwds_6_tfserasachequesultocorsus ,
                                             DateTime AV36Serasachequeswwds_7_tfserasachequesultocorsus_to ,
                                             decimal AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo ,
                                             decimal AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to ,
                                             decimal AV39Serasachequeswwds_10_tfserasachequestotalsust ,
                                             decimal AV40Serasachequeswwds_11_tfserasachequestotalsust_to ,
                                             decimal A694SerasaChequesTotalCons ,
                                             decimal A695SerasaChequesQtdSemFundo ,
                                             DateTime A696SerasaChequesUltOcorSus ,
                                             decimal A697SerasaChequesValorSemFundo ,
                                             decimal A698SerasaChequesTotalSust ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV30Serasachequeswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SerasaChequesTotalSust, SerasaChequesValorSemFundo, SerasaChequesUltOcorSus, SerasaChequesQtdSemFundo, SerasaChequesTotalCons, SerasaId, SerasaChequesId";
         sFromString = " FROM SerasaCheques";
         sOrderString = "";
         AddWhere(sWhereString, "(SerasaId = :AV30Serasachequeswwds_1_serasaid)");
         if ( ! (Convert.ToDecimal(0)==AV31Serasachequeswwds_2_tfserasachequestotalcons) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalCons >= :AV31Serasachequeswwds_2_tfserasachequestotalcons)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32Serasachequeswwds_3_tfserasachequestotalcons_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalCons <= :AV32Serasachequeswwds_3_tfserasachequestotalcons_to)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo) )
         {
            AddWhere(sWhereString, "(SerasaChequesQtdSemFundo >= :AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesQtdSemFundo <= :AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV35Serasachequeswwds_6_tfserasachequesultocorsus) )
         {
            AddWhere(sWhereString, "(SerasaChequesUltOcorSus >= :AV35Serasachequeswwds_6_tfserasachequesultocorsus)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV36Serasachequeswwds_7_tfserasachequesultocorsus_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesUltOcorSus <= :AV36Serasachequeswwds_7_tfserasachequesultocorsus_to)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo) )
         {
            AddWhere(sWhereString, "(SerasaChequesValorSemFundo >= :AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesValorSemFundo <= :AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39Serasachequeswwds_10_tfserasachequestotalsust) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalSust >= :AV39Serasachequeswwds_10_tfserasachequestotalsust)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40Serasachequeswwds_11_tfserasachequestotalsust_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalSust <= :AV40Serasachequeswwds_11_tfserasachequestotalsust_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaChequesTotalCons, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaChequesTotalCons DESC, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaChequesQtdSemFundo, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaChequesQtdSemFundo DESC, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaChequesUltOcorSus, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaChequesUltOcorSus DESC, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaChequesValorSemFundo, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaChequesValorSemFundo DESC, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaChequesTotalSust, SerasaChequesId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaChequesTotalSust DESC, SerasaChequesId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY SerasaChequesId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00883( IGxContext context ,
                                             decimal AV31Serasachequeswwds_2_tfserasachequestotalcons ,
                                             decimal AV32Serasachequeswwds_3_tfserasachequestotalcons_to ,
                                             decimal AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo ,
                                             decimal AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to ,
                                             DateTime AV35Serasachequeswwds_6_tfserasachequesultocorsus ,
                                             DateTime AV36Serasachequeswwds_7_tfserasachequesultocorsus_to ,
                                             decimal AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo ,
                                             decimal AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to ,
                                             decimal AV39Serasachequeswwds_10_tfserasachequestotalsust ,
                                             decimal AV40Serasachequeswwds_11_tfserasachequestotalsust_to ,
                                             decimal A694SerasaChequesTotalCons ,
                                             decimal A695SerasaChequesQtdSemFundo ,
                                             DateTime A696SerasaChequesUltOcorSus ,
                                             decimal A697SerasaChequesValorSemFundo ,
                                             decimal A698SerasaChequesTotalSust ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV30Serasachequeswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM SerasaCheques";
         AddWhere(sWhereString, "(SerasaId = :AV30Serasachequeswwds_1_serasaid)");
         if ( ! (Convert.ToDecimal(0)==AV31Serasachequeswwds_2_tfserasachequestotalcons) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalCons >= :AV31Serasachequeswwds_2_tfserasachequestotalcons)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32Serasachequeswwds_3_tfserasachequestotalcons_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalCons <= :AV32Serasachequeswwds_3_tfserasachequestotalcons_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo) )
         {
            AddWhere(sWhereString, "(SerasaChequesQtdSemFundo >= :AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesQtdSemFundo <= :AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV35Serasachequeswwds_6_tfserasachequesultocorsus) )
         {
            AddWhere(sWhereString, "(SerasaChequesUltOcorSus >= :AV35Serasachequeswwds_6_tfserasachequesultocorsus)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV36Serasachequeswwds_7_tfserasachequesultocorsus_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesUltOcorSus <= :AV36Serasachequeswwds_7_tfserasachequesultocorsus_to)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo) )
         {
            AddWhere(sWhereString, "(SerasaChequesValorSemFundo >= :AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesValorSemFundo <= :AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV39Serasachequeswwds_10_tfserasachequestotalsust) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalSust >= :AV39Serasachequeswwds_10_tfserasachequestotalsust)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV40Serasachequeswwds_11_tfserasachequestotalsust_to) )
         {
            AddWhere(sWhereString, "(SerasaChequesTotalSust <= :AV40Serasachequeswwds_11_tfserasachequestotalsust_to)");
         }
         else
         {
            GXv_int4[10] = 1;
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00882(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (DateTime)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] );
               case 1 :
                     return conditional_H00883(context, (decimal)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (DateTime)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] );
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
          Object[] prmH00882;
          prmH00882 = new Object[] {
          new ParDef("AV30Serasachequeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV31Serasachequeswwds_2_tfserasachequestotalcons",GXType.Number,15,2) ,
          new ParDef("AV32Serasachequeswwds_3_tfserasachequestotalcons_to",GXType.Number,15,2) ,
          new ParDef("AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo",GXType.Number,15,2) ,
          new ParDef("AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to",GXType.Number,15,2) ,
          new ParDef("AV35Serasachequeswwds_6_tfserasachequesultocorsus",GXType.Date,8,0) ,
          new ParDef("AV36Serasachequeswwds_7_tfserasachequesultocorsus_to",GXType.Date,8,0) ,
          new ParDef("AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo",GXType.Number,18,2) ,
          new ParDef("AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to",GXType.Number,18,2) ,
          new ParDef("AV39Serasachequeswwds_10_tfserasachequestotalsust",GXType.Number,15,2) ,
          new ParDef("AV40Serasachequeswwds_11_tfserasachequestotalsust_to",GXType.Number,15,2) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00883;
          prmH00883 = new Object[] {
          new ParDef("AV30Serasachequeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV31Serasachequeswwds_2_tfserasachequestotalcons",GXType.Number,15,2) ,
          new ParDef("AV32Serasachequeswwds_3_tfserasachequestotalcons_to",GXType.Number,15,2) ,
          new ParDef("AV33Serasachequeswwds_4_tfserasachequesqtdsemfundo",GXType.Number,15,2) ,
          new ParDef("AV34Serasachequeswwds_5_tfserasachequesqtdsemfundo_to",GXType.Number,15,2) ,
          new ParDef("AV35Serasachequeswwds_6_tfserasachequesultocorsus",GXType.Date,8,0) ,
          new ParDef("AV36Serasachequeswwds_7_tfserasachequesultocorsus_to",GXType.Date,8,0) ,
          new ParDef("AV37Serasachequeswwds_8_tfserasachequesvalorsemfundo",GXType.Number,18,2) ,
          new ParDef("AV38Serasachequeswwds_9_tfserasachequesvalorsemfundo_to",GXType.Number,18,2) ,
          new ParDef("AV39Serasachequeswwds_10_tfserasachequestotalsust",GXType.Number,15,2) ,
          new ParDef("AV40Serasachequeswwds_11_tfserasachequestotalsust_to",GXType.Number,15,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00882", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00882,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00883", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00883,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
