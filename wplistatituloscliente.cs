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
   public class wplistatituloscliente : GXDataArea
   {
      public wplistatituloscliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wplistatituloscliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           string aP1_ClienteRazaoSocial )
      {
         this.AV7ClienteId = aP0_ClienteId;
         this.AV102ClienteRazaoSocial = aP1_ClienteRazaoSocial;
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
         chkTituloDeleted = new GXCheckbox();
         cmbTituloTipo = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ClienteId");
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
               gxfirstwebparm = GetFirstPar( "ClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ClienteId");
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
         nRC_GXsfl_105 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_105"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_105_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_105_idx = GetPar( "sGXsfl_105_idx");
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
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV17DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19TituloValor1 = NumberUtil.Val( GetPar( "TituloValor1"), ".");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23TituloValor2 = NumberUtil.Val( GetPar( "TituloValor2"), ".");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV27TituloValor3 = NumberUtil.Val( GetPar( "TituloValor3"), ".");
         AV35ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV105Pgmname = GetPar( "Pgmname");
         AV7ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
         AV16FilterFullText = GetPar( "FilterFullText");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV103TFTituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TFTituloId"), "."), 18, MidpointRounding.ToEven));
         AV104TFTituloId_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFTituloId_To"), "."), 18, MidpointRounding.ToEven));
         AV38TFTituloValor = NumberUtil.Val( GetPar( "TFTituloValor"), ".");
         AV39TFTituloValor_To = NumberUtil.Val( GetPar( "TFTituloValor_To"), ".");
         AV40TFTituloDesconto = NumberUtil.Val( GetPar( "TFTituloDesconto"), ".");
         AV41TFTituloDesconto_To = NumberUtil.Val( GetPar( "TFTituloDesconto_To"), ".");
         AV52TFTituloCompetencia_F = GetPar( "TFTituloCompetencia_F");
         AV53TFTituloCompetencia_F_Sel = GetPar( "TFTituloCompetencia_F_Sel");
         AV54TFTituloProrrogacao = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao"));
         AV55TFTituloProrrogacao_To = context.localUtil.ParseDateParm( GetPar( "TFTituloProrrogacao_To"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV72TFTituloTipo_Sels);
         AV77TFTituloSaldo_F = NumberUtil.Val( GetPar( "TFTituloSaldo_F"), ".");
         AV78TFTituloSaldo_F_To = NumberUtil.Val( GetPar( "TFTituloSaldo_F_To"), ".");
         AV79TFTituloStatus_F = GetPar( "TFTituloStatus_F");
         AV80TFTituloStatus_F_Sel = GetPar( "TFTituloStatus_F_Sel");
         AV102ClienteRazaoSocial = GetPar( "ClienteRazaoSocial");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV29DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV28DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
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
         PA512( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START512( ) ;
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
         GXEncryptionTmp = "wplistatituloscliente"+UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV102ClienteRazaoSocial));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wplistatituloscliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV102ClienteRazaoSocial, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR1", StringUtil.LTrim( StringUtil.NToC( AV19TituloValor1, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR2", StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTITULOVALOR3", StringUtil.LTrim( StringUtil.NToC( AV27TituloValor3, 18, 2, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_105", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_105), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV33ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV33ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV97GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV93DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV93DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATE", context.localUtil.DToC( AV56DDO_TituloProrrogacaoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TITULOPRORROGACAOAUXDATETO", context.localUtil.DToC( AV57DDO_TituloProrrogacaoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFTITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103TFTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV104TFTituloId_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR", StringUtil.LTrim( StringUtil.NToC( AV38TFTituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOVALOR_TO", StringUtil.LTrim( StringUtil.NToC( AV39TFTituloValor_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO", StringUtil.LTrim( StringUtil.NToC( AV40TFTituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULODESCONTO_TO", StringUtil.LTrim( StringUtil.NToC( AV41TFTituloDesconto_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOCOMPETENCIA_F", AV52TFTituloCompetencia_F);
         GxWebStd.gx_hidden_field( context, "vTFTITULOCOMPETENCIA_F_SEL", AV53TFTituloCompetencia_F_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO", context.localUtil.DToC( AV54TFTituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTITULOPRORROGACAO_TO", context.localUtil.DToC( AV55TFTituloProrrogacao_To, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFTITULOTIPO_SELS", AV72TFTituloTipo_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFTITULOTIPO_SELS", AV72TFTituloTipo_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFTITULOSALDO_F", StringUtil.LTrim( StringUtil.NToC( AV77TFTituloSaldo_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOSALDO_F_TO", StringUtil.LTrim( StringUtil.NToC( AV78TFTituloSaldo_F_To, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFTITULOSTATUS_F", AV79TFTituloStatus_F);
         GxWebStd.gx_hidden_field( context, "vTFTITULOSTATUS_F_SEL", AV80TFTituloStatus_F_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV29DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV28DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "vTFTITULOTIPO_SELSJSON", AV71TFTituloTipo_SelsJson);
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
            WE512( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT512( ) ;
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
         GXEncryptionTmp = "wplistatituloscliente"+UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV102ClienteRazaoSocial));
         return formatLink("wplistatituloscliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WpListaTitulosCliente" ;
      }

      public override string GetPgmdesc( )
      {
         return " Titulo" ;
      }

      protected void WB510( )
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
            GxWebStd.gx_div_start( context, divDatacontentcellfl_Internalname, 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavClienterazaosocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavClienterazaosocial_Internalname, "Razão social", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavClienterazaosocial_Internalname, AV102ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( AV102ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavClienterazaosocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavClienterazaosocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpListaTitulosCliente.htm");
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV33ManageFiltersData);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WpListaTitulosCliente.htm");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV17DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_43_512( true) ;
         }
         else
         {
            wb_table1_43_512( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_512e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV21DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_65_512( true) ;
         }
         else
         {
            wb_table2_65_512( false) ;
         }
         return  ;
      }

      protected void wb_table2_65_512e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_87_512( true) ;
         }
         else
         {
            wb_table3_87_512( false) ;
         }
         return  ;
      }

      protected void wb_table3_87_512e( bool wbgen )
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
            StartGridControl105( ) ;
         }
         if ( wbEnd == 105 )
         {
            wbEnd = 0;
            nRC_GXsfl_105 = (int)(nGXsfl_105_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV95GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV96GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV97GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(105), 3, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
            ClassString = "ButtonExcel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(105), 3, 0)+","+"null"+");", "Excel", bttBtnexport_Jsonclick, 5, "Exportar para Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
            ClassString = "ButtonPDF";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexportreport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(105), 3, 0)+","+"null"+");", "PDF", bttBtnexportreport_Jsonclick, 5, "Exportar para PDF", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORTREPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(105), 3, 0)+","+"null"+");", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WpListaTitulosCliente.htm");
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
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WpListaTitulosCliente.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV93DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_tituloprorrogacaoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tituloprorrogacaoauxdatetext_Internalname, AV58DDO_TituloProrrogacaoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV58DDO_TituloProrrogacaoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WpListaTitulosCliente.htm");
            /* User Defined Control */
            ucTftituloprorrogacao_rangepicker.SetProperty("Start Date", AV56DDO_TituloProrrogacaoAuxDate);
            ucTftituloprorrogacao_rangepicker.SetProperty("End Date", AV57DDO_TituloProrrogacaoAuxDateTo);
            ucTftituloprorrogacao_rangepicker.Render(context, "wwp.daterangepicker", Tftituloprorrogacao_rangepicker_Internalname, "TFTITULOPRORROGACAO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 105 )
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

      protected void START512( )
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
         Form.Meta.addItem("description", " Titulo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP510( ) ;
      }

      protected void WS512( )
      {
         START512( ) ;
         EVT512( ) ;
      }

      protected void EVT512( )
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
                              E11512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E12512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E13512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E14512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E15512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E16512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E17512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E19512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORTREPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExportReport' */
                              E20512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E21512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E23512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24512 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25512 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_105_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
                              SubsflControlProps_1052( ) ;
                              AV98Display = cgiGet( edtavDisplay_Internalname);
                              AssignAttri("", false, edtavDisplay_Internalname, AV98Display);
                              A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n168ClienteId = false;
                              A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
                              n170ClienteRazaoSocial = false;
                              A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n261TituloId = false;
                              A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
                              n262TituloValor = false;
                              A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
                              n276TituloDesconto = false;
                              A284TituloDeleted = StringUtil.StrToBool( cgiGet( chkTituloDeleted_Internalname));
                              n284TituloDeleted = false;
                              A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n286TituloCompetenciaAno = false;
                              A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n287TituloCompetenciaMes = false;
                              A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
                              A264TituloProrrogacao = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTituloProrrogacao_Internalname), 0));
                              n264TituloProrrogacao = false;
                              cmbTituloTipo.Name = cmbTituloTipo_Internalname;
                              cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
                              A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
                              n283TituloTipo = false;
                              A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
                              n273TituloTotalMovimento_F = false;
                              A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
                              n275TituloSaldo_F = false;
                              A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
                              n282TituloStatus_F = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E26512 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E27512 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E28512 ();
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
                                       /* Set Refresh If Titulovalor1 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR1"), ",", ".") != AV19TituloValor1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Titulovalor2 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR2"), ",", ".") != AV23TituloValor2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Titulovalor3 Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR3"), ",", ".") != AV27TituloValor3 )
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

      protected void WE512( )
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

      protected void PA512( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wplistatituloscliente")), "wplistatituloscliente") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wplistatituloscliente")))) ;
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
                  gxfirstwebparm = GetFirstPar( "ClienteId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7ClienteId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 9, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV102ClienteRazaoSocial = GetPar( "ClienteRazaoSocial");
                        AssignAttri("", false, "AV102ClienteRazaoSocial", AV102ClienteRazaoSocial);
                        GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV102ClienteRazaoSocial, "@!")), context));
                     }
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
         SubsflControlProps_1052( ) ;
         while ( nGXsfl_105_idx <= nRC_GXsfl_105 )
         {
            sendrow_1052( ) ;
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       decimal AV19TituloValor1 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       decimal AV23TituloValor2 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       decimal AV27TituloValor3 ,
                                       short AV35ManageFiltersExecutionStep ,
                                       string AV105Pgmname ,
                                       int AV7ClienteId ,
                                       string AV16FilterFullText ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       int AV103TFTituloId ,
                                       int AV104TFTituloId_To ,
                                       decimal AV38TFTituloValor ,
                                       decimal AV39TFTituloValor_To ,
                                       decimal AV40TFTituloDesconto ,
                                       decimal AV41TFTituloDesconto_To ,
                                       string AV52TFTituloCompetencia_F ,
                                       string AV53TFTituloCompetencia_F_Sel ,
                                       DateTime AV54TFTituloProrrogacao ,
                                       DateTime AV55TFTituloProrrogacao_To ,
                                       GxSimpleCollection<string> AV72TFTituloTipo_Sels ,
                                       decimal AV77TFTituloSaldo_F ,
                                       decimal AV78TFTituloSaldo_F_To ,
                                       string AV79TFTituloStatus_F ,
                                       string AV80TFTituloStatus_F_Sel ,
                                       string AV102ClienteRazaoSocial ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV29DynamicFiltersIgnoreFirst ,
                                       bool AV28DynamicFiltersRemoving ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF512( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", "")));
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
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF512( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV105Pgmname = "WpListaTitulosCliente";
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavDisplay_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A283TituloTipo ,
                                              AV129Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              AV110Wplistatitulosclienteds_5_titulovalor1 ,
                                              AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              AV114Wplistatitulosclienteds_9_titulovalor2 ,
                                              AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              AV118Wplistatitulosclienteds_13_titulovalor3 ,
                                              AV119Wplistatitulosclienteds_14_tftituloid ,
                                              AV120Wplistatitulosclienteds_15_tftituloid_to ,
                                              AV121Wplistatitulosclienteds_16_tftitulovalor ,
                                              AV122Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              AV123Wplistatitulosclienteds_18_tftitulodesconto ,
                                              AV124Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              AV127Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              AV129Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                              A262TituloValor ,
                                              A261TituloId ,
                                              A276TituloDesconto ,
                                              A264TituloProrrogacao ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV107Wplistatitulosclienteds_2_filterfulltext ,
                                              A295TituloCompetencia_F ,
                                              A275TituloSaldo_F ,
                                              A282TituloStatus_F ,
                                              AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              AV125Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              AV130Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              AV132Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              A168ClienteId ,
                                              AV106Wplistatitulosclienteds_1_clienteid ,
                                              A284TituloDeleted } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV132Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV132Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
         /* Using cursor H00518 */
         pr_default.execute(0, new Object[] {AV130Wplistatitulosclienteds_25_tftitulosaldo_f, AV130Wplistatitulosclienteds_25_tftitulosaldo_f, AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV132Wplistatitulosclienteds_27_tftitulostatus_f, lV132Wplistatitulosclienteds_27_tftitulostatus_f, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV106Wplistatitulosclienteds_1_clienteid, AV110Wplistatitulosclienteds_5_titulovalor1, AV110Wplistatitulosclienteds_5_titulovalor1, AV110Wplistatitulosclienteds_5_titulovalor1, AV114Wplistatitulosclienteds_9_titulovalor2, AV114Wplistatitulosclienteds_9_titulovalor2, AV114Wplistatitulosclienteds_9_titulovalor2, AV118Wplistatitulosclienteds_13_titulovalor3, AV118Wplistatitulosclienteds_13_titulovalor3, AV118Wplistatitulosclienteds_13_titulovalor3, AV119Wplistatitulosclienteds_14_tftituloid, AV120Wplistatitulosclienteds_15_tftituloid_to, AV121Wplistatitulosclienteds_16_tftitulovalor, AV122Wplistatitulosclienteds_17_tftitulovalor_to, AV123Wplistatitulosclienteds_18_tftitulodesconto, AV124Wplistatitulosclienteds_19_tftitulodesconto_to, AV127Wplistatitulosclienteds_22_tftituloprorrogacao, AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A890NotaFiscalParcelamentoID = H00518_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = H00518_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = H00518_A794NotaFiscalId[0];
            n794NotaFiscalId = H00518_n794NotaFiscalId[0];
            A283TituloTipo = H00518_A283TituloTipo[0];
            n283TituloTipo = H00518_n283TituloTipo[0];
            A264TituloProrrogacao = H00518_A264TituloProrrogacao[0];
            n264TituloProrrogacao = H00518_n264TituloProrrogacao[0];
            A284TituloDeleted = H00518_A284TituloDeleted[0];
            n284TituloDeleted = H00518_n284TituloDeleted[0];
            A276TituloDesconto = H00518_A276TituloDesconto[0];
            n276TituloDesconto = H00518_n276TituloDesconto[0];
            A262TituloValor = H00518_A262TituloValor[0];
            n262TituloValor = H00518_n262TituloValor[0];
            A261TituloId = H00518_A261TituloId[0];
            n261TituloId = H00518_n261TituloId[0];
            A170ClienteRazaoSocial = H00518_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00518_n170ClienteRazaoSocial[0];
            A168ClienteId = H00518_A168ClienteId[0];
            n168ClienteId = H00518_n168ClienteId[0];
            A282TituloStatus_F = H00518_A282TituloStatus_F[0];
            n282TituloStatus_F = H00518_n282TituloStatus_F[0];
            A275TituloSaldo_F = H00518_A275TituloSaldo_F[0];
            n275TituloSaldo_F = H00518_n275TituloSaldo_F[0];
            A273TituloTotalMovimento_F = H00518_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H00518_n273TituloTotalMovimento_F[0];
            A286TituloCompetenciaAno = H00518_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = H00518_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = H00518_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = H00518_n287TituloCompetenciaMes[0];
            A794NotaFiscalId = H00518_A794NotaFiscalId[0];
            n794NotaFiscalId = H00518_n794NotaFiscalId[0];
            A168ClienteId = H00518_A168ClienteId[0];
            n168ClienteId = H00518_n168ClienteId[0];
            A170ClienteRazaoSocial = H00518_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = H00518_n170ClienteRazaoSocial[0];
            A282TituloStatus_F = H00518_A282TituloStatus_F[0];
            n282TituloStatus_F = H00518_n282TituloStatus_F[0];
            A275TituloSaldo_F = H00518_A275TituloSaldo_F[0];
            n275TituloSaldo_F = H00518_n275TituloSaldo_F[0];
            A273TituloTotalMovimento_F = H00518_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = H00518_n273TituloTotalMovimento_F[0];
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV107Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV107Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV125Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                     {
                        GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                     }
                  }
               }
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF512( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 105;
         /* Execute user event: Refresh */
         E27512 ();
         nGXsfl_105_idx = 1;
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         bGXsfl_105_Refreshing = true;
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
            SubsflControlProps_1052( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A283TituloTipo ,
                                                 AV129Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                                 AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                                 AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                                 AV110Wplistatitulosclienteds_5_titulovalor1 ,
                                                 AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                                 AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                                 AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                                 AV114Wplistatitulosclienteds_9_titulovalor2 ,
                                                 AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                                 AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                                 AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                                 AV118Wplistatitulosclienteds_13_titulovalor3 ,
                                                 AV119Wplistatitulosclienteds_14_tftituloid ,
                                                 AV120Wplistatitulosclienteds_15_tftituloid_to ,
                                                 AV121Wplistatitulosclienteds_16_tftitulovalor ,
                                                 AV122Wplistatitulosclienteds_17_tftitulovalor_to ,
                                                 AV123Wplistatitulosclienteds_18_tftitulodesconto ,
                                                 AV124Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                                 AV127Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                                 AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                                 AV129Wplistatitulosclienteds_24_tftitulotipo_sels.Count ,
                                                 A262TituloValor ,
                                                 A261TituloId ,
                                                 A276TituloDesconto ,
                                                 A264TituloProrrogacao ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV107Wplistatitulosclienteds_2_filterfulltext ,
                                                 A295TituloCompetencia_F ,
                                                 A275TituloSaldo_F ,
                                                 A282TituloStatus_F ,
                                                 AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                                 AV125Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                                 AV130Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                                 AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                                 AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                                 AV132Wplistatitulosclienteds_27_tftitulostatus_f ,
                                                 A168ClienteId ,
                                                 AV106Wplistatitulosclienteds_1_clienteid ,
                                                 A284TituloDeleted } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV132Wplistatitulosclienteds_27_tftitulostatus_f = StringUtil.Concat( StringUtil.RTrim( AV132Wplistatitulosclienteds_27_tftitulostatus_f), "%", "");
            /* Using cursor H005115 */
            pr_default.execute(1, new Object[] {AV130Wplistatitulosclienteds_25_tftitulosaldo_f, AV130Wplistatitulosclienteds_25_tftitulosaldo_f, AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV132Wplistatitulosclienteds_27_tftitulostatus_f, lV132Wplistatitulosclienteds_27_tftitulostatus_f, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel, AV106Wplistatitulosclienteds_1_clienteid, AV110Wplistatitulosclienteds_5_titulovalor1, AV110Wplistatitulosclienteds_5_titulovalor1, AV110Wplistatitulosclienteds_5_titulovalor1, AV114Wplistatitulosclienteds_9_titulovalor2, AV114Wplistatitulosclienteds_9_titulovalor2, AV114Wplistatitulosclienteds_9_titulovalor2, AV118Wplistatitulosclienteds_13_titulovalor3, AV118Wplistatitulosclienteds_13_titulovalor3, AV118Wplistatitulosclienteds_13_titulovalor3, AV119Wplistatitulosclienteds_14_tftituloid, AV120Wplistatitulosclienteds_15_tftituloid_to, AV121Wplistatitulosclienteds_16_tftitulovalor, AV122Wplistatitulosclienteds_17_tftitulovalor_to, AV123Wplistatitulosclienteds_18_tftitulodesconto, AV124Wplistatitulosclienteds_19_tftitulodesconto_to, AV127Wplistatitulosclienteds_22_tftituloprorrogacao, AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to});
            nGXsfl_105_idx = 1;
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A890NotaFiscalParcelamentoID = H005115_A890NotaFiscalParcelamentoID[0];
               n890NotaFiscalParcelamentoID = H005115_n890NotaFiscalParcelamentoID[0];
               A794NotaFiscalId = H005115_A794NotaFiscalId[0];
               n794NotaFiscalId = H005115_n794NotaFiscalId[0];
               A283TituloTipo = H005115_A283TituloTipo[0];
               n283TituloTipo = H005115_n283TituloTipo[0];
               A264TituloProrrogacao = H005115_A264TituloProrrogacao[0];
               n264TituloProrrogacao = H005115_n264TituloProrrogacao[0];
               A284TituloDeleted = H005115_A284TituloDeleted[0];
               n284TituloDeleted = H005115_n284TituloDeleted[0];
               A276TituloDesconto = H005115_A276TituloDesconto[0];
               n276TituloDesconto = H005115_n276TituloDesconto[0];
               A262TituloValor = H005115_A262TituloValor[0];
               n262TituloValor = H005115_n262TituloValor[0];
               A261TituloId = H005115_A261TituloId[0];
               n261TituloId = H005115_n261TituloId[0];
               A170ClienteRazaoSocial = H005115_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H005115_n170ClienteRazaoSocial[0];
               A168ClienteId = H005115_A168ClienteId[0];
               n168ClienteId = H005115_n168ClienteId[0];
               A282TituloStatus_F = H005115_A282TituloStatus_F[0];
               n282TituloStatus_F = H005115_n282TituloStatus_F[0];
               A275TituloSaldo_F = H005115_A275TituloSaldo_F[0];
               n275TituloSaldo_F = H005115_n275TituloSaldo_F[0];
               A273TituloTotalMovimento_F = H005115_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = H005115_n273TituloTotalMovimento_F[0];
               A286TituloCompetenciaAno = H005115_A286TituloCompetenciaAno[0];
               n286TituloCompetenciaAno = H005115_n286TituloCompetenciaAno[0];
               A287TituloCompetenciaMes = H005115_A287TituloCompetenciaMes[0];
               n287TituloCompetenciaMes = H005115_n287TituloCompetenciaMes[0];
               A794NotaFiscalId = H005115_A794NotaFiscalId[0];
               n794NotaFiscalId = H005115_n794NotaFiscalId[0];
               A168ClienteId = H005115_A168ClienteId[0];
               n168ClienteId = H005115_n168ClienteId[0];
               A170ClienteRazaoSocial = H005115_A170ClienteRazaoSocial[0];
               n170ClienteRazaoSocial = H005115_n170ClienteRazaoSocial[0];
               A282TituloStatus_F = H005115_A282TituloStatus_F[0];
               n282TituloStatus_F = H005115_n282TituloStatus_F[0];
               A275TituloSaldo_F = H005115_A275TituloSaldo_F[0];
               n275TituloSaldo_F = H005115_n275TituloSaldo_F[0];
               A273TituloTotalMovimento_F = H005115_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = H005115_n273TituloTotalMovimento_F[0];
               A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Wplistatitulosclienteds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A261TituloId), 9, 0) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A262TituloValor, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A276TituloDesconto, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "débito" , StringUtil.PadR( "%" + StringUtil.Lower( AV107Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) ) || ( StringUtil.Like( "crédito" , StringUtil.PadR( "%" + StringUtil.Lower( AV107Wplistatitulosclienteds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A275TituloSaldo_F, 18, 2) , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( A282TituloStatus_F , StringUtil.PadR( "%" + AV107Wplistatitulosclienteds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
               {
                  if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wplistatitulosclienteds_20_tftitulocompetencia_f)) ) ) || ( StringUtil.Like( A295TituloCompetencia_F , StringUtil.PadR( AV125Wplistatitulosclienteds_20_tftitulocompetencia_f , 40 , "%"),  ' ' ) ) )
                  {
                     if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel)) && ! ( StringUtil.StrCmp(AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A295TituloCompetencia_F, AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel) == 0 ) ) )
                     {
                        if ( ( StringUtil.StrCmp(AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A295TituloCompetencia_F)) ) )
                        {
                           /* Execute user event: Grid.Load */
                           E28512 ();
                        }
                     }
                  }
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 105;
            WB510( ) ;
         }
         bGXsfl_105_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes512( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV105Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV105Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TITULOID"+"_"+sGXsfl_105_idx, GetSecureSignedToken( sGXsfl_105_idx, context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV105Pgmname = "WpListaTitulosCliente";
         edtavClienterazaosocial_Enabled = 0;
         AssignProp("", false, edtavClienterazaosocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavClienterazaosocial_Enabled), 5, 0), true);
         edtavDisplay_Enabled = 0;
         edtClienteId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloStatus_F_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP510( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E26512 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV33ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV93DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_105 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_105"), ",", "."), 18, MidpointRounding.ToEven));
            AV95GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV96GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV97GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV56DDO_TituloProrrogacaoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATE"), 0);
            AV57DDO_TituloProrrogacaoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TITULOPRORROGACAOAUXDATETO"), 0);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR1");
               GX_FocusControl = edtavTitulovalor1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19TituloValor1 = 0;
               AssignAttri("", false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
            }
            else
            {
               AV19TituloValor1 = context.localUtil.CToN( cgiGet( edtavTitulovalor1_Internalname), ",", ".");
               AssignAttri("", false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
            }
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV21DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR2");
               GX_FocusControl = edtavTitulovalor2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23TituloValor2 = 0;
               AssignAttri("", false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
            }
            else
            {
               AV23TituloValor2 = context.localUtil.CToN( cgiGet( edtavTitulovalor2_Internalname), ",", ".");
               AssignAttri("", false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
            }
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV25DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTITULOVALOR3");
               GX_FocusControl = edtavTitulovalor3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV27TituloValor3 = 0;
               AssignAttri("", false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
            }
            else
            {
               AV27TituloValor3 = context.localUtil.CToN( cgiGet( edtavTitulovalor3_Internalname), ",", ".");
               AssignAttri("", false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
            }
            AV58DDO_TituloProrrogacaoAuxDateText = cgiGet( edtavDdo_tituloprorrogacaoauxdatetext_Internalname);
            AssignAttri("", false, "AV58DDO_TituloProrrogacaoAuxDateText", AV58DDO_TituloProrrogacaoAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV17DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV18DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR1"), ",", ".") != AV19TituloValor1 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV21DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV22DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR2"), ",", ".") != AV23TituloValor2 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV25DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vTITULOVALOR3"), ",", ".") != AV27TituloValor3 )
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
         E26512 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E26512( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFTITULOPRORROGACAO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_tituloprorrogacaoauxdatetext_Internalname});
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
         AV17DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV21DynamicFiltersSelector2 = "TITULOVALOR";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
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
         Form.Caption = " Titulo";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV93DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV93DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E27512( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( AV35ManageFiltersExecutionStep == 1 )
         {
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV35ManageFiltersExecutionStep == 2 )
         {
            AV35ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
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
         AV95GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV95GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV95GridCurrentPage), 10, 0));
         AV96GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV96GridPageCount", StringUtil.LTrimStr( (decimal)(AV96GridPageCount), 10, 0));
         GXt_char2 = AV97GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV105Pgmname, out  GXt_char2) ;
         AV97GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV97GridAppliedFilters", AV97GridAppliedFilters);
         edtTituloProrrogacao_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtTituloProrrogacao_Internalname, "Columnheaderclass", edtTituloProrrogacao_Columnheaderclass, !bGXsfl_105_Refreshing);
         cmbTituloTipo_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbTituloTipo_Internalname, "Columnheaderclass", cmbTituloTipo_Columnheaderclass, !bGXsfl_105_Refreshing);
         AV106Wplistatitulosclienteds_1_clienteid = AV7ClienteId;
         AV107Wplistatitulosclienteds_2_filterfulltext = AV16FilterFullText;
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV110Wplistatitulosclienteds_5_titulovalor1 = AV19TituloValor1;
         AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV114Wplistatitulosclienteds_9_titulovalor2 = AV23TituloValor2;
         AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV118Wplistatitulosclienteds_13_titulovalor3 = AV27TituloValor3;
         AV119Wplistatitulosclienteds_14_tftituloid = AV103TFTituloId;
         AV120Wplistatitulosclienteds_15_tftituloid_to = AV104TFTituloId_To;
         AV121Wplistatitulosclienteds_16_tftitulovalor = AV38TFTituloValor;
         AV122Wplistatitulosclienteds_17_tftitulovalor_to = AV39TFTituloValor_To;
         AV123Wplistatitulosclienteds_18_tftitulodesconto = AV40TFTituloDesconto;
         AV124Wplistatitulosclienteds_19_tftitulodesconto_to = AV41TFTituloDesconto_To;
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = AV52TFTituloCompetencia_F;
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = AV53TFTituloCompetencia_F_Sel;
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = AV54TFTituloProrrogacao;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = AV55TFTituloProrrogacao_To;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = AV72TFTituloTipo_Sels;
         AV130Wplistatitulosclienteds_25_tftitulosaldo_f = AV77TFTituloSaldo_F;
         AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = AV78TFTituloSaldo_F_To;
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = AV79TFTituloStatus_F;
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = AV80TFTituloStatus_F_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E12512( )
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
            AV94PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV94PageToGo) ;
         }
      }

      protected void E13512( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E14512( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloId") == 0 )
            {
               AV103TFTituloId = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFTituloId", StringUtil.LTrimStr( (decimal)(AV103TFTituloId), 9, 0));
               AV104TFTituloId_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFTituloId_To", StringUtil.LTrimStr( (decimal)(AV104TFTituloId_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloValor") == 0 )
            {
               AV38TFTituloValor = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
               AV39TFTituloValor_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloDesconto") == 0 )
            {
               AV40TFTituloDesconto = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
               AV41TFTituloDesconto_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloCompetencia_F") == 0 )
            {
               AV52TFTituloCompetencia_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFTituloCompetencia_F", AV52TFTituloCompetencia_F);
               AV53TFTituloCompetencia_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFTituloCompetencia_F_Sel", AV53TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloProrrogacao") == 0 )
            {
               AV54TFTituloProrrogacao = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 4);
               AssignAttri("", false, "AV54TFTituloProrrogacao", context.localUtil.Format(AV54TFTituloProrrogacao, "99/99/9999"));
               AV55TFTituloProrrogacao_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 4);
               AssignAttri("", false, "AV55TFTituloProrrogacao_To", context.localUtil.Format(AV55TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloTipo") == 0 )
            {
               AV71TFTituloTipo_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV71TFTituloTipo_SelsJson", AV71TFTituloTipo_SelsJson);
               AV72TFTituloTipo_Sels.FromJSonString(AV71TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloSaldo_F") == 0 )
            {
               AV77TFTituloSaldo_F = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV77TFTituloSaldo_F", StringUtil.LTrimStr( AV77TFTituloSaldo_F, 18, 2));
               AV78TFTituloSaldo_F_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV78TFTituloSaldo_F_To", StringUtil.LTrimStr( AV78TFTituloSaldo_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TituloStatus_F") == 0 )
            {
               AV79TFTituloStatus_F = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV79TFTituloStatus_F", AV79TFTituloStatus_F);
               AV80TFTituloStatus_F_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFTituloStatus_F_Sel", AV80TFTituloStatus_F_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV72TFTituloTipo_Sels", AV72TFTituloTipo_Sels);
      }

      private void E28512( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV98Display = "<i class=\"fa fa-search\"></i>";
            AssignAttri("", false, edtavDisplay_Internalname, AV98Display);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A261TituloId,9,0));
            edtavDisplay_Link = formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) < DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) == DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else if ( DateTimeUtil.ResetTime ( A264TituloProrrogacao ) > DateTimeUtil.ResetTime ( Gx_date ) )
            {
               edtTituloProrrogacao_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else
            {
               edtTituloProrrogacao_Columnclass = "WWColumn";
            }
            if ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 )
            {
               cmbTituloTipo_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 )
            {
               cmbTituloTipo_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else
            {
               cmbTituloTipo_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 105;
            }
            sendrow_1052( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_105_Refreshing )
         {
            DoAjaxLoad(105, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E21512( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E15512( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV29DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV29DynamicFiltersIgnoreFirst", AV29DynamicFiltersIgnoreFirst);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV29DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV29DynamicFiltersIgnoreFirst", AV29DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E22512( )
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

      protected void E23512( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E16512( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E24512( )
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

      protected void E17512( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV28DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
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
         AV28DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV28DynamicFiltersRemoving", AV28DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19TituloValor1, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23TituloValor2, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27TituloValor3, AV35ManageFiltersExecutionStep, AV105Pgmname, AV7ClienteId, AV16FilterFullText, AV20DynamicFiltersEnabled2, AV24DynamicFiltersEnabled3, AV103TFTituloId, AV104TFTituloId_To, AV38TFTituloValor, AV39TFTituloValor_To, AV40TFTituloDesconto, AV41TFTituloDesconto_To, AV52TFTituloCompetencia_F, AV53TFTituloCompetencia_F_Sel, AV54TFTituloProrrogacao, AV55TFTituloProrrogacao_To, AV72TFTituloTipo_Sels, AV77TFTituloSaldo_F, AV78TFTituloSaldo_F_To, AV79TFTituloStatus_F, AV80TFTituloStatus_F_Sel, AV102ClienteRazaoSocial, AV11GridState, AV29DynamicFiltersIgnoreFirst, AV28DynamicFiltersRemoving, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E25512( )
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

      protected void E11512( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras"+UrlEncode(StringUtil.RTrim("WpListaTitulosClienteFilters")) + "," + UrlEncode(StringUtil.RTrim(AV105Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters"+UrlEncode(StringUtil.RTrim("WpListaTitulosClienteFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV35ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV35ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV35ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV34ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WpListaTitulosClienteFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV34ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV34ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV105Pgmname+"GridState",  AV34ManageFiltersXml) ;
               AV11GridState.FromXml(AV34ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV72TFTituloTipo_Sels", AV72TFTituloTipo_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV17DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV21DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33ManageFiltersData", AV33ManageFiltersData);
      }

      protected void E18512( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E19512( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new wplistatitulosclienteexport(context ).execute( out  AV30ExcelFilename, out  AV31ErrorMessage) ;
         if ( StringUtil.StrCmp(AV30ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV30ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV31ErrorMessage);
         }
      }

      protected void E20512( )
      {
         /* 'DoExportReport' Routine */
         returnInSub = false;
         Innewwindow1_Target = formatLink("wplistatitulosclienteexportreport") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
         /*  Sending Event outputs  */
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
         edtavTitulovalor1_Visible = 0;
         AssignProp("", false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor1_Visible = 1;
            AssignProp("", false, edtavTitulovalor1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTitulovalor2_Visible = 0;
         AssignProp("", false, edtavTitulovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor2_Visible = 1;
            AssignProp("", false, edtavTitulovalor2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTitulovalor3_Visible = 0;
         AssignProp("", false, edtavTitulovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 )
         {
            edtavTitulovalor3_Visible = 1;
            AssignProp("", false, edtavTitulovalor3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTitulovalor3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S202( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "TITULOVALOR";
         AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23TituloValor2 = 0;
         AssignAttri("", false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "TITULOVALOR";
         AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV27TituloValor3 = 0;
         AssignAttri("", false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV33ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WpListaTitulosClienteFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV33ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S222( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV103TFTituloId = 0;
         AssignAttri("", false, "AV103TFTituloId", StringUtil.LTrimStr( (decimal)(AV103TFTituloId), 9, 0));
         AV104TFTituloId_To = 0;
         AssignAttri("", false, "AV104TFTituloId_To", StringUtil.LTrimStr( (decimal)(AV104TFTituloId_To), 9, 0));
         AV38TFTituloValor = 0;
         AssignAttri("", false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
         AV39TFTituloValor_To = 0;
         AssignAttri("", false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
         AV40TFTituloDesconto = 0;
         AssignAttri("", false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
         AV41TFTituloDesconto_To = 0;
         AssignAttri("", false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
         AV52TFTituloCompetencia_F = "";
         AssignAttri("", false, "AV52TFTituloCompetencia_F", AV52TFTituloCompetencia_F);
         AV53TFTituloCompetencia_F_Sel = "";
         AssignAttri("", false, "AV53TFTituloCompetencia_F_Sel", AV53TFTituloCompetencia_F_Sel);
         AV54TFTituloProrrogacao = DateTime.MinValue;
         AssignAttri("", false, "AV54TFTituloProrrogacao", context.localUtil.Format(AV54TFTituloProrrogacao, "99/99/9999"));
         AV55TFTituloProrrogacao_To = DateTime.MinValue;
         AssignAttri("", false, "AV55TFTituloProrrogacao_To", context.localUtil.Format(AV55TFTituloProrrogacao_To, "99/99/9999"));
         AV72TFTituloTipo_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV77TFTituloSaldo_F = 0;
         AssignAttri("", false, "AV77TFTituloSaldo_F", StringUtil.LTrimStr( AV77TFTituloSaldo_F, 18, 2));
         AV78TFTituloSaldo_F_To = 0;
         AssignAttri("", false, "AV78TFTituloSaldo_F_To", StringUtil.LTrimStr( AV78TFTituloSaldo_F_To, 18, 2));
         AV79TFTituloStatus_F = "";
         AssignAttri("", false, "AV79TFTituloStatus_F", AV79TFTituloStatus_F);
         AV80TFTituloStatus_F_Sel = "";
         AssignAttri("", false, "AV80TFTituloStatus_F_Sel", AV80TFTituloStatus_F_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV17DynamicFiltersSelector1 = "TITULOVALOR";
         AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19TituloValor1 = 0;
         AssignAttri("", false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
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
         if ( StringUtil.StrCmp(AV32Session.Get(AV105Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV105Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV32Session.Get(AV105Pgmname+"GridState"), null, "", "");
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
         AV135GXV1 = 1;
         while ( AV135GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV135GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOID") == 0 )
            {
               AV103TFTituloId = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFTituloId", StringUtil.LTrimStr( (decimal)(AV103TFTituloId), 9, 0));
               AV104TFTituloId_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFTituloId_To", StringUtil.LTrimStr( (decimal)(AV104TFTituloId_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOVALOR") == 0 )
            {
               AV38TFTituloValor = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV38TFTituloValor", StringUtil.LTrimStr( AV38TFTituloValor, 18, 2));
               AV39TFTituloValor_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV39TFTituloValor_To", StringUtil.LTrimStr( AV39TFTituloValor_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULODESCONTO") == 0 )
            {
               AV40TFTituloDesconto = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV40TFTituloDesconto", StringUtil.LTrimStr( AV40TFTituloDesconto, 18, 2));
               AV41TFTituloDesconto_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV41TFTituloDesconto_To", StringUtil.LTrimStr( AV41TFTituloDesconto_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F") == 0 )
            {
               AV52TFTituloCompetencia_F = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFTituloCompetencia_F", AV52TFTituloCompetencia_F);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOCOMPETENCIA_F_SEL") == 0 )
            {
               AV53TFTituloCompetencia_F_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFTituloCompetencia_F_Sel", AV53TFTituloCompetencia_F_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOPRORROGACAO") == 0 )
            {
               AV54TFTituloProrrogacao = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 4);
               AssignAttri("", false, "AV54TFTituloProrrogacao", context.localUtil.Format(AV54TFTituloProrrogacao, "99/99/9999"));
               AV55TFTituloProrrogacao_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 4);
               AssignAttri("", false, "AV55TFTituloProrrogacao_To", context.localUtil.Format(AV55TFTituloProrrogacao_To, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOTIPO_SEL") == 0 )
            {
               AV71TFTituloTipo_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFTituloTipo_SelsJson", AV71TFTituloTipo_SelsJson);
               AV72TFTituloTipo_Sels.FromJSonString(AV71TFTituloTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSALDO_F") == 0 )
            {
               AV77TFTituloSaldo_F = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV77TFTituloSaldo_F", StringUtil.LTrimStr( AV77TFTituloSaldo_F, 18, 2));
               AV78TFTituloSaldo_F_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV78TFTituloSaldo_F_To", StringUtil.LTrimStr( AV78TFTituloSaldo_F_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F") == 0 )
            {
               AV79TFTituloStatus_F = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFTituloStatus_F", AV79TFTituloStatus_F);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTITULOSTATUS_F_SEL") == 0 )
            {
               AV80TFTituloStatus_F_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFTituloStatus_F_Sel", AV80TFTituloStatus_F_Sel);
            }
            AV135GXV1 = (int)(AV135GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFTituloCompetencia_F_Sel)),  AV53TFTituloCompetencia_F_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV72TFTituloTipo_Sels.Count==0),  AV71TFTituloTipo_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFTituloStatus_F_Sel)),  AV80TFTituloStatus_F_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char2+"||"+GXt_char4+"||"+GXt_char5;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTituloCompetencia_F)),  AV52TFTituloCompetencia_F, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFTituloStatus_F)),  AV79TFTituloStatus_F, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((0==AV103TFTituloId) ? "" : StringUtil.Str( (decimal)(AV103TFTituloId), 9, 0))+"|"+((Convert.ToDecimal(0)==AV38TFTituloValor) ? "" : StringUtil.Str( AV38TFTituloValor, 18, 2))+"|"+((Convert.ToDecimal(0)==AV40TFTituloDesconto) ? "" : StringUtil.Str( AV40TFTituloDesconto, 18, 2))+"|"+GXt_char5+"|"+((DateTime.MinValue==AV54TFTituloProrrogacao) ? "" : context.localUtil.DToC( AV54TFTituloProrrogacao, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV77TFTituloSaldo_F) ? "" : StringUtil.Str( AV77TFTituloSaldo_F, 18, 2))+"|"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV104TFTituloId_To) ? "" : StringUtil.Str( (decimal)(AV104TFTituloId_To), 9, 0))+"|"+((Convert.ToDecimal(0)==AV39TFTituloValor_To) ? "" : StringUtil.Str( AV39TFTituloValor_To, 18, 2))+"|"+((Convert.ToDecimal(0)==AV41TFTituloDesconto_To) ? "" : StringUtil.Str( AV41TFTituloDesconto_To, 18, 2))+"||"+((DateTime.MinValue==AV55TFTituloProrrogacao_To) ? "" : context.localUtil.DToC( AV55TFTituloProrrogacao_To, 4, "/"))+"||"+((Convert.ToDecimal(0)==AV78TFTituloSaldo_F_To) ? "" : StringUtil.Str( AV78TFTituloSaldo_F_To, 18, 2))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
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
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19TituloValor1 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
               AssignAttri("", false, "AV19TituloValor1", StringUtil.LTrimStr( AV19TituloValor1, 18, 2));
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
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23TituloValor2 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                  AssignAttri("", false, "AV23TituloValor2", StringUtil.LTrimStr( AV23TituloValor2, 18, 2));
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
                  AV24DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27TituloValor3 = NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, ".");
                     AssignAttri("", false, "AV27TituloValor3", StringUtil.LTrimStr( AV27TituloValor3, 18, 2));
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
         if ( AV28DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV32Session.Get(AV105Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  AV16FilterFullText,  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOID",  "Titulo",  !((0==AV103TFTituloId)&&(0==AV104TFTituloId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV103TFTituloId), 9, 0)),  ((0==AV103TFTituloId) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV103TFTituloId), "ZZZZZZZZ9"))),  true,  StringUtil.Trim( StringUtil.Str( (decimal)(AV104TFTituloId_To), 9, 0)),  ((0==AV104TFTituloId_To) ? "" : StringUtil.Trim( context.localUtil.Format( (decimal)(AV104TFTituloId_To), "ZZZZZZZZ9")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOVALOR",  "Valor",  !((Convert.ToDecimal(0)==AV38TFTituloValor)&&(Convert.ToDecimal(0)==AV39TFTituloValor_To)),  0,  StringUtil.Trim( StringUtil.Str( AV38TFTituloValor, 18, 2)),  ((Convert.ToDecimal(0)==AV38TFTituloValor) ? "" : StringUtil.Trim( context.localUtil.Format( AV38TFTituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV39TFTituloValor_To, 18, 2)),  ((Convert.ToDecimal(0)==AV39TFTituloValor_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV39TFTituloValor_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULODESCONTO",  "Desconto",  !((Convert.ToDecimal(0)==AV40TFTituloDesconto)&&(Convert.ToDecimal(0)==AV41TFTituloDesconto_To)),  0,  StringUtil.Trim( StringUtil.Str( AV40TFTituloDesconto, 18, 2)),  ((Convert.ToDecimal(0)==AV40TFTituloDesconto) ? "" : StringUtil.Trim( context.localUtil.Format( AV40TFTituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV41TFTituloDesconto_To, 18, 2)),  ((Convert.ToDecimal(0)==AV41TFTituloDesconto_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV41TFTituloDesconto_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTITULOCOMPETENCIA_F",  "Competência",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFTituloCompetencia_F)),  0,  AV52TFTituloCompetencia_F,  AV52TFTituloCompetencia_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFTituloCompetencia_F_Sel)),  AV53TFTituloCompetencia_F_Sel,  AV53TFTituloCompetencia_F_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOPRORROGACAO",  "Vencimento",  !((DateTime.MinValue==AV54TFTituloProrrogacao)&&(DateTime.MinValue==AV55TFTituloProrrogacao_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV54TFTituloProrrogacao, 4, "/")),  ((DateTime.MinValue==AV54TFTituloProrrogacao) ? "" : StringUtil.Trim( context.localUtil.Format( AV54TFTituloProrrogacao, "99/99/9999"))),  true,  StringUtil.Trim( context.localUtil.DToC( AV55TFTituloProrrogacao_To, 4, "/")),  ((DateTime.MinValue==AV55TFTituloProrrogacao_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV55TFTituloProrrogacao_To, "99/99/9999")))) ;
         AV101AuxText = ((AV72TFTituloTipo_Sels.Count==1) ? "["+((string)AV72TFTituloTipo_Sels.Item(1))+"]" : "Vários valores");
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOTIPO_SEL",  "Tipo",  !(AV72TFTituloTipo_Sels.Count==0),  0,  AV72TFTituloTipo_Sels.ToJSonString(false),  ((StringUtil.StrCmp(AV101AuxText, "")==0) ? "" : StringUtil.StringReplace( StringUtil.StringReplace( AV101AuxText, "[DEBITO]", "Débito"), "[CREDITO]", "Crédito")),  false,  "",  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTITULOSALDO_F",  "Saldo",  !((Convert.ToDecimal(0)==AV77TFTituloSaldo_F)&&(Convert.ToDecimal(0)==AV78TFTituloSaldo_F_To)),  0,  StringUtil.Trim( StringUtil.Str( AV77TFTituloSaldo_F, 18, 2)),  ((Convert.ToDecimal(0)==AV77TFTituloSaldo_F) ? "" : StringUtil.Trim( context.localUtil.Format( AV77TFTituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))),  true,  StringUtil.Trim( StringUtil.Str( AV78TFTituloSaldo_F_To, 18, 2)),  ((Convert.ToDecimal(0)==AV78TFTituloSaldo_F_To) ? "" : StringUtil.Trim( context.localUtil.Format( AV78TFTituloSaldo_F_To, "ZZZ,ZZZ,ZZZ,ZZ9.99")))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTITULOSTATUS_F",  "Situação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFTituloStatus_F)),  0,  AV79TFTituloStatus_F,  AV79TFTituloStatus_F,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFTituloStatus_F_Sel)),  AV80TFTituloStatus_F_Sel,  AV80TFTituloStatus_F_Sel) ;
         if ( ! (0==AV7ClienteId) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTEID";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV7ClienteId), 9, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102ClienteRazaoSocial)) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&CLIENTERAZAOSOCIAL";
            AV12GridStateFilterValue.gxTpr_Value = AV102ClienteRazaoSocial;
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV105Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV29DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV17DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV19TituloValor1) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV18DynamicFiltersOperator1,  StringUtil.Trim( StringUtil.Str( AV19TituloValor1, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV20DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV21DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV23TituloValor2) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV22DynamicFiltersOperator2,  StringUtil.Trim( StringUtil.Str( AV23TituloValor2, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV24DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "TITULOVALOR") == 0 ) && ! (Convert.ToDecimal(0)==AV27TituloValor3) )
            {
               new GeneXus.Programs.wwpbaseobjects.wwp_gridstateadddynfiltervalue(context ).execute( ref  AV13GridStateDynamicFilter,  "Valor",  AV26DynamicFiltersOperator3,  StringUtil.Trim( StringUtil.Str( AV27TituloValor3, 18, 2)),  StringUtil.Format( "%"+StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3+1), 10, 0)), "<"+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "="+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), ">"+" "+StringUtil.Trim( context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99")), "", "", "", "", "", ""),  false,  "",  "") ;
            }
            if ( AV28DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV105Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Titulo";
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "ClienteId";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV7ClienteId), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV32Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table3_87_512( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor3_Internalname, "Titulo Valor3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor3_Internalname, StringUtil.LTrim( StringUtil.NToC( AV27TituloValor3, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor3_Enabled!=0) ? context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV27TituloValor3, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor3_Visible, edtavTitulovalor3_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListaTitulosCliente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_87_512e( true) ;
         }
         else
         {
            wb_table3_87_512e( false) ;
         }
      }

      protected void wb_table2_65_512( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor2_Internalname, "Titulo Valor2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor2_Internalname, StringUtil.LTrim( StringUtil.NToC( AV23TituloValor2, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor2_Enabled!=0) ? context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV23TituloValor2, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor2_Visible, edtavTitulovalor2_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListaTitulosCliente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListaTitulosCliente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_65_512e( true) ;
         }
         else
         {
            wb_table2_65_512e( false) ;
         }
      }

      protected void wb_table1_43_512( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_105_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_WpListaTitulosCliente.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_titulovalor1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitulovalor1_Internalname, "Titulo Valor1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_105_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitulovalor1_Internalname, StringUtil.LTrim( StringUtil.NToC( AV19TituloValor1, 18, 2, ",", "")), StringUtil.LTrim( ((edtavTitulovalor1_Enabled!=0) ? context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV19TituloValor1, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitulovalor1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTitulovalor1_Visible, edtavTitulovalor1_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WpListaTitulosCliente.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListaTitulosCliente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WpListaTitulosCliente.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_512e( true) ;
         }
         else
         {
            wb_table1_43_512e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7ClienteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         AV102ClienteRazaoSocial = (string)getParm(obj,1);
         AssignAttri("", false, "AV102ClienteRazaoSocial", AV102ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTERAZAOSOCIAL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV102ClienteRazaoSocial, "@!")), context));
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
         PA512( ) ;
         WS512( ) ;
         WE512( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019251560", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("wplistatituloscliente.js", "?202561019251561", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1052( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_105_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_105_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_105_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_105_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_105_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_105_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_105_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_105_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_105_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_105_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_105_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_105_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_105_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_105_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_105_idx;
      }

      protected void SubsflControlProps_fel_1052( )
      {
         edtavDisplay_Internalname = "vDISPLAY_"+sGXsfl_105_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_105_fel_idx;
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL_"+sGXsfl_105_fel_idx;
         edtTituloId_Internalname = "TITULOID_"+sGXsfl_105_fel_idx;
         edtTituloValor_Internalname = "TITULOVALOR_"+sGXsfl_105_fel_idx;
         edtTituloDesconto_Internalname = "TITULODESCONTO_"+sGXsfl_105_fel_idx;
         chkTituloDeleted_Internalname = "TITULODELETED_"+sGXsfl_105_fel_idx;
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO_"+sGXsfl_105_fel_idx;
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES_"+sGXsfl_105_fel_idx;
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F_"+sGXsfl_105_fel_idx;
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO_"+sGXsfl_105_fel_idx;
         cmbTituloTipo_Internalname = "TITULOTIPO_"+sGXsfl_105_fel_idx;
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F_"+sGXsfl_105_fel_idx;
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F_"+sGXsfl_105_fel_idx;
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F_"+sGXsfl_105_fel_idx;
      }

      protected void sendrow_1052( )
      {
         sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
         SubsflControlProps_1052( ) ;
         WB510( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_105_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_105_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_105_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_105_idx + "',105)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDisplay_Internalname,StringUtil.RTrim( AV98Display),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDisplay_Link,(string)"",(string)"Mostrar",(string)"",(string)edtavDisplay_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(short)-1,(int)edtavDisplay_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteRazaoSocial_Internalname,(string)A170ClienteRazaoSocial,StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteRazaoSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)150,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloDesconto_Internalname,StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloDesconto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TITULODELETED_" + sGXsfl_105_idx;
            chkTituloDeleted.Name = GXCCtl;
            chkTituloDeleted.WebTags = "";
            chkTituloDeleted.Caption = "";
            AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_105_Refreshing);
            chkTituloDeleted.CheckedValue = "false";
            A284TituloDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A284TituloDeleted));
            n284TituloDeleted = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTituloDeleted_Internalname,StringUtil.BoolToStr( A284TituloDeleted),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaAno_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaAno_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetenciaMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetenciaMes_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloCompetencia_F_Internalname,(string)A295TituloCompetencia_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloCompetencia_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloProrrogacao_Internalname,context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"),context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloProrrogacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtTituloProrrogacao_Columnclass,(string)edtTituloProrrogacao_Columnheaderclass,(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTituloTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TITULOTIPO_" + sGXsfl_105_idx;
               cmbTituloTipo.Name = GXCCtl;
               cmbTituloTipo.WebTags = "";
               cmbTituloTipo.addItem("DEBITO", "Débito", 0);
               cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
               if ( cmbTituloTipo.ItemCount > 0 )
               {
                  A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
                  n283TituloTipo = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTituloTipo,(string)cmbTituloTipo_Internalname,StringUtil.RTrim( A283TituloTipo),(short)1,(string)cmbTituloTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbTituloTipo_Columnclass,(string)cmbTituloTipo_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
            AssignProp("", false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), !bGXsfl_105_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloTotalMovimento_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloTotalMovimento_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloSaldo_F_Internalname,StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloSaldo_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)0,(bool)true,(string)"Valor",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTituloStatus_F_Internalname,(string)A282TituloStatus_F,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTituloStatus_F_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)105,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes512( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_105_idx = ((subGrid_Islastpage==1)&&(nGXsfl_105_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_105_idx+1);
            sGXsfl_105_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_105_idx), 4, 0), 4, "0");
            SubsflControlProps_1052( ) ;
         }
         /* End function sendrow_1052 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TITULOVALOR", "Valor", 0);
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
         cmbavDynamicfiltersselector2.addItem("TITULOVALOR", "Valor", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV21DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV21DynamicFiltersSelector2);
            AssignAttri("", false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TITULOVALOR", "Valor", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV25DynamicFiltersSelector3);
            AssignAttri("", false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "<", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", ">", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "TITULODELETED_" + sGXsfl_105_idx;
         chkTituloDeleted.Name = GXCCtl;
         chkTituloDeleted.WebTags = "";
         chkTituloDeleted.Caption = "";
         AssignProp("", false, chkTituloDeleted_Internalname, "TitleCaption", chkTituloDeleted.Caption, !bGXsfl_105_Refreshing);
         chkTituloDeleted.CheckedValue = "false";
         A284TituloDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A284TituloDeleted));
         n284TituloDeleted = false;
         GXCCtl = "TITULOTIPO_" + sGXsfl_105_idx;
         cmbTituloTipo.Name = GXCCtl;
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl105( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"105\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Titulo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Desconto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Título deletado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Ano") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Mês") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Competência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Vencimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Total movimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Saldo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV98Display)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDisplay_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDisplay_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170ClienteRazaoSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A284TituloDeleted)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A295TituloCompetencia_F));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A264TituloProrrogacao, "99/99/9999")));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtTituloProrrogacao_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtTituloProrrogacao_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A283TituloTipo));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbTituloTipo_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbTituloTipo_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A282TituloStatus_F));
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
         edtavClienterazaosocial_Internalname = "vCLIENTERAZAOSOCIAL";
         divDatacontentcellfl_Internalname = "DATACONTENTCELLFL";
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
         edtavTitulovalor1_Internalname = "vTITULOVALOR1";
         cellFilter_titulovalor1_cell_Internalname = "FILTER_TITULOVALOR1_CELL";
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
         edtavTitulovalor2_Internalname = "vTITULOVALOR2";
         cellFilter_titulovalor2_cell_Internalname = "FILTER_TITULOVALOR2_CELL";
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
         edtavTitulovalor3_Internalname = "vTITULOVALOR3";
         cellFilter_titulovalor3_cell_Internalname = "FILTER_TITULOVALOR3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         Dvpanel_tableheader_Internalname = "DVPANEL_TABLEHEADER";
         edtavDisplay_Internalname = "vDISPLAY";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtTituloId_Internalname = "TITULOID";
         edtTituloValor_Internalname = "TITULOVALOR";
         edtTituloDesconto_Internalname = "TITULODESCONTO";
         chkTituloDeleted_Internalname = "TITULODELETED";
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO";
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES";
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F";
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO";
         cmbTituloTipo_Internalname = "TITULOTIPO";
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F";
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F";
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         bttBtnexportreport_Internalname = "BTNEXPORTREPORT";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         edtavDdo_tituloprorrogacaoauxdatetext_Internalname = "vDDO_TITULOPRORROGACAOAUXDATETEXT";
         Tftituloprorrogacao_rangepicker_Internalname = "TFTITULOPRORROGACAO_RANGEPICKER";
         divDdo_tituloprorrogacaoauxdates_Internalname = "DDO_TITULOPRORROGACAOAUXDATES";
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
         edtTituloStatus_F_Jsonclick = "";
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Jsonclick = "";
         cmbTituloTipo_Jsonclick = "";
         cmbTituloTipo_Columnclass = "WWColumn";
         edtTituloProrrogacao_Jsonclick = "";
         edtTituloProrrogacao_Columnclass = "WWColumn";
         edtTituloCompetencia_F_Jsonclick = "";
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloCompetenciaAno_Jsonclick = "";
         chkTituloDeleted.Caption = "";
         edtTituloDesconto_Jsonclick = "";
         edtTituloValor_Jsonclick = "";
         edtTituloId_Jsonclick = "";
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteId_Jsonclick = "";
         edtavDisplay_Jsonclick = "";
         edtavDisplay_Link = "";
         edtavDisplay_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavTitulovalor1_Jsonclick = "";
         edtavTitulovalor1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTitulovalor2_Jsonclick = "";
         edtavTitulovalor2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTitulovalor3_Jsonclick = "";
         edtavTitulovalor3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTitulovalor3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTitulovalor2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTitulovalor1_Visible = 1;
         cmbTituloTipo_Columnheaderclass = "";
         edtTituloProrrogacao_Columnheaderclass = "";
         edtTituloStatus_F_Enabled = 0;
         edtTituloSaldo_F_Enabled = 0;
         edtTituloTotalMovimento_F_Enabled = 0;
         cmbTituloTipo.Enabled = 0;
         edtTituloProrrogacao_Enabled = 0;
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloCompetenciaMes_Enabled = 0;
         edtTituloCompetenciaAno_Enabled = 0;
         chkTituloDeleted.Enabled = 0;
         edtTituloDesconto_Enabled = 0;
         edtTituloValor_Enabled = 0;
         edtTituloId_Enabled = 0;
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Enabled = 0;
         subGrid_Sortable = 0;
         edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavClienterazaosocial_Jsonclick = "";
         edtavClienterazaosocial_Enabled = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "9.0|18.2|18.2||||18.2|";
         Ddo_grid_Datalistproc = "WpListaTitulosClienteGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||DEBITO:Débito,CREDITO:Crédito||";
         Ddo_grid_Allowmultipleselection = "|||||T||";
         Ddo_grid_Datalisttype = "|||Dynamic||FixedValues||Dynamic";
         Ddo_grid_Includedatalist = "|||T||T||T";
         Ddo_grid_Filterisrange = "T|T|T||P||T|";
         Ddo_grid_Filtertype = "Numeric|Numeric|Numeric|Character|Date||Numeric|Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||T|T";
         Ddo_grid_Includesortasc = "T|T|T||T|T||";
         Ddo_grid_Columnssortvalues = "2|3|4||5|6||";
         Ddo_grid_Columnids = "3:TituloId|4:TituloValor|5:TituloDesconto|9:TituloCompetencia_F|10:TituloProrrogacao|11:TituloTipo|13:TituloSaldo_F|14:TituloStatus_F";
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
         Form.Caption = " Titulo";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV95GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV96GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV97GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","""{"handler":"E12512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"Gridpaginationbar_Selectedpage","ctrl":"GRIDPAGINATIONBAR","prop":"SelectedPage"}]}""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","""{"handler":"E13512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"Gridpaginationbar_Rowsperpageselectedvalue","ctrl":"GRIDPAGINATIONBAR","prop":"RowsPerPageSelectedValue"}]""");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",""","oparms":[{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E14512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtextto_get","ctrl":"DDO_GRID","prop":"FilteredTextTo_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV71TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E28512","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A264TituloProrrogacao","fld":"TITULOPRORROGACAO","type":"date"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"cmbTituloTipo"},{"av":"A283TituloTipo","fld":"TITULOTIPO","type":"svchar"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"AV98Display","fld":"vDISPLAY","type":"char"},{"av":"edtavDisplay_Link","ctrl":"vDISPLAY","prop":"Link"},{"av":"edtTituloProrrogacao_Columnclass","ctrl":"TITULOPRORROGACAO","prop":"Columnclass"},{"av":"cmbTituloTipo"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS1'","""{"handler":"E21512","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS1'",""","oparms":[{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","""{"handler":"E15512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV95GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV96GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV97GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","""{"handler":"E22512","iparms":[{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",""","oparms":[{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator1"}]}""");
         setEventMetadata("'ADDDYNAMICFILTERS2'","""{"handler":"E23512","iparms":[]""");
         setEventMetadata("'ADDDYNAMICFILTERS2'",""","oparms":[{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","""{"handler":"E16512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV95GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV96GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV97GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","""{"handler":"E24512","iparms":[{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",""","oparms":[{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator2"}]}""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","""{"handler":"E17512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"}]""");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",""","oparms":[{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV95GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV96GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV97GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","""{"handler":"E25512","iparms":[{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"}]""");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",""","oparms":[{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"cmbavDynamicfiltersoperator3"}]}""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","""{"handler":"E11512","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV105Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"AV102ClienteRazaoSocial","fld":"vCLIENTERAZAOSOCIAL","pic":"@!","hsh":true,"type":"svchar"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV29DynamicFiltersIgnoreFirst","fld":"vDYNAMICFILTERSIGNOREFIRST","type":"boolean"},{"av":"AV28DynamicFiltersRemoving","fld":"vDYNAMICFILTERSREMOVING","type":"boolean"},{"av":"Gx_date","fld":"vTODAY","hsh":true,"type":"date"},{"av":"Ddo_managefilters_Activeeventkey","ctrl":"DDO_MANAGEFILTERS","prop":"ActiveEventKey"},{"av":"AV71TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"}]""");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",""","oparms":[{"av":"AV35ManageFiltersExecutionStep","fld":"vMANAGEFILTERSEXECUTIONSTEP","pic":"9","type":"int"},{"av":"AV11GridState","fld":"vGRIDSTATE","type":""},{"av":"AV14OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV15OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV16FilterFullText","fld":"vFILTERFULLTEXT","type":"svchar"},{"av":"AV103TFTituloId","fld":"vTFTITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV104TFTituloId_To","fld":"vTFTITULOID_TO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV38TFTituloValor","fld":"vTFTITULOVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV39TFTituloValor_To","fld":"vTFTITULOVALOR_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV40TFTituloDesconto","fld":"vTFTITULODESCONTO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV41TFTituloDesconto_To","fld":"vTFTITULODESCONTO_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV52TFTituloCompetencia_F","fld":"vTFTITULOCOMPETENCIA_F","type":"svchar"},{"av":"AV53TFTituloCompetencia_F_Sel","fld":"vTFTITULOCOMPETENCIA_F_SEL","type":"svchar"},{"av":"AV54TFTituloProrrogacao","fld":"vTFTITULOPRORROGACAO","type":"date"},{"av":"AV55TFTituloProrrogacao_To","fld":"vTFTITULOPRORROGACAO_TO","type":"date"},{"av":"AV72TFTituloTipo_Sels","fld":"vTFTITULOTIPO_SELS","type":""},{"av":"AV77TFTituloSaldo_F","fld":"vTFTITULOSALDO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV78TFTituloSaldo_F_To","fld":"vTFTITULOSALDO_F_TO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV79TFTituloStatus_F","fld":"vTFTITULOSTATUS_F","type":"svchar"},{"av":"AV80TFTituloStatus_F_Sel","fld":"vTFTITULOSTATUS_F_SEL","type":"svchar"},{"av":"Ddo_grid_Selectedvalue_set","ctrl":"DDO_GRID","prop":"SelectedValue_set"},{"av":"Ddo_grid_Filteredtext_set","ctrl":"DDO_GRID","prop":"FilteredText_set"},{"av":"Ddo_grid_Filteredtextto_set","ctrl":"DDO_GRID","prop":"FilteredTextTo_set"},{"av":"cmbavDynamicfiltersselector1"},{"av":"AV17DynamicFiltersSelector1","fld":"vDYNAMICFILTERSSELECTOR1","type":"svchar"},{"av":"cmbavDynamicfiltersoperator1"},{"av":"AV18DynamicFiltersOperator1","fld":"vDYNAMICFILTERSOPERATOR1","pic":"ZZZ9","type":"int"},{"av":"AV19TituloValor1","fld":"vTITULOVALOR1","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"},{"av":"AV71TFTituloTipo_SelsJson","fld":"vTFTITULOTIPO_SELSJSON","type":"vchar"},{"av":"imgAdddynamicfilters1_Visible","ctrl":"ADDDYNAMICFILTERS1","prop":"Visible"},{"av":"imgRemovedynamicfilters1_Visible","ctrl":"REMOVEDYNAMICFILTERS1","prop":"Visible"},{"av":"imgAdddynamicfilters2_Visible","ctrl":"ADDDYNAMICFILTERS2","prop":"Visible"},{"av":"imgRemovedynamicfilters2_Visible","ctrl":"REMOVEDYNAMICFILTERS2","prop":"Visible"},{"av":"lblJsdynamicfilters_Caption","ctrl":"JSDYNAMICFILTERS","prop":"Caption"},{"av":"AV20DynamicFiltersEnabled2","fld":"vDYNAMICFILTERSENABLED2","type":"boolean"},{"av":"cmbavDynamicfiltersselector2"},{"av":"AV21DynamicFiltersSelector2","fld":"vDYNAMICFILTERSSELECTOR2","type":"svchar"},{"av":"cmbavDynamicfiltersoperator2"},{"av":"AV22DynamicFiltersOperator2","fld":"vDYNAMICFILTERSOPERATOR2","pic":"ZZZ9","type":"int"},{"av":"AV23TituloValor2","fld":"vTITULOVALOR2","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"AV24DynamicFiltersEnabled3","fld":"vDYNAMICFILTERSENABLED3","type":"boolean"},{"av":"cmbavDynamicfiltersselector3"},{"av":"AV25DynamicFiltersSelector3","fld":"vDYNAMICFILTERSSELECTOR3","type":"svchar"},{"av":"cmbavDynamicfiltersoperator3"},{"av":"AV26DynamicFiltersOperator3","fld":"vDYNAMICFILTERSOPERATOR3","pic":"ZZZ9","type":"int"},{"av":"AV27TituloValor3","fld":"vTITULOVALOR3","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"edtavTitulovalor1_Visible","ctrl":"vTITULOVALOR1","prop":"Visible"},{"av":"edtavTitulovalor2_Visible","ctrl":"vTITULOVALOR2","prop":"Visible"},{"av":"edtavTitulovalor3_Visible","ctrl":"vTITULOVALOR3","prop":"Visible"},{"av":"AV95GridCurrentPage","fld":"vGRIDCURRENTPAGE","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV96GridPageCount","fld":"vGRIDPAGECOUNT","pic":"ZZZZZZZZZ9","type":"int"},{"av":"AV97GridAppliedFilters","fld":"vGRIDAPPLIEDFILTERS","type":"svchar"},{"av":"edtTituloProrrogacao_Columnheaderclass","ctrl":"TITULOPRORROGACAO","prop":"Columnheaderclass"},{"av":"cmbTituloTipo"},{"av":"AV33ManageFiltersData","fld":"vMANAGEFILTERSDATA","type":""}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E18512","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("'DOEXPORT'","""{"handler":"E19512","iparms":[]}""");
         setEventMetadata("'DOEXPORTREPORT'","""{"handler":"E20512","iparms":[]""");
         setEventMetadata("'DOEXPORTREPORT'",""","oparms":[{"av":"Innewwindow1_Target","ctrl":"INNEWWINDOW1","prop":"Target"},{"av":"Innewwindow1_Height","ctrl":"INNEWWINDOW1","prop":"Height"},{"av":"Innewwindow1_Width","ctrl":"INNEWWINDOW1","prop":"Width"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIA_F","""{"handler":"Valid_Titulocompetencia_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOTIPO","""{"handler":"Valid_Titulotipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOSTATUS_F","""{"handler":"Valid_Titulostatus_f","iparms":[]}""");
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
         wcpOAV102ClienteRazaoSocial = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17DynamicFiltersSelector1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV105Pgmname = "";
         AV16FilterFullText = "";
         AV52TFTituloCompetencia_F = "";
         AV53TFTituloCompetencia_F_Sel = "";
         AV54TFTituloProrrogacao = DateTime.MinValue;
         AV55TFTituloProrrogacao_To = DateTime.MinValue;
         AV72TFTituloTipo_Sels = new GxSimpleCollection<string>();
         AV79TFTituloStatus_F = "";
         AV80TFTituloStatus_F_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV33ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV97GridAppliedFilters = "";
         AV93DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV56DDO_TituloProrrogacaoAuxDate = DateTime.MinValue;
         AV57DDO_TituloProrrogacaoAuxDateTo = DateTime.MinValue;
         AV71TFTituloTipo_SelsJson = "";
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
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         bttBtninsert_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         bttBtnexportreport_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV58DDO_TituloProrrogacaoAuxDateText = "";
         ucTftituloprorrogacao_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV98Display = "";
         A170ClienteRazaoSocial = "";
         A295TituloCompetencia_F = "";
         A264TituloProrrogacao = DateTime.MinValue;
         A283TituloTipo = "";
         A282TituloStatus_F = "";
         GXDecQS = "";
         AV107Wplistatitulosclienteds_2_filterfulltext = "";
         AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 = "";
         AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 = "";
         AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 = "";
         AV125Wplistatitulosclienteds_20_tftitulocompetencia_f = "";
         AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel = "";
         AV127Wplistatitulosclienteds_22_tftituloprorrogacao = DateTime.MinValue;
         AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to = DateTime.MinValue;
         AV129Wplistatitulosclienteds_24_tftitulotipo_sels = new GxSimpleCollection<string>();
         AV132Wplistatitulosclienteds_27_tftitulostatus_f = "";
         AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = "";
         lV107Wplistatitulosclienteds_2_filterfulltext = "";
         lV132Wplistatitulosclienteds_27_tftitulostatus_f = "";
         H00518_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H00518_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H00518_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H00518_n794NotaFiscalId = new bool[] {false} ;
         H00518_A283TituloTipo = new string[] {""} ;
         H00518_n283TituloTipo = new bool[] {false} ;
         H00518_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H00518_n264TituloProrrogacao = new bool[] {false} ;
         H00518_A284TituloDeleted = new bool[] {false} ;
         H00518_n284TituloDeleted = new bool[] {false} ;
         H00518_A276TituloDesconto = new decimal[1] ;
         H00518_n276TituloDesconto = new bool[] {false} ;
         H00518_A262TituloValor = new decimal[1] ;
         H00518_n262TituloValor = new bool[] {false} ;
         H00518_A261TituloId = new int[1] ;
         H00518_n261TituloId = new bool[] {false} ;
         H00518_A170ClienteRazaoSocial = new string[] {""} ;
         H00518_n170ClienteRazaoSocial = new bool[] {false} ;
         H00518_A168ClienteId = new int[1] ;
         H00518_n168ClienteId = new bool[] {false} ;
         H00518_A282TituloStatus_F = new string[] {""} ;
         H00518_n282TituloStatus_F = new bool[] {false} ;
         H00518_A275TituloSaldo_F = new decimal[1] ;
         H00518_n275TituloSaldo_F = new bool[] {false} ;
         H00518_A273TituloTotalMovimento_F = new decimal[1] ;
         H00518_n273TituloTotalMovimento_F = new bool[] {false} ;
         H00518_A286TituloCompetenciaAno = new short[1] ;
         H00518_n286TituloCompetenciaAno = new bool[] {false} ;
         H00518_A287TituloCompetenciaMes = new short[1] ;
         H00518_n287TituloCompetenciaMes = new bool[] {false} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         H005115_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         H005115_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         H005115_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         H005115_n794NotaFiscalId = new bool[] {false} ;
         H005115_A283TituloTipo = new string[] {""} ;
         H005115_n283TituloTipo = new bool[] {false} ;
         H005115_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         H005115_n264TituloProrrogacao = new bool[] {false} ;
         H005115_A284TituloDeleted = new bool[] {false} ;
         H005115_n284TituloDeleted = new bool[] {false} ;
         H005115_A276TituloDesconto = new decimal[1] ;
         H005115_n276TituloDesconto = new bool[] {false} ;
         H005115_A262TituloValor = new decimal[1] ;
         H005115_n262TituloValor = new bool[] {false} ;
         H005115_A261TituloId = new int[1] ;
         H005115_n261TituloId = new bool[] {false} ;
         H005115_A170ClienteRazaoSocial = new string[] {""} ;
         H005115_n170ClienteRazaoSocial = new bool[] {false} ;
         H005115_A168ClienteId = new int[1] ;
         H005115_n168ClienteId = new bool[] {false} ;
         H005115_A282TituloStatus_F = new string[] {""} ;
         H005115_n282TituloStatus_F = new bool[] {false} ;
         H005115_A275TituloSaldo_F = new decimal[1] ;
         H005115_n275TituloSaldo_F = new bool[] {false} ;
         H005115_A273TituloTotalMovimento_F = new decimal[1] ;
         H005115_n273TituloTotalMovimento_F = new bool[] {false} ;
         H005115_A286TituloCompetenciaAno = new short[1] ;
         H005115_n286TituloCompetenciaAno = new bool[] {false} ;
         H005115_A287TituloCompetenciaMes = new short[1] ;
         H005115_n287TituloCompetenciaMes = new bool[] {false} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV34ManageFiltersXml = "";
         AV30ExcelFilename = "";
         AV31ErrorMessage = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV32Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV101AuxText = "";
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wplistatituloscliente__default(),
            new Object[][] {
                new Object[] {
               H00518_A890NotaFiscalParcelamentoID, H00518_n890NotaFiscalParcelamentoID, H00518_A794NotaFiscalId, H00518_n794NotaFiscalId, H00518_A283TituloTipo, H00518_n283TituloTipo, H00518_A264TituloProrrogacao, H00518_n264TituloProrrogacao, H00518_A284TituloDeleted, H00518_n284TituloDeleted,
               H00518_A276TituloDesconto, H00518_n276TituloDesconto, H00518_A262TituloValor, H00518_n262TituloValor, H00518_A261TituloId, H00518_A170ClienteRazaoSocial, H00518_n170ClienteRazaoSocial, H00518_A168ClienteId, H00518_n168ClienteId, H00518_A282TituloStatus_F,
               H00518_n282TituloStatus_F, H00518_A275TituloSaldo_F, H00518_n275TituloSaldo_F, H00518_A273TituloTotalMovimento_F, H00518_n273TituloTotalMovimento_F, H00518_A286TituloCompetenciaAno, H00518_n286TituloCompetenciaAno, H00518_A287TituloCompetenciaMes, H00518_n287TituloCompetenciaMes
               }
               , new Object[] {
               H005115_A890NotaFiscalParcelamentoID, H005115_n890NotaFiscalParcelamentoID, H005115_A794NotaFiscalId, H005115_n794NotaFiscalId, H005115_A283TituloTipo, H005115_n283TituloTipo, H005115_A264TituloProrrogacao, H005115_n264TituloProrrogacao, H005115_A284TituloDeleted, H005115_n284TituloDeleted,
               H005115_A276TituloDesconto, H005115_n276TituloDesconto, H005115_A262TituloValor, H005115_n262TituloValor, H005115_A261TituloId, H005115_A170ClienteRazaoSocial, H005115_n170ClienteRazaoSocial, H005115_A168ClienteId, H005115_n168ClienteId, H005115_A282TituloStatus_F,
               H005115_n282TituloStatus_F, H005115_A275TituloSaldo_F, H005115_n275TituloSaldo_F, H005115_A273TituloTotalMovimento_F, H005115_n273TituloTotalMovimento_F, H005115_A286TituloCompetenciaAno, H005115_n286TituloCompetenciaAno, H005115_A287TituloCompetenciaMes, H005115_n287TituloCompetenciaMes
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV105Pgmname = "WpListaTitulosCliente";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV105Pgmname = "WpListaTitulosCliente";
         edtavClienterazaosocial_Enabled = 0;
         edtavDisplay_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14OrderedBy ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short AV35ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private short nDonePA ;
      private short AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 ;
      private short AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 ;
      private short AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 ;
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
      private int AV7ClienteId ;
      private int wcpOAV7ClienteId ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_105 ;
      private int nGXsfl_105_idx=1 ;
      private int AV103TFTituloId ;
      private int AV104TFTituloId_To ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavClienterazaosocial_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int A168ClienteId ;
      private int A261TituloId ;
      private int subGrid_Islastpage ;
      private int edtavDisplay_Enabled ;
      private int AV106Wplistatitulosclienteds_1_clienteid ;
      private int AV119Wplistatitulosclienteds_14_tftituloid ;
      private int AV120Wplistatitulosclienteds_15_tftituloid_to ;
      private int AV129Wplistatitulosclienteds_24_tftitulotipo_sels_Count ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtTituloId_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetenciaMes_Enabled ;
      private int edtTituloCompetencia_F_Enabled ;
      private int edtTituloProrrogacao_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int AV94PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTitulovalor1_Visible ;
      private int edtavTitulovalor2_Visible ;
      private int edtavTitulovalor3_Visible ;
      private int AV135GXV1 ;
      private int edtavTitulovalor3_Enabled ;
      private int edtavTitulovalor2_Enabled ;
      private int edtavTitulovalor1_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV95GridCurrentPage ;
      private long AV96GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV19TituloValor1 ;
      private decimal AV23TituloValor2 ;
      private decimal AV27TituloValor3 ;
      private decimal AV38TFTituloValor ;
      private decimal AV39TFTituloValor_To ;
      private decimal AV40TFTituloDesconto ;
      private decimal AV41TFTituloDesconto_To ;
      private decimal AV77TFTituloSaldo_F ;
      private decimal AV78TFTituloSaldo_F_To ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A275TituloSaldo_F ;
      private decimal AV110Wplistatitulosclienteds_5_titulovalor1 ;
      private decimal AV114Wplistatitulosclienteds_9_titulovalor2 ;
      private decimal AV118Wplistatitulosclienteds_13_titulovalor3 ;
      private decimal AV121Wplistatitulosclienteds_16_tftitulovalor ;
      private decimal AV122Wplistatitulosclienteds_17_tftitulovalor_to ;
      private decimal AV123Wplistatitulosclienteds_18_tftitulodesconto ;
      private decimal AV124Wplistatitulosclienteds_19_tftitulodesconto_to ;
      private decimal AV130Wplistatitulosclienteds_25_tftitulosaldo_f ;
      private decimal AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_105_idx="0001" ;
      private string AV105Pgmname ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
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
      private string divDatacontentcellfl_Internalname ;
      private string edtavClienterazaosocial_Internalname ;
      private string TempTags ;
      private string edtavClienterazaosocial_Jsonclick ;
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
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string bttBtnexportreport_Internalname ;
      private string bttBtnexportreport_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_tituloprorrogacaoauxdates_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Internalname ;
      private string edtavDdo_tituloprorrogacaoauxdatetext_Jsonclick ;
      private string Tftituloprorrogacao_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV98Display ;
      private string edtavDisplay_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtTituloId_Internalname ;
      private string edtTituloValor_Internalname ;
      private string edtTituloDesconto_Internalname ;
      private string chkTituloDeleted_Internalname ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetenciaMes_Internalname ;
      private string edtTituloCompetencia_F_Internalname ;
      private string edtTituloProrrogacao_Internalname ;
      private string cmbTituloTipo_Internalname ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloStatus_F_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavTitulovalor1_Internalname ;
      private string edtavTitulovalor2_Internalname ;
      private string edtavTitulovalor3_Internalname ;
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
      private string edtTituloProrrogacao_Columnheaderclass ;
      private string cmbTituloTipo_Columnheaderclass ;
      private string edtavDisplay_Link ;
      private string edtTituloProrrogacao_Columnclass ;
      private string cmbTituloTipo_Columnclass ;
      private string GXt_char2 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_titulovalor3_cell_Internalname ;
      private string edtavTitulovalor3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_titulovalor2_cell_Internalname ;
      private string edtavTitulovalor2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_titulovalor1_cell_Internalname ;
      private string edtavTitulovalor1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string sGXsfl_105_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDisplay_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Jsonclick ;
      private string GXCCtl ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetenciaMes_Jsonclick ;
      private string edtTituloCompetencia_F_Jsonclick ;
      private string edtTituloProrrogacao_Jsonclick ;
      private string cmbTituloTipo_Jsonclick ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloStatus_F_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV54TFTituloProrrogacao ;
      private DateTime AV55TFTituloProrrogacao_To ;
      private DateTime Gx_date ;
      private DateTime AV56DDO_TituloProrrogacaoAuxDate ;
      private DateTime AV57DDO_TituloProrrogacaoAuxDateTo ;
      private DateTime A264TituloProrrogacao ;
      private DateTime AV127Wplistatitulosclienteds_22_tftituloprorrogacao ;
      private DateTime AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV29DynamicFiltersIgnoreFirst ;
      private bool AV28DynamicFiltersRemoving ;
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
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n261TituloId ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n284TituloDeleted ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool n264TituloProrrogacao ;
      private bool n283TituloTipo ;
      private bool n273TituloTotalMovimento_F ;
      private bool n275TituloSaldo_F ;
      private bool n282TituloStatus_F ;
      private bool AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 ;
      private bool AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool bGXsfl_105_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV71TFTituloTipo_SelsJson ;
      private string AV34ManageFiltersXml ;
      private string AV102ClienteRazaoSocial ;
      private string wcpOAV102ClienteRazaoSocial ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV16FilterFullText ;
      private string AV52TFTituloCompetencia_F ;
      private string AV53TFTituloCompetencia_F_Sel ;
      private string AV79TFTituloStatus_F ;
      private string AV80TFTituloStatus_F_Sel ;
      private string AV97GridAppliedFilters ;
      private string AV58DDO_TituloProrrogacaoAuxDateText ;
      private string A170ClienteRazaoSocial ;
      private string A295TituloCompetencia_F ;
      private string A283TituloTipo ;
      private string A282TituloStatus_F ;
      private string AV107Wplistatitulosclienteds_2_filterfulltext ;
      private string AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 ;
      private string AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 ;
      private string AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 ;
      private string AV125Wplistatitulosclienteds_20_tftitulocompetencia_f ;
      private string AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ;
      private string AV132Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel ;
      private string lV107Wplistatitulosclienteds_2_filterfulltext ;
      private string lV132Wplistatitulosclienteds_27_tftitulostatus_f ;
      private string AV30ExcelFilename ;
      private string AV31ErrorMessage ;
      private string AV101AuxText ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV32Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableheader ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftituloprorrogacao_rangepicker ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCheckbox chkTituloDeleted ;
      private GXCombobox cmbTituloTipo ;
      private GxSimpleCollection<string> AV72TFTituloTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV33ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV93DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV129Wplistatitulosclienteds_24_tftitulotipo_sels ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00518_A890NotaFiscalParcelamentoID ;
      private bool[] H00518_n890NotaFiscalParcelamentoID ;
      private Guid[] H00518_A794NotaFiscalId ;
      private bool[] H00518_n794NotaFiscalId ;
      private string[] H00518_A283TituloTipo ;
      private bool[] H00518_n283TituloTipo ;
      private DateTime[] H00518_A264TituloProrrogacao ;
      private bool[] H00518_n264TituloProrrogacao ;
      private bool[] H00518_A284TituloDeleted ;
      private bool[] H00518_n284TituloDeleted ;
      private decimal[] H00518_A276TituloDesconto ;
      private bool[] H00518_n276TituloDesconto ;
      private decimal[] H00518_A262TituloValor ;
      private bool[] H00518_n262TituloValor ;
      private int[] H00518_A261TituloId ;
      private bool[] H00518_n261TituloId ;
      private string[] H00518_A170ClienteRazaoSocial ;
      private bool[] H00518_n170ClienteRazaoSocial ;
      private int[] H00518_A168ClienteId ;
      private bool[] H00518_n168ClienteId ;
      private string[] H00518_A282TituloStatus_F ;
      private bool[] H00518_n282TituloStatus_F ;
      private decimal[] H00518_A275TituloSaldo_F ;
      private bool[] H00518_n275TituloSaldo_F ;
      private decimal[] H00518_A273TituloTotalMovimento_F ;
      private bool[] H00518_n273TituloTotalMovimento_F ;
      private short[] H00518_A286TituloCompetenciaAno ;
      private bool[] H00518_n286TituloCompetenciaAno ;
      private short[] H00518_A287TituloCompetenciaMes ;
      private bool[] H00518_n287TituloCompetenciaMes ;
      private Guid[] H005115_A890NotaFiscalParcelamentoID ;
      private bool[] H005115_n890NotaFiscalParcelamentoID ;
      private Guid[] H005115_A794NotaFiscalId ;
      private bool[] H005115_n794NotaFiscalId ;
      private string[] H005115_A283TituloTipo ;
      private bool[] H005115_n283TituloTipo ;
      private DateTime[] H005115_A264TituloProrrogacao ;
      private bool[] H005115_n264TituloProrrogacao ;
      private bool[] H005115_A284TituloDeleted ;
      private bool[] H005115_n284TituloDeleted ;
      private decimal[] H005115_A276TituloDesconto ;
      private bool[] H005115_n276TituloDesconto ;
      private decimal[] H005115_A262TituloValor ;
      private bool[] H005115_n262TituloValor ;
      private int[] H005115_A261TituloId ;
      private bool[] H005115_n261TituloId ;
      private string[] H005115_A170ClienteRazaoSocial ;
      private bool[] H005115_n170ClienteRazaoSocial ;
      private int[] H005115_A168ClienteId ;
      private bool[] H005115_n168ClienteId ;
      private string[] H005115_A282TituloStatus_F ;
      private bool[] H005115_n282TituloStatus_F ;
      private decimal[] H005115_A275TituloSaldo_F ;
      private bool[] H005115_n275TituloSaldo_F ;
      private decimal[] H005115_A273TituloTotalMovimento_F ;
      private bool[] H005115_n273TituloTotalMovimento_F ;
      private short[] H005115_A286TituloCompetenciaAno ;
      private bool[] H005115_n286TituloCompetenciaAno ;
      private short[] H005115_A287TituloCompetenciaMes ;
      private bool[] H005115_n287TituloCompetenciaMes ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wplistatituloscliente__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00518( IGxContext context ,
                                             string A283TituloTipo ,
                                             GxSimpleCollection<string> AV129Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                             string AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                             short AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                             decimal AV110Wplistatitulosclienteds_5_titulovalor1 ,
                                             bool AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                             string AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                             short AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                             decimal AV114Wplistatitulosclienteds_9_titulovalor2 ,
                                             bool AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                             string AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                             short AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                             decimal AV118Wplistatitulosclienteds_13_titulovalor3 ,
                                             int AV119Wplistatitulosclienteds_14_tftituloid ,
                                             int AV120Wplistatitulosclienteds_15_tftituloid_to ,
                                             decimal AV121Wplistatitulosclienteds_16_tftitulovalor ,
                                             decimal AV122Wplistatitulosclienteds_17_tftitulovalor_to ,
                                             decimal AV123Wplistatitulosclienteds_18_tftitulodesconto ,
                                             decimal AV124Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                             DateTime AV127Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                             DateTime AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                             int AV129Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                             decimal A262TituloValor ,
                                             int A261TituloId ,
                                             decimal A276TituloDesconto ,
                                             DateTime A264TituloProrrogacao ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV107Wplistatitulosclienteds_2_filterfulltext ,
                                             string A295TituloCompetencia_F ,
                                             decimal A275TituloSaldo_F ,
                                             string A282TituloStatus_F ,
                                             string AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                             string AV125Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                             decimal AV130Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                             decimal AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                             string AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                             string AV132Wplistatitulosclienteds_27_tftitulostatus_f ,
                                             int A168ClienteId ,
                                             int AV106Wplistatitulosclienteds_1_clienteid ,
                                             bool A284TituloDeleted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[29];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloTipo, T1.TituloProrrogacao, T1.TituloDeleted, T1.TituloDesconto, T1.TituloValor, T1.TituloId, T4.ClienteRazaoSocial, T3.ClienteId, COALESCE( T5.TituloStatus_F, '') AS TituloStatus_F, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN (SELECT CASE  WHEN (COALESCE( T9.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T9.TituloSaldo_F, 0) = COALESCE( T8.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T8.TituloId FROM (Titulo T8 INNER JOIN (SELECT ( COALESCE( T10.TituloValor, 0) - COALESCE( T10.TituloDesconto, 0)) - COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T10.TituloId FROM (Titulo T10 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T10.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T10.TituloId) ) T9 ON T9.TituloId = T8.TituloId) ) T5 ON T5.TituloId = T1.TituloId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT";
         scmdbuf += " JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV130Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T6.TituloSaldo_F, 0) >= :AV130Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T6.TituloSaldo_F, 0) <= :AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV132Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( COALESCE( T5.TituloStatus_F, '') like :lV132Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( COALESCE( T5.TituloStatus_F, '') = ( :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T5.TituloStatus_F, '')))=0)))");
         AddWhere(sWhereString, "(T3.ClienteId = :AV106Wplistatitulosclienteds_1_clienteid)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (0==AV119Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV119Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (0==AV120Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV120Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV121Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV121Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV122Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV122Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV123Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV123Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV124Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV124Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV127Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV127Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( AV129Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV129Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.TituloCompetenciaAno DESC, T1.TituloCompetenciaMes DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloId DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloTipo DESC, T1.TituloId";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H005115( IGxContext context ,
                                              string A283TituloTipo ,
                                              GxSimpleCollection<string> AV129Wplistatitulosclienteds_24_tftitulotipo_sels ,
                                              string AV108Wplistatitulosclienteds_3_dynamicfiltersselector1 ,
                                              short AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 ,
                                              decimal AV110Wplistatitulosclienteds_5_titulovalor1 ,
                                              bool AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 ,
                                              string AV112Wplistatitulosclienteds_7_dynamicfiltersselector2 ,
                                              short AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 ,
                                              decimal AV114Wplistatitulosclienteds_9_titulovalor2 ,
                                              bool AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 ,
                                              string AV116Wplistatitulosclienteds_11_dynamicfiltersselector3 ,
                                              short AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 ,
                                              decimal AV118Wplistatitulosclienteds_13_titulovalor3 ,
                                              int AV119Wplistatitulosclienteds_14_tftituloid ,
                                              int AV120Wplistatitulosclienteds_15_tftituloid_to ,
                                              decimal AV121Wplistatitulosclienteds_16_tftitulovalor ,
                                              decimal AV122Wplistatitulosclienteds_17_tftitulovalor_to ,
                                              decimal AV123Wplistatitulosclienteds_18_tftitulodesconto ,
                                              decimal AV124Wplistatitulosclienteds_19_tftitulodesconto_to ,
                                              DateTime AV127Wplistatitulosclienteds_22_tftituloprorrogacao ,
                                              DateTime AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to ,
                                              int AV129Wplistatitulosclienteds_24_tftitulotipo_sels_Count ,
                                              decimal A262TituloValor ,
                                              int A261TituloId ,
                                              decimal A276TituloDesconto ,
                                              DateTime A264TituloProrrogacao ,
                                              short AV14OrderedBy ,
                                              bool AV15OrderedDsc ,
                                              string AV107Wplistatitulosclienteds_2_filterfulltext ,
                                              string A295TituloCompetencia_F ,
                                              decimal A275TituloSaldo_F ,
                                              string A282TituloStatus_F ,
                                              string AV126Wplistatitulosclienteds_21_tftitulocompetencia_f_sel ,
                                              string AV125Wplistatitulosclienteds_20_tftitulocompetencia_f ,
                                              decimal AV130Wplistatitulosclienteds_25_tftitulosaldo_f ,
                                              decimal AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to ,
                                              string AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel ,
                                              string AV132Wplistatitulosclienteds_27_tftitulostatus_f ,
                                              int A168ClienteId ,
                                              int AV106Wplistatitulosclienteds_1_clienteid ,
                                              bool A284TituloDeleted )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[29];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoID, T2.NotaFiscalId, T1.TituloTipo, T1.TituloProrrogacao, T1.TituloDeleted, T1.TituloDesconto, T1.TituloValor, T1.TituloId, T4.ClienteRazaoSocial, T3.ClienteId, COALESCE( T5.TituloStatus_F, '') AS TituloStatus_F, COALESCE( T6.TituloSaldo_F, 0) AS TituloSaldo_F, COALESCE( T7.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, T1.TituloCompetenciaAno, T1.TituloCompetenciaMes FROM ((((((Titulo T1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = T1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN (SELECT CASE  WHEN (COALESCE( T9.TituloSaldo_F, 0) = 0) THEN 'Liquidado' ELSE CASE  WHEN COALESCE( T9.TituloSaldo_F, 0) = COALESCE( T8.TituloValor, 0) THEN 'Aberto' ELSE 'Baixado parcialmente' END END AS TituloStatus_F, T8.TituloId FROM (Titulo T8 INNER JOIN (SELECT ( COALESCE( T10.TituloValor, 0) - COALESCE( T10.TituloDesconto, 0)) - COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T10.TituloId FROM (Titulo T10 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T10.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = T10.TituloId) ) T9 ON T9.TituloId = T8.TituloId) ) T5 ON T5.TituloId = T1.TituloId) INNER JOIN (SELECT ( COALESCE( T8.TituloValor, 0) - COALESCE( T8.TituloDesconto, 0)) - COALESCE( T9.TituloTotalMovimento_F, 0) AS TituloSaldo_F, T8.TituloId FROM (Titulo T8 LEFT JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T8.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T9 ON T9.TituloId = T8.TituloId) ) T6 ON T6.TituloId = T1.TituloId) LEFT";
         scmdbuf += " JOIN LATERAL (SELECT TituloId, SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE (T1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T1.TituloId)";
         AddWhere(sWhereString, "((:AV130Wplistatitulosclienteds_25_tftitulosaldo_f = 0) or ( COALESCE( T6.TituloSaldo_F, 0) >= :AV130Wplistatitulosclienteds_25_tftitulosaldo_f))");
         AddWhere(sWhereString, "((:AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to = 0) or ( COALESCE( T6.TituloSaldo_F, 0) <= :AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to))");
         AddWhere(sWhereString, "(Not ( (char_length(trim(trailing ' ' from :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and ( Not (char_length(trim(trailing ' ' from :AV132Wplistatitulosclienteds_27_tftitulostatus_f))=0))) or ( COALESCE( T5.TituloStatus_F, '') like :lV132Wplistatitulosclienteds_27_tftitulostatus_f))");
         AddWhere(sWhereString, "(Not ( Not (char_length(trim(trailing ' ' from :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel))=0) and Not :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel = ( '<#Empty#>')) or ( COALESCE( T5.TituloStatus_F, '') = ( :AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel)))");
         AddWhere(sWhereString, "(:AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel <> ( '<#Empty#>') or ( (char_length(trim(trailing ' ' from COALESCE( T5.TituloStatus_F, '')))=0)))");
         AddWhere(sWhereString, "(T3.ClienteId = :AV106Wplistatitulosclienteds_1_clienteid)");
         AddWhere(sWhereString, "(Not T1.TituloDeleted)");
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Wplistatitulosclienteds_3_dynamicfiltersselector1, "TITULOVALOR") == 0 ) && ( AV109Wplistatitulosclienteds_4_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV110Wplistatitulosclienteds_5_titulovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV110Wplistatitulosclienteds_5_titulovalor1)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV111Wplistatitulosclienteds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV112Wplistatitulosclienteds_7_dynamicfiltersselector2, "TITULOVALOR") == 0 ) && ( AV113Wplistatitulosclienteds_8_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV114Wplistatitulosclienteds_9_titulovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV114Wplistatitulosclienteds_9_titulovalor2)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor < :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor = :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV115Wplistatitulosclienteds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wplistatitulosclienteds_11_dynamicfiltersselector3, "TITULOVALOR") == 0 ) && ( AV117Wplistatitulosclienteds_12_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV118Wplistatitulosclienteds_13_titulovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.TituloValor > :AV118Wplistatitulosclienteds_13_titulovalor3)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (0==AV119Wplistatitulosclienteds_14_tftituloid) )
         {
            AddWhere(sWhereString, "(T1.TituloId >= :AV119Wplistatitulosclienteds_14_tftituloid)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (0==AV120Wplistatitulosclienteds_15_tftituloid_to) )
         {
            AddWhere(sWhereString, "(T1.TituloId <= :AV120Wplistatitulosclienteds_15_tftituloid_to)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV121Wplistatitulosclienteds_16_tftitulovalor) )
         {
            AddWhere(sWhereString, "(T1.TituloValor >= :AV121Wplistatitulosclienteds_16_tftitulovalor)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV122Wplistatitulosclienteds_17_tftitulovalor_to) )
         {
            AddWhere(sWhereString, "(T1.TituloValor <= :AV122Wplistatitulosclienteds_17_tftitulovalor_to)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV123Wplistatitulosclienteds_18_tftitulodesconto) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto >= :AV123Wplistatitulosclienteds_18_tftitulodesconto)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV124Wplistatitulosclienteds_19_tftitulodesconto_to) )
         {
            AddWhere(sWhereString, "(T1.TituloDesconto <= :AV124Wplistatitulosclienteds_19_tftitulodesconto_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV127Wplistatitulosclienteds_22_tftituloprorrogacao) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao >= :AV127Wplistatitulosclienteds_22_tftituloprorrogacao)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to) )
         {
            AddWhere(sWhereString, "(T1.TituloProrrogacao <= :AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( AV129Wplistatitulosclienteds_24_tftitulotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV129Wplistatitulosclienteds_24_tftitulotipo_sels, "T1.TituloTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.TituloCompetenciaAno DESC, T1.TituloCompetenciaMes DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloId DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloValor, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloValor DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloDesconto, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloDesconto DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloProrrogacao, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloProrrogacao DESC, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteId, T1.TituloTipo, T1.TituloId";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteId DESC, T1.TituloTipo DESC, T1.TituloId";
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
                     return conditional_H00518(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (bool)dynConstraints[40] );
               case 1 :
                     return conditional_H005115(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (decimal)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (decimal)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (decimal)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (decimal)dynConstraints[34] , (decimal)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (bool)dynConstraints[40] );
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
          Object[] prmH00518;
          prmH00518 = new Object[] {
          new ParDef("AV130Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV130Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV132Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV132Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV106Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV119Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV120Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV121Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV122Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV123Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV124Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV127Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          Object[] prmH005115;
          prmH005115 = new Object[] {
          new ParDef("AV130Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV130Wplistatitulosclienteds_25_tftitulosaldo_f",GXType.Number,18,2) ,
          new ParDef("AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV131Wplistatitulosclienteds_26_tftitulosaldo_f_to",GXType.Number,18,2) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV132Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("lV132Wplistatitulosclienteds_27_tftitulostatus_f",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV133Wplistatitulosclienteds_28_tftitulostatus_f_sel",GXType.VarChar,40,0) ,
          new ParDef("AV106Wplistatitulosclienteds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV110Wplistatitulosclienteds_5_titulovalor1",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV114Wplistatitulosclienteds_9_titulovalor2",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV118Wplistatitulosclienteds_13_titulovalor3",GXType.Number,18,2) ,
          new ParDef("AV119Wplistatitulosclienteds_14_tftituloid",GXType.Int32,9,0) ,
          new ParDef("AV120Wplistatitulosclienteds_15_tftituloid_to",GXType.Int32,9,0) ,
          new ParDef("AV121Wplistatitulosclienteds_16_tftitulovalor",GXType.Number,18,2) ,
          new ParDef("AV122Wplistatitulosclienteds_17_tftitulovalor_to",GXType.Number,18,2) ,
          new ParDef("AV123Wplistatitulosclienteds_18_tftitulodesconto",GXType.Number,18,2) ,
          new ParDef("AV124Wplistatitulosclienteds_19_tftitulodesconto_to",GXType.Number,18,2) ,
          new ParDef("AV127Wplistatitulosclienteds_22_tftituloprorrogacao",GXType.Date,8,0) ,
          new ParDef("AV128Wplistatitulosclienteds_23_tftituloprorrogacao_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00518", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00518,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005115", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005115,11, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
