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
   public class serasaprotestosww : GXWebComponent
   {
      public serasaprotestosww( )
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

      public serasaprotestosww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SerasaId )
      {
         this.AV27SerasaId = aP0_SerasaId;
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
                  AV27SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV27SerasaId", StringUtil.LTrimStr( (decimal)(AV27SerasaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV27SerasaId});
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
         AV27SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
         AV15TFSerasaProtestosData = context.localUtil.ParseDateParm( GetPar( "TFSerasaProtestosData"));
         AV16TFSerasaProtestosData_To = context.localUtil.ParseDateParm( GetPar( "TFSerasaProtestosData_To"));
         AV20TFSerasaProtestosValor = NumberUtil.Val( GetPar( "TFSerasaProtestosValor"), ".");
         AV21TFSerasaProtestosValor_To = NumberUtil.Val( GetPar( "TFSerasaProtestosValor_To"), ".");
         AV22TFSerasaProtestosCartorio = GetPar( "TFSerasaProtestosCartorio");
         AV23TFSerasaProtestosCartorio_Sel = GetPar( "TFSerasaProtestosCartorio_Sel");
         AV24TFSerasaProtestosCidade = GetPar( "TFSerasaProtestosCidade");
         AV25TFSerasaProtestosCidade_Sel = GetPar( "TFSerasaProtestosCidade_Sel");
         AV37Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
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
            PA852( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV37Pgmname = "SerasaProtestosWW";
               WS852( ) ;
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
            context.SendWebValue( " Serasa Protestos") ;
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
            GXEncryptionTmp = "serasaprotestosww"+UrlEncode(StringUtil.LTrimStr(AV27SerasaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("serasaprotestosww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV26DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASAPROTESTOSDATAAUXDATE", context.localUtil.DToC( AV17DDO_SerasaProtestosDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASAPROTESTOSDATAAUXDATETO", context.localUtil.DToC( AV18DDO_SerasaProtestosDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV27SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV27SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSDATA", context.localUtil.DToC( AV15TFSerasaProtestosData, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSDATA_TO", context.localUtil.DToC( AV16TFSerasaProtestosData_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSVALOR", StringUtil.LTrim( StringUtil.NToC( AV20TFSerasaProtestosValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV21TFSerasaProtestosValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSCARTORIO", AV22TFSerasaProtestosCartorio);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSCARTORIO_SEL", AV23TFSerasaProtestosCartorio_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSCIDADE", AV24TFSerasaProtestosCidade);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAPROTESTOSCIDADE_SEL", AV25TFSerasaProtestosCidade_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
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

      protected void RenderHtmlCloseForm852( )
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
         return "SerasaProtestosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Serasa Protestos" ;
      }

      protected void WB850( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "serasaprotestosww");
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
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV26DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_serasaprotestosdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_serasaprotestosdataauxdatetext_Internalname, AV19DDO_SerasaProtestosDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV19DDO_SerasaProtestosDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_serasaprotestosdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaProtestosWW.htm");
            /* User Defined Control */
            ucTfserasaprotestosdata_rangepicker.SetProperty("Start Date", AV17DDO_SerasaProtestosDataAuxDate);
            ucTfserasaprotestosdata_rangepicker.SetProperty("End Date", AV18DDO_SerasaProtestosDataAuxDateTo);
            ucTfserasaprotestosdata_rangepicker.Render(context, "wwp.daterangepicker", Tfserasaprotestosdata_rangepicker_Internalname, sPrefix+"TFSERASAPROTESTOSDATA_RANGEPICKERContainer");
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

      protected void START852( )
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
            Form.Meta.addItem("description", " Serasa Protestos", 0) ;
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
               STRUP850( ) ;
            }
         }
      }

      protected void WS852( )
      {
         START852( ) ;
         EVT852( ) ;
      }

      protected void EVT852( )
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
                                 STRUP850( ) ;
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
                                 STRUP850( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E11852 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP850( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP850( ) ;
                              }
                              AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
                              AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
                              AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
                              AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
                              AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
                              AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
                              AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
                              AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
                              AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
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
                                 STRUP850( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A711SerasaProtestosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaProtestosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n662SerasaId = false;
                              A712SerasaProtestosData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSerasaProtestosData_Internalname), 0));
                              n712SerasaProtestosData = false;
                              A713SerasaProtestosValor = context.localUtil.CToN( cgiGet( edtSerasaProtestosValor_Internalname), ",", ".");
                              n713SerasaProtestosValor = false;
                              A714SerasaProtestosCartorio = cgiGet( edtSerasaProtestosCartorio_Internalname);
                              n714SerasaProtestosCartorio = false;
                              A715SerasaProtestosCidade = cgiGet( edtSerasaProtestosCidade_Internalname);
                              n715SerasaProtestosCidade = false;
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
                                          GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12852 ();
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
                                          GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13852 ();
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
                                          GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E14852 ();
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
                                       STRUP850( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
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

      protected void WE852( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm852( ) ;
            }
         }
      }

      protected void PA852( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaprotestosww")), "serasaprotestosww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaprotestosww")))) ;
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
               GX_FocusControl = edtavDdo_serasaprotestosdataauxdatetext_Internalname;
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
                                       int AV27SerasaId ,
                                       DateTime AV15TFSerasaProtestosData ,
                                       DateTime AV16TFSerasaProtestosData_To ,
                                       decimal AV20TFSerasaProtestosValor ,
                                       decimal AV21TFSerasaProtestosValor_To ,
                                       string AV22TFSerasaProtestosCartorio ,
                                       string AV23TFSerasaProtestosCartorio_Sel ,
                                       string AV24TFSerasaProtestosCidade ,
                                       string AV25TFSerasaProtestosCidade_Sel ,
                                       string AV37Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF852( ) ;
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
         RF852( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV37Pgmname = "SerasaProtestosWW";
      }

      protected void RF852( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13852 ();
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
                                                 AV29Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                                 AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                                 AV31Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                                 AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                                 AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                                 AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                                 AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                                 AV35Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                                 A712SerasaProtestosData ,
                                                 A713SerasaProtestosValor ,
                                                 A714SerasaProtestosCartorio ,
                                                 A715SerasaProtestosCidade ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A662SerasaId ,
                                                 AV28Serasaprotestoswwds_1_serasaid } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = StringUtil.Concat( StringUtil.RTrim( AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio), "%", "");
            lV35Serasaprotestoswwds_8_tfserasaprotestoscidade = StringUtil.Concat( StringUtil.RTrim( AV35Serasaprotestoswwds_8_tfserasaprotestoscidade), "%", "");
            /* Using cursor H00852 */
            pr_default.execute(0, new Object[] {AV28Serasaprotestoswwds_1_serasaid, AV29Serasaprotestoswwds_2_tfserasaprotestosdata, AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to, AV31Serasaprotestoswwds_4_tfserasaprotestosvalor, AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to, lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio, AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, lV35Serasaprotestoswwds_8_tfserasaprotestoscidade, AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A715SerasaProtestosCidade = H00852_A715SerasaProtestosCidade[0];
               n715SerasaProtestosCidade = H00852_n715SerasaProtestosCidade[0];
               A714SerasaProtestosCartorio = H00852_A714SerasaProtestosCartorio[0];
               n714SerasaProtestosCartorio = H00852_n714SerasaProtestosCartorio[0];
               A713SerasaProtestosValor = H00852_A713SerasaProtestosValor[0];
               n713SerasaProtestosValor = H00852_n713SerasaProtestosValor[0];
               A712SerasaProtestosData = H00852_A712SerasaProtestosData[0];
               n712SerasaProtestosData = H00852_n712SerasaProtestosData[0];
               A662SerasaId = H00852_A662SerasaId[0];
               n662SerasaId = H00852_n662SerasaId[0];
               A711SerasaProtestosId = H00852_A711SerasaProtestosId[0];
               /* Execute user event: Grid.Load */
               E14852 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB850( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes852( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV37Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37Pgmname, "")), context));
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
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV29Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                              AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                              AV31Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                              AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                              AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                              AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                              AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                              AV35Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                              A712SerasaProtestosData ,
                                              A713SerasaProtestosValor ,
                                              A714SerasaProtestosCartorio ,
                                              A715SerasaProtestosCidade ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A662SerasaId ,
                                              AV28Serasaprotestoswwds_1_serasaid } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = StringUtil.Concat( StringUtil.RTrim( AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio), "%", "");
         lV35Serasaprotestoswwds_8_tfserasaprotestoscidade = StringUtil.Concat( StringUtil.RTrim( AV35Serasaprotestoswwds_8_tfserasaprotestoscidade), "%", "");
         /* Using cursor H00853 */
         pr_default.execute(1, new Object[] {AV28Serasaprotestoswwds_1_serasaid, AV29Serasaprotestoswwds_2_tfserasaprotestosdata, AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to, AV31Serasaprotestoswwds_4_tfserasaprotestosvalor, AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to, lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio, AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, lV35Serasaprotestoswwds_8_tfserasaprotestoscidade, AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel});
         GRID_nRecordCount = H00853_AGRID_nRecordCount[0];
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
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV27SerasaId, AV15TFSerasaProtestosData, AV16TFSerasaProtestosData_To, AV20TFSerasaProtestosValor, AV21TFSerasaProtestosValor_To, AV22TFSerasaProtestosCartorio, AV23TFSerasaProtestosCartorio_Sel, AV24TFSerasaProtestosCidade, AV25TFSerasaProtestosCidade_Sel, AV37Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV37Pgmname = "SerasaProtestosWW";
         edtSerasaProtestosId_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaProtestosData_Enabled = 0;
         edtSerasaProtestosValor_Enabled = 0;
         edtSerasaProtestosCartorio_Enabled = 0;
         edtSerasaProtestosCidade_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP850( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12852 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV26DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            AV17DDO_SerasaProtestosDataAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASAPROTESTOSDATAAUXDATE"), 0);
            AV18DDO_SerasaProtestosDataAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASAPROTESTOSDATAAUXDATETO"), 0);
            wcpOAV27SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
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
            AV19DDO_SerasaProtestosDataAuxDateText = cgiGet( edtavDdo_serasaprotestosdataauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV19DDO_SerasaProtestosDataAuxDateText", AV19DDO_SerasaProtestosDataAuxDateText);
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
         E12852 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12852( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFSERASAPROTESTOSDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_serasaprotestosdataauxdatetext_Internalname});
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV26DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV26DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13852( )
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
         AV28Serasaprotestoswwds_1_serasaid = AV27SerasaId;
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = AV15TFSerasaProtestosData;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = AV16TFSerasaProtestosData_To;
         AV31Serasaprotestoswwds_4_tfserasaprotestosvalor = AV20TFSerasaProtestosValor;
         AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to = AV21TFSerasaProtestosValor_To;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = AV22TFSerasaProtestosCartorio;
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = AV23TFSerasaProtestosCartorio_Sel;
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = AV24TFSerasaProtestosCidade;
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = AV25TFSerasaProtestosCidade_Sel;
      }

      protected void E11852( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaProtestosData") == 0 )
            {
               AV15TFSerasaProtestosData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV15TFSerasaProtestosData", context.localUtil.Format(AV15TFSerasaProtestosData, "99/99/99"));
               AV16TFSerasaProtestosData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV16TFSerasaProtestosData_To", context.localUtil.Format(AV16TFSerasaProtestosData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaProtestosValor") == 0 )
            {
               AV20TFSerasaProtestosValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV20TFSerasaProtestosValor", StringUtil.LTrimStr( AV20TFSerasaProtestosValor, 18, 2));
               AV21TFSerasaProtestosValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV21TFSerasaProtestosValor_To", StringUtil.LTrimStr( AV21TFSerasaProtestosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaProtestosCartorio") == 0 )
            {
               AV22TFSerasaProtestosCartorio = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV22TFSerasaProtestosCartorio", AV22TFSerasaProtestosCartorio);
               AV23TFSerasaProtestosCartorio_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV23TFSerasaProtestosCartorio_Sel", AV23TFSerasaProtestosCartorio_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaProtestosCidade") == 0 )
            {
               AV24TFSerasaProtestosCidade = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV24TFSerasaProtestosCidade", AV24TFSerasaProtestosCidade);
               AV25TFSerasaProtestosCidade_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV25TFSerasaProtestosCidade_Sel", AV25TFSerasaProtestosCidade_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E14852( )
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
         GXEncryptionTmp = "serasaprotestos"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A711SerasaProtestosId,9,0));
         edtSerasaProtestosData_Link = formatLink("serasaprotestos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         if ( StringUtil.StrCmp(AV14Session.Get(AV37Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV37Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV37Pgmname+"GridState"), null, "", "");
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
         AV38GXV1 = 1;
         while ( AV38GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV38GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSDATA") == 0 )
            {
               AV15TFSerasaProtestosData = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV15TFSerasaProtestosData", context.localUtil.Format(AV15TFSerasaProtestosData, "99/99/99"));
               AV16TFSerasaProtestosData_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV16TFSerasaProtestosData_To", context.localUtil.Format(AV16TFSerasaProtestosData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSVALOR") == 0 )
            {
               AV20TFSerasaProtestosValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV20TFSerasaProtestosValor", StringUtil.LTrimStr( AV20TFSerasaProtestosValor, 18, 2));
               AV21TFSerasaProtestosValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV21TFSerasaProtestosValor_To", StringUtil.LTrimStr( AV21TFSerasaProtestosValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCARTORIO") == 0 )
            {
               AV22TFSerasaProtestosCartorio = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFSerasaProtestosCartorio", AV22TFSerasaProtestosCartorio);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCARTORIO_SEL") == 0 )
            {
               AV23TFSerasaProtestosCartorio_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFSerasaProtestosCartorio_Sel", AV23TFSerasaProtestosCartorio_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCIDADE") == 0 )
            {
               AV24TFSerasaProtestosCidade = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFSerasaProtestosCidade", AV24TFSerasaProtestosCidade);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAPROTESTOSCIDADE_SEL") == 0 )
            {
               AV25TFSerasaProtestosCidade_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFSerasaProtestosCidade_Sel", AV25TFSerasaProtestosCidade_Sel);
            }
            AV38GXV1 = (int)(AV38GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSerasaProtestosCartorio_Sel)),  AV23TFSerasaProtestosCartorio_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaProtestosCidade_Sel)),  AV25TFSerasaProtestosCidade_Sel, out  GXt_char3) ;
         Ddo_grid_Selectedvalue_set = "||"+GXt_char2+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSerasaProtestosCartorio)),  AV22TFSerasaProtestosCartorio, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaProtestosCidade)),  AV24TFSerasaProtestosCidade, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV15TFSerasaProtestosData) ? "" : context.localUtil.DToC( AV15TFSerasaProtestosData, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV20TFSerasaProtestosValor) ? "" : StringUtil.Str( AV20TFSerasaProtestosValor, 18, 2))+"|"+GXt_char3+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV16TFSerasaProtestosData_To) ? "" : context.localUtil.DToC( AV16TFSerasaProtestosData_To, 4, "/"))+"|"+((Convert.ToDecimal(0)==AV21TFSerasaProtestosValor_To) ? "" : StringUtil.Str( AV21TFSerasaProtestosValor_To, 18, 2))+"||";
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
         AV10GridState.FromXml(AV14Session.Get(AV37Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAPROTESTOSDATA",  "",  !((DateTime.MinValue==AV15TFSerasaProtestosData)&&(DateTime.MinValue==AV16TFSerasaProtestosData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV15TFSerasaProtestosData, 4, "/")),  ((DateTime.MinValue==AV15TFSerasaProtestosData) ? "" : StringUtil.Trim( context.localUtil.Format( AV15TFSerasaProtestosData, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV16TFSerasaProtestosData_To, 4, "/")),  ((DateTime.MinValue==AV16TFSerasaProtestosData_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV16TFSerasaProtestosData_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAPROTESTOSVALOR",  "",  !((Convert.ToDecimal(0)==AV20TFSerasaProtestosValor)&&(Convert.ToDecimal(0)==AV21TFSerasaProtestosValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV20TFSerasaProtestosValor, 18, 2)),  ((Convert.ToDecimal(0)==AV20TFSerasaProtestosValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV20TFSerasaProtestosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV21TFSerasaProtestosValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV21TFSerasaProtestosValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV21TFSerasaProtestosValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAPROTESTOSCARTORIO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSerasaProtestosCartorio)),  0,  AV22TFSerasaProtestosCartorio,  AV22TFSerasaProtestosCartorio,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSerasaProtestosCartorio_Sel)),  AV23TFSerasaProtestosCartorio_Sel,  AV23TFSerasaProtestosCartorio_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAPROTESTOSCIDADE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaProtestosCidade)),  0,  AV24TFSerasaProtestosCidade,  AV24TFSerasaProtestosCidade,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaProtestosCidade_Sel)),  AV25TFSerasaProtestosCidade_Sel,  AV25TFSerasaProtestosCidade_Sel) ;
         if ( ! (0==AV27SerasaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SERASAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV27SerasaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV37Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV37Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "SerasaProtestos";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SerasaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV27SerasaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27SerasaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV27SerasaId", StringUtil.LTrimStr( (decimal)(AV27SerasaId), 9, 0));
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
         PA852( ) ;
         WS852( ) ;
         WE852( ) ;
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
         sCtrlAV27SerasaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA852( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "serasaprotestosww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA852( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV27SerasaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV27SerasaId", StringUtil.LTrimStr( (decimal)(AV27SerasaId), 9, 0));
         }
         wcpOAV27SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV27SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV27SerasaId != wcpOAV27SerasaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV27SerasaId = AV27SerasaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV27SerasaId = cgiGet( sPrefix+"AV27SerasaId_CTRL");
         if ( StringUtil.Len( sCtrlAV27SerasaId) > 0 )
         {
            AV27SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV27SerasaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV27SerasaId", StringUtil.LTrimStr( (decimal)(AV27SerasaId), 9, 0));
         }
         else
         {
            AV27SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV27SerasaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA852( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS852( ) ;
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
         WS852( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV27SerasaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27SerasaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV27SerasaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV27SerasaId_CTRL", StringUtil.RTrim( sCtrlAV27SerasaId));
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
         WE852( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019201884", true, true);
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
         context.AddJavascriptSource("serasaprotestosww.js", "?202561019201885", false, true);
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
         edtSerasaProtestosId_Internalname = sPrefix+"SERASAPROTESTOSID_"+sGXsfl_12_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_idx;
         edtSerasaProtestosData_Internalname = sPrefix+"SERASAPROTESTOSDATA_"+sGXsfl_12_idx;
         edtSerasaProtestosValor_Internalname = sPrefix+"SERASAPROTESTOSVALOR_"+sGXsfl_12_idx;
         edtSerasaProtestosCartorio_Internalname = sPrefix+"SERASAPROTESTOSCARTORIO_"+sGXsfl_12_idx;
         edtSerasaProtestosCidade_Internalname = sPrefix+"SERASAPROTESTOSCIDADE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtSerasaProtestosId_Internalname = sPrefix+"SERASAPROTESTOSID_"+sGXsfl_12_fel_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_fel_idx;
         edtSerasaProtestosData_Internalname = sPrefix+"SERASAPROTESTOSDATA_"+sGXsfl_12_fel_idx;
         edtSerasaProtestosValor_Internalname = sPrefix+"SERASAPROTESTOSVALOR_"+sGXsfl_12_fel_idx;
         edtSerasaProtestosCartorio_Internalname = sPrefix+"SERASAPROTESTOSCARTORIO_"+sGXsfl_12_fel_idx;
         edtSerasaProtestosCidade_Internalname = sPrefix+"SERASAPROTESTOSCIDADE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB850( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaProtestosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A711SerasaProtestosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A711SerasaProtestosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaProtestosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaProtestosData_Internalname,context.localUtil.Format(A712SerasaProtestosData, "99/99/99"),context.localUtil.Format( A712SerasaProtestosData, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSerasaProtestosData_Link,(string)"",(string)"",(string)"",(string)edtSerasaProtestosData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaProtestosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A713SerasaProtestosValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A713SerasaProtestosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaProtestosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaProtestosCartorio_Internalname,(string)A714SerasaProtestosCartorio,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaProtestosCartorio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaProtestosCidade_Internalname,(string)A715SerasaProtestosCidade,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaProtestosCidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes852( ) ;
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
            context.SendWebValue( "Protestos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data da ocorrência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cartório") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cidade") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A711SerasaProtestosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A712SerasaProtestosData, "99/99/99")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSerasaProtestosData_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A713SerasaProtestosValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A714SerasaProtestosCartorio));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A715SerasaProtestosCidade));
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
         edtSerasaProtestosId_Internalname = sPrefix+"SERASAPROTESTOSID";
         edtSerasaId_Internalname = sPrefix+"SERASAID";
         edtSerasaProtestosData_Internalname = sPrefix+"SERASAPROTESTOSDATA";
         edtSerasaProtestosValor_Internalname = sPrefix+"SERASAPROTESTOSVALOR";
         edtSerasaProtestosCartorio_Internalname = sPrefix+"SERASAPROTESTOSCARTORIO";
         edtSerasaProtestosCidade_Internalname = sPrefix+"SERASAPROTESTOSCIDADE";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_serasaprotestosdataauxdatetext_Internalname = sPrefix+"vDDO_SERASAPROTESTOSDATAAUXDATETEXT";
         Tfserasaprotestosdata_rangepicker_Internalname = sPrefix+"TFSERASAPROTESTOSDATA_RANGEPICKER";
         divDdo_serasaprotestosdataauxdates_Internalname = sPrefix+"DDO_SERASAPROTESTOSDATAAUXDATES";
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
         edtSerasaProtestosCidade_Jsonclick = "";
         edtSerasaProtestosCartorio_Jsonclick = "";
         edtSerasaProtestosValor_Jsonclick = "";
         edtSerasaProtestosData_Jsonclick = "";
         edtSerasaProtestosData_Link = "";
         edtSerasaId_Jsonclick = "";
         edtSerasaProtestosId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtSerasaProtestosCidade_Enabled = 0;
         edtSerasaProtestosCartorio_Enabled = 0;
         edtSerasaProtestosValor_Enabled = 0;
         edtSerasaProtestosData_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaProtestosId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_serasaprotestosdataauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|18.2||";
         Ddo_grid_Datalistproc = "SerasaProtestosWWGetFilterData";
         Ddo_grid_Datalisttype = "||Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "||T|T";
         Ddo_grid_Filterisrange = "P|T||";
         Ddo_grid_Filtertype = "Date|Numeric|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4";
         Ddo_grid_Columnids = "2:SerasaProtestosData|3:SerasaProtestosValor|4:SerasaProtestosCartorio|5:SerasaProtestosCidade";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11852","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14852","iparms":[{"av":"A711SerasaProtestosId","fld":"SERASAPROTESTOSID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSerasaProtestosData_Link","ctrl":"SERASAPROTESTOSDATA","prop":"Link"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV27SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaProtestosData","fld":"vTFSERASAPROTESTOSDATA","type":"date"},{"av":"AV16TFSerasaProtestosData_To","fld":"vTFSERASAPROTESTOSDATA_TO","type":"date"},{"av":"AV20TFSerasaProtestosValor","fld":"vTFSERASAPROTESTOSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV21TFSerasaProtestosValor_To","fld":"vTFSERASAPROTESTOSVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV22TFSerasaProtestosCartorio","fld":"vTFSERASAPROTESTOSCARTORIO","type":"svchar"},{"av":"AV23TFSerasaProtestosCartorio_Sel","fld":"vTFSERASAPROTESTOSCARTORIO_SEL","type":"svchar"},{"av":"AV24TFSerasaProtestosCidade","fld":"vTFSERASAPROTESTOSCIDADE","type":"svchar"},{"av":"AV25TFSerasaProtestosCidade_Sel","fld":"vTFSERASAPROTESTOSCIDADE_SEL","type":"svchar"},{"av":"AV37Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Serasaprotestoscidade","iparms":[]}""");
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
         AV15TFSerasaProtestosData = DateTime.MinValue;
         AV16TFSerasaProtestosData_To = DateTime.MinValue;
         AV22TFSerasaProtestosCartorio = "";
         AV23TFSerasaProtestosCartorio_Sel = "";
         AV24TFSerasaProtestosCidade = "";
         AV25TFSerasaProtestosCidade_Sel = "";
         AV37Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV26DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17DDO_SerasaProtestosDataAuxDate = DateTime.MinValue;
         AV18DDO_SerasaProtestosDataAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
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
         AV19DDO_SerasaProtestosDataAuxDateText = "";
         ucTfserasaprotestosdata_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV29Serasaprotestoswwds_2_tfserasaprotestosdata = DateTime.MinValue;
         AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to = DateTime.MinValue;
         AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = "";
         AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel = "";
         AV35Serasaprotestoswwds_8_tfserasaprotestoscidade = "";
         AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel = "";
         A712SerasaProtestosData = DateTime.MinValue;
         A714SerasaProtestosCartorio = "";
         A715SerasaProtestosCidade = "";
         GXDecQS = "";
         lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio = "";
         lV35Serasaprotestoswwds_8_tfserasaprotestoscidade = "";
         H00852_A715SerasaProtestosCidade = new string[] {""} ;
         H00852_n715SerasaProtestosCidade = new bool[] {false} ;
         H00852_A714SerasaProtestosCartorio = new string[] {""} ;
         H00852_n714SerasaProtestosCartorio = new bool[] {false} ;
         H00852_A713SerasaProtestosValor = new decimal[1] ;
         H00852_n713SerasaProtestosValor = new bool[] {false} ;
         H00852_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         H00852_n712SerasaProtestosData = new bool[] {false} ;
         H00852_A662SerasaId = new int[1] ;
         H00852_n662SerasaId = new bool[] {false} ;
         H00852_A711SerasaProtestosId = new int[1] ;
         H00853_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV27SerasaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaprotestosww__default(),
            new Object[][] {
                new Object[] {
               H00852_A715SerasaProtestosCidade, H00852_n715SerasaProtestosCidade, H00852_A714SerasaProtestosCartorio, H00852_n714SerasaProtestosCartorio, H00852_A713SerasaProtestosValor, H00852_n713SerasaProtestosValor, H00852_A712SerasaProtestosData, H00852_n712SerasaProtestosData, H00852_A662SerasaId, H00852_n662SerasaId,
               H00852_A711SerasaProtestosId
               }
               , new Object[] {
               H00853_AGRID_nRecordCount
               }
            }
         );
         AV37Pgmname = "SerasaProtestosWW";
         /* GeneXus formulas. */
         AV37Pgmname = "SerasaProtestosWW";
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
      private int AV27SerasaId ;
      private int wcpOAV27SerasaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV28Serasaprotestoswwds_1_serasaid ;
      private int A711SerasaProtestosId ;
      private int A662SerasaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSerasaProtestosId_Enabled ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaProtestosData_Enabled ;
      private int edtSerasaProtestosValor_Enabled ;
      private int edtSerasaProtestosCartorio_Enabled ;
      private int edtSerasaProtestosCidade_Enabled ;
      private int AV38GXV1 ;
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
      private decimal AV20TFSerasaProtestosValor ;
      private decimal AV21TFSerasaProtestosValor_To ;
      private decimal AV31Serasaprotestoswwds_4_tfserasaprotestosvalor ;
      private decimal AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to ;
      private decimal A713SerasaProtestosValor ;
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
      private string AV37Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string divDdo_serasaprotestosdataauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_serasaprotestosdataauxdatetext_Internalname ;
      private string edtavDdo_serasaprotestosdataauxdatetext_Jsonclick ;
      private string Tfserasaprotestosdata_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSerasaProtestosId_Internalname ;
      private string edtSerasaId_Internalname ;
      private string edtSerasaProtestosData_Internalname ;
      private string edtSerasaProtestosValor_Internalname ;
      private string edtSerasaProtestosCartorio_Internalname ;
      private string edtSerasaProtestosCidade_Internalname ;
      private string GXDecQS ;
      private string edtSerasaProtestosData_Link ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV27SerasaId ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSerasaProtestosId_Jsonclick ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaProtestosData_Jsonclick ;
      private string edtSerasaProtestosValor_Jsonclick ;
      private string edtSerasaProtestosCartorio_Jsonclick ;
      private string edtSerasaProtestosCidade_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV15TFSerasaProtestosData ;
      private DateTime AV16TFSerasaProtestosData_To ;
      private DateTime AV17DDO_SerasaProtestosDataAuxDate ;
      private DateTime AV18DDO_SerasaProtestosDataAuxDateTo ;
      private DateTime AV29Serasaprotestoswwds_2_tfserasaprotestosdata ;
      private DateTime AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to ;
      private DateTime A712SerasaProtestosData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n662SerasaId ;
      private bool n712SerasaProtestosData ;
      private bool n713SerasaProtestosValor ;
      private bool n714SerasaProtestosCartorio ;
      private bool n715SerasaProtestosCidade ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV22TFSerasaProtestosCartorio ;
      private string AV23TFSerasaProtestosCartorio_Sel ;
      private string AV24TFSerasaProtestosCidade ;
      private string AV25TFSerasaProtestosCidade_Sel ;
      private string AV19DDO_SerasaProtestosDataAuxDateText ;
      private string AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ;
      private string AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ;
      private string AV35Serasaprotestoswwds_8_tfserasaprotestoscidade ;
      private string AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ;
      private string A714SerasaProtestosCartorio ;
      private string A715SerasaProtestosCidade ;
      private string lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ;
      private string lV35Serasaprotestoswwds_8_tfserasaprotestoscidade ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfserasaprotestosdata_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV26DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00852_A715SerasaProtestosCidade ;
      private bool[] H00852_n715SerasaProtestosCidade ;
      private string[] H00852_A714SerasaProtestosCartorio ;
      private bool[] H00852_n714SerasaProtestosCartorio ;
      private decimal[] H00852_A713SerasaProtestosValor ;
      private bool[] H00852_n713SerasaProtestosValor ;
      private DateTime[] H00852_A712SerasaProtestosData ;
      private bool[] H00852_n712SerasaProtestosData ;
      private int[] H00852_A662SerasaId ;
      private bool[] H00852_n662SerasaId ;
      private int[] H00852_A711SerasaProtestosId ;
      private long[] H00853_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaprotestosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00852( IGxContext context ,
                                             DateTime AV29Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                             DateTime AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                             decimal AV31Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                             decimal AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                             string AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                             string AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                             string AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                             string AV35Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                             DateTime A712SerasaProtestosData ,
                                             decimal A713SerasaProtestosValor ,
                                             string A714SerasaProtestosCartorio ,
                                             string A715SerasaProtestosCidade ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV28Serasaprotestoswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SerasaProtestosCidade, SerasaProtestosCartorio, SerasaProtestosValor, SerasaProtestosData, SerasaId, SerasaProtestosId";
         sFromString = " FROM SerasaProtestos";
         sOrderString = "";
         AddWhere(sWhereString, "(SerasaId = :AV28Serasaprotestoswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV29Serasaprotestoswwds_2_tfserasaprotestosdata) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData >= :AV29Serasaprotestoswwds_2_tfserasaprotestosdata)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData <= :AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV31Serasaprotestoswwds_4_tfserasaprotestosvalor) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor >= :AV31Serasaprotestoswwds_4_tfserasaprotestosvalor)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor <= :AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio like :lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ! ( StringUtil.StrCmp(AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio = ( :AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCartorio))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Serasaprotestoswwds_8_tfserasaprotestoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade like :lV35Serasaprotestoswwds_8_tfserasaprotestoscidade)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ! ( StringUtil.StrCmp(AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade = ( :AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCidade))=0))");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaProtestosData, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaProtestosData DESC, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaProtestosValor, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaProtestosValor DESC, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaProtestosCartorio, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaProtestosCartorio DESC, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaProtestosCidade, SerasaProtestosId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaProtestosCidade DESC, SerasaProtestosId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY SerasaProtestosId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00853( IGxContext context ,
                                             DateTime AV29Serasaprotestoswwds_2_tfserasaprotestosdata ,
                                             DateTime AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to ,
                                             decimal AV31Serasaprotestoswwds_4_tfserasaprotestosvalor ,
                                             decimal AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to ,
                                             string AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel ,
                                             string AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio ,
                                             string AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel ,
                                             string AV35Serasaprotestoswwds_8_tfserasaprotestoscidade ,
                                             DateTime A712SerasaProtestosData ,
                                             decimal A713SerasaProtestosValor ,
                                             string A714SerasaProtestosCartorio ,
                                             string A715SerasaProtestosCidade ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV28Serasaprotestoswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[9];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM SerasaProtestos";
         AddWhere(sWhereString, "(SerasaId = :AV28Serasaprotestoswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV29Serasaprotestoswwds_2_tfserasaprotestosdata) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData >= :AV29Serasaprotestoswwds_2_tfserasaprotestosdata)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosData <= :AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV31Serasaprotestoswwds_4_tfserasaprotestosvalor) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor >= :AV31Serasaprotestoswwds_4_tfserasaprotestosvalor)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaProtestosValor <= :AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Serasaprotestoswwds_6_tfserasaprotestoscartorio)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio like :lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel)) && ! ( StringUtil.StrCmp(AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio = ( :AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCartorio IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCartorio))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35Serasaprotestoswwds_8_tfserasaprotestoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade like :lV35Serasaprotestoswwds_8_tfserasaprotestoscidade)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel)) && ! ( StringUtil.StrCmp(AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade = ( :AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaProtestosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaProtestosCidade))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00852(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
               case 1 :
                     return conditional_H00853(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
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
          Object[] prmH00852;
          prmH00852 = new Object[] {
          new ParDef("AV28Serasaprotestoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV29Serasaprotestoswwds_2_tfserasaprotestosdata",GXType.Date,8,0) ,
          new ParDef("AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to",GXType.Date,8,0) ,
          new ParDef("AV31Serasaprotestoswwds_4_tfserasaprotestosvalor",GXType.Number,18,2) ,
          new ParDef("AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to",GXType.Number,18,2) ,
          new ParDef("lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio",GXType.VarChar,40,0) ,
          new ParDef("AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel",GXType.VarChar,40,0) ,
          new ParDef("lV35Serasaprotestoswwds_8_tfserasaprotestoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00853;
          prmH00853 = new Object[] {
          new ParDef("AV28Serasaprotestoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV29Serasaprotestoswwds_2_tfserasaprotestosdata",GXType.Date,8,0) ,
          new ParDef("AV30Serasaprotestoswwds_3_tfserasaprotestosdata_to",GXType.Date,8,0) ,
          new ParDef("AV31Serasaprotestoswwds_4_tfserasaprotestosvalor",GXType.Number,18,2) ,
          new ParDef("AV32Serasaprotestoswwds_5_tfserasaprotestosvalor_to",GXType.Number,18,2) ,
          new ParDef("lV33Serasaprotestoswwds_6_tfserasaprotestoscartorio",GXType.VarChar,40,0) ,
          new ParDef("AV34Serasaprotestoswwds_7_tfserasaprotestoscartorio_sel",GXType.VarChar,40,0) ,
          new ParDef("lV35Serasaprotestoswwds_8_tfserasaprotestoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV36Serasaprotestoswwds_9_tfserasaprotestoscidade_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00852", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00852,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00853", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00853,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
