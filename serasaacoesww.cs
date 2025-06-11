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
   public class serasaacoesww : GXWebComponent
   {
      public serasaacoesww( )
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

      public serasaacoesww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SerasaId )
      {
         this.AV39SerasaId = aP0_SerasaId;
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
                  AV39SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV39SerasaId", StringUtil.LTrimStr( (decimal)(AV39SerasaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV39SerasaId});
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
         AV39SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
         AV15TFSerasaAcoesData = context.localUtil.ParseDateParm( GetPar( "TFSerasaAcoesData"));
         AV16TFSerasaAcoesData_To = context.localUtil.ParseDateParm( GetPar( "TFSerasaAcoesData_To"));
         AV20TFSerasaAcoesNatureza = GetPar( "TFSerasaAcoesNatureza");
         AV21TFSerasaAcoesNatureza_Sel = GetPar( "TFSerasaAcoesNatureza_Sel");
         AV22TFSerasaAcoesValor = NumberUtil.Val( GetPar( "TFSerasaAcoesValor"), ".");
         AV23TFSerasaAcoesValor_To = NumberUtil.Val( GetPar( "TFSerasaAcoesValor_To"), ".");
         AV24TFSerasaAcoesDistribuidor = GetPar( "TFSerasaAcoesDistribuidor");
         AV25TFSerasaAcoesDistribuidor_Sel = GetPar( "TFSerasaAcoesDistribuidor_Sel");
         AV26TFSerasaAcoesVara = GetPar( "TFSerasaAcoesVara");
         AV27TFSerasaAcoesVara_Sel = GetPar( "TFSerasaAcoesVara_Sel");
         AV28TFSerasaAcoesCidade = GetPar( "TFSerasaAcoesCidade");
         AV29TFSerasaAcoesCidade_Sel = GetPar( "TFSerasaAcoesCidade_Sel");
         AV30TFSerasaAcoesUF = GetPar( "TFSerasaAcoesUF");
         AV31TFSerasaAcoesUF_Sel = GetPar( "TFSerasaAcoesUF_Sel");
         AV32TFSerasaAcoesPrincipal = GetPar( "TFSerasaAcoesPrincipal");
         AV33TFSerasaAcoesPrincipal_Sel = GetPar( "TFSerasaAcoesPrincipal_Sel");
         AV34TFSerasaAcoesTipoMoeda = GetPar( "TFSerasaAcoesTipoMoeda");
         AV35TFSerasaAcoesTipoMoeda_Sel = GetPar( "TFSerasaAcoesTipoMoeda_Sel");
         AV36TFSerasaAcoesQtdOco = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSerasaAcoesQtdOco"), "."), 18, MidpointRounding.ToEven));
         AV37TFSerasaAcoesQtdOco_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFSerasaAcoesQtdOco_To"), "."), 18, MidpointRounding.ToEven));
         AV61Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
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
            PA872( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV61Pgmname = "SerasaAcoesWW";
               WS872( ) ;
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
            context.SendWebValue( " Serasa Acoes") ;
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
            GXEncryptionTmp = "serasaacoesww"+UrlEncode(StringUtil.LTrimStr(AV39SerasaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("serasaacoesww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV38DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASAACOESDATAAUXDATE", context.localUtil.DToC( AV17DDO_SerasaAcoesDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_SERASAACOESDATAAUXDATETO", context.localUtil.DToC( AV18DDO_SerasaAcoesDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV39SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV39SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESDATA", context.localUtil.DToC( AV15TFSerasaAcoesData, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESDATA_TO", context.localUtil.DToC( AV16TFSerasaAcoesData_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESNATUREZA", AV20TFSerasaAcoesNatureza);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESNATUREZA_SEL", AV21TFSerasaAcoesNatureza_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESVALOR", StringUtil.LTrim( StringUtil.NToC( AV22TFSerasaAcoesValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV23TFSerasaAcoesValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESDISTRIBUIDOR", AV24TFSerasaAcoesDistribuidor);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESDISTRIBUIDOR_SEL", AV25TFSerasaAcoesDistribuidor_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESVARA", AV26TFSerasaAcoesVara);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESVARA_SEL", AV27TFSerasaAcoesVara_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESCIDADE", AV28TFSerasaAcoesCidade);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESCIDADE_SEL", AV29TFSerasaAcoesCidade_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESUF", AV30TFSerasaAcoesUF);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESUF_SEL", AV31TFSerasaAcoesUF_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESPRINCIPAL", AV32TFSerasaAcoesPrincipal);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESPRINCIPAL_SEL", AV33TFSerasaAcoesPrincipal_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESTIPOMOEDA", AV34TFSerasaAcoesTipoMoeda);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESTIPOMOEDA_SEL", AV35TFSerasaAcoesTipoMoeda_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESQTDOCO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36TFSerasaAcoesQtdOco), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAACOESQTDOCO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37TFSerasaAcoesQtdOco_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseForm872( )
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
         return "SerasaAcoesWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Serasa Acoes" ;
      }

      protected void WB870( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "serasaacoesww");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV38DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_serasaacoesdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_12_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_serasaacoesdataauxdatetext_Internalname, AV19DDO_SerasaAcoesDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV19DDO_SerasaAcoesDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_serasaacoesdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_SerasaAcoesWW.htm");
            /* User Defined Control */
            ucTfserasaacoesdata_rangepicker.SetProperty("Start Date", AV17DDO_SerasaAcoesDataAuxDate);
            ucTfserasaacoesdata_rangepicker.SetProperty("End Date", AV18DDO_SerasaAcoesDataAuxDateTo);
            ucTfserasaacoesdata_rangepicker.Render(context, "wwp.daterangepicker", Tfserasaacoesdata_rangepicker_Internalname, sPrefix+"TFSERASAACOESDATA_RANGEPICKERContainer");
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

      protected void START872( )
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
            Form.Meta.addItem("description", " Serasa Acoes", 0) ;
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
               STRUP870( ) ;
            }
         }
      }

      protected void WS872( )
      {
         START872( ) ;
         EVT872( ) ;
      }

      protected void EVT872( )
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
                                 STRUP870( ) ;
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
                                 STRUP870( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E11872 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP870( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP870( ) ;
                              }
                              AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
                              AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
                              AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
                              AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
                              AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
                              AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
                              AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
                              AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
                              AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
                              AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
                              AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
                              AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
                              AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
                              AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
                              AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
                              AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
                              AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
                              AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
                              AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
                              AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
                              AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
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
                                 STRUP870( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A699SerasaAcoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaAcoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n662SerasaId = false;
                              A700SerasaAcoesData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSerasaAcoesData_Internalname), 0));
                              n700SerasaAcoesData = false;
                              A701SerasaAcoesNatureza = cgiGet( edtSerasaAcoesNatureza_Internalname);
                              n701SerasaAcoesNatureza = false;
                              A702SerasaAcoesValor = context.localUtil.CToN( cgiGet( edtSerasaAcoesValor_Internalname), ",", ".");
                              n702SerasaAcoesValor = false;
                              A703SerasaAcoesDistribuidor = cgiGet( edtSerasaAcoesDistribuidor_Internalname);
                              n703SerasaAcoesDistribuidor = false;
                              A704SerasaAcoesVara = cgiGet( edtSerasaAcoesVara_Internalname);
                              n704SerasaAcoesVara = false;
                              A705SerasaAcoesCidade = cgiGet( edtSerasaAcoesCidade_Internalname);
                              n705SerasaAcoesCidade = false;
                              A706SerasaAcoesUF = cgiGet( edtSerasaAcoesUF_Internalname);
                              n706SerasaAcoesUF = false;
                              A707SerasaAcoesPrincipal = cgiGet( edtSerasaAcoesPrincipal_Internalname);
                              n707SerasaAcoesPrincipal = false;
                              A708SerasaAcoesTipoMoeda = cgiGet( edtSerasaAcoesTipoMoeda_Internalname);
                              n708SerasaAcoesTipoMoeda = false;
                              A709SerasaAcoesQtdOco = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaAcoesQtdOco_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n709SerasaAcoesQtdOco = false;
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
                                          GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12872 ();
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
                                          GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13872 ();
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
                                          GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E14872 ();
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
                                       STRUP870( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
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

      protected void WE872( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm872( ) ;
            }
         }
      }

      protected void PA872( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaacoesww")), "serasaacoesww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaacoesww")))) ;
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
               GX_FocusControl = edtavDdo_serasaacoesdataauxdatetext_Internalname;
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
                                       int AV39SerasaId ,
                                       DateTime AV15TFSerasaAcoesData ,
                                       DateTime AV16TFSerasaAcoesData_To ,
                                       string AV20TFSerasaAcoesNatureza ,
                                       string AV21TFSerasaAcoesNatureza_Sel ,
                                       decimal AV22TFSerasaAcoesValor ,
                                       decimal AV23TFSerasaAcoesValor_To ,
                                       string AV24TFSerasaAcoesDistribuidor ,
                                       string AV25TFSerasaAcoesDistribuidor_Sel ,
                                       string AV26TFSerasaAcoesVara ,
                                       string AV27TFSerasaAcoesVara_Sel ,
                                       string AV28TFSerasaAcoesCidade ,
                                       string AV29TFSerasaAcoesCidade_Sel ,
                                       string AV30TFSerasaAcoesUF ,
                                       string AV31TFSerasaAcoesUF_Sel ,
                                       string AV32TFSerasaAcoesPrincipal ,
                                       string AV33TFSerasaAcoesPrincipal_Sel ,
                                       string AV34TFSerasaAcoesTipoMoeda ,
                                       string AV35TFSerasaAcoesTipoMoeda_Sel ,
                                       short AV36TFSerasaAcoesQtdOco ,
                                       short AV37TFSerasaAcoesQtdOco_To ,
                                       string AV61Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF872( ) ;
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
         RF872( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV61Pgmname = "SerasaAcoesWW";
      }

      protected void RF872( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13872 ();
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
                                                 AV41Serasaacoeswwds_2_tfserasaacoesdata ,
                                                 AV42Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                                 AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                                 AV43Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                                 AV45Serasaacoeswwds_6_tfserasaacoesvalor ,
                                                 AV46Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                                 AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                                 AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                                 AV50Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                                 AV49Serasaacoeswwds_10_tfserasaacoesvara ,
                                                 AV52Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                                 AV51Serasaacoeswwds_12_tfserasaacoescidade ,
                                                 AV54Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                                 AV53Serasaacoeswwds_14_tfserasaacoesuf ,
                                                 AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                                 AV55Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                                 AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                                 AV57Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                                 AV59Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                                 AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                                 A700SerasaAcoesData ,
                                                 A701SerasaAcoesNatureza ,
                                                 A702SerasaAcoesValor ,
                                                 A703SerasaAcoesDistribuidor ,
                                                 A704SerasaAcoesVara ,
                                                 A705SerasaAcoesCidade ,
                                                 A706SerasaAcoesUF ,
                                                 A707SerasaAcoesPrincipal ,
                                                 A708SerasaAcoesTipoMoeda ,
                                                 A709SerasaAcoesQtdOco ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A662SerasaId ,
                                                 AV40Serasaacoeswwds_1_serasaid } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV43Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV43Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
            lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
            lV49Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV49Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
            lV51Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV51Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
            lV53Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV53Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
            lV55Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV55Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
            lV57Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV57Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
            /* Using cursor H00872 */
            pr_default.execute(0, new Object[] {AV40Serasaacoeswwds_1_serasaid, AV41Serasaacoeswwds_2_tfserasaacoesdata, AV42Serasaacoeswwds_3_tfserasaacoesdata_to, lV43Serasaacoeswwds_4_tfserasaacoesnatureza, AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV45Serasaacoeswwds_6_tfserasaacoesvalor, AV46Serasaacoeswwds_7_tfserasaacoesvalor_to, lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV49Serasaacoeswwds_10_tfserasaacoesvara, AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, lV51Serasaacoeswwds_12_tfserasaacoescidade, AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, lV53Serasaacoeswwds_14_tfserasaacoesuf, AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, lV55Serasaacoeswwds_16_tfserasaacoesprincipal, AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV57Serasaacoeswwds_18_tfserasaacoestipomoeda, AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV59Serasaacoeswwds_20_tfserasaacoesqtdoco, AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A709SerasaAcoesQtdOco = H00872_A709SerasaAcoesQtdOco[0];
               n709SerasaAcoesQtdOco = H00872_n709SerasaAcoesQtdOco[0];
               A708SerasaAcoesTipoMoeda = H00872_A708SerasaAcoesTipoMoeda[0];
               n708SerasaAcoesTipoMoeda = H00872_n708SerasaAcoesTipoMoeda[0];
               A707SerasaAcoesPrincipal = H00872_A707SerasaAcoesPrincipal[0];
               n707SerasaAcoesPrincipal = H00872_n707SerasaAcoesPrincipal[0];
               A706SerasaAcoesUF = H00872_A706SerasaAcoesUF[0];
               n706SerasaAcoesUF = H00872_n706SerasaAcoesUF[0];
               A705SerasaAcoesCidade = H00872_A705SerasaAcoesCidade[0];
               n705SerasaAcoesCidade = H00872_n705SerasaAcoesCidade[0];
               A704SerasaAcoesVara = H00872_A704SerasaAcoesVara[0];
               n704SerasaAcoesVara = H00872_n704SerasaAcoesVara[0];
               A703SerasaAcoesDistribuidor = H00872_A703SerasaAcoesDistribuidor[0];
               n703SerasaAcoesDistribuidor = H00872_n703SerasaAcoesDistribuidor[0];
               A702SerasaAcoesValor = H00872_A702SerasaAcoesValor[0];
               n702SerasaAcoesValor = H00872_n702SerasaAcoesValor[0];
               A701SerasaAcoesNatureza = H00872_A701SerasaAcoesNatureza[0];
               n701SerasaAcoesNatureza = H00872_n701SerasaAcoesNatureza[0];
               A700SerasaAcoesData = H00872_A700SerasaAcoesData[0];
               n700SerasaAcoesData = H00872_n700SerasaAcoesData[0];
               A662SerasaId = H00872_A662SerasaId[0];
               n662SerasaId = H00872_n662SerasaId[0];
               A699SerasaAcoesId = H00872_A699SerasaAcoesId[0];
               /* Execute user event: Grid.Load */
               E14872 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB870( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes872( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV61Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV61Pgmname, "")), context));
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
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV41Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV42Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV43Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV45Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV46Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV50Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV49Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV52Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV51Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV54Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV53Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV55Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV57Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV59Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A662SerasaId ,
                                              AV40Serasaacoeswwds_1_serasaid } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV43Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV43Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV49Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV49Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV51Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV51Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV53Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV53Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV55Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV55Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV57Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV57Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor H00873 */
         pr_default.execute(1, new Object[] {AV40Serasaacoeswwds_1_serasaid, AV41Serasaacoeswwds_2_tfserasaacoesdata, AV42Serasaacoeswwds_3_tfserasaacoesdata_to, lV43Serasaacoeswwds_4_tfserasaacoesnatureza, AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV45Serasaacoeswwds_6_tfserasaacoesvalor, AV46Serasaacoeswwds_7_tfserasaacoesvalor_to, lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV49Serasaacoeswwds_10_tfserasaacoesvara, AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, lV51Serasaacoeswwds_12_tfserasaacoescidade, AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, lV53Serasaacoeswwds_14_tfserasaacoesuf, AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, lV55Serasaacoeswwds_16_tfserasaacoesprincipal, AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV57Serasaacoeswwds_18_tfserasaacoestipomoeda, AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV59Serasaacoeswwds_20_tfserasaacoesqtdoco, AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         GRID_nRecordCount = H00873_AGRID_nRecordCount[0];
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
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV39SerasaId, AV15TFSerasaAcoesData, AV16TFSerasaAcoesData_To, AV20TFSerasaAcoesNatureza, AV21TFSerasaAcoesNatureza_Sel, AV22TFSerasaAcoesValor, AV23TFSerasaAcoesValor_To, AV24TFSerasaAcoesDistribuidor, AV25TFSerasaAcoesDistribuidor_Sel, AV26TFSerasaAcoesVara, AV27TFSerasaAcoesVara_Sel, AV28TFSerasaAcoesCidade, AV29TFSerasaAcoesCidade_Sel, AV30TFSerasaAcoesUF, AV31TFSerasaAcoesUF_Sel, AV32TFSerasaAcoesPrincipal, AV33TFSerasaAcoesPrincipal_Sel, AV34TFSerasaAcoesTipoMoeda, AV35TFSerasaAcoesTipoMoeda_Sel, AV36TFSerasaAcoesQtdOco, AV37TFSerasaAcoesQtdOco_To, AV61Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV61Pgmname = "SerasaAcoesWW";
         edtSerasaAcoesId_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaAcoesData_Enabled = 0;
         edtSerasaAcoesNatureza_Enabled = 0;
         edtSerasaAcoesValor_Enabled = 0;
         edtSerasaAcoesDistribuidor_Enabled = 0;
         edtSerasaAcoesVara_Enabled = 0;
         edtSerasaAcoesCidade_Enabled = 0;
         edtSerasaAcoesUF_Enabled = 0;
         edtSerasaAcoesPrincipal_Enabled = 0;
         edtSerasaAcoesTipoMoeda_Enabled = 0;
         edtSerasaAcoesQtdOco_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP870( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12872 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV38DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            AV17DDO_SerasaAcoesDataAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASAACOESDATAAUXDATE"), 0);
            AV18DDO_SerasaAcoesDataAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_SERASAACOESDATAAUXDATETO"), 0);
            wcpOAV39SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV39SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            AV19DDO_SerasaAcoesDataAuxDateText = cgiGet( edtavDdo_serasaacoesdataauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV19DDO_SerasaAcoesDataAuxDateText", AV19DDO_SerasaAcoesDataAuxDateText);
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
         E12872 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12872( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "TFSERASAACOESDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_serasaacoesdataauxdatetext_Internalname});
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV38DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV38DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13872( )
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
         AV40Serasaacoeswwds_1_serasaid = AV39SerasaId;
         AV41Serasaacoeswwds_2_tfserasaacoesdata = AV15TFSerasaAcoesData;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = AV16TFSerasaAcoesData_To;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = AV20TFSerasaAcoesNatureza;
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV21TFSerasaAcoesNatureza_Sel;
         AV45Serasaacoeswwds_6_tfserasaacoesvalor = AV22TFSerasaAcoesValor;
         AV46Serasaacoeswwds_7_tfserasaacoesvalor_to = AV23TFSerasaAcoesValor_To;
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV24TFSerasaAcoesDistribuidor;
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV25TFSerasaAcoesDistribuidor_Sel;
         AV49Serasaacoeswwds_10_tfserasaacoesvara = AV26TFSerasaAcoesVara;
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = AV27TFSerasaAcoesVara_Sel;
         AV51Serasaacoeswwds_12_tfserasaacoescidade = AV28TFSerasaAcoesCidade;
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = AV29TFSerasaAcoesCidade_Sel;
         AV53Serasaacoeswwds_14_tfserasaacoesuf = AV30TFSerasaAcoesUF;
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = AV31TFSerasaAcoesUF_Sel;
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = AV32TFSerasaAcoesPrincipal;
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV33TFSerasaAcoesPrincipal_Sel;
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = AV34TFSerasaAcoesTipoMoeda;
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV35TFSerasaAcoesTipoMoeda_Sel;
         AV59Serasaacoeswwds_20_tfserasaacoesqtdoco = AV36TFSerasaAcoesQtdOco;
         AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV37TFSerasaAcoesQtdOco_To;
      }

      protected void E11872( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesData") == 0 )
            {
               AV15TFSerasaAcoesData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri(sPrefix, false, "AV15TFSerasaAcoesData", context.localUtil.Format(AV15TFSerasaAcoesData, "99/99/99"));
               AV16TFSerasaAcoesData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri(sPrefix, false, "AV16TFSerasaAcoesData_To", context.localUtil.Format(AV16TFSerasaAcoesData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesNatureza") == 0 )
            {
               AV20TFSerasaAcoesNatureza = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV20TFSerasaAcoesNatureza", AV20TFSerasaAcoesNatureza);
               AV21TFSerasaAcoesNatureza_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV21TFSerasaAcoesNatureza_Sel", AV21TFSerasaAcoesNatureza_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesValor") == 0 )
            {
               AV22TFSerasaAcoesValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV22TFSerasaAcoesValor", StringUtil.LTrimStr( AV22TFSerasaAcoesValor, 18, 2));
               AV23TFSerasaAcoesValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV23TFSerasaAcoesValor_To", StringUtil.LTrimStr( AV23TFSerasaAcoesValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesDistribuidor") == 0 )
            {
               AV24TFSerasaAcoesDistribuidor = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV24TFSerasaAcoesDistribuidor", AV24TFSerasaAcoesDistribuidor);
               AV25TFSerasaAcoesDistribuidor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV25TFSerasaAcoesDistribuidor_Sel", AV25TFSerasaAcoesDistribuidor_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesVara") == 0 )
            {
               AV26TFSerasaAcoesVara = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV26TFSerasaAcoesVara", AV26TFSerasaAcoesVara);
               AV27TFSerasaAcoesVara_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV27TFSerasaAcoesVara_Sel", AV27TFSerasaAcoesVara_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesCidade") == 0 )
            {
               AV28TFSerasaAcoesCidade = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV28TFSerasaAcoesCidade", AV28TFSerasaAcoesCidade);
               AV29TFSerasaAcoesCidade_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV29TFSerasaAcoesCidade_Sel", AV29TFSerasaAcoesCidade_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesUF") == 0 )
            {
               AV30TFSerasaAcoesUF = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV30TFSerasaAcoesUF", AV30TFSerasaAcoesUF);
               AV31TFSerasaAcoesUF_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV31TFSerasaAcoesUF_Sel", AV31TFSerasaAcoesUF_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesPrincipal") == 0 )
            {
               AV32TFSerasaAcoesPrincipal = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV32TFSerasaAcoesPrincipal", AV32TFSerasaAcoesPrincipal);
               AV33TFSerasaAcoesPrincipal_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV33TFSerasaAcoesPrincipal_Sel", AV33TFSerasaAcoesPrincipal_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesTipoMoeda") == 0 )
            {
               AV34TFSerasaAcoesTipoMoeda = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV34TFSerasaAcoesTipoMoeda", AV34TFSerasaAcoesTipoMoeda);
               AV35TFSerasaAcoesTipoMoeda_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV35TFSerasaAcoesTipoMoeda_Sel", AV35TFSerasaAcoesTipoMoeda_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaAcoesQtdOco") == 0 )
            {
               AV36TFSerasaAcoesQtdOco = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFSerasaAcoesQtdOco", StringUtil.LTrimStr( (decimal)(AV36TFSerasaAcoesQtdOco), 4, 0));
               AV37TFSerasaAcoesQtdOco_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFSerasaAcoesQtdOco_To", StringUtil.LTrimStr( (decimal)(AV37TFSerasaAcoesQtdOco_To), 4, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E14872( )
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
         GXEncryptionTmp = "serasaacoes"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A699SerasaAcoesId,9,0));
         edtSerasaAcoesData_Link = formatLink("serasaacoes") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
         if ( StringUtil.StrCmp(AV14Session.Get(AV61Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV61Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV61Pgmname+"GridState"), null, "", "");
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
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDATA") == 0 )
            {
               AV15TFSerasaAcoesData = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri(sPrefix, false, "AV15TFSerasaAcoesData", context.localUtil.Format(AV15TFSerasaAcoesData, "99/99/99"));
               AV16TFSerasaAcoesData_To = context.localUtil.CToD( AV11GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri(sPrefix, false, "AV16TFSerasaAcoesData_To", context.localUtil.Format(AV16TFSerasaAcoesData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESNATUREZA") == 0 )
            {
               AV20TFSerasaAcoesNatureza = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20TFSerasaAcoesNatureza", AV20TFSerasaAcoesNatureza);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESNATUREZA_SEL") == 0 )
            {
               AV21TFSerasaAcoesNatureza_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFSerasaAcoesNatureza_Sel", AV21TFSerasaAcoesNatureza_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVALOR") == 0 )
            {
               AV22TFSerasaAcoesValor = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV22TFSerasaAcoesValor", StringUtil.LTrimStr( AV22TFSerasaAcoesValor, 18, 2));
               AV23TFSerasaAcoesValor_To = NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV23TFSerasaAcoesValor_To", StringUtil.LTrimStr( AV23TFSerasaAcoesValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDISTRIBUIDOR") == 0 )
            {
               AV24TFSerasaAcoesDistribuidor = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFSerasaAcoesDistribuidor", AV24TFSerasaAcoesDistribuidor);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDISTRIBUIDOR_SEL") == 0 )
            {
               AV25TFSerasaAcoesDistribuidor_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFSerasaAcoesDistribuidor_Sel", AV25TFSerasaAcoesDistribuidor_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVARA") == 0 )
            {
               AV26TFSerasaAcoesVara = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFSerasaAcoesVara", AV26TFSerasaAcoesVara);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVARA_SEL") == 0 )
            {
               AV27TFSerasaAcoesVara_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFSerasaAcoesVara_Sel", AV27TFSerasaAcoesVara_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESCIDADE") == 0 )
            {
               AV28TFSerasaAcoesCidade = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFSerasaAcoesCidade", AV28TFSerasaAcoesCidade);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESCIDADE_SEL") == 0 )
            {
               AV29TFSerasaAcoesCidade_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFSerasaAcoesCidade_Sel", AV29TFSerasaAcoesCidade_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESUF") == 0 )
            {
               AV30TFSerasaAcoesUF = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30TFSerasaAcoesUF", AV30TFSerasaAcoesUF);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESUF_SEL") == 0 )
            {
               AV31TFSerasaAcoesUF_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFSerasaAcoesUF_Sel", AV31TFSerasaAcoesUF_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESPRINCIPAL") == 0 )
            {
               AV32TFSerasaAcoesPrincipal = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFSerasaAcoesPrincipal", AV32TFSerasaAcoesPrincipal);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESPRINCIPAL_SEL") == 0 )
            {
               AV33TFSerasaAcoesPrincipal_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV33TFSerasaAcoesPrincipal_Sel", AV33TFSerasaAcoesPrincipal_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESTIPOMOEDA") == 0 )
            {
               AV34TFSerasaAcoesTipoMoeda = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV34TFSerasaAcoesTipoMoeda", AV34TFSerasaAcoesTipoMoeda);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESTIPOMOEDA_SEL") == 0 )
            {
               AV35TFSerasaAcoesTipoMoeda_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFSerasaAcoesTipoMoeda_Sel", AV35TFSerasaAcoesTipoMoeda_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAACOESQTDOCO") == 0 )
            {
               AV36TFSerasaAcoesQtdOco = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV36TFSerasaAcoesQtdOco", StringUtil.LTrimStr( (decimal)(AV36TFSerasaAcoesQtdOco), 4, 0));
               AV37TFSerasaAcoesQtdOco_To = (short)(Math.Round(NumberUtil.Val( AV11GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV37TFSerasaAcoesQtdOco_To", StringUtil.LTrimStr( (decimal)(AV37TFSerasaAcoesQtdOco_To), 4, 0));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSerasaAcoesNatureza_Sel)),  AV21TFSerasaAcoesNatureza_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaAcoesDistribuidor_Sel)),  AV25TFSerasaAcoesDistribuidor_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSerasaAcoesVara_Sel)),  AV27TFSerasaAcoesVara_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSerasaAcoesCidade_Sel)),  AV29TFSerasaAcoesCidade_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSerasaAcoesUF_Sel)),  AV31TFSerasaAcoesUF_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSerasaAcoesPrincipal_Sel)),  AV33TFSerasaAcoesPrincipal_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSerasaAcoesTipoMoeda_Sel)),  AV35TFSerasaAcoesTipoMoeda_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"||"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSerasaAcoesNatureza)),  AV20TFSerasaAcoesNatureza, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaAcoesDistribuidor)),  AV24TFSerasaAcoesDistribuidor, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSerasaAcoesVara)),  AV26TFSerasaAcoesVara, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSerasaAcoesCidade)),  AV28TFSerasaAcoesCidade, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSerasaAcoesUF)),  AV30TFSerasaAcoesUF, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSerasaAcoesPrincipal)),  AV32TFSerasaAcoesPrincipal, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSerasaAcoesTipoMoeda)),  AV34TFSerasaAcoesTipoMoeda, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV15TFSerasaAcoesData) ? "" : context.localUtil.DToC( AV15TFSerasaAcoesData, 4, "/"))+"|"+GXt_char8+"|"+((Convert.ToDecimal(0)==AV22TFSerasaAcoesValor) ? "" : StringUtil.Str( AV22TFSerasaAcoesValor, 18, 2))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2+"|"+((0==AV36TFSerasaAcoesQtdOco) ? "" : StringUtil.Str( (decimal)(AV36TFSerasaAcoesQtdOco), 4, 0));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV16TFSerasaAcoesData_To) ? "" : context.localUtil.DToC( AV16TFSerasaAcoesData_To, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV23TFSerasaAcoesValor_To) ? "" : StringUtil.Str( AV23TFSerasaAcoesValor_To, 18, 2))+"|||||||"+((0==AV37TFSerasaAcoesQtdOco_To) ? "" : StringUtil.Str( (decimal)(AV37TFSerasaAcoesQtdOco_To), 4, 0));
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
         AV10GridState.FromXml(AV14Session.Get(AV61Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAACOESDATA",  "",  !((DateTime.MinValue==AV15TFSerasaAcoesData)&&(DateTime.MinValue==AV16TFSerasaAcoesData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV15TFSerasaAcoesData, 4, "/")),  ((DateTime.MinValue==AV15TFSerasaAcoesData) ? "" : StringUtil.Trim( context.localUtil.Format( AV15TFSerasaAcoesData, "99/99/99"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV16TFSerasaAcoesData_To, 4, "/")),  ((DateTime.MinValue==AV16TFSerasaAcoesData_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV16TFSerasaAcoesData_To, "99/99/99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESNATUREZA",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSerasaAcoesNatureza)),  0,  AV20TFSerasaAcoesNatureza,  AV20TFSerasaAcoesNatureza,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSerasaAcoesNatureza_Sel)),  AV21TFSerasaAcoesNatureza_Sel,  AV21TFSerasaAcoesNatureza_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAACOESVALOR",  "",  !((Convert.ToDecimal(0)==AV22TFSerasaAcoesValor)&&(Convert.ToDecimal(0)==AV23TFSerasaAcoesValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV22TFSerasaAcoesValor, 18, 2)),  ((Convert.ToDecimal(0)==AV22TFSerasaAcoesValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV22TFSerasaAcoesValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV23TFSerasaAcoesValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV23TFSerasaAcoesValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV23TFSerasaAcoesValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESDISTRIBUIDOR",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaAcoesDistribuidor)),  0,  AV24TFSerasaAcoesDistribuidor,  AV24TFSerasaAcoesDistribuidor,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaAcoesDistribuidor_Sel)),  AV25TFSerasaAcoesDistribuidor_Sel,  AV25TFSerasaAcoesDistribuidor_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESVARA",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSerasaAcoesVara)),  0,  AV26TFSerasaAcoesVara,  AV26TFSerasaAcoesVara,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSerasaAcoesVara_Sel)),  AV27TFSerasaAcoesVara_Sel,  AV27TFSerasaAcoesVara_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESCIDADE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSerasaAcoesCidade)),  0,  AV28TFSerasaAcoesCidade,  AV28TFSerasaAcoesCidade,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSerasaAcoesCidade_Sel)),  AV29TFSerasaAcoesCidade_Sel,  AV29TFSerasaAcoesCidade_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESUF",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSerasaAcoesUF)),  0,  AV30TFSerasaAcoesUF,  AV30TFSerasaAcoesUF,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSerasaAcoesUF_Sel)),  AV31TFSerasaAcoesUF_Sel,  AV31TFSerasaAcoesUF_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESPRINCIPAL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSerasaAcoesPrincipal)),  0,  AV32TFSerasaAcoesPrincipal,  AV32TFSerasaAcoesPrincipal,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFSerasaAcoesPrincipal_Sel)),  AV33TFSerasaAcoesPrincipal_Sel,  AV33TFSerasaAcoesPrincipal_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAACOESTIPOMOEDA",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFSerasaAcoesTipoMoeda)),  0,  AV34TFSerasaAcoesTipoMoeda,  AV34TFSerasaAcoesTipoMoeda,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSerasaAcoesTipoMoeda_Sel)),  AV35TFSerasaAcoesTipoMoeda_Sel,  AV35TFSerasaAcoesTipoMoeda_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV10GridState,  "TFSERASAACOESQTDOCO",  "",  !((0==AV36TFSerasaAcoesQtdOco)&&(0==AV37TFSerasaAcoesQtdOco_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV36TFSerasaAcoesQtdOco), 4, 0)),  ((0==AV36TFSerasaAcoesQtdOco) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV36TFSerasaAcoesQtdOco), "ZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV37TFSerasaAcoesQtdOco_To), 4, 0)),  ((0==AV37TFSerasaAcoesQtdOco_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV37TFSerasaAcoesQtdOco_To), "ZZZ9")))) ;
         if ( ! (0==AV39SerasaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SERASAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV39SerasaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV61Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV61Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "SerasaAcoes";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SerasaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV39SerasaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV39SerasaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV39SerasaId", StringUtil.LTrimStr( (decimal)(AV39SerasaId), 9, 0));
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
         PA872( ) ;
         WS872( ) ;
         WE872( ) ;
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
         sCtrlAV39SerasaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA872( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "serasaacoesww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA872( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV39SerasaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV39SerasaId", StringUtil.LTrimStr( (decimal)(AV39SerasaId), 9, 0));
         }
         wcpOAV39SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV39SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV39SerasaId != wcpOAV39SerasaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV39SerasaId = AV39SerasaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV39SerasaId = cgiGet( sPrefix+"AV39SerasaId_CTRL");
         if ( StringUtil.Len( sCtrlAV39SerasaId) > 0 )
         {
            AV39SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV39SerasaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV39SerasaId", StringUtil.LTrimStr( (decimal)(AV39SerasaId), 9, 0));
         }
         else
         {
            AV39SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV39SerasaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA872( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS872( ) ;
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
         WS872( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV39SerasaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39SerasaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV39SerasaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV39SerasaId_CTRL", StringUtil.RTrim( sCtrlAV39SerasaId));
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
         WE872( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019201468", true, true);
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
         context.AddJavascriptSource("serasaacoesww.js", "?202561019201469", false, true);
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
         edtSerasaAcoesId_Internalname = sPrefix+"SERASAACOESID_"+sGXsfl_12_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_idx;
         edtSerasaAcoesData_Internalname = sPrefix+"SERASAACOESDATA_"+sGXsfl_12_idx;
         edtSerasaAcoesNatureza_Internalname = sPrefix+"SERASAACOESNATUREZA_"+sGXsfl_12_idx;
         edtSerasaAcoesValor_Internalname = sPrefix+"SERASAACOESVALOR_"+sGXsfl_12_idx;
         edtSerasaAcoesDistribuidor_Internalname = sPrefix+"SERASAACOESDISTRIBUIDOR_"+sGXsfl_12_idx;
         edtSerasaAcoesVara_Internalname = sPrefix+"SERASAACOESVARA_"+sGXsfl_12_idx;
         edtSerasaAcoesCidade_Internalname = sPrefix+"SERASAACOESCIDADE_"+sGXsfl_12_idx;
         edtSerasaAcoesUF_Internalname = sPrefix+"SERASAACOESUF_"+sGXsfl_12_idx;
         edtSerasaAcoesPrincipal_Internalname = sPrefix+"SERASAACOESPRINCIPAL_"+sGXsfl_12_idx;
         edtSerasaAcoesTipoMoeda_Internalname = sPrefix+"SERASAACOESTIPOMOEDA_"+sGXsfl_12_idx;
         edtSerasaAcoesQtdOco_Internalname = sPrefix+"SERASAACOESQTDOCO_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtSerasaAcoesId_Internalname = sPrefix+"SERASAACOESID_"+sGXsfl_12_fel_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesData_Internalname = sPrefix+"SERASAACOESDATA_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesNatureza_Internalname = sPrefix+"SERASAACOESNATUREZA_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesValor_Internalname = sPrefix+"SERASAACOESVALOR_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesDistribuidor_Internalname = sPrefix+"SERASAACOESDISTRIBUIDOR_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesVara_Internalname = sPrefix+"SERASAACOESVARA_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesCidade_Internalname = sPrefix+"SERASAACOESCIDADE_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesUF_Internalname = sPrefix+"SERASAACOESUF_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesPrincipal_Internalname = sPrefix+"SERASAACOESPRINCIPAL_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesTipoMoeda_Internalname = sPrefix+"SERASAACOESTIPOMOEDA_"+sGXsfl_12_fel_idx;
         edtSerasaAcoesQtdOco_Internalname = sPrefix+"SERASAACOESQTDOCO_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB870( ) ;
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A699SerasaAcoesId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A699SerasaAcoesId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
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
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesData_Internalname,context.localUtil.Format(A700SerasaAcoesData, "99/99/99"),context.localUtil.Format( A700SerasaAcoesData, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSerasaAcoesData_Link,(string)"",(string)"",(string)"",(string)edtSerasaAcoesData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesNatureza_Internalname,(string)A701SerasaAcoesNatureza,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesNatureza_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A702SerasaAcoesValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesDistribuidor_Internalname,(string)A703SerasaAcoesDistribuidor,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesDistribuidor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesVara_Internalname,(string)A704SerasaAcoesVara,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesVara_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesCidade_Internalname,(string)A705SerasaAcoesCidade,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesCidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesUF_Internalname,(string)A706SerasaAcoesUF,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesUF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesPrincipal_Internalname,(string)A707SerasaAcoesPrincipal,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesPrincipal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesTipoMoeda_Internalname,(string)A708SerasaAcoesTipoMoeda,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesTipoMoeda_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaAcoesQtdOco_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A709SerasaAcoesQtdOco), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaAcoesQtdOco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes872( ) ;
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
            context.SendWebValue( "Acoes Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data da ocorrência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Natureza") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Distribuidor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vara") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "UF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Principal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo da moeda") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantidade de ações") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A699SerasaAcoesId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A700SerasaAcoesData, "99/99/99")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSerasaAcoesData_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A701SerasaAcoesNatureza));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A702SerasaAcoesValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A703SerasaAcoesDistribuidor));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A704SerasaAcoesVara));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A705SerasaAcoesCidade));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A706SerasaAcoesUF));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A707SerasaAcoesPrincipal));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A708SerasaAcoesTipoMoeda));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A709SerasaAcoesQtdOco), 4, 0, ".", ""))));
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
         edtSerasaAcoesId_Internalname = sPrefix+"SERASAACOESID";
         edtSerasaId_Internalname = sPrefix+"SERASAID";
         edtSerasaAcoesData_Internalname = sPrefix+"SERASAACOESDATA";
         edtSerasaAcoesNatureza_Internalname = sPrefix+"SERASAACOESNATUREZA";
         edtSerasaAcoesValor_Internalname = sPrefix+"SERASAACOESVALOR";
         edtSerasaAcoesDistribuidor_Internalname = sPrefix+"SERASAACOESDISTRIBUIDOR";
         edtSerasaAcoesVara_Internalname = sPrefix+"SERASAACOESVARA";
         edtSerasaAcoesCidade_Internalname = sPrefix+"SERASAACOESCIDADE";
         edtSerasaAcoesUF_Internalname = sPrefix+"SERASAACOESUF";
         edtSerasaAcoesPrincipal_Internalname = sPrefix+"SERASAACOESPRINCIPAL";
         edtSerasaAcoesTipoMoeda_Internalname = sPrefix+"SERASAACOESTIPOMOEDA";
         edtSerasaAcoesQtdOco_Internalname = sPrefix+"SERASAACOESQTDOCO";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         edtavDdo_serasaacoesdataauxdatetext_Internalname = sPrefix+"vDDO_SERASAACOESDATAAUXDATETEXT";
         Tfserasaacoesdata_rangepicker_Internalname = sPrefix+"TFSERASAACOESDATA_RANGEPICKER";
         divDdo_serasaacoesdataauxdates_Internalname = sPrefix+"DDO_SERASAACOESDATAAUXDATES";
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
         edtSerasaAcoesQtdOco_Jsonclick = "";
         edtSerasaAcoesTipoMoeda_Jsonclick = "";
         edtSerasaAcoesPrincipal_Jsonclick = "";
         edtSerasaAcoesUF_Jsonclick = "";
         edtSerasaAcoesCidade_Jsonclick = "";
         edtSerasaAcoesVara_Jsonclick = "";
         edtSerasaAcoesDistribuidor_Jsonclick = "";
         edtSerasaAcoesValor_Jsonclick = "";
         edtSerasaAcoesNatureza_Jsonclick = "";
         edtSerasaAcoesData_Jsonclick = "";
         edtSerasaAcoesData_Link = "";
         edtSerasaId_Jsonclick = "";
         edtSerasaAcoesId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtSerasaAcoesQtdOco_Enabled = 0;
         edtSerasaAcoesTipoMoeda_Enabled = 0;
         edtSerasaAcoesPrincipal_Enabled = 0;
         edtSerasaAcoesUF_Enabled = 0;
         edtSerasaAcoesCidade_Enabled = 0;
         edtSerasaAcoesVara_Enabled = 0;
         edtSerasaAcoesDistribuidor_Enabled = 0;
         edtSerasaAcoesValor_Enabled = 0;
         edtSerasaAcoesNatureza_Enabled = 0;
         edtSerasaAcoesData_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaAcoesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_serasaacoesdataauxdatetext_Jsonclick = "";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "||18.2|||||||4.0";
         Ddo_grid_Datalistproc = "SerasaAcoesWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "|T||T|T|T|T|T|T|";
         Ddo_grid_Filterisrange = "P||T|||||||T";
         Ddo_grid_Filtertype = "Date|Character|Numeric|Character|Character|Character|Character|Character|Character|Numeric";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "2:SerasaAcoesData|3:SerasaAcoesNatureza|4:SerasaAcoesValor|5:SerasaAcoesDistribuidor|6:SerasaAcoesVara|7:SerasaAcoesCidade|8:SerasaAcoesUF|9:SerasaAcoesPrincipal|10:SerasaAcoesTipoMoeda|11:SerasaAcoesQtdOco";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11872","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14872","iparms":[{"av":"A699SerasaAcoesId","fld":"SERASAACOESID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSerasaAcoesData_Link","ctrl":"SERASAACOESDATA","prop":"Link"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV39SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaAcoesData","fld":"vTFSERASAACOESDATA","type":"date"},{"av":"AV16TFSerasaAcoesData_To","fld":"vTFSERASAACOESDATA_TO","type":"date"},{"av":"AV20TFSerasaAcoesNatureza","fld":"vTFSERASAACOESNATUREZA","type":"svchar"},{"av":"AV21TFSerasaAcoesNatureza_Sel","fld":"vTFSERASAACOESNATUREZA_SEL","type":"svchar"},{"av":"AV22TFSerasaAcoesValor","fld":"vTFSERASAACOESVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV23TFSerasaAcoesValor_To","fld":"vTFSERASAACOESVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24TFSerasaAcoesDistribuidor","fld":"vTFSERASAACOESDISTRIBUIDOR","type":"svchar"},{"av":"AV25TFSerasaAcoesDistribuidor_Sel","fld":"vTFSERASAACOESDISTRIBUIDOR_SEL","type":"svchar"},{"av":"AV26TFSerasaAcoesVara","fld":"vTFSERASAACOESVARA","type":"svchar"},{"av":"AV27TFSerasaAcoesVara_Sel","fld":"vTFSERASAACOESVARA_SEL","type":"svchar"},{"av":"AV28TFSerasaAcoesCidade","fld":"vTFSERASAACOESCIDADE","type":"svchar"},{"av":"AV29TFSerasaAcoesCidade_Sel","fld":"vTFSERASAACOESCIDADE_SEL","type":"svchar"},{"av":"AV30TFSerasaAcoesUF","fld":"vTFSERASAACOESUF","type":"svchar"},{"av":"AV31TFSerasaAcoesUF_Sel","fld":"vTFSERASAACOESUF_SEL","type":"svchar"},{"av":"AV32TFSerasaAcoesPrincipal","fld":"vTFSERASAACOESPRINCIPAL","type":"svchar"},{"av":"AV33TFSerasaAcoesPrincipal_Sel","fld":"vTFSERASAACOESPRINCIPAL_SEL","type":"svchar"},{"av":"AV34TFSerasaAcoesTipoMoeda","fld":"vTFSERASAACOESTIPOMOEDA","type":"svchar"},{"av":"AV35TFSerasaAcoesTipoMoeda_Sel","fld":"vTFSERASAACOESTIPOMOEDA_SEL","type":"svchar"},{"av":"AV36TFSerasaAcoesQtdOco","fld":"vTFSERASAACOESQTDOCO","pic":"ZZZ9","type":"int"},{"av":"AV37TFSerasaAcoesQtdOco_To","fld":"vTFSERASAACOESQTDOCO_TO","pic":"ZZZ9","type":"int"},{"av":"AV61Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Serasaacoesqtdoco","iparms":[]}""");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15TFSerasaAcoesData = DateTime.MinValue;
         AV16TFSerasaAcoesData_To = DateTime.MinValue;
         AV20TFSerasaAcoesNatureza = "";
         AV21TFSerasaAcoesNatureza_Sel = "";
         AV24TFSerasaAcoesDistribuidor = "";
         AV25TFSerasaAcoesDistribuidor_Sel = "";
         AV26TFSerasaAcoesVara = "";
         AV27TFSerasaAcoesVara_Sel = "";
         AV28TFSerasaAcoesCidade = "";
         AV29TFSerasaAcoesCidade_Sel = "";
         AV30TFSerasaAcoesUF = "";
         AV31TFSerasaAcoesUF_Sel = "";
         AV32TFSerasaAcoesPrincipal = "";
         AV33TFSerasaAcoesPrincipal_Sel = "";
         AV34TFSerasaAcoesTipoMoeda = "";
         AV35TFSerasaAcoesTipoMoeda_Sel = "";
         AV61Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV38DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17DDO_SerasaAcoesDataAuxDate = DateTime.MinValue;
         AV18DDO_SerasaAcoesDataAuxDateTo = DateTime.MinValue;
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
         AV19DDO_SerasaAcoesDataAuxDateText = "";
         ucTfserasaacoesdata_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41Serasaacoeswwds_2_tfserasaacoesdata = DateTime.MinValue;
         AV42Serasaacoeswwds_3_tfserasaacoesdata_to = DateTime.MinValue;
         AV43Serasaacoeswwds_4_tfserasaacoesnatureza = "";
         AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel = "";
         AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = "";
         AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = "";
         AV49Serasaacoeswwds_10_tfserasaacoesvara = "";
         AV50Serasaacoeswwds_11_tfserasaacoesvara_sel = "";
         AV51Serasaacoeswwds_12_tfserasaacoescidade = "";
         AV52Serasaacoeswwds_13_tfserasaacoescidade_sel = "";
         AV53Serasaacoeswwds_14_tfserasaacoesuf = "";
         AV54Serasaacoeswwds_15_tfserasaacoesuf_sel = "";
         AV55Serasaacoeswwds_16_tfserasaacoesprincipal = "";
         AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel = "";
         AV57Serasaacoeswwds_18_tfserasaacoestipomoeda = "";
         AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = "";
         A700SerasaAcoesData = DateTime.MinValue;
         A701SerasaAcoesNatureza = "";
         A703SerasaAcoesDistribuidor = "";
         A704SerasaAcoesVara = "";
         A705SerasaAcoesCidade = "";
         A706SerasaAcoesUF = "";
         A707SerasaAcoesPrincipal = "";
         A708SerasaAcoesTipoMoeda = "";
         GXDecQS = "";
         lV43Serasaacoeswwds_4_tfserasaacoesnatureza = "";
         lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor = "";
         lV49Serasaacoeswwds_10_tfserasaacoesvara = "";
         lV51Serasaacoeswwds_12_tfserasaacoescidade = "";
         lV53Serasaacoeswwds_14_tfserasaacoesuf = "";
         lV55Serasaacoeswwds_16_tfserasaacoesprincipal = "";
         lV57Serasaacoeswwds_18_tfserasaacoestipomoeda = "";
         H00872_A709SerasaAcoesQtdOco = new short[1] ;
         H00872_n709SerasaAcoesQtdOco = new bool[] {false} ;
         H00872_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         H00872_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         H00872_A707SerasaAcoesPrincipal = new string[] {""} ;
         H00872_n707SerasaAcoesPrincipal = new bool[] {false} ;
         H00872_A706SerasaAcoesUF = new string[] {""} ;
         H00872_n706SerasaAcoesUF = new bool[] {false} ;
         H00872_A705SerasaAcoesCidade = new string[] {""} ;
         H00872_n705SerasaAcoesCidade = new bool[] {false} ;
         H00872_A704SerasaAcoesVara = new string[] {""} ;
         H00872_n704SerasaAcoesVara = new bool[] {false} ;
         H00872_A703SerasaAcoesDistribuidor = new string[] {""} ;
         H00872_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         H00872_A702SerasaAcoesValor = new decimal[1] ;
         H00872_n702SerasaAcoesValor = new bool[] {false} ;
         H00872_A701SerasaAcoesNatureza = new string[] {""} ;
         H00872_n701SerasaAcoesNatureza = new bool[] {false} ;
         H00872_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         H00872_n700SerasaAcoesData = new bool[] {false} ;
         H00872_A662SerasaId = new int[1] ;
         H00872_n662SerasaId = new bool[] {false} ;
         H00872_A699SerasaAcoesId = new int[1] ;
         H00873_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV39SerasaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaacoesww__default(),
            new Object[][] {
                new Object[] {
               H00872_A709SerasaAcoesQtdOco, H00872_n709SerasaAcoesQtdOco, H00872_A708SerasaAcoesTipoMoeda, H00872_n708SerasaAcoesTipoMoeda, H00872_A707SerasaAcoesPrincipal, H00872_n707SerasaAcoesPrincipal, H00872_A706SerasaAcoesUF, H00872_n706SerasaAcoesUF, H00872_A705SerasaAcoesCidade, H00872_n705SerasaAcoesCidade,
               H00872_A704SerasaAcoesVara, H00872_n704SerasaAcoesVara, H00872_A703SerasaAcoesDistribuidor, H00872_n703SerasaAcoesDistribuidor, H00872_A702SerasaAcoesValor, H00872_n702SerasaAcoesValor, H00872_A701SerasaAcoesNatureza, H00872_n701SerasaAcoesNatureza, H00872_A700SerasaAcoesData, H00872_n700SerasaAcoesData,
               H00872_A662SerasaId, H00872_n662SerasaId, H00872_A699SerasaAcoesId
               }
               , new Object[] {
               H00873_AGRID_nRecordCount
               }
            }
         );
         AV61Pgmname = "SerasaAcoesWW";
         /* GeneXus formulas. */
         AV61Pgmname = "SerasaAcoesWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short AV36TFSerasaAcoesQtdOco ;
      private short AV37TFSerasaAcoesQtdOco_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV59Serasaacoeswwds_20_tfserasaacoesqtdoco ;
      private short AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to ;
      private short A709SerasaAcoesQtdOco ;
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
      private int AV39SerasaId ;
      private int wcpOAV39SerasaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV40Serasaacoeswwds_1_serasaid ;
      private int A699SerasaAcoesId ;
      private int A662SerasaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSerasaAcoesId_Enabled ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaAcoesData_Enabled ;
      private int edtSerasaAcoesNatureza_Enabled ;
      private int edtSerasaAcoesValor_Enabled ;
      private int edtSerasaAcoesDistribuidor_Enabled ;
      private int edtSerasaAcoesVara_Enabled ;
      private int edtSerasaAcoesCidade_Enabled ;
      private int edtSerasaAcoesUF_Enabled ;
      private int edtSerasaAcoesPrincipal_Enabled ;
      private int edtSerasaAcoesTipoMoeda_Enabled ;
      private int edtSerasaAcoesQtdOco_Enabled ;
      private int AV62GXV1 ;
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
      private decimal AV22TFSerasaAcoesValor ;
      private decimal AV23TFSerasaAcoesValor_To ;
      private decimal AV45Serasaacoeswwds_6_tfserasaacoesvalor ;
      private decimal AV46Serasaacoeswwds_7_tfserasaacoesvalor_to ;
      private decimal A702SerasaAcoesValor ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string AV61Pgmname ;
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
      private string divDdo_serasaacoesdataauxdates_Internalname ;
      private string TempTags ;
      private string edtavDdo_serasaacoesdataauxdatetext_Internalname ;
      private string edtavDdo_serasaacoesdataauxdatetext_Jsonclick ;
      private string Tfserasaacoesdata_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSerasaAcoesId_Internalname ;
      private string edtSerasaId_Internalname ;
      private string edtSerasaAcoesData_Internalname ;
      private string edtSerasaAcoesNatureza_Internalname ;
      private string edtSerasaAcoesValor_Internalname ;
      private string edtSerasaAcoesDistribuidor_Internalname ;
      private string edtSerasaAcoesVara_Internalname ;
      private string edtSerasaAcoesCidade_Internalname ;
      private string edtSerasaAcoesUF_Internalname ;
      private string edtSerasaAcoesPrincipal_Internalname ;
      private string edtSerasaAcoesTipoMoeda_Internalname ;
      private string edtSerasaAcoesQtdOco_Internalname ;
      private string GXDecQS ;
      private string edtSerasaAcoesData_Link ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV39SerasaId ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSerasaAcoesId_Jsonclick ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaAcoesData_Jsonclick ;
      private string edtSerasaAcoesNatureza_Jsonclick ;
      private string edtSerasaAcoesValor_Jsonclick ;
      private string edtSerasaAcoesDistribuidor_Jsonclick ;
      private string edtSerasaAcoesVara_Jsonclick ;
      private string edtSerasaAcoesCidade_Jsonclick ;
      private string edtSerasaAcoesUF_Jsonclick ;
      private string edtSerasaAcoesPrincipal_Jsonclick ;
      private string edtSerasaAcoesTipoMoeda_Jsonclick ;
      private string edtSerasaAcoesQtdOco_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV15TFSerasaAcoesData ;
      private DateTime AV16TFSerasaAcoesData_To ;
      private DateTime AV17DDO_SerasaAcoesDataAuxDate ;
      private DateTime AV18DDO_SerasaAcoesDataAuxDateTo ;
      private DateTime AV41Serasaacoeswwds_2_tfserasaacoesdata ;
      private DateTime AV42Serasaacoeswwds_3_tfserasaacoesdata_to ;
      private DateTime A700SerasaAcoesData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n662SerasaId ;
      private bool n700SerasaAcoesData ;
      private bool n701SerasaAcoesNatureza ;
      private bool n702SerasaAcoesValor ;
      private bool n703SerasaAcoesDistribuidor ;
      private bool n704SerasaAcoesVara ;
      private bool n705SerasaAcoesCidade ;
      private bool n706SerasaAcoesUF ;
      private bool n707SerasaAcoesPrincipal ;
      private bool n708SerasaAcoesTipoMoeda ;
      private bool n709SerasaAcoesQtdOco ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV20TFSerasaAcoesNatureza ;
      private string AV21TFSerasaAcoesNatureza_Sel ;
      private string AV24TFSerasaAcoesDistribuidor ;
      private string AV25TFSerasaAcoesDistribuidor_Sel ;
      private string AV26TFSerasaAcoesVara ;
      private string AV27TFSerasaAcoesVara_Sel ;
      private string AV28TFSerasaAcoesCidade ;
      private string AV29TFSerasaAcoesCidade_Sel ;
      private string AV30TFSerasaAcoesUF ;
      private string AV31TFSerasaAcoesUF_Sel ;
      private string AV32TFSerasaAcoesPrincipal ;
      private string AV33TFSerasaAcoesPrincipal_Sel ;
      private string AV34TFSerasaAcoesTipoMoeda ;
      private string AV35TFSerasaAcoesTipoMoeda_Sel ;
      private string AV19DDO_SerasaAcoesDataAuxDateText ;
      private string AV43Serasaacoeswwds_4_tfserasaacoesnatureza ;
      private string AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel ;
      private string AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ;
      private string AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ;
      private string AV49Serasaacoeswwds_10_tfserasaacoesvara ;
      private string AV50Serasaacoeswwds_11_tfserasaacoesvara_sel ;
      private string AV51Serasaacoeswwds_12_tfserasaacoescidade ;
      private string AV52Serasaacoeswwds_13_tfserasaacoescidade_sel ;
      private string AV53Serasaacoeswwds_14_tfserasaacoesuf ;
      private string AV54Serasaacoeswwds_15_tfserasaacoesuf_sel ;
      private string AV55Serasaacoeswwds_16_tfserasaacoesprincipal ;
      private string AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel ;
      private string AV57Serasaacoeswwds_18_tfserasaacoestipomoeda ;
      private string AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ;
      private string A701SerasaAcoesNatureza ;
      private string A703SerasaAcoesDistribuidor ;
      private string A704SerasaAcoesVara ;
      private string A705SerasaAcoesCidade ;
      private string A706SerasaAcoesUF ;
      private string A707SerasaAcoesPrincipal ;
      private string A708SerasaAcoesTipoMoeda ;
      private string lV43Serasaacoeswwds_4_tfserasaacoesnatureza ;
      private string lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ;
      private string lV49Serasaacoeswwds_10_tfserasaacoesvara ;
      private string lV51Serasaacoeswwds_12_tfserasaacoescidade ;
      private string lV53Serasaacoeswwds_14_tfserasaacoesuf ;
      private string lV55Serasaacoeswwds_16_tfserasaacoesprincipal ;
      private string lV57Serasaacoeswwds_18_tfserasaacoestipomoeda ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfserasaacoesdata_rangepicker ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV38DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private short[] H00872_A709SerasaAcoesQtdOco ;
      private bool[] H00872_n709SerasaAcoesQtdOco ;
      private string[] H00872_A708SerasaAcoesTipoMoeda ;
      private bool[] H00872_n708SerasaAcoesTipoMoeda ;
      private string[] H00872_A707SerasaAcoesPrincipal ;
      private bool[] H00872_n707SerasaAcoesPrincipal ;
      private string[] H00872_A706SerasaAcoesUF ;
      private bool[] H00872_n706SerasaAcoesUF ;
      private string[] H00872_A705SerasaAcoesCidade ;
      private bool[] H00872_n705SerasaAcoesCidade ;
      private string[] H00872_A704SerasaAcoesVara ;
      private bool[] H00872_n704SerasaAcoesVara ;
      private string[] H00872_A703SerasaAcoesDistribuidor ;
      private bool[] H00872_n703SerasaAcoesDistribuidor ;
      private decimal[] H00872_A702SerasaAcoesValor ;
      private bool[] H00872_n702SerasaAcoesValor ;
      private string[] H00872_A701SerasaAcoesNatureza ;
      private bool[] H00872_n701SerasaAcoesNatureza ;
      private DateTime[] H00872_A700SerasaAcoesData ;
      private bool[] H00872_n700SerasaAcoesData ;
      private int[] H00872_A662SerasaId ;
      private bool[] H00872_n662SerasaId ;
      private int[] H00872_A699SerasaAcoesId ;
      private long[] H00873_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaacoesww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00872( IGxContext context ,
                                             DateTime AV41Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV42Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV43Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV45Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV46Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV50Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV49Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV52Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV51Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV54Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV53Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV55Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV57Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV59Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV40Serasaacoeswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[24];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaId, SerasaAcoesId";
         sFromString = " FROM SerasaAcoes";
         sOrderString = "";
         AddWhere(sWhereString, "(SerasaId = :AV40Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV41Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV41Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV42Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV42Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV43Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV45Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV45Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV46Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV49Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV50Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV51Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV52Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV53Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV54Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV55Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV57Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV59Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV59Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (0==AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesData, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesData DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesNatureza, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesNatureza DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesValor, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesValor DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesDistribuidor, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesDistribuidor DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesVara, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesVara DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesCidade, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesCidade DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesUF, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesUF DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesPrincipal, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesPrincipal DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesTipoMoeda, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesTipoMoeda DESC, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaAcoesQtdOco, SerasaAcoesId";
         }
         else if ( ( AV12OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaAcoesQtdOco DESC, SerasaAcoesId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY SerasaAcoesId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H00873( IGxContext context ,
                                             DateTime AV41Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV42Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV43Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV45Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV46Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV50Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV49Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV52Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV51Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV54Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV53Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV55Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV57Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV59Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV40Serasaacoeswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[21];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV40Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV41Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV41Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV42Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV42Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV43Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV45Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV45Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV46Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV46Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV49Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV50Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV50Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV51Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV52Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV52Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV53Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV54Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV54Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV55Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV57Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV59Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV59Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! (0==AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int11[20] = 1;
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
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 10 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 10 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00872(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] );
               case 1 :
                     return conditional_H00873(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (bool)dynConstraints[31] , (int)dynConstraints[32] , (int)dynConstraints[33] );
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
          Object[] prmH00872;
          prmH00872 = new Object[] {
          new ParDef("AV40Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV41Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV42Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV43Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV45Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV46Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV49Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV50Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV51Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV52Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV54Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00873;
          prmH00873 = new Object[] {
          new ParDef("AV40Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV41Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV42Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV43Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV44Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV45Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV46Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV47Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV48Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV49Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV50Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV51Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV52Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV53Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV54Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV55Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV56Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV57Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV58Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV60Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00872", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00872,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00873", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00873,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
