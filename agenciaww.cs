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
   public class agenciaww : GXDataArea
   {
      public agenciaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agenciaww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_BancoId )
      {
         this.AV7BancoId = aP0_BancoId;
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
         cmbavGridactiongroup1 = new GXCombobox();
         cmbAgenciaStatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "BancoId");
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
               gxfirstwebparm = GetFirstPar( "BancoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "BancoId");
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
         nRC_GXsfl_110 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_110"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_110_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_110_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_110_idx = GetPar( "sGXsfl_110_idx");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero1"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero2"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV31AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaNumero3"), "."), 18, MidpointRounding.ToEven));
         AV7BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
         AV41ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV73Pgmname = GetPar( "Pgmname");
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV28DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV71TFAgenciaBancoNome = GetPar( "TFAgenciaBancoNome");
         AV72TFAgenciaBancoNome_Sel = GetPar( "TFAgenciaBancoNome_Sel");
         AV44TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero"), "."), 18, MidpointRounding.ToEven));
         AV45TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaNumero_To"), "."), 18, MidpointRounding.ToEven));
         AV46TFAgenciaDigito = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaDigito"), "."), 18, MidpointRounding.ToEven));
         AV47TFAgenciaDigito_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaDigito_To"), "."), 18, MidpointRounding.ToEven));
         AV48TFAgenciaStatus_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFAgenciaStatus_Sel"), "."), 18, MidpointRounding.ToEven));
         AV51TFAgenciaCreatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFAgenciaCreatedAt"));
         AV52TFAgenciaCreatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFAgenciaCreatedAt_To"));
         AV58TFAgenciaUpdatedAt = context.localUtil.ParseDTimeParm( GetPar( "TFAgenciaUpdatedAt"));
         AV59TFAgenciaUpdatedAt_To = context.localUtil.ParseDTimeParm( GetPar( "TFAgenciaUpdatedAt_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV35DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV34DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
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
         PA9J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9J2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agenciaww"+UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("agenciaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19AgenciaNumero1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25AgenciaNumero2), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV29DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAGENCIANUMERO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31AgenciaNumero3), 9, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_110", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_110), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV39ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV65GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV66GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV67GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV63DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV63DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_AGENCIACREATEDATAUXDATE", context.localUtil.DToC( AV53DDO_AgenciaCreatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AGENCIACREATEDATAUXDATETO", context.localUtil.DToC( AV54DDO_AgenciaCreatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AGENCIAUPDATEDATAUXDATE", context.localUtil.DToC( AV60DDO_AgenciaUpdatedAtAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AGENCIAUPDATEDATAUXDATETO", context.localUtil.DToC( AV61DDO_AgenciaUpdatedAtAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV28DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME", AV71TFAgenciaBancoNome);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIABANCONOME_SEL", AV72TFAgenciaBancoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44TFAgenciaNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIANUMERO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45TFAgenciaNumero_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIADIGITO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFAgenciaDigito), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIADIGITO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFAgenciaDigito_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIASTATUS_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIACREATEDAT", context.localUtil.TToC( AV51TFAgenciaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIACREATEDAT_TO", context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIAUPDATEDAT", context.localUtil.TToC( AV58TFAgenciaUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAGENCIAUPDATEDAT_TO", context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vBANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV35DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV34DynamicFiltersRemoving);
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
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
            WE9J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9J2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agenciaww"+UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         return formatLink("agenciaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AgenciaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Lista de agências" ;
      }

      protected void WB9J0( )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(110), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AgenciaWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_AgenciaWW.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV17DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_48_9J2( true) ;
         }
         else
         {
            wb_table1_48_9J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_48_9J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_70_9J2( true) ;
         }
         else
         {
            wb_table2_70_9J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_70_9J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_92_9J2( true) ;
         }
         else
         {
            wb_table3_92_9J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_92_9J2e( bool wbgen )
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
            StartGridControl110( ) ;
         }
         if ( wbEnd == 110 )
         {
            wbEnd = 0;
            nRC_GXsfl_110 = (int)(nGXsfl_110_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV65GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV66GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV67GridAppliedFilters);
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_AgenciaWW.htm");
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV63DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_agenciacreatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_agenciacreatedatauxdatetext_Internalname, AV55DDO_AgenciaCreatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV55DDO_AgenciaCreatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_agenciacreatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AgenciaWW.htm");
            /* User Defined Control */
            ucTfagenciacreatedat_rangepicker.SetProperty("Start Date", AV53DDO_AgenciaCreatedAtAuxDate);
            ucTfagenciacreatedat_rangepicker.SetProperty("End Date", AV54DDO_AgenciaCreatedAtAuxDateTo);
            ucTfagenciacreatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfagenciacreatedat_rangepicker_Internalname, "TFAGENCIACREATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_agenciaupdatedatauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_agenciaupdatedatauxdatetext_Internalname, AV62DDO_AgenciaUpdatedAtAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV62DDO_AgenciaUpdatedAtAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_agenciaupdatedatauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AgenciaWW.htm");
            /* User Defined Control */
            ucTfagenciaupdatedat_rangepicker.SetProperty("Start Date", AV60DDO_AgenciaUpdatedAtAuxDate);
            ucTfagenciaupdatedat_rangepicker.SetProperty("End Date", AV61DDO_AgenciaUpdatedAtAuxDateTo);
            ucTfagenciaupdatedat_rangepicker.Render(context, "wwp.daterangepicker", Tfagenciaupdatedat_rangepicker_Internalname, "TFAGENCIAUPDATEDAT_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 110 )
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

      protected void START9J2( )
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
         Form.Meta.addItem("description", " Lista de agências", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9J0( ) ;
      }

      protected void WS9J2( )
      {
         START9J2( ) ;
         EVT9J2( ) ;
      }

      protected void EVT9J2( )
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
                              E119J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E129J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E139J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E149J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E159J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E169J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E179J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E189J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E199J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E209J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E219J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E229J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E239J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E249J2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "VGRIDACTIONGROUP1.CLICK") == 0 ) )
                           {
                              nGXsfl_110_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
                              SubsflControlProps_1102( ) ;
                              cmbavGridactiongroup1.Name = cmbavGridactiongroup1_Internalname;
                              cmbavGridactiongroup1.CurrentValue = cgiGet( cmbavGridactiongroup1_Internalname);
                              AV70GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactiongroup1_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActionGroup1), 4, 0));
                              A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A969AgenciaBancoNome = cgiGet( edtAgenciaBancoNome_Internalname);
                              n969AgenciaBancoNome = false;
                              A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n939AgenciaNumero = false;
                              A945AgenciaDigito = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAgenciaDigito_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n945AgenciaDigito = false;
                              cmbAgenciaStatus.Name = cmbAgenciaStatus_Internalname;
                              cmbAgenciaStatus.CurrentValue = cgiGet( cmbAgenciaStatus_Internalname);
                              A940AgenciaStatus = StringUtil.StrToBool( cgiGet( cmbAgenciaStatus_Internalname));
                              n940AgenciaStatus = false;
                              A941AgenciaCreatedAt = context.localUtil.CToT( cgiGet( edtAgenciaCreatedAt_Internalname), 0);
                              n941AgenciaCreatedAt = false;
                              A942AgenciaUpdatedAt = context.localUtil.CToT( cgiGet( edtAgenciaUpdatedAt_Internalname), 0);
                              n942AgenciaUpdatedAt = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E259J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E269J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E279J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONGROUP1.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E289J2 ();
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
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Agencianumero1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19AgenciaNumero1 )) )
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
                                       /* Set Refresh If Agencianumero2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO2"), ",", ".") != Convert.ToDecimal( AV25AgenciaNumero2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Agencianumero3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO3"), ",", ".") != Convert.ToDecimal( AV31AgenciaNumero3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE9J2( )
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

      protected void PA9J2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "agenciaww")), "agenciaww") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "agenciaww")))) ;
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
                  gxfirstwebparm = GetFirstPar( "BancoId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7BancoId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7BancoId", StringUtil.LTrimStr( (decimal)(AV7BancoId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
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
         SubsflControlProps_1102( ) ;
         while ( nGXsfl_110_idx <= nRC_GXsfl_110 )
         {
            sendrow_1102( ) ;
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       int AV19AgenciaNumero1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       int AV25AgenciaNumero2 ,
                                       string AV29DynamicFiltersSelector3 ,
                                       short AV30DynamicFiltersOperator3 ,
                                       int AV31AgenciaNumero3 ,
                                       int AV7BancoId ,
                                       short AV41ManageFiltersExecutionStep ,
                                       string AV73Pgmname ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV28DynamicFiltersEnabled3 ,
                                       string AV71TFAgenciaBancoNome ,
                                       string AV72TFAgenciaBancoNome_Sel ,
                                       int AV44TFAgenciaNumero ,
                                       int AV45TFAgenciaNumero_To ,
                                       int AV46TFAgenciaDigito ,
                                       int AV47TFAgenciaDigito_To ,
                                       short AV48TFAgenciaStatus_Sel ,
                                       DateTime AV51TFAgenciaCreatedAt ,
                                       DateTime AV52TFAgenciaCreatedAt_To ,
                                       DateTime AV58TFAgenciaUpdatedAt ,
                                       DateTime AV59TFAgenciaUpdatedAt_To ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV35DynamicFiltersIgnoreFirst ,
                                       bool AV34DynamicFiltersRemoving )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF9J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AGENCIAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "AGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", "")));
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
            AV17DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV17DynamicFiltersSelector1);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
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
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV73Pgmname = "AgenciaWW";
      }

      protected void RF9J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 110;
         /* Execute user event: Refresh */
         E269J2 ();
         nGXsfl_110_idx = 1;
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         bGXsfl_110_Refreshing = true;
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
            SubsflControlProps_1102( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV74Agenciawwds_1_filterfulltext ,
                                                 AV75Agenciawwds_2_dynamicfiltersselector1 ,
                                                 AV76Agenciawwds_3_dynamicfiltersoperator1 ,
                                                 AV77Agenciawwds_4_agencianumero1 ,
                                                 AV78Agenciawwds_5_dynamicfiltersenabled2 ,
                                                 AV79Agenciawwds_6_dynamicfiltersselector2 ,
                                                 AV80Agenciawwds_7_dynamicfiltersoperator2 ,
                                                 AV81Agenciawwds_8_agencianumero2 ,
                                                 AV82Agenciawwds_9_dynamicfiltersenabled3 ,
                                                 AV83Agenciawwds_10_dynamicfiltersselector3 ,
                                                 AV84Agenciawwds_11_dynamicfiltersoperator3 ,
                                                 AV85Agenciawwds_12_agencianumero3 ,
                                                 AV87Agenciawwds_14_tfagenciabanconome_sel ,
                                                 AV86Agenciawwds_13_tfagenciabanconome ,
                                                 AV88Agenciawwds_15_tfagencianumero ,
                                                 AV89Agenciawwds_16_tfagencianumero_to ,
                                                 AV90Agenciawwds_17_tfagenciadigito ,
                                                 AV91Agenciawwds_18_tfagenciadigito_to ,
                                                 AV92Agenciawwds_19_tfagenciastatus_sel ,
                                                 AV93Agenciawwds_20_tfagenciacreatedat ,
                                                 AV94Agenciawwds_21_tfagenciacreatedat_to ,
                                                 AV95Agenciawwds_22_tfagenciaupdatedat ,
                                                 AV96Agenciawwds_23_tfagenciaupdatedat_to ,
                                                 AV7BancoId ,
                                                 A969AgenciaBancoNome ,
                                                 A939AgenciaNumero ,
                                                 A945AgenciaDigito ,
                                                 A940AgenciaStatus ,
                                                 A941AgenciaCreatedAt ,
                                                 A942AgenciaUpdatedAt ,
                                                 A968AgenciaBancoId ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
            lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
            lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
            lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
            lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
            lV86Agenciawwds_13_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV86Agenciawwds_13_tfagenciabanconome), "%", "");
            /* Using cursor H009J2 */
            pr_default.execute(0, new Object[] {lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, AV77Agenciawwds_4_agencianumero1, AV77Agenciawwds_4_agencianumero1, AV77Agenciawwds_4_agencianumero1, AV81Agenciawwds_8_agencianumero2, AV81Agenciawwds_8_agencianumero2, AV81Agenciawwds_8_agencianumero2, AV85Agenciawwds_12_agencianumero3, AV85Agenciawwds_12_agencianumero3, AV85Agenciawwds_12_agencianumero3, lV86Agenciawwds_13_tfagenciabanconome, AV87Agenciawwds_14_tfagenciabanconome_sel, AV88Agenciawwds_15_tfagencianumero, AV89Agenciawwds_16_tfagencianumero_to, AV90Agenciawwds_17_tfagenciadigito, AV91Agenciawwds_18_tfagenciadigito_to, AV93Agenciawwds_20_tfagenciacreatedat, AV94Agenciawwds_21_tfagenciacreatedat_to, AV95Agenciawwds_22_tfagenciaupdatedat, AV96Agenciawwds_23_tfagenciaupdatedat_to, AV7BancoId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_110_idx = 1;
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A968AgenciaBancoId = H009J2_A968AgenciaBancoId[0];
               n968AgenciaBancoId = H009J2_n968AgenciaBancoId[0];
               A942AgenciaUpdatedAt = H009J2_A942AgenciaUpdatedAt[0];
               n942AgenciaUpdatedAt = H009J2_n942AgenciaUpdatedAt[0];
               A941AgenciaCreatedAt = H009J2_A941AgenciaCreatedAt[0];
               n941AgenciaCreatedAt = H009J2_n941AgenciaCreatedAt[0];
               A940AgenciaStatus = H009J2_A940AgenciaStatus[0];
               n940AgenciaStatus = H009J2_n940AgenciaStatus[0];
               A945AgenciaDigito = H009J2_A945AgenciaDigito[0];
               n945AgenciaDigito = H009J2_n945AgenciaDigito[0];
               A939AgenciaNumero = H009J2_A939AgenciaNumero[0];
               n939AgenciaNumero = H009J2_n939AgenciaNumero[0];
               A969AgenciaBancoNome = H009J2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009J2_n969AgenciaBancoNome[0];
               A938AgenciaId = H009J2_A938AgenciaId[0];
               A969AgenciaBancoNome = H009J2_A969AgenciaBancoNome[0];
               n969AgenciaBancoNome = H009J2_n969AgenciaBancoNome[0];
               /* Execute user event: Grid.Load */
               E279J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 110;
            WB9J0( ) ;
         }
         bGXsfl_110_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV73Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV73Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_AGENCIAID"+"_"+sGXsfl_110_idx, GetSecureSignedToken( sGXsfl_110_idx, context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9"), context));
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
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV74Agenciawwds_1_filterfulltext ,
                                              AV75Agenciawwds_2_dynamicfiltersselector1 ,
                                              AV76Agenciawwds_3_dynamicfiltersoperator1 ,
                                              AV77Agenciawwds_4_agencianumero1 ,
                                              AV78Agenciawwds_5_dynamicfiltersenabled2 ,
                                              AV79Agenciawwds_6_dynamicfiltersselector2 ,
                                              AV80Agenciawwds_7_dynamicfiltersoperator2 ,
                                              AV81Agenciawwds_8_agencianumero2 ,
                                              AV82Agenciawwds_9_dynamicfiltersenabled3 ,
                                              AV83Agenciawwds_10_dynamicfiltersselector3 ,
                                              AV84Agenciawwds_11_dynamicfiltersoperator3 ,
                                              AV85Agenciawwds_12_agencianumero3 ,
                                              AV87Agenciawwds_14_tfagenciabanconome_sel ,
                                              AV86Agenciawwds_13_tfagenciabanconome ,
                                              AV88Agenciawwds_15_tfagencianumero ,
                                              AV89Agenciawwds_16_tfagencianumero_to ,
                                              AV90Agenciawwds_17_tfagenciadigito ,
                                              AV91Agenciawwds_18_tfagenciadigito_to ,
                                              AV92Agenciawwds_19_tfagenciastatus_sel ,
                                              AV93Agenciawwds_20_tfagenciacreatedat ,
                                              AV94Agenciawwds_21_tfagenciacreatedat_to ,
                                              AV95Agenciawwds_22_tfagenciaupdatedat ,
                                              AV96Agenciawwds_23_tfagenciaupdatedat_to ,
                                              AV7BancoId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A945AgenciaDigito ,
                                              A940AgenciaStatus ,
                                              A941AgenciaCreatedAt ,
                                              A942AgenciaUpdatedAt ,
                                              A968AgenciaBancoId ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
         lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
         lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
         lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
         lV74Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext), "%", "");
         lV86Agenciawwds_13_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV86Agenciawwds_13_tfagenciabanconome), "%", "");
         /* Using cursor H009J3 */
         pr_default.execute(1, new Object[] {lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, lV74Agenciawwds_1_filterfulltext, AV77Agenciawwds_4_agencianumero1, AV77Agenciawwds_4_agencianumero1, AV77Agenciawwds_4_agencianumero1, AV81Agenciawwds_8_agencianumero2, AV81Agenciawwds_8_agencianumero2, AV81Agenciawwds_8_agencianumero2, AV85Agenciawwds_12_agencianumero3, AV85Agenciawwds_12_agencianumero3, AV85Agenciawwds_12_agencianumero3, lV86Agenciawwds_13_tfagenciabanconome, AV87Agenciawwds_14_tfagenciabanconome_sel, AV88Agenciawwds_15_tfagencianumero, AV89Agenciawwds_16_tfagencianumero_to, AV90Agenciawwds_17_tfagenciadigito, AV91Agenciawwds_18_tfagenciadigito_to, AV93Agenciawwds_20_tfagenciacreatedat, AV94Agenciawwds_21_tfagenciacreatedat_to, AV95Agenciawwds_22_tfagenciaupdatedat, AV96Agenciawwds_23_tfagenciaupdatedat_to, AV7BancoId});
         GRID_nRecordCount = H009J3_AGRID_nRecordCount[0];
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
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV73Pgmname = "AgenciaWW";
         edtAgenciaId_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtAgenciaDigito_Enabled = 0;
         cmbAgenciaStatus.Enabled = 0;
         edtAgenciaCreatedAt_Enabled = 0;
         edtAgenciaUpdatedAt_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E259J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV39ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV63DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_110 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_110"), ",", "."), 18, MidpointRounding.ToEven));
            AV65GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV66GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV67GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV53DDO_AgenciaCreatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AGENCIACREATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV53DDO_AgenciaCreatedAtAuxDate", context.localUtil.Format(AV53DDO_AgenciaCreatedAtAuxDate, "99/99/99"));
            AV54DDO_AgenciaCreatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AGENCIACREATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV54DDO_AgenciaCreatedAtAuxDateTo", context.localUtil.Format(AV54DDO_AgenciaCreatedAtAuxDateTo, "99/99/99"));
            AV60DDO_AgenciaUpdatedAtAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AGENCIAUPDATEDATAUXDATE"), 0);
            AssignAttri("", false, "AV60DDO_AgenciaUpdatedAtAuxDate", context.localUtil.Format(AV60DDO_AgenciaUpdatedAtAuxDate, "99/99/99"));
            AV61DDO_AgenciaUpdatedAtAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AGENCIAUPDATEDATAUXDATETO"), 0);
            AssignAttri("", false, "AV61DDO_AgenciaUpdatedAtAuxDateTo", context.localUtil.Format(AV61DDO_AgenciaUpdatedAtAuxDateTo, "99/99/99"));
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
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
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
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV17DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO1");
               GX_FocusControl = edtavAgencianumero1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19AgenciaNumero1 = 0;
               AssignAttri("", false, "AV19AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV19AgenciaNumero1), 9, 0));
            }
            else
            {
               AV19AgenciaNumero1 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV19AgenciaNumero1), 9, 0));
            }
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO2");
               GX_FocusControl = edtavAgencianumero2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25AgenciaNumero2 = 0;
               AssignAttri("", false, "AV25AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV25AgenciaNumero2), 9, 0));
            }
            else
            {
               AV25AgenciaNumero2 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV25AgenciaNumero2), 9, 0));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV29DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAGENCIANUMERO3");
               GX_FocusControl = edtavAgencianumero3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31AgenciaNumero3 = 0;
               AssignAttri("", false, "AV31AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV31AgenciaNumero3), 9, 0));
            }
            else
            {
               AV31AgenciaNumero3 = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavAgencianumero3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV31AgenciaNumero3), 9, 0));
            }
            AV55DDO_AgenciaCreatedAtAuxDateText = cgiGet( edtavDdo_agenciacreatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV55DDO_AgenciaCreatedAtAuxDateText", AV55DDO_AgenciaCreatedAtAuxDateText);
            AV62DDO_AgenciaUpdatedAtAuxDateText = cgiGet( edtavDdo_agenciaupdatedatauxdatetext_Internalname);
            AssignAttri("", false, "AV62DDO_AgenciaUpdatedAtAuxDateText", AV62DDO_AgenciaUpdatedAtAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO1"), ",", ".") != Convert.ToDecimal( AV19AgenciaNumero1 )) )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO2"), ",", ".") != Convert.ToDecimal( AV25AgenciaNumero2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV29DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV30DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vAGENCIANUMERO3"), ",", ".") != Convert.ToDecimal( AV31AgenciaNumero3 )) )
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
         E259J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E259J2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFAGENCIAUPDATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_agenciaupdatedatauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFAGENCIACREATEDAT_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_agenciacreatedatauxdatetext_Internalname});
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
         AV17DynamicFiltersSelector1 = "AGENCIANUMERO";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "AGENCIANUMERO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector3 = "AGENCIANUMERO";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
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
         Form.Caption = " Lista de agências";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV63DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV63DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E269J2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
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
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV65GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV65GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV65GridCurrentPage), 10, 0));
         AV66GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV66GridPageCount", StringUtil.LTrimStr( (decimal)(AV66GridPageCount), 10, 0));
         GXt_char2 = AV67GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV73Pgmname, out  GXt_char2) ;
         AV67GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV67GridAppliedFilters", AV67GridAppliedFilters);
         cmbAgenciaStatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbAgenciaStatus_Internalname, "Columnheaderclass", cmbAgenciaStatus_Columnheaderclass, !bGXsfl_110_Refreshing);
         AV74Agenciawwds_1_filterfulltext = AV16FilterFullText;
         AV75Agenciawwds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV76Agenciawwds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV77Agenciawwds_4_agencianumero1 = AV19AgenciaNumero1;
         AV78Agenciawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Agenciawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Agenciawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Agenciawwds_8_agencianumero2 = AV25AgenciaNumero2;
         AV82Agenciawwds_9_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV83Agenciawwds_10_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV84Agenciawwds_11_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV85Agenciawwds_12_agencianumero3 = AV31AgenciaNumero3;
         AV86Agenciawwds_13_tfagenciabanconome = AV71TFAgenciaBancoNome;
         AV87Agenciawwds_14_tfagenciabanconome_sel = AV72TFAgenciaBancoNome_Sel;
         AV88Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV89Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV90Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV91Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV92Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV93Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV94Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV95Agenciawwds_22_tfagenciaupdatedat = AV58TFAgenciaUpdatedAt;
         AV96Agenciawwds_23_tfagenciaupdatedat_to = AV59TFAgenciaUpdatedAt_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E129J2( )
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
            AV64PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV64PageToGo) ;
         }
      }

      protected void E139J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E149J2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaBancoNome") == 0 )
            {
               AV71TFAgenciaBancoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV71TFAgenciaBancoNome", AV71TFAgenciaBancoNome);
               AV72TFAgenciaBancoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV72TFAgenciaBancoNome_Sel", AV72TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaNumero") == 0 )
            {
               AV44TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV44TFAgenciaNumero), 9, 0));
               AV45TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV45TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaDigito") == 0 )
            {
               AV46TFAgenciaDigito = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFAgenciaDigito", StringUtil.LTrimStr( (decimal)(AV46TFAgenciaDigito), 9, 0));
               AV47TFAgenciaDigito_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAgenciaDigito_To", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaDigito_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaStatus") == 0 )
            {
               AV48TFAgenciaStatus_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAgenciaStatus_Sel", StringUtil.Str( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaCreatedAt") == 0 )
            {
               AV51TFAgenciaCreatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV51TFAgenciaCreatedAt", context.localUtil.TToC( AV51TFAgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV52TFAgenciaCreatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV52TFAgenciaCreatedAt_To", context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV52TFAgenciaCreatedAt_To) )
               {
                  AV52TFAgenciaCreatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV52TFAgenciaCreatedAt_To)), (short)(DateTimeUtil.Month( AV52TFAgenciaCreatedAt_To)), (short)(DateTimeUtil.Day( AV52TFAgenciaCreatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV52TFAgenciaCreatedAt_To", context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AgenciaUpdatedAt") == 0 )
            {
               AV58TFAgenciaUpdatedAt = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV58TFAgenciaUpdatedAt", context.localUtil.TToC( AV58TFAgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV59TFAgenciaUpdatedAt_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV59TFAgenciaUpdatedAt_To", context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV59TFAgenciaUpdatedAt_To) )
               {
                  AV59TFAgenciaUpdatedAt_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV59TFAgenciaUpdatedAt_To)), (short)(DateTimeUtil.Month( AV59TFAgenciaUpdatedAt_To)), (short)(DateTimeUtil.Day( AV59TFAgenciaUpdatedAt_To)), 23, 59, 59);
                  AssignAttri("", false, "AV59TFAgenciaUpdatedAt_To", context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               }
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E279J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactiongroup1.removeAllItems();
         cmbavGridactiongroup1.addItem("0", ";fas fa-bars", 0);
         cmbavGridactiongroup1.addItem("1", StringUtil.Format( "%1;%2", "Modifica", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         cmbavGridactiongroup1.addItem("2", StringUtil.Format( "%1;%2", "Conta", "fas fa-money-check", "", "", "", "", "", "", ""), 0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A938AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         edtAgenciaNumero_Link = formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "true") == 0 )
         {
            cmbAgenciaStatus_Columnclass = "WWColumn WWColumnSuccess WWColumnSuccessSingleCell";
         }
         else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "false") == 0 )
         {
            cmbAgenciaStatus_Columnclass = "WWColumn WWColumnDanger WWColumnDangerSingleCell";
         }
         else
         {
            cmbAgenciaStatus_Columnclass = "WWColumn";
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 110;
         }
         sendrow_1102( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_110_Refreshing )
         {
            DoAjaxLoad(110, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0));
      }

      protected void E209J2( )
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

      protected void E159J2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV34DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         AV35DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV35DynamicFiltersIgnoreFirst", AV35DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV34DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         AV35DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV35DynamicFiltersIgnoreFirst", AV35DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E219J2( )
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

      protected void E229J2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E169J2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV34DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV34DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E239J2( )
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

      protected void E179J2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV34DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV34DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV34DynamicFiltersRemoving", AV34DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19AgenciaNumero1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25AgenciaNumero2, AV29DynamicFiltersSelector3, AV30DynamicFiltersOperator3, AV31AgenciaNumero3, AV7BancoId, AV41ManageFiltersExecutionStep, AV73Pgmname, AV22DynamicFiltersEnabled2, AV28DynamicFiltersEnabled3, AV71TFAgenciaBancoNome, AV72TFAgenciaBancoNome_Sel, AV44TFAgenciaNumero, AV45TFAgenciaNumero_To, AV46TFAgenciaDigito, AV47TFAgenciaDigito_To, AV48TFAgenciaStatus_Sel, AV51TFAgenciaCreatedAt, AV52TFAgenciaCreatedAt_To, AV58TFAgenciaUpdatedAt, AV59TFAgenciaUpdatedAt_To, AV11GridState, AV35DynamicFiltersIgnoreFirst, AV34DynamicFiltersRemoving) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E249J2( )
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

      protected void E119J2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S232 ();
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
            S192 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("AgenciaWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV73Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("AgenciaWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV41ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV41ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV41ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV40ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "AgenciaWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV40ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV40ManageFiltersXml) ;
               AV11GridState.FromXml(AV40ManageFiltersXml, null, "", "");
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
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S222 ();
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
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
      }

      protected void E289J2( )
      {
         /* Gridactiongroup1_Click Routine */
         returnInSub = false;
         if ( AV70GridActionGroup1 == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV70GridActionGroup1 == 2 )
         {
            /* Execute user subroutine: 'DO CONTA' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV70GridActionGroup1 = 0;
         AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActionGroup1), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0));
         AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", cmbavGridactiongroup1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E189J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         context.PopUp(formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39ManageFiltersData", AV39ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E199J2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new agenciawwexport(context ).execute( out  AV36ExcelFilename, out  AV37ErrorMessage) ;
         if ( StringUtil.StrCmp(AV36ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV36ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV37ErrorMessage);
         }
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( ! (0==AV7BancoId) ) )
         {
            bttBtn_cancel_Visible = 0;
            AssignProp("", false, bttBtn_cancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_cancel_Visible), 5, 0), true);
         }
         if ( ! ( ! (0==AV7BancoId) ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavAgencianumero1_Visible = 0;
         AssignProp("", false, edtavAgencianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero1_Visible = 1;
            AssignProp("", false, edtavAgencianumero1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavAgencianumero2_Visible = 0;
         AssignProp("", false, edtavAgencianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero2_Visible = 1;
            AssignProp("", false, edtavAgencianumero2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavAgencianumero3_Visible = 0;
         AssignProp("", false, edtavAgencianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
         {
            edtavAgencianumero3_Visible = 1;
            AssignProp("", false, edtavAgencianumero3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAgencianumero3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "AGENCIANUMERO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25AgenciaNumero2 = 0;
         AssignAttri("", false, "AV25AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV25AgenciaNumero2), 9, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
         AV29DynamicFiltersSelector3 = "AGENCIANUMERO";
         AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         AV30DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         AV31AgenciaNumero3 = 0;
         AssignAttri("", false, "AV31AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV31AgenciaNumero3), 9, 0));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "AgenciaWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV39ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S232( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV71TFAgenciaBancoNome = "";
         AssignAttri("", false, "AV71TFAgenciaBancoNome", AV71TFAgenciaBancoNome);
         AV72TFAgenciaBancoNome_Sel = "";
         AssignAttri("", false, "AV72TFAgenciaBancoNome_Sel", AV72TFAgenciaBancoNome_Sel);
         AV44TFAgenciaNumero = 0;
         AssignAttri("", false, "AV44TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV44TFAgenciaNumero), 9, 0));
         AV45TFAgenciaNumero_To = 0;
         AssignAttri("", false, "AV45TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV45TFAgenciaNumero_To), 9, 0));
         AV46TFAgenciaDigito = 0;
         AssignAttri("", false, "AV46TFAgenciaDigito", StringUtil.LTrimStr( (decimal)(AV46TFAgenciaDigito), 9, 0));
         AV47TFAgenciaDigito_To = 0;
         AssignAttri("", false, "AV47TFAgenciaDigito_To", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaDigito_To), 9, 0));
         AV48TFAgenciaStatus_Sel = 0;
         AssignAttri("", false, "AV48TFAgenciaStatus_Sel", StringUtil.Str( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0));
         AV51TFAgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV51TFAgenciaCreatedAt", context.localUtil.TToC( AV51TFAgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV52TFAgenciaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV52TFAgenciaCreatedAt_To", context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         AV58TFAgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV58TFAgenciaUpdatedAt", context.localUtil.TToC( AV58TFAgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         AV59TFAgenciaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV59TFAgenciaUpdatedAt_To", context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV17DynamicFiltersSelector1 = "AGENCIANUMERO";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19AgenciaNumero1 = 0;
         AssignAttri("", false, "AV19AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV19AgenciaNumero1), 9, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S252( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "agencia"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A938AgenciaId,9,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BancoId,9,0));
         context.PopUp(formatLink("agencia") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         context.DoAjaxRefresh();
      }

      protected void S262( )
      {
         /* 'DO CONTA' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "contabancariaww"+UrlEncode(StringUtil.LTrimStr(A938AgenciaId,9,0));
         CallWebObject(formatLink("contabancariaww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get(AV73Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV73Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV38Session.Get(AV73Pgmname+"GridState"), null, "", "");
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
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
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

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV71TFAgenciaBancoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFAgenciaBancoNome", AV71TFAgenciaBancoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV72TFAgenciaBancoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFAgenciaBancoNome_Sel", AV72TFAgenciaBancoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV44TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44TFAgenciaNumero", StringUtil.LTrimStr( (decimal)(AV44TFAgenciaNumero), 9, 0));
               AV45TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV45TFAgenciaNumero_To", StringUtil.LTrimStr( (decimal)(AV45TFAgenciaNumero_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIADIGITO") == 0 )
            {
               AV46TFAgenciaDigito = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFAgenciaDigito", StringUtil.LTrimStr( (decimal)(AV46TFAgenciaDigito), 9, 0));
               AV47TFAgenciaDigito_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFAgenciaDigito_To", StringUtil.LTrimStr( (decimal)(AV47TFAgenciaDigito_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIASTATUS_SEL") == 0 )
            {
               AV48TFAgenciaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFAgenciaStatus_Sel", StringUtil.Str( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIACREATEDAT") == 0 )
            {
               AV51TFAgenciaCreatedAt = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV51TFAgenciaCreatedAt", context.localUtil.TToC( AV51TFAgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV52TFAgenciaCreatedAt_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV52TFAgenciaCreatedAt_To", context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV53DDO_AgenciaCreatedAtAuxDate = DateTimeUtil.ResetTime(AV51TFAgenciaCreatedAt);
               AssignAttri("", false, "AV53DDO_AgenciaCreatedAtAuxDate", context.localUtil.Format(AV53DDO_AgenciaCreatedAtAuxDate, "99/99/99"));
               AV54DDO_AgenciaCreatedAtAuxDateTo = DateTimeUtil.ResetTime(AV52TFAgenciaCreatedAt_To);
               AssignAttri("", false, "AV54DDO_AgenciaCreatedAtAuxDateTo", context.localUtil.Format(AV54DDO_AgenciaCreatedAtAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAGENCIAUPDATEDAT") == 0 )
            {
               AV58TFAgenciaUpdatedAt = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV58TFAgenciaUpdatedAt", context.localUtil.TToC( AV58TFAgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
               AV59TFAgenciaUpdatedAt_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV59TFAgenciaUpdatedAt_To", context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " "));
               AV60DDO_AgenciaUpdatedAtAuxDate = DateTimeUtil.ResetTime(AV58TFAgenciaUpdatedAt);
               AssignAttri("", false, "AV60DDO_AgenciaUpdatedAtAuxDate", context.localUtil.Format(AV60DDO_AgenciaUpdatedAtAuxDate, "99/99/99"));
               AV61DDO_AgenciaUpdatedAtAuxDateTo = DateTimeUtil.ResetTime(AV59TFAgenciaUpdatedAt_To);
               AssignAttri("", false, "AV61DDO_AgenciaUpdatedAtAuxDateTo", context.localUtil.Format(AV61DDO_AgenciaUpdatedAtAuxDateTo, "99/99/99"));
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFAgenciaBancoNome_Sel)),  AV72TFAgenciaBancoNome_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|||"+((0==AV48TFAgenciaStatus_Sel) ? "" : StringUtil.Str( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFAgenciaBancoNome)),  AV71TFAgenciaBancoNome, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"|"+((0==AV44TFAgenciaNumero) ? "" : StringUtil.Str( (decimal)(AV44TFAgenciaNumero), 9, 0))+"|"+((0==AV46TFAgenciaDigito) ? "" : StringUtil.Str( (decimal)(AV46TFAgenciaDigito), 9, 0))+"||"+((DateTime.MinValue==AV51TFAgenciaCreatedAt) ? "" : context.localUtil.DToC( AV53DDO_AgenciaCreatedAtAuxDate, 4, "/"))+"|"+((DateTime.MinValue==AV58TFAgenciaUpdatedAt) ? "" : context.localUtil.DToC( AV60DDO_AgenciaUpdatedAtAuxDate, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|"+((0==AV45TFAgenciaNumero_To) ? "" : StringUtil.Str( (decimal)(AV45TFAgenciaNumero_To), 9, 0))+"|"+((0==AV47TFAgenciaDigito_To) ? "" : StringUtil.Str( (decimal)(AV47TFAgenciaDigito_To), 9, 0))+"||"+((DateTime.MinValue==AV52TFAgenciaCreatedAt_To) ? "" : context.localUtil.DToC( AV54DDO_AgenciaCreatedAtAuxDateTo, 4, "/"))+"|"+((DateTime.MinValue==AV59TFAgenciaUpdatedAt_To) ? "" : context.localUtil.DToC( AV61DDO_AgenciaUpdatedAtAuxDateTo, 4, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
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
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19AgenciaNumero1", StringUtil.LTrimStr( (decimal)(AV19AgenciaNumero1), 9, 0));
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
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25AgenciaNumero2", StringUtil.LTrimStr( (decimal)(AV25AgenciaNumero2), 9, 0));
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
                  AV28DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV28DynamicFiltersEnabled3", AV28DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
                     AV31AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV31AgenciaNumero3", StringUtil.LTrimStr( (decimal)(AV31AgenciaNumero3), 9, 0));
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
         if ( AV34DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV38Session.Get(AV73Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAGENCIABANCONOME",  "Banco",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFAgenciaBancoNome)),  0,  AV71TFAgenciaBancoNome,  AV71TFAgenciaBancoNome,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFAgenciaBancoNome_Sel)),  AV72TFAgenciaBancoNome_Sel,  AV72TFAgenciaBancoNome_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIANUMERO",  "Número",  !((0==AV44TFAgenciaNumero)&&(0==AV45TFAgenciaNumero_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV44TFAgenciaNumero), 9, 0)),  ((0==AV44TFAgenciaNumero) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV44TFAgenciaNumero), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV45TFAgenciaNumero_To), 9, 0)),  ((0==AV45TFAgenciaNumero_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV45TFAgenciaNumero_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIADIGITO",  "Dígito",  !((0==AV46TFAgenciaDigito)&&(0==AV47TFAgenciaDigito_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFAgenciaDigito), 9, 0)),  ((0==AV46TFAgenciaDigito) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV46TFAgenciaDigito), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFAgenciaDigito_To), 9, 0)),  ((0==AV47TFAgenciaDigito_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV47TFAgenciaDigito_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIASTATUS_SEL",  "Status",  !(0==AV48TFAgenciaStatus_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFAgenciaStatus_Sel), 1, 0)),  ((AV48TFAgenciaStatus_Sel==1) ? "Marcado" : "Desmarcado"),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIACREATEDAT",  "Criado em",  !((DateTime.MinValue==AV51TFAgenciaCreatedAt)&&(DateTime.MinValue==AV52TFAgenciaCreatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV51TFAgenciaCreatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV51TFAgenciaCreatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV51TFAgenciaCreatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV52TFAgenciaCreatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV52TFAgenciaCreatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV52TFAgenciaCreatedAt_To, "99/99/99 99:99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAGENCIAUPDATEDAT",  "Atualizado em",  !((DateTime.MinValue==AV58TFAgenciaUpdatedAt)&&(DateTime.MinValue==AV59TFAgenciaUpdatedAt_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV58TFAgenciaUpdatedAt, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV58TFAgenciaUpdatedAt) ? "" : StringUtil.Trim( context.localUtil.Format( AV58TFAgenciaUpdatedAt, "99/99/99 99:99"))),  true,  StringUtil.Trim( context.localUtil.TToC( AV59TFAgenciaUpdatedAt_To, 8, 5, 0, 3, "/", ":", " ")),  ((DateTime.MinValue==AV59TFAgenciaUpdatedAt_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV59TFAgenciaUpdatedAt_To, "99/99/99 99:99")))) ;
         if ( ! (0==AV7BancoId) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&BANCOID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7BancoId), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV73Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV35DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV17DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "AGENCIANUMERO") == 0 ) && ! (0==AV19AgenciaNumero1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV18DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( (decimal)(AV19AgenciaNumero1), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19AgenciaNumero1), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19AgenciaNumero1), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV19AgenciaNumero1), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV34DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AGENCIANUMERO") == 0 ) && ! (0==AV25AgenciaNumero2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV24DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25AgenciaNumero2), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV25AgenciaNumero2), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV25AgenciaNumero2), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV25AgenciaNumero2), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV34DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "AGENCIANUMERO") == 0 ) && ! (0==AV31AgenciaNumero3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Agência",  AV30DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31AgenciaNumero3), 9, 0)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV31AgenciaNumero3), "ZZZZZZZZ9")), "="+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV31AgenciaNumero3), "ZZZZZZZZ9")), ">"+" "+StringUtil.Trim( context.localUtil.Format( (decimal)(AV31AgenciaNumero3), "ZZZZZZZZ9")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV34DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV73Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Agencia";
         AV38Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_92_9J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero3_Internalname, "Agencia Numero3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31AgenciaNumero3), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31AgenciaNumero3), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV31AgenciaNumero3), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero3_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero3_Visible, edtavAgencianumero3_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AgenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_92_9J2e( true) ;
         }
         else
         {
            wb_table3_92_9J2e( false) ;
         }
      }

      protected void wb_table2_70_9J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero2_Internalname, "Agencia Numero2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25AgenciaNumero2), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25AgenciaNumero2), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV25AgenciaNumero2), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero2_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero2_Visible, edtavAgencianumero2_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AgenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AgenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_70_9J2e( true) ;
         }
         else
         {
            wb_table2_70_9J2e( false) ;
         }
      }

      protected void wb_table1_48_9J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_110_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_AgenciaWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_agencianumero1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAgencianumero1_Internalname, "Agencia Numero1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_110_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAgencianumero1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19AgenciaNumero1), 9, 0, ",", "")), StringUtil.LTrim( ((edtavAgencianumero1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19AgenciaNumero1), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19AgenciaNumero1), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAgencianumero1_Jsonclick, 0, "Attribute", "", "", "", "", edtavAgencianumero1_Visible, edtavAgencianumero1_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AgenciaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AgenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_AgenciaWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_48_9J2e( true) ;
         }
         else
         {
            wb_table1_48_9J2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7BancoId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7BancoId", StringUtil.LTrimStr( (decimal)(AV7BancoId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BancoId), "ZZZZZZZZ9"), context));
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
         PA9J2( ) ;
         WS9J2( ) ;
         WE9J2( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101928328", true, true);
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
         context.AddJavascriptSource("agenciaww.js", "?20256101928328", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1102( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_110_idx;
         edtAgenciaId_Internalname = "AGENCIAID_"+sGXsfl_110_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_110_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_110_idx;
         edtAgenciaDigito_Internalname = "AGENCIADIGITO_"+sGXsfl_110_idx;
         cmbAgenciaStatus_Internalname = "AGENCIASTATUS_"+sGXsfl_110_idx;
         edtAgenciaCreatedAt_Internalname = "AGENCIACREATEDAT_"+sGXsfl_110_idx;
         edtAgenciaUpdatedAt_Internalname = "AGENCIAUPDATEDAT_"+sGXsfl_110_idx;
      }

      protected void SubsflControlProps_fel_1102( )
      {
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1_"+sGXsfl_110_fel_idx;
         edtAgenciaId_Internalname = "AGENCIAID_"+sGXsfl_110_fel_idx;
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME_"+sGXsfl_110_fel_idx;
         edtAgenciaNumero_Internalname = "AGENCIANUMERO_"+sGXsfl_110_fel_idx;
         edtAgenciaDigito_Internalname = "AGENCIADIGITO_"+sGXsfl_110_fel_idx;
         cmbAgenciaStatus_Internalname = "AGENCIASTATUS_"+sGXsfl_110_fel_idx;
         edtAgenciaCreatedAt_Internalname = "AGENCIACREATEDAT_"+sGXsfl_110_fel_idx;
         edtAgenciaUpdatedAt_Internalname = "AGENCIAUPDATEDAT_"+sGXsfl_110_fel_idx;
      }

      protected void sendrow_1102( )
      {
         sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
         SubsflControlProps_1102( ) ;
         WB9J0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_110_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_110_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_110_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_110_idx + "',110)\"";
            if ( ( cmbavGridactiongroup1.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_110_idx;
               cmbavGridactiongroup1.Name = GXCCtl;
               cmbavGridactiongroup1.WebTags = "";
               if ( cmbavGridactiongroup1.ItemCount > 0 )
               {
                  AV70GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActionGroup1), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactiongroup1,(string)cmbavGridactiongroup1_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0)),(short)1,(string)cmbavGridactiongroup1_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONGROUP1.CLICK."+sGXsfl_110_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"",(string)"",(bool)true,(short)0});
            cmbavGridactiongroup1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0));
            AssignProp("", false, cmbavGridactiongroup1_Internalname, "Values", (string)(cmbavGridactiongroup1.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A938AgenciaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaBancoNome_Internalname,(string)A969AgenciaBancoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaBancoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaNumero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A939AgenciaNumero), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAgenciaNumero_Link,(string)"",(string)"",(string)"",(string)edtAgenciaNumero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaDigito_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A945AgenciaDigito), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaDigito_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbAgenciaStatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "AGENCIASTATUS_" + sGXsfl_110_idx;
               cmbAgenciaStatus.Name = GXCCtl;
               cmbAgenciaStatus.WebTags = "";
               cmbAgenciaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
               cmbAgenciaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
               if ( cmbAgenciaStatus.ItemCount > 0 )
               {
                  A940AgenciaStatus = StringUtil.StrToBool( cmbAgenciaStatus.getValidValue(StringUtil.BoolToStr( A940AgenciaStatus)));
                  n940AgenciaStatus = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbAgenciaStatus,(string)cmbAgenciaStatus_Internalname,StringUtil.BoolToStr( A940AgenciaStatus),(short)1,(string)cmbAgenciaStatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbAgenciaStatus_Columnclass,(string)cmbAgenciaStatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbAgenciaStatus.CurrentValue = StringUtil.BoolToStr( A940AgenciaStatus);
            AssignProp("", false, cmbAgenciaStatus_Internalname, "Values", (string)(cmbAgenciaStatus.ToJavascriptSource()), !bGXsfl_110_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaCreatedAt_Internalname,context.localUtil.TToC( A941AgenciaCreatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A941AgenciaCreatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaCreatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAgenciaUpdatedAt_Internalname,context.localUtil.TToC( A942AgenciaUpdatedAt, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A942AgenciaUpdatedAt, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAgenciaUpdatedAt_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)110,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_110_idx = ((subGrid_Islastpage==1)&&(nGXsfl_110_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_110_idx+1);
            sGXsfl_110_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_110_idx), 4, 0), 4, "0");
            SubsflControlProps_1102( ) ;
         }
         /* End function sendrow_1102 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("AGENCIANUMERO", "Agência", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV17DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV17DynamicFiltersSelector1);
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("AGENCIANUMERO", "Agência", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("AGENCIANUMERO", "Agência", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV29DynamicFiltersSelector3);
            AssignAttri("", false, "AV29DynamicFiltersSelector3", AV29DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONGROUP1_" + sGXsfl_110_idx;
         cmbavGridactiongroup1.Name = GXCCtl;
         cmbavGridactiongroup1.WebTags = "";
         if ( cmbavGridactiongroup1.ItemCount > 0 )
         {
            AV70GridActionGroup1 = (short)(Math.Round(NumberUtil.Val( cmbavGridactiongroup1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActionGroup1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactiongroup1_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActionGroup1), 4, 0));
         }
         GXCCtl = "AGENCIASTATUS_" + sGXsfl_110_idx;
         cmbAgenciaStatus.Name = GXCCtl;
         cmbAgenciaStatus.WebTags = "";
         cmbAgenciaStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbAgenciaStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbAgenciaStatus.ItemCount > 0 )
         {
            A940AgenciaStatus = StringUtil.StrToBool( cmbAgenciaStatus.getValidValue(StringUtil.BoolToStr( A940AgenciaStatus)));
            n940AgenciaStatus = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl110( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"110\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Banco") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Dígito") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Criado em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Atualizado em") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridActionGroup1), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A969AgenciaBancoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAgenciaNumero_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A945AgenciaDigito), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A940AgenciaStatus)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbAgenciaStatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbAgenciaStatus_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A941AgenciaCreatedAt, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A942AgenciaUpdatedAt, 10, 8, 0, 3, "/", ":", " ")));
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
         bttBtn_cancel_Internalname = "BTN_CANCEL";
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
         edtavAgencianumero1_Internalname = "vAGENCIANUMERO1";
         cellFilter_agencianumero1_cell_Internalname = "FILTER_AGENCIANUMERO1_CELL";
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
         edtavAgencianumero2_Internalname = "vAGENCIANUMERO2";
         cellFilter_agencianumero2_cell_Internalname = "FILTER_AGENCIANUMERO2_CELL";
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
         edtavAgencianumero3_Internalname = "vAGENCIANUMERO3";
         cellFilter_agencianumero3_cell_Internalname = "FILTER_AGENCIANUMERO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         cmbavGridactiongroup1_Internalname = "vGRIDACTIONGROUP1";
         edtAgenciaId_Internalname = "AGENCIAID";
         edtAgenciaBancoNome_Internalname = "AGENCIABANCONOME";
         edtAgenciaNumero_Internalname = "AGENCIANUMERO";
         edtAgenciaDigito_Internalname = "AGENCIADIGITO";
         cmbAgenciaStatus_Internalname = "AGENCIASTATUS";
         edtAgenciaCreatedAt_Internalname = "AGENCIACREATEDAT";
         edtAgenciaUpdatedAt_Internalname = "AGENCIAUPDATEDAT";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_agenciacreatedatauxdatetext_Internalname = "vDDO_AGENCIACREATEDATAUXDATETEXT";
         Tfagenciacreatedat_rangepicker_Internalname = "TFAGENCIACREATEDAT_RANGEPICKER";
         divDdo_agenciacreatedatauxdates_Internalname = "DDO_AGENCIACREATEDATAUXDATES";
         edtavDdo_agenciaupdatedatauxdatetext_Internalname = "vDDO_AGENCIAUPDATEDATAUXDATETEXT";
         Tfagenciaupdatedat_rangepicker_Internalname = "TFAGENCIAUPDATEDAT_RANGEPICKER";
         divDdo_agenciaupdatedatauxdates_Internalname = "DDO_AGENCIAUPDATEDATAUXDATES";
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
         edtAgenciaUpdatedAt_Jsonclick = "";
         edtAgenciaCreatedAt_Jsonclick = "";
         cmbAgenciaStatus_Jsonclick = "";
         cmbAgenciaStatus_Columnclass = "WWColumn";
         edtAgenciaDigito_Jsonclick = "";
         edtAgenciaNumero_Jsonclick = "";
         edtAgenciaNumero_Link = "";
         edtAgenciaBancoNome_Jsonclick = "";
         edtAgenciaId_Jsonclick = "";
         cmbavGridactiongroup1_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavAgencianumero1_Jsonclick = "";
         edtavAgencianumero1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavAgencianumero2_Jsonclick = "";
         edtavAgencianumero2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavAgencianumero3_Jsonclick = "";
         edtavAgencianumero3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavAgencianumero3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavAgencianumero2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavAgencianumero1_Visible = 1;
         cmbAgenciaStatus_Columnheaderclass = "";
         edtAgenciaUpdatedAt_Enabled = 0;
         edtAgenciaCreatedAt_Enabled = 0;
         cmbAgenciaStatus.Enabled = 0;
         edtAgenciaDigito_Enabled = 0;
         edtAgenciaNumero_Enabled = 0;
         edtAgenciaBancoNome_Enabled = 0;
         edtAgenciaId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_agenciaupdatedatauxdatetext_Jsonclick = "";
         edtavDdo_agenciacreatedatauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         bttBtninsert_Visible = 1;
         bttBtn_cancel_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|9.0|9.0|||";
         Ddo_grid_Datalistproc = "AgenciaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||1:WWP_TSChecked,2:WWP_TSUnChecked||";
         Ddo_grid_Datalisttype = "Dynamic|||FixedValues||";
         Ddo_grid_Includedatalist = "T|||T||";
         Ddo_grid_Filterisrange = "|T|T||P|P";
         Ddo_grid_Filtertype = "Character|Numeric|Numeric||Date|Date";
         Ddo_grid_Includefilter = "T|T|T||T|T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6";
         Ddo_grid_Columnids = "2:AgenciaBancoNome|3:AgenciaNumero|4:AgenciaDigito|5:AgenciaStatus|6:AgenciaCreatedAt|7:AgenciaUpdatedAt";
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
         Form.Caption = " Lista de agências";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E129J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E139J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E149J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E279J2","iparms":[{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"cmbAgenciaStatus"},{"av":"A940AgenciaStatus","fld":"AGENCIASTATUS","type":"boolean"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV70GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"edtAgenciaNumero_Link","ctrl":"AGENCIANUMERO","prop":"Link"},{"av":"cmbAgenciaStatus"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E209J2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E159J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E219J2","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E229J2","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E169J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E239J2","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E179J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E249J2","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E119J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV53DDO_AgenciaCreatedAtAuxDate","fld":"vDDO_AGENCIACREATEDATAUXDATE","type":"date"},{"av":"AV60DDO_AgenciaUpdatedAtAuxDate","fld":"vDDO_AGENCIAUPDATEDATAUXDATE","type":"date"},{"av":"AV54DDO_AgenciaCreatedAtAuxDateTo","fld":"vDDO_AGENCIACREATEDATAUXDATETO","type":"date"},{"av":"AV61DDO_AgenciaUpdatedAtAuxDateTo","fld":"vDDO_AGENCIAUPDATEDATAUXDATETO","type":"date"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV60DDO_AgenciaUpdatedAtAuxDate","fld":"vDDO_AGENCIAUPDATEDATAUXDATE","type":"date"},{"av":"AV61DDO_AgenciaUpdatedAtAuxDateTo","fld":"vDDO_AGENCIAUPDATEDATAUXDATETO","type":"date"},{"av":"AV53DDO_AgenciaCreatedAtAuxDate","fld":"vDDO_AGENCIACREATEDATAUXDATE","type":"date"},{"av":"AV54DDO_AgenciaCreatedAtAuxDateTo","fld":"vDDO_AGENCIACREATEDATAUXDATETO","type":"date"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"edtavAgencianumero1_Visible","ctrl":"vAGENCIANUMERO1","prop":"Visible"},{"av":"edtavAgencianumero2_Visible","ctrl":"vAGENCIANUMERO2","prop":"Visible"},{"av":"edtavAgencianumero3_Visible","ctrl":"vAGENCIANUMERO3","prop":"Visible"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK","""{"handler":"E289J2","iparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV70GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("VGRIDACTIONGROUP1.CLICK",""","oparms":[{"av":"cmbavGridactiongroup1"},{"av":"AV70GridActionGroup1","fld":"vGRIDACTIONGROUP1","pic":"ZZZ9","type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E189J2","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19AgenciaNumero1","fld":"vAGENCIANUMERO1","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV23DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV24DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV25AgenciaNumero2","fld":"vAGENCIANUMERO2","pic":"ZZZZZZZZ9","type":"int"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV29DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV30DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV31AgenciaNumero3","fld":"vAGENCIANUMERO3","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV7BancoId","fld":"vBANCOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV73Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV22DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV28DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV71TFAgenciaBancoNome","fld":"vTFAGENCIABANCONOME","type":"svchar"},{"av":"AV72TFAgenciaBancoNome_Sel","fld":"vTFAGENCIABANCONOME_SEL","type":"svchar"},{"av":"AV44TFAgenciaNumero","fld":"vTFAGENCIANUMERO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV45TFAgenciaNumero_To","fld":"vTFAGENCIANUMERO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV46TFAgenciaDigito","fld":"vTFAGENCIADIGITO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV47TFAgenciaDigito_To","fld":"vTFAGENCIADIGITO_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV48TFAgenciaStatus_Sel","fld":"vTFAGENCIASTATUS_SEL","pic":"9","type":"int"},{"av":"AV51TFAgenciaCreatedAt","fld":"vTFAGENCIACREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV52TFAgenciaCreatedAt_To","fld":"vTFAGENCIACREATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV58TFAgenciaUpdatedAt","fld":"vTFAGENCIAUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV59TFAgenciaUpdatedAt_To","fld":"vTFAGENCIAUPDATEDAT_TO","pic":"99/99/99 99:99","type":"dtime"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV35DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV34DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"A938AgenciaId","fld":"AGENCIAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]""");
         setEventMetadata("'DOINSERT'",""","oparms":[{"av":"AV41ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV65GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV66GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV67GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"cmbAgenciaStatus"},{"ctrl":"BTN_CANCEL","prop":"Visible"},{"ctrl":"BTNINSERT","prop":"Visible"},{"av":"AV39ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E199J2","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Agenciaupdatedat","iparms":[]}""");
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
         AV16FilterFullText = "";
         AV17DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV73Pgmname = "";
         AV71TFAgenciaBancoNome = "";
         AV72TFAgenciaBancoNome_Sel = "";
         AV51TFAgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         AV52TFAgenciaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV58TFAgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV59TFAgenciaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV39ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV67GridAppliedFilters = "";
         AV63DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV53DDO_AgenciaCreatedAtAuxDate = DateTime.MinValue;
         AV54DDO_AgenciaCreatedAtAuxDateTo = DateTime.MinValue;
         AV60DDO_AgenciaUpdatedAtAuxDate = DateTime.MinValue;
         AV61DDO_AgenciaUpdatedAtAuxDateTo = DateTime.MinValue;
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_cancel_Jsonclick = "";
         ucDvpanel_tableheader = new GXUserControl();
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
         AV55DDO_AgenciaCreatedAtAuxDateText = "";
         ucTfagenciacreatedat_rangepicker = new GXUserControl();
         AV62DDO_AgenciaUpdatedAtAuxDateText = "";
         ucTfagenciaupdatedat_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A969AgenciaBancoNome = "";
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         GXDecQS = "";
         lV74Agenciawwds_1_filterfulltext = "";
         lV86Agenciawwds_13_tfagenciabanconome = "";
         AV74Agenciawwds_1_filterfulltext = "";
         AV75Agenciawwds_2_dynamicfiltersselector1 = "";
         AV79Agenciawwds_6_dynamicfiltersselector2 = "";
         AV83Agenciawwds_10_dynamicfiltersselector3 = "";
         AV87Agenciawwds_14_tfagenciabanconome_sel = "";
         AV86Agenciawwds_13_tfagenciabanconome = "";
         AV93Agenciawwds_20_tfagenciacreatedat = (DateTime)(DateTime.MinValue);
         AV94Agenciawwds_21_tfagenciacreatedat_to = (DateTime)(DateTime.MinValue);
         AV95Agenciawwds_22_tfagenciaupdatedat = (DateTime)(DateTime.MinValue);
         AV96Agenciawwds_23_tfagenciaupdatedat_to = (DateTime)(DateTime.MinValue);
         H009J2_A968AgenciaBancoId = new int[1] ;
         H009J2_n968AgenciaBancoId = new bool[] {false} ;
         H009J2_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         H009J2_n942AgenciaUpdatedAt = new bool[] {false} ;
         H009J2_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         H009J2_n941AgenciaCreatedAt = new bool[] {false} ;
         H009J2_A940AgenciaStatus = new bool[] {false} ;
         H009J2_n940AgenciaStatus = new bool[] {false} ;
         H009J2_A945AgenciaDigito = new int[1] ;
         H009J2_n945AgenciaDigito = new bool[] {false} ;
         H009J2_A939AgenciaNumero = new int[1] ;
         H009J2_n939AgenciaNumero = new bool[] {false} ;
         H009J2_A969AgenciaBancoNome = new string[] {""} ;
         H009J2_n969AgenciaBancoNome = new bool[] {false} ;
         H009J2_A938AgenciaId = new int[1] ;
         H009J3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV40ManageFiltersXml = "";
         AV36ExcelFilename = "";
         AV37ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV38Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agenciaww__default(),
            new Object[][] {
                new Object[] {
               H009J2_A968AgenciaBancoId, H009J2_n968AgenciaBancoId, H009J2_A942AgenciaUpdatedAt, H009J2_n942AgenciaUpdatedAt, H009J2_A941AgenciaCreatedAt, H009J2_n941AgenciaCreatedAt, H009J2_A940AgenciaStatus, H009J2_n940AgenciaStatus, H009J2_A945AgenciaDigito, H009J2_n945AgenciaDigito,
               H009J2_A939AgenciaNumero, H009J2_n939AgenciaNumero, H009J2_A969AgenciaBancoNome, H009J2_n969AgenciaBancoNome, H009J2_A938AgenciaId
               }
               , new Object[] {
               H009J3_AGRID_nRecordCount
               }
            }
         );
         AV73Pgmname = "AgenciaWW";
         /* GeneXus formulas. */
         AV73Pgmname = "AgenciaWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV41ManageFiltersExecutionStep ;
      private short AV48TFAgenciaStatus_Sel ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV70GridActionGroup1 ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV76Agenciawwds_3_dynamicfiltersoperator1 ;
      private short AV80Agenciawwds_7_dynamicfiltersoperator2 ;
      private short AV84Agenciawwds_11_dynamicfiltersoperator3 ;
      private short AV92Agenciawwds_19_tfagenciastatus_sel ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV7BancoId ;
      private int wcpOAV7BancoId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_110 ;
      private int nGXsfl_110_idx=1 ;
      private int AV19AgenciaNumero1 ;
      private int AV25AgenciaNumero2 ;
      private int AV31AgenciaNumero3 ;
      private int AV44TFAgenciaNumero ;
      private int AV45TFAgenciaNumero_To ;
      private int AV46TFAgenciaDigito ;
      private int AV47TFAgenciaDigito_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtn_cancel_Visible ;
      private int bttBtninsert_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int A938AgenciaId ;
      private int A939AgenciaNumero ;
      private int A945AgenciaDigito ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV77Agenciawwds_4_agencianumero1 ;
      private int AV81Agenciawwds_8_agencianumero2 ;
      private int AV85Agenciawwds_12_agencianumero3 ;
      private int AV88Agenciawwds_15_tfagencianumero ;
      private int AV89Agenciawwds_16_tfagencianumero_to ;
      private int AV90Agenciawwds_17_tfagenciadigito ;
      private int AV91Agenciawwds_18_tfagenciadigito_to ;
      private int A968AgenciaBancoId ;
      private int edtAgenciaId_Enabled ;
      private int edtAgenciaBancoNome_Enabled ;
      private int edtAgenciaNumero_Enabled ;
      private int edtAgenciaDigito_Enabled ;
      private int edtAgenciaCreatedAt_Enabled ;
      private int edtAgenciaUpdatedAt_Enabled ;
      private int AV64PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavAgencianumero1_Visible ;
      private int edtavAgencianumero2_Visible ;
      private int edtavAgencianumero3_Visible ;
      private int AV97GXV1 ;
      private int edtavAgencianumero3_Enabled ;
      private int edtavAgencianumero2_Enabled ;
      private int edtavAgencianumero1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV65GridCurrentPage ;
      private long AV66GridPageCount ;
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
      private string sGXsfl_110_idx="0001" ;
      private string AV73Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string Dvpanel_tableheader_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
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
      private string divDdo_agenciacreatedatauxdates_Internalname ;
      private string edtavDdo_agenciacreatedatauxdatetext_Internalname ;
      private string edtavDdo_agenciacreatedatauxdatetext_Jsonclick ;
      private string Tfagenciacreatedat_rangepicker_Internalname ;
      private string divDdo_agenciaupdatedatauxdates_Internalname ;
      private string edtavDdo_agenciaupdatedatauxdatetext_Internalname ;
      private string edtavDdo_agenciaupdatedatauxdatetext_Jsonclick ;
      private string Tfagenciaupdatedat_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactiongroup1_Internalname ;
      private string edtAgenciaId_Internalname ;
      private string edtAgenciaBancoNome_Internalname ;
      private string edtAgenciaNumero_Internalname ;
      private string edtAgenciaDigito_Internalname ;
      private string cmbAgenciaStatus_Internalname ;
      private string edtAgenciaCreatedAt_Internalname ;
      private string edtAgenciaUpdatedAt_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavAgencianumero1_Internalname ;
      private string edtavAgencianumero2_Internalname ;
      private string edtavAgencianumero3_Internalname ;
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
      private string cmbAgenciaStatus_Columnheaderclass ;
      private string edtAgenciaNumero_Link ;
      private string cmbAgenciaStatus_Columnclass ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_agencianumero3_cell_Internalname ;
      private string edtavAgencianumero3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_agencianumero2_cell_Internalname ;
      private string edtavAgencianumero2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_agencianumero1_cell_Internalname ;
      private string edtavAgencianumero1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_110_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactiongroup1_Jsonclick ;
      private string ROClassString ;
      private string edtAgenciaId_Jsonclick ;
      private string edtAgenciaBancoNome_Jsonclick ;
      private string edtAgenciaNumero_Jsonclick ;
      private string edtAgenciaDigito_Jsonclick ;
      private string cmbAgenciaStatus_Jsonclick ;
      private string edtAgenciaCreatedAt_Jsonclick ;
      private string edtAgenciaUpdatedAt_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV51TFAgenciaCreatedAt ;
      private DateTime AV52TFAgenciaCreatedAt_To ;
      private DateTime AV58TFAgenciaUpdatedAt ;
      private DateTime AV59TFAgenciaUpdatedAt_To ;
      private DateTime A941AgenciaCreatedAt ;
      private DateTime A942AgenciaUpdatedAt ;
      private DateTime AV93Agenciawwds_20_tfagenciacreatedat ;
      private DateTime AV94Agenciawwds_21_tfagenciacreatedat_to ;
      private DateTime AV95Agenciawwds_22_tfagenciaupdatedat ;
      private DateTime AV96Agenciawwds_23_tfagenciaupdatedat_to ;
      private DateTime AV53DDO_AgenciaCreatedAtAuxDate ;
      private DateTime AV54DDO_AgenciaCreatedAtAuxDateTo ;
      private DateTime AV60DDO_AgenciaUpdatedAtAuxDate ;
      private DateTime AV61DDO_AgenciaUpdatedAtAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV35DynamicFiltersIgnoreFirst ;
      private bool AV34DynamicFiltersRemoving ;
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
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool n945AgenciaDigito ;
      private bool A940AgenciaStatus ;
      private bool n940AgenciaStatus ;
      private bool n941AgenciaCreatedAt ;
      private bool n942AgenciaUpdatedAt ;
      private bool bGXsfl_110_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV78Agenciawwds_5_dynamicfiltersenabled2 ;
      private bool AV82Agenciawwds_9_dynamicfiltersenabled3 ;
      private bool n968AgenciaBancoId ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV40ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV71TFAgenciaBancoNome ;
      private string AV72TFAgenciaBancoNome_Sel ;
      private string AV67GridAppliedFilters ;
      private string AV55DDO_AgenciaCreatedAtAuxDateText ;
      private string AV62DDO_AgenciaUpdatedAtAuxDateText ;
      private string A969AgenciaBancoNome ;
      private string lV74Agenciawwds_1_filterfulltext ;
      private string lV86Agenciawwds_13_tfagenciabanconome ;
      private string AV74Agenciawwds_1_filterfulltext ;
      private string AV75Agenciawwds_2_dynamicfiltersselector1 ;
      private string AV79Agenciawwds_6_dynamicfiltersselector2 ;
      private string AV83Agenciawwds_10_dynamicfiltersselector3 ;
      private string AV87Agenciawwds_14_tfagenciabanconome_sel ;
      private string AV86Agenciawwds_13_tfagenciabanconome ;
      private string AV36ExcelFilename ;
      private string AV37ErrorMessage ;
      private IGxSession AV38Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfagenciacreatedat_rangepicker ;
      private GXUserControl ucTfagenciaupdatedat_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactiongroup1 ;
      private GXCombobox cmbAgenciaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV39ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV63DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private int[] H009J2_A968AgenciaBancoId ;
      private bool[] H009J2_n968AgenciaBancoId ;
      private DateTime[] H009J2_A942AgenciaUpdatedAt ;
      private bool[] H009J2_n942AgenciaUpdatedAt ;
      private DateTime[] H009J2_A941AgenciaCreatedAt ;
      private bool[] H009J2_n941AgenciaCreatedAt ;
      private bool[] H009J2_A940AgenciaStatus ;
      private bool[] H009J2_n940AgenciaStatus ;
      private int[] H009J2_A945AgenciaDigito ;
      private bool[] H009J2_n945AgenciaDigito ;
      private int[] H009J2_A939AgenciaNumero ;
      private bool[] H009J2_n939AgenciaNumero ;
      private string[] H009J2_A969AgenciaBancoNome ;
      private bool[] H009J2_n969AgenciaBancoNome ;
      private int[] H009J2_A938AgenciaId ;
      private long[] H009J3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class agenciaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009J2( IGxContext context ,
                                             string AV74Agenciawwds_1_filterfulltext ,
                                             string AV75Agenciawwds_2_dynamicfiltersselector1 ,
                                             short AV76Agenciawwds_3_dynamicfiltersoperator1 ,
                                             int AV77Agenciawwds_4_agencianumero1 ,
                                             bool AV78Agenciawwds_5_dynamicfiltersenabled2 ,
                                             string AV79Agenciawwds_6_dynamicfiltersselector2 ,
                                             short AV80Agenciawwds_7_dynamicfiltersoperator2 ,
                                             int AV81Agenciawwds_8_agencianumero2 ,
                                             bool AV82Agenciawwds_9_dynamicfiltersenabled3 ,
                                             string AV83Agenciawwds_10_dynamicfiltersselector3 ,
                                             short AV84Agenciawwds_11_dynamicfiltersoperator3 ,
                                             int AV85Agenciawwds_12_agencianumero3 ,
                                             string AV87Agenciawwds_14_tfagenciabanconome_sel ,
                                             string AV86Agenciawwds_13_tfagenciabanconome ,
                                             int AV88Agenciawwds_15_tfagencianumero ,
                                             int AV89Agenciawwds_16_tfagencianumero_to ,
                                             int AV90Agenciawwds_17_tfagenciadigito ,
                                             int AV91Agenciawwds_18_tfagenciadigito_to ,
                                             short AV92Agenciawwds_19_tfagenciastatus_sel ,
                                             DateTime AV93Agenciawwds_20_tfagenciacreatedat ,
                                             DateTime AV94Agenciawwds_21_tfagenciacreatedat_to ,
                                             DateTime AV95Agenciawwds_22_tfagenciaupdatedat ,
                                             DateTime AV96Agenciawwds_23_tfagenciaupdatedat_to ,
                                             int AV7BancoId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             int A945AgenciaDigito ,
                                             bool A940AgenciaStatus ,
                                             DateTime A941AgenciaCreatedAt ,
                                             DateTime A942AgenciaUpdatedAt ,
                                             int A968AgenciaBancoId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[28];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.AgenciaBancoId AS AgenciaBancoId, T1.AgenciaUpdatedAt, T1.AgenciaCreatedAt, T1.AgenciaStatus, T1.AgenciaDigito, T1.AgenciaNumero, T2.BancoNome AS AgenciaBancoNome, T1.AgenciaId";
         sFromString = " FROM (Agencia T1 LEFT JOIN Banco T2 ON T2.BancoId = T1.AgenciaBancoId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.BancoNome) like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.AgenciaNumero,'999999999'), 2) like '%' || :lV74Agenciawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.AgenciaDigito,'999999999'), 2) like '%' || :lV74Agenciawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = FALSE))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Agenciawwds_14_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Agenciawwds_13_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome like :lV86Agenciawwds_13_tfagenciabanconome)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Agenciawwds_14_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV87Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome = ( :AV87Agenciawwds_14_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV87Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.BancoNome IS NULL or (char_length(trim(trailing ' ' from T2.BancoNome))=0))");
         }
         if ( ! (0==AV88Agenciawwds_15_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero >= :AV88Agenciawwds_15_tfagencianumero)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (0==AV89Agenciawwds_16_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero <= :AV89Agenciawwds_16_tfagencianumero_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV90Agenciawwds_17_tfagenciadigito) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito >= :AV90Agenciawwds_17_tfagenciadigito)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (0==AV91Agenciawwds_18_tfagenciadigito_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito <= :AV91Agenciawwds_18_tfagenciadigito_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV92Agenciawwds_19_tfagenciastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = TRUE)");
         }
         if ( AV92Agenciawwds_19_tfagenciastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV93Agenciawwds_20_tfagenciacreatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt >= :AV93Agenciawwds_20_tfagenciacreatedat)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Agenciawwds_21_tfagenciacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt <= :AV94Agenciawwds_21_tfagenciacreatedat_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Agenciawwds_22_tfagenciaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt >= :AV95Agenciawwds_22_tfagenciaupdatedat)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Agenciawwds_23_tfagenciaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt <= :AV96Agenciawwds_23_tfagenciaupdatedat_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (0==AV7BancoId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaBancoId = :AV7BancoId)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AgenciaNumero, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AgenciaNumero DESC, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.BancoNome, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.BancoNome DESC, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AgenciaDigito, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AgenciaDigito DESC, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AgenciaStatus, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AgenciaStatus DESC, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AgenciaCreatedAt, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AgenciaCreatedAt DESC, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.AgenciaUpdatedAt, T1.AgenciaId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.AgenciaUpdatedAt DESC, T1.AgenciaId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.AgenciaId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H009J3( IGxContext context ,
                                             string AV74Agenciawwds_1_filterfulltext ,
                                             string AV75Agenciawwds_2_dynamicfiltersselector1 ,
                                             short AV76Agenciawwds_3_dynamicfiltersoperator1 ,
                                             int AV77Agenciawwds_4_agencianumero1 ,
                                             bool AV78Agenciawwds_5_dynamicfiltersenabled2 ,
                                             string AV79Agenciawwds_6_dynamicfiltersselector2 ,
                                             short AV80Agenciawwds_7_dynamicfiltersoperator2 ,
                                             int AV81Agenciawwds_8_agencianumero2 ,
                                             bool AV82Agenciawwds_9_dynamicfiltersenabled3 ,
                                             string AV83Agenciawwds_10_dynamicfiltersselector3 ,
                                             short AV84Agenciawwds_11_dynamicfiltersoperator3 ,
                                             int AV85Agenciawwds_12_agencianumero3 ,
                                             string AV87Agenciawwds_14_tfagenciabanconome_sel ,
                                             string AV86Agenciawwds_13_tfagenciabanconome ,
                                             int AV88Agenciawwds_15_tfagencianumero ,
                                             int AV89Agenciawwds_16_tfagencianumero_to ,
                                             int AV90Agenciawwds_17_tfagenciadigito ,
                                             int AV91Agenciawwds_18_tfagenciadigito_to ,
                                             short AV92Agenciawwds_19_tfagenciastatus_sel ,
                                             DateTime AV93Agenciawwds_20_tfagenciacreatedat ,
                                             DateTime AV94Agenciawwds_21_tfagenciacreatedat_to ,
                                             DateTime AV95Agenciawwds_22_tfagenciaupdatedat ,
                                             DateTime AV96Agenciawwds_23_tfagenciaupdatedat_to ,
                                             int AV7BancoId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             int A945AgenciaDigito ,
                                             bool A940AgenciaStatus ,
                                             DateTime A941AgenciaCreatedAt ,
                                             DateTime A942AgenciaUpdatedAt ,
                                             int A968AgenciaBancoId ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[25];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (Agencia T1 LEFT JOIN Banco T2 ON T2.BancoId = T1.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Agenciawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.BancoNome) like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.AgenciaNumero,'999999999'), 2) like '%' || :lV74Agenciawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.AgenciaDigito,'999999999'), 2) like '%' || :lV74Agenciawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV74Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = FALSE))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV75Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV76Agenciawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV77Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV77Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV78Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV80Agenciawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV81Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV81Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV82Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Agenciawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV85Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV85Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Agenciawwds_14_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Agenciawwds_13_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome like :lV86Agenciawwds_13_tfagenciabanconome)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Agenciawwds_14_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV87Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome = ( :AV87Agenciawwds_14_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV87Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.BancoNome IS NULL or (char_length(trim(trailing ' ' from T2.BancoNome))=0))");
         }
         if ( ! (0==AV88Agenciawwds_15_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero >= :AV88Agenciawwds_15_tfagencianumero)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (0==AV89Agenciawwds_16_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero <= :AV89Agenciawwds_16_tfagencianumero_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV90Agenciawwds_17_tfagenciadigito) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito >= :AV90Agenciawwds_17_tfagenciadigito)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (0==AV91Agenciawwds_18_tfagenciadigito_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito <= :AV91Agenciawwds_18_tfagenciadigito_to)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV92Agenciawwds_19_tfagenciastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = TRUE)");
         }
         if ( AV92Agenciawwds_19_tfagenciastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV93Agenciawwds_20_tfagenciacreatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt >= :AV93Agenciawwds_20_tfagenciacreatedat)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Agenciawwds_21_tfagenciacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt <= :AV94Agenciawwds_21_tfagenciacreatedat_to)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Agenciawwds_22_tfagenciaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt >= :AV95Agenciawwds_22_tfagenciaupdatedat)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV96Agenciawwds_23_tfagenciaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt <= :AV96Agenciawwds_23_tfagenciaupdatedat_to)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (0==AV7BancoId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaBancoId = :AV7BancoId)");
         }
         else
         {
            GXv_int6[24] = 1;
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
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
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
                     return conditional_H009J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (int)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (short)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (int)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
               case 1 :
                     return conditional_H009J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (int)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (short)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (int)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmH009J2;
          prmH009J2 = new Object[] {
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV86Agenciawwds_13_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV87Agenciawwds_14_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV88Agenciawwds_15_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV89Agenciawwds_16_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV90Agenciawwds_17_tfagenciadigito",GXType.Int32,9,0) ,
          new ParDef("AV91Agenciawwds_18_tfagenciadigito_to",GXType.Int32,9,0) ,
          new ParDef("AV93Agenciawwds_20_tfagenciacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV94Agenciawwds_21_tfagenciacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV95Agenciawwds_22_tfagenciaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV96Agenciawwds_23_tfagenciaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV7BancoId",GXType.Int32,9,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009J3;
          prmH009J3 = new Object[] {
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV81Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV85Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV86Agenciawwds_13_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV87Agenciawwds_14_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV88Agenciawwds_15_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV89Agenciawwds_16_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV90Agenciawwds_17_tfagenciadigito",GXType.Int32,9,0) ,
          new ParDef("AV91Agenciawwds_18_tfagenciadigito_to",GXType.Int32,9,0) ,
          new ParDef("AV93Agenciawwds_20_tfagenciacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV94Agenciawwds_21_tfagenciacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV95Agenciawwds_22_tfagenciaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV96Agenciawwds_23_tfagenciaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV7BancoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H009J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
